using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using ESRI.ArcGIS.Controls;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;


namespace SnowCover.Modules
{
    public partial class ucFileNavPanel : UserControl
    {
        private string path = "";
        private bool isDateTimePickerPopup = false;
        private AxMapControl axMapControl = null;
        private DataTable dataTable = null;
        private TreeListNode clickNode = null;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public DevExpress.XtraTreeList.TreeList TreeList
        {
            get { return this.treeList1; }
            //set { this.treeList1 = value; }
        }

        public DevExpress.XtraEditors.DateEdit DateEdit
        {
            get { return this.dateEdit1; }
            //set { this.treeList1 = value; }
        }

        public ucFileNavPanel(AxMapControl _AxMapControl)
        {
            InitializeComponent();
            axMapControl = _AxMapControl;
            Init();
        }

        private void Init()
        {
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsFilter.FilterMode = FilterMode.Smart;
            //this.check_DateFilter.Checked = false;
        }

        private void btn_PreMonth_Click(object sender, EventArgs e)
        {
            if (!this.dateEdit1.IsPopupOpen)
            {
                this.dateEdit1.ShowPopup();
            }
            DateTime date = this.dateEdit1.DateTime;
            this.dateEdit1.DateTime = date.AddMonths(-1);
            this.dateEdit1.Refresh();
        }

        private void btn_NextMonth_Click(object sender, EventArgs e)
        {
            if (!this.dateEdit1.IsPopupOpen)
            {
                this.dateEdit1.ShowPopup();
            }
            DateTime date = this.dateEdit1.DateTime;
            this.dateEdit1.DateTime = date.AddMonths(1);
            this.dateEdit1.Refresh();
        }


        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (isDateTimePickerPopup)
            {
                this.check_DateFilter.Checked = true;
            }
            
            DateTime date = this.dateEdit1.DateTime;

            if(!Directory.Exists(path))
            {
                MessageBox.Show("数据文件夹不存在，请检查","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            SetTreeList();
        }
        private void check_DateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if(!this.check_DateFilter.Checked)
            {
                isDateTimePickerPopup = false;
            }
            DateTime date = this.dateEdit1.DateTime;
            if(!Directory.Exists(path))
            {
                MessageBox.Show("数据文件夹不存在，请检查","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            SetTreeList();
        }

        private void SetTreeList()
        {            
            DateTime date = this.DateEdit.DateTime;
            if(date  == null)
            {
                return;
            }
            this.dateEdit1.DateTime = date;
            

            dataTable = DataHandle.DiskFile.getDataTable(path,this.check_DateFilter.Checked,date);
            if (dataTable == null)
            {
                return;
            }
            //if (dt.Rows.Count == 0)
            //{
            //    return;
            //}
            this.treeList1.KeyFieldName = "id";
            this.treeList1.ParentFieldName = "pid";            
            this.treeList1.DataSource = dataTable;

            //按名称排序
            this.treeList1.BeginSort();
            this.treeList1.Columns["type"].SortOrder = SortOrder.Descending;
            this.treeList1.Columns["name"].SortOrder = SortOrder.Ascending;
            this.treeList1.EndSort();

            //隐藏除"name"的列
            for (int i = 0; i < this.treeList1.Columns.Count; i++)
            {
                if (this.treeList1.Columns[i].FieldName != "name")
                {
                    this.treeList1.Columns[i].Visible = false;
                }
            }
            if (dataTable.Rows.Count < 100)
            {
                this.treeList1.ExpandAll();
            }
            if (this.treeList1.Columns.Count > 0)
            {
                this.treeList1.Columns[0].Caption = "名称";
            }
        }


        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl is DevExpress.XtraTreeList.TreeList)
            {
                TreeList tree = (TreeList)e.SelectedControl;
                TreeListHitInfo hit = tree.CalcHitInfo(e.ControlMousePosition);
                if (hit.HitInfoType == HitInfoType.Cell)
                {
                    object cellInfo = new TreeListCellToolTipInfo(hit.Node, hit.Column, null);

                    string name = (string)hit.Node[hit.Column];
                    string toolTip = "";                    
                    if (name.Length >= 18)
                    {
                        string dayOfYearStr = name.Substring(15, 3);    //截取天数
                        string yearStr = name.Substring(13, 2);         //截取年份
                        int dayOfYear = 0;
                        int year = 0;                        
                        if (int.TryParse(dayOfYearStr, out dayOfYear))
                        {
                            if (int.TryParse(yearStr, out year))
                            {
                                DateTime date = new DateTime(2000 + year, 1, 1).AddDays(dayOfYear - 1);
                                string dateStr = date.ToString("yyyy年MM月dd日");
                                toolTip = string.Format("{0} ({1})", hit.Node[hit.Column], dateStr);
                            }
                        }
                    }
                    else
                    {
                        toolTip = string.Format("{0}", hit.Node[hit.Column]);
                    }                    
                    e.Info = new DevExpress.Utils.ToolTipControlInfo(cellInfo, toolTip);
                }
            }
        }

        private void dateEdit1_Popup(object sender, EventArgs e)
        {
            isDateTimePickerPopup = true;
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DevExpress.XtraTreeList.TreeList tree = sender as DevExpress.XtraTreeList.TreeList;

                if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && tree.State == TreeListState.Regular)
                {
                    Point ptTreeList = tree.PointToClient(MousePosition);
                    Point pt = Control.MousePosition;
                    TreeListHitInfo info = tree.CalcHitInfo(ptTreeList);
                    if (info.HitInfoType == HitInfoType.Cell)
                    {
                        clickNode = info.Node;
                        tree.FocusedNode = clickNode;
                        this.contextMenuStrip1.Show(pt);                        
                    }
                }
            }
            catch
            {
            }
        }

        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DevExpress.XtraTreeList.TreeList tree = sender as DevExpress.XtraTreeList.TreeList;

                DevExpress.XtraTreeList.TreeListHitInfo info = tree.CalcHitInfo(tree.PointToClient(MousePosition));
                if (info.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell)
                {                    
                    TreeListNode node = info.Node;
                    
                    tree.FocusedNode = node;
                    AddLayerToMapControl(node);
                }
            }
            catch
            {
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string itemName = e.ClickedItem.Name;
            switch(itemName)
            {
                case "tsmi_AddLayer":
                    AddLayerToMapControl(clickNode);
                    break;
                case "tsmi_OpenFolder":
                    break;

            }
        }

        private void AddLayerToMapControl(TreeListNode node)
        {
            if (node == null)
            {
                return;
            }
            if (node.Nodes.Count > 0)
            {
                return;
            }
            if (dataTable == null)
            {
                return;
            }
            if (dataTable.Rows.Count < 1)
            {
                return;
            }
            int id = node.Id;
            DataRow row = dataTable.Rows[id];
            string path = (string)row["path"];
            if (!File.Exists(path))
            {
                MessageBox.Show("文件不存在，请检查文件后重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string extension = System.IO.Path.GetExtension(path).ToLower();
            if (extension == "mxd")
            {
                this.axMapControl.LoadMxFile(path);
            }
            else if (SystemBase.GISLayers.IsSupportLayerType(extension))
            {
                SystemBase.GISLayers.OpenRaster(path, this.axMapControl);
            }
            else
            {
                MessageBox.Show("暂不支持打开[*" + extension + "]格式的文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }





    }
}
