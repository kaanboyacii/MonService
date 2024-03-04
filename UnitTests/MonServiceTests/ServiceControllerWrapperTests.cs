using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MonService;
using System.ServiceProcess;

namespace UnitTests.MonServiceTests
{
    [TestClass]
    public class ServiceControllerWrapperTests
    {
        [TestMethod]
        public void Status_GetStatus_ReturnsServiceStatus()
        {
            // Arrange
            var serviceName = "MockWindowsService";
            var serviceControllerWrapper = new ServiceControllerWrapper(serviceName);

            // Act
            var status = serviceControllerWrapper.Status;

            // Assert
            Assert.IsNotNull(status);
        }
    }
}
