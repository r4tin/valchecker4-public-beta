namespace valchecker_4._0_private_beta
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            bannedlabel = new Label();
            validlabel = new Label();
            checkedlabel = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(bannedlabel);
            panel1.Controls.Add(validlabel);
            panel1.Controls.Add(checkedlabel);
            panel1.Location = new Point(24, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 171);
            panel1.TabIndex = 0;
            // 
            // bannedlabel
            // 
            bannedlabel.AutoSize = true;
            bannedlabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            bannedlabel.ForeColor = Color.Maroon;
            bannedlabel.Location = new Point(16, 69);
            bannedlabel.Name = "bannedlabel";
            bannedlabel.Size = new Size(69, 17);
            bannedlabel.TabIndex = 2;
            bannedlabel.Text = "Banned: 0";
            // 
            // validlabel
            // 
            validlabel.AutoSize = true;
            validlabel.BackColor = SystemColors.ControlDark;
            validlabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            validlabel.ForeColor = Color.DarkGreen;
            validlabel.Location = new Point(16, 42);
            validlabel.Name = "validlabel";
            validlabel.Size = new Size(54, 17);
            validlabel.TabIndex = 1;
            validlabel.Text = "Valid: 0";
            validlabel.Click += validlabel_Click;
            // 
            // checkedlabel
            // 
            checkedlabel.AutoSize = true;
            checkedlabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            checkedlabel.Location = new Point(16, 13);
            checkedlabel.Name = "checkedlabel";
            checkedlabel.Size = new Size(87, 17);
            checkedlabel.TabIndex = 0;
            checkedlabel.Text = "Checked: 0/0";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(554, 93);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(325, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(570, 147);
            button1.Name = "button1";
            button1.Size = new Size(188, 50);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 445);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "ValChecker v4.0 beta";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        public Label checkedlabel;
        public Label bannedlabel;
        public Label validlabel;
        private TextBox textBox1;
        private Button button1;
    }
}