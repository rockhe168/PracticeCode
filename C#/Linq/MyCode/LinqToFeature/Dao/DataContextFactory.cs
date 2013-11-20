using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace LinqToFeature.Dao
{
    public class DataContextFactory
    {
        private static NorthwindDataContext instance = new NorthwindDataContext();
        private static string logPath = HttpContext.Current.Server.MapPath("~/log/" + DateTime.Now.ToLongDateString() + "_log.txt");

        private static StreamWriter sw = new StreamWriter(logPath, true);
        public static NorthwindDataContext GetInstance()
        {
            //StreamWriter sw = new StreamWriter("log.txt", true);
            if (sw == null)
                sw = new StreamWriter(DateTime.Now.ToLongDateString() + "_log.txt", true);

            if (instance == null)
                instance = new NorthwindDataContext();

            sw.AutoFlush = true;//将其缓冲区刷新到基础流(立即保存,不放在IO缓冲区)。

            instance.Log = sw;
            sw.WriteLine("发生时间为:" + DateTime.Now.ToString());
            sw.WriteLine("日志内容为:");


            return instance;
        }
    }
}