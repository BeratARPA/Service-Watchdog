using ServiceCheck.Helpers;
using System;
using System.Windows.Forms;

namespace ServiceCheck.Forms
{
    public partial class SMSSettingsForm : Form
    {
        public SMSSettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
                textBoxPassword.UseSystemPasswordChar = false;
            else
                textBoxPassword.UseSystemPasswordChar = true;
        }

        private void LoadSettings()
        {
            textBoxTitle.Text = Properties.Settings.Default.Title;
            textBoxUsername.Text = Properties.Settings.Default.Username;
            textBoxPassword.Text = Properties.Settings.Default.Password;
            checkBoxNLSS.Checked = Properties.Settings.Default.NLSS;
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text) || string.IsNullOrEmpty(textBoxUsername.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Gerekli alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Properties.Settings.Default.Title = textBoxTitle.Text;
            Properties.Settings.Default.Username = textBoxUsername.Text;
            Properties.Settings.Default.Password = textBoxPassword.Text;
            Properties.Settings.Default.NLSS = checkBoxNLSS.Checked;
            Properties.Settings.Default.Save();

            await LogService.LogAsync($"[Service Watchdog]: SMS ayarları güncellendi.");

            this.Close();
        }
    }
}
