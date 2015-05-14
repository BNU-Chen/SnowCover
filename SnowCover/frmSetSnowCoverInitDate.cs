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

            this.dateNavigator1.DateTime = today;
            this.dateNavigator1.TodayButton.Text = "今天";

        }
        //确定
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            bool isDataExist = IsOrigionDataExist(date);
            if (!isDataExist)
            {
                MessageBox.Show("选定日期的原始影像数据不存在。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExeInitSnowCover(date);
        }
        //分析今天
        private void btn_Today_Click(object sender, EventArgs e)
        {
            
            DateTime today = DateTime.Now;
            bool isDataExist = IsOrigionDataExist(today);
            if(!isDataExist)
            {
                MessageBox.Show("今天的原始影像数据不存在。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            ExeInitSnowCover(today);
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

                ImageProcessing.IDL.ProcessingOrigionData(In_Directory, Date_Time, EVF_FileName, PreprocessingSnowCover, EverydaySnowCoverFolder, axMapControl);
            }
            catch
            { }
            this.Close();
        }


        private void dateNavigator1_EditDateModified(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            this.dateNavigator1.HotDate = date;

            string dateStr = date.ToString("yyyy-MM-dd");
            this.lbl_SelectionDate.Text = dateStr;

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

        
    }
}
