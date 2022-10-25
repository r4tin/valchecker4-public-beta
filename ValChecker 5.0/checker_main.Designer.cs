namespace ValChecker_5._0
{
    partial class checker_main
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.logpasstext = new System.Windows.Forms.TextBox();
            this.proxytext = new System.Windows.Forms.TextBox();
            this.validtext = new System.Windows.Forms.TextBox();
            this.validnum = new System.Windows.Forms.TextBox();
            this.threadstext = new System.Windows.Forms.TextBox();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.threadstext);
            this.guna2Panel1.Controls.Add(this.validnum);
            this.guna2Panel1.Controls.Add(this.validtext);
            this.guna2Panel1.Controls.Add(this.proxytext);
            this.guna2Panel1.Controls.Add(this.logpasstext);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.guna2Panel1.Location = new System.Drawing.Point(588, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(200, 268);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // logpasstext
            // 
            this.logpasstext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.logpasstext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logpasstext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logpasstext.ForeColor = System.Drawing.Color.White;
            this.logpasstext.Location = new System.Drawing.Point(18, 13);
            this.logpasstext.Name = "logpasstext";
            this.logpasstext.ReadOnly = true;
            this.logpasstext.Size = new System.Drawing.Size(100, 15);
            this.logpasstext.TabIndex = 0;
            this.logpasstext.Text = "Combo: 0";
            this.logpasstext.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // proxytext
            // 
            this.proxytext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.proxytext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.proxytext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proxytext.ForeColor = System.Drawing.Color.White;
            this.proxytext.Location = new System.Drawing.Point(18, 34);
            this.proxytext.Name = "proxytext";
            this.proxytext.ReadOnly = true;
            this.proxytext.Size = new System.Drawing.Size(100, 15);
            this.proxytext.TabIndex = 1;
            this.proxytext.Text = "Proxy: 0";
            this.proxytext.TextChanged += new System.EventHandler(this.proxytext_TextChanged);
            // 
            // validtext
            // 
            this.validtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.validtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.validtext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validtext.ForeColor = System.Drawing.Color.White;
            this.validtext.Location = new System.Drawing.Point(18, 85);
            this.validtext.Name = "validtext";
            this.validtext.ReadOnly = true;
            this.validtext.Size = new System.Drawing.Size(34, 15);
            this.validtext.TabIndex = 2;
            this.validtext.Text = "Valid:";
            this.validtext.TextChanged += new System.EventHandler(this.validtext_TextChanged);
            // 
            // validnum
            // 
            this.validnum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.validnum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.validnum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validnum.ForeColor = System.Drawing.Color.Lime;
            this.validnum.Location = new System.Drawing.Point(58, 85);
            this.validnum.Name = "validnum";
            this.validnum.ReadOnly = true;
            this.validnum.Size = new System.Drawing.Size(42, 15);
            this.validnum.TabIndex = 3;
            this.validnum.Text = "0";
            this.validnum.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // threadstext
            // 
            this.threadstext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.threadstext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.threadstext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threadstext.ForeColor = System.Drawing.Color.White;
            this.threadstext.Location = new System.Drawing.Point(18, 55);
            this.threadstext.Name = "threadstext";
            this.threadstext.ReadOnly = true;
            this.threadstext.Size = new System.Drawing.Size(100, 15);
            this.threadstext.TabIndex = 4;
            this.threadstext.Text = "Threads: 0";
            this.threadstext.TextChanged += new System.EventHandler(this.threadstext_TextChanged);
            // 
            // checker_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "checker_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ValChecker 5.0 by liljaba1337";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.TextBox logpasstext;
        public System.Windows.Forms.TextBox validtext;
        public System.Windows.Forms.TextBox proxytext;
        public System.Windows.Forms.TextBox validnum;
        public System.Windows.Forms.TextBox threadstext;
    }
}