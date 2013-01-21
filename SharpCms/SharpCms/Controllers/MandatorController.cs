using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SharpCms.Controllers
{
    public class MandatorController : Controller
    {
        //
        // GET: /Mandator/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Navigation()
        {
            var model = new List<NavigationItem>
                {
                    new NavigationItem{Name = "Site Manager", ActionName = "index", ControllerName = "Sites"},
                    new NavigationItem{Name = "Security", ActionName = "index", ControllerName = "Security"},
                    new NavigationItem{Name = "Templates", ActionName = "index", ControllerName = "Templates"},
                    new NavigationItem{Name = "Media", ActionName = "index", ControllerName = "Media"},
                    new NavigationItem{Name = "News", ActionName = "index", ControllerName = "News"},
                    new NavigationItem{Name = "Blog", ActionName = "index", ControllerName = "Blog"},
                    new NavigationItem{Name = "Plugins", ActionName = "index", ControllerName = "Plugins"},
                    new NavigationItem{Name = "Parameters", ActionName = "index", ControllerName = "Parameters"}
                };
            return View(model);
        }

        public ActionResult DashBoard()
        {
            return View();
        }

    }

    public class NavigationItem
    {
        public NavigationItem()
        {
            Name = String.Empty;
            ActionName = String.Empty;
            ControllerName = String.Empty;
        }
        public object Name { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }
    }
}
