using Microsoft.Web.Administration;
using System;
using Logger;

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

    public class ServerManagerWrapper : IServerManagerWrapper
    {
        private ServerManager _serverManager;

        public ServerManagerWrapper(ServerManager serverManager)
        {
            _serverManager = serverManager;
        }

        public ISiteCollectionWrapper Sites => new SiteCollectionWrapper(_serverManager.Sites);
    }

    public class SiteCollectionWrapper : ISiteCollectionWrapper
    {
        private SiteCollection _siteCollection;

        public SiteCollectionWrapper(SiteCollection siteCollection)
        {
            _siteCollection = siteCollection;
        }

        public ISiteWrapper this[string siteName] => new SiteWrapper(_siteCollection[siteName]);
    }

    public class SiteWrapper : ISiteWrapper
    {
        private Site _site;

        public SiteWrapper(Site site)
        {
            _site = site;
        }

        public ObjectState State => _site.State;

        public void Start()
        {
            _site.Start();
        }
    }

    public class IISWebAppMonitor : IMonitoringService
    {
        private string _siteName;
        private IServerManagerWrapper _serverManager;
        private ILogger _logger;

        public IISWebAppMonitor(string siteName, IServerManagerWrapper serverManager, ILogger logger)
        {
            _siteName = siteName ?? throw new ArgumentNullException(nameof(siteName));
            _serverManager = serverManager ?? throw new ArgumentNullException(nameof(serverManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void CheckAndStartService()
        {
            try
            {
                ISiteWrapper site = _serverManager.Sites[_siteName];
                if (site.State != ObjectState.Started)
                {
                    _logger.Log($"IIS Service for {_siteName} is not running. Attempting to start...");
                    site.Start();
                    _logger.Log($"IIS Service for {_siteName} started successfully.");
                }
                else
                {
                    _logger.Log($"IIS Service for {_siteName} is already running.");
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Error occurred while starting IIS Service for {_siteName}: {ex.Message}");
            }
        }
    }
}
