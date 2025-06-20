using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narth
{
    public partial class Regedit : Form
    {
        public Regedit()
        {
            InitializeComponent();
        }
        private async void ApplyTcpIpSettings()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters"))
                {
                    key.SetValue("TcpAckFrequency", 1, RegistryValueKind.DWord);
                    listBox1.Items.Add("TcpAckFrequency successfully");
                    await Task.Delay(100);
                    key.SetValue("TCPNoDelay", 1, RegistryValueKind.DWord);
                    listBox1.Items.Add("TCPNoDelay successfully");
                    await Task.Delay(100);
                    key.SetValue("DefaultTTL", 64, RegistryValueKind.DWord);
                    listBox1.Items.Add("DefaultTTL successfully");
                    await Task.Delay(100);
                    key.SetValue("EnablePMTUDiscovery", 1, RegistryValueKind.DWord);
                    listBox1.Items.Add("EnablePMTUDiscovery successfully");
                    await Task.Delay(100);
                    key.SetValue("EnableTCPChimney", 0, RegistryValueKind.DWord);
                    listBox1.Items.Add("EnableTCPChimney successfully");
                    await Task.Delay(100);
                    key.SetValue("EnableRSS", 1, RegistryValueKind.DWord);
                    listBox1.Items.Add("EnableRSS successfully");
                    await Task.Delay(100);
                    key.SetValue("EnableTCPA", 0, RegistryValueKind.DWord);
                    listBox1.Items.Add("EnableTCPA successfully");
                    await Task.Delay(100);
                    key.SetValue("DisableTaskOffload", 0, RegistryValueKind.DWord);
                    listBox1.Items.Add("DisableTaskOffload successfully");
                    await Task.Delay(100);
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("TcpIp dropped: " + ex.Message);
            }
        }

        private async void ApplyDnsCacheSettings()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\Dnscache\Parameters"))
                {
                    key.SetValue("MaxCacheTtl", 86400, RegistryValueKind.DWord);
                    listBox1.Items.Add("MaxCacheTtl successfully");
                    await Task.Delay(100);
                    key.SetValue("MaxNegativeCacheTtl", 0, RegistryValueKind.DWord);
                    listBox1.Items.Add("MaxNegativeCacheTtl successfully");
                    await Task.Delay(100);
                    key.SetValue("NegativeSOACacheTime", 0, RegistryValueKind.DWord);
                    listBox1.Items.Add("NegativeSOACacheTime successfully");
                    await Task.Delay(100);
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("DNS Reg Injection Eroor: " + ex.Message);
            }
        }

        private void ApplyTcpPerformanceSettings()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\MSMQ\Parameters"))
                {
                    key.SetValue("TCPNoDelay", 1, RegistryValueKind.DWord);
                    listBox1.Items.Add("MSMQ TCPNoDelay succesfully");
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("TCP Performance Error: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button1.Enabled = false;
                ApplyTcpIpSettings();
                ApplyDnsCacheSettings();
                ApplyTcpPerformanceSettings();
                button1.Enabled = true;
            }
            else if (radioButton2.Checked)
            {
                listBox1.Items.Add("Coming Soon.");
            }
            else
            {
                listBox1.Items.Add("Please select a transaction before starting.");
            }
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void Regedit_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Regedit_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void Regedit_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}
