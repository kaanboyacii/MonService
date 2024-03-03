using System;
using System.Collections.Generic;
using System.ServiceProcess;
using Logger;
using DTOs;

namespace MonService
{
    public partial class MonService : ServiceBase
    {
        public MonitoringSettingsDTO Settings { get; set; }
        public TaskContainer TaskContainer { get; private set; }

        private const string EventLogSource = "MonService";
        private ILogger logger;

        public MonService()
        {
            InitializeComponent();
            logger = new EventViewerLogger(EventLogSource);
        }

        protected override void OnStart(string[] args)
        {
            LoadSettings();
            ConfigureService();
            TaskContainer.Start();
        }

        protected override void OnStop()
        {
            TaskContainer.Stop();
        }

        public void LoadSettings()
        {
            try
            {
                Settings = MonitoringSettingsSerializer.LoadFromXml();
                Console.WriteLine("Settings loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading settings: " + ex.Message);
            }
        }

        public void ConfigureService()
        {
            List<IMonitoringService> servicesToCheck = new List<IMonitoringService>();
            foreach (var service in Settings.ServicesToMonitor)
            {
                IMonitoringService monitoringService;
                switch (service.ServiceType.ToLower())
                {
                    case "windowsservice":
                        monitoringService = new WindowsServiceMonitor(service.ServiceName, logger);
                        break;
                    case "iiswebapp":
                        monitoringService = new IISWebAppMonitor(service.ServiceName, logger);
                        break;
                    default:
                        logger.Log($"Unknown service type: {service.ServiceType}");
                        continue;
                }

                servicesToCheck.Add(monitoringService);
            }

            TaskContainer = new TaskContainer(servicesToCheck, Settings.CheckIntervalSeconds, logger);
        }

        public void OnDebug()
        {
            OnStart(null);
        }
    }
}
