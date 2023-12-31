using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace valchecker_4._0_private_beta
{
    public partial class Form1 : Form
    {
        bool IsDown;
        Point PrevMousePosition;
        public int CornerRadius { get; set; } = 10;
        private Dictionary<string, Label> labelsDictionary = new Dictionary<string, Label>();
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0.95;
            //test.firststart();
            var rauth = new RiotClient();
            var acc = rauth.AuthAsync("gwclapzz:Woodbridge11");
            //Console.WriteLine(acc.Result);
            //Console.ReadKey();
            //this.DoubleBuffered = true;

            TextChangeHandler.TextChangeEvent += OnTextChangeRequested;

            labelsDictionary.Add("cpmlbl", cpmlbl);

            labelsDictionary.Add("checkedlabel", checkedlabel);

            labelsDictionary.Add("validlabel", validlabel);
            labelsDictionary.Add("bannedlabel", bannedlabel);
            labelsDictionary.Add("tempbannedlbl", tempbannedlbl);

            labelsDictionary.Add("wskinslbl", wskinslbl);
            labelsDictionary.Add("falbl", falbl);

            labelsDictionary.Add("errlbl", errlbl);
            labelsDictionary.Add("retrieslbl", retrieslbl);

            labelsDictionary.Add("eulbl", eulbl);
            labelsDictionary.Add("nalbl", nalbl);
            labelsDictionary.Add("aplbl", aplbl);
            labelsDictionary.Add("krlbl", krlbl);
            labelsDictionary.Add("brlbl", brlbl);
            labelsDictionary.Add("latamlbl", latamlbl);

            labelsDictionary.Add("unlbl", unlbl);
            labelsDictionary.Add("irlbl", irlbl);
            labelsDictionary.Add("brolbl", brolbl);
            labelsDictionary.Add("silbl", silbl);
            labelsDictionary.Add("golbl", golbl);
            labelsDictionary.Add("pllbl", pllbl);
            labelsDictionary.Add("dilbl", dilbl);
            labelsDictionary.Add("imlbl", imlbl);
            labelsDictionary.Add("ralbl", ralbl);
            labelsDictionary.Add("lolbl", lolbl);

            labelsDictionary.Add("onetotenlbl", onetotenlbl);
            labelsDictionary.Add("tentotwentylbl", tentotwentylbl);
            labelsDictionary.Add("twentytofortyfivelbl", twentytofortyfivelbl);
            labelsDictionary.Add("fortyfivetosixtyfivelbl", fortyfivetosixtyfivelbl);
            labelsDictionary.Add("sixtyfivetoahundredlbl", sixtyfivetoahundredlbl);
            labelsDictionary.Add("ahundredpluslbl", ahundredpluslbl);
        }

        private void validlabel_Click(object sender, EventArgs e)
        {

        }
        private void OnTextChangeRequested(object sender, TextChangeEventArgs e)
        {
            if (labelsDictionary.TryGetValue(e.Labelname, out Label label))
            {
                label.Text = e.NewText;
                if (label == checkedlabel)
                {
                    progressBar1.Value = Convert.ToInt32(label.Text.Split(" ")[1].Split("/")[0]);
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            loadaccbtn.Enabled = false;
            loadproxybtn.Enabled = false;
            startcheckingbtn.Enabled = false;
            //trackBar1.Enabled = false;
            morethreadscb.Enabled = false;
            await mainProgram.Main();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            threadslbl.Text = $"THREADS: {trackBar1.Value}";
            vars.threadsam = trackBar1.Value;
            if (trackBar1.Value == 50 && !morethreadscb.Enabled)
            {
                trackBar1.Value = 50;
                morethreadscb.Visible = true;
                morethreadscb.Enabled = true;
            }
            else if (trackBar1.Value == 1000 && !imretardedcb.Enabled)
            {
                trackBar1.Value = 1000;
                imretardedcb.Visible = true;
                imretardedcb.Enabled = true;
            }
        }

        private void morethreadscb_CheckedChanged(object sender, EventArgs e)
        {
            if (morethreadscb.Checked)
            {
                trackBar1.Maximum = 1000;
            }
            else
            {
                trackBar1.Maximum = 50;
                trackBar1.Value = 25;
                threadslbl.Text = $"THREADS: {trackBar1.Value}";
            }
        }

        private void loadaccbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Title = "Select a file with your combolist (login:password)";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                using (StreamReader sr = new StreamReader(selectedFilePath))
                {
                    vars.combolist = sr.ReadToEnd().Split("\n").ToList();
                }
                linesloadedlbl.Text = $"Lines loaded: {vars.combolist.Count}";
                progressBar1.Maximum = vars.combolist.Count;
            }
        }

        private void loadproxybtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Title = "Select a file with your proxylist (ip:port)";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                using (StreamReader sr = new StreamReader(selectedFilePath))
                {
                    vars.proxylist = sr.ReadToEnd().Split("\n").ToList();
                }
                proxyloadedlbl.Text = $"Proxy loaded: {vars.proxylist.Count}";
            }
        }

        private void imretardedcb_CheckedChanged(object sender, EventArgs e)
        {
            if (imretardedcb.Checked)
            {
                trackBar1.Maximum = 1000000;
            }
            else
            {
                trackBar1.Maximum = 50;
                trackBar1.Value = 25;
                threadslbl.Text = $"THREADS: {trackBar1.Value}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void discordbtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://discord.gg/DYfCsZG5UX");
        }

        private void ghbtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/LIL-JABA/");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            IsDown = true;
            PrevMousePosition = MousePosition;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            IsDown = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                Point CurrentMousePosition = MousePosition;
                this.Location = new Point(this.Location.X + (CurrentMousePosition.X - PrevMousePosition.X), this.Location.Y + (CurrentMousePosition.Y - PrevMousePosition.Y));
                PrevMousePosition = CurrentMousePosition;
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public static class vars
    {
        public static List<string> combolist = new List<string>();
        public static List<string> proxylist = new List<string>();
        public static int threadsam = 1;
    }
}