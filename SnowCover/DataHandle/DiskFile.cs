using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;

namespace SnowCover.DataHandle
{
    public class DiskFile
    {
        public static DataTable getDataTable(string path)
        {
            DataTable dt = new DataTable();
            //初始化列
            dt.Columns.Add("id", System.Type.GetType("System.Int64"));  //id列，标识列
            dt.Columns.Add("pid", System.Type.GetType("System.Int64"));  //pid列，父级id
            dt.Columns.Add("name", System.Type.GetType("System.String"));  //名称，不包含后缀
            dt.Columns.Add("ext", System.Type.GetType("System.String"));  //后缀名，文件夹为空
            dt.Columns.Add("type", System.Type.GetType("System.String"));  //File or Folder
            dt.Columns.Add("path", System.Type.GetType("System.String"));  //路径

            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                int id = 0;
                ListFiles(di, ref dt, ref id);
                return dt;
            }

            return dt;
        }

        //递归遍历路径中的所有文件夹及文件
        public static void ListFiles(FileSystemInfo info, ref DataTable dt, ref int id)
        {
            try
            {
                //目录信息不存在
                if (!info.Exists)
                    return;
                DirectoryInfo dir = info as DirectoryInfo;
                //不是目录
                if (dir == null)
                    return;
                int pid = id;       //记录当前id，作为pid


                FileSystemInfo[] files = dir.GetFileSystemInfos();
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = files[i] as FileInfo;
                    id++;
                    //是文件
                    if (file != null)
                    {
                        DataRow dr = dt.NewRow();
                        dr["id"] = id;
                        dr["pid"] = pid;
                        dr["name"] = Path.GetFileName(file.FullName);  //文件名 
                        dr["ext"] = file.Extension.Substring(1, file.Extension.Length - 1).ToLower();      //拓展名，包含“.”
                        dr["type"] = "File";
                        dr["path"] = file.FullName;         //全路径
                        dt.Rows.Add(dr);
                    }
                    //对于子目录，进行递归调用
                    else
                    {
                        DirectoryInfo di = files[i] as DirectoryInfo;

                        DataRow dr = dt.NewRow();
                        dr["id"] = id;
                        dr["pid"] = pid;
                        dr["name"] = di.Name;
                        dr["ext"] = "folder";
                        dr["type"] = "Folder";
                        dr["path"] = di.FullName;
                        dt.Rows.Add(dr);

                        ListFiles(files[i], ref dt, ref id);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
