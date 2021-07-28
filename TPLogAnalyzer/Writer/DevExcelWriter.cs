using Autofac;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPLogAnalyzer.Config;

namespace TPLogAnalyzer.Writer
{
    /// <summary>
    /// dev log example:
    ///     2021/07/20| 14:08:03.404| [14dc]| HR: 0x00000000| TYPE: USR STATUS| MSG: Reading configuration data base| LINE: 000025| FILE: Q:\NT Probe\5240\OP5240MeasurementStation\TWMECallback.cpp
    /// </summary>
    class DevExcelWriter : IExcelWriter
    {
        public DevExcelWriter(string filePath)
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
                ISheet devSheet = workbook.CreateSheet("DevLog");
                devSheet.SetColumnWidth(0, 10 * 256);
                devSheet.SetColumnWidth(1, 12 * 256);
                devSheet.SetColumnWidth(2, 6 * 256);
                devSheet.SetColumnWidth(3, 6 * 256);
                devSheet.SetColumnWidth(4, 6 * 256);
                devSheet.SetColumnWidth(5, 90 * 256);
                devSheet.SetColumnWidth(6, 12 * 256);
                devSheet.SetColumnWidth(7, 90 * 256);

                int exceptionCount = 0;
                int devRowCount = 0;
                int lineNumberInDevLogFile = 0;
                foreach (List<string> row in logList)
                {
                    lineNumberInDevLogFile++;
                    IRow excelRow = devSheet.CreateRow(devRowCount++);
                    int len = row.Count;
                    if (len != LogColumns.devColumns)
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
                            exceptionSheet.SetColumnWidth(0, 100 * 256);
                            exceptionSheet.SetColumnWidth(1, 10 * 256);
                        }
                        IRow exceptionRow = exceptionSheet.CreateRow(exceptionCount++);
                        exceptionRow.CreateCell(0).SetCellValue(errLine);
                        exceptionRow.CreateCell(1).SetCellValue(lineNumberInDevLogFile.ToString());

                        //also save to dev sheet
                        excelRow.CreateCell(LogColumns.devTextColumnIndex).SetCellValue(errLine);
                    }
                    else
                    {
                        excelRow.CreateCell(0).SetCellValue(row[0]);
                        excelRow.CreateCell(1).SetCellValue(row[1].Trim(new char[1] { ' '}));
                        excelRow.CreateCell(2).SetCellValue(row[2].Trim(new char[1] { ' ' }));
                        //excelRow.CreateCell(2).SetCellValue(row[2].TrimStart('[').TrimEnd(']'));
                        excelRow.CreateCell(3).SetCellValue(row[3].Trim(new char[1] { ' ' }));
                        excelRow.CreateCell(4).SetCellValue(row[4].Trim(new char[1] { ' ' }));
                        excelRow.CreateCell(5).SetCellValue(row[5]);
                        excelRow.CreateCell(6).SetCellValue(row[6].Trim(new char[1] { ' ' }));
                        excelRow.CreateCell(7).SetCellValue(row[7].Trim(new char[1] { ' ' }));

                        IAnalyzerConfigReader devConfig = IOC.Container.ResolveNamed<IAnalyzerConfigReader>("DevConfig");
                        foreach (var item in devConfig.ConfigList)
                        {
                            // todo. use regex
                            if (row[LogColumns.devTextColumnIndex].ToLower().Contains(item.KeyWord.ToLower()))
                            {
                                ICellStyle cellStyle = workbook.CreateCellStyle();
                                IFont cellFont = workbook.CreateFont();
                                cellFont.Color = ConfigColorMap.ColorMapDic[item.FontColor];
                                cellFont.IsBold = item.FontBold;
                                cellFont.FontHeightInPoints = item.FontSize;
                                cellStyle.SetFont(cellFont);
                                cellStyle.FillBackgroundColor = ConfigColorMap.ColorMapDic[item.BackgroundColor];
                                excelRow.GetCell(LogColumns.devTextColumnIndex).CellStyle = cellStyle;
                            }
                        }
                    }
                }

                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                using (FileStream fs = File.Open(FilePath + @"\" + FileName.Substring(0, FileName.IndexOf(@".txt")) + "  --  " + dateTime + ".xlsx", FileMode.OpenOrCreate))
                {
                    workbook.Write(fs);
                    workbook.Close();
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #region Members
        private string m_filePath;
        private string m_fileName;

        public string FilePath { get => m_filePath; set => m_filePath = value; }
        public string FileName { get => m_fileName; set => m_fileName = value; }
        #endregion
    }
}
