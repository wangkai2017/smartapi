using SmartCache;
using SmartCommon.LogHelper;
using SmartEntity.RequestEntity;
using SmartVerify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string returnUrl)
        {
            try
            {
                var user = UserHelper.Instance.GetUser();
                if (user != null)
                {
                    var token = CookieHelper.GetCookieValue(SmartConstArgs.UserToken);
                    if (token!=null&&string.IsNullOrEmpty(token)==false)
                    {
                        return Redirect(returnUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.WriteErrorLog(ex, extContent: "获取用户失败");                
            }            
            return View();
        }

        [HttpPost]
        public ActionResult LoginIn(LoginRequestEntity entity)
        {            
            return View();
        }
        
        public ActionResult LoginOut()
        {
            UserHelper.Instance.SignOut();
            return View();
        }

    }
}