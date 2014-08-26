using System;
using System.IO;
using System.Web;
using System.Xml.Linq;
using SharpCms.Core;
using SharpCms.Core.Contracts.Data;
using SharpCms.Core.DataObjects;

namespace SharpCms.Data.FileSystem
{
    public class SitetreeProvider : ISitetreeProvider
    {
        private readonly HttpContextBase _server;
        private readonly string _connectionString;

        public SitetreeProvider(HttpContextBase server, string connectionString)
        {
            _server = server;
            _connectionString = connectionString;
        }

        private HttpServerUtilityBase Server
        {
            get { return _server.Server; }
        }

        public PageInfo GetSiteTree()
        {
            var siteTree = new PageInfo
                {
                    Id = Guid.NewGuid(),
                    PageIdentifier = String.Empty,
                    Menuname = string.Empty,
                    InPath = true,
                    PageName = "root",
                };

            var path = Server.MapPath(Path.Combine(_connectionString, "tree.xml"));
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var document = XDocument.Load(fileStream);
                var tree = document.Element("tree");

                AddSubPages(siteTree, tree);

            }

            return siteTree;
        }

        private void AddSubPages(PageInfo parentPage, XContainer parentElemet)
        {
            foreach (var element in parentElemet.Elements())
            {
                var page = new PageInfo
                    {
                        Id = Guid.NewGuid(),
                        PageIdentifier = element.Attribute("pageidentifier", String.Empty).Value,
                        Menuname = element.Attribute("menuname", String.Empty).Value,
                        PageName = element.Attribute("pagename", String.Empty).Value,
                        UrlName = element.Name.LocalName,
                        InPath = false,
                        NavState = (NavState)Enum.Parse(typeof(NavState), element.Attribute("status", "open").Value.ToUpper()),
                        LastEdited = DateTime.Now,
                        Tags = element.Attribute("metakeywords", String.Empty).Value.Split(new[] { ',' }),
                        Description = element.Attribute("metadescription", String.Empty).Value,
                        Template = "Show"
                    };
                parentPage.Children.Add(page);
                AddSubPages(page, element);

            }
        }
    }
}
