namespace Narth
{
    partial class Monitor
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label2 = new Label();
            listBox3 = new ListBox();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Maroon;
            label1.Location = new Point(27, 333);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "Ports";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.network;
            pictureBox1.Location = new Point(508, 333);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 175);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.Black;
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.ForeColor = Color.Maroon;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(94, 146);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(596, 120);
            listBox1.TabIndex = 2;
            // 
            // listBox2
            // 
            listBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBox2.BackColor = Color.Black;
            listBox2.BorderStyle = BorderStyle.None;
            listBox2.ForeColor = Color.Maroon;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(94, 285);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(408, 150);
            listBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(4, 194);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 4;
            label2.Text = "Route Position";
            // 
            // listBox3
            // 
            listBox3.BackColor = Color.Black;
            listBox3.BorderStyle = BorderStyle.None;
            listBox3.ForeColor = Color.Maroon;
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 15;
            listBox3.Location = new Point(93, 9);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(597, 120);
            listBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Maroon;
            label3.Location = new Point(4, 38);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 6;
            label3.Text = "Network Users";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(4, 443);
            button1.Name = "button1";
            button1.Size = new Size(237, 63);
            button1.TabIndex = 7;
            button1.Text = "Start Test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(531, 277);
            label4.Name = "label4";
            label4.Size = new Size(139, 15);
            label4.TabIndex = 8;
            label4.Text = "8.8.8.8 IP Listening: -- ms";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(524, 301);
            label5.Name = "label5";
            label5.Size = new Size(154, 15);
            label5.TabIndex = 9;
            label5.Text = "Sent = 4 : 0 Recieved, () Lost";
            // 
            // Monitor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(693, 511);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(listBox3);
            Controls.Add(label2);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            ForeColor = Color.Maroon;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Monitor";
            Text = "Monitor";
            Load += Monitor_Load;
            MouseDown += Monitor_MouseDown;
            MouseMove += Monitor_MouseMove;
            MouseUp += Monitor_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label label2;
        private ListBox listBox3;
        private Label label3;
        private Button button1;
        private Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Label label5;
    }
}