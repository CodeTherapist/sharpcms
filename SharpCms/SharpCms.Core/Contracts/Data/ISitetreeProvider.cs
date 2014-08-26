using SharpCms.Core.DataObjects;

namespace SharpCms.Core.Contracts.Data
{
    public interface ISitetreeProvider
    {
        PageInfo GetSiteTree();
    }
}