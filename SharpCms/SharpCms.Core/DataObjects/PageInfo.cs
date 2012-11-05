using System;
using System.Collections.Generic;

namespace SharpCms.Core.DataObjects
{
    public class PageInfo
    {
        public Guid Id { get; set; }
        public string Menuname { get; set; }
        public string PageName { get; set; }
        public int Version { get; set; }
        public PageState PageState { get; set; }
        public NavState NavState { get; set; }
        public ViewState ViewState { get; set; }
        public string PageIdentifier { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public string LinkTo { get; set; }
        public bool InPath { get; set; }
        public IEnumerable<PageInfo> Children { get; set; }
        public IEnumerable<GroupInfo> ExtranetGroups { get; set; }
        public IEnumerable<GroupInfo> EditorGroups { get; set; }

        public string TemplateName { get; set; }
    }
}