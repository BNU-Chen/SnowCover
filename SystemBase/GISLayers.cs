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
using ESRI.ArcGIS.Geometry;

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
            if (_MapControl == null)
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

        public static ILayer GetLayerFromTOCControl(AxTOCControl _axTOCControl)
        {
            IBasicMap map = new MapClass();
            ILayer layer = new FeatureLayerClass();
            object legendGroup = new object();
            object index = new object();
            esriTOCControlItem item = new esriTOCControlItem();

            _axTOCControl.GetSelectedItem(ref item, ref map, ref layer, ref legendGroup, ref index);
            return layer;
        }
        //投影转换
        public static void TestProjection(ILayer layer)
        {
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            var srf = obj as ISpatialReferenceFactory3;

            // Create Transformation from WGS84 to WGS1972
            var geoTrans = srf.CreateGeoTransformation((int)esriSRGeoTransformationType.esriSRGeoTransformation_WGS1972_To_WGS1984_1) as IGeoTransformation;

            ISpatialReference fromSpatialReference;
            ISpatialReference toSpatialReference;
            geoTrans.GetSpatialReferences(out fromSpatialReference, out toSpatialReference);

            var wgs84GCS = srf.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
            //var bngPCS = srf.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_BritishNationalGrid);
            //if ((wgs84GCS.FactoryCode != toSpatialReference.FactoryCode)
            //    || (bngPCS.GeographicCoordinateSystem.FactoryCode != fromSpatialReference.FactoryCode))
            //{
            //    //throw new System.Exception("invalid geotransformation");
            //    return;
            //}
            layer.SpatialReference = wgs84GCS;
            
            //IGeometry5 geometry;
            //IPoint point = new PointClass();
            //point.PutCoords(-3.159875, 51.465615);
            //geometry = point as IGeometry5;
            //geometry.SpatialReference = wgs84GCS;

            //geometry.ProjectEx(bngPCS, esriTransformDirection.esriTransformReverse, geoTrans, false, 0.0, 0.0);
            //point = geometry as IPoint;
            //Debug.Print("{0} {1}", point.X, point.Y);
        }
    }
}
