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
    public partial class frmSetStatisticSnowCoverDate : Form
    {
        private DataHandle.INIFile iniFile = null;
        private AxMapControl axMapControl = null;
        private DateTime startDate;
        private DateTime endDate;
        public frmSetStatisticSnowCoverDate(AxMapControl _AxMapControl)
        {
            InitializeComponent();
            axMapControl = _AxMapControl;
        }

        private void frmSetStatisticSnowCoverDate_Load(object sender, EventArgs e)
        {
            iniFile = new DataHandle.INIFile(DataHandle.INIFile.GetINIFilePath());

            DateTime today = DateTime.Now;
            DateTime firstDayOfYear = Convert.ToDateTime(today.Year.ToString() + "-01-01");//DateTime.Now;
            this.dateNavigator1.DateTime = firstDayOfYear;

            this.dateNavigator1.DateTime = today;
            this.dateNavigator1.TodayButton.Text = "今天";
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if(startDate == null || endDate == null)
            {
                MessageBox.Show("请选择起始和截止日期。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int isLater = DateTime.Compare(startDate, endDate);
            if(isLater >=0)
            {
                MessageBox.Show("截止日期小于起始日期，请重新选择。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExeInitSnowCover(startDate, endDate);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btn_SelectStartDate_Click(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            int dayOfYear = date.DayOfYear;
            this.lbl_StartDate.Text = date.ToString("yyyy-MM-dd") + " " + dayOfYear.ToString("D3");

            startDate = date;
        }

        private void btn_SelectEndDate_Click(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            int dayOfYear = date.DayOfYear;
            this.lbl_EndDate.Text = date.ToString("yyyy-MM-dd") + " " + dayOfYear.ToString("D3");

            endDate = date;
        }

        private void dateNavigator1_EditDateModified(object sender, EventArgs e)
        {
            DateTime date = this.dateNavigator1.DateTime;
            int dayOfYear = date.DayOfYear;
            this.lbl_SelectionDate.Text = date.ToString("yyyy-MM-dd") + " " + dayOfYear.ToString("D3");
            this.lbl_DayOfYear.Text = dayOfYear.ToString("D3");
        }

        private void ExeInitSnowCover(DateTime startDate,DateTime endDate)
        {
            this.Hide();
            try
            {
                string SnowCoverFolder = iniFile.IniReadValue("DataCenter", "EverydaySnowCoverFolder");
                string[] IN_FILES = getDateRangeFiles(startDate, endDate, SnowCoverFolder);
                string StatisticFolder = iniFile.IniReadValue("DataCenter", "DateRangeSnowCoverFolder");
                string yearStartStr = startDate.Year.ToString();
                string yearEndStr  = endDate.Year.ToString();
                string startDay = startDate.DayOfYear.ToString("D3");
                string endDay = endDate.DayOfYear.ToString("D3");
                string StatisticFile = StatisticFolder + "\\Sta" + yearStartStr.Substring(2, 2) + startDay + "_" + yearEndStr.Substring(2, 2) + endDay + ".tif";
                ImageProcessing.IDL.StatisticSnowCover(IN_FILES, StatisticFile, this.axMapControl);                
            }
            catch
            { }
            this.Close();
        }

        private string[] getDateRangeFiles(DateTime _startDate,DateTime _endDate,string folder)
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
            {

            }

            if(list.Count == 0)
            {
                return null;
            }
            string[] files = list.ToArray();
            return files;           

        }


        private void dateNavigator1_MouseUp(object sender, MouseEventArgs e)
        {
            DateTime selectionStart = this.dateNavigator1.SelectionStart;
            DateTime selectionEnd = this.dateNavigator1.SelectionEnd;
            if(selectionStart.DayOfYear != selectionEnd.DayOfYear)
            {
                int start = selectionStart.DayOfYear;
                this.lbl_StartDate.Text = selectionStart.ToString("yyyy-MM-dd") + " " + start.ToString("D3");

                int end = selectionEnd.DayOfYear;
                this.lbl_EndDate.Text = selectionEnd.ToString("yyyy-MM-dd") + " " + end.ToString("D3");

                startDate = selectionStart;
                endDate = selectionEnd;
            }
        }




    }
}
