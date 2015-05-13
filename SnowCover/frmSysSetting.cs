using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;


namespace SnowCover
{
    public partial class frmSysSetting : Form
    {
        private string iniFilePath = "";
        private DataHandle.INIFile iniFile = null;

        public frmSysSetting()
        {
            InitializeComponent();
        }


        private void frmSysSetting_Load(object sender, EventArgs e)
        {
            iniFilePath = DataHandle.INIFile.GetINIFilePath();
            if (!File.Exists(iniFilePath))
            {
                MessageBox.Show("配置文件丢失，系统将使用默认配置参数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                iniFile = new DataHandle.INIFile(iniFilePath);
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
            if(ApplicateSetting())
            {
                this.Close();
            }            
        }

        private void btn_ApplicationSetting_Click(object sender, EventArgs e)
        {
            ApplicateSetting();
        }
        //加载设置
        private void LoadSetting()
        {
            try
            {
                if (!File.Exists(iniFilePath))
                {
                    MessageBox.Show("配置文件丢失，系统将使用默认配置参数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (iniFile == null)
                {
                    return;
                }
                //获取
                string DataCenterFolder = iniFile.IniReadValue("DataCenter", "DataCenterFolder");
                string OrigionDataFolder = iniFile.IniReadValue("DataCenter", "OrigionDataFolder");
                string BoundaryFilePath = iniFile.IniReadValue("DataCenter", "BoundaryFilePath");
                string PreprocessingSnowCoverFolder = iniFile.IniReadValue("DataCenter", "PreprocessingSnowCoverFolder");
                string EverydaySnowCoverFolder = iniFile.IniReadValue("DataCenter", "EverydaySnowCoverFolder");
                string StatisticSnowCoverFolder = iniFile.IniReadValue("DataCenter", "StatisticSnowCoverFolder");
                string PublishDisasterDoc = iniFile.IniReadValue("DataCenter", "PublishDisasterDoc");

                string DatabaseServerName = iniFile.IniReadValue("DatabaseConn", "DatabaseServerName");
                string DatabaseCatalog = iniFile.IniReadValue("DatabaseConn", "DatabaseCatalog");
                string DatabaseUsername = iniFile.IniReadValue("DatabaseConn", "DatabaseUsername");
                string DatabasePassword = iniFile.IniReadValue("DatabaseConn", "DatabasePassword");

                //设置
                this.txt_DataCenterFolder.Text = DataCenterFolder;
                this.txt_OrigionDataFolder.Text = OrigionDataFolder;
                this.txt_BoundaryFilePath.Text = BoundaryFilePath;
                this.txt_PreprocessingSnowCoverFolder.Text = PreprocessingSnowCoverFolder;
                this.txt_EverydaySnowCoverFolder.Text = EverydaySnowCoverFolder;
                this.txt_StatisticSnowCoverFolder.Text = StatisticSnowCoverFolder;
                this.txt_PublishDisasterDoc.Text = PublishDisasterDoc;

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
            try
            {
                if (iniFile == null)
                {
                    iniFile = new DataHandle.INIFile(iniFilePath);
                }
                //获取配置信息
                string DataCenterFolder = this.txt_DataCenterFolder.Text.Trim();
                string OrigionDataFolder = this.txt_OrigionDataFolder.Text.Trim();
                string BoundaryFilePath = this.txt_BoundaryFilePath.Text.Trim();
                string PreprocessingSnowCoverFolder = this.txt_PreprocessingSnowCoverFolder.Text.Trim();
                string EverydaySnowCoverFolder = this.txt_EverydaySnowCoverFolder.Text.Trim();
                string StatisticSnowCoverFolder = this.txt_StatisticSnowCoverFolder.Text.Trim();
                string PublishDisasterDoc = this.txt_PublishDisasterDoc.Text.Trim();

                string DatabaseServerName = this.txt_DatabaseServerName.Text.Trim();
                string DatabaseCatalog = this.txt_DatabaseCatalog.Text.Trim();
                string DatabaseUsername = this.txt_DatabaseUsername.Text.Trim();
                string DatabasePassword = this.txt_DatabasePassword.Text.Trim();
                //写入配置信息
                iniFile.IniWriteValue("DataCenter", "DataCenterFolder", DataCenterFolder);
                iniFile.IniWriteValue("DataCenter", "OrigionDataFolder", OrigionDataFolder);
                iniFile.IniWriteValue("DataCenter", "BoundaryFilePath", BoundaryFilePath);
                iniFile.IniWriteValue("DataCenter", "PreprocessingSnowCoverFolder", PreprocessingSnowCoverFolder);                
                iniFile.IniWriteValue("DataCenter", "EverydaySnowCoverFolder", EverydaySnowCoverFolder);
                iniFile.IniWriteValue("DataCenter", "StatisticSnowCoverFolder", StatisticSnowCoverFolder);
                iniFile.IniWriteValue("DataCenter", "PublishDisasterDoc", PublishDisasterDoc);

                iniFile.IniWriteValue("DatabaseConn", "DatabaseServerName", DatabaseServerName);
                iniFile.IniWriteValue("DatabaseConn", "DatabaseCatalog", DatabaseCatalog);
                iniFile.IniWriteValue("DatabaseConn", "DatabaseUsername", DatabaseUsername);
                iniFile.IniWriteValue("DatabaseConn", "DatabasePassword", DatabasePassword);
                //创建文件夹                
                if (!CreateFolder(OrigionDataFolder))
                {
                    MessageBox.Show("原始数据目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (!File.Exists(BoundaryFilePath))
                {
                    MessageBox.Show("边界文件不存在，请检查后重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false; ;
                }
                if (!CreateFolder(PreprocessingSnowCoverFolder))
                {
                    MessageBox.Show("影像预处理目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false; ;
                }
                if (!CreateFolder(EverydaySnowCoverFolder))
                {
                    MessageBox.Show("每日积雪数据目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false; ;
                }
                if (!CreateFolder(StatisticSnowCoverFolder))
                {
                    MessageBox.Show("统计积雪数据目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false; ;
                }
                if (!CreateFolder(PublishDisasterDoc))
                {
                    MessageBox.Show("公报灾情文档目录创建失败，请检查权限及路径是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false; ;
                }
            }
            catch
            { }
            return true;
        }
        private void DefaultSetting()
        {
            try
            {
                string startPath = Application.StartupPath;
                this.txt_OrigionDataFolder.Text = startPath + "\\OrigionData";
                this.txt_BoundaryFilePath.Text = startPath + "\\OrigionData\\bou1_4p_.evf";
                this.txt_PreprocessingSnowCoverFolder.Text = startPath + "\\PreprocessingSnowCover";
                this.txt_EverydaySnowCoverFolder.Text = startPath + "\\EverydaySnowCover";
                this.txt_StatisticSnowCoverFolder.Text = startPath + "\\StatisticSnowCover";
                this.txt_PublishDisasterDoc.Text = startPath + "\\PublishDisasterDoc";
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
                    this.txt_OrigionDataFolder.Text = dataCenterFolder + "\\OrigionData";
                    this.txt_BoundaryFilePath.Text = dataCenterFolder + "\\OrigionData\\bou1_4p_.evf";
                    this.txt_PreprocessingSnowCoverFolder.Text = dataCenterFolder + "\\PreprocessingSnowCover";
                    this.txt_EverydaySnowCoverFolder.Text = dataCenterFolder + "\\EverydaySnowCover";
                    this.txt_StatisticSnowCoverFolder.Text = dataCenterFolder + "\\StatisticSnowCover";
                    this.txt_PublishDisasterDoc.Text = dataCenterFolder + "\\PublishDisasterDoc";
                }
            }
            catch
            { }
        }

        private void btn_OpenDataCenterFolder_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_DataCenterFolder);
        }
        //原始数据
        private void btn_SetOrigionDataFolder_Click(object sender, EventArgs e)
        {
            try
            {                
                string dataCenter = this.txt_DataCenterFolder.Text.Trim();
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "设置原始影像目录";
                fbd.ShowNewFolderButton = true;
                if (Directory.Exists(dataCenter))
                {
                    fbd.SelectedPath = dataCenter;
                }
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectFolder = fbd.SelectedPath;
                    this.txt_OrigionDataFolder.Text = selectFolder;
                }
            }
            catch
            { }
        }

        private void btn_OpenOrigionDataFolder_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_OrigionDataFolder);
        }
        //边界文件
        private void btn_SetBoundaryFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                string textPath = this.txt_OrigionDataFolder.Text.Trim();
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "所有文件(*.*) |*.*";
                ofd.Multiselect = false;
                if (Directory.Exists(textPath))
                {
                    ofd.InitialDirectory = textPath;
                }
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectPath = ofd.FileName;
                    this.txt_BoundaryFilePath.Text = selectPath;
                }
            }
            catch
            { }
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
            try
            {
                string dataCenter = this.txt_DataCenterFolder.Text.Trim();
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "设置影像预处理数据目录";
                fbd.ShowNewFolderButton = true;
                if (Directory.Exists(dataCenter))
                {
                    fbd.SelectedPath = dataCenter;
                }
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectFolder = fbd.SelectedPath;
                    this.txt_PreprocessingSnowCoverFolder.Text = selectFolder;
                }
            }
            catch
            { }
        }

        private void btn_OpenPreprocessingSnowCoverFolder_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_PreprocessingSnowCoverFolder);
        }

        //每日积雪
        private void btn_SetEverydaySnowCoverFolder_Click(object sender, EventArgs e)
        {
            try
            {                
                string dataCenter = this.txt_DataCenterFolder.Text.Trim();
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "设置每日积雪数据目录";
                fbd.ShowNewFolderButton = true;
                if (Directory.Exists(dataCenter))
                {
                    fbd.SelectedPath = dataCenter;
                }
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectFolder = fbd.SelectedPath;
                    this.txt_EverydaySnowCoverFolder.Text = selectFolder;
                }
            }
            catch
            { }
        }

        private void btn_OpenEverydaySnowCoverFolder_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_EverydaySnowCoverFolder);
        }
        //统计积雪
        private void btn_SetStatisticSnowCoverFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string dataCenter = this.txt_DataCenterFolder.Text.Trim();
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "设置统计积雪数据目录";
                fbd.ShowNewFolderButton = true;
                if (Directory.Exists(dataCenter))
                {
                    fbd.SelectedPath = dataCenter;
                }
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectFolder = fbd.SelectedPath;
                    this.txt_StatisticSnowCoverFolder.Text = selectFolder;
                }
            }
            catch
            { }
        }

        private void btn_OpenStatisticSnowCoverFolder_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_StatisticSnowCoverFolder);
        }
        //公报灾情
        private void btn_SetPublishDisaster_Click(object sender, EventArgs e)
        {
            try
            {
                string dataCenter = this.txt_DataCenterFolder.Text.Trim();
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "设置原始影像目录";
                fbd.ShowNewFolderButton = true;
                if (Directory.Exists(dataCenter))
                {
                    fbd.SelectedPath = dataCenter;
                }
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectFolder = fbd.SelectedPath;
                    this.txt_PublishDisasterDoc.Text = selectFolder;
                }
            }
            catch
            { }
        }

        private void btn_OpenPublishDisaster_Click(object sender, EventArgs e)
        {
            OpenTextBoxPath(this.txt_PublishDisasterDoc);
        }

        private void OpenTextBoxPath(TextBox _textBox)
        {
            string path = _textBox.Text.Trim();
            if (path == "")
            {
                MessageBox.Show("请先设置数据目录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!Directory.Exists(path))
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
        #endregion

        #region //数据库连接
        private void txt_DatabaseTestConn_Click(object sender, EventArgs e)
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
                DataHandle.MySQL.TestConnection(server, catalog, username, password);
            }
            catch
            { }
        }
        #endregion



    }
}
