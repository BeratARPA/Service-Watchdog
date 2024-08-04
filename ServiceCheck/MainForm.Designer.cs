namespace ServiceCheck
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flowLayoutPanelServices = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxServices = new System.Windows.Forms.ComboBox();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.labelServiceName = new System.Windows.Forms.Label();
            this.linkLabelAddress = new System.Windows.Forms.LinkLabel();
            this.buttonAutomaticRestartInSequence = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonSMS = new System.Windows.Forms.Button();
            this.buttonLogs = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.progressBarCPU = new System.Windows.Forms.ProgressBar();
            this.labelCPU = new System.Windows.Forms.Label();
            this.labelRAM = new System.Windows.Forms.Label();
            this.progressBarRAM = new System.Windows.Forms.ProgressBar();
            this.labelDisk = new System.Windows.Forms.Label();
            this.progressBarDisk = new System.Windows.Forms.ProgressBar();
            this.labelNetwork = new System.Windows.Forms.Label();
            this.progressBarNetwork = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // flowLayoutPanelServices
            // 
            this.flowLayoutPanelServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelServices.AutoScroll = true;
            this.flowLayoutPanelServices.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutPanelServices.Location = new System.Drawing.Point(13, 182);
            this.flowLayoutPanelServices.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelServices.Name = "flowLayoutPanelServices";
            this.flowLayoutPanelServices.Size = new System.Drawing.Size(758, 365);
            this.flowLayoutPanelServices.TabIndex = 0;
            // 
            // comboBoxServices
            // 
            this.comboBoxServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxServices.FormattingEnabled = true;
            this.comboBoxServices.Location = new System.Drawing.Point(14, 30);
            this.comboBoxServices.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxServices.Name = "comboBoxServices";
            this.comboBoxServices.Size = new System.Drawing.Size(251, 24);
            this.comboBoxServices.TabIndex = 1;
            // 
            // buttonAddService
            // 
            this.buttonAddService.BackColor = System.Drawing.Color.White;
            this.buttonAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddService.ForeColor = System.Drawing.Color.Black;
            this.buttonAddService.Location = new System.Drawing.Point(14, 63);
            this.buttonAddService.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(250, 50);
            this.buttonAddService.TabIndex = 5;
            this.buttonAddService.Text = "Servis Ekle";
            this.buttonAddService.UseVisualStyleBackColor = false;
            this.buttonAddService.Click += new System.EventHandler(this.buttonAddService_Click);
            // 
            // labelServiceName
            // 
            this.labelServiceName.AutoSize = true;
            this.labelServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelServiceName.Location = new System.Drawing.Point(16, 9);
            this.labelServiceName.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelServiceName.Name = "labelServiceName";
            this.labelServiceName.Size = new System.Drawing.Size(63, 17);
            this.labelServiceName.TabIndex = 7;
            this.labelServiceName.Text = "Servisler";
            this.labelServiceName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelAddress
            // 
            this.linkLabelAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelAddress.AutoSize = true;
            this.linkLabelAddress.Location = new System.Drawing.Point(148, 9);
            this.linkLabelAddress.Name = "linkLabelAddress";
            this.linkLabelAddress.Size = new System.Drawing.Size(115, 17);
            this.linkLabelAddress.TabIndex = 9;
            this.linkLabelAddress.TabStop = true;
            this.linkLabelAddress.Text = "www.liwasoft.com";
            this.linkLabelAddress.Visible = false;
            this.linkLabelAddress.Click += new System.EventHandler(this.linkLabelAddress_Click);
            // 
            // buttonAutomaticRestartInSequence
            // 
            this.buttonAutomaticRestartInSequence.BackColor = System.Drawing.Color.White;
            this.buttonAutomaticRestartInSequence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutomaticRestartInSequence.Location = new System.Drawing.Point(13, 123);
            this.buttonAutomaticRestartInSequence.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAutomaticRestartInSequence.Name = "buttonAutomaticRestartInSequence";
            this.buttonAutomaticRestartInSequence.Size = new System.Drawing.Size(250, 50);
            this.buttonAutomaticRestartInSequence.TabIndex = 5;
            this.buttonAutomaticRestartInSequence.Text = "Sırayla Otomatik Yeniden Başlat";
            this.buttonAutomaticRestartInSequence.UseVisualStyleBackColor = false;
            this.buttonAutomaticRestartInSequence.Click += new System.EventHandler(this.buttonAutomaticRestartInSequence_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelStatus.Location = new System.Drawing.Point(271, 41);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(89, 17);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "labelStatus";
            // 
            // buttonSMS
            // 
            this.buttonSMS.BackColor = System.Drawing.Color.White;
            this.buttonSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSMS.Location = new System.Drawing.Point(273, 123);
            this.buttonSMS.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSMS.Name = "buttonSMS";
            this.buttonSMS.Size = new System.Drawing.Size(150, 50);
            this.buttonSMS.TabIndex = 5;
            this.buttonSMS.Text = "SMS";
            this.buttonSMS.UseVisualStyleBackColor = false;
            this.buttonSMS.Click += new System.EventHandler(this.buttonSMS_Click);
            // 
            // buttonLogs
            // 
            this.buttonLogs.BackColor = System.Drawing.Color.White;
            this.buttonLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogs.Location = new System.Drawing.Point(274, 63);
            this.buttonLogs.Margin = new System.Windows.Forms.Padding(5);
            this.buttonLogs.Name = "buttonLogs";
            this.buttonLogs.Size = new System.Drawing.Size(100, 50);
            this.buttonLogs.TabIndex = 5;
            this.buttonLogs.Text = "LOGS";
            this.buttonLogs.UseVisualStyleBackColor = false;
            this.buttonLogs.Click += new System.EventHandler(this.buttonLogs_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Service Watchdog";
            this.notifyIcon1.BalloonTipTitle = "Service Watchdog";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Service Watchdog";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // progressBarCPU
            // 
            this.progressBarCPU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarCPU.Location = new System.Drawing.Point(571, 29);
            this.progressBarCPU.Name = "progressBarCPU";
            this.progressBarCPU.Size = new System.Drawing.Size(200, 10);
            this.progressBarCPU.TabIndex = 11;
            // 
            // labelCPU
            // 
            this.labelCPU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCPU.AutoSize = true;
            this.labelCPU.Location = new System.Drawing.Point(568, 9);
            this.labelCPU.Name = "labelCPU";
            this.labelCPU.Size = new System.Drawing.Size(66, 17);
            this.labelCPU.TabIndex = 12;
            this.labelCPU.Text = "labelCPU";
            // 
            // labelRAM
            // 
            this.labelRAM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRAM.AutoSize = true;
            this.labelRAM.Location = new System.Drawing.Point(568, 42);
            this.labelRAM.Name = "labelRAM";
            this.labelRAM.Size = new System.Drawing.Size(68, 17);
            this.labelRAM.TabIndex = 14;
            this.labelRAM.Text = "labelRAM";
            // 
            // progressBarRAM
            // 
            this.progressBarRAM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarRAM.Location = new System.Drawing.Point(571, 62);
            this.progressBarRAM.Name = "progressBarRAM";
            this.progressBarRAM.Size = new System.Drawing.Size(200, 10);
            this.progressBarRAM.TabIndex = 13;
            // 
            // labelDisk
            // 
            this.labelDisk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDisk.AutoSize = true;
            this.labelDisk.Location = new System.Drawing.Point(568, 75);
            this.labelDisk.Name = "labelDisk";
            this.labelDisk.Size = new System.Drawing.Size(65, 17);
            this.labelDisk.TabIndex = 16;
            this.labelDisk.Text = "labelDisk";
            // 
            // progressBarDisk
            // 
            this.progressBarDisk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDisk.Location = new System.Drawing.Point(571, 95);
            this.progressBarDisk.Name = "progressBarDisk";
            this.progressBarDisk.Size = new System.Drawing.Size(200, 10);
            this.progressBarDisk.TabIndex = 15;
            // 
            // labelNetwork
            // 
            this.labelNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNetwork.AutoSize = true;
            this.labelNetwork.Location = new System.Drawing.Point(568, 108);
            this.labelNetwork.Name = "labelNetwork";
            this.labelNetwork.Size = new System.Drawing.Size(89, 17);
            this.labelNetwork.TabIndex = 18;
            this.labelNetwork.Text = "labelNetwork";
            // 
            // progressBarNetwork
            // 
            this.progressBarNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarNetwork.Location = new System.Drawing.Point(571, 128);
            this.progressBarNetwork.Name = "progressBarNetwork";
            this.progressBarNetwork.Size = new System.Drawing.Size(200, 10);
            this.progressBarNetwork.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.labelNetwork);
            this.Controls.Add(this.progressBarNetwork);
            this.Controls.Add(this.labelDisk);
            this.Controls.Add(this.progressBarDisk);
            this.Controls.Add(this.labelRAM);
            this.Controls.Add(this.progressBarRAM);
            this.Controls.Add(this.labelCPU);
            this.Controls.Add(this.progressBarCPU);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.linkLabelAddress);
            this.Controls.Add(this.labelServiceName);
            this.Controls.Add(this.buttonLogs);
            this.Controls.Add(this.buttonSMS);
            this.Controls.Add(this.buttonAutomaticRestartInSequence);
            this.Controls.Add(this.buttonAddService);
            this.Controls.Add(this.comboBoxServices);
            this.Controls.Add(this.flowLayoutPanelServices);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Watchdog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelServices;
        private System.Windows.Forms.ComboBox comboBoxServices;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Label labelServiceName;
        private System.Windows.Forms.LinkLabel linkLabelAddress;
        private System.Windows.Forms.Button buttonAutomaticRestartInSequence;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonSMS;
        private System.Windows.Forms.Button buttonLogs;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ProgressBar progressBarCPU;
        private System.Windows.Forms.Label labelCPU;
        private System.Windows.Forms.Label labelRAM;
        private System.Windows.Forms.ProgressBar progressBarRAM;
        private System.Windows.Forms.Label labelDisk;
        private System.Windows.Forms.ProgressBar progressBarDisk;
        private System.Windows.Forms.Label labelNetwork;
        private System.Windows.Forms.ProgressBar progressBarNetwork;
    }
}