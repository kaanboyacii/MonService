using System.ServiceProcess;

namespace MonService
{
    public interface IServiceControllerWrapper
    {
        ServiceControllerStatus Status { get; }
        void Start();
    }
}
