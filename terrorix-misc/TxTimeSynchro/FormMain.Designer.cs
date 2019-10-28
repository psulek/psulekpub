namespace TxTimeSynchro
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lbInitDate = new System.Windows.Forms.Label();
            this.chRunSynchro = new System.Windows.Forms.CheckBox();
            this.chMakeLog = new System.Windows.Forms.CheckBox();
            this.chRetryFailure = new System.Windows.Forms.CheckBox();
            this.chRunWinStartup = new System.Windows.Forms.CheckBox();
            this.ppTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.edRetryCount = new System.Windows.Forms.NumericUpDown();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabServers = new System.Windows.Forms.TabPage();
            this.lvServers = new System.Windows.Forms.ListView();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnIP = new System.Windows.Forms.ColumnHeader();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.helpRunWinStartup = new System.Windows.Forms.Label();
            this.helpMakeLog = new System.Windows.Forms.Label();
            this.helpRetryFailure = new System.Windows.Forms.Label();
            this.helpRunSynchro = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStripAdvSynchro = new System.Windows.Forms.ToolStrip();
            this.btnGetCurrentDate = new System.Windows.Forms.ToolStripButton();
            this.helpStartPointEnabled = new System.Windows.Forms.Label();
            this.chStartPointEnabled = new System.Windows.Forms.CheckBox();
            this.edSynchroInterval = new System.Windows.Forms.NumericUpDown();
            this.cmbSynchroMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.edLog = new System.Windows.Forms.RichTextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnRestoreDefaults = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.iconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniSynchronize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.lbInitDateTime = new System.Windows.Forms.Label();
            this.chUpdateInitDate = new System.Windows.Forms.CheckBox();
            this.helpUpdateInitDate = new System.Windows.Forms.Label();
            this.toolStripServers = new System.Windows.Forms.ToolStrip();
            this.btnRemoveServer = new System.Windows.Forms.ToolStripButton();
            this.btnAddServer = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.edRetryCount)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabServers.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStripAdvSynchro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edSynchroInterval)).BeginInit();
            this.tabLogs.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.iconMenu.SuspendLayout();
            this.toolStripServers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInitDate
            // 
            this.lbInitDate.AutoSize = true;
            this.lbInitDate.Enabled = false;
            this.lbInitDate.Location = new System.Drawing.Point(68, 46);
            this.lbInitDate.Name = "lbInitDate";
            this.lbInitDate.Size = new System.Drawing.Size(80, 13);
            this.lbInitDate.TabIndex = 0;
            this.lbInitDate.Text = "Initial date time:";
            // 
            // chRunSynchro
            // 
            this.chRunSynchro.AutoSize = true;
            this.chRunSynchro.Location = new System.Drawing.Point(51, 17);
            this.chRunSynchro.Name = "chRunSynchro";
            this.chRunSynchro.Size = new System.Drawing.Size(186, 17);
            this.chRunSynchro.TabIndex = 0;
            this.chRunSynchro.Tag = "Automatically runs date-time synchronization every specified interval";
            this.chRunSynchro.Text = "Run synchronization automatically";
            this.chRunSynchro.UseVisualStyleBackColor = true;
            this.chRunSynchro.CheckedChanged += new System.EventHandler(this.chRunSynchro_CheckedChanged);
            // 
            // chMakeLog
            // 
            this.chMakeLog.AutoSize = true;
            this.chMakeLog.Location = new System.Drawing.Point(51, 135);
            this.chMakeLog.Name = "chMakeLog";
            this.chMakeLog.Size = new System.Drawing.Size(146, 17);
            this.chMakeLog.TabIndex = 5;
            this.chMakeLog.Tag = "After synchrozation of date-time if writes record to log file";
            this.chMakeLog.Text = "Make synchronization log";
            this.chMakeLog.UseVisualStyleBackColor = true;
            // 
            // chRetryFailure
            // 
            this.chRetryFailure.AutoSize = true;
            this.chRetryFailure.Location = new System.Drawing.Point(51, 75);
            this.chRetryFailure.Name = "chRetryFailure";
            this.chRetryFailure.Size = new System.Drawing.Size(158, 17);
            this.chRetryFailure.TabIndex = 3;
            this.chRetryFailure.Tag = "If synchronization failed (e.g. for broken internet connectivity, etc) it will re" +
                "try synchronization";
            this.chRetryFailure.Text = "Retry synchronization failure";
            this.chRetryFailure.UseVisualStyleBackColor = true;
            this.chRetryFailure.CheckedChanged += new System.EventHandler(this.chRetryFailure_CheckedChanged);
            // 
            // chRunWinStartup
            // 
            this.chRunWinStartup.AutoSize = true;
            this.chRunWinStartup.Location = new System.Drawing.Point(51, 168);
            this.chRunWinStartup.Name = "chRunWinStartup";
            this.chRunWinStartup.Size = new System.Drawing.Size(201, 17);
            this.chRunWinStartup.TabIndex = 6;
            this.chRunWinStartup.Tag = "After synchrozation of date-time if writes record to log file";
            this.chRunWinStartup.Text = "Run automatically at windows startup";
            this.chRunWinStartup.UseVisualStyleBackColor = true;
            // 
            // ppTimer
            // 
            this.ppTimer.Interval = 500;
            this.ppTimer.Tick += new System.EventHandler(this.ppTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Retry count:";
            // 
            // edRetryCount
            // 
            this.edRetryCount.Enabled = false;
            this.edRetryCount.Location = new System.Drawing.Point(160, 103);
            this.edRetryCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.edRetryCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edRetryCount.Name = "edRetryCount";
            this.edRetryCount.Size = new System.Drawing.Size(68, 20);
            this.edRetryCount.TabIndex = 4;
            this.edRetryCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabServers);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Controls.Add(this.tabLogs);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(426, 329);
            this.tabControl.TabIndex = 0;
            // 
            // tabServers
            // 
            this.tabServers.Controls.Add(this.toolStripServers);
            this.tabServers.Controls.Add(this.lvServers);
            this.tabServers.Location = new System.Drawing.Point(4, 22);
            this.tabServers.Name = "tabServers";
            this.tabServers.Padding = new System.Windows.Forms.Padding(3);
            this.tabServers.Size = new System.Drawing.Size(418, 303);
            this.tabServers.TabIndex = 0;
            this.tabServers.Text = "Time servers";
            this.tabServers.UseVisualStyleBackColor = true;
            // 
            // lvServers
            // 
            this.lvServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnIP});
            this.lvServers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvServers.GridLines = true;
            this.lvServers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvServers.HideSelection = false;
            this.lvServers.LabelEdit = true;
            this.lvServers.Location = new System.Drawing.Point(3, 31);
            this.lvServers.Name = "lvServers";
            this.lvServers.ShowGroups = false;
            this.lvServers.ShowItemToolTips = true;
            this.lvServers.Size = new System.Drawing.Size(412, 269);
            this.lvServers.TabIndex = 0;
            this.lvServers.UseCompatibleStateImageBehavior = false;
            this.lvServers.View = System.Windows.Forms.View.Details;
            this.lvServers.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvServers_AfterLabelEdit);
            this.lvServers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvServers_KeyDown);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 198;
            // 
            // columnIP
            // 
            this.columnIP.Text = "IP";
            this.columnIP.Width = 169;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.helpRunWinStartup);
            this.tabSettings.Controls.Add(this.helpMakeLog);
            this.tabSettings.Controls.Add(this.helpRetryFailure);
            this.tabSettings.Controls.Add(this.helpRunSynchro);
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Controls.Add(this.chRunWinStartup);
            this.tabSettings.Controls.Add(this.chRetryFailure);
            this.tabSettings.Controls.Add(this.chMakeLog);
            this.tabSettings.Controls.Add(this.edSynchroInterval);
            this.tabSettings.Controls.Add(this.cmbSynchroMode);
            this.tabSettings.Controls.Add(this.label3);
            this.tabSettings.Controls.Add(this.chRunSynchro);
            this.tabSettings.Controls.Add(this.edRetryCount);
            this.tabSettings.Controls.Add(this.label2);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(418, 303);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // helpRunWinStartup
            // 
            this.helpRunWinStartup.Image = global::TxTimeSynchro.Properties.Resources.question2;
            this.helpRunWinStartup.Location = new System.Drawing.Point(26, 167);
            this.helpRunWinStartup.Name = "helpRunWinStartup";
            this.helpRunWinStartup.Size = new System.Drawing.Size(16, 16);
            this.helpRunWinStartup.TabIndex = 15;
            this.helpRunWinStartup.Click += new System.EventHandler(this.helpRunWinStartup_Click);
            // 
            // helpMakeLog
            // 
            this.helpMakeLog.Image = global::TxTimeSynchro.Properties.Resources.question2;
            this.helpMakeLog.Location = new System.Drawing.Point(26, 134);
            this.helpMakeLog.Name = "helpMakeLog";
            this.helpMakeLog.Size = new System.Drawing.Size(16, 16);
            this.helpMakeLog.TabIndex = 14;
            this.helpMakeLog.Click += new System.EventHandler(this.helpMakeLog_Click);
            // 
            // helpRetryFailure
            // 
            this.helpRetryFailure.Image = global::TxTimeSynchro.Properties.Resources.question2;
            this.helpRetryFailure.Location = new System.Drawing.Point(26, 74);
            this.helpRetryFailure.Name = "helpRetryFailure";
            this.helpRetryFailure.Size = new System.Drawing.Size(16, 16);
            this.helpRetryFailure.TabIndex = 13;
            this.helpRetryFailure.Click += new System.EventHandler(this.helpRetryFailure_Click);
            // 
            // helpRunSynchro
            // 
            this.helpRunSynchro.Image = global::TxTimeSynchro.Properties.Resources.question2;
            this.helpRunSynchro.Location = new System.Drawing.Point(26, 16);
            this.helpRunSynchro.Name = "helpRunSynchro";
            this.helpRunSynchro.Size = new System.Drawing.Size(16, 16);
            this.helpRunSynchro.TabIndex = 12;
            this.helpRunSynchro.Click += new System.EventHandler(this.helpRunSynchro_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.helpUpdateInitDate);
            this.groupBox1.Controls.Add(this.chUpdateInitDate);
            this.groupBox1.Controls.Add(this.lbInitDateTime);
            this.groupBox1.Controls.Add(this.toolStripAdvSynchro);
            this.groupBox1.Controls.Add(this.helpStartPointEnabled);
            this.groupBox1.Controls.Add(this.chStartPointEnabled);
            this.groupBox1.Controls.Add(this.lbInitDate);
            this.groupBox1.Location = new System.Drawing.Point(19, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced synchronization";
            // 
            // toolStripAdvSynchro
            // 
            this.toolStripAdvSynchro.BackColor = System.Drawing.Color.Transparent;
            this.toolStripAdvSynchro.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripAdvSynchro.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripAdvSynchro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGetCurrentDate});
            this.toolStripAdvSynchro.Location = new System.Drawing.Point(289, 39);
            this.toolStripAdvSynchro.Name = "toolStripAdvSynchro";
            this.toolStripAdvSynchro.Size = new System.Drawing.Size(73, 25);
            this.toolStripAdvSynchro.TabIndex = 17;
            this.toolStripAdvSynchro.Text = "toolStrip1";
            // 
            // btnGetCurrentDate
            // 
            this.btnGetCurrentDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGetCurrentDate.Enabled = false;
            this.btnGetCurrentDate.Image = ((System.Drawing.Image)(resources.GetObject("btnGetCurrentDate.Image")));
            this.btnGetCurrentDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetCurrentDate.Name = "btnGetCurrentDate";
            this.btnGetCurrentDate.Size = new System.Drawing.Size(70, 22);
            this.btnGetCurrentDate.Text = "Get current";
            this.btnGetCurrentDate.Click += new System.EventHandler(this.btnGetCurrentDate_Click);
            // 
            // helpStartPointEnabled
            // 
            this.helpStartPointEnabled.Image = global::TxTimeSynchro.Properties.Resources.question2;
            this.helpStartPointEnabled.Location = new System.Drawing.Point(7, 22);
            this.helpStartPointEnabled.Name = "helpStartPointEnabled";
            this.helpStartPointEnabled.Size = new System.Drawing.Size(16, 16);
            this.helpStartPointEnabled.TabIndex = 16;
            this.helpStartPointEnabled.Click += new System.EventHandler(this.helpStartPointEnabled_Click);
            // 
            // chStartPointEnabled
            // 
            this.chStartPointEnabled.AutoSize = true;
            this.chStartPointEnabled.Location = new System.Drawing.Point(32, 23);
            this.chStartPointEnabled.Name = "chStartPointEnabled";
            this.chStartPointEnabled.Size = new System.Drawing.Size(184, 17);
            this.chStartPointEnabled.TabIndex = 0;
            this.chStartPointEnabled.Tag = "";
            this.chStartPointEnabled.Text = "Enable start-point synchronization";
            this.chStartPointEnabled.UseVisualStyleBackColor = true;
            this.chStartPointEnabled.CheckedChanged += new System.EventHandler(this.chStartPointEnabled_CheckedChanged);
            // 
            // edSynchroInterval
            // 
            this.edSynchroInterval.Enabled = false;
            this.edSynchroInterval.Location = new System.Drawing.Point(160, 44);
            this.edSynchroInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.edSynchroInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edSynchroInterval.Name = "edSynchroInterval";
            this.edSynchroInterval.Size = new System.Drawing.Size(69, 20);
            this.edSynchroInterval.TabIndex = 1;
            this.edSynchroInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbSynchroMode
            // 
            this.cmbSynchroMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSynchroMode.Enabled = false;
            this.cmbSynchroMode.FormattingEnabled = true;
            this.cmbSynchroMode.Items.AddRange(new object[] {
            "second(s)",
            "minute(s)",
            "hour(s)",
            "day(s)"});
            this.cmbSynchroMode.Location = new System.Drawing.Point(235, 43);
            this.cmbSynchroMode.Name = "cmbSynchroMode";
            this.cmbSynchroMode.Size = new System.Drawing.Size(99, 21);
            this.cmbSynchroMode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Every:";
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.edLog);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(431, 382);
            this.tabLogs.TabIndex = 2;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // edLog
            // 
            this.edLog.AutoWordSelection = true;
            this.edLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edLog.DetectUrls = false;
            this.edLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edLog.Location = new System.Drawing.Point(3, 3);
            this.edLog.Name = "edLog";
            this.edLog.ReadOnly = true;
            this.edLog.ShortcutsEnabled = false;
            this.edLog.Size = new System.Drawing.Size(425, 376);
            this.edLog.TabIndex = 0;
            this.edLog.Text = "";
            this.edLog.WordWrap = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnRestoreDefaults);
            this.panelBottom.Controls.Add(this.btnApply);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 329);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(426, 30);
            this.panelBottom.TabIndex = 7;
            // 
            // btnRestoreDefaults
            // 
            this.btnRestoreDefaults.Location = new System.Drawing.Point(3, 4);
            this.btnRestoreDefaults.Name = "btnRestoreDefaults";
            this.btnRestoreDefaults.Size = new System.Drawing.Size(100, 23);
            this.btnRestoreDefaults.TabIndex = 1;
            this.btnRestoreDefaults.Text = "Restore defaults";
            this.btnRestoreDefaults.UseVisualStyleBackColor = true;
            this.btnRestoreDefaults.Click += new System.EventHandler(this.btnRestoreDefaults_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(319, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipTitle = "TX Time Synchro";
            this.notifyIcon.ContextMenuStrip = this.iconMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TX Time Synchro";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // iconMenu
            // 
            this.iconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSynchronize,
            this.toolStripMenuItem1,
            this.mniSettings,
            this.exitToolStripMenuItem});
            this.iconMenu.Name = "iconMenu";
            this.iconMenu.Size = new System.Drawing.Size(170, 76);
            // 
            // mniSynchronize
            // 
            this.mniSynchronize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mniSynchronize.Name = "mniSynchronize";
            this.mniSynchronize.Size = new System.Drawing.Size(169, 22);
            this.mniSynchronize.Text = "Synchronize now";
            this.mniSynchronize.Click += new System.EventHandler(this.mniSynchronize_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 6);
            // 
            // mniSettings
            // 
            this.mniSettings.Name = "mniSettings";
            this.mniSettings.Size = new System.Drawing.Size(169, 22);
            this.mniSettings.Text = "Settings...";
            this.mniSettings.Click += new System.EventHandler(this.mniSettings_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolTipHelp
            // 
            this.toolTipHelp.AutoPopDelay = 10000;
            this.toolTipHelp.InitialDelay = 10;
            this.toolTipHelp.IsBalloon = true;
            this.toolTipHelp.ReshowDelay = 100;
            // 
            // lbInitDateTime
            // 
            this.lbInitDateTime.AutoSize = true;
            this.lbInitDateTime.Enabled = false;
            this.lbInitDateTime.Location = new System.Drawing.Point(154, 46);
            this.lbInitDateTime.Name = "lbInitDateTime";
            this.lbInitDateTime.Size = new System.Drawing.Size(10, 13);
            this.lbInitDateTime.TabIndex = 18;
            this.lbInitDateTime.Text = "-";
            // 
            // chUpdateInitDate
            // 
            this.chUpdateInitDate.AutoSize = true;
            this.chUpdateInitDate.Enabled = false;
            this.chUpdateInitDate.Location = new System.Drawing.Point(32, 69);
            this.chUpdateInitDate.Name = "chUpdateInitDate";
            this.chUpdateInitDate.Size = new System.Drawing.Size(266, 17);
            this.chUpdateInitDate.TabIndex = 19;
            this.chUpdateInitDate.Text = "Update initial date time with synchronized date time";
            this.chUpdateInitDate.UseVisualStyleBackColor = true;
            // 
            // helpUpdateInitDate
            // 
            this.helpUpdateInitDate.Image = global::TxTimeSynchro.Properties.Resources.question2;
            this.helpUpdateInitDate.Location = new System.Drawing.Point(7, 68);
            this.helpUpdateInitDate.Name = "helpUpdateInitDate";
            this.helpUpdateInitDate.Size = new System.Drawing.Size(16, 16);
            this.helpUpdateInitDate.TabIndex = 20;
            // 
            // toolStripServers
            // 
            this.toolStripServers.BackColor = System.Drawing.Color.Transparent;
            this.toolStripServers.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripServers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRemoveServer,
            this.btnAddServer});
            this.toolStripServers.Location = new System.Drawing.Point(3, 3);
            this.toolStripServers.Name = "toolStripServers";
            this.toolStripServers.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripServers.Size = new System.Drawing.Size(412, 25);
            this.toolStripServers.TabIndex = 2;
            // 
            // btnRemoveServer
            // 
            this.btnRemoveServer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRemoveServer.Image = global::TxTimeSynchro.Properties.Resources.remove;
            this.btnRemoveServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveServer.Name = "btnRemoveServer";
            this.btnRemoveServer.Size = new System.Drawing.Size(104, 22);
            this.btnRemoveServer.Text = "Remove server";
            this.btnRemoveServer.Click += new System.EventHandler(this.btnRemoveServer_Click);
            // 
            // btnAddServer
            // 
            this.btnAddServer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAddServer.Image = ((System.Drawing.Image)(resources.GetObject("btnAddServer.Image")));
            this.btnAddServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(83, 22);
            this.btnAddServer.Text = "Add server";
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 359);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TX Time Synchro";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.edRetryCount)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabServers.ResumeLayout(false);
            this.tabServers.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStripAdvSynchro.ResumeLayout(false);
            this.toolStripAdvSynchro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edSynchroInterval)).EndInit();
            this.tabLogs.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.iconMenu.ResumeLayout(false);
            this.toolStripServers.ResumeLayout(false);
            this.toolStripServers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbInitDate;
        private System.Windows.Forms.Timer ppTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown edRetryCount;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabServers;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.ListView lvServers;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnIP;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.CheckBox chRunSynchro;
        private System.Windows.Forms.NumericUpDown edSynchroInterval;
        private System.Windows.Forms.ComboBox cmbSynchroMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chRetryFailure;
        private System.Windows.Forms.CheckBox chMakeLog;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnRestoreDefaults;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip iconMenu;
        private System.Windows.Forms.ToolStripMenuItem mniSynchronize;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mniSettings;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox chRunWinStartup;
        private System.Windows.Forms.RichTextBox edLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chStartPointEnabled;
        private System.Windows.Forms.Label helpRunSynchro;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.Label helpRetryFailure;
        private System.Windows.Forms.Label helpMakeLog;
        private System.Windows.Forms.Label helpRunWinStartup;
        private System.Windows.Forms.Label helpStartPointEnabled;
        private System.Windows.Forms.ToolStrip toolStripAdvSynchro;
        private System.Windows.Forms.ToolStripButton btnGetCurrentDate;
        private System.Windows.Forms.Label lbInitDateTime;
        private System.Windows.Forms.CheckBox chUpdateInitDate;
        private System.Windows.Forms.Label helpUpdateInitDate;
        private System.Windows.Forms.ToolStrip toolStripServers;
        private System.Windows.Forms.ToolStripButton btnRemoveServer;
        private System.Windows.Forms.ToolStripButton btnAddServer;
    }
}

