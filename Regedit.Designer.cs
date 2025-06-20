namespace Narth
{
    partial class Regedit
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
            button1 = new Button();
            listBox1 = new ListBox();
            label1 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Maroon;
            button1.Location = new Point(214, 185);
            button1.Name = "button1";
            button1.Size = new Size(254, 61);
            button1.TabIndex = 0;
            button1.Text = "RUN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.Black;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.ForeColor = Color.Maroon;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(6, 311);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(680, 197);
            listBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 293);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 7;
            label1.Text = "Console";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(197, 95);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(98, 19);
            radioButton1.TabIndex = 8;
            radioButton1.TabStop = true;
            radioButton1.Text = "Add  Regedits";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(394, 95);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(110, 19);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "Regedit cleanup";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(335, 97);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 10;
            label2.Text = "or";
            // 
            // Regedit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(693, 511);
            Controls.Add(label2);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            ForeColor = Color.Maroon;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Regedit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Regedit";
            MouseDown += Regedit_MouseDown;
            MouseMove += Regedit_MouseMove;
            MouseUp += Regedit_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private Label label1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label2;
    }
}