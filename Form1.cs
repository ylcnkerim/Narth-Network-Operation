namespace Narth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void panelContainer_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panelContainer_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panelContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Maroon;
        }
        private void OpenRegedit()
        {
            var child = new Regedit();

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            child.BackColor = Color.Black;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(child);
            child.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenRegedit();
        }
        private void OpenNetworkO()
        {
            var child = new NetworkO();

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            child.BackColor = Color.Black;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(child);
            child.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenNetworkO();
        }
        private void OpenMonitor()
        {
            var child = new Monitor();

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            child.BackColor = Color.Black;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(child);
            child.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenMonitor();
        }
        private void OpenAbility()
        {
            var child = new Ability();

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            child.BackColor = Color.Black;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(child);
            child.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenAbility();
        }
        private void OpenKiller()
        {
            var child = new Killer();

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            child.BackColor = Color.Black;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(child);
            child.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenKiller();
        }

        private void button3_Enter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.Maroon;
        }

        private void button3_Leave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Maroon;
            button3.ForeColor = Color.Black;

        }

        private void button2_Enter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.Maroon;
        }

        private void button2_Leave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Maroon;
            button2.ForeColor = Color.Black;
        }

        private void button5_Enter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Black;
            button5.ForeColor = Color.Maroon;
        }

        private void button5_Leave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Maroon;
            button5.ForeColor = Color.Black;
        }

        private void button4_Enter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Black;
            button4.ForeColor = Color.Maroon;
        }

        private void button4_Leave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Maroon;
            button4.ForeColor = Color.Black;
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.Maroon;
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Maroon;
            button1.ForeColor = Color.Black;
        }
        int pnt = 0;
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            pnt++;
            if (pnt == 1)
            {
                this.AcceptButton = null;
                this.ActiveControl = null;
            }
        }
    }
}
