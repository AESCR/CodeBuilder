#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 单位 运管家
// 版权所有。 
//
// 文件名：Repository
// 文件功能描述：
//
// 
// 创建者：名字 AESCR
// 时间：2021/5/10 9:28:35
//
// 修改人：
// 时间：
// 修改说明：
//
// 修改人：
// 时间：
// 修改说明：
//
// 版本：V1.0.0
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using CodeBuilder.DbTool;
using MySql.Data.MySqlClient;

namespace CodeBuilder.RepositoryTool.BaseRepository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DataBaseType DbType = DataBaseType.MsSQL;
        private readonly DbContext _dbContext;
        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<TEntity> Entities => DbEntities.AsQueryable().AsNoTracking();
        public DbSet<TEntity> DbEntities=>_dbContext.Set<TEntity>();
        public bool Insert(params TEntity[] entity)
        {
            try
            {
                foreach (var e in entity)
                {
                    DbEntities.Add(e);
                }
                return _dbContext.SaveChanges()>0;
            }
            catch
            {
                return false;
            }
        }

        public bool BulkInsert(DataTable dt)
        {
            if (DbType == DataBaseType.MySQL)
            {
               return MySqlBulkInsert(dt)>0;
            }else if (DbType == DataBaseType.MsSQL)
            {
                return SqlBulkCopy(dt);
            }
            return false;
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                DbEntities.Remove(entity);
                return _dbContext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Expression<Func<TEntity, bool>> match)
        {
            var listT = _dbContext.Set<TEntity>().Where(match).ToList();
            foreach (var item in listT) _dbContext.Set<TEntity>().Remove(item);
            return _dbContext.SaveChanges()>0;
        }

        public bool Update(TEntity t)
        {
            _dbContext.Set<TEntity>().Attach(t);
            PropertyInfo[] props = t.GetType().GetProperties(BindingFlags.Public |
                                                             BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(t, null) != null)
                {
                    _dbContext.Entry(t).Property(prop.Name).IsModified = true;
                }
            }
            return _dbContext.SaveChanges()>0;
        }

        public bool BulkUpdate(IEnumerable<TEntity> t)
        {
            foreach (TEntity entity in t)
            {
                _dbContext.Set<TEntity>().Attach(entity);
                PropertyInfo[] props = entity.GetType().GetProperties(BindingFlags.Public |
                                                                      BindingFlags.Instance);
                foreach (PropertyInfo prop in props)
                {
                    if (prop.GetValue(entity, null) != null)
                    {
                        _dbContext.Entry(entity).Property(prop.Name).IsModified = true;
                    }
                }
            }
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Expression<Func<TEntity, bool>> @where, Dictionary<string, object> dic)
        {
            IEnumerable<TEntity> result = _dbContext.Set<TEntity>().Where(where).ToList();
            var type = typeof(TEntity);
            var propertyList =
                type.GetProperties(BindingFlags.Public |
                                   BindingFlags.Instance).ToList();
            //遍历结果集
            foreach (var entity in result)
            foreach (var propertyInfo in propertyList)
            {
                var propertyName = propertyInfo.Name;
                if (dic.ContainsKey(propertyName))
                {
                    propertyInfo.SetValue(entity, dic[propertyName]);
                }
            }
            return _dbContext.SaveChanges()>0;
        }

        public IQueryable<TEntity> FromSql(string sql)
        {
            return _dbContext.Database.SqlQuery<TEntity>(sql).AsQueryable();
        }

        public int Count(Expression<Func<TEntity, bool>> whereFun = null)
        {
            return whereFun!=null ? _dbContext.Set<TEntity>().Where(whereFun).Count() : _dbContext.Set<TEntity>().Count();
        }

        public bool Exist(Expression<Func<TEntity, bool>> match)
        {
            var c= Count(match);
            return c>0;
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(match);
            return query.ToList();
        }
        public IEnumerable<TResult> FindAll<TResult>(Expression<Func<TEntity, bool>> match)
        {
            Type sourceType = typeof(TEntity);
            Type resultType = typeof(TResult);
            PropertyInfo[] resultProperties = resultType.GetProperties();
            ParameterExpression xParam = Expression.Parameter(sourceType, "x");
            var memberBindingList = new List<MemberBinding>();
            foreach (var resultProperty in resultProperties)
            {
                var pName = resultProperty.Name;
                var sourceItem = sourceType.GetProperty(pName);
                if (sourceItem == null || sourceItem.PropertyType != resultProperty.PropertyType)
                    continue;
                var property = Expression.PropertyOrField(xParam, sourceItem.Name);
                var memberBinding = Expression.Bind(resultProperty, property);
                memberBindingList.Add(memberBinding);
            }
            var memberInitExpression = Expression.MemberInit(Expression.New(resultType), memberBindingList);
            var lambda = Expression.Lambda<Func<TEntity, TResult>>(memberInitExpression, xParam);
            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(match).Select(lambda);
            return query.ToList();
        }

        public IEnumerable<TEntity> FindAll<TOrderKey>(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, TOrderKey>> orderFun, bool desc = true)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(match);
            query = desc ? query.OrderByDescending(orderFun) : query.OrderBy(orderFun);
            return query.ToList();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(match);
            return query.FirstOrDefault();
        }

        public TEntity Find<TOrderKey>(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, TOrderKey>> orderFun, bool desc = true)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(match);
            query = desc ? query.OrderByDescending(orderFun) : query.OrderBy(orderFun);
            return query.FirstOrDefault();
        }

        public TResult Find<TResult>(Expression<Func<TEntity, bool>> match)
        {
            Type sourceType = typeof(TEntity);
            Type resultType = typeof(TResult);
            PropertyInfo[] resultProperties = resultType.GetProperties();
            ParameterExpression xParam = Expression.Parameter(sourceType, "x");
            var memberBindingList = new List<MemberBinding>();
            foreach (var resultProperty in resultProperties)
            {
                var pName = resultProperty.Name;
                var sourceItem = sourceType.GetProperty(pName);
                if (sourceItem == null || sourceItem.PropertyType != resultProperty.PropertyType)
                    continue;
                var property = Expression.PropertyOrField(xParam, sourceItem.Name);
                var memberBinding = Expression.Bind(resultProperty, property);
                memberBindingList.Add(memberBinding);
            }
            var memberInitExpression = Expression.MemberInit(Expression.New(resultType), memberBindingList);
            var lambda = Expression.Lambda<Func<TEntity, TResult>>(memberInitExpression, xParam);
            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(match).Select(lambda);
            return query.FirstOrDefault();
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> match)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(match);
            return query;
        }


        public IQueryable<TEntity> Filter(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> match)
        {
            return query.Where(match);
        }

        public IQueryable<TEntity> Sort<TOrderKey>(IQueryable<TEntity> query, Expression<Func<TEntity, TOrderKey>> orderFun, bool desc = true)
        {
            query = desc ? query.OrderByDescending(orderFun) : query.OrderBy(orderFun);
            return query;
        }

        public IQueryable<TEntity> PagingQuery(IQueryable<TEntity> query, out int total, int pageIndex = 1, int pageSize = 20)
        {
            var temp = query.AsNoTracking();
            total = temp.Count();
            temp = pageIndex - 1>=0 ? temp.Skip(pageSize * (pageIndex - 1)) : temp.Skip(0);
            return temp.Take(pageSize); ;
        }


        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        #region Sql 批量插入
        /// <summary>
        /// Sql Server将表中资料批量插入到数据库
        /// 转自：http://www.cnblogs.com/mrliuc/archive/2011/01/18/1938271.html
        /// </summary>
        /// <param name="dt"></param>
        private bool SqlBulkCopy(DataTable dt)
        {
            if (string.IsNullOrEmpty(dt.TableName)) throw new Exception("请给DataTable的TableName属性附上表名称");
            var connectionString = _dbContext.Database.Connection.ConnectionString;
            using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.UseInternalTransaction))
            {
                try
                {
                    sqlbulkcopy.DestinationTableName = dt.TableName;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                    }
                    sqlbulkcopy.WriteToServer(dt);
                }
                catch (System.Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///  MySQL 大批量数据插入,返回成功插入行数
        /// </summary>
        /// <param name="table">数据表</param>
        /// <returns>返回成功插入行数</returns>
        private  int MySqlBulkInsert(DataTable table)
        {
            if (string.IsNullOrEmpty(table.TableName)) throw new Exception("请给DataTable的TableName属性附上表名称");
            if (table.Rows.Count == 0) return 0;
            int insertCount = 0;
            string tmpPath = Path.GetTempFileName();
            string csv = DataTableToCsv();
            File.WriteAllText(tmpPath, csv);
            var connectionString = _dbContext.Database.Connection.ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlTransaction tran = null;
                try
                {

                    conn.Open();
                    tran = conn.BeginTransaction();
                    MySqlBulkLoader bulk = new MySqlBulkLoader(conn)
                    {
                        FieldTerminator = ",",
                        FieldQuotationCharacter = '"',
                        EscapeCharacter = '"',
                        LineTerminator = "\r\n",
                        FileName = tmpPath,
                        NumberOfLinesToSkip = 0,
                        TableName = table.TableName,
                    };
                    bulk.Columns.AddRange(table.Columns.Cast<DataColumn>().Select(colum => colum.ColumnName).ToArray());
                    insertCount = bulk.Load();
                    tran.Commit();
                }
                catch
                {
                    tran?.Rollback();
                    return 0;
                }
            }
            File.Delete(tmpPath);
            return insertCount;

            string DataTableToCsv()
            {
                //以半角逗号（即,）作分隔符，列为空也要表达其存在。  
                //列内容如存在半角逗号（即,）则用半角引号（即""）将该字段值包含起来。  
                //列内容如存在半角引号（即"）则应替换成半角双引号（""）转义，并用半角引号（即""）将该字段值包含起来。  
                StringBuilder sb = new StringBuilder();
                DataColumn colum;
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        colum = table.Columns[i];
                        if (i != 0) sb.Append(",");
                        if (colum.DataType == typeof(string) && row[colum].ToString().Contains(","))
                        {
                            sb.Append("\"" + row[colum].ToString().Replace("\"", "\"\"") + "\"");
                        }
                        else sb.Append(row[colum].ToString());
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
        }
        #endregion

    }
}
