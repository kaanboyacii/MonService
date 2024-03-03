using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using DTOs;


namespace Logger
{
    public class EventViewerLogger : ILogger
    {
        private EventLogEntryType defaultLogLevel;
        private string sourceName;

        public EventViewerLogger(string sourceName, EventLogEntryType? defaultLogLevel = null)
        {
            this.sourceName = sourceName;

            // Eğer defaultLogLevel parametresi belirtilmemişse veya null ise, settings.xml'den log seviyesini yükle
            if (defaultLogLevel == null)
            {
                LoadDefaultLogLevel();
            }
            else
            {
                this.defaultLogLevel = defaultLogLevel.Value;
            }

            CreateEventSourceIfNotExists();
        }

        public void Log(string message, EventLogEntryType logType)
        {
            if (logType <= defaultLogLevel)
            {
                EventLog.WriteEntry(sourceName, message, logType);
            }
        }

        public void Log(string message)
        {
            Log(message, defaultLogLevel);
        }

        public void SetLogLevel(EventLogEntryType logType)
        {
            defaultLogLevel = logType;
        }

        private void LoadDefaultLogLevel()
        {
            try
            {
                MonitoringSettingsDTO settings = MonitoringSettingsSerializer.LoadFromXml();
                defaultLogLevel = GetEventLogEntryType(settings.LogLevel.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while loading log level from settings.xml: " + ex.Message);
                defaultLogLevel = EventLogEntryType.Error;
            }
        }

        private void CreateEventSourceIfNotExists()
        {
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }
        }

        private EventLogEntryType GetEventLogEntryType(string logLevel)
        {
            switch (logLevel.ToLower())
            {
                case "information":
                    return EventLogEntryType.Information;
                case "warning":
                    return EventLogEntryType.Warning;
                case "error":
                    return EventLogEntryType.Error;
                default:
                    return EventLogEntryType.Information;
            }
        }
    }
}
