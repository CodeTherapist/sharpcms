using System;
using System.Linq;
using SharpCms.Core.DataObjects;

namespace SharpCms.Core
{
    public static class ElementExtensions
    {
        public static Parameter Parameters(this Element element, Func<Parameter, bool> expression)
        {
            return element.Parameters.Where(expression).FirstOrDefault();
        }
    }
}