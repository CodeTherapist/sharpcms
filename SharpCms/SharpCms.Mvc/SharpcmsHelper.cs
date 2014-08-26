using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using SharpCms.Core.DataObjects;

namespace SharpCms.Mvc
{
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
}