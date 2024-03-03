using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace SettingsApplication.Business
{
    public class ServiceRestartHelper
    {
        public static void RestartOrStartService(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);
            try
            {
                if (serviceController.Status == ServiceControllerStatus.Running)
                {
                    serviceController.Stop();
                    serviceController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                }
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10)); 

                MessageBox.Show($"Service '{serviceName}' has been successfully restarted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while restarting service '{serviceName}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
