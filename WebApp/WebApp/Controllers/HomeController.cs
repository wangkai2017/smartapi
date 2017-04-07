using Chloe.SqlServer;
using SmartCommon.DbHelper;
using SmartCommon.LogHelper;
using SmartCommon.SerializerHelper;
using SmartEntity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartCommon.ConstHelper;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        /* DbContext 是非线程安全的，正式使用不能设置为 static */
        private MsSqlContext context = new MsSqlContext(DbHelper.ConnectionString, DatabaseNameConst.DBTest);
        public ActionResult Index()
        {
            var entity = context.Query<Students>();
            var t = entity.Where(e => e.Id == 1).FirstOrDefault();
            var str = SerializerHelper.ObjectToJson(t);
            ViewBag.Str = str;
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}