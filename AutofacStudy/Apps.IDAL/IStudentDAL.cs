using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Model;

namespace Apps.IDAL
{
    public interface IStudentDAL
    {
        IQueryable<Student> GetList();
    }
}
