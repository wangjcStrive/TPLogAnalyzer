using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TPLogAnalyzer.LogReader;

namespace TPLogAnalyzer
{
    class LogFileReader : ILogReader
    {
        public LogFileReader(string logFileName)
        {
            m_logFilePath = logFileName;
        }

        public int LogRead(ref List<List<string>> arrList)
        {
            int totalLines = 0;
            try
            {
                StreamReader sreader = new StreamReader(LogFilePath, Encoding.Default);
                string line;
                while ((line = sreader.ReadLine()) != null)
                {
                    totalLines++;
                    arrList.Add(line.Split('|').ToList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return totalLines;
        }

        #region members
        private string m_logFilePath;
        public string LogFilePath { get => m_logFilePath; set => m_logFilePath = value; }
        #endregion
    }
}
