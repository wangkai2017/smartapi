using SmartVerify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Base
{
    [VerifyUserAuthorize]
    public class BaseController : Controller
    {
        public UserInfo CurrentUser
        {
            get { return UserHelper.Instance.GetUser(); }
        }
    }
}