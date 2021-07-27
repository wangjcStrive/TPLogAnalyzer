using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using TPLogAnalyzer.LogReader;

namespace TPLogAnalyzer
{
    class LogFileReader : ILogReader
    {
        public LogFileReader(string logFileName)
        {
            m_logFilePath = logFileName;
        }

        public void LogRead(ref List<List<string>> arrList)
        {
            try
            {
                StreamReader sreader = new StreamReader(LogFilePath, Encoding.Default);
                string line;
                while ((line = sreader.ReadLine()) != null)
                {
                    arrList.Add(line.Split('|').ToList());
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        #region members
        private string m_logFilePath;
        public string LogFilePath { get => m_logFilePath; set => m_logFilePath = value; }
        #endregion
    }
}
