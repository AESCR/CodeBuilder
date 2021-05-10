
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace CodeBuilder.RepositoryTool
{
    public interface IRepository<TEntity>:IDisposable where TEntity: class, new()
    {
        /// <summary>
        /// 获取当前实体的查询数据集
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        /// <summary>
        /// 获取当前实体的数据集
        /// </summary>
        DbSet<TEntity> DbEntities { get; }
        #region 添加

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        bool Insert(TEntity entity);
        /// <summary>
        /// 使用Bulk批量插入数据（适合大数据量，速度非常快）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        bool BulkInsert<T>(List<T> entities);

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        bool Delete(TEntity entity);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="match">匹配条件</param>
        bool Delete(Expression<Func<TEntity, bool>> match);
        /// <summary>
        /// 删除数据通过主键
        /// </summary>
        /// <param name="id"></param>
        bool DeleteById(object id);
        #endregion

        #region 更新

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="t"></param>
        bool Update(TEntity t);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="t"></param>
        bool BulkUpdate(IEnumerable<TEntity> t);
        /// <summary>
        /// 更新指定条件和字段的值
        /// </summary>
        /// <param name="where">指定的条件</param>
        /// <param name="dic">待更新的值</param>
        /// <returns></returns>
        bool Update(Expression<Func<TEntity, bool>> where, Dictionary<string, object> dic);
        #endregion

        #region 执行Sql语句
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IQueryable<TEntity> FromSql(string sql);
        #endregion

        #region 查询

        /// <summary>
        /// 指定条件Count(*)
        /// </summary>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> whereFun = null);
        /// <summary>
        /// 获取数据库中存在的对象
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        bool Exist(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// 根据主键Id查询数据
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        TEntity FindById(object id);
        /// <summary>
        /// 指定条件查询全部数据
        /// </summary>
        /// <param name="match">匹配条件</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// 指定条件查询全部数据
        /// </summary>
        /// <typeparam name="TOrderKey">排序字段</typeparam>
        /// <param name="match">匹配条件</param>
        /// <param name="orderFun">排序</param>
        /// <param name="desc">是否是降序</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll<TOrderKey>(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, TOrderKey>> orderFun, bool desc = true);
        /// <summary>
        /// 指定条件查询一条数据
        /// </summary>
        /// <param name="match">匹配条件</param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> match);
        /// <summary>
        /// 指定条件查询一条数据
        /// </summary>
        /// <typeparam name="TOrderKey">排序字段</typeparam>
        /// <param name="match">匹配条件</param>
        /// <param name="orderFun">排序</param>
        /// <param name="desc">是否是降序</param>
        /// <returns></returns>
        TEntity Find<TOrderKey>(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, TOrderKey>> orderFun, bool desc = true);
        /// <summary>
        /// 指定条件查询一条数据
        /// </summary>
        /// <typeparam name="TResult">自定义查询实体</typeparam>
        /// <param name="match"></param>
        /// <returns></returns>
        TResult Find<TResult>(Expression<Func<TEntity, bool>> match);
        /// <summary>
        /// 通过筛选器从数据库中获取对象。
        /// </summary>
        /// <param name="match">匹配条件</param>
        /// <returns></returns>
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> match);
        /// <summary>
        /// 通过筛选器从数据库中获取对象
        /// </summary>
        /// <param name="match">match</param>
        /// <param name="total">返回筛选器的总记录计数</param>
        /// <param name="pageIndex">指定页索引 从1开始</param>
        /// <param name="pageSize">指定页大小 默认20</param>
        /// <returns></returns>
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> match, out int total, int pageIndex = 1, int pageSize = 20);
        #endregion
    }
}