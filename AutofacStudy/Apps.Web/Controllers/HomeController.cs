using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apps.IBLL;
using Apps.Model;
using Autofac;
using Autofac.Core;

namespace Apps.Web.Controllers
{
    public class HomeController : Controller
    {
        #region 普通类型---Student
        //private readonly IStudentBLL _iBLL;
        //public HomeController(IStudentBLL iBLL)
        //{
        //    this._iBLL = iBLL;
        //}
        //public ActionResult Index()
        //{
        //    List<Student> lstStudent = _iBLL.GetList().ToList();

        //    //为了视图不要重写，将Student类赋值给Teacher类。两个类的字段完全一样
        //    List<Teacher> lstTeacher = new List<Teacher>();
        //    foreach (Student item in lstStudent)
        //    {
        //        Teacher model = new Teacher();
        //        model.gKey = item.gKey;
        //        model.sName = item.sName;
        //        model.iAge = item.iAge;
        //        model.dAddTime = item.dAddTime;
        //        lstTeacher.Add(model);
        //    }

        //    return View(lstTeacher);
        //} 
        #endregion

        #region 将容器保存在Application中---Student
        //private IStudentBLL _iBLL;
        //public ActionResult Index()
        //{
        //    if (_iBLL == null)
        //    {
        //        object oContainer = System.Web.HttpContext.Current.Application["container"];
        //        if (oContainer != null && oContainer != "")
        //        {
        //            IContainer ioc = (IContainer)oContainer;
        //            //当我们解析出一个组件时，依赖于我们定义的lifetime scope，一个新的对象实例会被创建。
        //            using (var scope = ioc.BeginLifetimeScope())
        //            {
        //                //从容器中解析需要使用的组件
        //                _iBLL = scope.Resolve<IStudentBLL>();
        //                //调用解析后的组件中的方法
        //                List<Student> list = _iBLL.GetList().ToList();

        //                Console.WriteLine("List中的数据行：" + list.Count);
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("IOC容器初始化发生错误!");
        //        }
        //    }
        //    List<Student> lstStudent = _iBLL.GetList().ToList();

        //    //为了视图不要重写，将Student类赋值给Teacher类。两个类的字段完全一样
        //    List<Teacher> lstTeacher = new List<Teacher>();
        //    foreach (Student item in lstStudent)
        //    {
        //        Teacher model = new Teacher();
        //        model.gKey = item.gKey;
        //        model.sName = item.sName;
        //        model.iAge = item.iAge;
        //        model.dAddTime = item.dAddTime;
        //        lstTeacher.Add(model);
        //    }

        //    return View(lstTeacher);
        //}
        #endregion

        #region 泛型类型---Teacher
        private readonly ITeacherBLL _iBLL;
        public HomeController(ITeacherBLL iBLL)
        {
            this._iBLL = iBLL;
        }
        public ActionResult Index()
        {
            List<Teacher> lstStudent = _iBLL.GetList(t => t.gKey != null).ToList();

            Teacher model1 = _iBLL.GetModelByCondition(t => t.iAge == 5);
            model1.dAddTime = DateTime.Now;
            _iBLL.Update();

            //Teacher model = new Teacher();
            //model.gKey = Guid.NewGuid();
            //model.iAge = 12;
            //model.sName = "郭彤";
            //model.dAddTime = DateTime.Now;
            //_iBLL.Add(model);

            return View(lstStudent);
        }
        #endregion
    }
}