using Microsoft.Web.Administration;

namespace MonService
{
    public interface IServerManagerWrapper
    {
        ISiteCollectionWrapper Sites { get; }
    }
    public interface ISiteCollectionWrapper
    {
        ISiteWrapper this[string siteName] { get; }
    }

    public interface ISiteWrapper
    {
        ObjectState State { get; }
        void Start();
    }
}
