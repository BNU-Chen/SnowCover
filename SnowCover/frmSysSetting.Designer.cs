namespace SnowCover
{
    partial class frmSysSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btn_CancelSetting = new System.Windows.Forms.Button();
            this.btn_SubmitSetting = new System.Windows.Forms.Button();
            this.btn_ApplicationSetting = new System.Windows.Forms.Button();
            this.btn_DefaultSetting = new System.Windows.Forms.Button();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_DatabaseTestConn = new System.Windows.Forms.Button();
            this.txt_DatabasePassword = new System.Windows.Forms.TextBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txt_DatabaseUsername = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txt_DatabaseCatalog = new System.Windows.Forms.TextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_DatabaseServerName = new System.Windows.Forms.TextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_OpenPublishDisaster = new System.Windows.Forms.Button();
            this.btn_OpenEverydaySnowCoverFolder = new System.Windows.Forms.Button();
            this.btn_OpenStatisticSnowCoverFolder = new System.Windows.Forms.Button();
            this.btn_OpenBoundaryFilePath = new System.Windows.Forms.Button();
            this.btn_OpenOrigionDataFolder = new System.Windows.Forms.Button();
            this.btn_SetPublishDisaster = new System.Windows.Forms.Button();
            this.btn_SetEverydaySnowCoverFolder = new System.Windows.Forms.Button();
            this.btn_SetStatisticSnowCoverFolder = new System.Windows.Forms.Button();
            this.btn_SetBoundaryFilePath = new System.Windows.Forms.Button();
            this.btn_SetOrigionDataFolder = new System.Windows.Forms.Button();
            this.txt_PublishDisasterDoc = new System.Windows.Forms.TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_EverydaySnowCoverFolder = new System.Windows.Forms.TextBox();
            this.txt_StatisticSnowCoverFolder = new System.Windows.Forms.TextBox();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_BoundaryFilePath = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_OrigionDataFolder = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_OpenDataCenterFolder = new System.Windows.Forms.Button();
            this.btn_SetDataCenterFolder = new System.Windows.Forms.Button();
            this.txt_DataCenterFolder = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txt_PreprocessingSnowCoverFolder = new System.Windows.Forms.TextBox();
            this.btn_SetPreprocessingSnowCoverFolder = new System.Windows.Forms.Button();
            this.btn_OpenPreprocessingSnowCoverFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(584, 462);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btn_CancelSetting);
            this.xtraTabPage1.Controls.Add(this.btn_SubmitSetting);
            this.xtraTabPage1.Controls.Add(this.btn_ApplicationSetting);
            this.xtraTabPage1.Controls.Add(this.btn_DefaultSetting);
            this.xtraTabPage1.Controls.Add(this.labelControl10);
            this.xtraTabPage1.Controls.Add(this.groupBox2);
            this.xtraTabPage1.Controls.Add(this.groupBox1);
            this.xtraTabPage1.Controls.Add(this.btn_OpenDataCenterFolder);
            this.xtraTabPage1.Controls.Add(this.btn_SetDataCenterFolder);
            this.xtraTabPage1.Controls.Add(this.txt_DataCenterFolder);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(578, 433);
            this.xtraTabPage1.Text = "数据中心";
            // 
            // btn_CancelSetting
            // 
            this.btn_CancelSetting.Location = new System.Drawing.Point(329, 403);
            this.btn_CancelSetting.Name = "btn_CancelSetting";
            this.btn_CancelSetting.Size = new System.Drawing.Size(75, 23);
            this.btn_CancelSetting.TabIndex = 7;
            this.btn_CancelSetting.Text = "取消";
            this.btn_CancelSetting.UseVisualStyleBackColor = true;
            this.btn_CancelSetting.Click += new System.EventHandler(this.btn_CancelSetting_Click);
            // 
            // btn_SubmitSetting
            // 
            this.btn_SubmitSetting.Location = new System.Drawing.Point(410, 403);
            this.btn_SubmitSetting.Name = "btn_SubmitSetting";
            this.btn_SubmitSetting.Size = new System.Drawing.Size(75, 23);
            this.btn_SubmitSetting.TabIndex = 7;
            this.btn_SubmitSetting.Text = "确定";
            this.btn_SubmitSetting.UseVisualStyleBackColor = true;
            this.btn_SubmitSetting.Click += new System.EventHandler(this.btn_SubmitSetting_Click);
            // 
            // btn_ApplicationSetting
            // 
            this.btn_ApplicationSetting.Location = new System.Drawing.Point(491, 403);
            this.btn_ApplicationSetting.Name = "btn_ApplicationSetting";
            this.btn_ApplicationSetting.Size = new System.Drawing.Size(75, 23);
            this.btn_ApplicationSetting.TabIndex = 7;
            this.btn_ApplicationSetting.Text = "应用";
            this.btn_ApplicationSetting.UseVisualStyleBackColor = true;
            this.btn_ApplicationSetting.Click += new System.EventHandler(this.btn_ApplicationSetting_Click);
            // 
            // btn_DefaultSetting
            // 
            this.btn_DefaultSetting.Location = new System.Drawing.Point(192, 400);
            this.btn_DefaultSetting.Name = "btn_DefaultSetting";
            this.btn_DefaultSetting.Size = new System.Drawing.Size(75, 23);
            this.btn_DefaultSetting.TabIndex = 6;
            this.btn_DefaultSetting.Text = "默认设置";
            this.btn_DefaultSetting.UseVisualStyleBackColor = true;
            this.btn_DefaultSetting.Click += new System.EventHandler(this.btn_DefaultSetting_Click);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(18, 403);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(168, 14);
            this.labelControl10.TabIndex = 5;
            this.labelControl10.Text = "有些设置需要重启软件以生效。";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_DatabaseTestConn);
            this.groupBox2.Controls.Add(this.txt_DatabasePassword);
            this.groupBox2.Controls.Add(this.labelControl9);
            this.groupBox2.Controls.Add(this.txt_DatabaseUsername);
            this.groupBox2.Controls.Add(this.labelControl8);
            this.groupBox2.Controls.Add(this.txt_DatabaseCatalog);
            this.groupBox2.Controls.Add(this.labelControl7);
            this.groupBox2.Controls.Add(this.txt_DatabaseServerName);
            this.groupBox2.Controls.Add(this.labelControl6);
            this.groupBox2.Location = new System.Drawing.Point(11, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 82);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "关系数据库设置";
            // 
            // txt_DatabaseTestConn
            // 
            this.txt_DatabaseTestConn.Location = new System.Drawing.Point(473, 48);
            this.txt_DatabaseTestConn.Name = "txt_DatabaseTestConn";
            this.txt_DatabaseTestConn.Size = new System.Drawing.Size(75, 23);
            this.txt_DatabaseTestConn.TabIndex = 2;
            this.txt_DatabaseTestConn.Text = "测试连接";
            this.txt_DatabaseTestConn.UseVisualStyleBackColor = true;
            this.txt_DatabaseTestConn.Click += new System.EventHandler(this.txt_DatabaseTestConn_Click);
            // 
            // txt_DatabasePassword
            // 
            this.txt_DatabasePassword.Location = new System.Drawing.Point(319, 50);
            this.txt_DatabasePassword.Name = "txt_DatabasePassword";
            this.txt_DatabasePassword.PasswordChar = '*';
            this.txt_DatabasePassword.Size = new System.Drawing.Size(130, 21);
            this.txt_DatabasePassword.TabIndex = 1;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(262, 53);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(48, 14);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "密   码：";
            // 
            // txt_DatabaseUsername
            // 
            this.txt_DatabaseUsername.Location = new System.Drawing.Point(319, 20);
            this.txt_DatabaseUsername.Name = "txt_DatabaseUsername";
            this.txt_DatabaseUsername.Size = new System.Drawing.Size(130, 21);
            this.txt_DatabaseUsername.TabIndex = 1;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(262, 23);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(48, 14);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "用户名：";
            // 
            // txt_DatabaseCatalog
            // 
            this.txt_DatabaseCatalog.Location = new System.Drawing.Point(92, 50);
            this.txt_DatabaseCatalog.Name = "txt_DatabaseCatalog";
            this.txt_DatabaseCatalog.Size = new System.Drawing.Size(144, 21);
            this.txt_DatabaseCatalog.TabIndex = 1;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(7, 53);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 14);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "数据库名称：";
            // 
            // txt_DatabaseServerName
            // 
            this.txt_DatabaseServerName.Location = new System.Drawing.Point(92, 20);
            this.txt_DatabaseServerName.Name = "txt_DatabaseServerName";
            this.txt_DatabaseServerName.Size = new System.Drawing.Size(144, 21);
            this.txt_DatabaseServerName.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(7, 23);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(72, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "服务器名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_OpenPublishDisaster);
            this.groupBox1.Controls.Add(this.btn_OpenPreprocessingSnowCoverFolder);
            this.groupBox1.Controls.Add(this.btn_OpenEverydaySnowCoverFolder);
            this.groupBox1.Controls.Add(this.btn_OpenStatisticSnowCoverFolder);
            this.groupBox1.Controls.Add(this.btn_OpenBoundaryFilePath);
            this.groupBox1.Controls.Add(this.btn_OpenOrigionDataFolder);
            this.groupBox1.Controls.Add(this.btn_SetPublishDisaster);
            this.groupBox1.Controls.Add(this.btn_SetPreprocessingSnowCoverFolder);
            this.groupBox1.Controls.Add(this.btn_SetEverydaySnowCoverFolder);
            this.groupBox1.Controls.Add(this.btn_SetStatisticSnowCoverFolder);
            this.groupBox1.Controls.Add(this.btn_SetBoundaryFilePath);
            this.groupBox1.Controls.Add(this.btn_SetOrigionDataFolder);
            this.groupBox1.Controls.Add(this.txt_PublishDisasterDoc);
            this.groupBox1.Controls.Add(this.txt_PreprocessingSnowCoverFolder);
            this.groupBox1.Controls.Add(this.labelControl5);
            this.groupBox1.Controls.Add(this.txt_EverydaySnowCoverFolder);
            this.groupBox1.Controls.Add(this.labelControl12);
            this.groupBox1.Controls.Add(this.txt_StatisticSnowCoverFolder);
            this.groupBox1.Controls.Add(this.labelControl11);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.txt_BoundaryFilePath);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.txt_OrigionDataFolder);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Location = new System.Drawing.Point(11, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 220);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据目录设置";
            // 
            // btn_OpenPublishDisaster
            // 
            this.btn_OpenPublishDisaster.Location = new System.Drawing.Point(517, 186);
            this.btn_OpenPublishDisaster.Name = "btn_OpenPublishDisaster";
            this.btn_OpenPublishDisaster.Size = new System.Drawing.Size(38, 23);
            this.btn_OpenPublishDisaster.TabIndex = 5;
            this.btn_OpenPublishDisaster.Text = "打开";
            this.btn_OpenPublishDisaster.UseVisualStyleBackColor = true;
            this.btn_OpenPublishDisaster.Click += new System.EventHandler(this.btn_OpenPublishDisaster_Click);
            // 
            // btn_OpenEverydaySnowCoverFolder
            // 
            this.btn_OpenEverydaySnowCoverFolder.Location = new System.Drawing.Point(517, 120);
            this.btn_OpenEverydaySnowCoverFolder.Name = "btn_OpenEverydaySnowCoverFolder";
            this.btn_OpenEverydaySnowCoverFolder.Size = new System.Drawing.Size(38, 23);
            this.btn_OpenEverydaySnowCoverFolder.TabIndex = 5;
            this.btn_OpenEverydaySnowCoverFolder.Text = "打开";
            this.btn_OpenEverydaySnowCoverFolder.UseVisualStyleBackColor = true;
            this.btn_OpenEverydaySnowCoverFolder.Click += new System.EventHandler(this.btn_OpenEverydaySnowCoverFolder_Click);
            // 
            // btn_OpenStatisticSnowCoverFolder
            // 
            this.btn_OpenStatisticSnowCoverFolder.Location = new System.Drawing.Point(517, 153);
            this.btn_OpenStatisticSnowCoverFolder.Name = "btn_OpenStatisticSnowCoverFolder";
            this.btn_OpenStatisticSnowCoverFolder.Size = new System.Drawing.Size(38, 23);
            this.btn_OpenStatisticSnowCoverFolder.TabIndex = 5;
            this.btn_OpenStatisticSnowCoverFolder.Text = "打开";
            this.btn_OpenStatisticSnowCoverFolder.UseVisualStyleBackColor = true;
            this.btn_OpenStatisticSnowCoverFolder.Click += new System.EventHandler(this.btn_OpenStatisticSnowCoverFolder_Click);
            // 
            // btn_OpenBoundaryFilePath
            // 
            this.btn_OpenBoundaryFilePath.Location = new System.Drawing.Point(517, 55);
            this.btn_OpenBoundaryFilePath.Name = "btn_OpenBoundaryFilePath";
            this.btn_OpenBoundaryFilePath.Size = new System.Drawing.Size(38, 23);
            this.btn_OpenBoundaryFilePath.TabIndex = 5;
            this.btn_OpenBoundaryFilePath.Text = "打开";
            this.btn_OpenBoundaryFilePath.UseVisualStyleBackColor = true;
            this.btn_OpenBoundaryFilePath.Click += new System.EventHandler(this.btn_OpenBoundaryFilePath_Click);
            // 
            // btn_OpenOrigionDataFolder
            // 
            this.btn_OpenOrigionDataFolder.Location = new System.Drawing.Point(517, 22);
            this.btn_OpenOrigionDataFolder.Name = "btn_OpenOrigionDataFolder";
            this.btn_OpenOrigionDataFolder.Size = new System.Drawing.Size(38, 23);
            this.btn_OpenOrigionDataFolder.TabIndex = 5;
            this.btn_OpenOrigionDataFolder.Text = "打开";
            this.btn_OpenOrigionDataFolder.UseVisualStyleBackColor = true;
            this.btn_OpenOrigionDataFolder.Click += new System.EventHandler(this.btn_OpenOrigionDataFolder_Click);
            // 
            // btn_SetPublishDisaster
            // 
            this.btn_SetPublishDisaster.Location = new System.Drawing.Point(473, 186);
            this.btn_SetPublishDisaster.Name = "btn_SetPublishDisaster";
            this.btn_SetPublishDisaster.Size = new System.Drawing.Size(38, 23);
            this.btn_SetPublishDisaster.TabIndex = 6;
            this.btn_SetPublishDisaster.Text = "浏览";
            this.btn_SetPublishDisaster.UseVisualStyleBackColor = true;
            this.btn_SetPublishDisaster.Click += new System.EventHandler(this.btn_SetPublishDisaster_Click);
            // 
            // btn_SetEverydaySnowCoverFolder
            // 
            this.btn_SetEverydaySnowCoverFolder.Location = new System.Drawing.Point(473, 120);
            this.btn_SetEverydaySnowCoverFolder.Name = "btn_SetEverydaySnowCoverFolder";
            this.btn_SetEverydaySnowCoverFolder.Size = new System.Drawing.Size(38, 23);
            this.btn_SetEverydaySnowCoverFolder.TabIndex = 6;
            this.btn_SetEverydaySnowCoverFolder.Text = "浏览";
            this.btn_SetEverydaySnowCoverFolder.UseVisualStyleBackColor = true;
            this.btn_SetEverydaySnowCoverFolder.Click += new System.EventHandler(this.btn_SetEverydaySnowCoverFolder_Click);
            // 
            // btn_SetStatisticSnowCoverFolder
            // 
            this.btn_SetStatisticSnowCoverFolder.Location = new System.Drawing.Point(473, 153);
            this.btn_SetStatisticSnowCoverFolder.Name = "btn_SetStatisticSnowCoverFolder";
            this.btn_SetStatisticSnowCoverFolder.Size = new System.Drawing.Size(38, 23);
            this.btn_SetStatisticSnowCoverFolder.TabIndex = 6;
            this.btn_SetStatisticSnowCoverFolder.Text = "浏览";
            this.btn_SetStatisticSnowCoverFolder.UseVisualStyleBackColor = true;
            this.btn_SetStatisticSnowCoverFolder.Click += new System.EventHandler(this.btn_SetStatisticSnowCoverFolder_Click);
            // 
            // btn_SetBoundaryFilePath
            // 
            this.btn_SetBoundaryFilePath.Location = new System.Drawing.Point(473, 55);
            this.btn_SetBoundaryFilePath.Name = "btn_SetBoundaryFilePath";
            this.btn_SetBoundaryFilePath.Size = new System.Drawing.Size(38, 23);
            this.btn_SetBoundaryFilePath.TabIndex = 6;
            this.btn_SetBoundaryFilePath.Text = "浏览";
            this.btn_SetBoundaryFilePath.UseVisualStyleBackColor = true;
            this.btn_SetBoundaryFilePath.Click += new System.EventHandler(this.btn_SetBoundaryFilePath_Click);
            // 
            // btn_SetOrigionDataFolder
            // 
            this.btn_SetOrigionDataFolder.Location = new System.Drawing.Point(473, 22);
            this.btn_SetOrigionDataFolder.Name = "btn_SetOrigionDataFolder";
            this.btn_SetOrigionDataFolder.Size = new System.Drawing.Size(38, 23);
            this.btn_SetOrigionDataFolder.TabIndex = 6;
            this.btn_SetOrigionDataFolder.Text = "浏览";
            this.btn_SetOrigionDataFolder.UseVisualStyleBackColor = true;
            this.btn_SetOrigionDataFolder.Click += new System.EventHandler(this.btn_SetOrigionDataFolder_Click);
            // 
            // txt_PublishDisasterDoc
            // 
            this.txt_PublishDisasterDoc.Location = new System.Drawing.Point(97, 187);
            this.txt_PublishDisasterDoc.Name = "txt_PublishDisasterDoc";
            this.txt_PublishDisasterDoc.Size = new System.Drawing.Size(370, 21);
            this.txt_PublishDisasterDoc.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 190);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(84, 14);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "公报灾情目录：";
            // 
            // txt_EverydaySnowCoverFolder
            // 
            this.txt_EverydaySnowCoverFolder.Location = new System.Drawing.Point(97, 121);
            this.txt_EverydaySnowCoverFolder.Name = "txt_EverydaySnowCoverFolder";
            this.txt_EverydaySnowCoverFolder.Size = new System.Drawing.Size(370, 21);
            this.txt_EverydaySnowCoverFolder.TabIndex = 4;
            // 
            // txt_StatisticSnowCoverFolder
            // 
            this.txt_StatisticSnowCoverFolder.Location = new System.Drawing.Point(97, 154);
            this.txt_StatisticSnowCoverFolder.Name = "txt_StatisticSnowCoverFolder";
            this.txt_StatisticSnowCoverFolder.Size = new System.Drawing.Size(370, 21);
            this.txt_StatisticSnowCoverFolder.TabIndex = 4;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(7, 124);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(84, 14);
            this.labelControl11.TabIndex = 3;
            this.labelControl11.Text = "每日积雪目录：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 157);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "积雪统计目录：";
            // 
            // txt_BoundaryFilePath
            // 
            this.txt_BoundaryFilePath.Location = new System.Drawing.Point(97, 56);
            this.txt_BoundaryFilePath.Name = "txt_BoundaryFilePath";
            this.txt_BoundaryFilePath.Size = new System.Drawing.Size(370, 21);
            this.txt_BoundaryFilePath.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(84, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "边界文件设置：";
            // 
            // txt_OrigionDataFolder
            // 
            this.txt_OrigionDataFolder.Location = new System.Drawing.Point(97, 23);
            this.txt_OrigionDataFolder.Name = "txt_OrigionDataFolder";
            this.txt_OrigionDataFolder.Size = new System.Drawing.Size(370, 21);
            this.txt_OrigionDataFolder.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "原始影像目录：";
            // 
            // btn_OpenDataCenterFolder
            // 
            this.btn_OpenDataCenterFolder.Location = new System.Drawing.Point(527, 12);
            this.btn_OpenDataCenterFolder.Name = "btn_OpenDataCenterFolder";
            this.btn_OpenDataCenterFolder.Size = new System.Drawing.Size(38, 23);
            this.btn_OpenDataCenterFolder.TabIndex = 2;
            this.btn_OpenDataCenterFolder.Text = "打开";
            this.btn_OpenDataCenterFolder.UseVisualStyleBackColor = true;
            this.btn_OpenDataCenterFolder.Click += new System.EventHandler(this.btn_OpenDataCenterFolder_Click);
            // 
            // btn_SetDataCenterFolder
            // 
            this.btn_SetDataCenterFolder.Location = new System.Drawing.Point(483, 12);
            this.btn_SetDataCenterFolder.Name = "btn_SetDataCenterFolder";
            this.btn_SetDataCenterFolder.Size = new System.Drawing.Size(38, 23);
            this.btn_SetDataCenterFolder.TabIndex = 2;
            this.btn_SetDataCenterFolder.Text = "浏览";
            this.btn_SetDataCenterFolder.UseVisualStyleBackColor = true;
            this.btn_SetDataCenterFolder.Click += new System.EventHandler(this.btn_SetDataCenterFolder_Click);
            // 
            // txt_DataCenterFolder
            // 
            this.txt_DataCenterFolder.Location = new System.Drawing.Point(108, 15);
            this.txt_DataCenterFolder.Name = "txt_DataCenterFolder";
            this.txt_DataCenterFolder.Size = new System.Drawing.Size(370, 21);
            this.txt_DataCenterFolder.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "数据中心目录：";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(578, 433);
            this.xtraTabPage2.Text = "积雪覆盖分析";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(6, 92);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(96, 14);
            this.labelControl12.TabIndex = 3;
            this.labelControl12.Text = "影像预处理目录：";
            // 
            // txt_PreprocessingSnowCoverFolder
            // 
            this.txt_PreprocessingSnowCoverFolder.Location = new System.Drawing.Point(96, 89);
            this.txt_PreprocessingSnowCoverFolder.Name = "txt_PreprocessingSnowCoverFolder";
            this.txt_PreprocessingSnowCoverFolder.Size = new System.Drawing.Size(370, 21);
            this.txt_PreprocessingSnowCoverFolder.TabIndex = 4;
            // 
            // btn_SetPreprocessingSnowCoverFolder
            // 
            this.btn_SetPreprocessingSnowCoverFolder.Location = new System.Drawing.Point(472, 88);
            this.btn_SetPreprocessingSnowCoverFolder.Name = "btn_SetPreprocessingSnowCoverFolder";
            this.btn_SetPreprocessingSnowCoverFolder.Size = new System.Drawing.Size(38, 23);
            this.btn_SetPreprocessingSnowCoverFolder.TabIndex = 6;
            this.btn_SetPreprocessingSnowCoverFolder.Text = "浏览";
            this.btn_SetPreprocessingSnowCoverFolder.UseVisualStyleBackColor = true;
            this.btn_SetPreprocessingSnowCoverFolder.Click += new System.EventHandler(this.btn_SetPreprocessingSnowCoverFolder_Click);
            // 
            // btn_OpenPreprocessingSnowCoverFolder
            // 
            this.btn_OpenPreprocessingSnowCoverFolder.Location = new System.Drawing.Point(516, 88);
            this.btn_OpenPreprocessingSnowCoverFolder.Name = "btn_OpenPreprocessingSnowCoverFolder";
            this.btn_OpenPreprocessingSnowCoverFolder.Size = new System.Drawing.Size(38, 23);
            this.btn_OpenPreprocessingSnowCoverFolder.TabIndex = 5;
            this.btn_OpenPreprocessingSnowCoverFolder.Text = "打开";
            this.btn_OpenPreprocessingSnowCoverFolder.UseVisualStyleBackColor = true;
            this.btn_OpenPreprocessingSnowCoverFolder.Click += new System.EventHandler(this.btn_OpenPreprocessingSnowCoverFolder_Click);
            // 
            // frmSysSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSysSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.frmSysSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btn_SetDataCenterFolder;
        private System.Windows.Forms.TextBox txt_DataCenterFolder;
        private System.Windows.Forms.Button btn_OpenDataCenterFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_OpenOrigionDataFolder;
        private System.Windows.Forms.Button btn_SetOrigionDataFolder;
        private System.Windows.Forms.TextBox txt_OrigionDataFolder;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Button btn_OpenPublishDisaster;
        private System.Windows.Forms.Button btn_OpenStatisticSnowCoverFolder;
        private System.Windows.Forms.Button btn_OpenBoundaryFilePath;
        private System.Windows.Forms.Button btn_SetPublishDisaster;
        private System.Windows.Forms.Button btn_SetStatisticSnowCoverFolder;
        private System.Windows.Forms.Button btn_SetBoundaryFilePath;
        private System.Windows.Forms.TextBox txt_PublishDisasterDoc;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox txt_StatisticSnowCoverFolder;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox txt_BoundaryFilePath;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_DatabasePassword;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private System.Windows.Forms.TextBox txt_DatabaseUsername;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.TextBox txt_DatabaseCatalog;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.TextBox txt_DatabaseServerName;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.Button txt_DatabaseTestConn;
        private System.Windows.Forms.Button btn_CancelSetting;
        private System.Windows.Forms.Button btn_SubmitSetting;
        private System.Windows.Forms.Button btn_ApplicationSetting;
        private System.Windows.Forms.Button btn_DefaultSetting;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.Button btn_OpenEverydaySnowCoverFolder;
        private System.Windows.Forms.Button btn_SetEverydaySnowCoverFolder;
        private System.Windows.Forms.TextBox txt_EverydaySnowCoverFolder;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private System.Windows.Forms.Button btn_OpenPreprocessingSnowCoverFolder;
        private System.Windows.Forms.Button btn_SetPreprocessingSnowCoverFolder;
        private System.Windows.Forms.TextBox txt_PreprocessingSnowCoverFolder;
        private DevExpress.XtraEditors.LabelControl labelControl12;
    }
}