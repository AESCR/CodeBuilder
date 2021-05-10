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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace CodeBuilder.RepositoryTool
{
    public class EfRepository<TEntity>: IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DbContext _dbContext;
        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<TEntity> Entities => _dbContext.Set<TEntity>().AsQueryable().AsNoTracking();
        public DbSet<TEntity> DbEntities=>_dbContext.Set<TEntity>();
        public bool Insert(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                return _dbContext.SaveChanges()>0;
            }
            catch
            {
                return false;
            }
        }

        public bool BulkInsert<T>(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Remove(entity);
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

        public bool DeleteById(object id)
        {
            var item = _dbContext.Set<TEntity>().Find(id);
            if (item!=null)
            {
                _dbContext.Set<TEntity>().Remove(item);
                return _dbContext.SaveChanges()>0;
            }
            return false;
        }

        public bool Update(TEntity t)
        {
            _dbContext.Set<TEntity>().Attach(t);
            PropertyInfo[] props = t.GetType().GetProperties();
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
            throw new NotImplementedException();
        }

        public bool Update(Expression<Func<TEntity, bool>> @where, Dictionary<string, object> dic)
        {
            throw new NotImplementedException();
        }

        public bool BulkUpdate(TEntity t)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FromSql(string sql)
        {
            //return _dbContext.Database.e<TEntity>(sql).AsQueryable();
            throw null;
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

        public TEntity FindById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(match);
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
            throw new NotImplementedException();
        }


        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> match)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().Where(match);
            return query;
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> match, out int total, int pageIndex = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
