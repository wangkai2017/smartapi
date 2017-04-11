using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SmartVerify
{
    public class VerifyUserAuthorize: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext context)
        {
            base.OnAuthorization(context);
            return;
            var returnUrl = context.HttpContext.Request.QueryString["returnUrl"];
            //验证用户
            var user = UserHelper.Instance.GetUser();
            if (user != null && user.UserId > 0)
            {
                return;            
            }
            context.HttpContext.Response.Redirect(SmartConstArgs.SmartUrl + "Login/Index" + "?returnUrl=" + returnUrl);
            context.Result = new HttpUnauthorizedResult();
            return;
        }
    }
}
