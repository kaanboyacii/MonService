namespace SettingsApplication
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.btnChangeFrequency = new System.Windows.Forms.Button();
            this.btnChangeLogLevel = new System.Windows.Forms.Button();
            this.cmbboxLogLevel = new System.Windows.Forms.ComboBox();
            this.lblLogLevel = new System.Windows.Forms.Label();
            this.checkedListBoxServices = new System.Windows.Forms.CheckedListBox();
            this.lblSelectServices = new System.Windows.Forms.Label();
            this.btnSaveServices = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // numericFrequency
            // 
            this.numericFrequency.Location = new System.Drawing.Point(611, 32);
            this.numericFrequency.Name = "numericFrequency";
            this.numericFrequency.Size = new System.Drawing.Size(120, 26);
            this.numericFrequency.TabIndex = 0;
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(427, 34);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(166, 20);
            this.lblFrequency.TabIndex = 1;
            this.lblFrequency.Text = "Monitoring Frequency:";
            // 
            // btnChangeFrequency
            // 
            this.btnChangeFrequency.Location = new System.Drawing.Point(431, 64);
            this.btnChangeFrequency.Name = "btnChangeFrequency";
            this.btnChangeFrequency.Size = new System.Drawing.Size(300, 42);
            this.btnChangeFrequency.TabIndex = 2;
            this.btnChangeFrequency.Text = "Change Frequency";
            this.btnChangeFrequency.UseVisualStyleBackColor = true;
            this.btnChangeFrequency.Click += new System.EventHandler(this.btnChangeFrequency_Click);
            // 
            // btnChangeLogLevel
            // 
            this.btnChangeLogLevel.Location = new System.Drawing.Point(431, 228);
            this.btnChangeLogLevel.Name = "btnChangeLogLevel";
            this.btnChangeLogLevel.Size = new System.Drawing.Size(300, 42);
            this.btnChangeLogLevel.TabIndex = 3;
            this.btnChangeLogLevel.Text = "Change Log Level";
            this.btnChangeLogLevel.UseVisualStyleBackColor = true;
            this.btnChangeLogLevel.Click += new System.EventHandler(this.btnChangeLogLevel_Click);
            // 
            // cmbboxLogLevel
            // 
            this.cmbboxLogLevel.FormattingEnabled = true;
            this.cmbboxLogLevel.Location = new System.Drawing.Point(526, 194);
            this.cmbboxLogLevel.Name = "cmbboxLogLevel";
            this.cmbboxLogLevel.Size = new System.Drawing.Size(205, 28);
            this.cmbboxLogLevel.TabIndex = 4;
            // 
            // lblLogLevel
            // 
            this.lblLogLevel.AutoSize = true;
            this.lblLogLevel.Location = new System.Drawing.Point(427, 197);
            this.lblLogLevel.Name = "lblLogLevel";
            this.lblLogLevel.Size = new System.Drawing.Size(81, 20);
            this.lblLogLevel.TabIndex = 5;
            this.lblLogLevel.Text = "Log Level:";
            // 
            // checkedListBoxServices
            // 
            this.checkedListBoxServices.FormattingEnabled = true;
            this.checkedListBoxServices.Items.AddRange(new object[] {
            "MockWindowsService - WindowsService",
            "MockWebApi - IISWebApp"});
            this.checkedListBoxServices.Location = new System.Drawing.Point(41, 76);
            this.checkedListBoxServices.Name = "checkedListBoxServices";
            this.checkedListBoxServices.Size = new System.Drawing.Size(347, 142);
            this.checkedListBoxServices.TabIndex = 10;
            // 
            // lblSelectServices
            // 
            this.lblSelectServices.AutoSize = true;
            this.lblSelectServices.Location = new System.Drawing.Point(37, 34);
            this.lblSelectServices.Name = "lblSelectServices";
            this.lblSelectServices.Size = new System.Drawing.Size(122, 20);
            this.lblSelectServices.TabIndex = 11;
            this.lblSelectServices.Text = "Select Services:";
            // 
            // btnSaveServices
            // 
            this.btnSaveServices.Location = new System.Drawing.Point(41, 228);
            this.btnSaveServices.Name = "btnSaveServices";
            this.btnSaveServices.Size = new System.Drawing.Size(347, 42);
            this.btnSaveServices.TabIndex = 12;
            this.btnSaveServices.Text = "Save Services";
            this.btnSaveServices.UseVisualStyleBackColor = true;
            this.btnSaveServices.Click += new System.EventHandler(this.btnSaveServices_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 312);
            this.Controls.Add(this.btnSaveServices);
            this.Controls.Add(this.lblSelectServices);
            this.Controls.Add(this.checkedListBoxServices);
            this.Controls.Add(this.lblLogLevel);
            this.Controls.Add(this.cmbboxLogLevel);
            this.Controls.Add(this.btnChangeLogLevel);
            this.Controls.Add(this.btnChangeFrequency);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.numericFrequency);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonService Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericFrequency;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Button btnChangeFrequency;
        private System.Windows.Forms.Button btnChangeLogLevel;
        private System.Windows.Forms.ComboBox cmbboxLogLevel;
        private System.Windows.Forms.Label lblLogLevel;
        private System.Windows.Forms.CheckedListBox checkedListBoxServices;
        private System.Windows.Forms.Label lblSelectServices;
        private System.Windows.Forms.Button btnSaveServices;
    }
}

