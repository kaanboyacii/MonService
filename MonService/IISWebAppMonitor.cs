using Microsoft.Web.Administration;
using System;
using System.Diagnostics;
using Logger;

namespace MonService
{
    public class IISWebAppMonitor : IMonitoringService
    {
        private string siteName;
        private ILogger logger;

        public IISWebAppMonitor(string siteName, ILogger logger)
        {
            this.siteName = siteName;
            this.logger = logger;
        }

        public void CheckAndStartService()
        {
            try
            {
                using (var iisManager = new ServerManager())
                {
                    Site site = iisManager.Sites[siteName];
                    if (site.State != ObjectState.Started)
                    {
                        logger.Log($"IIS Service for {siteName} is not running. Attempting to start...");
                        site.Start();
                        logger.Log($"IIS Service for {siteName} started successfully.");
                    }
                    else
                    {
                        logger.Log($"IIS Service for {siteName} is already running.");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error occurred while starting IIS Service for {siteName}: {ex.Message}");
            }
        }
    }
}
