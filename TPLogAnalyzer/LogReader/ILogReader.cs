using System.Collections.Generic;

namespace TPLogAnalyzer.LogReader
{
    interface ILogReader
    {
        int LogRead(ref List<List<string>> arrList);
    }
}
