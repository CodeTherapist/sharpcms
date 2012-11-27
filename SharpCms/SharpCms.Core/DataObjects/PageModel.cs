using System.Collections.Generic;

namespace SharpCms.Core.DataObjects
{
    public class PageModel
    {
        public string Basepath { get; set; }
        public string Referrer { get; set; }
        public string Domain { get; set; }
        public string Useragent { get; set; }
        public IDictionary<string, string> Query { get; set; }
        public UserInfo CurrentUser { get; set; }
        public IEnumerable<string> History { get; set; }

        public PageInfo SiteTree { get; set; }
        
        public Page Page { get; set; }

    }
}