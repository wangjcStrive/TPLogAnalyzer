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
        public StsExcelWriter()
        {
            m_workbook = new XSSFWorkbook();

            m_configKeywordCount = new Dictionary<string, int>();
            foreach (var item in IOC.Container.ResolveNamed<IAnalyzerConfigReader>("StsConfig").ConfigList)
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
                ISheet stsSheet = m_workbook.CreateSheet(sheetName);
                stsSheet.SetColumnWidth(0, 10 * 256);
                stsSheet.SetColumnWidth(1, 12 * 256);
                stsSheet.SetColumnWidth(2, 8 * 256);
                stsSheet.SetColumnWidth(3, 90 * 256);

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
                        excelRow.CreateCell(LogColumns.stsTextColumnIndex).SetCellValue(errLine);
                    }
                    else
                    {
                        excelRow.CreateCell(0).SetCellValue(row[0]);
                        excelRow.CreateCell(1).SetCellValue(row[1].Trim(new char[1] { ' ' }));
                        excelRow.CreateCell(2).SetCellValue(row[2].Trim(new char[1] { ' ' }));
                        //excelRow.CreateCell(2).SetCellValue(row[2].TrimStart('[').TrimEnd(']'));
                        excelRow.CreateCell(3).SetCellValue(row[3]);

                        foreach (var item in IOC.Container.ResolveNamed<IAnalyzerConfigReader>("StsConfig").ConfigList)
                        {
                            // todo. use regex
                            if (row[LogColumns.stsTextColumnIndex].ToLower().Contains(item.KeyWord.ToLower()))
                            {
                                IName cellName = stsSheet.Workbook.CreateName();
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
                                excelRow.GetCell(LogColumns.stsTextColumnIndex).CellStyle = cellStyle;
                            }
                        }
                    }
                }

                using (FileStream fs = File.Open(filePath + "\\StsLog.xlsx", FileMode.OpenOrCreate))
                {
                    m_workbook.Write(fs);
                    //m_workbook.Close();
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
