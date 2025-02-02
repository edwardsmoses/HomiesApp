﻿using Data.Services.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AppService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Data.HomiesDbContext, Configuration>());



            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacConfig.RegisterAutofac();

        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            if (exception != null)
                Services.AppLog.Instance.Fatal(exception);
        }
    }
}
