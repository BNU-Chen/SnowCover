namespace SnowCover
{
    partial class frmSetStatisticSnowCoverDate
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_IsDataExist = new System.Windows.Forms.Label();
            this.lbl_EndDate = new DevExpress.XtraEditors.LabelControl();
            this.lbl_StartDate = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_DayOfYear = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_SelectionDate = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SelectEndDate = new System.Windows.Forms.Button();
            this.btn_SelectStartDate = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Submit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.DateTime = new System.DateTime(2015, 5, 13, 0, 0, 0, 0);
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator1.HighlightHolidays = false;
            this.dateNavigator1.HotDate = null;
            this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.Size = new System.Drawing.Size(826, 469);
            this.dateNavigator1.TabIndex = 0;
            this.dateNavigator1.EditDateModified += new System.EventHandler(this.dateNavigator1_EditDateModified);
            this.dateNavigator1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateNavigator1_MouseDown);
            this.dateNavigator1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dateNavigator1_MouseUp);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lbl_IsDataExist);
            this.panelControl1.Controls.Add(this.lbl_EndDate);
            this.panelControl1.Controls.Add(this.lbl_StartDate);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.lbl_DayOfYear);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.lbl_SelectionDate);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.btn_SelectEndDate);
            this.panelControl1.Controls.Add(this.btn_SelectStartDate);
            this.panelControl1.Controls.Add(this.btn_Cancel);
            this.panelControl1.Controls.Add(this.btn_Submit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 469);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(826, 86);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(37, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(132, 14);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "积雪覆盖数据是否存在：";
            // 
            // lbl_IsDataExist
            // 
            this.lbl_IsDataExist.AutoSize = true;
            this.lbl_IsDataExist.ForeColor = System.Drawing.Color.Red;
            this.lbl_IsDataExist.Location = new System.Drawing.Point(170, 53);
            this.lbl_IsDataExist.Name = "lbl_IsDataExist";
            this.lbl_IsDataExist.Size = new System.Drawing.Size(17, 12);
            this.lbl_IsDataExist.TabIndex = 18;
            this.lbl_IsDataExist.Text = "否";
            // 
            // lbl_EndDate
            // 
            this.lbl_EndDate.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_EndDate.Location = new System.Drawing.Point(354, 51);
            this.lbl_EndDate.Name = "lbl_EndDate";
            this.lbl_EndDate.Size = new System.Drawing.Size(48, 14);
            this.lbl_EndDate.TabIndex = 17;
            this.lbl_EndDate.Text = "截止日期";
            // 
            // lbl_StartDate
            // 
            this.lbl_StartDate.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_StartDate.Location = new System.Drawing.Point(354, 22);
            this.lbl_StartDate.Name = "lbl_StartDate";
            this.lbl_StartDate.Size = new System.Drawing.Size(48, 14);
            this.lbl_StartDate.TabIndex = 17;
            this.lbl_StartDate.Text = "起始日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "天";
            // 
            // lbl_DayOfYear
            // 
            this.lbl_DayOfYear.AutoSize = true;
            this.lbl_DayOfYear.ForeColor = System.Drawing.Color.Red;
            this.lbl_DayOfYear.Location = new System.Drawing.Point(191, 24);
            this.lbl_DayOfYear.Name = "lbl_DayOfYear";
            this.lbl_DayOfYear.Size = new System.Drawing.Size(23, 12);
            this.lbl_DayOfYear.TabIndex = 15;
            this.lbl_DayOfYear.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "第：";
            // 
            // lbl_SelectionDate
            // 
            this.lbl_SelectionDate.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_SelectionDate.Location = new System.Drawing.Point(94, 23);
            this.lbl_SelectionDate.Name = "lbl_SelectionDate";
            this.lbl_SelectionDate.Size = new System.Drawing.Size(24, 14);
            this.lbl_SelectionDate.TabIndex = 13;
            this.lbl_SelectionDate.Text = "日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "当前日期：";
            // 
            // btn_SelectEndDate
            // 
            this.btn_SelectEndDate.Location = new System.Drawing.Point(261, 48);
            this.btn_SelectEndDate.Name = "btn_SelectEndDate";
            this.btn_SelectEndDate.Size = new System.Drawing.Size(86, 23);
            this.btn_SelectEndDate.TabIndex = 9;
            this.btn_SelectEndDate.Text = "设为截止日期";
            this.btn_SelectEndDate.UseVisualStyleBackColor = true;
            this.btn_SelectEndDate.Click += new System.EventHandler(this.btn_SelectEndDate_Click);
            // 
            // btn_SelectStartDate
            // 
            this.btn_SelectStartDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_SelectStartDate.Location = new System.Drawing.Point(261, 19);
            this.btn_SelectStartDate.Name = "btn_SelectStartDate";
            this.btn_SelectStartDate.Size = new System.Drawing.Size(86, 23);
            this.btn_SelectStartDate.TabIndex = 9;
            this.btn_SelectStartDate.Text = "设为起始日期";
            this.btn_SelectStartDate.UseVisualStyleBackColor = true;
            this.btn_SelectStartDate.Click += new System.EventHandler(this.btn_SelectStartDate_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(643, 19);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(733, 19);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 10;
            this.btn_Submit.Text = "确定";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // frmSetStatisticSnowCoverDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 555);
            this.Controls.Add(this.dateNavigator1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmSetStatisticSnowCoverDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "积雪覆盖统计";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSetStatisticSnowCoverDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_DayOfYear;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LabelControl lbl_SelectionDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SelectStartDate;
        private DevExpress.XtraEditors.LabelControl lbl_StartDate;
        private DevExpress.XtraEditors.LabelControl lbl_EndDate;
        private System.Windows.Forms.Button btn_SelectEndDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label lbl_IsDataExist;
    }
}