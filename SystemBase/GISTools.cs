using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;

namespace SystemBase
{
    public class GISTools
    {
        /// <summary>
        /// 设置当前工具为空
        /// </summary>
        /// <param name="axMapControl"></param>
        public static void setNull(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            IMapControl2 mapControl = (IMapControl2)axMapControl.Object;
            mapControl.CurrentTool = null;
            mapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        public static void AddData(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsAddDataCommandClass();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 放大
        /// </summary>
        public static void ZoomIn(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomInToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
        /// <summary>
        /// 缩小
        /// </summary>
        public static void ZoomOut(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomOutToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
        /// <summary>
        /// 查询要素信息
        /// </summary>
        public static void IdentifyTool(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapIdentifyToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
        /// <summary>
        /// 移动
        /// </summary>
        public static void Pan(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapPanToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
        /// <summary>
        /// 比例放大
        /// </summary>
        public static void ZoomInFix(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomInFixedCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 比例缩小
        /// </summary>
        public static void ZoomOutFix(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomOutFixedCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 左移
        /// </summary>
        public static void PanLeft(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapLeftCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 右移
        /// </summary>
        public static void PanRight(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapRightCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 上移
        /// </summary>
        public static void PanUp(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapUpCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 下移
        /// </summary>
        public static void PanDown(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapDownCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 上移场景
        /// </summary>
        public static void LastExtentBack(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomToLastExtentBackCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 下移场景
        /// </summary>
        public static void LastExtentForward(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomToLastExtentForwardCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 全屏显示
        /// </summary>
        public static void FullExtend(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ESRI.ArcGIS.Controls.ControlsMapFullExtentCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 选择
        /// </summary>
        public static void SelectFeature(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsSelectFeaturesToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
        /// <summary>
        /// 反选
        /// </summary>
        public static void SwitchSelection(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsSwitchSelectionCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 放大到选择对象
        /// </summary>
        public static void ZoomToFeatures(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsZoomToSelectedCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 清除选择
        /// </summary>
        public static void ClearSelect(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsClearSelectionCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /// <summary>
        /// 选择要素
        /// </summary>
        public static void SelectByGraphic(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsSelectToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
        /// <summary>
        /// 全选
        /// </summary>
        public static void SelectAll(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsSelectAllCommandClass();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        public static void SaveMxdFile(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsSaveAsDocCommandClass();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        /*
        /// <summary>
        /// 属性查询
        /// </summary>
        public void Identify(AxMapControl axMapControl, frmMain form)
        {
            IdentityService service = new IdentityService();
            service.FeatureIdentity(form, axMapControl);
        }
        /// <summary>
        /// 量测
        /// </summary>
        public void Measure(AxMapControl axMapControl, frmMain form)
        {
            IdentityService service = new IdentityService();
            service.Measure(form, axMapControl);
        }
         */
        /// <summary>
        /// 刷新
        /// </summary>
        public void barRefresh()
        {
            //IGraphicsContainer pDeleteElements = define.define.axMapControl.ActiveView.FocusMap as IGraphicsContainer;
            //pDeleteElements.DeleteAllElements();
            //define.define.axMapControl.ActiveView.Refresh();
        }

        /// <summary>
        /// 查询定位
        /// </summary>
        //public void FindAndLocate()
        //{
        //    Tools.frmFindAndLocate sf = new Tools.frmFindAndLocate();
        //    sf.ShowDialog();
        //}

        /// <summary>
        /// 根据项目地图的不同，自定义全图工具
        /// </summary>
        /// <param name="axMapControl"></param>
        public static void FullExtentBySelfDefine(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            IEnvelope evp = new EnvelopeClass();
            evp.XMax = 138.197944;
            evp.XMin = 70.335832;
            evp.YMax = 14.680281;
            evp.YMin = 57.216853;
            axMapControl.ActiveView.Extent = evp;
            axMapControl.ActiveView.Refresh();
        }

        //输出当前地图为图片
        public static string ExportImage(IActiveView pActiveView)
        {
            if (pActiveView == null)
            {
                return null;
            }
            try
            {
                SaveFileDialog pSaveFileDialog = new SaveFileDialog();
                pSaveFileDialog.Filter = "JPEG(*.jpg)|*.jpg|AI(*.ai)|*.ai|BMP(*.BMP)|*.bmp|EMF(*.emf)|*.emf|GIF(*.gif)|*.gif|PDF(*.pdf)|*.pdf|PNG(*.png)|*.png|EPS(*.eps)|*.eps|SVG(*.svg)|*.svg|TIFF(*.tif)|*.tif";
                pSaveFileDialog.Title = "输出地图";
                pSaveFileDialog.RestoreDirectory = true;
                pSaveFileDialog.FilterIndex = 1;
                if (pSaveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return null;
                }
                string FileName = pSaveFileDialog.FileName;
                IExport pExporter = null;
                switch (pSaveFileDialog.FilterIndex)
                {
                    case 1:
                        pExporter = new ExportJPEGClass();
                        break;
                    case 2:
                        pExporter = new ExportBMPClass();
                        break;
                    case 3:
                        pExporter = new ExportEMFClass();
                        break;
                    case 4:
                        pExporter = new ExportGIFClass();
                        break;
                    case 5:
                        pExporter = new ExportAIClass();
                        break;
                    case 6:
                        pExporter = new ExportPDFClass();
                        break;
                    case 7:
                        pExporter = new ExportPNGClass();
                        break;
                    case 8:
                        pExporter = new ExportPSClass();
                        break;
                    case 9:
                        pExporter = new ExportSVGClass();
                        break;
                    case 10:
                        pExporter = new ExportTIFFClass();
                        break;
                    default:
                        MessageBox.Show("输出格式错误");
                        return null;
                }
                IEnvelope pEnvelope = new EnvelopeClass();
                ITrackCancel pTrackCancel = new CancelTrackerClass();
                tagRECT ptagRECT;
                ptagRECT = pActiveView.ScreenDisplay.DisplayTransformation.get_DeviceFrame();

                int pResolution = (int)(pActiveView.ScreenDisplay.DisplayTransformation.Resolution);

                pEnvelope.PutCoords(ptagRECT.left, ptagRECT.bottom, ptagRECT.right, ptagRECT.top);
                pExporter.Resolution = pResolution;
                pExporter.ExportFileName = FileName;
                pExporter.PixelBounds = pEnvelope;
                pActiveView.Output(pExporter.StartExporting(), pResolution, ref ptagRECT, pActiveView.Extent, pTrackCancel);
                pExporter.FinishExporting();
                //释放资源
                pSaveFileDialog.Dispose();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pExporter);
                return FileName;
            }
            catch
            {
                return null;

            }
        }
    }
}
