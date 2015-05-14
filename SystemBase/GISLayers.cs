using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;

namespace SystemBase
{
    public class GISLayers
    {
        //定义栅格打开函数
        public static void OpenRaster(string rasterFileName, AxMapControl _MapControl)
        {
            if (!File.Exists(rasterFileName))
            {
                return;
            }
            try
            {
                //文件名处理
                string ws = System.IO.Path.GetDirectoryName(rasterFileName);
                string fbs = System.IO.Path.GetFileName(rasterFileName);
                //创建工作空间
                IWorkspaceFactory pWork = new RasterWorkspaceFactoryClass();
                //打开工作空间路径，工作空间的参数是目录，不是具体的文件名
                IRasterWorkspace pRasterWS = (IRasterWorkspace)pWork.OpenFromFile(ws, 0);
                //打开工作空间下的文件，
                IRasterDataset pRasterDataset = pRasterWS.OpenRasterDataset(fbs);
                IRasterLayer pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromDataset(pRasterDataset);
                //添加到图层控制中
                _MapControl.Map.AddLayer(pRasterLayer as ILayer);
            }
            catch { }
        }

        public static bool IsSupportLayerType(string extension)
        {
            bool isSupport = false;
            if (extension == ".img" || extension == ".tif" || extension == ".shp" || extension == ".mm" || extension == ".mxd")
            {
                isSupport = true;
            }
            return isSupport;
        }
    }
}
