using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using TimeSync;

namespace TxTimeSynchro
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Initialize();
        }

        private const string File_Config = "config.xml";
        private const string AppName = "TXTimeSynchro";
        private const string File_Logs = "synchronization.log";

        private const string Resource = "TxTimeSynchro.config.xml";

        private string fileName_Config;
        private string fileName_Logs;

        private Config config;
        private bool exitingFromPopup = false;
        private bool firstTimeInitialized = false;

        private void Initialize()
        {
            fileName_Config = Path.Combine(Application.StartupPath, File_Config);
            fileName_Logs = Path.Combine(Application.StartupPath, File_Logs);

            string fileContent;
            if (!File.Exists(fileName_Config))
            {
                fileContent = Util.ExtractResourceFile(Resource);
                File.WriteAllText(fileName_Config, fileContent);
            }
            else
            {
                fileContent = File.ReadAllText(fileName_Config);
            }

            config = Config.Load(fileContent);

            chStartPointEnabled.Tag =
                @"Start-point synchronization is usefull when computer randomly change date-time in backward/forward direction 
at random times and count (e.g. if there is an error in hardware clock, etc).
Enable only in such scenario, but do not enable this if your hardware clock working and you just want to synchronize small inaccurateness of date time.";

            PopulateSettings();

//            if (config.StartPointDate > 0)
//            {
//                WindowState = FormWindowState.Minimized;
//                ShowInTaskbar = false;
//                this.Hide();
//            }

            this.Enabled = false;
        }

        private void PopulateSettings()
        {
            if (config.StartPointDate > 0)
            {
                DateTime date = new DateTime(config.StartPointDate);
                lbInitDateTime.Text = String.Format("{0:F}", date);
            }
            else
            {
                lbInitDateTime.Text = "not set";
            }
            lbInitDateTime.Tag = config.StartPointDate;

            chRunSynchro.Checked = config.RunAutoSynchro;
            edSynchroInterval.Value = config.SynchroEvery;
            cmbSynchroMode.SelectedIndex = (int) config.SynchroMode;
            chRetryFailure.Checked = config.SynchroFailureRetry;
            edRetryCount.Value = config.SynchroFailureRetryCount;
            chMakeLog.Checked = config.MakeLog;
            chRunWinStartup.Checked = GetRunAtStartup();
        }

        private bool GetRunAtStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            object value = key.GetValue(AppName);
            return value == null ? false : true;
        }

        private void SetRunAtStartup(bool enabled)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (enabled)
            {
                key.SetValue(AppName, Application.ExecutablePath);
            }
            else
            {
                key.DeleteValue(AppName, false);
            }
        }

        private void PopulateServers()
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {
                lvServers.BeginUpdate();

                lvServers.Items.Clear();

                foreach (var item in config.Servers)
                {
                    ListViewItem viewItem = lvServers.Items.Add(item);

                    viewItem.SubItems.Add(GetIPAdd(item));
                }
            }
            finally
            {
                lvServers.EndUpdate();
                this.Cursor = Cursors.Default;
                this.Enabled = true;
            }
        }

        private string GetIPAdd(string host)
        {
            try
            {
                IPHostEntry hostadd = Dns.Resolve(host);
                if (hostadd.AddressList.Length > 0)
                {
                    return hostadd.AddressList[0].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            
            return string.Empty;
        }

        private void lvServers_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = string.IsNullOrEmpty(e.Label);
            ListViewItem viewItem = lvServers.Items[e.Item];
            if (string.IsNullOrEmpty(viewItem.Text) && e.CancelEdit)
            {
                lvServers.Items.RemoveAt(e.Item);
            }

            if (!e.CancelEdit)
            {
                string ipAdd = GetIPAdd(e.Label);
                if (viewItem.SubItems.Count == 2)
                {
                    viewItem.SubItems[1].Text = ipAdd;
                }
                else
                {
                    viewItem.SubItems.Add(ipAdd);
                }

                //SaveServersFile(true, e.Label);
            }
        }

        private void lvServers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && lvServers.FocusedItem != null)
            {
                lvServers.FocusedItem.BeginEdit();
            }
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            lvServers.SelectedIndices.Clear();

            ListViewItem viewItem = lvServers.Items.Add(string.Empty);
            viewItem.EnsureVisible();
            viewItem.BeginEdit();
        }

        private void btnRemoveServer_Click(object sender, EventArgs e)
        {
            if (lvServers.FocusedItem != null)
            {
                string item = lvServers.FocusedItem.Text;
                lvServers.FocusedItem.Remove();

                config.Servers.Remove(item);
            }
        }

        private void SaveServersFile(bool rebuildConfig)
        {
            SaveServersFile(rebuildConfig, null);
        }

        private void SaveServersFile(bool rebuildConfig, string lastItem)
        {
            if (rebuildConfig)
            {
                config.Servers.Clear();
                foreach (ListViewItem item in lvServers.Items)
                {
                    config.Servers.Add(item.Text);
                }
            }

            config.StartPointDate = (long) lbInitDateTime.Tag;
            config.RunAutoSynchro = chRunSynchro.Checked;
            config.SynchroEvery = (int) edSynchroInterval.Value;
            config.SynchroMode = (SynchroMode) cmbSynchroMode.SelectedIndex;
            config.SynchroFailureRetry = chRetryFailure.Checked;
            config.SynchroFailureRetryCount = (int) edRetryCount.Value;
            config.MakeLog = chMakeLog.Checked;
            SetRunAtStartup(chRunWinStartup.Checked);

            string xml = config.Save();
            File.WriteAllText(fileName_Config, xml);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (config.StartPointDate > 0)
            {
                MinimizeToTray();
            }

            ppTimer.Enabled = true;
        }

        private void ppTimer_Tick(object sender, EventArgs e)
        {
            ppTimer.Enabled = false;

            PopulateServers();

            if (!firstTimeInitialized)
            {
                //UpdateNotifyIcon();
                firstTimeInitialized = true;
                ThreadPool.QueueUserWorkItem(SynchronizationWork);
            }
        }

        private void SynchronizationWork(object state)
        {
            while (!exitingFromPopup)
            {
                Thread.Sleep(1000);
                if (config.RunAutoSynchro)
                {
                    DoSynchronization();
                }
            }
        }

        private bool startPointSynchronized = false;
        private DateTime lastSynchro = DateTime.MinValue;

        private void DoSynchronization()
        {
            if (!startPointSynchronized)
            {
                DateTime startPointTime = new DateTime(config.StartPointDate);
                DateTime updatedTime = NTPClient.SetSystemTime(startPointTime);

                if (!updatedTime.Equals(startPointTime))
                {
                    AddToLog("Error setting start point date time!, cannot continue to automatically synchronize date and time.");
                    return;
                }

                startPointSynchronized = true;
            }

            DateTime now = DateTime.Now;
            DateTime nextSynchro = lastSynchro;

            switch (config.SynchroMode)
            {
                case SynchroMode.Seconds:
                    nextSynchro = nextSynchro.AddSeconds(config.SynchroEvery);
                    break;
                case SynchroMode.Minutes:
                    nextSynchro = nextSynchro.AddMinutes(config.SynchroEvery);
                    break;
                case SynchroMode.Hours:
                    nextSynchro = nextSynchro.AddHours(config.SynchroEvery);
                    break;
                default:
                    nextSynchro = nextSynchro.AddDays(config.SynchroEvery);
                    break;
            }

            if (lastSynchro == DateTime.MinValue || now > nextSynchro)
            {
                SynchroProc();
            }
        }

        private bool synchroRunning = false;
        private bool SynchroProc()
        {
            if (synchroRunning) return false;
            synchroRunning = true;

            bool result = false;

            try
            {
                var client = new NTPClient();

                bool successSynchro = false;
                int retryCount = 0;

                while (!successSynchro && retryCount < config.SynchroFailureRetryCount)
                {
                    for (int i = 0; i < config.Servers.Count; i++)
                    {
                        string server = config.Servers[i];
                        successSynchro = client.Connect(server);
                        if (successSynchro)
                        {
                            AddToLog(
                                string.Format(
                                    "Synchronization with server '{0}' completed successfully, updated to date time: {1}",
                                    server, DateTime.Now));
                            break;
                        }

                        AddToLog(
                            string.Format("Synchronization with server '{0}' failed, will try another server in list",
                                          server));

                        if (exitingFromPopup) break;
                        Thread.Sleep(200);
                    }

                    retryCount++;
                    if (!successSynchro)
                    {
                        if (!config.SynchroFailureRetry)
                        {
                            break;
                        }

                        AddToLog(string.Format("try# {0}/{1} - synchronization with all defined servers failed", retryCount, config.SynchroFailureRetryCount));
                    }
                }

                if (!successSynchro)
                {
                    if (config.SynchroFailureRetry)
                    {
                        AddToLog(
                            "There was no retry of synchronization because of disabled setting 'Retry synchronization failure'.");
                    }
                    
                    AddToLog(
                        "Synchronization with all defined servers failed, please check your internet connection or add another time server(s)");
                }

                result = successSynchro;

                lastSynchro = DateTime.Now;
            }
            finally
            {
                synchroRunning = false;
            }

            return result;
        }

        //public delegate void AddToLogDelegate(string message);
        private string messageToLog = null;

        private void AddToLog(string message)
        {
            messageToLog = message;
            AddToLog();
        }

        private void AddToLog()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(AddToLog));
                return;
            }

            if (config.MakeLog)
            {
                string msg = string.Format("[{0}] {1}{2}", DateTime.Now, messageToLog, Environment.NewLine);

                edLog.AppendText(msg);
                edLog.ScrollToCaret();

                File.AppendAllText(fileName_Logs, msg);
            }
        }

        private void chRunSynchro_CheckedChanged(object sender, EventArgs e)
        {
            edSynchroInterval.Enabled = chRunSynchro.Checked;
            cmbSynchroMode.Enabled = chRunSynchro.Checked;
        }

        private void chRetryFailure_CheckedChanged(object sender, EventArgs e)
        {
            edRetryCount.Enabled = chRetryFailure.Checked;
        }

        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to restore default settings?", "Restore defaults",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            var fileContent = Util.ExtractResourceFile(Resource);
            config = Config.Load(fileContent);

            PopulateSettings();
            this.Enabled = false;
            ppTimer.Enabled = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            long date = (long) lbInitDateTime.Tag;

            if (date == 0)
            {
                MessageBox.Show("You must set start point date time before applying changes!",
                                "Apply changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (tabControl.SelectedIndex != 1)
                {
                    tabControl.SelectedIndex = 1;
                }

                return;
            }

            SaveServersFile(true);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RestoreFromTray();
        }

        private void RestoreFromTray()
        {
            ShowInTaskbar = true;
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitingFromPopup = true;
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitingFromPopup && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                long date = (long) lbInitDateTime.Tag;

                if (date == 0)
                {
                    MessageBox.Show("You must set start point date time before minimizing application to system tray!",
                                    "Minimize to system tray", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (tabControl.SelectedIndex != 1)
                    {
                        tabControl.SelectedIndex = 1;
                    }
                }
                else if (config.StartPointDate == 0)
                {
                    MessageBox.Show("You must apply changes for the first time before minimizing application to system tray!",
                                    "Minimize to system tray", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnApply.Focus();
                }
                else
                {
                    MinimizeToTray(e);
                }
            }
        }

        private string CB(bool value)
        {
            return value ? "yes" : "no";
        }

        private void UpdateNotifyIcon()
        {
            notifyIcon.BalloonTipText =
                string.Format(
                    "Automatically synchronization: {0}\nEvery: {1}\nFailure retrying: {2}\nFailure retry count: {3}\nAppend to log: {4}",
                    CB(config.RunAutoSynchro),
                    config.RunAutoSynchro ? config.SynchroEvery + " " + config.SynchroMode : "-",
                    CB(config.SynchroFailureRetry),
                    config.SynchroFailureRetry ? config.SynchroFailureRetryCount.ToString() : "-",
                    config.MakeLog);

            notifyIcon.ShowBalloonTip(2000);
        }

        private void MinimizeToTray()
        {
            MinimizeToTray(null, false);
        }

        private void MinimizeToTray(FormClosingEventArgs e)
        {
            MinimizeToTray(e, true);
        }

        private void MinimizeToTray(FormClosingEventArgs e, bool showNotifyIcon)
        {
            if (e != null) e.Cancel = true;
            
            this.Hide();
            ShowInTaskbar = false;

            if (showNotifyIcon)
            {
                UpdateNotifyIcon();
            }
        }

        private void mniSettings_Click(object sender, EventArgs e)
        {
            RestoreFromTray();
        }

        private void mniSynchronize_Click(object sender, EventArgs e)
        {
            if (synchroRunning)
            {
                MessageBox.Show("Synchronization already running now...", "Run synchronization",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool result = SynchroProc();

            string msg = string.Format("Date time synchronization {0}{1}",
                result ? "completed successfully" : "failed",
                result ? "" : ". Check log for reason.");

            MessageBox.Show(msg, "Run synchronization", MessageBoxButtons.OK,
                            result ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void ShowTooltip(Label labelControl, Control tooltipControl)
        {
            string tooltipText = tooltipControl.Tag as string;
            toolTipHelp.SetToolTip(labelControl, tooltipText);
        }

        private void helpRunSynchro_Click(object sender, EventArgs e)
        {
            ShowTooltip(helpRunSynchro, chRunSynchro);
        }

        private void helpRetryFailure_Click(object sender, EventArgs e)
        {
            ShowTooltip(helpRetryFailure, chRetryFailure);
        }

        private void helpMakeLog_Click(object sender, EventArgs e)
        {
            ShowTooltip(helpMakeLog, chMakeLog);
        }

        private void helpRunWinStartup_Click(object sender, EventArgs e)
        {
            ShowTooltip(helpRunWinStartup, chRunWinStartup);
        }

        private void btnGetCurrentDate_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lbInitDateTime.Tag = now.Ticks;
            lbInitDateTime.Text = String.Format("{0:F}", now);
        }

        private void helpStartPointEnabled_Click(object sender, EventArgs e)
        {
            ShowTooltip(helpStartPointEnabled, chStartPointEnabled);
        }

        private void chStartPointEnabled_CheckedChanged(object sender, EventArgs e)
        {
            btnGetCurrentDate.Enabled = chStartPointEnabled.Checked;
            chUpdateInitDate.Enabled = chStartPointEnabled.Checked;
            lbInitDate.Enabled = chStartPointEnabled.Checked;
            lbInitDateTime.Enabled = chStartPointEnabled.Checked;
        }
    }
}