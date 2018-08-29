using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.BLL;
using Apps.DAL;
using Apps.IBLL;
using Apps.IDAL;
using Apps.Model;
using Autofac;

namespace Apps.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 普通类型---Student
            // 创建组件/服务注册的容器
            var builder = new ContainerBuilder();

            // 注册类型公开接口
           // builder.RegisterType<StudentDAL>().As<IStudentDAL>();
            builder.RegisterType<StudentDAL>().AsSelf().As<IStudentDAL>();
            builder.RegisterType<StudentBLL>().As<IStudentBLL>();

            // 编译容器完成注册且准备对象解析
            var container = builder.Build();

            // 现在你可以使用 Autofac 解析服务. 例如,这行将执行注册的lambda表达式对于 IConfigReader 服务.
            //但是我们不推荐直接操作容器，这会导致内存泄漏。
            //当我们解析出一个组件时，依赖于我们定义的lifetime scope，一个新的对象实例会被创建。
            using (var scope = container.BeginLifetimeScope())
            {
                //从容器中解析需要使用的组件
                var iStudentBLL = scope.Resolve<IStudentBLL>();
                //调用解析后的组件中的方法
                List<Student> list = iStudentBLL.GetList().ToList();

                Console.WriteLine("List中的数据行："+list.Count);
            } 
            #endregion

            #region 泛型类型---Teacher

            #endregion

            Console.ReadKey();
        }
    }
}
