using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Apps.BLL;
using Apps.DAL;
using Apps.IBLL;
using Apps.IDAL;
using Apps.Infrastructure.BaseObject;
using Apps.Infrastructure.IBaseInterface;
using Apps.Web.Controllers;
using Autofac;
using Autofac.Integration.Mvc;

namespace Apps.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            #region 普通类型---Student
            //// 创建组件/服务注册的容器
            //var builder = new ContainerBuilder();

            //// 注册类型公开接口
            //builder.RegisterType<StudentDAL>().As<IStudentDAL>();
            //builder.RegisterType<StudentBLL>().As<IStudentBLL>();

            ////方式1：单个Controller的注册(项目中有多少个Controller就要写多少次)
            //builder.RegisterType<HomeController>().InstancePerDependency();
            ////方式2：使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            ////builder.RegisterControllers(Assembly.GetExecutingAssembly());

            ////生成具体的实例
            //var container = builder.Build();
            ////下面就是使用MVC的扩展 更改了MVC中的注入方式.
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion

            #region 将容器保存在Application中---Student
            //// 创建组件/服务注册的容器
            //var builder = new ContainerBuilder();

            //// 注册类型公开接口
            //builder.RegisterType<StudentDAL>().As<IStudentDAL>();
            //builder.RegisterType<StudentBLL>().As<IStudentBLL>();

            ////方式1：单个Controller的注册(项目中有多少个Controller就要写多少次)
            ////builder.RegisterType<HomeController>().InstancePerDependency();
            ////方式2：使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            ////builder.RegisterControllers(Assembly.GetExecutingAssembly());

            ////生成具体的实例
            //var container = builder.Build();
            ////下面就是使用MVC的扩展 更改了MVC中的注入方式.
            ////DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //Application.Add("container", container);
            #endregion

            #region 泛型类型---Teacher
            // 创建组件/服务注册的容器
            var builder = new ContainerBuilder();

            // 注册类型公开接口

            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).SingleInstance();
            builder.RegisterGeneric(typeof(DatabaseFactory<>)).As(typeof(IDatabaseFactory<>)).SingleInstance();

            builder.RegisterType<TeacherBLL>().As<ITeacherBLL>();
            builder.RegisterType<TeacherDAL>().As<ITeacherDAL>();

            //方式1：单个Controller的注册(项目中有多少个Controller就要写多少次)
            //builder.RegisterType<HomeController>().InstancePerDependency();
            //方式2：使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //生成具体的实例
            var container = builder.Build();
            //下面就是使用MVC的扩展 更改了MVC中的注入方式.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion
        }
    }
}
