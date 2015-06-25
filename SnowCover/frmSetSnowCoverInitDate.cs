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

using SystemBase;

namespace SnowCover
{
    public partial class frmSetSnowCoverInitDate : Form
    {
        private SystemConfig config = null;
        private AxMapControl axMapControl = null;
        private DateTime startDate;
        private DateTime endDate;
        private bool isBatHandler = false;

        private DateTime datePre = DateTime.Now;   //上一个选择的日期


        public frmSetSnowCoverInitDate(AxMapControl _AxMapControl)
        {
            InitializeComponent();
            axMapControl = _AxMapControl;
            config = new SystemConfig();
        }

        private void frmSetSnowCoverInitDate_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime firstDayOfYear = Convert.ToDateTime(today.Year.ToString()+"-01-01");//DateTime.Now;
            this.dateNavigator1.DateTime = firstDayOfYear;

            //this.dateNavigator1.DateTime = today;
            this.dateNavigator1.TodayButton.Text = "今天";

            //初始为单个处理
            this.Height = 565;
        }
        //确定
        private void btn_Submit_Click(object sender, EventArgs e)
        {            
            DateTime date = this.dateNavigator1.DateTime;
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
                string handleSuccessDates = "";
                string handleFailureDates = "";
                for (DateTime dateIndex = startDate; dateIndex <= endDate; )
                {
                    bool isDataExist = IsOrigionDataExist(date);
                    if (isDataExist)
                    {
                        handleSuccessDates += GetYearDayStr(dateIndex) + ",";
                        ExeInitSnowCover(dateIndex);
                    }
                    else
                    {
                        handleFailureDates += GetYearDayStr(dateIndex) + ",";
                    }

                    dateIndex = dateIndex.AddDays(1);
                }
                SystemBase.LogFile.Log(this.Text, "处理成功：" + handleSuccessDates);
                SystemBase.LogFile.Log(this.Text, "处理失败：" + handleFailureDates);
                MessageBox.Show("以下数据处理成功：\n" + handleSuccessDates + "\n以下数据处理失败：\n" + handleFailureDates, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (handleSuccessDates == "" && handleFailureDates != "")
                {
                    this.Close();
                }
            }
            else
            {
                bool isDataExist = IsOrigionDataExist(date);
                if (!isDataExist)
                {
                    MessageBox.Show("选定日期的原始影像数据不存在。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ExeInitSnowCover(date);
                SystemBase.LogFile.Log(this.Text, "处理成功：" + GetYearDayStr(date));
                this.Close();
            }
        }
        //批量处理
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

        private void btn_SetStartDate_Click(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            int dayOfYear = date.DayOfYear;
            this.lbl_StartDate.Text = date.ToString("yyyy-MM-dd") + " " + date.Year.ToString().Substring(2, 2) + dayOfYear.ToString("D3");

            startDate = date;
        }

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

        private void ExeInitSnowCover(DateTime date)
        {
            this.Hide();
            try
            {
                string year = date.Year.ToString();
                string dayOfYear = date.DayOfYear.ToString("D3");

                string In_Directory = config.OrigionDataFolderPath;
                string Date_Time = year.Substring(2, 2) + dayOfYear;
                string EVF_FileName = config.BoundaryFilePath;
                string EverydaySnowCoverFolder = config.EverydaySnowCoverFolderPath;
                string PreprocessingSnowCover = config.PreprocessingSnowCoverFolderPath + "\\" + Date_Time;

                if(!Directory.Exists(PreprocessingSnowCover))
                {
                    try
                    {
                        Directory.CreateDirectory(PreprocessingSnowCover);
                    }
                    catch
                    {
                        MessageBox.Show("创建积雪预处理文件目录失败，请检查权限后重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (isBatHandler)
                {
                    ImageProcessing.IDL.ProcessingOrigionData(In_Directory, Date_Time, EVF_FileName, PreprocessingSnowCover, EverydaySnowCoverFolder, null);
                }else
                {
                    ImageProcessing.IDL.ProcessingOrigionData(In_Directory, Date_Time, EVF_FileName, PreprocessingSnowCover, EverydaySnowCoverFolder, axMapControl);
                }                
            }
            catch
            { }
        }


        private void dateNavigator1_EditDateModified(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            this.dateNavigator1.HotDate = date;

            string dateStr = date.ToString("yyyy-MM-dd");
            this.lbl_SelectionDate.Text = dateStr;
            System.Console.WriteLine(dateStr);

            string dayOfYearStr = date.DayOfYear.ToString("D3");
            this.lbl_DayOfYear.Text = dayOfYearStr;

            if(IsOrigionDataExist(date))
            {
                this.lbl_IsOrigionDataExist.Text = "是";
            }
            else
            {
                this.lbl_IsOrigionDataExist.Text = "否";
            }
            //控制显示一整年的月历
            DateTime dateTo = DateTime.Now;
            if (date.Year != datePre.Year)
            {
                string monthDay = "-01-01";
                if (date.Month == 1 && datePre.Month == 12)
                {
                    monthDay = "-12-01";
                }
                dateTo = Convert.ToDateTime(date.Year.ToString() + monthDay);//DateTime.Now;                

            }
            datePre = date;
            if (dateTo.DayOfYear != DateTime.Now.DayOfYear)
            {
                this.dateNavigator1.DateTime = dateTo;
                this.dateNavigator1.Refresh();
            }
           
        }

        private bool IsOrigionDataExist(DateTime date)
        {
            bool isExist = false;
            if(date == null)
            {
                return isExist;
            }
            string dayOfYearStr = date.DayOfYear.ToString("D3");
            string year = date.Year.ToString().Substring(2, 2);
            string pattern = "*D" + year + dayOfYearStr + "*.mm";

            string path = config.OrigionDataFolderPath;
            try
            {

                string[] files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
                if(files.Length >0)
                {
                    isExist = true;
                }
            }
            catch{}
            return isExist;
        }

        private string GetYearDayStr(DateTime date)
        {            
            int dayOfYear = date.DayOfYear;
            string yearDayStr =date.Year.ToString().Substring(2, 2) + dayOfYear.ToString("D3");
            return yearDayStr;
        }


       




        
    }
}
