using DTOs;
using System.Collections.Generic;

namespace SettingsApplication.Business
{
    public class SettingsManager
    {
        public MonitoringSettingsDTO LoadSettingsFromXml()
        {
            return MonitoringSettingsSerializer.LoadFromXml();
        }
        public void SaveSettingsToXml(int monitoringFrequency, LogLevel logLevel)
        {
            MonitoringSettingsDTO settings = LoadSettingsFromXml();
            if (monitoringFrequency != 0)
            {
                settings.CheckIntervalSeconds = monitoringFrequency;
            }
            if (logLevel != 0)
            {
                settings.LogLevel = logLevel;
            }
            MonitoringSettingsSerializer.SaveToXml(settings);
        }
        public void SaveServicesToXml(List<ServiceToMonitorDTO> selectedServices)
        {
            MonitoringSettingsDTO settings = LoadSettingsFromXml();
            settings.ServicesToMonitor = selectedServices;
            MonitoringSettingsSerializer.SaveToXml(settings);
        }
    }
}
