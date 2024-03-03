using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace DTOs
{
    public static class MonitoringSettingsSerializer
    {
        // XML dosyasına kaydetme işlemi
        public static void SaveToXml(MonitoringSettingsDTO settings)
        {
            // Uygulamanın çalışma dizini alınıyor
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // settings.xml dosyasının tam yolu oluşturuluyor
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", "MonService", "bin", "Debug", "settings.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(MonitoringSettingsDTO));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, settings);
            }
        }

        // XML dosyasından yükleme işlemi
        public static MonitoringSettingsDTO LoadFromXml()
        {
            // Uygulamanın çalışma dizini alınıyor
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // settings.xml dosyasının tam yolu oluşturuluyor
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", "MonService", "bin", "Debug", "settings.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(MonitoringSettingsDTO));
            using (StreamReader reader = new StreamReader(filePath))
            {
                var settings = (MonitoringSettingsDTO)serializer.Deserialize(reader);
                if (settings != null)
                {
                    //Console.WriteLine($"Services to monitor:");
                    //foreach (var service in settings.ServicesToMonitor)
                    //{
                    //    Console.WriteLine($"Service Name: {service.ServiceName}, Service Type: {service.ServiceType}");
                    //}
                    //Console.WriteLine($"Check Interval Seconds: {settings.CheckIntervalSeconds}");
                    //Console.WriteLine($"Log Level: {settings.LogLevel}");
                }
                else
                {
                    Console.WriteLine("Settings object is null!");
                }
                return settings;
            }
        }
    }
}
