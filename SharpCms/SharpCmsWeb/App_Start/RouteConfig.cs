﻿using System.Web.Mvc;
using System.Web.Routing;

namespace SharpCmsWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{id}",
                defaults: new { controller = "Page", action = "PageView", id = UrlParameter.Optional }
            );
        }
    }
}