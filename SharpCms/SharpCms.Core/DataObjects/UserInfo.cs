using System;
using System.Collections.Generic;

namespace SharpCms.Core.DataObjects
{
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public IEnumerable<GroupInfo> Groups { get; set; }
    }
}