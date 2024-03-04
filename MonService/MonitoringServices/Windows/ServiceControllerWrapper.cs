using System.ServiceProcess;

namespace MonService
{
    public class ServiceControllerWrapper : IServiceControllerWrapper
    {
        private readonly ServiceController _serviceController;
        public ServiceControllerWrapper(string serviceName)
        {
            _serviceController = new ServiceController(serviceName);
        }
        public ServiceControllerStatus Status
        {
            get
            {
                _serviceController.Refresh(); 
                return _serviceController.Status;
            }
        }
        public void Start()
        {
            _serviceController.Start();
        }
    }
}
