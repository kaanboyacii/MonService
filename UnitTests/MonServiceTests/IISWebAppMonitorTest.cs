using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MonService;
using Logger;
using Microsoft.Web.Administration;
using System;

namespace UnitTests.MonServiceTests
{
    [TestClass]
    public class IISWebAppMonitorTest
    {
        [TestMethod]
        public void Test_CheckAndStartService_SiteNotStarted_StartsSite()
        {
            // Arrange
            string siteName = "MockWebApi";
            var serverManagerMock = new Mock<IServerManagerWrapper>();
            var siteCollectionMock = new Mock<ISiteCollectionWrapper>();
            var siteMock = new Mock<ISiteWrapper>();

            siteMock.SetupGet(s => s.State).Returns(ObjectState.Stopped);
            siteCollectionMock.Setup(s => s[siteName]).Returns(siteMock.Object);
            serverManagerMock.Setup(s => s.Sites).Returns(siteCollectionMock.Object);

            var loggerMock = new Mock<ILogger>();
            var monitor = new IISWebAppMonitor(siteName, serverManagerMock.Object, loggerMock.Object);

            // Act
            monitor.CheckAndStartService();

            // Assert
            siteMock.Verify(s => s.Start(), Times.Once);
        }

        [TestMethod]
        public void Test_CheckAndStartService_SiteStarted_NoActionTaken()
        {
            // Arrange
            string siteName = "MockWebApi";
            var serverManagerMock = new Mock<IServerManagerWrapper>();
            var siteCollectionMock = new Mock<ISiteCollectionWrapper>();
            var siteMock = new Mock<ISiteWrapper>();

            siteMock.SetupGet(s => s.State).Returns(ObjectState.Started);
            siteCollectionMock.Setup(s => s[siteName]).Returns(siteMock.Object);
            serverManagerMock.Setup(s => s.Sites).Returns(siteCollectionMock.Object);

            var loggerMock = new Mock<ILogger>();
            var monitor = new IISWebAppMonitor(siteName, serverManagerMock.Object, loggerMock.Object);

            // Act
            monitor.CheckAndStartService();

            // Assert
            siteMock.Verify(s => s.Start(), Times.Never);
        }

        [TestMethod]
        public void Test_CheckAndStartService_ExceptionThrown_LogsError()
        {
            // Arrange
            string siteName = "MockWebApi";
            var serverManagerMock = new Mock<IServerManagerWrapper>();
            var siteCollectionMock = new Mock<ISiteCollectionWrapper>();
            var siteMock = new Mock<ISiteWrapper>();

            siteCollectionMock.Setup(s => s[siteName]).Throws<Exception>();
            serverManagerMock.Setup(s => s.Sites).Returns(siteCollectionMock.Object);

            var loggerMock = new Mock<ILogger>();
            var monitor = new IISWebAppMonitor(siteName, serverManagerMock.Object, loggerMock.Object);

            // Act
            monitor.CheckAndStartService();

            // Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
        }
    }
}
