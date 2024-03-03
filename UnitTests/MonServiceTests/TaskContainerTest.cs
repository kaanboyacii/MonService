using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MonService;
using System.Collections.Generic;
using Logger;

namespace UnitTests.MonServiceTests
{
    [TestClass]
    public class TaskContainerTest
    {
        [TestMethod]
        public void Start_PerformChecks_CalledOnce()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            var taskMock = new Mock<IMonitoringService>();
            var tasks = new List<IMonitoringService> { taskMock.Object };
            var taskContainer = new TaskContainer(tasks, 60, mockLogger.Object);

            // Act
            taskContainer.Start();

            // Assert
            taskMock.Verify(t => t.CheckAndStartService(), Times.Once);
        }

        [TestMethod]
        public void PerformChecks_Calls_CheckAndStartService_ForEachTask()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            var taskMock1 = new Mock<IMonitoringService>();
            var taskMock2 = new Mock<IMonitoringService>();
            var tasks = new List<IMonitoringService> { taskMock1.Object, taskMock2.Object };
            var taskContainer = new TaskContainer(tasks, 60, mockLogger.Object);

            // Act
            taskContainer.PerformChecks();

            // Assert
            taskMock1.Verify(t => t.CheckAndStartService(), Times.Once);
            taskMock2.Verify(t => t.CheckAndStartService(), Times.Once);
        }
    }
}
