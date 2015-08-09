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
using SystemBase;

using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using MySql.Data.MySqlClient;


namespace SnowCover
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private SystemConfig config = null;
        private bool isQueryStaInfoByMap = false;
        public Modules.ucFileNavPanel ucFileNavPanel = null;
        private MySqlConnection sqlConnection = null;
        private frmFeatureAttribute frmFeatureAttr = null;

        //esri
        private IActiveView activeView = null;

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
            //初始化MySQL Connection
            sqlConnection = SystemBase.MySQL.GetMySQLConnection(config.DatabaseServerName, config.DatabaseCatalog, config.DatabaseUsername, config.DatabasePassword);
        }

        #region //GIS控件事件
        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                //MapControl map = (MapControl)((ToolbarControl)hookHelper.getHook()).getBuddy();
                activeView = axMapControl1.ActiveView;

                activeView.ScreenDisplay.PanStart(activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y));

            }
        }


        private void axMapControl1_OnMouseUp(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 1)
            {
                if (isQueryStaInfoByMap && this.axMapControl1.MousePointer == ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair)
                {
                    GetStaInfoByMap();
                }
            }
            else if (e.button == 2)
            {
                //MessageBox.Show("2");
            }
            else if (e.button == 3)
            {
                //MessageBox.Show("3");
            }
            else if (e.button == 4 && activeView != null)
            {
                activeView.ScreenDisplay.PanStop();
                axMapControl1.ActiveView.Refresh();

            }
        }

        private void axMapControl1_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 4 && activeView != null)
            {
                activeView.ScreenDisplay.PanMoveTo(activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y));
            }
        }
        #endregion

        #region //GIS Map Tools
        //图层右键功能 
        private void axTOCControl1_OnMouseUp(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseUpEvent e)
        {
            if (e.button == 2)
            {
                Control control = (Control)sender;
                Point pt = control.PointToScreen(new Point(e.x, e.y));
                this.contextMenuStrip_TOCControl.Show(pt);
            }
        }

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
            SystemBase.GISTools.setNull(this.axMapControl1);
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
        private void btn_FullExtent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemBase.GISTools.FullExtend(this.axMapControl1);
        }

        private void btn_SetMouseNull_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemBase.GISTools.setNull(this.axMapControl1);
            isQueryStaInfoByMap = false;
        }
        #endregion
                
        #region //GIS AnalysisTools
        private void btn_StatisticTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSetSnowCoverDateForStatisticByBoundary statisticSnowCoverByBoundary = new frmSetSnowCoverDateForStatisticByBoundary(this.axMapControl1);
            statisticSnowCoverByBoundary.ShowDialog();
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

        #region //Excel表格灾害数据汇总
        private void btn_ExcelStatistic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDisasterStatisticsFromExcel disasterStatisticsFromExcel = new frmDisasterStatisticsFromExcel();
            disasterStatisticsFromExcel.Show();
        }
        #endregion

        #region //积雪统计信息查询
        private void GetStaInfoByMap()
        {
            IFeatureLayer layer = this.axMapControl1.get_Layer(0) as IFeatureLayer;
            ICursor cursor = SystemBase.GISFeatures.GetSelectionFeature(layer);

            IRow row = cursor.NextRow();
            string sValue = "";
            double dValue = 0.0;
            int iValue = 0;
            StaCountyProperty pro = new StaCountyProperty();
            while (row != null)
            {
                //行政区名称
                int nameIndex = row.Fields.FindField("name");
                if (nameIndex > 0)
                {
                    sValue = Convert.ToString(row.get_Value(nameIndex));
                    pro.区域名称 = sValue;
                }
                //行政区代码
                int codeIndex = row.Fields.FindField("scode");
                if (codeIndex > 0)
                {
                    sValue = Convert.ToString(row.get_Value(codeIndex));
                    pro.行政区代码 = sValue;
                }
                //区域总面积
                int areaIndex = row.Fields.FindField("area");
                if (areaIndex > 0)
                {
                    dValue = Convert.ToDouble(row.get_Value(areaIndex));
                    pro.区域总面积 = dValue;
                }

                //从数据库读取
                string sqlStr = "SELECT  sn.COUNT AS scount,sn.SUM AS ssum,sn.Date AS sdate "
                        + "FROM snowcover_statisticbyboundary AS sn "
                        + "WHERE sn.Code = '" + pro.行政区代码 + "' AND sn.Date = '" + config.LastHandleDate + "'";
                MySqlConnection conn = config.GetMySQLConnection();
                if (conn != null)
                {
                    DataTable table = SystemBase.MySQL.Select(sqlStr, conn);
                    if (table.Rows.Count < 1)
                    {
                        MessageBox.Show("数据库中为找到该行政区积雪覆盖数据。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    DataRow trow = table.Rows[0];
                    //总像元数
                    iValue = Convert.ToInt32(trow["scount"]);
                    pro.总像元数 = iValue;
                    //积雪像元数
                    iValue = Convert.ToInt32(trow["ssum"]);
                    pro.积雪像元数 = iValue;
                    //统计日期
                    sValue = Convert.ToString(trow["sdate"]);
                    pro.统计日期 = sValue;
                }
                else
                {
                    MessageBox.Show("数据库连接失败，请更改数据库配置。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                break;
            }
            if (frmFeatureAttr != null)
            {
                frmFeatureAttr.setData(pro);
                frmFeatureAttr.BringToFront();
            }
            else
            {
                frmFeatureAttr = new frmFeatureAttribute();
                frmFeatureAttr.setData(pro);
                frmFeatureAttr.FormClosed += frmFeatureAttr_FormClosed;
                frmFeatureAttr.Show();
            }
        }

        private void frmFeatureAttr_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFeatureAttr = null;
        }

        private void btn_renderStaInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string staByCountyMapPath = config.CountyMapPath;
            if (File.Exists(staByCountyMapPath))
            {
                this.axMapControl1.LoadMxFile(staByCountyMapPath);
            }
            else
            {
                if (MessageBox.Show("积雪覆盖统计地图未找到，请重新选择。是否现在选择？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    string mapPath = SystemBase.FormCommon.SelectSingleFile(config.DataCenterFolderPath, "mxd文件|*.mxd");
                    if (File.Exists(mapPath))
                    {
                        this.axMapControl1.LoadMxFile(mapPath);
                        config.CountyMapPath = mapPath; //保存到设置文件
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            frmSetStaMapDate frmSetMapDate = new frmSetStaMapDate(this.axMapControl1, this.axTOCControl1);
            frmSetMapDate.ShowDialog();

            isQueryStaInfoByMap = true;
            GISTools.SelectFeature(this.axMapControl1);
            this.axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;

            //else
            //{
            //    GISTools.setNull(this.axMapControl1);
            //    this.axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
            //}
        }

        #endregion

        
    }
}
