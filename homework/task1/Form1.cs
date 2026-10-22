using System.IO.Ports;
using System.Text;

namespace SerialAssistant
{
    public partial class Form1 : Form
    {
        private int receivedCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void OnFormLoad()
        {
            ScanPorts();
            serialPort1.DataReceived += SerialPort1_DataReceived;
            timerChart.Start();
        }

        private void exitToolStripMenuItem_Click(object? sender, EventArgs e) => this.Close();

        private void aboutToolStripMenuItem_Click(object? sender, EventArgs e) => MessageBox.Show("串口调试助手 v1.0", "关于");

        private void ScanPorts()
        {
            try
            {
                var ports = SerialPort.GetPortNames().OrderBy(p => p).ToArray();
                comboPort.Items.Clear();
                comboPort.Items.AddRange(ports);
                if (ports.Length > 0) comboPort.SelectedIndex = 0;
                statusLabel.Text = $"扫描完成: {ports.Length} 个端口";
            }
            catch (Exception ex)
            {
                MessageBox.Show("扫描端口错误: " + ex.Message);
            }
        }

        private void ToggleSerialPort()
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Close();
                    toolOpenClose.Text = "打开串口";
                    statusLabel.Text = "串口已关闭";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("关闭失败: " + ex.Message);
                }
                return;
            }
            if (comboPort.SelectedItem == null)
            {
                MessageBox.Show("请选择串口");
                return;
            }
            try
            {
                serialPort1.PortName = comboPort.SelectedItem.ToString()!;
                serialPort1.BaudRate = int.Parse(comboBaud.SelectedItem.ToString()!);
                serialPort1.Parity = Enum.Parse<Parity>(comboParity.SelectedItem.ToString()!);
                serialPort1.DataBits = int.Parse(comboDataBits.SelectedItem.ToString()!);
                serialPort1.StopBits = Enum.Parse<StopBits>(comboStopBits.SelectedItem.ToString()!);
                serialPort1.Open();
                toolOpenClose.Text = "关闭串口";
                statusLabel.Text = $"已打开 {serialPort1.PortName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开失败: " + ex.Message);
            }
        }

        private void SendData()
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("请先打开串口");
                return;
            }
            var text = txtSend.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;
            try
            {
                if (chkHexSend.Checked)
                {
                    var bytes = HexStringToBytes(text);
                    serialPort1.Write(bytes, 0, bytes.Length);
                }
                else
                {
                    serialPort1.Write(text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送失败: " + ex.Message);
            }
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytes = serialPort1.BytesToRead;
                byte[] buffer = new byte[bytes];
                serialPort1.Read(buffer, 0, bytes);
                this.BeginInvoke(new Action(() => AppendReceived(buffer)));
            }
            catch (Exception ex)
            {
                this.BeginInvoke(new Action(() => MessageBox.Show("接收错误: " + ex.Message)));
            }
        }

        private void AppendReceived(byte[] data)
        {
            string display = comboDisplayFormat.SelectedItem?.ToString() == "HEX" ? BitConverter.ToString(data).Replace('-', ' ') : Encoding.ASCII.GetString(data);
            txtReceive.AppendText(display + Environment.NewLine);
            if (chkAutoScroll.Checked)
            {
                txtReceive.SelectionStart = txtReceive.Text.Length;
                txtReceive.ScrollToCaret();
            }
            receivedCount += data.Length;
        }

        private void UpdateChart()
        {
            lblStats.Text = $"统计: {receivedCount} bytes";
        }

        private static byte[] HexStringToBytes(string hex)
        {
            hex = hex.Replace(" ", "").Replace("\r", "").Replace("\n", "");
            if (hex.Length % 2 != 0) throw new FormatException("HEX字符串长度必须为偶数");
            byte[] result = new byte[hex.Length / 2];
            for (int i = 0; i < result.Length; i++) result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return result;
        }
    }
}
