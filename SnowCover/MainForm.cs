using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using ImageProcessing;


namespace SnowCover
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataHandle.INIFile iniFile = null;
        public Modules.ucFileNavPanel ucFileNavPanel = new Modules.ucFileNavPanel();
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            iniFile = new DataHandle.INIFile(DataHandle.INIFile.GetINIFilePath());
        }

        #region //GIS Map Tools

        private void btn_OpenMapFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;    //单选
            ofd.Title = "选择地图文件";
            ofd.Filter = "mxd文件|*.mxd";
            ofd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                if (fi.Exists)
                {
                    this.axMapControl1.LoadMxFile(fi.FullName);
                    this.axMapControl1.ActiveView.Refresh();
                }
            }
        }
        private void btn_ExportMapPic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.ExportImage(this.axMapControl1.ActiveView);
        }

        private void btn_AddMapLayer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.AddData(this.axMapControl1);
        }

        private void btn_Pan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.Pan(this.axMapControl1);
        }

        private void btn_ZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.ZoomIn(axMapControl1);
        }

        private void btn_ZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.ZoomOut(axMapControl1);
        }

        private void btn_ScaleIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.ZoomInFix(axMapControl1);
        }

        private void btn_ScaleOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.ZoomOutFix(axMapControl1);
        }
        #endregion

        #region //数据中心
        private void btn_SnowCover_OriginalImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowFileNavPanel(this.btn_SnowCover_OriginalImage);
        }

        private void btn_SnowCover_Everyday_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowFileNavPanel(this.btn_SnowCover_Everyday);
        }

        private void btn_SnowCover_DateRange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowFileNavPanel(this.btn_SnowCover_DateRange);
        }

        private void btn_Data_StatisticTables_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_PublishDisasterDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowFileNavPanel(this.btn_PublishDisasterDoc);
        }

        private void ShowFileNavPanel(DevExpress.XtraBars.BarButtonItem button)
        {
            if (iniFile == null)
            {
                if(MessageBox.Show("配置文件不存在，请重新制定。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmSysSetting frmSetting = new frmSysSetting();
                    frmSetting.ShowDialog();                    
                }
                return;
            }

            string path = "";
            switch(button.Name)
            {
                case "btn_SnowCover_OriginalImage":
                    path = iniFile.IniReadValue("DataCenter", "OrigionDataFolder");
                    break;
                case "btn_SnowCover_Everyday":
                    path = iniFile.IniReadValue("DataCenter", "EverydaySnowCoverFolder");
                    break;
                case "btn_SnowCover_DateRange":
                    path = iniFile.IniReadValue("DataCenter", "DateRangeSnowCoverFolder");
                    break;
                case "btn_PublishDisasterDoc":
                    path = iniFile.IniReadValue("DataCenter", "PublishDisasterDoc");
                    break;
               
            }

            this.xtraTabPage_DataNav.Controls.Clear();
            this.xtraTabPage_DataNav.Controls.Add(ucFileNavPanel);
            ucFileNavPanel.Dock = DockStyle.Fill;
            this.xtraTabPage_DataNav.Text = button.Caption;
            this.xtraTabControl_Left.SelectedTabPage = this.xtraTabPage_DataNav;
            
            DataTable dt = DataHandle.DiskFile.getDataTable(path);
            if (dt == null)
            {
                return;
            }
            //if (dt.Rows.Count == 0)
            //{
            //    return;
            //}
            ucFileNavPanel.TreeList.KeyFieldName = "id";
            ucFileNavPanel.TreeList.ParentFieldName = "pid";
            ucFileNavPanel.TreeList.DataSource = dt;

            //按名称排序
            ucFileNavPanel.TreeList.BeginSort();
            ucFileNavPanel.TreeList.Columns["type"].SortOrder = SortOrder.Descending;
            ucFileNavPanel.TreeList.Columns["name"].SortOrder = SortOrder.Ascending;
            ucFileNavPanel.TreeList.EndSort();

            //隐藏除"name"的列
            for (int i = 0; i < ucFileNavPanel.TreeList.Columns.Count; i++)
            {
                if (ucFileNavPanel.TreeList.Columns[i].FieldName != "name")
                {
                    ucFileNavPanel.TreeList.Columns[i].Visible = false;
                }
            }
            if (dt.Rows.Count < 100)
            {
                this.ucFileNavPanel.TreeList.ExpandAll();
            }
            if(ucFileNavPanel.TreeList.Columns.Count >0)
            {
                ucFileNavPanel.TreeList.Columns[0].Caption = "名称";
            }            
        }
        #endregion

        #region //积雪分析
        private void btn_InitRSImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string Pro_Name = "ENVI_AVHRR_INVERtSNOWCOVER";
            string File_Directory = iniFile.IniReadValue("DataCenter","OrigionDataFolder");
            string Date_Time = "10011";
            string EVF_FileName = iniFile.IniReadValue("DataCenter","BoundaryFilePath");
            string EverydaySnowCoverFolder = iniFile.IniReadValue("DataCenter","EverydaySnowCoverFolder");            
            string Snow_FileName = EverydaySnowCoverFolder+"\\Snow_"+Date_Time+".tif";
            ImageProcessing.IDL.ProcessingOrigionData(Pro_Name, File_Directory, Date_Time, EVF_FileName, Snow_FileName,this.axMapControl1);
        }

        private void btn_AnalystSC_DateRange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        #region //设置与帮助
        private void btn_Settings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSysSetting settingForm = new frmSysSetting();
            settingForm.Show();
        }

        private void btn_HelpDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_About_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion 
    }
}
