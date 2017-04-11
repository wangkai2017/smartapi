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
            var retUrl = context.HttpContext.Request.QueryString["returnUrl"];
            //验证用户
            
            

        }
    }
}
