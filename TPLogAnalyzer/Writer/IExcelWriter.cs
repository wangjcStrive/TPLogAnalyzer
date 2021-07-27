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
    }
}
