using System;
using System.ServiceProcess;
using Logger;

namespace MonService
{
    public class WindowsServiceMonitor : IMonitoringService
    {
        private readonly string _serviceName;
        private readonly IServiceControllerWrapper _serviceController;
        private readonly ILogger _logger;

        public WindowsServiceMonitor(string serviceName, IServiceControllerWrapper serviceController, ILogger logger)
        {
            _serviceName = serviceName ?? throw new ArgumentNullException(nameof(serviceName));
            _serviceController = serviceController ?? throw new ArgumentNullException(nameof(serviceController));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
        }

        public void CheckAndStartService()
        {
            try
            {
                if (_serviceController.Status != ServiceControllerStatus.Running)
                {
                    Console.WriteLine(_serviceController.Status);
                    _logger.Log($"Windows Service for {_serviceName} is not running. Attempting to start...");
                    _serviceController.Start();
                    _logger.Log($"Windows Service for {_serviceName} started successfully.");
                }
                else
                {
                    _logger.Log($"Windows Service for {_serviceName} is already running.");
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Error occurred while starting {_serviceName}: {ex.Message}");
            }
        }
    }
}
