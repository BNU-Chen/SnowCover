using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace SystemBase
{
    public class SystemConfig
    {
        private string iniFileName = "setting.ini";

        private string iniFilePath = "";
        private INIFile iniFile = null;

        //配置信息字符串
        private string iniDataCenter = "DataCenter";
        private string iniDataCenterFolder = "DataCenter";
        private string iniOrigionDataFolder = "OrigionData";
        private string iniBoundaryFile = "BoundaryFile";
        private string iniBoundaryFileName = "bou1_4p_.evf";
        private string iniCountyBoundaryFileName = "400W_DLG_WGS84_BOCA_20120920.shp";
        private string iniPreprocessingSnowCoverFolder = "PreprocessingSnowCover";
        private string iniEverydaySnowCoverFolder = "EverydaySnowCover";
        private string iniStatisticSnowCoverFolder = "StatisticSnowCover";
        private string iniPublishDisasterDoc = "PublishDisasterDoc";

        private string iniDatabaseConnnection = "DatabaseConn";
        private string iniDatabaseServerName = "DatabaseServerName";
        private string iniDatabaseCatalog = "snowcover";
        private string iniDatabaseUsername = "DatabaseUsername";
        private string iniDatabasePassword = "DatabasePassword";

        //配置路径
        private string dataCenterFolderPath = "";
        private string origionDataFolderPath = "";
        private string boundaryFilePath = "";
        private string countyBoundaryFilePath = "";
        private string preprocessingSnowCoverFolderPath = "";
        private string everydaySnowCoverFolderPath = "";
        private string statisticSnowCoverFolderPath = "";
        private string publishDisasterDocPath = "";
                
        private string databaseServerName = "";
        private string databaseCatalog = "";
        private string databaseUsername = "";
        private string databasePassword = "";

        //INIFile

        public string IniFileName
        {
            get { return iniFileName; }
            //set { iniFileName = value; }
        }

        public string IniFilePath
        {
            get {

                return Application.StartupPath + "\\" +iniFileName; 
            }
            set { iniFilePath = value; }
        }

        public INIFile IniFile
        {
            get {
                iniFile = new INIFile(IniFilePath);
                return iniFile; 
            }
            set { iniFile = value; }
        }

        //配置文件夹名称
        public string IniDataCenter
        {
            get { return iniDataCenter; }
            //set { iniDataCenter = value; }
        }
        public string IniDataCenterFolder
        {
            get { return iniDataCenterFolder; }
            //set { iniDataCenterFolder = value; }
        }
        public string IniOrigionDataFolder
        {
            get { return iniOrigionDataFolder; }
            //set { iniOrigionDataFolder = value; }
        }
        public string IniBoundaryFile
        {
            get { return iniBoundaryFile; }
            //set { iniBoundaryFile = value; }
        }

        public string IniBoundaryFileName
        {
            get { return iniBoundaryFileName; }
            //set { iniBoundaryFileName = value; }
        }

        public string IniCountyBoundaryFileName
        {
            get { return iniCountyBoundaryFileName; }
            //set { iniBoundaryFileName = value; }
        }

        public string IniPreprocessingSnowCoverFolder
        {
            get { return iniPreprocessingSnowCoverFolder; }
            //set { iniPreprocessingSnowCoverFolder = value; }
        }

        public string IniEverydaySnowCoverFolder
        {
            get { return iniEverydaySnowCoverFolder; }
            //set { iniEverydaySnowCoverFolder = value; }
        }
        public string IniStatisticSnowCoverFolder
        {
            get { return iniStatisticSnowCoverFolder; }
            //set { iniStatisticSnowCoverFolder = value; }
        }
        public string IniPublishDisasterDoc
        {
            get { return iniPublishDisasterDoc; }
            //set { iniPublishDisasterDoc = value; }
        }


        //设置、获取文件夹路径
        
        public string DataCenterFolderPath
        {
            get { 
                dataCenterFolderPath = IniFile.IniReadValue(iniDataCenter, iniDataCenterFolder);
                return dataCenterFolderPath;
            }
            set { 
                dataCenterFolderPath = value;
                IniFile.IniWriteValue(iniDataCenter, iniDataCenterFolder, dataCenterFolderPath);
            }
        }

        public string OrigionDataFolderPath
        {            
            get { 
                origionDataFolderPath = IniFile.IniReadValue(iniDataCenter, iniOrigionDataFolder);
                return origionDataFolderPath;
            }
            set { 
                origionDataFolderPath = value;
                IniFile.IniWriteValue(iniDataCenter, iniOrigionDataFolder, origionDataFolderPath);
            }
        }

        public string BoundaryFilePath
        {
            get { 
                boundaryFilePath = IniFile.IniReadValue(iniDataCenter, iniBoundaryFile);
                return boundaryFilePath;
            }
            set { 
                boundaryFilePath = value;
                IniFile.IniWriteValue(iniDataCenter, iniBoundaryFile, boundaryFilePath);
            }
        }

        public string CountyBoundaryFilePath
        {
            get
            {
                countyBoundaryFilePath = IniFile.IniReadValue(iniDataCenter, iniOrigionDataFolder) + "\\" + iniCountyBoundaryFileName;
                return countyBoundaryFilePath;
            }
            set
            {
                countyBoundaryFilePath = value;
                //IniFile.IniWriteValue(iniDataCenter, iniOrigionDataFolder, countyBoundaryFilePath);
            }
        }

        public string PreprocessingSnowCoverFolderPath
        {
            get { 
                preprocessingSnowCoverFolderPath = IniFile.IniReadValue(iniDataCenter, iniPreprocessingSnowCoverFolder);
                return preprocessingSnowCoverFolderPath;
            }
            set { 
                preprocessingSnowCoverFolderPath = value;
                IniFile.IniWriteValue(iniDataCenter, iniPreprocessingSnowCoverFolder, preprocessingSnowCoverFolderPath);
            }
        }

        public string EverydaySnowCoverFolderPath
        {
            get { 
                everydaySnowCoverFolderPath = IniFile.IniReadValue(iniDataCenter, iniEverydaySnowCoverFolder);
                return everydaySnowCoverFolderPath;
            }
            set { 
                everydaySnowCoverFolderPath = value;
                IniFile.IniWriteValue(iniDataCenter, iniEverydaySnowCoverFolder, everydaySnowCoverFolderPath);
            }
        }

        public string StatisticSnowCoverFolderPath
        {
            get { 
                statisticSnowCoverFolderPath = IniFile.IniReadValue(iniDataCenter, iniStatisticSnowCoverFolder);
                return statisticSnowCoverFolderPath;
            }
            set { 
                statisticSnowCoverFolderPath = value;
                IniFile.IniWriteValue(iniDataCenter, iniStatisticSnowCoverFolder, statisticSnowCoverFolderPath);
            }
        }

        public string PublishDisasterDocPath
        {
            get { 
                publishDisasterDocPath = IniFile.IniReadValue(iniDataCenter, iniPublishDisasterDoc);
                return publishDisasterDocPath;
            }
            set { 
                publishDisasterDocPath = value;
                IniFile.IniWriteValue(iniDataCenter, iniPublishDisasterDoc, publishDisasterDocPath);
            }
        }
        

        public string DatabaseServerName
        {
            get {
                databaseServerName = IniFile.IniReadValue(iniDatabaseConnnection, iniDatabaseServerName);
                return databaseServerName;
            }
            set { 
                databaseServerName = value;
                IniFile.IniWriteValue(iniDatabaseConnnection, iniDatabaseServerName, databaseServerName);
            }
        }
        public string DatabaseCatalog
        {
            get { 
                databaseCatalog = IniFile.IniReadValue(iniDatabaseConnnection, iniDatabaseCatalog);
                return databaseCatalog;
            }
            set { 
                databaseCatalog = value;
                IniFile.IniWriteValue(iniDatabaseConnnection, iniDatabaseCatalog, databaseCatalog);
            }
        }
        public string DatabaseUsername
        {
            get {
                databaseUsername = IniFile.IniReadValue(iniDatabaseConnnection, iniDatabaseUsername);
                return databaseUsername;
            }
            set { 
                databaseUsername = value;
                IniFile.IniWriteValue(iniDatabaseConnnection, iniDatabaseUsername, databaseUsername);
            }
        }

        public string DatabasePassword
        {
            get {
                databasePassword = IniFile.IniReadValue(iniDatabaseConnnection, iniDatabasePassword);
                return databasePassword;
            }
            set { 
                databasePassword = value;
                IniFile.IniWriteValue(iniDatabaseConnnection, iniDatabasePassword, databasePassword);
            }
        }

    }
}
