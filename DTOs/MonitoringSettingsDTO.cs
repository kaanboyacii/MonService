using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DTOs
{
    [Serializable]
    [XmlRoot("MonitoringSettings")]
    public class MonitoringSettingsDTO
    {
        [XmlArray("ServicesToMonitor")]
        [XmlArrayItem("Service")]
        public List<ServiceToMonitorDTO> ServicesToMonitor { get; set; }

        [XmlElement("CheckIntervalSeconds")]
        public int CheckIntervalSeconds { get; set; }

        [XmlElement("LogLevel")]
        public LogLevel LogLevel { get; set; }
    }

    public class ServiceToMonitorDTO
    {
        [XmlElement("ServiceName")]
        public string ServiceName { get; set; }

        [XmlElement("ServiceType")]
        public string ServiceType { get; set; }
    }

    public enum LogLevel
    {
        Default,
        Warning,
        Error,
        Information,
    }
}
