using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;

using SystemBase;

namespace SnowCover.DataHandle
{
    public class DiskFile
    {
        public static DataTable getDataTable(string path, bool dateFilter,DateTime date)
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

                string year = date.Year.ToString();
                int dayOfYear = date.DayOfYear;
                int firstDayOfMonth = getFistDayOfMonth(date);
                int lastDayOfMonth = getLastDayOfMonth(date);

                ListFiles(di, ref dt, ref id, dateFilter, year,firstDayOfMonth, lastDayOfMonth);
                return dt;
            }

            return dt;
        }

        //递归遍历路径中的所有文件夹及文件
        public static void ListFiles(FileSystemInfo info, ref DataTable dt, ref int id, bool dateFilter,string year, int firstDayOfMonth, int lastDayOfMonth)
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
                        if (!IsThisMonthFile(year, firstDayOfMonth, lastDayOfMonth, file.FullName) && dateFilter)
                        {
                            continue;
                        }
                        string extension = file.Extension.ToLower();
                        //是否支持打开该类地图文件
                        if (!SystemBase.GISLayers.IsSupportLayerType(extension))
                        {
                            continue;
                        }
                        DataRow dr = dt.NewRow();
                        dr["id"] = id;
                        dr["pid"] = pid;
                        dr["name"] = Path.GetFileName(file.FullName);  //文件名 
                        dr["ext"] = extension;   //.Substring(1, file.Extension.Length - 1).ToLower();      //拓展名，包含“.”
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

                        ListFiles(files[i], ref dt, ref id, dateFilter, year, firstDayOfMonth, lastDayOfMonth);
                    }
                }
            }
            catch
            {
            }
        }

        private static bool IsThisMonthFile(string year, int firstDayOfMonth, int lastDayOfMonth, string path)
        {
            bool isWanted = false;
            try
            {
                string name = Path.GetFileNameWithoutExtension(path);
                if(name.Length < 18)
                {
                    return isWanted;
                }
                string fileYear = "20"+name.Substring(13, 2);
                if(year != fileYear)
                {
                    isWanted = false;
                    return isWanted;
                }

                string dayOfYearStr = name.Substring(15, 3);
                int dayOfYear = 0;
                if (int.TryParse(dayOfYearStr, out dayOfYear))
                {
                    if (dayOfYear >= firstDayOfMonth && dayOfYear <= lastDayOfMonth)
                    {
                        isWanted = true;
                        return isWanted;
                    }
                }
            }
            catch { }
            return isWanted;
        }


        private static int getFistDayOfMonth(DateTime date)
        {
            if (date == null)
            {
                return 0;
            }
            int dayOfMonth = date.Day;
            int dayOfYear = date.DayOfYear;

            return dayOfYear - dayOfMonth + 1;
        }

        private static int getLastDayOfMonth(DateTime date)
        {
            if (date == null)
            {
                return 0;
            }
            int lastDayOfMonth = 0;

            int dayOfMonth = date.Day;
            int dayOfYear = date.DayOfYear;
            int month = date.Month;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    lastDayOfMonth = dayOfYear - dayOfMonth + 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    lastDayOfMonth = dayOfYear - dayOfMonth + 30;
                    break;
                case 2:
                    lastDayOfMonth = dayOfYear - dayOfMonth + 29;
                    break;
            }

            return lastDayOfMonth;
        }
    }
}
