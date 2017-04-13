﻿using SmartCommon.LogHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_EndRequest()
        {
            var statusCode = Context.Response.StatusCode;
            var ex = Context.Request.RequestContext.HttpContext.Error;
            if (statusCode == 400 || statusCode == 500)
            {
                Response.Clear();

                LogService.WriteErrorLog(ex);

                Response.RedirectToRoutePermanent("Error");
            }
        }

    }
}
