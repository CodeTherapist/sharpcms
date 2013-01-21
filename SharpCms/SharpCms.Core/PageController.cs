using System.Collections.Generic;
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

            var siteTree = PageData.GetSiteTree();

            var model = CreatePageModel(siteTree, path);

            return View(model.Page.PageInfo.Template, model);
        }

        private PageModel CreatePageModel(PageInfo siteTree, IList<string> path)
        {
            var homepage = GetCurrentPageInfo(siteTree, path, 0);

            var containers = PageData.GetCurrentPageContainers(homepage);

            var page = new PageModel
                {
                    Page = new Page
                        {
                            PageInfo = homepage,
                            Containers = containers
                        },
                    SiteTree = siteTree
                };

            return page;
        }

        private PageInfo GetCurrentPageInfo(PageInfo siteTree, IList<string> path, int level)
        {
            if (siteTree.Children != null)
            {
                foreach (var pageInfo in siteTree.Children)
                {
                    if (path[level] != null)
                    {
                        if (pageInfo.UrlName == path[level])
                        {
                            return GetCurrentPageInfo(pageInfo, path, level + 1);
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
