using System;
using System.Diagnostics;
using System.ServiceProcess;
using Logger;

namespace MonService
{
    public class WindowsServiceMonitor : IMonitoringService
    {
        private string serviceName;
        private ILogger logger;

        public WindowsServiceMonitor(string serviceName, ILogger logger)
        {
            this.serviceName = serviceName;
            this.logger = logger;
        }

        public void CheckAndStartService()
        {
            using (ServiceController serviceController = new ServiceController(serviceName))
            {
                try
                {
                    if (serviceController.Status != ServiceControllerStatus.Running)
                    {
                        logger.Log($"Windows Service for {serviceName} is not running. Attempting to start...");
                        serviceController.Start();
                        logger.Log($"Windows Service for {serviceName} started successfully.");
                    }
                    else
                    {
                        logger.Log($"Windows Service for {serviceName} is already running.");
                    }
                }
                catch (Exception ex)
                {
                    logger.Log($"Error occurred while starting {serviceName}: {ex.Message}");
                }
            }
        }
    }
}
