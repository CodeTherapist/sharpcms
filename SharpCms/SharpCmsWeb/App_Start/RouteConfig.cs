using System.Web.Mvc;
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
                url: "{page1}/{page2}/{page3}/{page4}/{page5}",
                defaults: new
                    {
                        controller = "Page",
                        action = "PageView",
                        page1 = "german",
                        page2 = "home",
                        page3 = string.Empty,
                        page4 = string.Empty,
                        page5 = string.Empty
                    }
                );
        }
    }
}