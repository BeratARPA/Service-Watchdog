using ServiceCheck.DTOs;
using ServiceCheck.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceCheck.UserControls
{
    public partial class ServiceUserControl : UserControl
    {
        SMSHelper SMSHelper = new SMSHelper();
        Timer serviceCheckTimer = new Timer();
        private NotificationHelper _notificationHelper;

        string previousStatus = "";

        public event EventHandler RemoveClick;
        public event EventHandler SortNumbersSelectedIndexChanged;
        public event EventHandler AutomaticRestartCheckedChanged;
        public event EventHandler StopMessageCheckedChanged;
        public event EventHandler StartMessageCheckedChanged;

        public ServiceUserControl()
        {
            InitializeComponent();

            _notificationHelper = new NotificationHelper(GlobalVariables.MainForm.notifyIcon1);

            serviceCheckTimer.Interval = 1000; // 5 saniyede bir kontrol et
            serviceCheckTimer.Tick += ServiceCheckTimer_Tick;
            serviceCheckTimer.Start();
        }

        private string _serviceName;
        public string ServiceName
        {
            get { return _serviceName; }
            set
            {
                _serviceName = value;
                labelServiceName.Text = _serviceName;
            }
        }

        private string _sortNumber;
        public string SortNumber
        {
            get
            {
                return _sortNumber;
            }
            set
            {
                _sortNumber = value;
                comboBoxNumbers.Text = _sortNumber;
            }
        }

        private bool _automaticRestart;
        public bool AutomaticStart
        {
            get { return _automaticRestart; }
            set
            {
                _automaticRestart = value;
                checkBoxAutomaticRestart.Checked = _automaticRestart;
            }
        }

        private bool _stopMessage;
        public bool StopMessage
        {
            get { return _stopMessage; }
            set
            {
                _stopMessage = value;
                checkBoxStopMessage.Checked = _stopMessage;
            }
        }

        private bool _startMessage;
        public bool StartMessage
        {
            get { return _startMessage; }
            set
            {
                _startMessage = value;
                checkBoxStartMessage.Checked = _startMessage;
            }
        }

        public async void buttonStart_Click(object sender, EventArgs e)
        {
            await ExecuteCommandAsync($"sc start {ServiceName}");
        }

        public async void buttonStop_Click(object sender, EventArgs e)
        {
            await ExecuteCommandAsync($"sc stop {ServiceName}");
        }

        private static async Task<string> ReplacePlaceholders<T>(string template, T data)
        {
            if (string.IsNullOrEmpty(template))
            {
                await LogService.LogAsync($"[Service Watchdog]: Template cannot be null or empty {template}");
                return "";
            }

            if (data == null)
            {
                await LogService.LogAsync($"[Service Watchdog]: Data cannot be null or empty {data}");
                return "";
            }

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                string placeholder = $"{{{property.Name.ToLower()}}}";
                object value = property.GetValue(data);

                template = template.Replace(placeholder, value?.ToString() ?? string.Empty);
            }

            return template;
        }

        private async Task SendSMS(bool startOrStop)
        {
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
                string title = Properties.Settings.Default.Title;
                string username = Properties.Settings.Default.Username;
                string password = Properties.Settings.Default.Password;
                bool nlss = Properties.Settings.Default.NLSS;

                string message = "";
                if (startOrStop)
                    message = Properties.Settings.Default.StartServiceMessage;
                else
                    message = Properties.Settings.Default.StopServiceMessage;

                var data = new
                {
                    fullname = phoneNumber.Fullname,
                    phonenumber = phoneNumber.PhoneNumber,
                    servicename = ServiceName,
                    computername = Environment.MachineName
                };

                message = await ReplacePlaceholders(message, data);

                Random random = new Random();
                message += "\n" + random.Next(0, 999999).ToString();

                await SMSHelper.SendRequest<string, string>(HttpMethod.Get, string.Format("https://sms.telsam.com.tr:9588/direct/?cmd=sendsms&kullanici={0}&sifre={1}&mesaj={2}&gsm={3}&nlss={4}&baslik={5}", username, password, message, phoneNumber.PhoneNumber, nlss, title));
            }
        }

        private async void ServiceCheckTimer_Tick(object sender, EventArgs e)
        {
            string output = await CheckServiceStatus();

            if (output.Contains("RUNNING"))
            {
                if (previousStatus != "RUNNING")
                {
                    await LogService.LogAsync($"[Service Watchdog]: {ServiceName} servisi çalışıyor.");
                    _notificationHelper.ShowBalloonTip("Bilgilendirme", $"{ServiceName} servisi çalışıyor.", ToolTipIcon.Info);

                    if (StartMessage)
                        await SendSMS(true);
                }

                previousStatus = "RUNNING";              
            }
            else if (output.Contains("STOPPED"))
            {

                if (previousStatus != "STOPPED")
                {
                    await LogService.LogAsync($"[Service Watchdog]: {ServiceName} servisi durduruldu.");
                    _notificationHelper.ShowBalloonTip("Bilgilendirme", $"{ServiceName} servisi durduruldu.", ToolTipIcon.Info);

                    if (StopMessage)
                        await SendSMS(false);
                }

                previousStatus = "STOPPED";

                if (_automaticRestart)
                {
                    await ExecuteCommandAsync($"sc start {ServiceName}");
                }                
            }
            else
            {
                await LogService.LogAsync($"[Service Watchdog]: {ServiceName} servisinin durumu bekleniyor.");
            }
        }

        public async Task<string> CheckServiceStatus()
        {
            string output = await ExecuteCommandAsync($"sc query {ServiceName}");
            return output;
        }

        private async Task<string> ExecuteCommandAsync(string command)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/c " + command;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.Verb = "runas"; // Run as administrator

                    process.Start();

                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();

                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(error))
                    {
                        listBoxLogs.Items.Add("Hata: " + error);
                    }
                    else
                    {
                        if (command.Contains("start"))
                        {
                            listBoxLogs.Items.Add("Komut: " + command);
                            listBoxLogs.Items.Add($"Çıktı: {ServiceName} servisi çalışıyor.");

                        }
                        else if (command.Contains("stop"))
                        {
                            listBoxLogs.Items.Add("Komut: " + command);
                            listBoxLogs.Items.Add($"Çıktı: {ServiceName} servisi durduruldu.");
                        }

                        if (output.Contains("RUNNING"))
                        {
                            buttonStart.BackColor = Color.LightGray;
                            buttonStop.BackColor = Color.Red;

                            buttonStart.Enabled = false;
                            buttonStop.Enabled = true;

                            labelServiceStatus.Text = $"{ServiceName} servisi çalışıyor.";
                            labelServiceStatus.ForeColor = Color.Green;                          
                        }
                        else if (output.Contains("STOPPED"))
                        {
                            buttonStart.BackColor = Color.Green;
                            buttonStop.BackColor = Color.LightGray;

                            buttonStart.Enabled = true;
                            buttonStop.Enabled = false;

                            labelServiceStatus.Text = $"{ServiceName} servisi durduruldu.";
                            labelServiceStatus.ForeColor = Color.Red;                    
                        }
                        else
                        {
                            buttonStart.BackColor = Color.Green;
                            buttonStop.BackColor = Color.LightGray;

                            buttonStart.Enabled = true;
                            buttonStop.Enabled = false;

                            labelServiceStatus.Text = $"{ServiceName} servisinin durumu bekleniyor.";
                            labelServiceStatus.ForeColor = Color.Orange;
                        }
                    }

                    return output;
                }
            }
            catch (Exception ex)
            {
                listBoxLogs.Items.Add("An error occurred: " + ex.Message);
                await LogService.LogAsync($"[Service Watchdog]: {ServiceName} An error occurred: {ex}");
                return "";
            }
        }

        private async void buttonRestart_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            string output = await ExecuteCommandAsync($"sc query {ServiceName}");

            await LogService.LogAsync($"[Service Watchdog]: {ServiceName} servisi yeniden başlatılıyor.");
            _notificationHelper.ShowBalloonTip("Bilgilendirme", $"{ServiceName} servisi yeniden başlatılıyor.", ToolTipIcon.Info);

            if (output.Contains("RUNNING"))
            {
                await ExecuteCommandAsync($"sc stop {ServiceName}");
                await ExecuteCommandAsync($"sc start {ServiceName}");
            }
            else if (output.Contains("STOPPED"))
            {
                await ExecuteCommandAsync($"sc start {ServiceName}");
            }

            this.Enabled = true;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveClick?.Invoke(this, e);
        }

        private async void comboBoxNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortNumber = comboBoxNumbers.Text;
            await LogService.LogAsync($"[Service Watchdog]: {ServiceName} servisinin başlangıç önceliği {SortNumber} olarak seçildi.");
            SortNumbersSelectedIndexChanged?.Invoke(this, e);
        }

        private async void checkBoxAutomaticRestart_CheckedChanged(object sender, EventArgs e)
        {
            AutomaticStart = checkBoxAutomaticRestart.Checked;
            await LogService.LogAsync($"[Service Watchdog]: {ServiceName} servisinin otomatik başlatması {AutomaticStart} olarak seçildi.");
            AutomaticRestartCheckedChanged?.Invoke(this, e);
        }

        private async void checkBoxStartMessage_CheckedChanged(object sender, EventArgs e)
        {
            StartMessage = checkBoxStartMessage.Checked;
            await LogService.LogAsync($"[Service Watchdog]: {ServiceName} servisinin başlatma mesajı {StartMessage} olarak seçildi.");
            StartMessageCheckedChanged?.Invoke(this, e);
        }

        private async void checkBoxStopMessage_CheckedChanged(object sender, EventArgs e)
        {
            StopMessage = checkBoxStopMessage.Checked;
            await LogService.LogAsync($"[Service Watchdog]: {ServiceName} servisinin durdurma mesajı {StopMessage} olarak seçildi.");
            StopMessageCheckedChanged?.Invoke(this, e);
        }
    }
}
