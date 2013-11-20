using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using log4net;
using System.Text;
using System.IO;

/// <summary>
///WriteSysLog 的摘要说明
/// </summary>
public class WriteSysLog
{
    public WriteSysLog()
    { 
    
    }
    ///// <summary>
    ///// 获取系统日志
    ///// </summary>
    ///// <param name="FilePath"></param>
    //public StringBuilder GetSystemLog(string FilePath)
    //{
    //    FileInfo fi = new FileInfo(FilePath);
    //    if (fi.Exists)
    //    {
    //        using (StreamReader sr = new StreamReader(FilePath))
    //        { 
            
    //        }
    //    }
    //}
    /// <summary>
    /// 写系统日志(比如:ip登录信息地址,后台操作信息等等)
    /// </summary>
    /// <param name="sysInfo">登录系统信息</param>
    public  void WriteSystemLog(string sysInfo)
    {
        log4net.Filter.LevelRangeFilter levfilter = new log4net.Filter.LevelRangeFilter();
        levfilter.LevelMax = log4net.Core.Level.Info;
        levfilter.LevelMin = log4net.Core.Level.Debug;
        levfilter.ActivateOptions();
        //Appender1  
        log4net.Appender.FileAppender appender1 = new log4net.Appender.FileAppender();

        appender1.AppendToFile = true;
        appender1.File = "Log/sys_"+DateTime.Now.ToString ("yyyMMdd")+".log";
        appender1.ImmediateFlush = true;
        appender1.LockingModel = new log4net.Appender.FileAppender.MinimalLock();

        appender1.Name = "操作日志";
        appender1.AddFilter(levfilter);
        ///layout  
        log4net.Layout.PatternLayout layout = new log4net.Layout.PatternLayout("%date [%thread] %-5level - %message%newline");
        //layout.Header = "------ 系统日志 ------" + Environment.NewLine;
        //layout.Footer = "------ 系统日志 ------" + Environment.NewLine;
        //  
        appender1.Layout = layout;
        appender1.ActivateOptions();
        log4net.Repository.ILoggerRepository repository = log4net.LogManager.CreateRepository("MyRepository");

        log4net.Config.BasicConfigurator.Configure(repository, appender1);
        ILog logger = log4net.LogManager.GetLogger(repository.Name, "MyLog");
        logger.Info(sysInfo);
    
      
    }
}
