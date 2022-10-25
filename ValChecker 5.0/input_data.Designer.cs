namespace ValChecker_5._0
{
    partial class input_data
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
            this.loadcombo = new System.Windows.Forms.Button();
            this.loadproxy = new System.Windows.Forms.Button();
            this.combotext = new System.Windows.Forms.TextBox();
            this.proxytext = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.threadscount = new System.Windows.Forms.TextBox();
            this.startchecker = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // loadcombo
            // 
            this.loadcombo.BackColor = System.Drawing.Color.Gray;
            this.loadcombo.Location = new System.Drawing.Point(21, 21);
            this.loadcombo.Name = "loadcombo";
            this.loadcombo.Size = new System.Drawing.Size(176, 49);
            this.loadcombo.TabIndex = 0;
            this.loadcombo.Text = "Load Combo";
            this.loadcombo.UseVisualStyleBackColor = false;
            this.loadcombo.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadproxy
            // 
            this.loadproxy.BackColor = System.Drawing.Color.Gray;
            this.loadproxy.Location = new System.Drawing.Point(21, 76);
            this.loadproxy.Name = "loadproxy";
            this.loadproxy.Size = new System.Drawing.Size(176, 49);
            this.loadproxy.TabIndex = 1;
            this.loadproxy.Text = "Load Proxy";
            this.loadproxy.UseVisualStyleBackColor = false;
            this.loadproxy.Click += new System.EventHandler(this.loadproxy_Click);
            // 
            // combotext
            // 
            this.combotext.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.combotext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.combotext.ForeColor = System.Drawing.SystemColors.Menu;
            this.combotext.Location = new System.Drawing.Point(238, 39);
            this.combotext.Name = "combotext";
            this.combotext.Size = new System.Drawing.Size(202, 15);
            this.combotext.TabIndex = 2;
            this.combotext.Text = "Loaded 0 Logpasses";
            this.combotext.TextChanged += new System.EventHandler(this.combotext_TextChanged);
            // 
            // proxytext
            // 
            this.proxytext.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.proxytext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.proxytext.ForeColor = System.Drawing.SystemColors.Menu;
            this.proxytext.Location = new System.Drawing.Point(238, 91);
            this.proxytext.Name = "proxytext";
            this.proxytext.Size = new System.Drawing.Size(202, 15);
            this.proxytext.TabIndex = 3;
            this.proxytext.Text = "Loaded 0 Proxy";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(21, 194);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(484, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Tag = "";
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // threadscount
            // 
            this.threadscount.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.threadscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.threadscount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.threadscount.ForeColor = System.Drawing.SystemColors.Menu;
            this.threadscount.Location = new System.Drawing.Point(205, 161);
            this.threadscount.Name = "threadscount";
            this.threadscount.Size = new System.Drawing.Size(106, 27);
            this.threadscount.TabIndex = 5;
            this.threadscount.Text = "1 Threads";
            this.threadscount.TextChanged += new System.EventHandler(this.threadscount_TextChanged);
            // 
            // startchecker
            // 
            this.startchecker.BackColor = System.Drawing.Color.Gray;
            this.startchecker.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.startchecker.Location = new System.Drawing.Point(73, 257);
            this.startchecker.Name = "startchecker";
            this.startchecker.Size = new System.Drawing.Size(367, 83);
            this.startchecker.TabIndex = 6;
            this.startchecker.Text = "Start Checker";
            this.startchecker.UseVisualStyleBackColor = false;
            this.startchecker.Click += new System.EventHandler(this.startchecker_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(517, 369);
            this.Controls.Add(this.startchecker);
            this.Controls.Add(this.threadscount);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.proxytext);
            this.Controls.Add(this.combotext);
            this.Controls.Add(this.loadproxy);
            this.Controls.Add(this.loadcombo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ValChecker 5.0 by liljaba1337";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadcombo;
        private System.Windows.Forms.Button loadproxy;
        private System.Windows.Forms.TextBox combotext;
        private System.Windows.Forms.TextBox proxytext;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox threadscount;
        private System.Windows.Forms.Button startchecker;
    }
}

