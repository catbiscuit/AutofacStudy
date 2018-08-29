using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.IDAL;
using Apps.Model;

namespace Apps.DAL
{
    public class StudentDAL : IStudentDAL
    {
        public IQueryable<Student> GetList()
        {
            AutofacDBEntities db = new AutofacDBEntities();
            IQueryable<Student> list = db.Student.AsQueryable();
            return list;
        }
    }
}
