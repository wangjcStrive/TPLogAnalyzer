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
                string selectFile = System.IO.Path.GetFullPath(ofdStsLog.FileName);
                if (selectFile.ToLower().Contains("sts"))
                {
                    tbStsPath.Text = selectFile;
                }
                else
                {
                    MessageBox.Show("Please choose StsLog file.", "Error");
                }
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

                IExcelWriter writer = new ExcelWriter(tbStsPath.Text);
                writer.excelWrite(ref stsTextList);
            }
            else
            {
                MessageBox.Show("Select File first", "Error");
            }
        }
    }
}
