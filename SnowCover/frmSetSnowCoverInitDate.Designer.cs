namespace SnowCover
{
    partial class frmSetSnowCoverInitDate
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
            this.btn_Today = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_SelectionDate = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_DayOfYear = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_IsOrigionDataExist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.DateTime = new System.DateTime(2015, 5, 13, 0, 0, 0, 0);
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateNavigator1.HighlightHolidays = false;
            this.dateNavigator1.HotDate = null;
            this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator1.Multiselect = false;
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.Size = new System.Drawing.Size(826, 471);
            this.dateNavigator1.TabIndex = 7;
            this.dateNavigator1.EditDateModified += new System.EventHandler(this.dateNavigator1_EditDateModified);
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
            // btn_Today
            // 
            this.btn_Today.Location = new System.Drawing.Point(646, 491);
            this.btn_Today.Name = "btn_Today";
            this.btn_Today.Size = new System.Drawing.Size(75, 23);
            this.btn_Today.TabIndex = 8;
            this.btn_Today.Text = "分析今天";
            this.btn_Today.UseVisualStyleBackColor = true;
            this.btn_Today.Click += new System.EventHandler(this.btn_Today_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(561, 491);
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
            this.labelControl1.Text = "原始影像数据是否存在：";
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
            // frmSetSnowCoverInitDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 524);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_IsOrigionDataExist);
            this.Controls.Add(this.lbl_DayOfYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_SelectionDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Today);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.dateNavigator1);
            this.Name = "frmSetSnowCoverInitDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置分析积雪覆盖时间";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSetSnowCoverInitDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Today;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl lbl_SelectionDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_DayOfYear;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label lbl_IsOrigionDataExist;

    }
}