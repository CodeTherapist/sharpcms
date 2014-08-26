using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace SharpCms.Mvc
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
}
