using System;
using System.Collections.Generic;

namespace SharpCms.Core
{
    public static class IEnumerableExtensions
    {
        public static string Join<T>(this IEnumerable<T> source, string separator)
        {
            return String.Join(separator, source);
        }
    }
}
