﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using ImageProcessing;
using SystemBase;

using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;

namespace SnowCover
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private SystemConfig config = null;
        public Modules.ucFileNavPanel ucFileNavPanel = null;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DateTime.Now > Convert.ToDateTime("2015-12-30"))
            {
                return;
            }
            config = new SystemBase.SystemConfig();
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

        private void btn_MapPointValuel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemBase.GISTools.IdentifyTool(this.axMapControl1);
        }

        private void btn_ExportMapPic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemBase.GISTools.ExportImage(this.axMapControl1.ActiveView);
        }

        private void btn_AddMapLayer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemBase.GISTools.AddData(this.axMapControl1);
        }

        private void btn_Pan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemBase.GISTools.Pan(this.axMapControl1);
        }

        private void btn_ZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemBase.GISTools.ZoomIn(axMapControl1);
        }

        private void btn_ZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemBase.GISTools.ZoomOut(axMapControl1);
        }

        private void btn_ScaleIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemBase.GISTools.ZoomInFix(axMapControl1);
        }

        private void btn_ScaleOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemBase.GISTools.ZoomOutFix(axMapControl1);
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

        private void btn_SnowCover_Statistic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowFileNavPanel(this.btn_SnowCover_Statistic);
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
            if (config.IniFile == null)
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
                    path = config.OrigionDataFolderPath;
                    break;
                case "btn_SnowCover_Everyday":
                    path = config.EverydaySnowCoverFolderPath;
                    break;
                case "btn_SnowCover_Statistic":
                    path = config.StatisticSnowCoverFolderPath;
                    break;
                case "btn_PublishDisasterDoc":
                    path = config.PublishDisasterDocPath;
                    break;               
            }
            ucFileNavPanel = new Modules.ucFileNavPanel(this.axMapControl1);

            this.xtraTabPage_DataNav.Controls.Clear();
            this.xtraTabPage_DataNav.Controls.Add(ucFileNavPanel);
            ucFileNavPanel.Dock = DockStyle.Fill;
            this.xtraTabPage_DataNav.Text = button.Caption;
            this.xtraTabControl_Left.SelectedTabPage = this.xtraTabPage_DataNav;

            DateTime date = DateTime.Now;
            this.ucFileNavPanel.Path = path;
            this.ucFileNavPanel.DateEdit.DateTime = date;
        }
        #endregion

        #region //积雪分析
        private void btn_InitRSImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSetSnowCoverInitDate setInitDate = new frmSetSnowCoverInitDate(this.axMapControl1);
            setInitDate.ShowDialog();            
        }

        private void btn_AnalystSC_Statistic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSetStatisticSnowCoverDate frmSetStatistic = new frmSetStatisticSnowCoverDate(this.axMapControl1);
            frmSetStatistic.ShowDialog();
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

        //图层右键菜单
        private void contextMenuStrip_TOCControl_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsmi_ZoomToLayer":
                    if (this.axMapControl1.Map.LayerCount == 0)
                    {
                        return;
                    }

                    ESRI.ArcGIS.Carto.ILayer layer = SystemBase.GISLayers.GetLayerFromTOCControl(this.axTOCControl1);
                    ESRI.ArcGIS.Carto.IActiveView activeView = this.axMapControl1.ActiveView;

                    // Zoom to the extent of the layer and refresh the map
                    activeView.Extent = layer.AreaOfInterest;
                    activeView.Refresh();
                    break;
                case "tsmi_RemoveLayer":
                    ESRI.ArcGIS.Carto.ILayer layerRemove = SystemBase.GISLayers.GetLayerFromTOCControl(this.axTOCControl1);
                    if (null != layerRemove)
                    {
                        ((IDataLayer2)layerRemove).Disconnect();
                        ((IMapLayers)this.axMapControl1.ActiveView).DeleteLayer(layerRemove);
                    }
                    this.axTOCControl1.Refresh();
                    this.axMapControl1.ActiveView.Refresh();
                    break;
                case "tsmi_ProjectToWGS1984":
                    ESRI.ArcGIS.Carto.ILayer layerProject = SystemBase.GISLayers.GetLayerFromTOCControl(this.axTOCControl1);
                    if (null != layerProject)
                    {
                        SystemBase.GISLayers.TestProjection(layerProject);
                        this.axMapControl1.ActiveView.Refresh();
                    }
                    break;
                default:
                    break;
            }
        }

        private void axTOCControl1_OnMouseUp(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseUpEvent e)
        {
            if (e.button == 2)
            {
                Control control = (Control)sender;
                Point pt = control.PointToScreen(new Point(e.x, e.y));
                this.contextMenuStrip_TOCControl.Show(pt);
            }
        }

    }
}
