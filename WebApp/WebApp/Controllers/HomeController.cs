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
using System.Threading.Tasks;
using System.Threading;
using SmartCache;
using WebApp.Base;
using SmartCommon.ConvertHelper;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
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