using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Web;
using System.Xml.Linq;
using SharpCms.Core.Contracts.Data;
using SharpCms.Core.DataObjects;

namespace SharpCms.Data.FileSystem
{
    public class PageProvider : IPageProvider
    {
        private readonly HttpContextBase _server;
        private readonly string _connectionString;

        public PageProvider(HttpContextBase server, string connectionString)
        {
            _server = server;
            _connectionString = connectionString;
        }

        private HttpServerUtilityBase Server
        {
            get { return _server.Server; }
        }

        public ICollection<Container> GetCurrentPageContainers(PageInfo currentpage)
        {
            var pagefile = String.Format("{0}.xml", currentpage.PageIdentifier);
            var path = Server.MapPath(Path.Combine(_connectionString, pagefile));

            var result = new Collection<Container>();
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var document = XDocument.Load(fileStream);

                var tree = document.Element("page").Elements("containers");

                foreach (var xcontainer in tree.Elements("container"))
                {
                    var container = new Container
                        {
                            Id = Guid.NewGuid(),
                            Name = xcontainer.Attribute("name").Value
                        };

                    AddElements(container, xcontainer);

                    result.Add(container);
                }
            }

            return result;
        }

        private void AddElements(Container container, XElement xcontainer)
        {
            foreach (var xelement in xcontainer.Element("elements").Elements("element"))
            {
                var element = new Element
                    {
                        Id = Guid.NewGuid(),
                        ElementTypeName = xelement.Attribute("type").Value,
                        Published = true
                    };

                AddParameters(element, xelement);

                container.Elements.Add(element);
            }
        }

        private void AddParameters(Element element, XContainer xelement)
        {
            foreach (var xparameter in xelement.Elements())
            {
                var parameter = new Parameter()
                    {
                        Id = Guid.NewGuid(),
                        Name = xparameter.Name.LocalName,
                        Value = xparameter.Value,
                        Type = typeof (string)
                    };
                element.Parameters.Add(parameter);
            }
        }
    }
}