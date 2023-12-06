﻿using System.Web.Mvc;

namespace QuanLyCongTrinh.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
           "Admin_Default",
           "admin/{controller}/{action}/{id}", // URL Pattern

           new { controller = "HomeAdmin", action = "Index", id = UrlParameter.Optional }, // Controller và Action
           new[] { "QuanLyCongTrinh.Areas.Admin.Controllers" } // Định rõ namespace cho Area 'Admin'
       );
        }
    }
}