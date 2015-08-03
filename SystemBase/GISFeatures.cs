using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace SystemBase
{
    public class GISFeatures
    {
        public static ICursor GetSelectionFeature(IFeatureLayer _featureLayer)
        {
            IFeatureSelection featureSelection = _featureLayer as IFeatureSelection;
            ISelectionSet selectionSet = featureSelection.SelectionSet;

            ICursor cursor = null;
            try
            {
                selectionSet.Search(null, false, out cursor);

                //IRow row = cursor.NextRow();
                //while (row != null)
                //{
                //    IFeature feature = (IFeature)row;
                //    ITable table = row.Table;
                //    int nameIndex = table.FindField("PAC");
                //    if (nameIndex > 0)
                //    {
                //        string value = (string)feature.get_Value(nameIndex);
                //        MessageBox.Show(value);
                //        break;
                //    }
                //}
            }
            catch { }
            return cursor;

        }
    }
}
