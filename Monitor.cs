using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narth
{
    public partial class Monitor : Form
    {
        public Monitor()
        {
            InitializeComponent();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private async Task RunArpCommand()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c arp -a";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();

                listBox3.Items.Clear();

                string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    listBox3.Items.Add(line);
                    await Task.Delay(100);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }



        //PORTS



        private async Task ShowOpenPorts()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c netstat -an | find \"LISTEN\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();

                listBox2.Items.Clear();

                string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    listBox2.Items.Add(line.Trim());
                    await Task.Delay(100);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private async Task RunRoutePrint()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c route print";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();

                listBox1.Items.Clear();

                string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    listBox1.Items.Add(line.Trim());
                    await Task.Delay(100);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            RunArpCommand();
            Task.Delay(1000);
            ShowOpenPorts();
            Task.Delay(1000);
            RunRoutePrint();
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = await ping.SendPingAsync("8.8.8.8", 1000);

                    if (reply.Status == IPStatus.Success)
                    {
                        label4.Text = $"8.8.8.8 IP Listening: {reply.RoundtripTime}ms";
                    }
                    else
                    {
                        label4.Text = "ms: Timeout";
                    }
                }
            }
            catch
            {
                label4.Text = "ms: Error";
            }
        }
        private async void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "ping",
                    Arguments = "-n 4 -l 32 8.8.8.8",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = await process.StandardOutput.ReadToEndAsync();
                    process.WaitForExit();

                    // "Packets: Sent = 4, Received = 3, Lost = 1 (25% loss)"
                    var sentMatch = System.Text.RegularExpressions.Regex.Match(output, @"Sent = (\d+)");
                    var recvMatch = System.Text.RegularExpressions.Regex.Match(output, @"Received = (\d+)");
                    var lostMatch = System.Text.RegularExpressions.Regex.Match(output, @"Lost = (\d+)");

                    if (sentMatch.Success && recvMatch.Success && lostMatch.Success)
                    {
                        int sent = int.Parse(sentMatch.Groups[1].Value);
                        int recv = int.Parse(recvMatch.Groups[1].Value);
                        int lost = int.Parse(lostMatch.Groups[1].Value);
                        int loss;
                        loss = (sent - recv) * 25;


                        label5.Text = $"Sent = {sent}:{recv} Recieved, (%{loss}) Lost";
                    }
                    else
                    {
                        label5.Text = "Ping parse error";
                    }
                }
            }
            catch (Exception ex)
            {
                label5.Text = "Ping failed";
            }
        }
        private void Monitor_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1500;
            timer2.Interval = 3000;

            timer1.Tick += timer1_Tick;
            timer2.Tick += timer2_Tick;

            timer1.Start();
            timer2.Start();
        }

        private void Monitor_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Monitor_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void Monitor_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}
