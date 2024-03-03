using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTOs;
using SettingsApplication.Business;

namespace SettingsApplication
{
    public partial class SettingsForm : Form
    {
        public SettingsManager settingsManager;
        //public LogLevel currentLogLevel;
        //public int currentFrequency;
        public LogLevel currentLogLevel { get; set; }
        public int currentFrequency { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            settingsManager = new SettingsManager();

            cmbboxLogLevel.Items.Add(LogLevel.Information);
            cmbboxLogLevel.Items.Add(LogLevel.Warning);
            cmbboxLogLevel.Items.Add(LogLevel.Error);
            cmbboxLogLevel.SelectedIndex = 0;

            LoadCurrentSettings();
        }

        public void LoadCurrentSettings()
        {
            MonitoringSettingsDTO settings = settingsManager.LoadSettingsFromXml();
            currentLogLevel = settings.LogLevel;
            cmbboxLogLevel.SelectedItem = currentLogLevel;

            currentFrequency = settings.CheckIntervalSeconds;
            numericFrequency.Value = currentFrequency;

            foreach (var service in settings.ServicesToMonitor)
            {
                string itemValue = $"{service.ServiceName} - {service.ServiceType}";
                int index = checkedListBoxServices.FindStringExact(itemValue);
                if (index != -1)
                {
                    checkedListBoxServices.SetItemChecked(index, true);
                }
            }
        }

        public void btnChangeFrequency_Click(object sender, EventArgs e)
        {
            int monitoringFrequency = (int)numericFrequency.Value;
            settingsManager.SaveSettingsToXml(monitoringFrequency, currentLogLevel);
            currentFrequency = monitoringFrequency;
            MessageBox.Show("Frequency have been successfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ServiceRestartHelper.RestartOrStartService("MonService");
        }

        public void btnChangeLogLevel_Click(object sender, EventArgs e)
        {
            LogLevel logLevel = (LogLevel)cmbboxLogLevel.SelectedItem;
            settingsManager.SaveSettingsToXml(currentFrequency, logLevel);
            currentLogLevel = logLevel;
            MessageBox.Show("Log Level have been successfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ServiceRestartHelper.RestartOrStartService("MonService");
        }

        public void btnSaveServices_Click(object sender, EventArgs e)
        {
            List<ServiceToMonitorDTO> selectedServices = new List<ServiceToMonitorDTO>();
            foreach (var item in checkedListBoxServices.CheckedItems)
            {
                string itemValue = item.ToString();
                string[] parts = itemValue.Split('-');

                if (parts.Length == 2)
                {
                    string serviceName = parts[0].Trim();
                    string serviceType = parts[1].Trim();
                    selectedServices.Add(new ServiceToMonitorDTO { ServiceName = serviceName, ServiceType = serviceType });
                }
            }
            settingsManager.SaveServicesToXml(selectedServices);
            MessageBox.Show("Services have been successfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ServiceRestartHelper.RestartOrStartService("MonService");
        }
    }
}
