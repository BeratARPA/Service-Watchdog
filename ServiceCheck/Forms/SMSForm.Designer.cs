namespace ServiceCheck.Forms
{
    partial class SMSForm
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
            this.buttonSMSSettings = new System.Windows.Forms.Button();
            this.textBoxStartMessage = new System.Windows.Forms.TextBox();
            this.textBoxStopMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFullname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.listViewPhoneNumbers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonTemplateSave = new System.Windows.Forms.Button();
            this.buttonPhoneNumberSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonPhoneNumberDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSMSSettings
            // 
            this.buttonSMSSettings.BackColor = System.Drawing.Color.White;
            this.buttonSMSSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSMSSettings.Location = new System.Drawing.Point(13, 13);
            this.buttonSMSSettings.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSMSSettings.Name = "buttonSMSSettings";
            this.buttonSMSSettings.Size = new System.Drawing.Size(102, 37);
            this.buttonSMSSettings.TabIndex = 6;
            this.buttonSMSSettings.Text = "SMS Ayarları";
            this.buttonSMSSettings.UseVisualStyleBackColor = false;
            this.buttonSMSSettings.Click += new System.EventHandler(this.buttonSMSSettings_Click);
            // 
            // textBoxStartMessage
            // 
            this.textBoxStartMessage.Location = new System.Drawing.Point(12, 74);
            this.textBoxStartMessage.Multiline = true;
            this.textBoxStartMessage.Name = "textBoxStartMessage";
            this.textBoxStartMessage.Size = new System.Drawing.Size(300, 100);
            this.textBoxStartMessage.TabIndex = 7;
            // 
            // textBoxStopMessage
            // 
            this.textBoxStopMessage.Location = new System.Drawing.Point(318, 74);
            this.textBoxStopMessage.Multiline = true;
            this.textBoxStopMessage.Name = "textBoxStopMessage";
            this.textBoxStopMessage.Size = new System.Drawing.Size(298, 100);
            this.textBoxStopMessage.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Servis Başlatıldı Mesajı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Servis Durduruldu Mesajı:";
            // 
            // textBoxFullname
            // 
            this.textBoxFullname.Location = new System.Drawing.Point(12, 242);
            this.textBoxFullname.Name = "textBoxFullname";
            this.textBoxFullname.Size = new System.Drawing.Size(300, 23);
            this.textBoxFullname.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ad Soyad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Telefon Numarası:";
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(318, 242);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(298, 23);
            this.textBoxPhoneNumber.TabIndex = 10;
            // 
            // listViewPhoneNumbers
            // 
            this.listViewPhoneNumbers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewPhoneNumbers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewPhoneNumbers.FullRowSelect = true;
            this.listViewPhoneNumbers.GridLines = true;
            this.listViewPhoneNumbers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewPhoneNumbers.HideSelection = false;
            this.listViewPhoneNumbers.Location = new System.Drawing.Point(12, 271);
            this.listViewPhoneNumbers.MultiSelect = false;
            this.listViewPhoneNumbers.Name = "listViewPhoneNumbers";
            this.listViewPhoneNumbers.Size = new System.Drawing.Size(604, 187);
            this.listViewPhoneNumbers.TabIndex = 12;
            this.listViewPhoneNumbers.UseCompatibleStateImageBehavior = false;
            this.listViewPhoneNumbers.View = System.Windows.Forms.View.Details;
            this.listViewPhoneNumbers.SelectedIndexChanged += new System.EventHandler(this.listViewPhoneNumbers_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ad Soyad";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Telefon Numarası";
            this.columnHeader2.Width = 250;
            // 
            // buttonTemplateSave
            // 
            this.buttonTemplateSave.BackColor = System.Drawing.Color.Green;
            this.buttonTemplateSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTemplateSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonTemplateSave.ForeColor = System.Drawing.Color.White;
            this.buttonTemplateSave.Location = new System.Drawing.Point(13, 181);
            this.buttonTemplateSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTemplateSave.Name = "buttonTemplateSave";
            this.buttonTemplateSave.Size = new System.Drawing.Size(602, 37);
            this.buttonTemplateSave.TabIndex = 13;
            this.buttonTemplateSave.Text = "Kaydet";
            this.buttonTemplateSave.UseVisualStyleBackColor = false;
            this.buttonTemplateSave.Click += new System.EventHandler(this.buttonTemplateSave_Click);
            // 
            // buttonPhoneNumberSave
            // 
            this.buttonPhoneNumberSave.BackColor = System.Drawing.Color.Green;
            this.buttonPhoneNumberSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPhoneNumberSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonPhoneNumberSave.ForeColor = System.Drawing.Color.White;
            this.buttonPhoneNumberSave.Location = new System.Drawing.Point(13, 465);
            this.buttonPhoneNumberSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPhoneNumberSave.Name = "buttonPhoneNumberSave";
            this.buttonPhoneNumberSave.Size = new System.Drawing.Size(602, 37);
            this.buttonPhoneNumberSave.TabIndex = 14;
            this.buttonPhoneNumberSave.Text = "Kaydet";
            this.buttonPhoneNumberSave.UseVisualStyleBackColor = false;
            this.buttonPhoneNumberSave.Click += new System.EventHandler(this.buttonPhoneNumberSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(427, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 39);
            this.label5.TabIndex = 8;
            this.label5.Text = "Anahtar Kelimeler:\r\n{fullname} {servicename} \r\n{phonenumber} {computername}";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelStatus.Location = new System.Drawing.Point(122, 13);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(52, 17);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "label1";
            // 
            // buttonPhoneNumberDelete
            // 
            this.buttonPhoneNumberDelete.BackColor = System.Drawing.Color.Red;
            this.buttonPhoneNumberDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonPhoneNumberDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPhoneNumberDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonPhoneNumberDelete.ForeColor = System.Drawing.Color.White;
            this.buttonPhoneNumberDelete.Location = new System.Drawing.Point(13, 510);
            this.buttonPhoneNumberDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPhoneNumberDelete.Name = "buttonPhoneNumberDelete";
            this.buttonPhoneNumberDelete.Size = new System.Drawing.Size(602, 37);
            this.buttonPhoneNumberDelete.TabIndex = 14;
            this.buttonPhoneNumberDelete.Text = "Sil";
            this.buttonPhoneNumberDelete.UseVisualStyleBackColor = false;
            this.buttonPhoneNumberDelete.Click += new System.EventHandler(this.buttonPhoneNumberDelete_Click);
            // 
            // SMSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(628, 551);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonPhoneNumberDelete);
            this.Controls.Add(this.buttonPhoneNumberSave);
            this.Controls.Add(this.buttonTemplateSave);
            this.Controls.Add(this.listViewPhoneNumbers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFullname);
            this.Controls.Add(this.textBoxStopMessage);
            this.Controls.Add(this.textBoxStartMessage);
            this.Controls.Add(this.buttonSMSSettings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SMSForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSMSSettings;
        private System.Windows.Forms.TextBox textBoxStartMessage;
        private System.Windows.Forms.TextBox textBoxStopMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFullname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.ListView listViewPhoneNumbers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonTemplateSave;
        private System.Windows.Forms.Button buttonPhoneNumberSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonPhoneNumberDelete;
    }
}