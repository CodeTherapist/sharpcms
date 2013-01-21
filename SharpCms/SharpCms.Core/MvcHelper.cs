using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using SharpCms.Core.DataObjects;

namespace SharpCms.Core
{
    public static class MvcHelper
    {
        public static SharpcmsHelper Sharpcms(this HtmlHelper htmlhelper)
        {
            return new SharpcmsHelper(htmlhelper);
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
            var model = (PageModel) _htmlhelper.ViewDataContainer.ViewData.Model;
            var container = model.Page.Containers.Where(expression).FirstOrDefault();

            if (container != null)
            {
                return container.Elements;
            }
            return new Collection<Element>();
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
