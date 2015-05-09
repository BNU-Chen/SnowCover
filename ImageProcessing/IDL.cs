using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;

using COM_IDL_connectLib;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;


namespace ImageProcessing
{
    public class IDL
    {
        public static void ProcessingOrigionData(string Pro_Name,string File_Directory, string Date_Time, string EVF_FileName, string SNOW_FILENAME)
        {
            string IDL_Path = Application.StartupPath + "\\idl\\" + Pro_Name+".pro";
            if (!File.Exists(IDL_Path))
            {
                return;
            }
            string proName = Path.GetFileNameWithoutExtension(IDL_Path);

            COM_IDL_connectLib.COM_IDL_connect oComIDL = new COM_IDL_connect();

            //对象初始化
            oComIDL.CreateObject(0, 0, 0);

            oComIDL.SetIDLVariable( "File_Directory",File_Directory);
            oComIDL.SetIDLVariable( "Date_Time",Date_Time);
            oComIDL.SetIDLVariable( "EVF_FileName",EVF_FileName);
            oComIDL.SetIDLVariable( "SNOW_FILENAME",SNOW_FILENAME);
            oComIDL.ExecuteString(".compile'" + IDL_Path);
            oComIDL.ExecuteString(proName + "," + File_Directory + "," + Date_Time + "," + EVF_FileName + "," + SNOW_FILENAME);
            

        }

        //定义栅格打开函数
        private static void OpenRaster(string rasterFileName, AxMapControl _MapControl)
        {
            if(!File.Exists(rasterFileName))
            {
                return;
            }
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
    }
}
