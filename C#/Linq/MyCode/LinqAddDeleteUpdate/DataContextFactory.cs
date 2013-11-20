using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace LinqAddDeleteUpdate
{
    public class DataContextFactory
    {
        
        private static string connectionStr = "server=.;database=GuestBook;integrated security=sspi";
        private static GuestBookDataContext instance = new GuestBookDataContext(connectionStr);
        private static string logPath=HttpContext.Current.Server.MapPath("~/log/"+DateTime.Now.ToLongDateString()+"_log.txt");

        private static StreamWriter sw = new StreamWriter(logPath,true);
        public static GuestBookDataContext GetInstance()
        {
            //StreamWriter sw = new StreamWriter("log.txt", true);
            if(sw ==null)
                sw = new StreamWriter(DateTime.Now.ToLongDateString() + "_log.txt", true);

            if (instance == null)
                instance =new GuestBookDataContext(connectionStr);

            sw.AutoFlush = true;//将其缓冲区刷新到基础流(立即保存,不放在IO缓冲区)。

            instance.Log = sw;
           

            return instance;
        }
        
    }
}