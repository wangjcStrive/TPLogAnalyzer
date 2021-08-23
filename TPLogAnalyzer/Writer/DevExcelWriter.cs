using Autofac;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using TPLogAnalyzer.Config;

namespace TPLogAnalyzer.Writer
{
    /// <summary>
    /// dev log example:
    ///     2021/07/20| 14:08:03.404| [14dc]| HR: 0x00000000| TYPE: USR STATUS| MSG: Reading configuration data base| LINE: 000025| FILE: Q:\NT Probe\5240\OP5240MeasurementStation\TWMECallback.cpp
    /// </summary>
    class DevExcelWriter : IExcelWriter
    {
        public DevExcelWriter()
        {
            m_workbook = new XSSFWorkbook();

            m_configKeywordCount = new Dictionary<string, int>();
            foreach (var item in IOC.Container.ResolveNamed<IAnalyzerConfigReader>("DevConfig").ConfigList)
            {
                m_configKeywordCount.Add(item.KeyWord, 0);
            }
        }

        public int excelWrite(ref List<List<string>> logList, string logFileFullPath)
        {
            int totalLines = 0;
            int index1 = logFileFullPath.LastIndexOf('\\');
            int index2 = logFileFullPath.LastIndexOf('.');
            string filePath = logFileFullPath.Substring(0, logFileFullPath.LastIndexOf('\\'));
            string sheetName = logFileFullPath.Substring(index1 + 1, index2 - index1 - 1);

            try
            {
                ISheet devSheet = m_workbook.CreateSheet(sheetName);
                devSheet.SetColumnWidth(0, 10 * 256);
                devSheet.SetColumnWidth(1, 12 * 256);
                devSheet.SetColumnWidth(2, 6 * 256);
                devSheet.SetColumnWidth(3, 6 * 256);
                devSheet.SetColumnWidth(4, 6 * 256);
                devSheet.SetColumnWidth(5, 90 * 256);
                devSheet.SetColumnWidth(6, 12 * 256);
                devSheet.SetColumnWidth(7, 90 * 256);

                int devRowCount = 0;
                int lineNumberInDevLogFile = 0;


                foreach (List<string> row in logList)
                {
                    lineNumberInDevLogFile++;
                    IRow excelRow = devSheet.CreateRow(devRowCount++);
                    totalLines++;
                    int len = row.Count;
                    // todo. if length not right, you can't highlight it even if it is in config.xml
                    if (len != LogColumns.devColumns)
                    {
                        string errLine = null;
                        foreach (string column in row)
                        {
                            errLine += column + " ";
                        }
                        //also save to dev sheet
                        excelRow.CreateCell(LogColumns.devTextColumnIndex).SetCellValue(errLine);
                    }
                    else
                    {
                        excelRow.CreateCell(0).SetCellValue(row[0]);
                        excelRow.CreateCell(1).SetCellValue(row[1].Trim(new char[1] { ' ' }));
                        excelRow.CreateCell(2).SetCellValue(row[2].Trim(new char[1] { ' ' }));
                        //excelRow.CreateCell(2).SetCellValue(row[2].TrimStart('[').TrimEnd(']'));
                        excelRow.CreateCell(3).SetCellValue(row[3].Trim(new char[1] { ' ' }));
                        excelRow.CreateCell(4).SetCellValue(row[4].Trim(new char[1] { ' ' }));
                        excelRow.CreateCell(5).SetCellValue(row[5]);
                        excelRow.CreateCell(6).SetCellValue(row[6].Trim(new char[1] { ' ' }));
                        excelRow.CreateCell(7).SetCellValue(row[7].Trim(new char[1] { ' ' }));

                        foreach (var item in IOC.Container.ResolveNamed<IAnalyzerConfigReader>("DevConfig").ConfigList)
                        {
                            // todo. use regex
                            if (row[LogColumns.devTextColumnIndex].ToLower().Contains(item.KeyWord.ToLower()))
                            {
                                IName cellName = devSheet.Workbook.CreateName();
                                cellName.NameName = item.KeyWord.Replace(' ', '_') + "___" + m_configKeywordCount[item.KeyWord];
                                cellName.RefersToFormula = string.Format("'{0}'!$A${1}:$D${2}", sheetName, excelRow.RowNum + 1, excelRow.RowNum + 1);
                                m_configKeywordCount[item.KeyWord] += 1;

                                ICellStyle cellStyle = m_workbook.CreateCellStyle();
                                IFont cellFont = m_workbook.CreateFont();
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
                using (FileStream fs = File.Open(filePath + "\\DevLog.xlsx", FileMode.OpenOrCreate))
                {
                    m_workbook.Write(fs);
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
        IWorkbook m_workbook;
        Dictionary<string, int> m_configKeywordCount;
        #endregion
    }
}
