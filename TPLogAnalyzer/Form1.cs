using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPLogAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // todo. select multi files
        private void btStsChoosePath_Click(object sender, EventArgs e)
        {
            if (ofdStsLog.ShowDialog() == DialogResult.OK)
            {
                tbStsPath.Text = System.IO.Path.GetFullPath(ofdStsLog.FileName);
            }
            else
            {
                // todo. exception
            }
        }

        private void btDevChoosePath_Click(object sender, EventArgs e)
        {
            if (ofdDevLog.ShowDialog() == DialogResult.OK)
            {
                tbStsPath.Text = System.IO.Path.GetFullPath(ofdDevLog.FileName);
            }
            else
            {
                // todo. exception
            }
        }

        private void btStartTransfer_Click(object sender, EventArgs e)
        {
            if (tbStsPath.TextLength > 0)
            {
                ILogReader lr = new StsLogFileReader(tbStsPath.Text);
                List<List<string>> stsTextList = new List<List<string>>();
                lr.LogRead(ref stsTextList);
            }
        }
    }
}
