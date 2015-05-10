﻿using System;
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
        private static string IDL_Path = Application.StartupPath + "\\idl\\";

        private static string Pro_ProcessingOrigionData = "ENVI_AVHRR_INVERtSNOWCOVER";
        private static string Pro_CSharp_Test = "CSharp_Test";
        private static string Pro_EXCHANGEARRt = "EXCHANGEARR";

        //原始影像初始化
        public static void ProcessingOrigionData(string File_Directory, string Date_Time, string EVF_FileName, string SNOW_FILENAME,AxMapControl _MapControl)
        {
            string Pro_Path = IDL_Path + Pro_ProcessingOrigionData+".pro";
            if (!File.Exists(Pro_Path))
            {
                return;
            }

            try
            {
                COM_IDL_connectLib.COM_IDL_connect oComIDL = new COM_IDL_connect();

                //对象初始化
                oComIDL.CreateObject(0, 0, 0);
                //oComIDL.CreateObjectEx(0,0, 0, 0);

                oComIDL.SetIDLVariable("File_Directory", File_Directory);
                oComIDL.SetIDLVariable("Date_Time", Date_Time);
                oComIDL.SetIDLVariable("EVF_FileName", EVF_FileName);
                oComIDL.SetIDLVariable("SNOW_FILENAME", SNOW_FILENAME);
                oComIDL.ExecuteString(".compile '" + Pro_Path + "'");
                //string exeStr = Pro_Name + "," + File_Directory + "," + Date_Time + "," + EVF_FileName + "," + SNOW_FILENAME;                
                //string exeStr = Pro_Name;
                //string exeStr = "obj = Obj_New('" + Pro_Name + ",File_Directory,Date_Time,EVF_FileName,SNOW_FILENAME" + ")";

                string exeStr = Pro_ProcessingOrigionData + ", File_Directory, Date_Time, EVF_FileName, SNOW_FILENAME";
                oComIDL.ExecuteString(exeStr);

                OpenRaster(SNOW_FILENAME, _MapControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        // 测试CSharp_Test
        public static string[] Processing_CSharp_Test(string File_Directory, string Date_Time, string OUT_NAME)
        {
            string[] searchResult = null;
            string pro_Path = Application.StartupPath + "\\idl\\" + Pro_CSharp_Test + ".pro";
            if (!File.Exists(pro_Path))
            {
                return searchResult;
            }

            try
            {
                COM_IDL_connectLib.COM_IDL_connect oComIDL = new COM_IDL_connect();
                
                //对象初始化
                oComIDL.CreateObject(0, 0, 0);
                //oComIDL.CreateObjectEx(0,0, 0, 0);

                oComIDL.SetIDLVariable("File_Directory", File_Directory);
                oComIDL.SetIDLVariable("Date_Time", "10011");
                oComIDL.SetIDLVariable("OUT_NAME", OUT_NAME+"\\re10011.tif");
                oComIDL.ExecuteString(".compile '" + pro_Path + "'");

                string exeStr = Pro_CSharp_Test + ", File_Directory, Date_Time,OUT_NAME, Search_Result=Search_Result";
                oComIDL.ExecuteString(exeStr);
                //获取IDL下变量arr
                object Search_Result = oComIDL.GetIDLVariable("Search_Result");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return searchResult;
        }

        public static void Processing_EXCHANGEARRt()
        {
            string IDL_Path = Application.StartupPath + "\\idl\\" + Pro_EXCHANGEARRt + ".pro";
            if (!File.Exists(IDL_Path))
            {
                return;
            }

            try
            {
                COM_IDL_connectLib.COM_IDL_connect oComIDL = new COM_IDL_connect();

                //定义数组
                int[,] dataarr = new int[3, 2] { { 6, 4 }, { 12, 9 }, { 18, 5 } };
                //定义IDL下的变量var，初始值为varInt
                oComIDL.SetIDLVariable("arr", dataarr);
                //编译IDL功能源码
                oComIDL.ExecuteString(".compile '" + IDL_Path+"'");
                oComIDL.ExecuteString("ExchangeArr, arr,oriArr = oriArr");
                //获取IDL下变量arr
                object objArr = oComIDL.GetIDLVariable("arr");
                object objArrOri = oComIDL.GetIDLVariable("oriArr");
                //弹出第一个元素的值
                MessageBox.Show("C#中的数组值为：" + ((Array)objArr).GetValue(0, 0));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //定义栅格打开函数
        private static void OpenRaster(string rasterFileName, AxMapControl _MapControl)
        {
            if(!File.Exists(rasterFileName))
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
    }
}
