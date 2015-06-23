using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SystemBase
{
    public class LogFile
    {
        public static void Log(string title,string logMessage)
        {
            DateTime now = DateTime.Now;
            //string logFileName = "log_" + now.ToString("yyyy-MM") + ".txt";
            StreamWriter w = File.AppendText("log.txt");

            //w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongDateString(),
                DateTime.Now.ToLongTimeString());
            w.WriteLine(title);
            w.WriteLine("{0}", logMessage);
            w.WriteLine("-------------------------------");
            w.Close();
        }


    }
}
