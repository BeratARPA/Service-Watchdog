namespace ServiceCheck.UserControls
{
    partial class ServiceUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelServiceStatus = new System.Windows.Forms.Label();
            this.labelServiceName = new System.Windows.Forms.Label();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.comboBoxNumbers = new System.Windows.Forms.ComboBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.checkBoxAutomaticRestart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxStartMessage = new System.Windows.Forms.CheckBox();
            this.checkBoxStopMessage = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.Red;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonStop.ForeColor = System.Drawing.Color.White;
            this.buttonStop.Location = new System.Drawing.Point(14, 129);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(225, 37);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Durdur";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Green;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonStart.ForeColor = System.Drawing.Color.White;
            this.buttonStart.Location = new System.Drawing.Point(14, 84);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(225, 37);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Başlat";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelServiceStatus
            // 
            this.labelServiceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelServiceStatus.Location = new System.Drawing.Point(15, 45);
            this.labelServiceStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelServiceStatus.Name = "labelServiceStatus";
            this.labelServiceStatus.Size = new System.Drawing.Size(223, 35);
            this.labelServiceStatus.TabIndex = 5;
            this.labelServiceStatus.Text = "Service Status";
            this.labelServiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelServiceName
            // 
            this.labelServiceName.Location = new System.Drawing.Point(15, 10);
            this.labelServiceName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelServiceName.Name = "labelServiceName";
            this.labelServiceName.Size = new System.Drawing.Size(223, 35);
            this.labelServiceName.TabIndex = 6;
            this.labelServiceName.Text = "Service Name";
            this.labelServiceName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRestart
            // 
            this.buttonRestart.BackColor = System.Drawing.Color.Orange;
            this.buttonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonRestart.ForeColor = System.Drawing.Color.White;
            this.buttonRestart.Location = new System.Drawing.Point(14, 174);
            this.buttonRestart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(225, 37);
            this.buttonRestart.TabIndex = 3;
            this.buttonRestart.Text = "Yeniden Başlat";
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.HorizontalScrollbar = true;
            this.listBoxLogs.Location = new System.Drawing.Point(13, 218);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.ScrollAlwaysVisible = true;
            this.listBoxLogs.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxLogs.Size = new System.Drawing.Size(227, 145);
            this.listBoxLogs.TabIndex = 7;
            // 
            // comboBoxNumbers
            // 
            this.comboBoxNumbers.DropDownHeight = 100;
            this.comboBoxNumbers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumbers.FormattingEnabled = true;
            this.comboBoxNumbers.IntegralHeight = false;
            this.comboBoxNumbers.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.comboBoxNumbers.Location = new System.Drawing.Point(181, 369);
            this.comboBoxNumbers.MaxDropDownItems = 10;
            this.comboBoxNumbers.Name = "comboBoxNumbers";
            this.comboBoxNumbers.Size = new System.Drawing.Size(59, 24);
            this.comboBoxNumbers.TabIndex = 8;
            this.comboBoxNumbers.SelectedIndexChanged += new System.EventHandler(this.comboBoxNumbers_SelectedIndexChanged);
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.Color.Red;
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonRemove.ForeColor = System.Drawing.Color.White;
            this.buttonRemove.Location = new System.Drawing.Point(13, 487);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(225, 37);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Kaldır";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // checkBoxAutomaticRestart
            // 
            this.checkBoxAutomaticRestart.AutoSize = true;
            this.checkBoxAutomaticRestart.Location = new System.Drawing.Point(14, 400);
            this.checkBoxAutomaticRestart.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxAutomaticRestart.Name = "checkBoxAutomaticRestart";
            this.checkBoxAutomaticRestart.Size = new System.Drawing.Size(201, 21);
            this.checkBoxAutomaticRestart.TabIndex = 9;
            this.checkBoxAutomaticRestart.Text = "Otomatik Yeniden Başlatma";
            this.checkBoxAutomaticRestart.UseVisualStyleBackColor = true;
            this.checkBoxAutomaticRestart.CheckedChanged += new System.EventHandler(this.checkBoxAutomaticRestart_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 376);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Başlatma Önceliği:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxStartMessage
            // 
            this.checkBoxStartMessage.AutoSize = true;
            this.checkBoxStartMessage.Location = new System.Drawing.Point(13, 429);
            this.checkBoxStartMessage.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxStartMessage.Name = "checkBoxStartMessage";
            this.checkBoxStartMessage.Size = new System.Drawing.Size(181, 21);
            this.checkBoxStartMessage.TabIndex = 9;
            this.checkBoxStartMessage.Text = "Başlatma Mesajı Gönder";
            this.checkBoxStartMessage.UseVisualStyleBackColor = true;
            this.checkBoxStartMessage.CheckedChanged += new System.EventHandler(this.checkBoxStartMessage_CheckedChanged);
            // 
            // checkBoxStopMessage
            // 
            this.checkBoxStopMessage.AutoSize = true;
            this.checkBoxStopMessage.Location = new System.Drawing.Point(13, 458);
            this.checkBoxStopMessage.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxStopMessage.Name = "checkBoxStopMessage";
            this.checkBoxStopMessage.Size = new System.Drawing.Size(186, 21);
            this.checkBoxStopMessage.TabIndex = 9;
            this.checkBoxStopMessage.Text = "Durdurma Mesajı Gönder";
            this.checkBoxStopMessage.UseVisualStyleBackColor = true;
            this.checkBoxStopMessage.CheckedChanged += new System.EventHandler(this.checkBoxStopMessage_CheckedChanged);
            // 
            // ServiceUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkBoxStopMessage);
            this.Controls.Add(this.checkBoxStartMessage);
            this.Controls.Add(this.checkBoxAutomaticRestart);
            this.Controls.Add(this.comboBoxNumbers);
            this.Controls.Add(this.listBoxLogs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelServiceName);
            this.Controls.Add(this.labelServiceStatus);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "ServiceUserControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(253, 530);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelServiceStatus;
        private System.Windows.Forms.Label labelServiceName;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.ListBox listBoxLogs;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.CheckBox checkBoxAutomaticRestart;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBoxNumbers;
        private System.Windows.Forms.CheckBox checkBoxStartMessage;
        private System.Windows.Forms.CheckBox checkBoxStopMessage;
    }
}
