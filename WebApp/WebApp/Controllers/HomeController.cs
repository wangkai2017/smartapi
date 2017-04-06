using Chloe.SqlServer;
using SmartCommon.DbHelper;
using SmartCommon.SerializerHelper;
using SmartEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        /* DbContext 是非线程安全的，正式使用不能设置为 static */
        private MsSqlContext context = new MsSqlContext(DbHelper.ConnectionString);
        public ActionResult Index()
        {
            var entity = context.Query<Students>();
            var str = SerializerHelper.ObjectToJson(entity.ToList());
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