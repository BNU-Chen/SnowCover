using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using MySql.Data.MySqlClient;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.SpatialAnalystTools;
using SystemBase;

namespace SnowCover
{
    public partial class frmSetSnowCoverDateForStatisticByBoundary : Form
    {
        private SystemConfig config = null;
        private AxMapControl axMapControl = null;
        private DateTime startDate;
        private DateTime endDate;
        private bool isBatHandler = false;

        private DateTime datePre = DateTime.Now;   //上一个选择的日期
        static private bool hasClickedNaviBtn = false;     //标识是否点击日期导航栏的按钮


        public frmSetSnowCoverDateForStatisticByBoundary(AxMapControl _AxMapControl)
        {
            InitializeComponent();
            axMapControl = _AxMapControl;
            config = new SystemConfig();
        }

        private void frmSetSnowCoverDateForStatisticByBoundary_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime firstDayOfYear = Convert.ToDateTime(today.Year.ToString()+"-01-01");//DateTime.Now;
            this.dateNavigator1.DateTime = firstDayOfYear;

            //this.dateNavigator1.DateTime = today;
            this.dateNavigator1.TodayButton.Text = "今天";

            //初始为单个处理
            this.Height = 565;
        }

        //确定，开始分析
        private void btn_Submit_Click(object sender, EventArgs e)
        {            
            DateTime date = this.dateNavigator1.DateTime;
            //获取县域边界文件路径
            string CountyBoundary_FileName = config.CountyBoundaryFilePath;

            if (isBatHandler)
            {
                if (startDate == null)
                {
                    MessageBox.Show("请选择批量处理的起始时间。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (endDate == null)
                {
                    MessageBox.Show("请选择批量处理的截止时间。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (startDate > endDate)
                {
                    MessageBox.Show("起始时间大于截止时间，请重新选择。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //临时文件dbf输出路径
                string outputPath = null;
                outputPath = config.DataCenterFolderPath+"\\Temp";
                if (Directory.Exists(outputPath) == false)
                {
                    Directory.CreateDirectory(outputPath);
                }

                string handleSuccessDates = "";
                string handleFailureDates = "";
                for (DateTime dateIndex = startDate; dateIndex <= endDate; )
                {
                    string snowCoverFilePath = getDateFile(dateIndex, config.EverydaySnowCoverFolderPath);
                    bool isDataExist = File.Exists(snowCoverFilePath);
                    if (isDataExist)
                    {
                        handleSuccessDates += GetYearDayStr(dateIndex) + ",";
                        string outputPath_temp = outputPath + "\\D" + GetYearDayStr(dateIndex) + ".dbf";
                        try
                        {
                            StatisticSnowCoverByBoundary(snowCoverFilePath, CountyBoundary_FileName, outputPath_temp);
                            DataTable dt = new DataTable();
                            TDbfTable tdb = new TDbfTable(outputPath_temp);
                            dt = tdb.Table.Copy();
                            dt.TableName = "D" + GetYearDayStr(dateIndex) + "_SC_StByBdy";
                            storeTableToMySQL(dt);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("错误提示:" + ex.Message, "系统出错");
                            if (Directory.Exists(outputPath) == true)
                            {
                                Directory.Delete(outputPath, true);
                            }
                        }
                    }
                    else
                    {
                        handleFailureDates += GetYearDayStr(dateIndex) + ",";
                    }

                    dateIndex = dateIndex.AddDays(1);
                }
                //删除临时文件dbf输出路径
                if (Directory.Exists(outputPath) == true)
                {
                    Directory.Delete(outputPath, true);
                }
                SystemBase.LogFile.Log(this.Text, "处理成功：" + handleSuccessDates);
                SystemBase.LogFile.Log(this.Text, "处理失败：" + handleFailureDates);
                MessageBox.Show("以下数据处理成功：\n" + handleSuccessDates + "\n以下数据处理失败：\n" + handleFailureDates, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                string snowCoverFilePath = getDateFile(date, config.EverydaySnowCoverFolderPath);
                bool isDataExist = File.Exists(snowCoverFilePath);
                if (!isDataExist)
                {
                    MessageBox.Show("选定日期的积雪覆盖数据不存在。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //临时文件dbf输出路径
                string outputPath = null;
                outputPath = config.DataCenterFolderPath + "\\Temp";
                if (Directory.Exists(outputPath) == false)
                {
                    Directory.CreateDirectory(outputPath);
                }
                string outputPath_All = outputPath + "\\D" + GetYearDayStr(date) + ".dbf";

                try
                {
                    StatisticSnowCoverByBoundary(snowCoverFilePath, CountyBoundary_FileName, outputPath_All);
                    DataTable dt = new DataTable();
                    TDbfTable tdb = new TDbfTable(outputPath_All);
                    dt = tdb.Table.Copy();
                    dt.TableName = "D" + GetYearDayStr(date) + "_SC_StByBdy";
                    
                    storeTableToMySQL(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误提示:" + ex.Message, "系统出错");
                    if (Directory.Exists(outputPath) == true)
                    {
                        Directory.Delete(outputPath, true);
                    }
                }
                SystemBase.LogFile.Log(this.Text, "处理成功：" + GetYearDayStr(date));
                //删除临时文件dbf输出路径
                if (Directory.Exists(outputPath) == true)
                {
                    Directory.Delete(outputPath, true);
                }
            }
            this.Close();
        }

        //批量处理设置开关
        private void chkBtn_BatHandler_CheckedChanged(object sender, EventArgs e)
        {
            isBatHandler = !isBatHandler;
            if (isBatHandler)
            {
                this.Height = 625;
            }
            else
            {
                this.Height = 565;
            }
        }
        
        //设置起始日期
        private void btn_SetStartDate_Click(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            int dayOfYear = date.DayOfYear;
            this.lbl_StartDate.Text = date.ToString("yyyy-MM-dd") + " " + date.Year.ToString().Substring(2, 2) + dayOfYear.ToString("D3");

            startDate = date;
        }
        
        //设置结束日期
        private void btn_SetEndDate_Click(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            int dayOfYear = date.DayOfYear;
            this.lbl_EndDate.Text = date.ToString("yyyy-MM-dd") + " " + date.Year.ToString().Substring(2, 2) + dayOfYear.ToString("D3");

            endDate = date;
        }

        //取消
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //分区统计函数
        private void StatisticSnowCoverByBoundary(string _SnowCoverFilePath,string _CountyBoundaryFilePath,string _OutputFilePath)
        {
            this.Hide();
            try
            {
                //构造Geoprocessor  
                Geoprocessor geoprocessor = new Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                //许可设置
                IAoInitialize m_AoInitialize = new AoInitializeClass();
                esriLicenseStatus licenseStatus = esriLicenseStatus.esriLicenseUnavailable;
                //licenseStatus = m_AoInitialize.Initialize(esriLicenseProductCode.esriLicenseProductCodeArcInfo);
                licenseStatus = m_AoInitialize.IsExtensionCodeAvailable(esriLicenseProductCode.esriLicenseProductCodeEngine,
                    esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst);
                licenseStatus = m_AoInitialize.CheckOutExtension(esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst);

                ESRI.ArcGIS.SpatialAnalystTools.ZonalStatisticsAsTable zonalStatisticsAsTable =
                    new ESRI.ArcGIS.SpatialAnalystTools.ZonalStatisticsAsTable();
                zonalStatisticsAsTable.in_zone_data = _CountyBoundaryFilePath;
                zonalStatisticsAsTable.zone_field = "Code";
                zonalStatisticsAsTable.in_value_raster = _SnowCoverFilePath;
                zonalStatisticsAsTable.out_table = _OutputFilePath;
                zonalStatisticsAsTable.statistics_type = "SUM";

                geoprocessor.Execute(zonalStatisticsAsTable, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误提示:" + ex.Message, "系统出错");
            }
        }

        //日期变更事件
        private void dateNavigator1_EditDateModified(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            this.dateNavigator1.HotDate = date;

            //如果点击的是导航按钮
            if (hasClickedNaviBtn)
            {
                hasClickedNaviBtn = false;

                string FebMonth = "-01-01";
                string DecMonth = "-12-31";
                int year = datePre.Year;
                year = DateTime.Compare(date, datePre) < 0 ? (year - 1) : (year + 1);  //三目运算符                
                string dateToFebStr = year.ToString() + FebMonth;
                string dateToDecStr = year.ToString() + DecMonth;
                DateTime dateToFeb = Convert.ToDateTime(dateToFebStr);
                DateTime dateToDec = Convert.ToDateTime(dateToDecStr);
                this.dateNavigator1.DateTime = dateToDec;
                this.dateNavigator1.DateTime = dateToFeb;
                this.dateNavigator1.Refresh();
                return;
            }

            this.lbl_SelectionDate.Text = date.ToString("yyyy-MM-dd");
            this.lbl_DayOfYear.Text = date.DayOfYear.ToString("D3");

            if(IsOrigionDataExist(date))
            {
                this.lbl_IsOrigionDataExist.Text = "是";
            }
            else
            {
                this.lbl_IsOrigionDataExist.Text = "否";
            }
           
            datePre = date;           
        }

        //数据查找
        private bool IsOrigionDataExist(DateTime date)
        {
            bool isExist = false;
            if (date == null)
            {
                return isExist;
            }
            string dayOfYearStr = date.DayOfYear.ToString("D3");
            string year = date.Year.ToString().Substring(2, 2);
            string pattern = "*D" + year + dayOfYearStr + "*.tif";

            string path = config.EverydaySnowCoverFolderPath;
            try
            {
                string[] files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
                if (files.Length > 0)
                {
                    isExist = true;
                }
            }
            catch { }
            return isExist;
        }

        //时间变量转字符串年+天
        private string GetYearDayStr(DateTime date)
        {            
            int dayOfYear = date.DayOfYear;
            string yearDayStr =date.Year.ToString().Substring(2, 2) + dayOfYear.ToString("D3");
            return yearDayStr;
        }

        //判断鼠标点击位置
        private void dateNavigator1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 30)
            {
                hasClickedNaviBtn = true;
            }
        }

        //根据起始日期获取全部积雪覆盖文件路径
        private string[] getDateRangeFiles(DateTime _startDate, DateTime _endDate, string folder)
        {
            int isRightDate = DateTime.Compare(startDate, endDate);
            if (isRightDate >= 0)
            {
                return null;
            }
            List<string> list = new List<string>();
            try
            {
                DateTime date = _startDate;
                int isLater = 0;
                while (isLater <= 0)
                {
                    int day = date.DayOfYear;
                    string year = date.Year.ToString();
                    string path = folder + "\\D" + year.Substring(2, 2) + day.ToString("D3") + "_sc.tif";
                    list.Add(path);
                    date = date.AddDays(1);
                    isLater = DateTime.Compare(date, _endDate);
                }
            }
            catch
            { }

            if (list.Count == 0)
            {
                return null;
            }
            string[] files = list.ToArray();
            return files;

        }

        //根据指定日期获取积雪覆盖文件路径
        private string getDateFile(DateTime dateTime, string folder)
        {
            string snowCoverFilePath = null;
            try
            {
                DateTime date = dateTime;
                int day = date.DayOfYear;
                string year = date.Year.ToString();
                snowCoverFilePath = folder + "\\D" + year.Substring(2, 2) + day.ToString("D3") + "_sc.tif";
            }
            catch
            { }

            return snowCoverFilePath;
        }

        //分区统计结果导入数据库
        private void storeTableToMySQL(DataTable dt)
        {
            if (CheckExistsTable(dt.TableName) == true)
            {
                dropTableInMySQL(dt.TableName);
            }
            creatTableInMySQL(dt.TableName);

            //创建插入语句列表
            List<string> SQLInsertStringList = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                DataColumn dc = dt.Columns[4];
                string _insertStr = "INSERT INTO " + dt.TableName + " (Code, COUNT, SUM) VALUES ('" + dt.Rows[i][0].ToString() + "', "
                    + dt.Rows[i][2].ToString() + ", " + dt.Rows[i][4].ToString() + ")";
                SQLInsertStringList.Add(_insertStr);
            }

            using (MySqlConnection conn = getMySqlConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLInsertStringList.Count; n++)
                    {
                        string strsql = SQLInsertStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                        //后来加上的  
                        if (n > 0 && (n % 500 == 0 || n == SQLInsertStringList.Count - 1))
                        {
                            tx.Commit();
                            tx = conn.BeginTransaction();
                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        //获取数据库连接
        private MySqlConnection getMySqlConnection()
        {
            MySqlConnection conn = new MySqlConnection();
            string myConnectionString;
            myConnectionString = "server=" + config.DatabaseServerName + ";uid=" + config.DatabaseUsername
                + ";" + "pwd=" + config.DatabasePassword + ";database=" + config.DatabaseCatalog + ";";
            conn.ConnectionString = myConnectionString;
            return conn;
        }

        //创建表
        private void creatTableInMySQL(string _TableName)
        {
            string creatStByBdyTable = "create table " + _TableName + " (Code VarChar(255) not null, COUNT Integer, SUM Integer, foreign key(Code) references countyboundarytable(Code) on delete cascade on update cascade)engine=innodb default charset=utf8 auto_increment=1;";
           
            using (MySqlConnection conn = getMySqlConnection())
            {
                conn.Open();
                // create the table...
                using (MySqlCommand cmd = new MySqlCommand(creatStByBdyTable, conn))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        throw new Exception(E.Message);
                    } 
                }
            }
        }

        //删除表
        private void dropTableInMySQL(string _TableName)
        {
            string creatStByBdyTable = "drop table " + _TableName;

            using (MySqlConnection conn = getMySqlConnection())
            {
                conn.Open();
                // create the table...
                using (MySqlCommand cmd = new MySqlCommand(creatStByBdyTable, conn))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        //查找数据库是否存在指定表，若存在删除
        public bool CheckExistsTable(string tablename)
        {
            String tableNameStr = "SELECT COUNT(*) FROM information_schema.TABLES WHERE TABLE_NAME='" + tablename + "'";
            using (MySqlConnection conn = getMySqlConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(tableNameStr, conn);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
