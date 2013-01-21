using System.Web.Mvc;

namespace SharpCms.Code
{
    public static class UrlExtensions
    {
        public static string ActionUrl(this HtmlHelper helper, string action, string controller, object routeValues)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            return urlHelper.Action(action, controller, routeValues); //  RouteUrl
        }

        public static string ActionUrl(this HtmlHelper helper, string action, string controller)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            return urlHelper.Action(action, controller); //  RouteUrl
        }

        public static string ActionUrl(this HtmlHelper helper, string action)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            return urlHelper.Action(action);
        }
    }
}