using Microsoft.Web.Administration;

namespace MonService
{
    public class ServerManagerWrapper : IServerManagerWrapper
    {
        private ServerManager _serverManager;

        public ServerManagerWrapper(ServerManager serverManager)
        {
            _serverManager = serverManager;
        }

        public ISiteCollectionWrapper Sites => new SiteCollectionWrapper(_serverManager.Sites);
    }
}
