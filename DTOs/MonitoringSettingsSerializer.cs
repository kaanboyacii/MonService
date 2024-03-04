using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace DTOs
{
    public static class MonitoringSettingsSerializer
    {
        public static void SaveToXml(MonitoringSettingsDTO settings)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", "MonService", "bin", "Debug", "settings.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(MonitoringSettingsDTO));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, settings);
            }
        }

        public static MonitoringSettingsDTO LoadFromXml()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", "MonService", "bin", "Debug", "settings.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(MonitoringSettingsDTO));
            using (StreamReader reader = new StreamReader(filePath))
            {
                var settings = (MonitoringSettingsDTO)serializer.Deserialize(reader);
         
                return settings;
            }
        }
    }
}
