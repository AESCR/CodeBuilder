using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CodeBuilder.RepositoryTool.BaseRepository
{
    public interface IRepository<TEntity>:IDisposable where TEntity : class
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
        bool Insert(params TEntity[] entity);
        /// <summary>
        /// 使用Bulk批量插入数据（适合大数据量，速度非常快）
        /// </summary>
        /// <param name="dataTable"></param>
        bool BulkInsert(DataTable dataTable);

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
        /// 筛选对象
        /// </summary>
        /// <param name="query">对象集合</param>
        /// <param name="match">符合条件的对象</param>
        /// <returns></returns>
        IQueryable<TEntity> Filter(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> match);
        #endregion

        #region 排序

        /// <summary>
        /// 排序集合
        /// </summary>
        /// <typeparam name="TOrderKey"></typeparam>
        /// <param name="query">对象集合</param>
        /// <param name="orderFun">排序的字段</param>
        /// <param name="desc">是否是降序</param>
        /// <returns></returns>
        IQueryable<TEntity> Sort<TOrderKey>(IQueryable<TEntity> query,Expression<Func<TEntity, TOrderKey>> orderFun, bool desc = true);
        #endregion

        #region 分页
        /// <summary>
        /// 分页总数
        /// </summary>
        /// <param name="query">对象集合</param>
        /// <param name="total">集合总数</param>
        /// <param name="pageIndex">当前页 1开始</param>
        /// <param name="pageSize">一页个数 20</param>
        /// <returns></returns>
        IQueryable<TEntity> PagingQuery(IQueryable<TEntity> query,out int total, int pageIndex = 1, int pageSize = 20);

        #endregion
    }
}