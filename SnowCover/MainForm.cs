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
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_OpenMapFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;    //单选
            ofd.Title = "选择地图文件";
            ofd.Filter = "mxd文件|*.mxd";
            ofd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                if (fi.Exists)
                {
                    this.axMapControl1.LoadMxFile(fi.FullName);
                    this.axMapControl1.ActiveView.Refresh();
                }
            }
        }

        private void btn_ExportMapPic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.ExportImage(this.axMapControl1.ActiveView);
        }

        private void btn_AddMapLayer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.AddData(this.axMapControl1);
        }

        private void btn_Pan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.Pan(this.axMapControl1);
        }

        private void btn_ZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.ZoomIn(axMapControl1);
        }

        private void btn_ZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.ZoomOut(axMapControl1);
        }

        private void btn_ScaleIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.ZoomInFix(axMapControl1);
        }

        private void btn_ScaleOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GISTools.ZoomOutFix(axMapControl1);
        }
    }
}
