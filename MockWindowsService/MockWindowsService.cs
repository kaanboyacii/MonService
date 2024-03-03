using Logger;
using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace MockWindowsService
{
    public partial class MockWindowsService : ServiceBase
    {
        private FileSystemWatcher watcher;
        private const string EventLogSource = "MockServiceSource";
        private ILogger logger;

        public MockWindowsService()
        {
            InitializeComponent();
            logger = new EventViewerLogger(EventLogSource);
        }

        protected override void OnStart(string[] args)
        {
            watcher = new FileSystemWatcher("C:\\Target")
            {
                EnableRaisingEvents = true,
                IncludeSubdirectories = true
            };

            watcher.Created += DirectoryChanged;
            watcher.Deleted += DirectoryChanged;
            watcher.Changed += DirectoryChanged;
            watcher.Renamed += DirectoryChanged;

            logger.Log("Mock Windows Service is Started.");
        }
        private void DirectoryChanged(object sender, FileSystemEventArgs e)
        {
            var message = $"{e.ChangeType} - {e.FullPath} {Environment.NewLine}";
            logger.Log(message);
        }

        protected override void OnStop()
        {
            watcher.Dispose();
            logger.Log("Mock Windows Service is Stopped.");
        }

        public void OnDebug()
        {
            OnStart(null);
        }
    }
}
