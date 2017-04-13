using SmartBusiness;
using SmartCache;
using SmartCommon.ConvertHelper;
using SmartCommon.LogHelper;
using SmartEntity;
using SmartExternalEntity.RequestEntity;
using SmartIBusiness;
using SmartVerify;
using System;
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
                    if (token != null && string.IsNullOrEmpty(token) == false)
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
            IUsersBusiness userBusiness = new UsersBusiness();
            var user = new T_Users();
            var loginName = ConvertHelper.ClearInputText(entity.LoginUserName);
            var loginPwd = ConvertHelper.ClearInputText(entity.LoginPwd);

            user = userBusiness.GetUserByPwd(loginName, EncryptionAndDecryptHelper.GetMD5(loginPwd));

            if (user == null || user.Id <= 0)
            {
                return View(user);
            }

            //生成token
            var token = EncryptionAndDecryptHelper.EncryptString(user.Id + "_" + ConvertHelper.ToISO8601DateString(DateTime.Now));

            UserHelper.Instance.CacheUser(token);

            
            if (string.IsNullOrEmpty(entity.ReturnUrl) == false)
            {
                return Redirect(entity.ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        
        public ActionResult LoginOut()
        {
            UserHelper.Instance.SignOut();
            return View();
        }

    }
}