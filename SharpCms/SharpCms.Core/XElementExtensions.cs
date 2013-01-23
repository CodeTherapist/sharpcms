using System.Xml.Linq;

namespace SharpCms.Core
{
    public static class XElementExtensions
    {
       public static XAttribute Attribute<T>(this XElement element, string name, T defaultValue)
        {
            var xAttribute = element.Attribute(name);
            if (xAttribute == null)
            {
                return new XAttribute(name, defaultValue);
            }
            return xAttribute;
        }
    }
}
