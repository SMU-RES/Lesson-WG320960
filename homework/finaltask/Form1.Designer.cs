namespace task
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonPanel = new System.Windows.Forms.Panel();
            this.rbnTabs = new System.Windows.Forms.TabControl();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.pagesHost = new System.Windows.Forms.Panel();
            this.pageDashboard = new System.Windows.Forms.Panel();
            this.pageSettings = new System.Windows.Forms.Panel();
            this.pageDatabase = new System.Windows.Forms.Panel();
            this.splitDash = new System.Windows.Forms.SplitContainer();
            this.splitDashRight = new System.Windows.Forms.SplitContainer();
            this.groupStatus = new System.Windows.Forms.GroupBox();
            this.tableKpi = new System.Windows.Forms.TableLayoutPanel();
            this.lblTempCaption = new System.Windows.Forms.Label();
            this.lblVoltCaption = new System.Windows.Forms.Label();
            this.lblRpmCaption = new System.Windows.Forms.Label();
            this.lblTempValue = new System.Windows.Forms.Label();
            this.lblVoltValue = new System.Windows.Forms.Label();
            this.lblRpmValue = new System.Windows.Forms.Label();
            this.panelAlarm = new System.Windows.Forms.Panel();
            this.lblAlarmText = new System.Windows.Forms.Label();
            this.groupCommands = new System.Windows.Forms.GroupBox();
            this.btnLedToggle = new System.Windows.Forms.Button();
            this.btnMotorStop = new System.Windows.Forms.Button();
            this.btnMotorStart = new System.Windows.Forms.Button();
            this.groupLogs = new System.Windows.Forms.GroupBox();
            this.listLogs = new System.Windows.Forms.ListView();
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupTrend = new System.Windows.Forms.GroupBox();
            this.trendsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.chartTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVolt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRpm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupConnConfig = new System.Windows.Forms.GroupBox();
            this.btnRefreshPorts = new System.Windows.Forms.Button();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.lblParity = new System.Windows.Forms.Label();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.lblBaud = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.groupSystemConfig = new System.Windows.Forms.GroupBox();
            this.lblAlarmWarn = new System.Windows.Forms.Label();
            this.numWarnTemp = new System.Windows.Forms.NumericUpDown();
            this.lblAlarmAlarm = new System.Windows.Forms.Label();
            this.numAlarmTemp = new System.Windows.Forms.NumericUpDown();
            this.lblRetention = new System.Windows.Forms.Label();
            this.numMaxRows = new System.Windows.Forms.NumericUpDown();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.groupDbSamples = new System.Windows.Forms.GroupBox();
            this.gridSamples = new System.Windows.Forms.DataGridView();
            this.panelDbActions = new System.Windows.Forms.Panel();
            this.btnDbLoadSamples = new System.Windows.Forms.Button();
            this.btnDbDeleteSample = new System.Windows.Forms.Button();
            this.btnDbExportCsv = new System.Windows.Forms.Button();
            this.timerUi = new System.Windows.Forms.Timer(this.components);
            this.timerBlink = new System.Windows.Forms.Timer(this.components);
            this.ribbonPanel.SuspendLayout();
            this.rbnTabs.SuspendLayout();
            this.pagesHost.SuspendLayout();
            this.pageDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDash)).BeginInit();
            this.splitDash.Panel1.SuspendLayout();
            this.splitDash.Panel2.SuspendLayout();
            this.splitDash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDashRight)).BeginInit();
            this.splitDashRight.Panel1.SuspendLayout();
            this.splitDashRight.SuspendLayout();
            this.groupStatus.SuspendLayout();
            this.tableKpi.SuspendLayout();
            this.panelAlarm.SuspendLayout();
            this.groupCommands.SuspendLayout();
            this.groupLogs.SuspendLayout();
            this.groupTrend.SuspendLayout();
            this.trendsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRpm)).BeginInit();
            this.pageSettings.SuspendLayout();
            this.groupConnConfig.SuspendLayout();
            this.groupSystemConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWarnTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRows)).BeginInit();
            this.pageDatabase.SuspendLayout();
            this.groupDbSamples.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSamples)).BeginInit();
            this.panelDbActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonPanel
            // 
            this.ribbonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.ribbonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ribbonPanel.Controls.Add(this.rbnTabs);
            this.ribbonPanel.Controls.Add(this.lblTitle);
            this.ribbonPanel.Controls.Add(this.btnStartStop);
            this.ribbonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonPanel.Location = new System.Drawing.Point(0, 0);
            this.ribbonPanel.Name = "ribbonPanel";
            this.ribbonPanel.Padding = new System.Windows.Forms.Padding(12, 8, 12, 6);
            this.ribbonPanel.Size = new System.Drawing.Size(1184, 82);
            this.ribbonPanel.TabIndex = 0;
            // 
            // rbnTabs
            // 
            this.rbnTabs.Alignment = System.Windows.Forms.TabAlignment.Top;
            this.rbnTabs.Controls.Add(this.tabDashboard);
            this.rbnTabs.Controls.Add(this.tabSettings);
            this.rbnTabs.Controls.Add(this.tabDatabase);
            this.rbnTabs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.rbnTabs.ItemSize = new System.Drawing.Size(90, 26);
            this.rbnTabs.Location = new System.Drawing.Point(12, 48);
            this.rbnTabs.Name = "rbnTabs";
            this.rbnTabs.SelectedIndex = 0;
            this.rbnTabs.Size = new System.Drawing.Size(420, 32);
            this.rbnTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.rbnTabs.TabIndex = 2;
            this.rbnTabs.SelectedIndexChanged += new System.EventHandler(this.rbnTabs_SelectedIndexChanged);
            // 
            // tabDashboard
            // 
            this.tabDashboard.Location = new System.Drawing.Point(4, 30);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(412, 0);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "看板";
            this.tabDashboard.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Location = new System.Drawing.Point(4, 30);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(412, 0);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "配置";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Location = new System.Drawing.Point(4, 30);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(412, 0);
            this.tabDatabase.TabIndex = 2;
            this.tabDatabase.Text = "数据库";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(341, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Industrial Telemetry Dashboard";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.BackColor = System.Drawing.Color.White;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStartStop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartStop.Location = new System.Drawing.Point(1037, 12);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(135, 32);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // pagesHost
            // 
            this.pagesHost.Controls.Add(this.pageDashboard);
            this.pagesHost.Controls.Add(this.pageSettings);
            this.pagesHost.Controls.Add(this.pageDatabase);
            this.pagesHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagesHost.Location = new System.Drawing.Point(0, 82);
            this.pagesHost.Name = "pagesHost";
            this.pagesHost.Padding = new System.Windows.Forms.Padding(10);
            this.pagesHost.Size = new System.Drawing.Size(1184, 679);
            this.pagesHost.TabIndex = 1;
            // 
            // pageDashboard
            // 
            this.pageDashboard.Controls.Add(this.splitDash);
            this.pageDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDashboard.Location = new System.Drawing.Point(10, 10);
            this.pageDashboard.Name = "pageDashboard";
            this.pageDashboard.Size = new System.Drawing.Size(1164, 659);
            this.pageDashboard.TabIndex = 0;
            // 
            // pageSettings
            // 
            this.pageSettings.Controls.Add(this.groupSystemConfig);
            this.pageSettings.Controls.Add(this.groupConnConfig);
            this.pageSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageSettings.Location = new System.Drawing.Point(10, 10);
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Padding = new System.Windows.Forms.Padding(0);
            this.pageSettings.Size = new System.Drawing.Size(1164, 659);
            this.pageSettings.TabIndex = 1;
            this.pageSettings.Visible = false;
            // 
            // pageDatabase
            // 
            this.pageDatabase.Controls.Add(this.groupDbSamples);
            this.pageDatabase.Controls.Add(this.panelDbActions);
            this.pageDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDatabase.Location = new System.Drawing.Point(10, 10);
            this.pageDatabase.Name = "pageDatabase";
            this.pageDatabase.Size = new System.Drawing.Size(1164, 659);
            this.pageDatabase.TabIndex = 2;
            this.pageDatabase.Visible = false;
            // 
            // splitDash
            // 
            this.splitDash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDash.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitDash.Location = new System.Drawing.Point(0, 0);
            this.splitDash.Name = "splitDash";
            // 
            // splitDash.Panel1
            // 
            this.splitDash.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.splitDash.Panel1.Controls.Add(this.groupCommands);
            this.splitDash.Panel1.Controls.Add(this.groupLogs);
            this.splitDash.Panel1.Controls.Add(this.groupStatus);
            this.splitDash.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitDash.Panel2
            // 
            this.splitDash.Panel2.Controls.Add(this.splitDashRight);
            this.splitDash.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitDash.Size = new System.Drawing.Size(1164, 659);
            this.splitDash.SplitterDistance = 360;
            this.splitDash.TabIndex = 0;
            // 
            // splitDashRight
            // 
            this.splitDashRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDashRight.Location = new System.Drawing.Point(10, 10);
            this.splitDashRight.Name = "splitDashRight";
            this.splitDashRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitDashRight.Panel1
            // 
            this.splitDashRight.Panel1.Controls.Add(this.groupTrend);
            this.splitDashRight.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // splitDashRight.Panel2
            // 
            this.splitDashRight.Panel2Collapsed = true;
            this.splitDashRight.Size = new System.Drawing.Size(780, 639);
            this.splitDashRight.SplitterDistance = 420;
            this.splitDashRight.TabIndex = 0;
            // 
            // groupStatus
            // 
            this.groupStatus.BackColor = System.Drawing.Color.White;
            this.groupStatus.Controls.Add(this.tableKpi);
            this.groupStatus.Controls.Add(this.panelAlarm);
            this.groupStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.groupStatus.Location = new System.Drawing.Point(10, 10);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Padding = new System.Windows.Forms.Padding(10);
            this.groupStatus.Size = new System.Drawing.Size(340, 250);
            this.groupStatus.TabIndex = 0;
            this.groupStatus.TabStop = false;
            this.groupStatus.Text = "状态看板";
            // 
            // groupLogs
            // 
            this.groupLogs.BackColor = System.Drawing.Color.White;
            this.groupLogs.Controls.Add(this.listLogs);
            this.groupLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.groupLogs.Location = new System.Drawing.Point(10, 260);
            this.groupLogs.Name = "groupLogs";
            this.groupLogs.Padding = new System.Windows.Forms.Padding(10);
            this.groupLogs.Size = new System.Drawing.Size(340, 314);
            this.groupLogs.TabIndex = 1;
            this.groupLogs.TabStop = false;
            this.groupLogs.Text = "日志";
            // 
            // groupCommands
            // 
            this.groupCommands.BackColor = System.Drawing.Color.White;
            this.groupCommands.Controls.Add(this.btnLedToggle);
            this.groupCommands.Controls.Add(this.btnMotorStop);
            this.groupCommands.Controls.Add(this.btnMotorStart);
            this.groupCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupCommands.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupCommands.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.groupCommands.Location = new System.Drawing.Point(10, 574);
            this.groupCommands.Name = "groupCommands";
            this.groupCommands.Padding = new System.Windows.Forms.Padding(10);
            this.groupCommands.Size = new System.Drawing.Size(340, 75);
            this.groupCommands.TabIndex = 2;
            this.groupCommands.TabStop = false;
            this.groupCommands.Text = "指令下发";
            // 
            // groupTrend
            // 
            this.groupTrend.BackColor = System.Drawing.Color.White;
            this.groupTrend.Controls.Add(this.trendsLayout);
            this.groupTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTrend.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupTrend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.groupTrend.Location = new System.Drawing.Point(0, 0);
            this.groupTrend.Name = "groupTrend";
            this.groupTrend.Padding = new System.Windows.Forms.Padding(10);
            this.groupTrend.Size = new System.Drawing.Size(780, 410);
            this.groupTrend.TabIndex = 0;
            this.groupTrend.TabStop = false;
            this.groupTrend.Text = "趋势可视化";
            // 
            // trendsLayout
            // 
            this.trendsLayout.ColumnCount = 1;
            this.trendsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.trendsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trendsLayout.Location = new System.Drawing.Point(10, 33);
            this.trendsLayout.Name = "trendsLayout";
            this.trendsLayout.RowCount = 3;
            this.trendsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.trendsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.trendsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.trendsLayout.Size = new System.Drawing.Size(760, 367);
            this.trendsLayout.TabIndex = 0;
            this.trendsLayout.Controls.Add(this.chartTemp, 0, 0);
            this.trendsLayout.Controls.Add(this.chartVolt, 0, 1);
            this.trendsLayout.Controls.Add(this.chartRpm, 0, 2);
            // 
            // chartTemp
            // 
            this.chartTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTemp.Location = new System.Drawing.Point(3, 3);
            this.chartTemp.Name = "chartTemp";
            this.chartTemp.Size = new System.Drawing.Size(754, 116);
            this.chartTemp.TabIndex = 0;
            // 
            // chartVolt
            // 
            this.chartVolt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVolt.Location = new System.Drawing.Point(3, 125);
            this.chartVolt.Name = "chartVolt";
            this.chartVolt.Size = new System.Drawing.Size(754, 116);
            this.chartVolt.TabIndex = 1;
            // 
            // chartRpm
            // 
            this.chartRpm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRpm.Location = new System.Drawing.Point(3, 247);
            this.chartRpm.Name = "chartRpm";
            this.chartRpm.Size = new System.Drawing.Size(754, 117);
            this.chartRpm.TabIndex = 2;
            // 
            // groupConnConfig
            // 
            this.groupConnConfig.BackColor = System.Drawing.Color.White;
            this.groupConnConfig.Controls.Add(this.btnRefreshPorts);
            this.groupConnConfig.Controls.Add(this.cbStopBits);
            this.groupConnConfig.Controls.Add(this.lblStopBits);
            this.groupConnConfig.Controls.Add(this.cbDataBits);
            this.groupConnConfig.Controls.Add(this.lblDataBits);
            this.groupConnConfig.Controls.Add(this.cbParity);
            this.groupConnConfig.Controls.Add(this.lblParity);
            this.groupConnConfig.Controls.Add(this.cbBaud);
            this.groupConnConfig.Controls.Add(this.lblBaud);
            this.groupConnConfig.Controls.Add(this.cbPort);
            this.groupConnConfig.Controls.Add(this.lblPort);
            this.groupConnConfig.Controls.Add(this.cbMode);
            this.groupConnConfig.Controls.Add(this.lblMode);
            this.groupConnConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupConnConfig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupConnConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.groupConnConfig.Location = new System.Drawing.Point(0, 0);
            this.groupConnConfig.Name = "groupConnConfig";
            this.groupConnConfig.Padding = new System.Windows.Forms.Padding(10);
            this.groupConnConfig.Size = new System.Drawing.Size(360, 659);
            this.groupConnConfig.TabIndex = 0;
            this.groupConnConfig.TabStop = false;
            this.groupConnConfig.Text = "连接配置";
            // 
            // groupSystemConfig
            // 
            this.groupSystemConfig.BackColor = System.Drawing.Color.White;
            this.groupSystemConfig.Controls.Add(this.btnSaveSettings);
            this.groupSystemConfig.Controls.Add(this.numMaxRows);
            this.groupSystemConfig.Controls.Add(this.lblRetention);
            this.groupSystemConfig.Controls.Add(this.numAlarmTemp);
            this.groupSystemConfig.Controls.Add(this.lblAlarmAlarm);
            this.groupSystemConfig.Controls.Add(this.numWarnTemp);
            this.groupSystemConfig.Controls.Add(this.lblAlarmWarn);
            this.groupSystemConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSystemConfig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupSystemConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.groupSystemConfig.Location = new System.Drawing.Point(360, 0);
            this.groupSystemConfig.Name = "groupSystemConfig";
            this.groupSystemConfig.Padding = new System.Windows.Forms.Padding(10);
            this.groupSystemConfig.Size = new System.Drawing.Size(804, 659);
            this.groupSystemConfig.TabIndex = 1;
            this.groupSystemConfig.TabStop = false;
            this.groupSystemConfig.Text = "系统配置";
            // 
            // lblAlarmWarn
            // 
            this.lblAlarmWarn.AutoSize = true;
            this.lblAlarmWarn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlarmWarn.Location = new System.Drawing.Point(20, 40);
            this.lblAlarmWarn.Name = "lblAlarmWarn";
            this.lblAlarmWarn.Size = new System.Drawing.Size(159, 23);
            this.lblAlarmWarn.TabIndex = 0;
            this.lblAlarmWarn.Text = "预警温度阈值(°C)：";
            // 
            // numWarnTemp
            // 
            this.numWarnTemp.DecimalPlaces = 1;
            this.numWarnTemp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numWarnTemp.Location = new System.Drawing.Point(210, 38);
            this.numWarnTemp.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numWarnTemp.Name = "numWarnTemp";
            this.numWarnTemp.Size = new System.Drawing.Size(120, 30);
            this.numWarnTemp.TabIndex = 1;
            // 
            // lblAlarmAlarm
            // 
            this.lblAlarmAlarm.AutoSize = true;
            this.lblAlarmAlarm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlarmAlarm.Location = new System.Drawing.Point(20, 80);
            this.lblAlarmAlarm.Name = "lblAlarmAlarm";
            this.lblAlarmAlarm.Size = new System.Drawing.Size(159, 23);
            this.lblAlarmAlarm.TabIndex = 2;
            this.lblAlarmAlarm.Text = "报警温度阈值(°C)：";
            // 
            // numAlarmTemp
            // 
            this.numAlarmTemp.DecimalPlaces = 1;
            this.numAlarmTemp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numAlarmTemp.Location = new System.Drawing.Point(210, 78);
            this.numAlarmTemp.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numAlarmTemp.Name = "numAlarmTemp";
            this.numAlarmTemp.Size = new System.Drawing.Size(120, 30);
            this.numAlarmTemp.TabIndex = 3;
            // 
            // lblRetention
            // 
            this.lblRetention.AutoSize = true;
            this.lblRetention.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRetention.Location = new System.Drawing.Point(20, 120);
            this.lblRetention.Name = "lblRetention";
            this.lblRetention.Size = new System.Drawing.Size(182, 23);
            this.lblRetention.TabIndex = 4;
            this.lblRetention.Text = "数据库保留采样条数：";
            // 
            // numMaxRows
            // 
            this.numMaxRows.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMaxRows.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxRows.Location = new System.Drawing.Point(210, 118);
            this.numMaxRows.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxRows.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxRows.Name = "numMaxRows";
            this.numMaxRows.Size = new System.Drawing.Size(120, 30);
            this.numMaxRows.TabIndex = 5;
            this.numMaxRows.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveSettings.Location = new System.Drawing.Point(24, 170);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(140, 30);
            this.btnSaveSettings.TabIndex = 6;
            this.btnSaveSettings.Text = "保存配置";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // panelDbActions
            // 
            this.panelDbActions.Controls.Add(this.btnDbExportCsv);
            this.panelDbActions.Controls.Add(this.btnDbDeleteSample);
            this.panelDbActions.Controls.Add(this.btnDbLoadSamples);
            this.panelDbActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDbActions.Location = new System.Drawing.Point(0, 0);
            this.panelDbActions.Name = "panelDbActions";
            this.panelDbActions.Padding = new System.Windows.Forms.Padding(10);
            this.panelDbActions.Size = new System.Drawing.Size(1164, 52);
            this.panelDbActions.TabIndex = 0;
            // 
            // btnDbLoadSamples
            // 
            this.btnDbLoadSamples.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDbLoadSamples.Location = new System.Drawing.Point(10, 10);
            this.btnDbLoadSamples.Name = "btnDbLoadSamples";
            this.btnDbLoadSamples.Size = new System.Drawing.Size(110, 30);
            this.btnDbLoadSamples.TabIndex = 0;
            this.btnDbLoadSamples.Text = "查询";
            this.btnDbLoadSamples.UseVisualStyleBackColor = true;
            this.btnDbLoadSamples.Click += new System.EventHandler(this.btnDbLoadSamples_Click);
            // 
            // btnDbDeleteSample
            // 
            this.btnDbDeleteSample.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDbDeleteSample.Location = new System.Drawing.Point(126, 10);
            this.btnDbDeleteSample.Name = "btnDbDeleteSample";
            this.btnDbDeleteSample.Size = new System.Drawing.Size(110, 30);
            this.btnDbDeleteSample.TabIndex = 1;
            this.btnDbDeleteSample.Text = "删除选中";
            this.btnDbDeleteSample.UseVisualStyleBackColor = true;
            this.btnDbDeleteSample.Click += new System.EventHandler(this.btnDbDeleteSample_Click);
            // 
            // btnDbExportCsv
            // 
            this.btnDbExportCsv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDbExportCsv.Location = new System.Drawing.Point(242, 10);
            this.btnDbExportCsv.Name = "btnDbExportCsv";
            this.btnDbExportCsv.Size = new System.Drawing.Size(110, 30);
            this.btnDbExportCsv.TabIndex = 2;
            this.btnDbExportCsv.Text = "导出CSV";
            this.btnDbExportCsv.UseVisualStyleBackColor = true;
            this.btnDbExportCsv.Click += new System.EventHandler(this.btnDbExportCsv_Click);
            // 
            // groupDbSamples
            // 
            this.groupDbSamples.BackColor = System.Drawing.Color.White;
            this.groupDbSamples.Controls.Add(this.gridSamples);
            this.groupDbSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDbSamples.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupDbSamples.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.groupDbSamples.Location = new System.Drawing.Point(0, 52);
            this.groupDbSamples.Name = "groupDbSamples";
            this.groupDbSamples.Padding = new System.Windows.Forms.Padding(10);
            this.groupDbSamples.Size = new System.Drawing.Size(1164, 607);
            this.groupDbSamples.TabIndex = 1;
            this.groupDbSamples.TabStop = false;
            this.groupDbSamples.Text = "TelemetrySamples";
            // 
            // gridSamples
            // 
            this.gridSamples.AllowUserToAddRows = false;
            this.gridSamples.AllowUserToDeleteRows = false;
            this.gridSamples.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSamples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSamples.Location = new System.Drawing.Point(10, 33);
            this.gridSamples.MultiSelect = false;
            this.gridSamples.Name = "gridSamples";
            this.gridSamples.ReadOnly = true;
            this.gridSamples.RowHeadersVisible = false;
            this.gridSamples.RowTemplate.Height = 24;
            this.gridSamples.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSamples.Size = new System.Drawing.Size(1144, 564);
            this.gridSamples.TabIndex = 0;
            // 
            // tableKpi
            // 
            this.tableKpi.ColumnCount = 2;
            this.tableKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tableKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tableKpi.Controls.Add(this.lblTempCaption, 0, 0);
            this.tableKpi.Controls.Add(this.lblVoltCaption, 0, 1);
            this.tableKpi.Controls.Add(this.lblRpmCaption, 0, 2);
            this.tableKpi.Controls.Add(this.lblTempValue, 1, 0);
            this.tableKpi.Controls.Add(this.lblVoltValue, 1, 1);
            this.tableKpi.Controls.Add(this.lblRpmValue, 1, 2);
            this.tableKpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableKpi.Location = new System.Drawing.Point(10, 78);
            this.tableKpi.Name = "tableKpi";
            this.tableKpi.RowCount = 3;
            this.tableKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableKpi.Size = new System.Drawing.Size(320, 162);
            this.tableKpi.TabIndex = 1;
            // 
            // lblTempCaption
            // 
            this.lblTempCaption.AutoSize = true;
            this.lblTempCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTempCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTempCaption.Location = new System.Drawing.Point(3, 0);
            this.lblTempCaption.Name = "lblTempCaption";
            this.lblTempCaption.Padding = new System.Windows.Forms.Padding(6, 18, 6, 6);
            this.lblTempCaption.Size = new System.Drawing.Size(128, 75);
            this.lblTempCaption.TabIndex = 0;
            this.lblTempCaption.Text = "温度 (°C)";
            this.lblTempCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVoltCaption
            // 
            this.lblVoltCaption.AutoSize = true;
            this.lblVoltCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVoltCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVoltCaption.Location = new System.Drawing.Point(3, 75);
            this.lblVoltCaption.Name = "lblVoltCaption";
            this.lblVoltCaption.Padding = new System.Windows.Forms.Padding(6, 18, 6, 6);
            this.lblVoltCaption.Size = new System.Drawing.Size(128, 75);
            this.lblVoltCaption.TabIndex = 1;
            this.lblVoltCaption.Text = "电压 (V)";
            this.lblVoltCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRpmCaption
            // 
            this.lblRpmCaption.AutoSize = true;
            this.lblRpmCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRpmCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRpmCaption.Location = new System.Drawing.Point(3, 150);
            this.lblRpmCaption.Name = "lblRpmCaption";
            this.lblRpmCaption.Padding = new System.Windows.Forms.Padding(6, 18, 6, 6);
            this.lblRpmCaption.Size = new System.Drawing.Size(128, 76);
            this.lblRpmCaption.TabIndex = 2;
            this.lblRpmCaption.Text = "转速 (RPM)";
            this.lblRpmCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTempValue
            // 
            this.lblTempValue.AutoSize = true;
            this.lblTempValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTempValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTempValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblTempValue.Location = new System.Drawing.Point(137, 0);
            this.lblTempValue.Name = "lblTempValue";
            this.lblTempValue.Padding = new System.Windows.Forms.Padding(6, 10, 6, 6);
            this.lblTempValue.Size = new System.Drawing.Size(180, 75);
            this.lblTempValue.TabIndex = 3;
            this.lblTempValue.Text = "--";
            this.lblTempValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVoltValue
            // 
            this.lblVoltValue.AutoSize = true;
            this.lblVoltValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVoltValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblVoltValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblVoltValue.Location = new System.Drawing.Point(137, 75);
            this.lblVoltValue.Name = "lblVoltValue";
            this.lblVoltValue.Padding = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.lblVoltValue.Size = new System.Drawing.Size(180, 75);
            this.lblVoltValue.TabIndex = 4;
            this.lblVoltValue.Text = "--";
            this.lblVoltValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRpmValue
            // 
            this.lblRpmValue.AutoSize = true;
            this.lblRpmValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRpmValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblRpmValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblRpmValue.Location = new System.Drawing.Point(137, 150);
            this.lblRpmValue.Name = "lblRpmValue";
            this.lblRpmValue.Padding = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.lblRpmValue.Size = new System.Drawing.Size(180, 76);
            this.lblRpmValue.TabIndex = 5;
            this.lblRpmValue.Text = "--";
            this.lblRpmValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAlarm
            // 
            this.panelAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(234)))));
            this.panelAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAlarm.Controls.Add(this.lblAlarmText);
            this.panelAlarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAlarm.Location = new System.Drawing.Point(10, 33);
            this.panelAlarm.Name = "panelAlarm";
            this.panelAlarm.Padding = new System.Windows.Forms.Padding(10);
            this.panelAlarm.Size = new System.Drawing.Size(320, 45);
            this.panelAlarm.TabIndex = 0;
            // 
            // lblAlarmText
            // 
            this.lblAlarmText.AutoSize = true;
            this.lblAlarmText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlarmText.Location = new System.Drawing.Point(10, 10);
            this.lblAlarmText.Name = "lblAlarmText";
            this.lblAlarmText.Size = new System.Drawing.Size(101, 25);
            this.lblAlarmText.TabIndex = 0;
            this.lblAlarmText.Text = "状态：OK";
            // 
            // listLogs
            // 
            this.listLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colCategory,
            this.colMessage});
            this.listLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLogs.Font = new System.Drawing.Font("Consolas", 9F);
            this.listLogs.FullRowSelect = true;
            this.listLogs.GridLines = true;
            this.listLogs.HideSelection = false;
            this.listLogs.Location = new System.Drawing.Point(10, 33);
            this.listLogs.Name = "listLogs";
            this.listLogs.Size = new System.Drawing.Size(320, 271);
            this.listLogs.TabIndex = 0;
            this.listLogs.UseCompatibleStateImageBehavior = false;
            this.listLogs.View = System.Windows.Forms.View.Details;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 130;
            // 
            // colCategory
            // 
            this.colCategory.Text = "Category";
            this.colCategory.Width = 80;
            // 
            // colMessage
            // 
            this.colMessage.Text = "Message";
            this.colMessage.Width = 420;
            // 
            // btnLedToggle
            // 
            this.btnLedToggle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLedToggle.Location = new System.Drawing.Point(226, 30);
            this.btnLedToggle.Name = "btnLedToggle";
            this.btnLedToggle.Size = new System.Drawing.Size(98, 32);
            this.btnLedToggle.TabIndex = 2;
            this.btnLedToggle.Text = "LED 开关";
            this.btnLedToggle.UseVisualStyleBackColor = true;
            this.btnLedToggle.Click += new System.EventHandler(this.btnLedToggle_Click);
            // 
            // btnMotorStop
            // 
            this.btnMotorStop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMotorStop.Location = new System.Drawing.Point(122, 30);
            this.btnMotorStop.Name = "btnMotorStop";
            this.btnMotorStop.Size = new System.Drawing.Size(98, 32);
            this.btnMotorStop.TabIndex = 1;
            this.btnMotorStop.Text = "电机停止";
            this.btnMotorStop.UseVisualStyleBackColor = true;
            this.btnMotorStop.Click += new System.EventHandler(this.btnMotorStop_Click);
            // 
            // btnMotorStart
            // 
            this.btnMotorStart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMotorStart.Location = new System.Drawing.Point(18, 30);
            this.btnMotorStart.Name = "btnMotorStart";
            this.btnMotorStart.Size = new System.Drawing.Size(98, 32);
            this.btnMotorStart.TabIndex = 0;
            this.btnMotorStart.Text = "电机启动";
            this.btnMotorStart.UseVisualStyleBackColor = true;
            this.btnMotorStart.Click += new System.EventHandler(this.btnMotorStart_Click);
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshPorts.Location = new System.Drawing.Point(18, 242);
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(92, 26);
            this.btnRefreshPorts.TabIndex = 12;
            this.btnRefreshPorts.Text = "刷新端口";
            this.btnRefreshPorts.UseVisualStyleBackColor = true;
            this.btnRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // cbStopBits
            // 
            this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBits.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Location = new System.Drawing.Point(110, 210);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(214, 31);
            this.cbStopBits.TabIndex = 11;
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStopBits.Location = new System.Drawing.Point(14, 213);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(78, 23);
            this.lblStopBits.TabIndex = 10;
            this.lblStopBits.Text = "停止位：";
            // 
            // cbDataBits
            // 
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Location = new System.Drawing.Point(110, 174);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(214, 31);
            this.cbDataBits.TabIndex = 9;
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDataBits.Location = new System.Drawing.Point(14, 177);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(78, 23);
            this.lblDataBits.TabIndex = 8;
            this.lblDataBits.Text = "数据位：";
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(110, 138);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(214, 31);
            this.cbParity.TabIndex = 7;
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblParity.Location = new System.Drawing.Point(14, 141);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(78, 23);
            this.lblParity.TabIndex = 6;
            this.lblParity.Text = "校验位：";
            // 
            // cbBaud
            // 
            this.cbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaud.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Location = new System.Drawing.Point(110, 102);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(214, 31);
            this.cbBaud.TabIndex = 5;
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBaud.Location = new System.Drawing.Point(14, 105);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(78, 23);
            this.lblBaud.TabIndex = 4;
            this.lblBaud.Text = "波特率：";
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(110, 66);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(214, 31);
            this.cbPort.TabIndex = 3;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPort.Location = new System.Drawing.Point(14, 69);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(78, 23);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "端口号：";
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Location = new System.Drawing.Point(110, 30);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(214, 31);
            this.cbMode.TabIndex = 1;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMode.Location = new System.Drawing.Point(14, 33);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(61, 23);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "模式：";
            // 
            // timerUi
            // 
            this.timerUi.Interval = 250;
            this.timerUi.Tick += new System.EventHandler(this.timerUi_Tick);
            // 
            // timerBlink
            // 
            this.timerBlink.Interval = 400;
            this.timerBlink.Tick += new System.EventHandler(this.timerBlink_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.pagesHost);
            this.Controls.Add(this.ribbonPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工业遥测仪表盘";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ribbonPanel.ResumeLayout(false);
            this.ribbonPanel.PerformLayout();
            this.rbnTabs.ResumeLayout(false);
            this.pagesHost.ResumeLayout(false);
            this.pageDashboard.ResumeLayout(false);
            this.splitDash.Panel1.ResumeLayout(false);
            this.splitDash.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDash)).EndInit();
            this.splitDash.ResumeLayout(false);
            this.splitDashRight.Panel1.ResumeLayout(false);
            this.splitDashRight.ResumeLayout(false);
            this.groupStatus.ResumeLayout(false);
            this.tableKpi.ResumeLayout(false);
            this.tableKpi.PerformLayout();
            this.panelAlarm.ResumeLayout(false);
            this.panelAlarm.PerformLayout();
            this.groupCommands.ResumeLayout(false);
            this.groupLogs.ResumeLayout(false);
            this.groupTrend.ResumeLayout(false);
            this.trendsLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRpm)).EndInit();
            this.pageSettings.ResumeLayout(false);
            this.groupConnConfig.ResumeLayout(false);
            this.groupConnConfig.PerformLayout();
            this.groupSystemConfig.ResumeLayout(false);
            this.groupSystemConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWarnTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRows)).EndInit();
            this.pageDatabase.ResumeLayout(false);
            this.groupDbSamples.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSamples)).EndInit();
            this.panelDbActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ribbonPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.TabControl rbnTabs;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.Panel pagesHost;
        private System.Windows.Forms.Panel pageDashboard;
        private System.Windows.Forms.Panel pageSettings;
        private System.Windows.Forms.Panel pageDatabase;
        private System.Windows.Forms.SplitContainer splitDash;
        private System.Windows.Forms.SplitContainer splitDashRight;
        private System.Windows.Forms.GroupBox groupStatus;
        private System.Windows.Forms.TableLayoutPanel tableKpi;
        private System.Windows.Forms.Label lblTempCaption;
        private System.Windows.Forms.Label lblVoltCaption;
        private System.Windows.Forms.Label lblRpmCaption;
        private System.Windows.Forms.Label lblTempValue;
        private System.Windows.Forms.Label lblVoltValue;
        private System.Windows.Forms.Label lblRpmValue;
        private System.Windows.Forms.Panel panelAlarm;
        private System.Windows.Forms.Label lblAlarmText;
        private System.Windows.Forms.GroupBox groupCommands;
        private System.Windows.Forms.Button btnLedToggle;
        private System.Windows.Forms.Button btnMotorStop;
        private System.Windows.Forms.Button btnMotorStart;
        private System.Windows.Forms.GroupBox groupLogs;
        private System.Windows.Forms.ListView listLogs;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colMessage;
        private System.Windows.Forms.GroupBox groupTrend;
        private System.Windows.Forms.TableLayoutPanel trendsLayout;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVolt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRpm;
        private System.Windows.Forms.GroupBox groupConnConfig;
        private System.Windows.Forms.Button btnRefreshPorts;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.Label lblBaud;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.GroupBox groupSystemConfig;
        private System.Windows.Forms.Label lblAlarmWarn;
        private System.Windows.Forms.NumericUpDown numWarnTemp;
        private System.Windows.Forms.Label lblAlarmAlarm;
        private System.Windows.Forms.NumericUpDown numAlarmTemp;
        private System.Windows.Forms.Label lblRetention;
        private System.Windows.Forms.NumericUpDown numMaxRows;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.GroupBox groupDbSamples;
        private System.Windows.Forms.DataGridView gridSamples;
        private System.Windows.Forms.Panel panelDbActions;
        private System.Windows.Forms.Button btnDbLoadSamples;
        private System.Windows.Forms.Button btnDbDeleteSample;
        private System.Windows.Forms.Button btnDbExportCsv;
        private System.Windows.Forms.Timer timerUi;
        private System.Windows.Forms.Timer timerBlink;
    }
}

