using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLogAnalyzer.Writer
{
    interface IExcelWriter
    {
        void excelWrite(ref List<List<string>> logList);

        string FileName { get; set; }
        string FilePath { get; set; }
    }
    public struct LogColumns
    {
        public static uint stsColumns = 4;
        public static uint devColumns = 8;
    }
}
