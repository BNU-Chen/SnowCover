using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data;
using System.IO;
using Microsoft.Office.Interop;
using Excel=Microsoft.Office.Interop.Excel;

namespace SystemBase
{
    public class ExcelHandler
    {
        public static void DataTable_To_Excel(DataTable dtTable, string PathFileName)
        {
            try
            {
                
                var excel = new Microsoft.Office.Interop.Excel.Application { Visible = false };
                var misValue = System.Reflection.Missing.Value;
                var wb = excel.Workbooks.Add(misValue);
                //var wb = excel.Workbooks.Open(PathFileName);
                Microsoft.Office.Interop.Excel.Worksheet sh = wb.Sheets.Add();
                sh.Name = "STACOUNTY";
                sh.Cells[1, "A"].Value2 = "SCODE";
                sh.Cells[1, "B"].Value2 = "SCOUNT";
                sh.Cells[1, "C"].Value2 = "SSUM";
                sh.Cells[1, "D"].Value2 = "SPERCENT";
                sh.Cells[1, "E"].Value2 = "SDATE";

                /* Insert Rows */
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    sh.Cells[i + 2, "A"].Value2 = dtTable.Rows[i][0]; // EmployeeNumber
                    sh.Cells[i + 2, "B"].Value2 += dtTable.Rows[i][1]; // Time From
                    sh.Cells[i + 2, "C"].Value2 += dtTable.Rows[i][2]; // Time To
                    sh.Cells[i + 2, "D"].Value2 += dtTable.Rows[i][3]; // Holiday
                    sh.Cells[i + 2, "E"].Value2 += dtTable.Rows[i][4]; // Rest Day
                }

                wb.SaveAs(PathFileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                wb.Close(true);
                excel.Quit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool SuperToExcel(System.Data.DataTable excelTable, string filePath)
        {
            Excel.Application app =new Excel.Application();
            try
            {
                app.Visible = false;
                Excel.Workbook wBook = app.Workbooks.Add(true);
                Excel.Worksheet wSheet = wBook.Worksheets[1] as Excel.Worksheet;
                Excel.Range range;
                int colIndex = 0;
                int rowIndex = 0;
                int colCount = excelTable.Columns.Count;
                int rowCount = excelTable.Rows.Count;

                //创建缓存数据  
                object[,] objData = new object[rowCount + 1, colCount];

                //写标题  
                int size = excelTable.Columns.Count;
                for (int i = 0; i < size; i++)
                {
                    wSheet.Cells[1, 1 + i] = excelTable.Columns[i].Caption;
                }
                range = (Excel.Range)wSheet.get_Range(app.Cells[1, 1], app.Cells[1, colCount]);
                range.Interior.ColorIndex = 15;//背景色 灰色  
                range.Font.Bold = true;//粗字体  
                //获取实际数据  

                for (rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (colIndex = 0; colIndex < colCount; colIndex++)
                    {
                        objData[rowIndex, colIndex] = excelTable.Rows[rowIndex][colIndex].ToString();
                    }
                }


                //写入Excel   
                range = wSheet.get_Range(app.Cells[2, 1], app.Cells[rowCount + 1, colCount]) as Excel.Range;
                range.NumberFormatLocal = "@";//设置数字文本格式  
                range.Value2 = objData;
                //Application.DoEvents();  

                wSheet.Columns.AutoFit();

                //设置禁止弹出保存和覆盖的询问提示框   
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = false;

                wBook.Saved = true;
                wBook.SaveCopyAs(filePath);

                app.Quit();
                app = null;
                GC.Collect();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            finally
            {
            }
        }

        public static void ExpotToExcel3(DataTable table, string file)
        {

            string title = "";

            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);

            //FileStream fs1 = File.Open(file, FileMode.Open, FileAccess.Read);

            StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);

            for (int i = 0; i < table.Columns.Count; i++)
            {

                title += table.Columns[i].ColumnName + "\t"; //栏位：自动跳到下一单元格

            }

            title = title.Substring(0, title.Length - 1) + "\n";

            sw.Write(title);

            foreach (DataRow row in table.Rows)
            {

                string line = "";

                for (int i = 0; i < table.Columns.Count; i++)
                {

                    line += row[i].ToString().Trim() + "\t"; //内容：自动跳到下一单元格

                }

                line = line.Substring(0, line.Length - 1) + "\n";

                sw.Write(line);

            }

            sw.Close();

            fs.Close();

        }

        public static void DataTableToCSV(System.Data.DataTable table, string path)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = table.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in table.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(path, sb.ToString());
        }
    }
}
