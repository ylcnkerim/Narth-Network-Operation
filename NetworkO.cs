using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narth
{
    public partial class NetworkO : Form
    {
        public NetworkO()
        {
            InitializeComponent();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void SetMtu(int mtu)
        {
            try
            {
                string interfaceName = GetPrimaryInterfaceName();

                if (string.IsNullOrEmpty(interfaceName))
                {
                    listBox1.Items.Add("Network interface not found.");
                    return;
                }

                Process process = new Process();
                process.StartInfo.FileName = "netsh";
                process.StartInfo.Arguments = $"interface ipv4 set subinterface \"{interfaceName}\" mtu={mtu} store=persistent";
                process.StartInfo.Verb = "runas";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = true;

                process.Start();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    listBox1.Items.Add($"MTU value has been successfully set to {mtu}\nInterface: {interfaceName}");
                }
                else
                {
                    listBox1.Items.Add("Error");
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error " + ex.Message);
            }
        }

        private string GetPrimaryInterfaceName()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "netsh";
                process.StartInfo.Arguments = "interface show interface";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                foreach (var line in output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.Contains("Connected") && line.Contains("Dedicated"))
                    {
                        string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 4)
                        {
                            int nameStartIndex = Array.IndexOf(parts, "Dedicated") + 1;
                            string interfaceName = string.Join(" ", parts, nameStartIndex, parts.Length - nameStartIndex);
                            return interfaceName;
                        }
                    }
                }
            }
            catch { }

            return null;
        }
        private async Task RunCommandWithOutput(string command, string infoText)
        {
            listBox1.Items.Add($"--- {infoText} ---");

            await Task.Run(() =>
            {
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c " + command)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();
                        AppendToListBox(line);
                        System.Threading.Thread.Sleep(50);
                    }
                    process.WaitForExit();
                }
            });
        }

        private void AppendToListBox(string text)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action<string>(AppendToListBox), text);
            }
            else
            {
                listBox1.Items.Add(text);
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
        }
        private string GetActiveAdapterName()
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = "interface show interface",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                var lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    if (line.Contains("Connected") && line.Contains("Enabled"))
                    {
                        var parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        return parts[parts.Length - 1];
                    }
                }
            }
            return null;
        }
        private void RunNetshCommand(string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Verb = "runas"
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    string error = process.StandardError.ReadToEnd();
                    throw new Exception($"Unsuccessfull Command: netsh {arguments}\nHata: {error}");
                }
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add("Changing DNS Address...");
                string adapterName = GetActiveAdapterName();
                if (string.IsNullOrEmpty(adapterName))
                {
                    listBox1.Items.Add("Adapter cannot found.");
                    return;
                }

                RunNetshCommand($"interface ip set dns name=\"{adapterName}\" static 8.8.8.8 primary");
                RunNetshCommand($"interface ip add dns name=\"{adapterName}\" 8.8.4.4 index=2");

                listBox1.Items.Add($"DNS adresses changed for: {adapterName}");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error: " + ex.Message);
            }
            await Task.Delay(1000);

            //-------------------------------------

            string mtuValue = textBox1.Text.Trim();
            listBox1.Items.Add("----------------------------------------------");
            if (!int.TryParse(mtuValue, out int mtu) || mtu < 1280 || mtu > 9000)
            {
                listBox1.Items.Add("Please enter a valid value!");
                return;
            }
            listBox1.Items.Add("Setting MTU...");
            button1.Enabled = false;
            button2.Enabled = false;
            await Task.Delay(100);
            SetMtu(mtu);

            //------------------------------------

            listBox1.Items.Add("----------------------------------------------");
            await RunCommandWithOutput("IPCONFIG /RELEASE", "IP Adress Released...");
            await RunCommandWithOutput("IPCONFIG /RENEW", "IP Adress is being renewed...");
            await RunCommandWithOutput("IPCONFIG /FLUSHDNS", "DNS being cleaned...");
            await RunCommandWithOutput("NETSH INT IP RESET", "Reseting IP issues...");

            button2.Enabled = true;
            button1.Enabled = true;
        }
        private int FindOptimalMTU(string ipAddress)
        {
            int low = 1000;
            int high = 1500;
            int optimal = low;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (PingWithDontFragment(ipAddress, mid))
                {
                    optimal = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return optimal + 28;
        }

        private bool PingWithDontFragment(string ipAddress, int packetSize)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                psi.Arguments = $"/c ping {ipAddress} -f -l {packetSize} -n 1";
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    return !output.Contains("Packet needs to be fragmented");
                }
            }
            catch
            {
                return false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int maxMTU = FindOptimalMTU("8.8.8.8");
            listBox1.Items.Add("Optimal MTU: " + maxMTU);
        }

        private void NetworkO_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void NetworkO_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void NetworkO_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}
