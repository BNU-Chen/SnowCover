using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Windows.Forms;

namespace SystemBase
{
    public class FormCommon
    {

        public static string SelectSingleFile(string initDir, string filterStr)
        {
            string selectPath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择文件";
            if (Directory.Exists(initDir))
            {
                ofd.InitialDirectory = initDir;
            }
            ofd.Multiselect = false;
            ofd.Filter = filterStr;// "mxd文件|mxd.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string mapPath = ofd.FileName;
                if (File.Exists(mapPath))
                {
                    selectPath = ofd.FileName;
                }
                else
                {
                    if (MessageBox.Show("文件不存在，请重新选择。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        SelectSingleFile(initDir, filterStr);
                    }
                }
            }
            return selectPath;
        }
    }
}
