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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(checker_main));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.logpasstext = new System.Windows.Forms.TextBox();
            this.proxytext = new System.Windows.Forms.TextBox();
            this.validtext = new System.Windows.Forms.TextBox();
            this.validnum = new System.Windows.Forms.TextBox();
            this.threadstext = new System.Windows.Forms.TextBox();
            this.bantext = new System.Windows.Forms.TextBox();
            this.bannednum = new System.Windows.Forms.TextBox();
            this.tempbantext = new System.Windows.Forms.TextBox();
            this.tempbannum = new System.Windows.Forms.TextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.errcount = new System.Windows.Forms.TextBox();
            this.rlimitsnum = new System.Windows.Forms.TextBox();
            this.errtext = new System.Windows.Forms.TextBox();
            this.rlimitstext = new System.Windows.Forms.TextBox();
            this.testtest = new System.Windows.Forms.TextBox();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // logpasstext
            // 
            this.logpasstext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.logpasstext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logpasstext.Cursor = System.Windows.Forms.Cursors.Arrow;
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
            this.proxytext.Cursor = System.Windows.Forms.Cursors.Arrow;
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
            this.validtext.Cursor = System.Windows.Forms.Cursors.Arrow;
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
            this.validnum.Cursor = System.Windows.Forms.Cursors.Arrow;
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
            this.threadstext.Cursor = System.Windows.Forms.Cursors.Arrow;
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
            // bantext
            // 
            this.bantext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.bantext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bantext.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bantext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bantext.ForeColor = System.Drawing.Color.White;
            this.bantext.Location = new System.Drawing.Point(18, 106);
            this.bantext.Name = "bantext";
            this.bantext.ReadOnly = true;
            this.bantext.Size = new System.Drawing.Size(52, 15);
            this.bantext.TabIndex = 5;
            this.bantext.Text = "Banned: ";
            this.bantext.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // bannednum
            // 
            this.bannednum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.bannednum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bannednum.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bannednum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bannednum.ForeColor = System.Drawing.Color.Red;
            this.bannednum.Location = new System.Drawing.Point(76, 106);
            this.bannednum.Name = "bannednum";
            this.bannednum.ReadOnly = true;
            this.bannednum.Size = new System.Drawing.Size(42, 15);
            this.bannednum.TabIndex = 6;
            this.bannednum.Text = "0";
            this.bannednum.TextChanged += new System.EventHandler(this.textBox1_TextChanged_2);
            // 
            // tempbantext
            // 
            this.tempbantext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.tempbantext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tempbantext.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tempbantext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempbantext.ForeColor = System.Drawing.Color.White;
            this.tempbantext.Location = new System.Drawing.Point(18, 127);
            this.tempbantext.Name = "tempbantext";
            this.tempbantext.ReadOnly = true;
            this.tempbantext.Size = new System.Drawing.Size(82, 15);
            this.tempbantext.TabIndex = 7;
            this.tempbantext.Text = "TempBanned: ";
            this.tempbantext.TextChanged += new System.EventHandler(this.tempbantext_TextChanged);
            // 
            // tempbannum
            // 
            this.tempbannum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.tempbannum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tempbannum.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tempbannum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempbannum.ForeColor = System.Drawing.Color.Orange;
            this.tempbannum.Location = new System.Drawing.Point(106, 127);
            this.tempbannum.Name = "tempbannum";
            this.tempbannum.ReadOnly = true;
            this.tempbannum.Size = new System.Drawing.Size(42, 15);
            this.tempbannum.TabIndex = 8;
            this.tempbannum.Text = "0";
            this.tempbannum.TextChanged += new System.EventHandler(this.tempbannum_TextChanged);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Panel1.Controls.Add(this.errcount);
            this.guna2Panel1.Controls.Add(this.rlimitsnum);
            this.guna2Panel1.Controls.Add(this.errtext);
            this.guna2Panel1.Controls.Add(this.rlimitstext);
            this.guna2Panel1.Controls.Add(this.tempbannum);
            this.guna2Panel1.Controls.Add(this.tempbantext);
            this.guna2Panel1.Controls.Add(this.bannednum);
            this.guna2Panel1.Controls.Add(this.bantext);
            this.guna2Panel1.Controls.Add(this.threadstext);
            this.guna2Panel1.Controls.Add(this.validnum);
            this.guna2Panel1.Controls.Add(this.validtext);
            this.guna2Panel1.Controls.Add(this.proxytext);
            this.guna2Panel1.Controls.Add(this.logpasstext);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.guna2Panel1.Location = new System.Drawing.Point(588, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(200, 359);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // errcount
            // 
            this.errcount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.errcount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errcount.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.errcount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errcount.ForeColor = System.Drawing.Color.OrangeRed;
            this.errcount.Location = new System.Drawing.Point(58, 180);
            this.errcount.Name = "errcount";
            this.errcount.ReadOnly = true;
            this.errcount.Size = new System.Drawing.Size(42, 15);
            this.errcount.TabIndex = 5;
            this.errcount.Text = "0";
            // 
            // rlimitsnum
            // 
            this.rlimitsnum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.rlimitsnum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rlimitsnum.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rlimitsnum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlimitsnum.ForeColor = System.Drawing.Color.OrangeRed;
            this.rlimitsnum.Location = new System.Drawing.Point(86, 159);
            this.rlimitsnum.Name = "rlimitsnum";
            this.rlimitsnum.ReadOnly = true;
            this.rlimitsnum.Size = new System.Drawing.Size(42, 15);
            this.rlimitsnum.TabIndex = 10;
            this.rlimitsnum.Text = "0";
            // 
            // errtext
            // 
            this.errtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.errtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errtext.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.errtext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errtext.ForeColor = System.Drawing.Color.White;
            this.errtext.Location = new System.Drawing.Point(18, 180);
            this.errtext.Name = "errtext";
            this.errtext.ReadOnly = true;
            this.errtext.Size = new System.Drawing.Size(34, 15);
            this.errtext.TabIndex = 4;
            this.errtext.Text = "Errors:";
            // 
            // rlimitstext
            // 
            this.rlimitstext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.rlimitstext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rlimitstext.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rlimitstext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlimitstext.ForeColor = System.Drawing.Color.White;
            this.rlimitstext.Location = new System.Drawing.Point(18, 159);
            this.rlimitstext.Name = "rlimitstext";
            this.rlimitstext.ReadOnly = true;
            this.rlimitstext.Size = new System.Drawing.Size(62, 15);
            this.rlimitstext.TabIndex = 9;
            this.rlimitstext.Text = "Rate Limits:";
            // 
            // testtest
            // 
            this.testtest.Location = new System.Drawing.Point(23, 20);
            this.testtest.Name = "testtest";
            this.testtest.Size = new System.Drawing.Size(559, 20);
            this.testtest.TabIndex = 1;
            this.testtest.TextChanged += new System.EventHandler(this.textBox1_TextChanged_3);
            // 
            // checker_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(793, 446);
            this.Controls.Add(this.testtest);
            this.Controls.Add(this.guna2Panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "checker_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ValChecker 5.0 by liljaba1337";
            this.Load += new System.EventHandler(this.checker_main_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        public System.Windows.Forms.TextBox tempbannum;
        public System.Windows.Forms.TextBox logpasstext;
        public System.Windows.Forms.TextBox tempbantext;
        public System.Windows.Forms.TextBox proxytext;
        public System.Windows.Forms.TextBox bannednum;
        public System.Windows.Forms.TextBox validtext;
        public System.Windows.Forms.TextBox bantext;
        public System.Windows.Forms.TextBox validnum;
        public System.Windows.Forms.TextBox threadstext;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.TextBox rlimitsnum;
        public System.Windows.Forms.TextBox rlimitstext;
        public System.Windows.Forms.TextBox errcount;
        public System.Windows.Forms.TextBox errtext;
        public System.Windows.Forms.TextBox testtest;
    }
}