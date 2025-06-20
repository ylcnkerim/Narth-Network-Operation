namespace Narth
{
    partial class Ability
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
            listBox1 = new ListBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.Black;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.ForeColor = Color.Maroon;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(5, 309);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(683, 197);
            listBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 292);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 1;
            label1.Text = "Console";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(17, 172);
            button1.Name = "button1";
            button1.Size = new Size(205, 65);
            button1.TabIndex = 2;
            button1.Text = "Performance Mode (Demo)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(460, 61);
            button2.Name = "button2";
            button2.Size = new Size(205, 65);
            button2.TabIndex = 3;
            button2.Text = "Security Mode (Coming Soon)";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(460, 172);
            button3.Name = "button3";
            button3.Size = new Size(205, 65);
            button3.TabIndex = 4;
            button3.Text = "Disk Cleaner";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(17, 61);
            button4.Name = "button4";
            button4.Size = new Size(205, 65);
            button4.TabIndex = 5;
            button4.Text = "Safe Net (Coming Soon)";
            button4.UseVisualStyleBackColor = true;
            // 
            // Ability
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(693, 511);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(listBox1);
            ForeColor = Color.Maroon;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Ability";
            Text = "Ability";
            MouseDown += Ability_MouseDown;
            MouseMove += Ability_MouseMove;
            MouseUp += Ability_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}