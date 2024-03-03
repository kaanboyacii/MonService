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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //#if DEBUG
            //While debugging this section is used.
            //MonService myService = new MonService();
            //myService.OnDebug();
            //System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

            //#else
            //In Release this section is used.This is the "normal" way.
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MonService()
            };
            ServiceBase.Run(ServicesToRun);
            //#endif
        }
    }
}
