using System.Web.Mvc;
using SharpCms.Core.DataObjects;

namespace SharpCms.Core
{
    public class PageController : Controller
    {
        public ActionResult PageView(string id)
        {
            var page = new PageModel
                {
                    Page = new Page
                        {
                            PageInfo = new PageInfo
                                {
                                    TemplateName = "PageTemplate",
                                    PageName = "Generic Page Page"
                                }
                        }
                };
            var bold = new PageModel
            {
                Page = new Page
                {
                    PageInfo = new PageInfo
                    {
                        TemplateName = "BoldTemplate",
                        PageName = "Generic Bold Page"
                    }
                }
            };

            var model = page;
            if (!string.IsNullOrWhiteSpace(id) && id == "bold")
            {
                model = bold;
            }
            return View(model.Page.PageInfo.TemplateName, model);
        }
    }
}
