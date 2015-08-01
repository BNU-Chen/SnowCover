namespace SnowCover
{
    partial class frmSetSnowCoverDateForStatisticByBoundary
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
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_SelectionDate = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_DayOfYear = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_IsOrigionDataExist = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SetEndDate = new System.Windows.Forms.Button();
            this.btn_SetStartDate = new System.Windows.Forms.Button();
            this.lbl_EndDate = new DevExpress.XtraEditors.LabelControl();
            this.lbl_StartDate = new DevExpress.XtraEditors.LabelControl();
            this.chkBtn_BatHandler = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.DateTime = new System.DateTime(2015, 5, 13, 0, 0, 0, 0);
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateNavigator1.HighlightHolidays = false;
            this.dateNavigator1.HotDate = new System.DateTime(2015, 6, 23, 0, 0, 0, 0);
            this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator1.Multiselect = false;
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.Size = new System.Drawing.Size(826, 471);
            this.dateNavigator1.TabIndex = 7;
            this.dateNavigator1.EditDateModified += new System.EventHandler(this.dateNavigator1_EditDateModified);
            this.dateNavigator1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateNavigator1_MouseDown);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(731, 491);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 8;
            this.btn_Submit.Text = "确定";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(650, 491);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "已选择日期：";
            // 
            // lbl_SelectionDate
            // 
            this.lbl_SelectionDate.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_SelectionDate.Location = new System.Drawing.Point(97, 497);
            this.lbl_SelectionDate.Name = "lbl_SelectionDate";
            this.lbl_SelectionDate.Size = new System.Drawing.Size(24, 14);
            this.lbl_SelectionDate.TabIndex = 10;
            this.lbl_SelectionDate.Text = "日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "今天是第：";
            // 
            // lbl_DayOfYear
            // 
            this.lbl_DayOfYear.AutoSize = true;
            this.lbl_DayOfYear.ForeColor = System.Drawing.Color.Red;
            this.lbl_DayOfYear.Location = new System.Drawing.Point(250, 498);
            this.lbl_DayOfYear.Name = "lbl_DayOfYear";
            this.lbl_DayOfYear.Size = new System.Drawing.Size(23, 12);
            this.lbl_DayOfYear.TabIndex = 11;
            this.lbl_DayOfYear.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 498);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "天";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(319, 497);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(132, 14);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "积雪覆盖数据是否存在：";
            // 
            // lbl_IsOrigionDataExist
            // 
            this.lbl_IsOrigionDataExist.AutoSize = true;
            this.lbl_IsOrigionDataExist.ForeColor = System.Drawing.Color.Red;
            this.lbl_IsOrigionDataExist.Location = new System.Drawing.Point(452, 499);
            this.lbl_IsOrigionDataExist.Name = "lbl_IsOrigionDataExist";
            this.lbl_IsOrigionDataExist.Size = new System.Drawing.Size(17, 12);
            this.lbl_IsOrigionDataExist.TabIndex = 11;
            this.lbl_IsOrigionDataExist.Text = "否";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SetEndDate);
            this.groupBox1.Controls.Add(this.btn_SetStartDate);
            this.groupBox1.Controls.Add(this.lbl_EndDate);
            this.groupBox1.Controls.Add(this.lbl_StartDate);
            this.groupBox1.Location = new System.Drawing.Point(16, 527);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 50);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "批量处理";
            // 
            // btn_SetEndDate
            // 
            this.btn_SetEndDate.Location = new System.Drawing.Point(279, 18);
            this.btn_SetEndDate.Name = "btn_SetEndDate";
            this.btn_SetEndDate.Size = new System.Drawing.Size(89, 23);
            this.btn_SetEndDate.TabIndex = 1;
            this.btn_SetEndDate.Text = "设为起始时间";
            this.btn_SetEndDate.UseVisualStyleBackColor = true;
            this.btn_SetEndDate.Click += new System.EventHandler(this.btn_SetEndDate_Click);
            // 
            // btn_SetStartDate
            // 
            this.btn_SetStartDate.Location = new System.Drawing.Point(16, 18);
            this.btn_SetStartDate.Name = "btn_SetStartDate";
            this.btn_SetStartDate.Size = new System.Drawing.Size(89, 23);
            this.btn_SetStartDate.TabIndex = 1;
            this.btn_SetStartDate.Text = "设为起始时间";
            this.btn_SetStartDate.UseVisualStyleBackColor = true;
            this.btn_SetStartDate.Click += new System.EventHandler(this.btn_SetStartDate_Click);
            // 
            // lbl_EndDate
            // 
            this.lbl_EndDate.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_EndDate.Location = new System.Drawing.Point(374, 21);
            this.lbl_EndDate.Name = "lbl_EndDate";
            this.lbl_EndDate.Size = new System.Drawing.Size(48, 14);
            this.lbl_EndDate.TabIndex = 0;
            this.lbl_EndDate.Text = "截止时间";
            // 
            // lbl_StartDate
            // 
            this.lbl_StartDate.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_StartDate.Location = new System.Drawing.Point(111, 21);
            this.lbl_StartDate.Name = "lbl_StartDate";
            this.lbl_StartDate.Size = new System.Drawing.Size(48, 14);
            this.lbl_StartDate.TabIndex = 0;
            this.lbl_StartDate.Text = "起始时间";
            // 
            // chkBtn_BatHandler
            // 
            this.chkBtn_BatHandler.Location = new System.Drawing.Point(560, 491);
            this.chkBtn_BatHandler.Name = "chkBtn_BatHandler";
            this.chkBtn_BatHandler.Size = new System.Drawing.Size(75, 23);
            this.chkBtn_BatHandler.TabIndex = 14;
            this.chkBtn_BatHandler.Text = "批量处理";
            this.chkBtn_BatHandler.CheckedChanged += new System.EventHandler(this.chkBtn_BatHandler_CheckedChanged);
            // 
            // frmSetSnowCoverDateForStatisticByBoundary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 587);
            this.Controls.Add(this.chkBtn_BatHandler);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_IsOrigionDataExist);
            this.Controls.Add(this.lbl_DayOfYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_SelectionDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.dateNavigator1);
            this.Name = "frmSetSnowCoverDateForStatisticByBoundary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "积雪分区统计分析";
            this.Load += new System.EventHandler(this.frmSetSnowCoverDateForStatisticByBoundary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl lbl_SelectionDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_DayOfYear;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label lbl_IsOrigionDataExist;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_SetStartDate;
        private DevExpress.XtraEditors.LabelControl lbl_StartDate;
        private System.Windows.Forms.Button btn_SetEndDate;
        private DevExpress.XtraEditors.LabelControl lbl_EndDate;
        private DevExpress.XtraEditors.CheckButton chkBtn_BatHandler;

    }
}