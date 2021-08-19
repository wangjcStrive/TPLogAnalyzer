using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TPLogAnalyzer.LogReader;
using TPLogAnalyzer.Writer;

namespace TPLogAnalyzer
{
    enum enumLogType
    {
        stsLogType = 0,
        DevLogType,
        DebugLogType
    }
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // todo. select multi files
        private void btStsChoosePath_Click(object sender, EventArgs e)
        {
            if (ofdStsLog.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in ofdStsLog.FileNames)
                {
                    tbStsPath.Text += item + @"; ";
                }
            }
            else
            {
                MessageBox.Show("File Choose Fail", "Error");
            }
        }

        private void btDevChoosePath_Click(object sender, EventArgs e)
        {
            if (ofdDevLog.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in ofdDevLog.FileNames)
                {
                    tbDevPath.Text += item + @"; ";
                }
            }
            else
            {
                MessageBox.Show("File Choose Fail", "Error");
            }
        }

        private void btStartTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 1;
                foreach (var fullFilePath in ofdStsLog.FileNames)
                {
                    if (fullFilePath.ToLower().Contains("sts"))
                    {
                        // todo. move logReader to IOC
                        ILogReader lr = new LogFileReader(fullFilePath);
                        List<List<string>> stsTextList = new List<List<string>>();
                        var textTotalLines = lr.LogRead(ref stsTextList);

                        IExcelWriter writer = new StsExcelWriter(fullFilePath);
                        var devTotalLine = writer.excelWrite(ref stsTextList);
                        MessageBox.Show(string.Format("Transfer Done {0} of {1} Successfully.\nText Line:  {2}\nExcel Line: {3}", index, ofdStsLog.FileNames.Length, textTotalLines, devTotalLine), "Done");
                        index++;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Please choose sts Log.\n{0}", fullFilePath), "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw;
            }
        }
        private void btDevStartTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 1;
                foreach (var fullFilePath in ofdDevLog.FileNames)
                {
                    if (fullFilePath.ToLower().Contains("dev"))
                    {
                        // todo. move logReader to IOC
                        ILogReader lr = new LogFileReader(fullFilePath);
                        List<List<string>> devTextList = new List<List<string>>();
                        var textTotalLines = lr.LogRead(ref devTextList);

                        IExcelWriter writer = new DevExcelWriter(fullFilePath);
                        var devTotalLine = writer.excelWrite(ref devTextList);
                        MessageBox.Show(string.Format("Transfer Done {0} of {1} Successfully.\nText Line:  {2}\nExcel Line: {3}", index, ofdDevLog.FileNames.Length, textTotalLines, devTotalLine), "Done");
                        index++;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Please choose dev Log.\n{0}", fullFilePath), "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw;
            }
        }

        private void modifyConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@".\TPLogAnalyzer Config.xml");
        }

    }
}
