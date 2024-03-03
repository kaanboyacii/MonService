//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using SettingsApplication;
//using SettingsApplication.Business;
//using DTOs;
//using System.Collections.Generic;
//using System.Linq;

//namespace UnitTests.SettingApplicationTests
//{
//    [TestClass]
//    public class SettingsFormTests
//    {
//        [TestMethod]
//        public void LoadCurrentSettings_Should_Load_Settings_Correctly()
//        {
//            // Arrange
//            SettingsForm settingsForm = new SettingsForm();
//            SettingsManager settingsManager = settingsForm.settingsManager;

//            MonitoringSettingsDTO dummySettings = new MonitoringSettingsDTO
//            {
//                CheckIntervalSeconds = 15, // Örnek bir monitör frekansı
//                LogLevel = LogLevel.Warning, // Örnek bir log seviyesi
//                ServicesToMonitor = new List<ServiceToMonitorDTO>
//                {
//                    new ServiceToMonitorDTO { ServiceName = "MockWindowsService", ServiceType = "WindowsService" },
//                    new ServiceToMonitorDTO { ServiceName = "MockWebApi", ServiceType = "IISWebApp" }
//                }
//            };

//            // Act
//            settingsForm.LoadCurrentSettings();

//            // Assert
//            Assert.AreEqual(dummySettings.LogLevel, settingsForm.currentLogLevel);
//            Assert.AreEqual(dummySettings.CheckIntervalSeconds, settingsForm.currentFrequency);

//            // Servislerin doğru şekilde yüklenip yüklenmediğini kontrol etmek için ek bir assert eklenebilir.
//            Assert.IsTrue(dummySettings.ServicesToMonitor.SequenceEqual(settingsManager.LoadSettingsFromXml().ServicesToMonitor));
//        }

//        [TestMethod]
//        public void btnChangeFrequency_Click_Should_Save_Frequency_And_Restart_Service()
//        {
//            // Arrange
//            SettingsForm settingsForm = new SettingsForm();
//            SettingsManager settingsManager = settingsForm.settingsManager;
//            int newFrequency = 20; // Yeni bir frekans değeri

//            // Act
//            settingsForm.btnChangeFrequency_Click(null, null);

//            // Assert
//            Assert.AreEqual(newFrequency, settingsForm.currentFrequency);
//            // Servisin yeniden başlatıldığını kontrol etmek için ek bir assert eklenebilir.
//        }

//        [TestMethod]
//        public void btnChangeLogLevel_Click_Should_Save_LogLevel_And_Restart_Service()
//        {
//            // Arrange
//            SettingsForm settingsForm = new SettingsForm();
//            SettingsManager settingsManager = settingsForm.settingsManager;
//            LogLevel newLogLevel = LogLevel.Information; // Yeni bir log seviyesi

//            // Act
//            settingsForm.btnChangeLogLevel_Click(null, null);

//            // Assert
//            Assert.AreEqual(newLogLevel, settingsForm.currentLogLevel);
//            // Servisin yeniden başlatıldığını kontrol etmek için ek bir assert eklenebilir.
//        }

//        [TestMethod]
//        public void btnSaveServices_Click_Should_Save_Services_And_Restart_Service()
//        {
//            // Arrange
//            SettingsForm settingsForm = new SettingsForm();
//            SettingsManager settingsManager = settingsForm.settingsManager;

//            // Yeni bir servis listesi oluştur
//            List<ServiceToMonitorDTO> newServices = new List<ServiceToMonitorDTO>
//            {
//                new ServiceToMonitorDTO { ServiceName = "MockWindowsServer", ServiceType = "WindowsServer" },
//                new ServiceToMonitorDTO { ServiceName = "MockWebApi", ServiceType = "IISWebApp" }
//            };

//            // Act
//            settingsForm.btnSaveServices_Click(null, null);

//            // Assert
//            // Yeni servis listesinin doğru bir şekilde kaydedildiğini kontrol etmek için ek bir assert eklenebilir.
//            Assert.IsTrue(newServices.SequenceEqual(settingsManager.LoadSettingsFromXml().ServicesToMonitor));
//            // Servisin yeniden başlatıldığını kontrol etmek için ek bir assert eklenebilir.
//        }
//    }
//}
