using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
using SharpCms.Core.DataObjects;

namespace SharpCms.Core
{
    public static class HtmlHelperExtensions
    {
        public static SharpcmsHelper Sharpcms(this HtmlHelper htmlhelper)
        {
            return new SharpcmsHelper(htmlhelper);
        }

        public static HelperResult RenderSection(this WebPageBase webPage, string name, Func<dynamic, HelperResult> defaultContents)
        {
            if (webPage.IsSectionDefined(name))
            {
                return webPage.RenderSection(name);
            }
            return defaultContents(null);
        }
    }

    public class SharpcmsHelper
    {
        private readonly HtmlHelper _htmlhelper;

        public SharpcmsHelper(HtmlHelper htmlhelper)
        {
            _htmlhelper = htmlhelper;
        }

        public ICollection<Element> GetElementsForContainer(Func<Container, bool> expression)
        {
            var model = (PageModel)_htmlhelper.ViewContext.Controller.ViewData.Model;
            var container = model.Page.Containers.Where(expression).FirstOrDefault();

            if (container != null)
            {
                return container.Elements;
            }
            return new Collection<Element>();
        }

        public PageInfo GetCurrentPage()
        {
            var model = (PageModel)_htmlhelper.ViewContext.Controller.ViewData.Model;
            return model.Page.PageInfo;
        }
        
        public ICollection<PageInfo> GetSubPages()
        {
            var model = (PageModel)_htmlhelper.ViewContext.Controller.ViewData.Model;
            return model.Page.PageInfo.Children;
        }

    }

    public static class ElementExtensions
    {
        public static Parameter Parameters(this Element element, Func<Parameter, bool> expression)
        {
            return element.Parameters.Where(expression).FirstOrDefault();
        }
    }
}
