using Microsoft.Web.Administration;
using System;
using Logger;

namespace MonService
{
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
