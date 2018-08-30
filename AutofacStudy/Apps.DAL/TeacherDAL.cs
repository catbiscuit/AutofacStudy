using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.IDAL;
using Apps.Infrastructure.BaseObject;
using Apps.Infrastructure.IBaseInterface;
using Apps.Model;

namespace Apps.DAL
{
    public class TeacherDAL : DALBase<Teacher, AutofacDBEntities>, ITeacherDAL
    {
        public TeacherDAL(IDatabaseFactory<AutofacDBEntities> databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
