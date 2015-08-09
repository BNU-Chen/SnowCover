using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
namespace SnowCover
{
    class UserDefineClasses
    {
    }

    public class SnowData
    {
        //以下字段需要赋值
        public string code = "";    //行政区代码
        public int count = 0;       //总像元数
        public int sum = 0;         //积雪覆盖像元数
        public string date = "";    //统计时间
        public string name = "";    //区域名称
        //shp属性表属性
        public double area =1; //区域总面积
        public string PAC = "";     //区域代码

        //以下字段不需要赋值，会自动计算
        private double percent = 0;  //积雪覆盖比例
        private double snowArea = 0; //积雪覆盖面积

        public double Percent
        {
            get
            {
                if (count != 0)
                {
                    percent = sum * 1.0 / count;
                }
                return percent;
            }
            set { percent = value; }
        }

        public double SnowArea
        {
            get
            {
                if (percent != 0)
                {
                    snowArea = percent * area;
                }
                return snowArea;
            }
            set { snowArea = value; }
        }

    }

    public class StaCountyProperty
    {
        [CategoryAttribute("积雪覆盖情况"), DescriptionAttribute("积雪覆盖计算")]
        //以下字段需要赋值
        private string code = "";    //行政区代码
        public string 行政区代码
        {
            get { return code; }
            set { code = value; }
        }

        private int count = 0;       //总像元数
        public int 总像元数
        {
            get { return count; }
            set { count = value; }
        }

        private int sum = 0;         //积雪像元数
        public int 积雪像元数
        {
            get { return sum; }
            set { sum = value; }
        }

        private string date = "";    //统计日期
        public string 统计日期
        {
            get {
                int blankIndex = date.IndexOf(' ');
                string dateShort = date;
                if (blankIndex > 0)
                {
                    dateShort = date.Substring(0, blankIndex);
                }
                return dateShort;
            }
            set { date = value; }
        }

        private string name = "";    //区域名称
        public string 区域名称
        {
            get { return name; }
            set { name = value; }
        }

        //shp属性表属性
        private double area = 1; //区域总面积(km2)
        public double 区域总面积
        {
            get { return Math.Round(area, 3); }
            set { area = value; }
        }

        //以下字段不需要赋值，会自动计算
        private double percent = 0;  //积雪覆盖比例
        public double 积雪覆盖比例
        {
            get
            {
                if (count != 0)
                {
                    percent = sum * 1.0 / count *100;
                }
                return Math.Round(percent, 3);
            }
            set { percent = value; }
        }

        private double snowArea = 0; //积雪覆盖面积
        public double 积雪覆盖面积
        {
            get
            {
                if (percent != 0)
                {
                    snowArea = percent * area;
                }
                return Math.Round(snowArea, 3);
            }
            set { snowArea = value; }
        }
    }
}
