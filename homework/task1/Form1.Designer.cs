using System.IO.Ports;
using System.Windows.Forms;

namespace SerialAssistant
{
    partial class Form1
    {
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private ToolStripButton toolOpenClose;
        private ToolStripButton toolScan;
        private ComboBox comboPort;
        private ComboBox comboBaud;
        private ComboBox comboParity;
        private ComboBox comboDataBits;
        private ComboBox comboStopBits;
        private ComboBox comboDisplayFormat;
        private Label lblPort;
        private Label lblBaud;
        private Label lblParity;
        private Label lblDataBits;
        private Label lblStopBits;
        private Label lblDisplayFormat;
        private Button btnSend;
        private Button btnClearRx;
        private TextBox txtSend;
        private TextBox txtReceive;
        private CheckBox chkAutoScroll;
        private CheckBox chkHexSend;
        private System.Windows.Forms.Timer timerChart;
        private Label lblStats;
        private SerialPort serialPort1;
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new ToolStrip();
            this.toolOpenClose = new ToolStripButton();
            this.toolScan = new ToolStripButton();
            this.statusStrip1 = new StatusStrip();
            this.statusLabel = new ToolStripStatusLabel();
            this.comboPort = new ComboBox();
            this.comboBaud = new ComboBox();
            this.comboParity = new ComboBox();
            this.comboDataBits = new ComboBox();
            this.comboStopBits = new ComboBox();
            this.comboDisplayFormat = new ComboBox();
            this.lblPort = new Label();
            this.lblBaud = new Label();
            this.lblParity = new Label();
            this.lblDataBits = new Label();
            this.lblStopBits = new Label();
            this.lblDisplayFormat = new Label();
            this.btnSend = new Button();
            this.btnClearRx = new Button();
            this.txtSend = new TextBox();
            this.txtReceive = new TextBox();
            this.chkAutoScroll = new CheckBox();
            this.chkHexSend = new CheckBox();
            this.timerChart = new System.Windows.Forms.Timer(this.components);
            this.lblStats = new Label();
            this.serialPort1 = new SerialPort(this.components);
            // ToolStrip
            this.toolOpenClose.Text = "打开串口"; this.toolOpenClose.Click += (s,e)=>ToggleSerialPort();
            this.toolScan.Text = "扫描端口"; this.toolScan.Click += (s,e)=>ScanPorts();
            this.toolStrip1.Items.AddRange(new ToolStripItem[]{toolOpenClose, toolScan});
            // StatusStrip
            this.statusStrip1.Items.Add(statusLabel);
            this.statusLabel.Text = "未打开串口";
            // Labels & Comboboxes
            this.lblPort.Text = "串口:"; this.lblPort.AutoSize = true;
            this.lblBaud.Text = "波特率:"; this.lblBaud.AutoSize = true;
            this.lblParity.Text = "校验:"; this.lblParity.AutoSize = true;
            this.lblDataBits.Text = "数据位:"; this.lblDataBits.AutoSize = true;
            this.lblStopBits.Text = "停止位:"; this.lblStopBits.AutoSize = true;
            this.lblDisplayFormat.Text = "显示格式:"; this.lblDisplayFormat.AutoSize = true;
            this.comboDisplayFormat.DropDownStyle = ComboBoxStyle.DropDownList; this.comboDisplayFormat.Items.AddRange(new object[]{"ASCII","HEX"}); this.comboDisplayFormat.SelectedIndex = 0;
            this.comboBaud.DropDownStyle = ComboBoxStyle.DropDownList; this.comboBaud.Items.AddRange(new object[]{"9600","19200","38400","57600","115200"}); this.comboBaud.SelectedIndex = 0;
            this.comboParity.DropDownStyle = ComboBoxStyle.DropDownList; this.comboParity.Items.AddRange(Enum.GetNames(typeof(Parity))); this.comboParity.SelectedItem = Parity.None.ToString();
            this.comboDataBits.DropDownStyle = ComboBoxStyle.DropDownList; this.comboDataBits.Items.AddRange(new object[]{"5","6","7","8"}); this.comboDataBits.SelectedItem = "8";
            this.comboStopBits.DropDownStyle = ComboBoxStyle.DropDownList; this.comboStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits))); this.comboStopBits.SelectedItem = StopBits.One.ToString();
            // TextBoxes
            this.txtReceive.Multiline = true; this.txtReceive.ScrollBars = ScrollBars.Vertical; this.txtReceive.ReadOnly = true;
            this.txtSend.Multiline = true; this.txtSend.ScrollBars = ScrollBars.Vertical;
            // Buttons
            this.btnSend.Text = "发送"; this.btnSend.Click += (s,e)=>SendData();
            this.btnClearRx.Text = "清空接收"; this.btnClearRx.Click += (s,e)=> txtReceive.Clear();
            // CheckBoxes
            this.chkAutoScroll.Text = "自动滚动"; this.chkAutoScroll.Checked = true;
            this.chkHexSend.Text = "发送HEX"; this.chkHexSend.Checked = false;
            // Timer
            this.timerChart.Interval = 1000; this.timerChart.Tick += (s,e)=>UpdateChart();
            // Stats label
            this.lblStats.Text = "统计: 0 bytes"; this.lblStats.AutoSize = true;
            // Layout (调整顶端起始位置)
            int top = 10; // 原来是 30, 去掉菜单后上移
            this.toolStrip1.Dock = DockStyle.Top;
            top += this.toolStrip1.Height + 5;
            this.lblPort.Left = 10; this.lblPort.Top = top; this.comboPort.Left = 60; this.comboPort.Top = top; this.comboPort.Width = 90;
            this.lblBaud.Left = 160; this.lblBaud.Top = top; this.comboBaud.Left = 220; this.comboBaud.Top = top; this.comboBaud.Width = 90;
            this.lblParity.Left = 320; this.lblParity.Top = top; this.comboParity.Left = 370; this.comboParity.Top = top; this.comboParity.Width = 90;
            top += 30;
            this.lblDataBits.Left = 10; this.lblDataBits.Top = top; this.comboDataBits.Left = 70; this.comboDataBits.Top = top; this.comboDataBits.Width = 80;
            this.lblStopBits.Left = 160; this.lblStopBits.Top = top; this.comboStopBits.Left = 220; this.comboStopBits.Top = top; this.comboStopBits.Width = 90;
            this.lblDisplayFormat.Left = 320; this.lblDisplayFormat.Top = top; this.comboDisplayFormat.Left = 400; this.comboDisplayFormat.Top = top; this.comboDisplayFormat.Width = 80;
            top += 35;
            this.txtReceive.Left = 10; this.txtReceive.Top = top; this.txtReceive.Width = 470; this.txtReceive.Height = 180;
            this.lblStats.Left = 490; this.lblStats.Top = top;
            top += 190;
            this.txtSend.Left = 10; this.txtSend.Top = top; this.txtSend.Width = 470; this.txtSend.Height = 80;
            this.btnSend.Left = 490; this.btnSend.Top = top; this.btnSend.Width = 80;
            this.btnClearRx.Left = 580; this.btnClearRx.Top = top; this.btnClearRx.Width = 80;
            this.chkAutoScroll.Left = 490; this.chkAutoScroll.Top = top + 40;
            this.chkHexSend.Left = 580; this.chkHexSend.Top = top + 40;
            // Form settings
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 470);
            this.Text = "串口调试助手";
            this.Controls.AddRange(new Control[]{toolStrip1, statusStrip1, lblPort, comboPort, lblBaud, comboBaud, lblParity, comboParity, lblDataBits, comboDataBits, lblStopBits, comboStopBits, lblDisplayFormat, comboDisplayFormat, txtReceive, txtSend, btnSend, btnClearRx, chkAutoScroll, chkHexSend, lblStats});
            this.statusStrip1.Dock = DockStyle.Bottom;
            this.Load += (s,e)=>OnFormLoad();
        }

        #endregion
    }
}
