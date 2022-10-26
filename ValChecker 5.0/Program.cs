using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValChecker_5._0
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new input_data());
        }


    }

    public class checker
    {
        string proxyfile;
        string combofile;
        int threadscount;
        int valid = 0;
        int banned = 0;
        string bgimage;
        public checker(string _proxyfile, string _combofile, int _threadscount, string _bgfile)
        {
            proxyfile = _proxyfile;
            combofile = _combofile;
            threadscount = _threadscount;
            bgimage = _bgfile;

            if (proxyfile == null)
            {
                MessageBox.Show("You haven't chosen the proxy file. The program will stop", "holy shit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            if (combofile == null)
            {
                MessageBox.Show("You haven't chosen the combo file. The program will stop", "holy shit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
        }
        public void Main()
        {
            checker_main chm = new checker_main();
            chm.Show();

            if (bgimage != null)
            {
                Image myimage = new Bitmap(bgimage);
                chm.BackgroundImage = myimage;
            }

            // get combos
            string[] accounts = System.IO.File.ReadAllLines(combofile);
            chm.logpasstext.Text = $"Combo: {accounts.Length}";

            //get proxy
            string[] proxies = System.IO.File.ReadAllLines(proxyfile);
            chm.proxytext.Text = $"Proxy: {proxies.Length}";

            //set threads
            chm.threadstext.Text = $"Threads: {threadscount}";

            string aa = auth.Main("Abdullah6129:k16006113050","123");
            chm.testtest.Text = aa;

        }
    }
}
