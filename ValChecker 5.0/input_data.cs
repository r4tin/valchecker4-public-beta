using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValChecker_5._0
{
    public partial class input_data : Form
    {
        public input_data()
        {
            InitializeComponent();
            combotext.ReadOnly = true;
        }

        protected string proxyfile;
        protected string combofile;
        protected int threadnum;
        string bgfile;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadcombo = new OpenFileDialog();

            loadcombo.InitialDirectory = "c:\\";
            loadcombo.Filter = "Text files (*.txt)|*.txt";
            loadcombo.FilterIndex = 0;
            loadcombo.RestoreDirectory = true;
            loadcombo.Title = "select file with combos (log:pass)";

            if (loadcombo.ShowDialog() == DialogResult.OK)
            {
                string comboFN = loadcombo.FileName;
                combofile = comboFN;
                string[] lines = System.IO.File.ReadAllLines(comboFN);
                combotext.Text = "Loaded "+Convert.ToString(lines.Length)+" Logpasses";
            }
            if (proxyfile != null && proxytext != null)
            {
                //guna2Panel1.Cursor = Cursors.Arrow;
                guna2Panel1.Enabled = false;
                startchecker.Enabled = true;
            }
        }

        private void loadproxy_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadproxy = new OpenFileDialog();

            loadproxy.InitialDirectory = "c:\\";
            loadproxy.Filter = "Text files (*.txt)|*.txt";
            loadproxy.FilterIndex = 0;
            loadproxy.RestoreDirectory = true;
            loadproxy.Title = "select file with proxies";

            if (loadproxy.ShowDialog() == DialogResult.OK)
            {
                string proxyFN = loadproxy.FileName;
                proxyfile = proxyFN;
                string[] lines = System.IO.File.ReadAllLines(proxyFN);
                proxytext.Text = "Loaded " + Convert.ToString(lines.Length) + " Proxies";
            }
            if (proxyfile != null && proxytext != null)
            {
                //guna2Panel1.Cursor = Cursors.Arrow;
                guna2Panel1.Enabled = false;
                startchecker.Enabled = true;
            }
        }

        private void combotext_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int threads = Convert.ToInt32(trackBar1.Value.ToString());
            threadscount.Text=threads+" Threads";
            threadnum = threads;
        }

        private void threadscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void startchecker_Click(object sender, EventArgs e)
        {
            this.Hide();
            checker vlchecker = new checker(proxyfile, combofile, threadnum,bgfile);
            vlchecker.Main();
        }

        //choose bg
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog loadproxy = new OpenFileDialog();

            loadproxy.InitialDirectory = "c:\\";
            loadproxy.Filter = "Text files (*.png; *.jpg)|*.png; *.jpg";
            loadproxy.FilterIndex = 0;
            loadproxy.RestoreDirectory = true;
            loadproxy.Title = "choose ur background file";

            if (loadproxy.ShowDialog() == DialogResult.OK)
            {
                bgfile = loadproxy.FileName;

            }
        }
    }
}
