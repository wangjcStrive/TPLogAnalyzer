using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLogAnalyzer.LogReader
{
    interface ILogReader
    {
        void LogRead(ref List<List<string>> arrList);
    }
}
