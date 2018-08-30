using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Infrastructure.IBaseInterface
{
    public interface IDALBase<T>
        where T : class
    {
        void Add(T entity);

        void Delete(T entity);        
        
        T GetModelByCondition(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetList(Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> orderBy,
            bool isAscending);

        IQueryable<T> GetList(Expression<Func<T, bool>> predicate);
        
        T GetModelBySql(string sql);
    }
}
