using Chloe.SqlServer;
using SmartCommon.DbHelper;
using SmartCommon.SerializerHelper;
using SmartEntity;
using System;
using System.Web.Mvc;
using SmartCommon.ConstHelper;
using SmartCache;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        /* DbContext 是非线程安全的，正式使用不能设置为 static */
        private MsSqlContext context = new MsSqlContext(DbHelper.ConnectionString, DatabaseNameConst.DBTest);
        public ActionResult Index()
        {
            var entity = context.Query<T_Students>();
            var t = entity.Where(e => e.Id == 1).FirstOrDefault();
            var str = SerializerHelper.ObjectToJson(t);
            
            var obj = LocalCacheHelper.GetCache("key");
            LocalCacheHelper.SetCache("key", "value", TimeSpan.FromMinutes(10));
            
            ViewBag.Str = str;
            return View();
        }

        public ActionResult About()
        {
            var obj = LocalCacheHelper.GetCache("key");
            ViewBag.Message = (string)obj;

            return View();
        }

        public ActionResult Contact()
        {                                  

            ViewBag.Message = "";            
            return View();
        }
    }
}