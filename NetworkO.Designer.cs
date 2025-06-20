namespace Narth
{
    partial class NetworkO
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
            textBox1 = new TextBox();
            label1 = new Label();
            listBox1 = new ListBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.ForeColor = Color.Gainsboro;
            textBox1.Location = new Point(247, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(187, 25);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Maroon;
            label1.Location = new Point(281, 37);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 1;
            label1.Text = "Enter Your MTU Value";
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.Black;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.ForeColor = Color.Maroon;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(7, 311);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(677, 197);
            listBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(4, 293);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 3;
            label2.Text = "Console";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Maroon;
            button1.Location = new Point(211, 212);
            button1.Name = "button1";
            button1.Size = new Size(256, 65);
            button1.TabIndex = 4;
            button1.Text = "RUN";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Maroon;
            button2.Location = new Point(247, 100);
            button2.Name = "button2";
            button2.Size = new Size(187, 58);
            button2.TabIndex = 5;
            button2.Text = "Check My Optimal MTU Value";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // NetworkO
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(693, 511);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(listBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NetworkO";
            Text = "NetworkO";
            MouseDown += NetworkO_MouseDown;
            MouseMove += NetworkO_MouseMove;
            MouseUp += NetworkO_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private ListBox listBox1;
        private Label label2;
        private Button button1;
        private Button button2;
    }
}