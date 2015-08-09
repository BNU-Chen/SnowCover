namespace SnowCover
{
    partial class frmSetStaMapDate
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
            this.btn_submit = new DevExpress.XtraEditors.SimpleButton();
            this.bnt_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_HasStaData = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.DateTime = new System.DateTime(2015, 8, 6, 0, 0, 0, 0);
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateNavigator1.HotDate = null;
            this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.Size = new System.Drawing.Size(321, 184);
            this.dateNavigator1.TabIndex = 0;
            this.dateNavigator1.EditDateModified += new System.EventHandler(this.dateNavigator1_EditDateModified);
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(229, 199);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 1;
            this.btn_submit.Text = "确定";
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // bnt_cancel
            // 
            this.bnt_cancel.Location = new System.Drawing.Point(148, 199);
            this.bnt_cancel.Name = "bnt_cancel";
            this.bnt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bnt_cancel.TabIndex = 1;
            this.bnt_cancel.Text = "取消";
            this.bnt_cancel.Click += new System.EventHandler(this.bnt_cancel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 203);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "数据是否存在：";
            // 
            // lbl_HasStaData
            // 
            this.lbl_HasStaData.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_HasStaData.Location = new System.Drawing.Point(94, 203);
            this.lbl_HasStaData.Name = "lbl_HasStaData";
            this.lbl_HasStaData.Size = new System.Drawing.Size(12, 14);
            this.lbl_HasStaData.TabIndex = 2;
            this.lbl_HasStaData.Text = "否";
            // 
            // frmSetStaMapDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 240);
            this.Controls.Add(this.lbl_HasStaData);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.bnt_cancel);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.dateNavigator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSetStaMapDate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择查看积雪覆盖日期";
            this.Load += new System.EventHandler(this.frmSetStaMapDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraEditors.SimpleButton btn_submit;
        private DevExpress.XtraEditors.SimpleButton bnt_cancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_HasStaData;
    }
}