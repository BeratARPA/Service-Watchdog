using ServiceCheck.DTOs;
using ServiceCheck.Forms;
using ServiceCheck.Helpers;
using ServiceCheck.UserControls;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceCheck
{
    public partial class MainForm : Form
    {
        ConcurrentDictionary<string, (int, int, bool, bool, bool)> ServicesInFlowLayoutPanel = new ConcurrentDictionary<string, (int, int, bool, bool, bool)>();
        private NotificationHelper _notificationHelper;

        public MainForm()
        {
            InitializeComponent();

            GlobalVariables.MainForm = this;

            _notificationHelper = new NotificationHelper(notifyIcon1);
            _notificationHelper.SetDoubleClickEvent(new MouseEventHandler(notifyIcon1_MouseDoubleClick));

            Load();
            LoadServicesIntoComboBox();

            labelStatus.Text = "";
        }

        private void LoadServicesIntoComboBox()
        {
            try
            {
                // Servisleri al
                ServiceController[] services = ServiceController.GetServices();

                // ComboBox'ı temizle
                comboBoxServices.Items.Clear();

                // Her servisi ComboBox'a ekle
                foreach (ServiceController service in services)
                {
                    comboBoxServices.Items.Add(service.ServiceName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private async void buttonAddService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxServices.Text))
                return;

            if (ServicesInFlowLayoutPanel.TryGetValue(comboBoxServices.Text, out _))
            {
                MessageBox.Show("Servis zaten mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var serviceUserControl = CreateServiceControl(comboBoxServices.Text, 0, false, false, false);

            flowLayoutPanelServices.Controls.Add(serviceUserControl);
            int index = flowLayoutPanelServices.Controls.GetChildIndex(serviceUserControl);
            ServicesInFlowLayoutPanel[serviceUserControl.ServiceName] = (index, Convert.ToInt32(serviceUserControl.SortNumber), serviceUserControl.AutomaticStart, serviceUserControl.StartMessage, serviceUserControl.StartMessage);

            Save();

            await LogService.LogAsync($"[Service Watchdog]: {comboBoxServices.Text} servisi eklendi.");
        }

        private ServiceUserControl CreateServiceControl(string serviceName, int sortNumber, bool automaticStart, bool startMessage, bool stopMessage)
        {
            var serviceUserControl = new ServiceUserControl
            {
                ServiceName = serviceName,
                SortNumber = sortNumber.ToString(),
                AutomaticStart = automaticStart,
                StartMessage = startMessage,
                StopMessage = stopMessage
            };

            serviceUserControl.RemoveClick += ServiceUserControl_RemoveClick;
            serviceUserControl.StopMessageCheckedChanged += ServiceUserControl_StopMessageCheckedChanged;
            serviceUserControl.StartMessageCheckedChanged += ServiceUserControl_StartMessageCheckedChanged;
            serviceUserControl.AutomaticRestartCheckedChanged += ServiceUserControl_AutomaticRestartCheckedChanged;
            serviceUserControl.SortNumbersSelectedIndexChanged += ServiceUserControl_SortNumbersSelectedIndexChanged;

            return serviceUserControl;
        }

        private void ServiceUserControl_StopMessageCheckedChanged(object sender, EventArgs e)
        {
            var serviceUserControl = sender as ServiceUserControl;
            if (serviceUserControl == null)
                return;

            bool newStopMessage;
            if (!bool.TryParse(serviceUserControl.StopMessage.ToString(), out newStopMessage))
                return;

            if (ServicesInFlowLayoutPanel.ContainsKey(serviceUserControl.ServiceName))
            {
                var serviceData = ServicesInFlowLayoutPanel[serviceUserControl.ServiceName];
                ServicesInFlowLayoutPanel[serviceUserControl.ServiceName] = (serviceData.Item1, serviceData.Item2, serviceData.Item3, serviceData.Item4, newStopMessage);
            }

            Save();
        }

        private void ServiceUserControl_StartMessageCheckedChanged(object sender, EventArgs e)
        {
            var serviceUserControl = sender as ServiceUserControl;
            if (serviceUserControl == null)
                return;

            bool newStartMessage;
            if (!bool.TryParse(serviceUserControl.StartMessage.ToString(), out newStartMessage))
                return;

            if (ServicesInFlowLayoutPanel.ContainsKey(serviceUserControl.ServiceName))
            {
                var serviceData = ServicesInFlowLayoutPanel[serviceUserControl.ServiceName];
                ServicesInFlowLayoutPanel[serviceUserControl.ServiceName] = (serviceData.Item1, serviceData.Item2, serviceData.Item3, newStartMessage, serviceData.Item5);
            }

            Save();
        }

        private void Save()
        {
            var services = new List<ServiceDTO>();
            foreach (var kvp in ServicesInFlowLayoutPanel)
            {
                var serviceDTO = new ServiceDTO
                {
                    Name = kvp.Key,
                    Index = kvp.Value.Item1,
                    SortNumber = kvp.Value.Item2,
                    AutomaticRestart = kvp.Value.Item3,
                    StartMessage = kvp.Value.Item4,
                    StopMessage = kvp.Value.Item5,
                };

                services.Add(serviceDTO);
            }

            string ServiceWatchdogFolderPath = Path.Combine("C:\\ProgramData", "ServiceWatchdog");
            string ServicesDirectory = Path.Combine(ServiceWatchdogFolderPath, "ServicesSettings.json");

            if (!Directory.Exists(ServiceWatchdogFolderPath))
            {
                Directory.CreateDirectory(ServiceWatchdogFolderPath);
            }

            string servicesSettings = JsonHelper.Serialize(services);
            FileOperations<string> fileOperations = new FileOperations<string>(ServicesDirectory);
            fileOperations.DeleteFile();
            fileOperations.CreateFile();
            fileOperations.WriteToFile(servicesSettings);
        }

        private void Load()
        {
            string ServiceWatchdogFolderPath = Path.Combine("C:\\ProgramData", "ServiceWatchdog");
            string ServicesDirectory = Path.Combine(ServiceWatchdogFolderPath, "ServicesSettings.json");

            if (!Directory.Exists(ServiceWatchdogFolderPath))
            {
                Directory.CreateDirectory(ServiceWatchdogFolderPath);
            }

            FileOperations<string> fileOperations = new FileOperations<string>(ServicesDirectory);
            var services = JsonHelper.Deserialize<List<ServiceDTO>>(fileOperations.ReadFile());
            if (services == null)
                return;

            foreach (var service in services.OrderBy(s => s.Index).ToList())
            {
                var serviceUserControl = CreateServiceControl(service.Name, service.SortNumber, service.AutomaticRestart, service.StartMessage, service.StopMessage);

                flowLayoutPanelServices.Controls.Add(serviceUserControl);
                int index = flowLayoutPanelServices.Controls.GetChildIndex(serviceUserControl);
                ServicesInFlowLayoutPanel[serviceUserControl.ServiceName] = (index, Convert.ToInt32(serviceUserControl.SortNumber), serviceUserControl.AutomaticStart, serviceUserControl.StartMessage, serviceUserControl.StopMessage);
            }
        }

        private void ServiceUserControl_AutomaticRestartCheckedChanged(object sender, EventArgs e)
        {
            var serviceUserControl = sender as ServiceUserControl;
            if (serviceUserControl == null)
                return;

            bool newAutomaticStart;
            if (!bool.TryParse(serviceUserControl.AutomaticStart.ToString(), out newAutomaticStart))
                return;

            if (ServicesInFlowLayoutPanel.ContainsKey(serviceUserControl.ServiceName))
            {
                var serviceData = ServicesInFlowLayoutPanel[serviceUserControl.ServiceName];
                ServicesInFlowLayoutPanel[serviceUserControl.ServiceName] = (serviceData.Item1, serviceData.Item2, newAutomaticStart, serviceData.Item4, serviceData.Item5);
            }

            Save();
        }

        private void ServiceUserControl_SortNumbersSelectedIndexChanged(object sender, EventArgs e)
        {
            var serviceUserControl = sender as ServiceUserControl;
            if (serviceUserControl == null)
                return;

            int newSortNumber;
            if (!int.TryParse(serviceUserControl.SortNumber, out newSortNumber))
                return;

            // Aynı sıralama numarasına sahip diğer servisleri kontrol et
            var duplicateSortNumbers = flowLayoutPanelServices.Controls
                .OfType<ServiceUserControl>()
                .Where(s => s != serviceUserControl && int.TryParse(s.SortNumber, out int existingSortNumber) && existingSortNumber == newSortNumber)
                .ToList();

            if (duplicateSortNumbers.Any())
            {
                // Aynı sıralama numarasına sahip başka servisler bulundu, kullanıcıyı bilgilendir
                serviceUserControl.comboBoxNumbers.Text = "0";
                MessageBox.Show("Bu sıralama numarası zaten mevcut. Lütfen başka bir numara seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ServicesInFlowLayoutPanel.ContainsKey(serviceUserControl.ServiceName))
            {
                var serviceData = ServicesInFlowLayoutPanel[serviceUserControl.ServiceName];
                ServicesInFlowLayoutPanel[serviceUserControl.ServiceName] = (serviceData.Item1, newSortNumber, serviceData.Item3, serviceData.Item4, serviceData.Item5);
            }

            Save();
        }

        private async void ServiceUserControl_RemoveClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Servisi kaldırmak istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            var serviceUserControl = (ServiceUserControl)sender;

            int index = flowLayoutPanelServices.Controls.GetChildIndex(serviceUserControl);

            if (index >= 0)
            {
                flowLayoutPanelServices.Controls.RemoveAt(index);
            }

            ServicesInFlowLayoutPanel.TryRemove(serviceUserControl.ServiceName, out _);

            Save();

            await LogService.LogAsync($"[Service Watchdog]: {serviceUserControl.ServiceName} servisi kaldırıldı.");
        }

        private void linkLabelAddress_Click(object sender, EventArgs e)
        {
            Process.Start("www.liwasoft.com");
        }

        private async void buttonAutomaticRestartInSequence_Click(object sender, EventArgs e)
        {
            await LogService.LogAsync($"[Service Watchdog]: Servisler sırayla yeniden başlatılıyor.");

            labelStatus.Text = "Bekleniyor...";
            labelStatus.ForeColor = Color.Orange;
            flowLayoutPanelServices.Enabled = false;

            var sortedServicesDescending = ServicesInFlowLayoutPanel
                .Where(s => s.Value.Item2 != 0)
                .OrderByDescending(s => s.Value.Item2)
                .Select(s => s.Key)
                .ToList();

            var sortedServicesAscending = ServicesInFlowLayoutPanel
                .Where(s => s.Value.Item2 != 0)
                .OrderBy(s => s.Value.Item2)
                .Select(s => s.Key)
                .ToList();

            var serviceControls = flowLayoutPanelServices.Controls
            .OfType<ServiceUserControl>()
            .ToDictionary(s => s.ServiceName, s => s);

            // AutomaticStart özelliğini geçici olarak devre dışı bırak (sadece true olanları)
            var servicesWithAutomaticStart = new List<ServiceUserControl>();
            foreach (var serviceControl in serviceControls.Values)
            {
                if (serviceControl.AutomaticStart)
                {
                    serviceControl.AutomaticStart = false;
                    servicesWithAutomaticStart.Add(serviceControl);
                }
            }

            // Servisleri sırayla durdur
            foreach (var serviceName in sortedServicesDescending)
            {
                var serviceControl = flowLayoutPanelServices.Controls
                    .OfType<ServiceUserControl>()
                    .FirstOrDefault(s => s.ServiceName == serviceName);

                if (serviceControl != null)
                {
                    serviceControl.buttonStop_Click(this, new EventArgs());

                    // Servisin durduğundan emin olmak için kontrol et
                    while (true)
                    {
                        string output = await serviceControl.CheckServiceStatus();
                        if (output.Contains("STOPPED"))
                        {
                            break;
                        }
                        await Task.Delay(1000); // 1 saniye bekle
                    }
                }
            }

            // Servisleri sırayla başlat
            foreach (var serviceName in sortedServicesAscending)
            {
                var serviceControl = flowLayoutPanelServices.Controls
                    .OfType<ServiceUserControl>()
                    .FirstOrDefault(s => s.ServiceName == serviceName);

                if (serviceControl != null)
                {
                    serviceControl.buttonStart_Click(this, new EventArgs());

                    // Servisin başladığından emin olmak için kontrol et
                    while (true)
                    {
                        string output = await serviceControl.CheckServiceStatus();
                        if (output.Contains("RUNNING"))
                        {
                            break;
                        }
                        await Task.Delay(1000); // 1 saniye bekle
                    }
                }
            }

            // AutomaticStart özelliğini eski haline getir (sadece geçici olarak false yapılanları)
            foreach (var serviceControl in servicesWithAutomaticStart)
            {
                serviceControl.AutomaticStart = true;
            }

            labelStatus.Text = "";
            labelStatus.ForeColor = Color.Black;
            flowLayoutPanelServices.Enabled = true;
        }

        private void buttonSMS_Click(object sender, EventArgs e)
        {
            SMSForm smsForm = new SMSForm();
            smsForm.ShowDialog();
        }

        private void buttonLogs_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\ProgramData\\ServiceWatchdog\\Logs");
            }
            catch { }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            _notificationHelper.Hide();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                _notificationHelper.Show();
                _notificationHelper.ShowBalloonTip("Bilgilendirme", $"Uygulama sistem tepsisine gönderildi.", ToolTipIcon.Info);
            }
        }
    }
}
