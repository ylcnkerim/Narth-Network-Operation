using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narth
{
    public partial class Killer : Form
    {
        public Killer()
        {
            InitializeComponent();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;

        private void Disable() 
        {
            button1.Enabled = false; button2.Enabled = false; button3.Enabled = false;
        }
        private void Enable()
        {
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
        }
        private bool SetServiceStartupType(string serviceName, string startupType)
        {
            try
            {
                string scMode = startupType.ToLower() switch
                {
                    "automatic" => "auto",
                    "manual" => "demand",
                    "disabled" => "disabled",
                    "automaticdelayedstart" => "delayed-auto",
                    _ => "demand"
                };

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "sc.exe",
                    Arguments = $"config \"{serviceName}\" start= {scMode}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process proc = Process.Start(psi))
                {
                    proc.WaitForExit();
                    return proc.ExitCode == 0;
                }
            }
            catch
            {
                return false;
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Processing...");
            Disable();
            await Task.Delay(1000);

            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Items.json");
            string jsonText = File.ReadAllText(jsonPath);
            JObject items = JObject.Parse(jsonText);

            List<string> results = new List<string>();

            foreach (var item in items)
            {
                var serviceArray = item.Value["service"];
                if (serviceArray == null) continue;

                foreach (var service in serviceArray)
                {
                    string name = service["Name"]?.ToString();
                    string mode = service["StartupType"]?.ToString();

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(mode))
                    {
                        bool result = SetServiceStartupType(name, mode);
                        string output = $"{name} services {mode} : {(result ? "✓" : "✗")}";
                        results.Add(output);
                    }
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.Add("--------------------------------------------------");

            foreach (var line in results)
            {
                listBox1.Items.Add(line);
                await Task.Delay(150);
            }
            Enable();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add("----------------------------------------------");
                listBox1.Items.Add("Starting...");
                Disable();
                await Task.Delay(1000);

                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications"))
                {
                    if (key != null)
                    {
                        key.SetValue("GlobalUserDisabled", 1, RegistryValueKind.DWord);
                        listBox1.Items.Add("Backround Apps are Disabled.");
                    }
                    else
                    {
                        listBox1.Items.Clear();
                        listBox1.Items.Add("Registry couldn't be opened");
                    }
                    Enable();
                }

            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error: " + ex.Message);
            }
        }

        private void Killer_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Killer_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void Killer_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}
