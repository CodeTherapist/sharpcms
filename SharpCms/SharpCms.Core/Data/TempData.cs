using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Web;
using System.Xml.Linq;
using SharpCms.Core.DataObjects;

namespace SharpCms.Core.Data
{
    public class PageData
    {
        internal static HttpServerUtility Server
        {
            get { return HttpContext.Current.Server; }
        }

        internal static PageInfo GetSiteTree()
        {
            var document = XDocument.Load(new FileStream(Server.MapPath("/App_Data/database/tree.xml"), FileMode.Open, FileAccess.Read));

            var tree = document.Element("tree");
            var siteTree = new PageInfo
                {
                    Id = Guid.NewGuid(),
                    PageIdentifier = String.Empty,
                    Menuname = string.Empty,
                    InPath = true,
                    PageName = "root",
                };

            AddSubPages(siteTree, tree);

            return siteTree;
        }

        private static void AddSubPages(PageInfo parentPage, XContainer parentElemet)
        {
            foreach (var element in parentElemet.Elements())
            {
                var page = new PageInfo
                    {
                        Id = Guid.NewGuid(),
                        PageIdentifier = element.Attribute("pageidentifier").Value,
                        Menuname = element.Attribute("menuname").Value,
                        PageName = element.Attribute("pagename").Value,
                        UrlName = element.Name.LocalName,
                        InPath = false,
                        NavState = (NavState)Enum.Parse(typeof(NavState), element.Attribute("status").Value.ToUpper()),
                        LastEdited = DateTime.Now,
                        Tags = element.Attribute("metakeywords").Value.Split(new[] { ',' }),
                        Description = element.Attribute("metadescription").Value,
                        Template = "Show"
                    };
                parentPage.Children.Add(page);
                AddSubPages(page, element);

            }
        }


        internal static ICollection<Container> GetCurrentPageContainers(PageInfo currentpage)
        {
            var pagepath = Server.MapPath(String.Format("/App_Data/database/site/{0}.xml", currentpage.PageIdentifier));
            var document = XDocument.Load(new FileStream(pagepath, FileMode.Open, FileAccess.Read));

            var tree = document.Element("page").Elements("containers");

            var result = new Collection<Container>();

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

            return result;
        }

        private static void AddElements(Container container, XElement xcontainer)
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

        private static void AddParameters(Element element, XContainer xelement)
        {
            foreach (var xparameter in xelement.Elements())
            {
                var parameter = new Parameter()
                    {
                        Id = Guid.NewGuid(),
                        Name = xparameter.Name.LocalName,
                        Value = xparameter.Value,
                        Type = typeof(string)
                    };
                element.Parameters.Add(parameter);
            }
        }
    }
}
