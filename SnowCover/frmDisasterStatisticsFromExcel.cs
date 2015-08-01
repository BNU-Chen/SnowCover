using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Data.OleDb;

namespace SnowCover
{
    public partial class frmDisasterStatisticsFromExcel : Form
    {
        private DataTable gridViewDataSource = new DataTable();

        public frmDisasterStatisticsFromExcel()
        {
            InitializeComponent();
            gridViewDataSource.Columns.Add("区县名称", typeof(string));
            gridViewDataSource.Columns.Add("行政编码", typeof(string));
            gridViewDataSource.Columns.Add("灾害类型", typeof(string));
            gridViewDataSource.Columns.Add("上报日期", typeof(string));
            this.dataGridView1.DataSource = gridViewDataSource;
            AutoChangeColumnWidthByGridViewWidth();
        }
        //根据GridView宽度改变列宽
        private void AutoChangeColumnWidthByGridViewWidth()
        {
            int gridWidth = this.dataGridView1.Width;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = gridWidth / dataGridView1.Columns.Count;
            }
        }

        private void btn_SetFloderPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string _folderPath = dialog.SelectedPath;
                if (Directory.Exists(_folderPath) == true)
                {
                    txt_FloderPath.Text = _folderPath;
                }
                else
                {
                    MessageBox.Show("所选择路径不存在。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btn_BeginStatistic_Click(object sender, EventArgs e)
        {
            gridViewDataSource.Clear();
            List<string> xlsFiles_Path = new List<string>();
            string floderPath = txt_FloderPath.Text;
            if (Directory.Exists(floderPath) == false)
            {
                MessageBox.Show("所选择路径不存在。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string[] files = Directory.GetFiles(floderPath);//得到文件
            foreach (string file in files)//循环文件,得到指定格式文件列表
            {
                string exname = Path.GetExtension(file);//得到后缀名
                string _fileName = Path.GetFileNameWithoutExtension(file);//得到文件名，无后缀
                string[] ss = _fileName.Split(new char[] { '_' });
                if (exname == ".xls" || exname == ".xlsx")//如果后缀名为.txt文件
                {
                    xlsFiles_Path.Add(file);
                    DataTable dt = ExcelToDataTable(file, "灾情指标");
                    for (int i = 2; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][1].ToString().Substring(4, 2) != "00")
                        {
                            DataRow dr = gridViewDataSource.NewRow();
                            dr["区县名称"] = dt.Rows[i][0].ToString();
                            dr["行政编码"] = dt.Rows[i][1].ToString();
                            dr["灾害类型"] = ss[0];
                            dr["上报日期"] = ss[1];
                            gridViewDataSource.Rows.Add(dr);
                        }
                    }
                    
                }
            }
            this.dataGridView1.Refresh();
        }
        
        private void btn_OutPutResult_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveAsExcel = new SaveFileDialog();
            saveAsExcel.Title = "保存为：";
            saveAsExcel.Filter = "Excel文件|*.xls;";
            if (saveAsExcel.ShowDialog() == DialogResult.OK)
            {
                if (saveAsExcel.FileName != "")
                {
                    if (File.Exists(saveAsExcel.FileName)) File.Delete(saveAsExcel.FileName);
                    dataTableToCsv(gridViewDataSource, saveAsExcel.FileName);
                }
            }
        }

        //Excel灾害文件统计
        public static DataTable ExcelToDataTable(string filePath, string _sheetName)
        {
            string connStr = "";
            string fileType = System.IO.Path.GetExtension(filePath);
            if (string.IsNullOrEmpty(fileType)) return null;

            if (fileType == ".xls")
                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            else
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            string sql_F = "Select * FROM [{0}]";

            OleDbConnection conn = null;
            OleDbDataAdapter da = null;
            DataTable dtSheetName = null;

            DataTable dt = null;
            try
            {
                // 初始化连接，并打开
                conn = new OleDbConnection(connStr);
                conn.Open();

                // 获取数据源的表定义元数据                        
                string SheetName = "";
                dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                // 初始化适配器
                da = new OleDbDataAdapter();
                for (int i = 0; i < dtSheetName.Rows.Count; i++)
                {
                    SheetName = dtSheetName.Rows[i]["TABLE_NAME"].ToString();
                    string checkSheet = SheetName.Replace("$", "");
                    if (String.Equals(checkSheet, _sheetName))
                    {
                        da.SelectCommand = new OleDbCommand(String.Format(sql_F, SheetName), conn);
                        DataSet dsItem = new DataSet();
                        da.Fill(dsItem, _sheetName);
                        dt = dsItem.Tables[0].Copy();
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                // 关闭连接
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    da.Dispose();
                    conn.Dispose();
                }
            }
            return dt;
        }
        
        //输出Excel
        private void dataTableToCsv(DataTable table, string file)
        {
            string title = "";

            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);

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

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            AutoChangeColumnWidthByGridViewWidth();
        }
    }
}
