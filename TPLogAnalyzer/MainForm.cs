using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            // DoWork will be called when user call BackgroundWorker.RunWorkerAsync()
            bwProgress.DoWork += new DoWorkEventHandler(startTransfer_DoWork);
            // ProgressChanged will be caled when user call BackgroundWorker.ReportProgress
            bwProgress.ProgressChanged += new ProgressChangedEventHandler(transfer_ProgressChanged);

            bwProgress.RunWorkerCompleted += new RunWorkerCompletedEventHandler(transferComplete_WorkerCompleted);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btStsChoosePath_Click(object sender, EventArgs e)
        {
            if (ofdStsLog.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in ofdStsLog.FileNames)
                {
                    tbStsPath.Text += item + @"; ";
                }
                if (!bwProgress.IsBusy)
                {
                    toolStripStatusLabel.Text = "Waiting Transfer!   ";
                    toolStripProgressBar.Value = 0;
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
                if (!bwProgress.IsBusy)
                {
                    toolStripStatusLabel.Text = "Waiting Transfer!   ";
                    toolStripProgressBar.Value = 0;
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
                if (tbStsPath.Text == "")
                {
                    MessageBox.Show(string.Format("Please choose sts Log file first."), "Error");
                    return;
                }

                if (bwProgress.IsBusy)
                {
                    MessageBox.Show("In Processing. wait!", "Error");
                    return;
                }
                toolStripProgressBar.Maximum = ofdStsLog.FileNames.Length;
                // RunWorkerAsync will call backgroundWroker's DoWork
                bwProgress.RunWorkerAsync(enumLogType.stsLogType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btDevStartTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbDevPath.Text == "")
                {
                    MessageBox.Show(string.Format("Please choose dev Log file first."), "Error");
                    return;
                }

                if (bwProgress.IsBusy)
                {
                    MessageBox.Show("In Processing. wait!", "Error");
                    return;
                }
                toolStripProgressBar.Maximum = ofdDevLog.FileNames.Length;
                // RunWorkerAsync will call backgroundWroker's DoWork
                bwProgress.RunWorkerAsync(enumLogType.DevLogType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw;
            }
        }

        // backgroundWorker start tranfer.
        public void startTransfer_DoWork(object sender, DoWorkEventArgs e)
        {
            var logType = (enumLogType)e.Argument;
            int index = 1;
            if (logType == enumLogType.stsLogType)
            {
                IExcelWriter writer = new StsExcelWriter();
                foreach (var fullFilePath in ofdStsLog.FileNames)
                {
                    if (fullFilePath.ToLower().Contains("sts"))
                    {

                        // todo. move logReader to IOC
                        ILogReader lr = new LogFileReader(fullFilePath);
                        List<List<string>> stsTextList = new List<List<string>>();
                        var textTotalLines = lr.LogRead(ref stsTextList);

                        writer.excelWrite(ref stsTextList, fullFilePath);
                        bwProgress.ReportProgress(index, string.Format("{0} of {1}", index, ofdStsLog.FileNames.Length));
                        index++;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Please choose sts Log.\n{0}", fullFilePath), "Error");
                    }
                }
            }
            else if(logType == enumLogType.DevLogType)
            {
                IExcelWriter writer = new DevExcelWriter();
                foreach (var fullFilePath in ofdDevLog.FileNames)
                {
                    if (fullFilePath.ToLower().Contains("dev"))
                    {
                        // todo. move logReader to IOC
                        ILogReader lr = new LogFileReader(fullFilePath);
                        List<List<string>> devTextList = new List<List<string>>();
                        var textTotalLines = lr.LogRead(ref devTextList);

                        writer.excelWrite(ref devTextList, fullFilePath);
                        bwProgress.ReportProgress(index, string.Format("{0} of {1}", index, ofdDevLog.FileNames.Length));
                        index++;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Please choose dev Log.\n{0}", fullFilePath), "Error");
                    }
                }
            }
        }

        private void transfer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
            toolStripStatusLabel.Text = "Process " + (string)e.UserState + " Done!";
        }

        private void transferComplete_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel.Text = "Done!               ";
            toolStripProgressBar.Value = 0;
            MessageBox.Show("Transfer Done!", "Info");
        }

        private void modifyConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@".\TPLogAnalyzer Config.xml");
        }

    }
}
