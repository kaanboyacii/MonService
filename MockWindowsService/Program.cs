using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MockWindowsService
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
            //MockWindowsService myService = new MockWindowsService();
            //myService.OnDebug();
            //System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

            //#else
            //            In Release this section is used.This is the "normal" way.
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MockWindowsService()
            };
            ServiceBase.Run(ServicesToRun);
            //#endif
        }
    }
}
