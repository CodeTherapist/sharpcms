using System.Web.Mvc;

namespace SharpCms.Controllers
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
