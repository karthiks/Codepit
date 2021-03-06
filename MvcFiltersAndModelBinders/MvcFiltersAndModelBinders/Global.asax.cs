﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcFiltersAndModelBinders.Models;
using Spark;
using Spark.Web.Mvc;

namespace MvcFiltersAndModelBinders
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Register Spark/Remove WebForms
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new SparkViewFactory());

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Banner), new BannerModelBinder());
        }
    }
}