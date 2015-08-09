using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using SystemBase;


namespace SnowCover
{
    public partial class frmSysSetting : Form
    {        
        private SystemBase.SystemConfig config = null;

        public frmSysSetting()
        {
            InitializeComponent();
            config = new SystemConfig();
        }


        private void frmSysSetting_Load(object sender, EventArgs e)
        {            
            if (config.IniFile == null)
            {
                MessageBox.Show("配置文件丢失，请检查系统根目录“"+config.IniFileName+"”文件是否存在。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }
            else
            {                
                LoadSetting();
            }
        }

        #region //应用、确定、取消、默认 按钮事件
        private void btn_DefaultSetting_Click(object sender, EventArgs e)
        {
            DefaultSetting();
        }

        private void btn_CancelSetting_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_SubmitSetting_Click(object sender, EventArgs e)
        {
            ApplicateSetting();
            this.Close();
        }

        private void btn_ApplicationSetting_Click(object sender, EventArgs e)
        {
            ApplicateSetting();
        }
        #endregion

        #region //加载设置 应用设置
        //加载设置
        private void LoadSetting()
        {
            try
            {
                if (config.IniFile == null)
                {
                    MessageBox.Show("配置文件丢失，系统将使用默认配置参数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                //获取
                string DataCenterFolder = config.DataCenterFolderPath;
                string OrigionDataFolder = config.OrigionDataFolderPath;
                string BoundaryFilePath = config.BoundaryFilePath;
                string PreprocessingSnowCoverFolder = config.PreprocessingSnowCoverFolderPath;
                string EverydaySnowCoverFolder = config.EverydaySnowCoverFolderPath;
                string StatisticSnowCoverFolder = config.StatisticSnowCoverFolderPath;
                string PublishDisasterDoc = config.PublishDisasterDocPath;
                string MapDocs = config.MapDocsPath;
                string CountyMapPath = config.CountyMapPath;
                string CountyMapJoinTable = config.CountyMapJoinTablePath;
                

                string DatabaseServerName = config.DatabaseServerName;
                string DatabaseCatalog = config.DatabaseCatalog;
                string DatabaseUsername = config.DatabaseUsername;
                string DatabasePassword = config.DatabasePassword;

                //设置
                this.txt_DataCenterFolder.Text = DataCenterFolder;
                this.txt_OrigionDataFolder.Text = OrigionDataFolder;
                this.txt_BoundaryFilePath.Text = BoundaryFilePath;
                this.txt_PreprocessingSnowCoverFolder.Text = PreprocessingSnowCoverFolder;
                this.txt_EverydaySnowCoverFolder.Text = EverydaySnowCoverFolder;
                this.txt_StatisticSnowCoverFolder.Text = StatisticSnowCoverFolder;
                this.txt_PublishDisasterDoc.Text = PublishDisasterDoc;
                this.txt_MapDocs.Text = MapDocs;
                this.txt_CountyMapPath.Text = CountyMapPath;
                this.txt_CountyMapJoinMapName.Text = CountyMapJoinTable;

                this.txt_DatabaseServerName.Text = DatabaseServerName;
                this.txt_DatabaseCatalog.Text = DatabaseCatalog;
                this.txt_DatabaseUsername.Text = DatabaseUsername;
                this.txt_DatabasePassword.Text = DatabasePassword;

            }
            catch
            { }
        }
        //应用设置
        private bool ApplicateSetting()
        {
            bool flag = true;
            try
            {
                if (config.IniFile == null)
                {
                    config.IniFile = new SystemBase.INIFile(config.IniFilePath);
                }
                //获取配置信息
                string DataCenterFolder = this.txt_DataCenterFolder.Text.Trim();
                string OrigionDataFolder = this.txt_OrigionDataFolder.Text.Trim();
                string BoundaryFilePath = this.txt_BoundaryFilePath.Text.Trim();
                string PreprocessingSnowCoverFolder = this.txt_PreprocessingSnowCoverFolder.Text.Trim();
                string EverydaySnowCoverFolder = this.txt_EverydaySnowCoverFolder.Text.Trim();
                string StatisticSnowCoverFolder = this.txt_StatisticSnowCoverFolder.Text.Trim();
                string PublishDisasterDoc = this.txt_PublishDisasterDoc.Text.Trim();
                string MapDocs = this.txt_MapDocs.Text.Trim();
                string CountyMapPath = this.txt_CountyMapPath.Text.Trim();
                string CountyMapJoinTablePath = this.txt_CountyMapJoinMapName.Text.Trim();

                string DatabaseServerName = this.txt_DatabaseServerName.Text.Trim();
                string DatabaseCatalog = this.txt_DatabaseCatalog.Text.Trim();
                string DatabaseUsername = this.txt_DatabaseUsername.Text.Trim();
                string DatabasePassword = this.txt_DatabasePassword.Text.Trim();
                //写入配置信息
                config.DataCenterFolderPath = DataCenterFolder;
                config.OrigionDataFolderPath = OrigionDataFolder;
                config.BoundaryFilePath = BoundaryFilePath;
                config.PreprocessingSnowCoverFolderPath = PreprocessingSnowCoverFolder;
                config.EverydaySnowCoverFolderPath = EverydaySnowCoverFolder;
                config.StatisticSnowCoverFolderPath = StatisticSnowCoverFolder;
                config.PublishDisasterDocPath = PublishDisasterDoc;
                config.MapDocsPath = MapDocs;
                config.CountyMapPath = CountyMapPath;
                config.CountyMapJoinTablePath = CountyMapJoinTablePath;
                

                config.DatabaseServerName = DatabaseServerName;
                config.DatabaseCatalog = DatabaseCatalog;
                config.DatabaseUsername = DatabaseUsername;
                config.DatabasePassword = DatabasePassword;
                                
                //创建文件夹                
                if (!CreateFolder(OrigionDataFolder))
                {
                    MessageBox.Show("原始数据目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = false;
                }
                if (!File.Exists(BoundaryFilePath))
                {
                    MessageBox.Show("边界文件不存在，请检查后重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = false; ;
                }
                if (!CreateFolder(PreprocessingSnowCoverFolder))
                {
                    MessageBox.Show("影像预处理目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = false; ;
                }
                if (!CreateFolder(EverydaySnowCoverFolder))
                {
                    MessageBox.Show("每日积雪数据目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = false; ;
                }
                if (!CreateFolder(StatisticSnowCoverFolder))
                {
                    MessageBox.Show("统计积雪数据目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = false; ;
                }
                if (!CreateFolder(PublishDisasterDoc))
                {
                    MessageBox.Show("公报灾情文档目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = false; ;
                }
                if (!CreateFolder(MapDocs))
                {
                    MessageBox.Show("地图文档目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = false; ;
                }
            }
            catch
            { }
            return flag;
        }
        private void DefaultSetting()
        {
            try
            {
                string startPath = Application.StartupPath;
                this.txt_OrigionDataFolder.Text = startPath + "\\"+config.IniOrigionDataFolder;
                this.txt_BoundaryFilePath.Text = startPath + "\\" + config.IniOrigionDataFolder + "\\" + config.IniBoundaryFileName;
                this.txt_PreprocessingSnowCoverFolder.Text = startPath + "\\"+config.IniPreprocessingSnowCoverFolder;
                this.txt_EverydaySnowCoverFolder.Text = startPath + "\\"+config.IniEverydaySnowCoverFolder;
                this.txt_StatisticSnowCoverFolder.Text = startPath + "\\"+config.IniStatisticSnowCoverFolder;
                this.txt_PublishDisasterDoc.Text = startPath + "\\"+config.IniPublishDisasterDoc;
                this.txt_MapDocs.Text = startPath + "\\" + config.IniMapDocs;
                this.txt_MapDocs.Text = startPath + "\\" + config.IniMapDocs;
                this.txt_CountyMapPath.Text = startPath + "\\" + config.IniMapDocs + "\\" + config.IniCountyMap + ".mxd";
                this.txt_CountyMapJoinMapName.Text = startPath + "\\" + config.IniMapDocs + "\\" + config.IniCountyMap + ".csv";
            }
            catch
            { }
        }

        private bool CreateFolder(string path)
        {
            bool isSuccess = true;
            try
            {
                if(Directory.Exists(path))
                {
                    isSuccess = true;
                }
                else
                {

                    try
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        isSuccess = false;
                    }
                    
                }
            }
            catch 
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        #endregion

        #region //设置数据中心目录
        //数据中心
        private void btn_SetDataCenterFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string textPath = this.txt_OrigionDataFolder.Text.Trim();
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "设置数据中心目录";
                fbd.ShowNewFolderButton = true;
                if (Directory.Exists(textPath))
                {
                    fbd.SelectedPath = textPath;
                }
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string dataCenterFolder = fbd.SelectedPath;
                    this.txt_DataCenterFolder.Text = dataCenterFolder;

                    //设置其他文件夹
                    //this.txt_OrigionDataFolder.Text = dataCenterFolder + "\\OrigionData";
                    //this.txt_BoundaryFilePath.Text = dataCenterFolder + "\\OrigionData\\bou1_4p_.evf";
                    //this.txt_PreprocessingSnowCoverFolder.Text = dataCenterFolder + "\\PreprocessingSnowCover";
                    //this.txt_EverydaySnowCoverFolder.Text = dataCenterFolder + "\\EverydaySnowCover";
                    //this.txt_StatisticSnowCoverFolder.Text = dataCenterFolder + "\\StatisticSnowCover";
                    //this.txt_PublishDisasterDoc.Text = dataCenterFolder + "\\PublishDisasterDoc";

                    this.txt_OrigionDataFolder.Text = dataCenterFolder + "\\" + config.IniOrigionDataFolder;
                    this.txt_BoundaryFilePath.Text = dataCenterFolder + "\\" + config.IniOrigionDataFolder + "\\" + config.IniBoundaryFileName;
                    this.txt_PreprocessingSnowCoverFolder.Text = dataCenterFolder + "\\" + config.IniPreprocessingSnowCoverFolder;
                    this.txt_EverydaySnowCoverFolder.Text = dataCenterFolder + "\\" + config.IniEverydaySnowCoverFolder;
                    this.txt_StatisticSnowCoverFolder.Text = dataCenterFolder + "\\" + config.IniStatisticSnowCoverFolder;
                    this.txt_PublishDisasterDoc.Text = dataCenterFolder + "\\" + config.IniPublishDisasterDoc;
                    this.txt_MapDocs.Text = dataCenterFolder + "\\" + config.IniMapDocs;
                    this.txt_CountyMapPath.Text = dataCenterFolder + "\\" + config.IniMapDocs+"\\"+config.IniCountyMap+".mxd";
                    this.txt_CountyMapJoinMapName.Text = dataCenterFolder + "\\" + config.IniMapDocs + "\\" + config.IniCountyMap + ".csv";
                }
            }
            catch
            { }
        }
        private void btn_OpenDataCenterFolder_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_DataCenterFolder, true);
        }
        //原始数据
        private void btn_SetOrigionDataFolder_Click(object sender, EventArgs e)
        {
            SetFolderPathInTextBox(this.txt_OrigionDataFolder, "设置原始影像目录");
        }

        private void btn_OpenOrigionDataFolder_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_OrigionDataFolder, true);
        }
        //边界文件
        private void btn_SetBoundaryFilePath_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_BoundaryFilePath);
            
        }

        private void btn_OpenBoundaryFilePath_Click(object sender, EventArgs e)
        {
            string path = this.txt_OrigionDataFolder.Text.Trim();
            if (path == "")
            {
                MessageBox.Show("请先设置数据目录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!Directory.Exists(path))
            {
                MessageBox.Show("设置的数据目录不存在，请检查。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                try
                {
                    string DataCenterFolder = this.txt_DataCenterFolder.Text.Trim();
                    if (Directory.Exists(DataCenterFolder))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", DataCenterFolder);
                    }                    
                }
                catch
                {
                    
                }
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", path);
                }
                catch
                { }
            }
        }

        //影像预处理目录
        private void btn_SetPreprocessingSnowCoverFolder_Click(object sender, EventArgs e)
        {
            SetFolderPathInTextBox(this.txt_PreprocessingSnowCoverFolder, "设置影像预处理数据目录");
        }

        private void btn_OpenPreprocessingSnowCoverFolder_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_PreprocessingSnowCoverFolder, true);
        }

        //每日积雪
        private void btn_SetEverydaySnowCoverFolder_Click(object sender, EventArgs e)
        {
            SetFolderPathInTextBox(this.txt_EverydaySnowCoverFolder, "设置每日积雪数据目录");
        }

        private void btn_OpenEverydaySnowCoverFolder_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_EverydaySnowCoverFolder, true);
        }
        //统计积雪
        private void btn_SetStatisticSnowCoverFolder_Click(object sender, EventArgs e)
        {
            SetFolderPathInTextBox(this.txt_StatisticSnowCoverFolder, "设置统计积雪数据目录");
        }

        private void btn_OpenStatisticSnowCoverFolder_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_StatisticSnowCoverFolder, true);
        }
        //公报灾情
        private void btn_SetPublishDisaster_Click(object sender, EventArgs e)
        {
            SetFolderPathInTextBox(this.txt_PublishDisasterDoc, "设置原始影像目录");
        }

        private void btn_OpenPublishDisaster_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_PublishDisasterDoc, true);
        }

        //地图文档
        private void btn_OpenMapDocs_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_MapDocs, true);
        }

        private void btn_SetMapDocs_Click(object sender, EventArgs e)
        {
            SetFolderPathInTextBox(this.txt_MapDocs, "设置地图文档目录");
        }
        //积雪覆盖统计地图
        private void btn_SetCountyMap_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_CountyMapPath);
            //联动修改jointable的路径
            string countyMapPath = this.txt_CountyMapPath.Text;
            if(File.Exists(countyMapPath))
            {
                string parentFolder = Path.GetDirectoryName(countyMapPath);
                string mxdName = Path.GetFileNameWithoutExtension(countyMapPath);
                this.txt_CountyMapJoinMapName.Text = parentFolder + "\\" + mxdName + ".csv";
            }
        }

        private void btn_OpenCountyMap_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_CountyMapPath, false);
        }

        private void btn_SetCountyMapJoinTable_Click(object sender, EventArgs e)
        {
            SetFilePath(this.txt_CountyMapJoinMapName);
        }

        private void btn_OpenCountyMapJoinTable_Click(object sender, EventArgs e)
        {
            string path = this.txt_CountyMapPath.Text.Trim()+"\\" +this.txt_CountyMapJoinMapName.Text.Trim();           
            try
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show("文件不存在，请检查。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
            catch
            { }
        }


        //通用函数
        //打开TextBox中的文件夹
        private void OpenTextBoxPath(TextBox _textBox,bool isDirectory)
        {
            string path = _textBox.Text.Trim();
            if (path == "")
            {
                MessageBox.Show("请先设置数据目录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (isDirectory)
            {
                if (!Directory.Exists(path))
                {
                    if (MessageBox.Show("设置的数据目录不存在，请检查，是否现在创建？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            Directory.CreateDirectory(path);
                            System.Diagnostics.Process.Start("explorer.exe", path);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("创建目录失败，请检查安全权限和路径后重试。\n" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    try
                    {
                        System.Diagnostics.Process.Start("explorer.exe", path);
                    }
                    catch
                    { }
                }
            }
            else
            {
                try
                {
                    if (!File.Exists(path))
                    {
                        MessageBox.Show("文件不存在，请检查。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    System.Diagnostics.Process.Start("explorer.exe", path);
                }
                catch
                { }
            }
        }

        private void SetFilePath(TextBox setTextBox)
        {
            try
            {
                string originPath = setTextBox.Text.Trim();
                string textPath = "";
                if (File.Exists(originPath))
                {
                    textPath = Path.GetDirectoryName(originPath);
                }
                else
                {
                    textPath = this.txt_DataCenterFolder.Text.Trim();
                }
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "所有文件(*.*) |*.*";
                ofd.Multiselect = false;
                if (textPath != "")
                {
                    ofd.InitialDirectory = textPath;
                }
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectPath = ofd.FileName;
                    setTextBox.Text = selectPath;
                }
            }
            catch
            { }
        }
        private void SetFolderPathInTextBox(TextBox txtBox,string title)
        {
            try
            {
                string dataCenter = this.txt_DataCenterFolder.Text.Trim();
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = title;
                fbd.ShowNewFolderButton = true;
                if (Directory.Exists(dataCenter))
                {
                    fbd.SelectedPath = dataCenter;
                }
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectFolder = fbd.SelectedPath;
                    txtBox.Text = selectFolder;
                }
            }
            catch
            { }
        }
        #endregion

        #region //数据库连接
        private void btn_DatabaseTestConnection_Click(object sender, EventArgs e)
        {
            string server = this.txt_DatabaseServerName.Text.Trim();
            string catalog = this.txt_DatabaseCatalog.Text.Trim();
            string username = this.txt_DatabaseUsername.Text.Trim();
            string password = this.txt_DatabasePassword.Text.Trim();

            try
            {
                if (server == "" || catalog == "" || username == "")
                {
                    MessageBox.Show("请将数据库信息填写完整,", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MySql.Data.MySqlClient.MySqlConnection mysqlConn =  SystemBase.MySQL.TestConnection(server, catalog, username, password);                
            }
            catch
            { }
        }
        #endregion
        
    }
}
