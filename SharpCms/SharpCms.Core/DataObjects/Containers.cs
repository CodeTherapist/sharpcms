using System;
using System.Collections.Generic;

namespace SharpCms.Core.DataObjects
{
    public class Containers
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Element> Elements { get; set; }
    }
}