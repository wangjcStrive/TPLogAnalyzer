using Autofac;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using TPLogAnalyzer.Config;

namespace TPLogAnalyzer.Writer
{
    class StsExcelWriter : IExcelWriter
    {
        public StsExcelWriter(string filePath)
        {
            int lastBackSlantIndex = filePath.LastIndexOf('\\');
            m_fileName = filePath.Substring(lastBackSlantIndex + 1);
            m_filePath = filePath.Substring(0, lastBackSlantIndex);
        }

        public int excelWrite(ref List<List<string>> logList)
        {
            int totalLines = 0;
            try
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet stsSheet = workbook.CreateSheet("StsLog");
                stsSheet.SetColumnWidth(0, 10 * 256);
                stsSheet.SetColumnWidth(1, 12 * 256);
                stsSheet.SetColumnWidth(2, 8 * 256);
                stsSheet.SetColumnWidth(3, 90 * 256);

                int exceptionCount = 0;
                int stsRowCount = 0;
                int lineNumberInStsLogFile = 0;
                foreach (List<string> row in logList)
                {
                    lineNumberInStsLogFile++;
                    IRow excelRow = stsSheet.CreateRow(stsRowCount++);
                    totalLines++;
                    int len = row.Count;
                    if (len != LogColumns.stsColumns)
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
                        exceptionRow.CreateCell(1).SetCellValue(lineNumberInStsLogFile.ToString());

                        //also save to sts sheet
                        excelRow.CreateCell(LogColumns.stsTextColumnIndex).SetCellValue(errLine);
                    }
                    else
                    {
                        excelRow.CreateCell(0).SetCellValue(row[0]);
                        excelRow.CreateCell(1).SetCellValue(row[1].Trim(new char[1] { ' ' }));
                        excelRow.CreateCell(2).SetCellValue(row[2].Trim(new char[1] { ' ' }));
                        //excelRow.CreateCell(2).SetCellValue(row[2].TrimStart('[').TrimEnd(']'));
                        excelRow.CreateCell(3).SetCellValue(row[3]);

                        IAnalyzerConfigReader stsConfig = IOC.Container.ResolveNamed<IAnalyzerConfigReader>("StsConfig");
                        foreach (var item in stsConfig.ConfigList)
                        {
                            // todo. use regex
                            if (row[LogColumns.stsTextColumnIndex].ToLower().Contains(item.KeyWord.ToLower()))
                            {
                                ICellStyle cellStyle = workbook.CreateCellStyle();
                                IFont cellFont = workbook.CreateFont();
                                cellFont.Color = ConfigColorMap.ColorMapDic[item.FontColor];
                                cellFont.IsBold = item.FontBold;
                                cellFont.FontHeightInPoints = item.FontSize;
                                cellStyle.SetFont(cellFont);
                                cellStyle.FillBackgroundColor = ConfigColorMap.ColorMapDic[item.BackgroundColor];
                                excelRow.GetCell(LogColumns.stsTextColumnIndex).CellStyle = cellStyle;
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

            return totalLines;
        }


        #region Members
        private string m_filePath;
        private string m_fileName;

        public string FilePath { get => m_filePath; set => m_filePath = value; }
        public string FileName { get => m_fileName; set => m_fileName = value; }
        #endregion
    }
}
