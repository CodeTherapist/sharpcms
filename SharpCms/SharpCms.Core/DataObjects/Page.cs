using System.Collections.Generic;

namespace SharpCms.Core.DataObjects
{
    public class Page
    {
        public PageInfo PageInfo { get; set; }
        public IEnumerable<Container> Containers { get; set; }
    }
}