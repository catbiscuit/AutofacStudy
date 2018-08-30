using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Apps.Infrastructure.IBaseInterface;

namespace Apps.Infrastructure.BaseObject
{
    public class DALBase<T, TT> : IDALBase<T>
        where T : class
        where TT : ObjectContext
    {
        private TT dataContext;
        private readonly ObjectSet<T> dbset;

        protected IDatabaseFactory<TT> DatabaseFactory
        {
            get;
            private set;
        }

        protected TT DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        protected DALBase(IDatabaseFactory<TT> databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.CreateObjectSet<T>();
        }

        #region 业务公共方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            dbset.AddObject(entity);
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            dbset.DeleteObject(entity);
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="entity"></param>
        public virtual T GetModelByCondition(Expression<Func<T, bool>> predicate)
        {
            return dbset.Where(predicate).FirstOrDefault<T>();
        }

        /// <summary>
        /// 获取全部列表
        /// </summary>
        /// <param name="entity"></param>
        public virtual IQueryable<T> GetList(Expression<Func<T, bool>> predicate,
            Expression<Func<T, Object>> orderBy, bool isAscending)
        {
            if (isAscending)
            {
                return dbset.Where(predicate)
                                         .OrderBy(orderBy);
            }
            else
            {
                return dbset.Where(predicate)
                                        .OrderByDescending(orderBy);
            }
        }
        /// <summary>
        /// 获取全部列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return dbset.Where(predicate);
        }

        ///// <summary>
        ///// 根据条件获取实体
        ///// </summary>
        ///// <param name="entity"></param>
        public virtual T GetModelBySql(string sql)
        {
            return dbset.Context.ExecuteStoreQuery<T>(sql, null).FirstOrDefault<T>();
        }
        #endregion
    }
}
