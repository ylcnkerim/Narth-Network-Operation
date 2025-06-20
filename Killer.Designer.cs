namespace Narth
{
    partial class Killer
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.Black;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.ForeColor = Color.Maroon;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(5, 310);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(682, 197);
            listBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Maroon;
            button1.Location = new Point(236, 32);
            button1.Name = "button1";
            button1.Size = new Size(205, 65);
            button1.TabIndex = 5;
            button1.Text = "Disable Backround Apps";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Maroon;
            button2.Location = new Point(236, 118);
            button2.Name = "button2";
            button2.Size = new Size(205, 65);
            button2.TabIndex = 6;
            button2.Text = "Alleviate (Coming Soon)";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Maroon;
            button3.Location = new Point(236, 203);
            button3.Name = "button3";
            button3.Size = new Size(205, 65);
            button3.TabIndex = 7;
            button3.Text = "Set Services to Manual";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 292);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 8;
            label1.Text = "Console";
            // 
            // Killer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(693, 511);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            ForeColor = Color.Maroon;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Killer";
            Text = "Killer";
            MouseDown += Killer_MouseDown;
            MouseMove += Killer_MouseMove;
            MouseUp += Killer_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
    }
}