using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Apps.IBLL;
using Apps.IDAL;
using Apps.Infrastructure.IBaseInterface;
using Apps.Model;

namespace Apps.BLL
{
    public class TeacherBLL : ITeacherBLL
    {
        private readonly ITeacherDAL _iTeacherDAL;
        private readonly IUnitOfWork<AutofacDBEntities> _uwork;

        public TeacherBLL(ITeacherDAL iTeacherDAL
        , IUnitOfWork<AutofacDBEntities> uwork)
        {
            this._iTeacherDAL = iTeacherDAL;
            this._uwork = uwork;
        }

        public bool Add(Teacher entity)
        {
            _iTeacherDAL.Add(entity);
            return _uwork.Commit() > 0;
        }
        public bool Delete(Teacher entity)
        {
            _iTeacherDAL.Delete(entity);
            return _uwork.Commit() > 0;
        }

        public bool Update()
        {
            return _uwork.Commit() > 0;
        }

        public Teacher GetModelByCondition(Expression<Func<Teacher, bool>> predicate)
        {
            return _iTeacherDAL.GetModelByCondition(predicate);
        }

        public IQueryable<Teacher> GetList(Expression<Func<Teacher, bool>> predicate
        , Expression<Func<Teacher, object>> orderBy
        , bool isAscending)
        {
            return _iTeacherDAL.GetList(predicate, orderBy, isAscending);
        }

        public IQueryable<Teacher> GetList(Expression<Func<Teacher, bool>> predicate)
        {
            return _iTeacherDAL.GetList(predicate);
        }

        public Teacher GetModelBySql(string sql)
        {
            return _iTeacherDAL.GetModelBySql(sql);
        }
    }
}
