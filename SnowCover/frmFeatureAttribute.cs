using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnowCover
{
    public partial class frmFeatureAttribute : Form
    {
        private StaCountyProperty propertyClass = new StaCountyProperty();
        public frmFeatureAttribute()
        {
            InitializeComponent();
        }

        private void frmFeatureAttribute_Load(object sender, EventArgs e)
        {
            this.propertyGrid1.SelectedObject = propertyClass;
        }

        public void setData(StaCountyProperty propertyClass)
        {
            this.propertyGrid1.SelectedObject = propertyClass;
        }

    }
}
