using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

using MySql.Data.MySqlClient;

namespace SnowCover
{
    public partial class frmSetStaMapDate : Form
    {
        private IMapControl2 mapControl = null;
        private DateTime date = DateTime.Now;
        private SystemBase.SystemConfig config = null;
        private MySqlConnection mysqlConn = null;
        

        public frmSetStaMapDate(AxMapControl _axMapControl)
        {
            InitializeComponent();
            mapControl = (IMapControl2)_axMapControl.Object;
            config = new SystemBase.SystemConfig();
            mysqlConn = config.GetMySQLConnection();        //获取数据库连接
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmProgressBar frmPB = new frmProgressBar();
            frmPB.Show();
            date = this.dateNavigator1.DateTime;
            string dateStr = date.ToString("yyyy-MM-dd");
            Dictionary<string, SnowData> snowStaDataKeyMap = getDataFromDatabase(dateStr);
            if (snowStaDataKeyMap == null||snowStaDataKeyMap.Count==0)
            {
                frmPB.Close();
                MessageBox.Show("未获取到[" + dateStr + "]的数据，请重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Show();
                return;
            }
            ILayer layer = mapControl.Map.get_Layer(0);
            EditRendererLayerAttr(layer, snowStaDataKeyMap);
            frmPB.Close();
            mapControl.ActiveView.Refresh();
            this.Close();
        }

        private void bnt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        //从数据库获取数据
        private Dictionary<string, SnowData> getDataFromDatabase(string  dateStr)
        {
            Dictionary<string, SnowData> snowDataKeyMap = new Dictionary<string, SnowData>();
            try
            {
                string sqlStr = "SELECT	sn.Code as snCode,sn.COUNT AS snCount,sn.SUM as snSum "
                    + "FROM snowcover_statisticbyboundary AS sn "
                    + "WHERE sn.Date LIKE '%" + dateStr + "%' "
                    + "ORDER BY sn.Code";
                DataTable dt = SystemBase.MySQL.Select(sqlStr, mysqlConn);
                if (dt.Rows.Count == 0)
                {
                    return snowDataKeyMap;
                }
                foreach (DataRow row in dt.Rows)
                {
                    SnowData sd = new SnowData();
                    sd.code = (string)row[0];
                    sd.count = (int)row[1];
                    sd.sum = (int)row[2];
                    sd.date = dateStr;

                    snowDataKeyMap.Add(sd.code, sd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return snowDataKeyMap;
        }

        //修改图层属性的值
        private void EditRendererLayerAttr(ILayer layer, Dictionary<string, SnowData> snowDataKeyMap)
        {
            try
            {
                IFeatureLayer pFTLayer = layer as IFeatureLayer;
                //IFeatureClass pFTClass = pFTLayer.Search                ITable pTable = pFTClass as ITable;
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = "Code <> ''";
                IFeatureCursor pFTCursor = pFTLayer.Search(queryFilter, false);
                //pCursor = pTable.Search(null, false);
                //IRow row = pFTCursor.NextRow();
                IFeature feature = pFTCursor.NextFeature();
                int codeIndex = feature.Fields.FindField("Code");
                int countIndex = feature.Fields.FindField("count");
                int sumIndex = feature.Fields.FindField("sum");
                int dateIndex = feature.Fields.FindField("date");
                int percentIndex = feature.Fields.FindField("percent");

                while (feature != null)
                {
                    string code = (string)feature.get_Value(codeIndex);
                    SnowData sn = snowDataKeyMap[code];
                    if (countIndex > 0)
                    {
                        feature.set_Value(countIndex, sn.count);
                    }
                    if (sumIndex > 0)
                    {
                        feature.set_Value(sumIndex, sn.sum);
                    }
                    if (dateIndex > 0)
                    {
                        feature.set_Value(dateIndex, sn.date);
                    }
                    double percent = 0.0;
                    if (sn.sum != 0 && sn.count != 0)
                    {
                        percent = sn.sum * 1.00 / sn.count * 100;
                    }
                    if (percentIndex > 0)
                    {
                        feature.set_Value(percentIndex, percent);
                    }
                    feature.Store();
                    feature = pFTCursor.NextFeature();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
    public class SnowData
    {
        public string code;
        public int count;
        public int sum;
        public string date;
    }
}
