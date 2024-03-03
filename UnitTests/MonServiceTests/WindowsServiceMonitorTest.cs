//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using MonService;
//using System;
//using System.ServiceProcess;
//using Logger;

//namespace UnitTests.MonServiceTests
//{
//    [TestClass]
//    public class WindowsServiceMonitorTest
//    {
//        [TestMethod]
//        public void CheckAndStartService_ServiceNotRunning_StartsService()
//        {
//            // Arrange
//            string serviceName = "MockWindowsServ";
//            var mockLogger = new Mock<ILogger>();
//            var serviceControllerMock = new Mock<ServiceController>(serviceName);
//            serviceControllerMock.SetupGet(s => s.Status).Returns(ServiceControllerStatus.Stopped);

//            var windowsServiceMonitor = new WindowsServiceMonitor(serviceName, mockLogger.Object);

//            // Act
//            windowsServiceMonitor.CheckAndStartService();

//            // Assert
//            serviceControllerMock.Verify(s => s.Start(), Times.Once);
//            mockLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(2));
//            mockLogger.Verify(l => l.Log($"Windows Service for {serviceName} is not running. Attempting to start..."), Times.Once);
//            mockLogger.Verify(l => l.Log($"Windows Service for {serviceName} started successfully."), Times.Once);
//        }

//        [TestMethod]
//        public void CheckAndStartService_ServiceAlreadyRunning_DoesNotStartService()
//        {
//            // Arrange
//            string serviceName = "TestService";
//            var mockLogger = new Mock<ILogger>();
//            var serviceControllerMock = new Mock<ServiceController>(serviceName);
//            serviceControllerMock.SetupGet(s => s.Status).Returns(ServiceControllerStatus.Running);

//            var windowsServiceMonitor = new WindowsServiceMonitor(serviceName, mockLogger.Object);

//            // Act
//            windowsServiceMonitor.CheckAndStartService();

//            // Assert
//            serviceControllerMock.Verify(s => s.Start(), Times.Never);
//            mockLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(1));
//            mockLogger.Verify(l => l.Log($"Windows Service for {serviceName} is already running."), Times.Once);
//        }

//        [TestMethod]
//        public void CheckAndStartService_ErrorWhileStarting_LogsError()
//        {
//            // Arrange
//            string serviceName = "TestService";
//            var mockLogger = new Mock<ILogger>();
//            var serviceControllerMock = new Mock<ServiceController>(serviceName);
//            serviceControllerMock.SetupGet(s => s.Status).Returns(ServiceControllerStatus.Stopped);
//            serviceControllerMock.Setup(s => s.Start()).Throws(new Exception("Test exception"));

//            var windowsServiceMonitor = new WindowsServiceMonitor(serviceName, mockLogger.Object);

//            // Act
//            windowsServiceMonitor.CheckAndStartService();

//            // Assert
//            mockLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(1));
//            mockLogger.Verify(l => l.Log($"Error occurred while starting {serviceName}: Test exception"), Times.Once);
//        }
//    }
//}
