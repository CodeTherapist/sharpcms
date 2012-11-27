using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using SharpCms.Core.Data;
using SharpCms.Core.DataObjects;

namespace SharpCms.Core
{
    public class PageController : Controller
    {
        public ActionResult PageView(string page1, string page2, string page3, string page4, string page5)
        {
            var path = new[] { page1, page2, page3, page4, page5 };

            var siteTree = TemporaryData.GetSiteTree();

            var model = CreatePageModel(siteTree, path);

            return View(model.Page.PageInfo.Template, model);
        }

        private PageModel CreatePageModel(PageInfo siteTree, string[] path)
        {
            var homepage = GetCurrentPage(siteTree, path, 0);

            var page = new PageModel
                {
                    Page = new Page
                        {
                            PageInfo = homepage
                        },
                    SiteTree = siteTree
                };

            return page;
        }

        private PageInfo GetCurrentPage(PageInfo siteTree, IList<string> path, int level)
        {
            if (siteTree.Children != null)
            {
                foreach (var pageInfo in siteTree.Children)
                {
                    if (path[level] != null)
                    {
                        if (pageInfo.PageName == path[level])
                        {
                            return GetCurrentPage(pageInfo, path, level + 1);
                        }
                    }
                }
            }
            if (level == 0)
            {
                return siteTree.Children.FirstOrDefault();
            }
            return siteTree;
        }
    }
}
