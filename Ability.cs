using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narth
{
    public partial class Ability : Form
    {
        public Ability()
        {
            InitializeComponent();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add("Cleaner starting...");
                Task.Delay(500);
                Process.Start("cleanmgr.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operation failed. " + ex.Message);
            }
        }
        private string RunScCommand(string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "sc.exe",
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                if (process.ExitCode != 0)
                    throw new Exception($"sc.exe exited with code {process.ExitCode}");
                return output;
            }
        }

        private string GetLineContaining(string text, string keyword)
        {
            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.Contains(keyword))
                    return line.Trim();
            }
            return null;
        }

        private string ParseStartType(string line)
        {
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3)
            {
                return parts[2];
            }
            return "Unknown";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Starting.");
            await Task.Delay(750);
            listBox1.Items.Clear();
            listBox1.Items.Add("Starting..");
            await Task.Delay(750);
            listBox1.Items.Clear();
            listBox1.Items.Add("Starting...");
            await Task.Delay(750);
            listBox1.Items.Clear();

            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CloudContent"))
                {
                    if (key != null)
                    {
                        listBox1.Items.Clear();
                        listBox1.Items.Add("------------------------------------------");
                        key.SetValue("DisableConsumerFeatures", 1, RegistryValueKind.DWord);
                        listBox1.Items.Add("Consumer Features have been disabled.");
                    }
                    else
                    {
                        listBox1.Items.Add("Failed to access registry path.");
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                listBox1.Items.Add("You must run this application as Administrator. ");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error: " + ex.Message);
            }




            listBox1.Items.Add("------------------------------------------");
            var services = new[] { "HomeGroupListener", "HomeGroupProvider" };

            foreach (var svc in services)
            {
                try
                {
                    RunScCommand($"config {svc} start= manual");

                    string output = RunScCommand($"qc {svc}");

                    listBox1.Items.Add($"Service Name: {svc}");

                    string startTypeLine = GetLineContaining(output, "START_TYPE");
                    if (startTypeLine != null)
                        listBox1.Items.Add($"Startup Type: {ParseStartType(startTypeLine)}");
                    else
                        listBox1.Items.Add("Startup Type: Not found");

                    listBox1.Items.Add("Original Type: Automatic");
                    listBox1.Items.Add("");
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add($"Error with service {svc}: {ex.Message}");
                    listBox1.Items.Add("");
                }
            }

            await Task.Delay(1000);
            listBox1.Items.Add("------------------------------------------");


            //TEMPP SILME 


            string command = @"
        Get-ChildItem -Path 'C:\Windows\Temp' -Recurse -Force -ErrorAction SilentlyContinue | Remove-Item -Force -Recurse -ErrorAction SilentlyContinue;
        Get-ChildItem -Path $env:TEMP -Recurse -Force -ErrorAction SilentlyContinue | Remove-Item -Force -Recurse -ErrorAction SilentlyContinue;
        Write-Output 'Temporary folders cleaned successfully.'
    ";

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process proc = Process.Start(psi))
                {
                    string output = await proc.StandardOutput.ReadToEndAsync();
                    string error = await proc.StandardError.ReadToEndAsync();

                    proc.WaitForExit();

                    if (!string.IsNullOrWhiteSpace(output))
                    {
                        foreach (string line in output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                            listBox1.Items.Add(line);
                    }

                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        listBox1.Items.Add("Errors:");
                        foreach (string line in error.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                            listBox1.Items.Add(line);
                    }

                    if (string.IsNullOrWhiteSpace(output) && string.IsNullOrWhiteSpace(error))
                        listBox1.Items.Add("No output. Cleanup may have completed silently.");
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Exception occurred:");
                listBox1.Items.Add(ex.Message);
            }
        }

        private void Ability_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Ability_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void Ability_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}
