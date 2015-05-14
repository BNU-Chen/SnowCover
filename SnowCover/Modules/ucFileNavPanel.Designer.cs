namespace SnowCover.Modules
{
    partial class ucFileNavPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.check_DateFilter = new DevExpress.XtraEditors.CheckEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.TextEdit_Filter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_DateFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Filter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.check_DateFilter);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Controls.Add(this.TextEdit_Filter);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(246, 72);
            this.panelControl1.TabIndex = 6;
            // 
            // check_DateFilter
            // 
            this.check_DateFilter.Location = new System.Drawing.Point(9, 41);
            this.check_DateFilter.Name = "check_DateFilter";
            this.check_DateFilter.Properties.Caption = "";
            this.check_DateFilter.Size = new System.Drawing.Size(20, 19);
            this.check_DateFilter.TabIndex = 7;
            this.check_DateFilter.CheckedChanged += new System.EventHandler(this.check_DateFilter_CheckedChanged);
            // 
            // dateEdit1
            // 
            this.dateEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEdit1.EditValue = new System.DateTime(2015, 5, 10, 13, 56, 47, 450);
            this.dateEdit1.Location = new System.Drawing.Point(35, 40);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dateEdit1.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dateEdit1.Size = new System.Drawing.Size(204, 20);
            this.dateEdit1.TabIndex = 5;
            this.dateEdit1.DateTimeChanged += new System.EventHandler(this.dateEdit1_DateTimeChanged);
            this.dateEdit1.Popup += new System.EventHandler(this.dateEdit1_Popup);
            // 
            // TextEdit_Filter
            // 
            this.TextEdit_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextEdit_Filter.Location = new System.Drawing.Point(35, 9);
            this.TextEdit_Filter.Name = "TextEdit_Filter";
            this.TextEdit_Filter.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextEdit_Filter.Properties.Appearance.Options.UseFont = true;
            this.TextEdit_Filter.Size = new System.Drawing.Size(204, 24);
            this.TextEdit_Filter.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(5, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "搜索";
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 72);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.RowHeight = 25;
            this.treeList1.Size = new System.Drawing.Size(246, 449);
            this.treeList1.TabIndex = 7;
            this.treeList1.ToolTipController = this.toolTipController1;
            this.treeList1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDoubleClick);
            this.treeList1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseUp);
            // 
            // toolTipController1
            // 
            this.toolTipController1.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
            // 
            // ucFileNavPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucFileNavPanel";
            this.Size = new System.Drawing.Size(246, 521);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_DateFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Filter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit TextEdit_Filter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraEditors.CheckEdit check_DateFilter;
        private DevExpress.Utils.ToolTipController toolTipController1;

    }
}
