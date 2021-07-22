using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace TPLogAnalyzer
{
    class ExcelWriter : IExcelWriter
    {
        public ExcelWriter(string filePath)
        {
            int lastBackSlantIndex = filePath.LastIndexOf('\\');
            m_fileName = filePath.Substring(lastBackSlantIndex + 1);
            m_filePath = filePath.Substring(0, lastBackSlantIndex);
        }

        public void excelWrite(ref List<List<string>> logList)
        {
            try
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet stsSheet = workbook.CreateSheet("StsLog");
                stsSheet.SetColumnWidth(0, 12 * 256);
                stsSheet.SetColumnWidth(1, 15 * 256);
                stsSheet.SetColumnWidth(2, 8 * 256);
                stsSheet.SetColumnWidth(3, 90 * 256);

                int exceptionCount = 0;
                int stsRowCount = 0;
                foreach (List<string> row in logList)
                {
                    int len = row.Count;
                    if (len != 4)
                    {
                        string errLine = null;
                        foreach (string column in row)
                        {
                            errLine += column + " ";
                        }
                        ISheet exceptionSheet = workbook.GetSheet("abnormal");
                        if (exceptionSheet == null)
                        {
                            exceptionSheet = workbook.CreateSheet("abnormal");
                            exceptionSheet.SetColumnWidth(1, 100 * 256);
                        }
                        IRow excelRow = exceptionSheet.CreateRow(exceptionCount++);
                        ICell excelCell = excelRow.CreateCell(0);
                        continue;
                    }
                    else
                    {
                        IRow excelRow = stsSheet.CreateRow(stsRowCount++);
                        excelRow.CreateCell(0).SetCellValue(row[0]);
                        excelRow.CreateCell(1).SetCellValue(row[1]);
                        excelRow.CreateCell(2).SetCellValue(row[2]);
                        excelRow.CreateCell(3).SetCellValue(row[3]);

                        if (row[3].Contains("Tool START UP"))
                        {
                            ICellStyle startupCellStyle = workbook.CreateCellStyle();
                            IFont startupFont = workbook.CreateFont();
                            startupFont.Color = IndexedColors.Orange.Index;
                            startupFont.IsBold = false;
                            startupCellStyle.SetFont(startupFont);
                            excelRow.GetCell(3).CellStyle = startupCellStyle;
                        }
                    }
                }

                using (FileStream fs = File.Open(m_filePath + @"\StsLog.xlsx", FileMode.OpenOrCreate))
                {
                    workbook.Write(fs);
                    workbook.Close();
                    fs.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region Members
        private string m_filePath;
        private string m_fileName;
        #endregion
    }
}
