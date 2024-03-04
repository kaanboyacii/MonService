using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MonService
{
    internal static class Program
    {
        static void Main()
        {
            //MonService myService = new MonService();
            //myService.OnDebug();
            //System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MonService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
