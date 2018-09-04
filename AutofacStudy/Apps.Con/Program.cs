using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.BLL;
using Apps.DAL;
using Apps.IBLL;
using Apps.IDAL;
using Apps.Infrastructure.BaseObject;
using Apps.Infrastructure.IBaseInterface;
using Apps.Model;
using Autofac;
using Autofac.Configuration;

namespace Apps.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 普通类型---Student
            //// 创建组件/服务注册的容器
            //var builder = new ContainerBuilder();

            //// 注册类型公开接口
            //builder.RegisterType<StudentDAL>().As<IStudentDAL>();
            //// builder.RegisterType<StudentDAL>().AsSelf().As<IStudentDAL>();
            //builder.RegisterType<StudentBLL>().As<IStudentBLL>();

            //// 编译容器完成注册且准备对象解析
            //var container = builder.Build();

            //// 现在你可以使用 Autofac 解析服务. 例如,这行将执行注册的lambda表达式对于 IConfigReader 服务.
            ////但是我们不推荐直接操作容器，这会导致内存泄漏。
            ////当我们解析出一个组件时，依赖于我们定义的lifetime scope，一个新的对象实例会被创建。
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    //从容器中解析需要使用的组件
            //    var iStudentBLL = scope.Resolve<IStudentBLL>();
            //    //调用解析后的组件中的方法
            //    List<Student> list = iStudentBLL.GetList().ToList();

            //    Console.WriteLine("List中的数据行：" + list.Count);
            //}
            #endregion

            #region 泛型类型---Teacher
            //// 创建组件/服务注册的容器
            //var builder = new ContainerBuilder();

            //// 注册类型公开接口
            //builder.RegisterType<TeacherDAL>().As<ITeacherDAL>();
            //builder.RegisterType<TeacherBLL>().As<ITeacherBLL>();
            ////方式1.以泛型方式注册
            //builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).SingleInstance();
            //builder.RegisterGeneric(typeof(DatabaseFactory<>)).As(typeof(IDatabaseFactory<>)).SingleInstance();

            ////方式2.以普通的方式注册
            ////builder.RegisterType<UnitOfWork<AutofacDBEntities>>().As<IUnitOfWork<AutofacDBEntities>>().SingleInstance();
            ////builder.RegisterType<DatabaseFactory<AutofacDBEntities>>().As<IDatabaseFactory<AutofacDBEntities>>().SingleInstance();

            //// 编译容器完成注册且准备对象解析
            //var container = builder.Build();

            //// 现在你可以使用 Autofac 解析服务. 例如,这行将执行注册的lambda表达式对于 IConfigReader 服务.
            ////但是我们不推荐直接操作容器，这会导致内存泄漏。
            ////当我们解析出一个组件时，依赖于我们定义的lifetime scope，一个新的对象实例会被创建。
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    //从容器中解析需要使用的组件
            //    var iTeacherBLL = scope.Resolve<ITeacherBLL>();
            //    //调用解析后的组件中的方法

            //    List<Teacher> list = iTeacherBLL.GetList(t => t.gKey != null).ToList();
            //    Console.WriteLine("List中的数据行：" + list.Count);

            //    Teacher model = iTeacherBLL.GetModelByCondition(t => t.iAge == 5);
            //    model.dAddTime = DateTime.Now;
            //    Console.WriteLine(iTeacherBLL.Update());

            //    //Teacher model = new Teacher();
            //    //model.gKey = Guid.NewGuid();
            //    //model.iAge = 12;
            //    //model.sName = "郭彤";
            //    //model.dAddTime = DateTime.Now;
            //    //Console.WriteLine(iTeacherBLL.Add(model));
            //}
            #endregion

            #region 普通类型---Student---Config获取配置
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));

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

                Console.WriteLine("List中的数据行：" + list.Count);
            }
            #endregion

            #region 泛型类型---Teacher---Config获取配置(配置失败，无法运行)
            //var builder = new ContainerBuilder();
            ////builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).SingleInstance();
            ////builder.RegisterGeneric(typeof(DatabaseFactory<>)).As(typeof(IDatabaseFactory<>)).SingleInstance();
            //builder.RegisterModule(new ConfigurationSettingsReader("autofac"));

            //// 编译容器完成注册且准备对象解析
            //var container = builder.Build();

            //// 现在你可以使用 Autofac 解析服务. 例如,这行将执行注册的lambda表达式对于 IConfigReader 服务.
            ////但是我们不推荐直接操作容器，这会导致内存泄漏。
            ////当我们解析出一个组件时，依赖于我们定义的lifetime scope，一个新的对象实例会被创建。
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    //从容器中解析需要使用的组件
            //    var iTeacherBLL = scope.Resolve<ITeacherBLL>();
            //    //调用解析后的组件中的方法

            //    List<Teacher> list = iTeacherBLL.GetList(t => t.gKey != null).ToList();
            //    Console.WriteLine("List中的数据行：" + list.Count);

            //    Console.WriteLine("List中的数据行：" + list.Count);
            //}
            #endregion

            Console.ReadKey();
        }
    }
}
