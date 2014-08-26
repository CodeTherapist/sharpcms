using System.Web.Mvc;

namespace SharpCms.Core.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectToRoute(new {Controller = "Sharpcms", Action = "Index"});
        }

    }
}
