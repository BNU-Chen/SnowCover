using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

using MySql.Data.MySqlClient;

namespace SnowCover
{
    public partial class frmSetStaMapDate : Form
    {
        private IMapControl2 mapControl = null;
        private AxTOCControl tocControl = null;
        private DateTime date = DateTime.Now;
        private SystemBase.SystemConfig config = null;
        private MySqlConnection mysqlConn = null;
        

        public frmSetStaMapDate(AxMapControl _axMapControl,AxTOCControl _tocCtrl)
        {
            InitializeComponent();
            mapControl = (IMapControl2)_axMapControl.Object;
            tocControl = _tocCtrl;
            config = new SystemBase.SystemConfig();
            mysqlConn = config.GetMySQLConnection();        //获取数据库连接
        }
        private void frmSetStaMapDate_Load(object sender, EventArgs e)
        {
            this.dateNavigator1.DateTime = config.LastHandleDate;    //初始化时实用上次的日期
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            this.Hide();
            date = this.dateNavigator1.DateTime;
            config.LastHandleDate = date;
            string dateStr = date.ToString("yyyy-MM-dd");
            DataTable snowDataTable = getDataFromDatabase(dateStr);
            if (snowDataTable == null || snowDataTable.Rows.Count == 0)
            {
                MessageBox.Show("未获取到[" + dateStr + "]的数据，请重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Show();
                return;
            }
            string excelPath = config.CountyMapJoinTablePath;
            SystemBase.ExcelHandler.DataTableToCSV(snowDataTable, excelPath);
            mapControl.Map.Name = dateStr;
            mapControl.ActiveView.Refresh();
            tocControl.Refresh();
            tocControl.Update();
            //tocControl.ProductName
            this.Close();
        }

        private void bnt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        //从数据库获取数据
        private DataTable getDataFromDatabase(string  dateStr)
        {
            DataTable table = new DataTable();
            try
            {
                string sqlStr = "SELECT	sn.Code as scode,sn.COUNT AS scount,sn.SUM as ssum,sn.SUM/sn.COUNT*100 AS spercent,sn.Date AS sdate "
                    + "FROM snowcover_statisticbyboundary AS sn "
                    + "WHERE sn.Date LIKE '%" + dateStr + "%' "
                    + "ORDER BY sn.Code";
                table = SystemBase.MySQL.Select(sqlStr, mysqlConn);
                if (table.Rows.Count == 0)
                {
                    return table;
                }
                table.TableName = "stacounty";
                //foreach (DataRow row in snowDataTable.Rows)
                //{
                //    SnowData sd = new SnowData();
                //    sd.code = (string)row[0];
                //    sd.count = (int)row[1];
                //    sd.sum = (int)row[2];
                //    sd.date = dateStr;

                //    snowDataKeyMap.Add(sd.code, sd);
                //}                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return table;
        }

        //修改图层属性的值
        private void EditRendererLayerAttr(ILayer layer, Dictionary<string, SnowData> snowDataKeyMap)
        {
            //IFeatureLayer pFTLayer = layer as IFeatureLayer;
            ////IFeatureClass pFTClass = pFTLayer.Search                ITable pTable = pFTClass as ITable;
            //IQueryFilter queryFilter = new QueryFilterClass();
            //queryFilter.WhereClause = "Code <> ''";
            //IFeatureCursor pFTCursor = pFTLayer.Search(queryFilter, false);
            ////pCursor = pTable.Search(null, false);
            ////IRow row = pFTCursor.NextRow();
            //IFeature feature = pFTCursor.NextFeature();

            IFeatureLayer pFTLayer = layer as IFeatureLayer;
            ITable pTbale = pFTLayer as ITable;
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = "Code <> ''";
            ICursor pFTCursor = pTbale.Search(queryFilter, false);
            IRow row = pFTCursor.NextRow();            

            try
            {
                int codeIndex = row.Fields.FindField("Code");
                int countIndex = row.Fields.FindField("count");
                int sumIndex = row.Fields.FindField("sum");
                int dateIndex = row.Fields.FindField("date");
                int percentIndex = row.Fields.FindField("percent");
                int countFT = 0;
                while (row != null)
                {
                    string code = (string)row.get_Value(codeIndex);
                    SnowData sn = null;
                    snowDataKeyMap.TryGetValue(code, out sn);
                    if (sn == null)
                    {
                        continue;
                    }
                    if (countIndex > 0)
                    {
                        row.set_Value(countIndex, sn.count);
                    }
                    if (sumIndex > 0)
                    {
                        row.set_Value(sumIndex, sn.sum);
                    }
                    if (dateIndex > 0)
                    {
                        row.set_Value(dateIndex, sn.date);
                    }
                    double percent = 0.0;
                    if (sn.sum != 0 && sn.count != 0)
                    {
                        percent = sn.sum * 1.00 / sn.count * 100;
                    }
                    if (percentIndex > 0)
                    {
                        row.set_Value(percentIndex, percent);
                    }
                    row.Store();
                    row = pFTCursor.NextRow();
                    countFT++;
                }
                System.Diagnostics.Debug.Write("Count:"+countFT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                System.GC.Collect();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFTCursor);
            }
        }

        private void ExportDataToExcel(DataTable dt,string excelPath)
        {
            try
            {
                StreamWriter wr = new StreamWriter(excelPath);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                }

                wr.WriteLine();

                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    //go to next line
                    wr.WriteLine();
                }
                //close file
                wr.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dateNavigator1_EditDateModified(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            string dateSt = date.ToString("yyyy-MM-dd");

            string sqlStr = "SELECT  DISTINCT sn.Date "
            + "FROM snowcover_statisticbyboundary AS sn "
            + "WHERE sn.Date = '" + dateSt + "'";
            DataTable table = SystemBase.MySQL.Select(sqlStr, mysqlConn);
            string labelText = "否";
            if (table.Rows.Count > 0)
            {
                labelText = "是";
            }
            this.lbl_HasStaData.Text = labelText;
        }


    }
}
