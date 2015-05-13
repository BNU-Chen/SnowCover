using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;

namespace SnowCover
{
    public partial class frmSetSnowCoverInitDate : Form
    {
        private DataHandle.INIFile iniFile = null;
        private AxMapControl axMapControl = null;

        public frmSetSnowCoverInitDate(AxMapControl _AxMapControl)
        {
            InitializeComponent();
            axMapControl = _AxMapControl;
        }

        private void frmSetSnowCoverInitDate_Load(object sender, EventArgs e)
        {
            iniFile = new DataHandle.INIFile(DataHandle.INIFile.GetINIFilePath());

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
            ExeInitSnowCover(date);
        }
        //分析今天
        private void btn_Today_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
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

                string In_Directory = iniFile.IniReadValue("DataCenter", "OrigionDataFolder");
                string Date_Time = year.Substring(2, 2) + dayOfYear;
                string EVF_FileName = iniFile.IniReadValue("DataCenter", "BoundaryFilePath");
                string EverydaySnowCoverFolder = iniFile.IniReadValue("DataCenter", "EverydaySnowCoverFolder");
                string PreprocessingSnowCover = iniFile.IniReadValue("DataCenter", "PreprocessingSnowCover");
                string Snow_FileName = iniFile.IniReadValue("DataCenter", "OrigionDataFolder");
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

            //this.lbl_SelectionDate.Text = today.ToString("")
        }

        
    }
}
