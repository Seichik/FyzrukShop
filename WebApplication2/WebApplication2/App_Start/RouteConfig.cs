﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Home",
                    action = "List",
                    category = UrlParameter.Optional,
                    page = UrlParameter.Optional
                });

            routes.MapRoute(null,
                    "{category}",
                    new
                    {
                        controller = "Home",
                        action = "List",
                    });
            routes.MapRoute(null,
                    "{category}/Page={page}",
                    new
                    {
                        controller = "Home",
                        action = "List"
                    });

            routes.MapRoute(null,
             "{controller}/{action}/Id={id}",
             new
             {
                 controller = "Home",
                 action = "ItemPage"
             });

            routes.MapRoute(null,
                "{controller}/{action}/{category}/{page}",
                new
                {
                    controller = "Home",
                    action = "List",
                    category = UrlParameter.Optional,
                    page = UrlParameter.Optional
                });
        }
    }
}
