using System;
using System.Diagnostics;
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
            this.defaultLogLevel = defaultLogLevel ?? LoadDefaultLogLevel();
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

        private EventLogEntryType LoadDefaultLogLevel()
        {
            try
            {
                MonitoringSettingsDTO settings = MonitoringSettingsSerializer.LoadFromXml();
                return GetEventLogEntryType(settings.LogLevel.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while loading log level from settings.xml: " + ex.Message);
                return EventLogEntryType.Error;
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
            return Enum.TryParse(logLevel, true, out EventLogEntryType result) ? result : EventLogEntryType.Information;
        }
    }
}
