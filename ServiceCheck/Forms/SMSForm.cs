using ServiceCheck.DTOs;
using ServiceCheck.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ServiceCheck.Forms
{
    public partial class SMSForm : Form
    {
        public SMSForm()
        {
            InitializeComponent();
            LoadSettings();

            labelStatus.Text = "";
        }

        private void buttonSMSSettings_Click(object sender, EventArgs e)
        {
            SMSSettingsForm smsSettingsForm = new SMSSettingsForm();
            smsSettingsForm.ShowDialog();
        }

        private void LoadSettings()
        {
            textBoxStartMessage.Text = Properties.Settings.Default.StartServiceMessage;
            textBoxStopMessage.Text = Properties.Settings.Default.StopServiceMessage;

            string ServiceWatchdogFolderPath = Path.Combine("C:\\ProgramData", "ServiceWatchdog");
            string PhoneNumbersDirectory = Path.Combine(ServiceWatchdogFolderPath, "PhoneNumbers.json");

            if (!Directory.Exists(ServiceWatchdogFolderPath))
            {
                Directory.CreateDirectory(ServiceWatchdogFolderPath);
            }

            FileOperations<string> fileOperations = new FileOperations<string>(PhoneNumbersDirectory);
            var phoneNumbers = JsonHelper.Deserialize<List<PhoneNumberDTO>>(fileOperations.ReadFile());
            if (phoneNumbers == null)
                return;

            foreach (var phoneNumber in phoneNumbers)
            {
                string[] row = { phoneNumber.Fullname, phoneNumber.PhoneNumber };
                var listViewItem = new ListViewItem(row);
                listViewPhoneNumbers.Items.Add(listViewItem);
            }
        }

        private async void buttonTemplateSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxStartMessage.Text) || string.IsNullOrEmpty(textBoxStopMessage.Text))
            {
                MessageBox.Show("Gerekli alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Properties.Settings.Default.StartServiceMessage = textBoxStartMessage.Text;
            Properties.Settings.Default.StopServiceMessage = textBoxStopMessage.Text;
            Properties.Settings.Default.Save();

            labelStatus.Text = "Kayıt Güncellendi.";
            labelStatus.ForeColor = Color.Orange;

            await LogService.LogAsync($"[Service Watchdog]: Başlatma ve durdurma mesajları güncellendi.");
        }

        private void Save()
        {
            var phoneNumbers = new List<PhoneNumberDTO>();
            foreach (ListViewItem item in listViewPhoneNumbers.Items)
            {
                var phoneNumberDTO = new PhoneNumberDTO
                {
                    Fullname = item.SubItems[0].Text,
                    PhoneNumber = item.SubItems[1].Text
                };

                phoneNumbers.Add(phoneNumberDTO);
            }

            string ServiceWatchdogFolderPath = Path.Combine("C:\\ProgramData", "ServiceWatchdog");
            string PhoneNumbersDirectory = Path.Combine(ServiceWatchdogFolderPath, "PhoneNumbers.json");

            if (!Directory.Exists(ServiceWatchdogFolderPath))
            {
                Directory.CreateDirectory(ServiceWatchdogFolderPath);
            }

            string phoneNumbersData = JsonHelper.Serialize(phoneNumbers);
            FileOperations<string> fileOperations = new FileOperations<string>(PhoneNumbersDirectory);
            fileOperations.DeleteFile();
            fileOperations.CreateFile();
            fileOperations.WriteToFile(phoneNumbersData);
        }

        private async void buttonPhoneNumberSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFullname.Text) || string.IsNullOrEmpty(textBoxPhoneNumber.Text))
            {
                MessageBox.Show("Gerekli alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Güncelleme işlemi
            if (listViewPhoneNumbers.SelectedItems.Count > 0)
            {
                var selectedItem = listViewPhoneNumbers.SelectedItems[0];

                // Aynı telefon numarası ile başka bir kayıt olup olmadığını kontrol et
                foreach (ListViewItem item in listViewPhoneNumbers.Items)
                {
                    if (item != selectedItem && item.SubItems[1].Text == textBoxPhoneNumber.Text)
                    {
                        MessageBox.Show("Telefon numarası zaten mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                selectedItem.SubItems[0].Text = textBoxFullname.Text;
                selectedItem.SubItems[1].Text = textBoxPhoneNumber.Text;

                Save();

                labelStatus.Text = "Kayıt Güncellendi.";
                labelStatus.ForeColor = Color.Orange;

                await LogService.LogAsync($"[Service Watchdog]: Kişi güncellendi.");
            }
            else // Ekleme işlemi
            {
                foreach (ListViewItem item in listViewPhoneNumbers.Items)
                {
                    if (item.SubItems[1].Text == textBoxPhoneNumber.Text)
                    {
                        MessageBox.Show("Telefon numarası zaten mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string[] row = { textBoxFullname.Text, textBoxPhoneNumber.Text };
                var listViewItem = new ListViewItem(row);
                listViewPhoneNumbers.Items.Add(listViewItem);

                Save();

                labelStatus.Text = "Kayıt Eklendi.";
                labelStatus.ForeColor = Color.Green;

                await LogService.LogAsync($"[Service Watchdog]: Kişi eklendi.");
            }

            Clear();
        }

        private async void buttonPhoneNumberDelete_Click(object sender, EventArgs e)
        {
            if (listViewPhoneNumbers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = listViewPhoneNumbers.SelectedItems[0];
            listViewPhoneNumbers.Items.Remove(selectedItem);

            Save();

            labelStatus.Text = "Kayıt Silindi.";
            labelStatus.ForeColor = Color.Red;

            await LogService.LogAsync($"[Service Watchdog]: Kişi silindi.");
        }

        private void listViewPhoneNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPhoneNumbers.SelectedItems.Count > 0)
            {
                var selectedItem = listViewPhoneNumbers.SelectedItems[0];
                textBoxFullname.Text = selectedItem.SubItems[0].Text;
                textBoxPhoneNumber.Text = selectedItem.SubItems[1].Text;
            }
        }

        private void Clear()
        {
            textBoxFullname.Clear();
            textBoxPhoneNumber.Clear();
        }
    }
}
