﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyCongTrinh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QuanLyCongTrinh.Controllers" } // Định rõ namespace cho Controller bên ngoài Area
            );
            routes.MapRoute(
               name: "Admin",
               url: "admin/{controller}/{action}/{id}",
               defaults: new { controller = "HomeAdmin", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "QuanLyCongTrinh.Areas.Admin.Controllers" } // Định rõ namespace cho Controller bên ngoài Area
           );

        }
    }
}
