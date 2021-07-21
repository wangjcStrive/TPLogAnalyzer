using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLogAnalyzer
{
    interface ILogReader
    {
        void LogRead(ref List<List<string>> arrList);
    }
}
