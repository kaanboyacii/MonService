using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MonService;
using Logger;
using System.ServiceProcess;

namespace UnitTests.MonServiceTests
{
    [TestClass]
    public class WindowsServiceMonitorTest
    {
        [TestMethod]
        public void CheckAndStartService_ServiceNotRunning_ServiceStarted()
        {
            // Arrange
            string serviceName = "MockWindowsService";
            var loggerMock = new Mock<ILogger>();
            var serviceControllerMock = new Mock<IServiceControllerWrapper>();
            serviceControllerMock.SetupGet(sc => sc.Status).Returns(ServiceControllerStatus.Stopped);
            serviceControllerMock.Setup(sc => sc.Start());

            var monitor = new WindowsServiceMonitor(serviceName, serviceControllerMock.Object, loggerMock.Object);

            // Act
            monitor.CheckAndStartService();

            // Assert
            loggerMock.Verify(l => l.Log($"Windows Service for {serviceName} is not running. Attempting to start..."), Times.Once);
            loggerMock.Verify(l => l.Log($"Windows Service for {serviceName} started successfully."), Times.Once);
            serviceControllerMock.Verify(sc => sc.Start(), Times.Once);
        }
    }
}
