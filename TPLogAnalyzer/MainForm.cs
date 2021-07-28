﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                MessageBox.Show("File Choose Fail", "Error");
            }
        }

        private void btDevChoosePath_Click(object sender, EventArgs e)
        {
            if (ofdDevLog.ShowDialog() == DialogResult.OK)
            {
                string selectFile = System.IO.Path.GetFullPath(ofdDevLog.FileName);
                if (selectFile.ToLower().Contains("dev"))
                {
                    tbDevPath.Text = selectFile;
                }
                else
                {
                    MessageBox.Show("Please choose DevLog file.", "Error");
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
                if (tbStsPath.TextLength > 0)
                {
                    // todo. move logReader to IOC
                    ILogReader lr = new LogFileReader(tbStsPath.Text);
                    List<List<string>> stsTextList = new List<List<string>>();
                    lr.LogRead(ref stsTextList);

                    IExcelWriter writer = new StsExcelWriter(tbStsPath.Text);
                    writer.excelWrite(ref stsTextList);
                    MessageBox.Show("Transfer Done", "Info");
                }
                else
                {
                    MessageBox.Show("Select File first", "Error");
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
                if (tbDevPath.TextLength > 0)
                {
                    // todo. move logReader to IOC
                    ILogReader lr = new LogFileReader(tbDevPath.Text);
                    List<List<string>> devTextList = new List<List<string>>();
                    lr.LogRead(ref devTextList);

                    IExcelWriter writer = new DevExcelWriter(tbDevPath.Text);
                    writer.excelWrite(ref devTextList);
                    MessageBox.Show("Transfer Done", "Info");
                }
                else
                {
                    MessageBox.Show("Select File first", "Error");
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