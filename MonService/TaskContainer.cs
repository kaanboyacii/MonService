using Logger;
using System.Collections.Generic;
using System.Timers;
using System;

namespace MonService
{
    public class TaskContainer
    {
        private List<IMonitoringService> tasks;
        public List<IMonitoringService> ServicesToCheck { get; private set; }
        private Timer timer;
        private ILogger logger;
        private bool firstRun = true; 

        public TaskContainer(List<IMonitoringService> tasks, int intervalSeconds, ILogger logger)
        {
            this.tasks = tasks;
            this.logger = logger;
            timer = new Timer(intervalSeconds * 1000);
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = true;
        }

        public void Start()
        {
            if (firstRun)
            {
                PerformChecks();
                firstRun = false;
            }

            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            PerformChecks();
        }

        public void PerformChecks()
        {
            foreach (var task in tasks)
            {
                task.CheckAndStartService();
                Console.WriteLine("Service Checked");
            }
        }
    }
}
