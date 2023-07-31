using System;
using System.Windows.Forms;

namespace valchecker_4._0_private_beta
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Label> labelsDictionary = new Dictionary<string, Label>();
        public Form1()
        {
            InitializeComponent();
            TextChangeHandler.TextChangeEvent += OnTextChangeRequested;

            labelsDictionary.Add("validlabel", validlabel);
            labelsDictionary.Add("bannedlabel", bannedlabel);
            labelsDictionary.Add("checkedlabel", checkedlabel);
        }

        private void validlabel_Click(object sender, EventArgs e)
        {

        }
        private void OnTextChangeRequested(object sender, TextChangeEventArgs e)
        {
            if (labelsDictionary.TryGetValue(e.Labelname, out Label label))
            {
                label.Text = e.NewText;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await mainProgram.Main(textBox1.Text);
        }
    }
}