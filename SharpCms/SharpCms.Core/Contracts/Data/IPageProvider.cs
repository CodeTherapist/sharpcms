using System.Collections.Generic;
using SharpCms.Core.DataObjects;

namespace SharpCms.Core.Contracts.Data
{
    public interface IPageProvider
    {
        ICollection<Container> GetCurrentPageContainers(PageInfo currentpage);
    }
}