using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Apps.Model;

namespace Apps.IBLL
{
    public interface ITeacherBLL
    {       
        bool Add(Teacher entity);

        bool Delete(Teacher entity);

        bool Update();

        Teacher GetModelByCondition(Expression<Func<Teacher, bool>> predicate);

        IQueryable<Teacher> GetList(Expression<Func<Teacher, bool>> predicate,
            Expression<Func<Teacher, object>> orderBy,
            bool isAscending);

        IQueryable<Teacher> GetList(Expression<Func<Teacher, bool>> predicate);

        Teacher GetModelBySql(string sql);
    }
}
