using DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monservice = MonService.MonService;

namespace UnitTests.MonServiceTests
{
    [TestClass]
    public class MonServiceTest
    {
        [TestMethod]
        public void LoadSettings_Successful()
        {
            // Arrange
            Monservice service = new Monservice();
            // Act
            service.LoadSettings();
            // Assert
            Assert.IsNotNull(service.Settings);
        }
        [TestMethod]
        public void ConfigureService_ValidServiceType()
        {
            // Arrange
            Monservice service = new Monservice();
            // Act
            service.LoadSettings();
            service.ConfigureService();
            // Assert
            Assert.IsNotNull(service.TaskContainer);
            Assert.IsNotNull(service.Settings);
            Assert.IsTrue(service.Settings.ServicesToMonitor.Count > 0);
        }

    }
}
