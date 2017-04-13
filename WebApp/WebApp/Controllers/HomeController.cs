using SmartCommon.SerializerHelper;
using System.Web.Mvc;
using SmartCache;
using SmartIBusiness;
using SmartBusiness;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            IStudentsBusiness studentBusiness = new StudentsBusiness();

            var list = studentBusiness.GetStudentList();
            var str = SerializerHelper.ObjectToJson(list);


            //var obj = LocalCacheHelper.GetCache("key");
            //LocalCacheHelper.SetCache("key", "value", TimeSpan.FromMinutes(10));

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