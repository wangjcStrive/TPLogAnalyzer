using System.Collections.Generic;

namespace TPLogAnalyzer.Writer
{
    interface IExcelWriter
    {
        int excelWrite(ref List<List<string>> logList);

        string FileName { get; set; }
        string FilePath { get; set; }
    }
    public struct LogColumns
    {
        // total column count
        public static uint stsColumns = 4;
        public static uint devColumns = 8;
        //text column index
        public static int stsTextColumnIndex = 3;
        public static int devTextColumnIndex = 5;
    }
}
