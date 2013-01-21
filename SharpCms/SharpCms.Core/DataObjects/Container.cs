using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SharpCms.Core.DataObjects
{
    public class Container
    {
        public Container()
        {
            Elements = new Collection<Element>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Element> Elements { get; set; }
    }
}