using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraTreeList;


namespace SnowCover.Modules
{
    public partial class ucFileNavPanel : UserControl
    {
        public DevExpress.XtraTreeList.TreeList TreeList
        {
            get { return this.treeList1; }
            //set { this.treeList1 = value; }
        }

        public ucFileNavPanel()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsFilter.FilterMode = FilterMode.Smart;
        }


    }
}
