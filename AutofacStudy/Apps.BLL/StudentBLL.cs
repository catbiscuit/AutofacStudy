using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.IBLL;
using Apps.IDAL;
using Apps.Model;

namespace Apps.BLL
{
    public class StudentBLL : IStudentBLL
    {
        private readonly IStudentDAL _iDAL;
        public StudentBLL(IStudentDAL iDAL)
        {
            this._iDAL = iDAL;
        }

        public IQueryable<Student> GetList()
        {
            return _iDAL.GetList();
        }
    }
}
