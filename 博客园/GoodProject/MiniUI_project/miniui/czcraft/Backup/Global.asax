<%@ Application Language="C#" %>
<script runat="server">
    private Quartz.IScheduler sched;
    log4net.ILog logger = log4net.LogManager.GetLogger(typeof(global_asax));
    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码
        log4net.Config.XmlConfigurator.Configure();
        PanGu.Segment.Init();

        //启动索引库的扫描线程
        IndexManager.GetInstance(IndexManager.JobSearchType.Knowledge).Start();
        #region 定时任务(暂时不用)
        //***************以下是定时任务***************//
        //Quartz.ISchedulerFactory sf = new Quartz.Impl.StdSchedulerFactory();
        //sched = sf.GetScheduler();
        //Quartz.JobDetail job = new Quartz.JobDetail("job1", "group1", typeof(czcraft.IndexJob));//IndexJob为实现了IJob接口的类
        //DateTime ts = Quartz.TriggerUtils.GetNextGivenSecondDate(null, 5);//5秒后开始第一次运行
        //int hour = Convert.ToInt32(ConfigurationManager.AppSettings["IndexStartHour"]);
        //int minute = Convert.ToInt32(ConfigurationManager.AppSettings["IndexStartMinute"]);
        //Quartz.Trigger trigger = Quartz.TriggerUtils.MakeDailyTrigger("tigger1", hour, minute);
        //trigger.JobName = "job1";
        //trigger.JobGroup = "group1";
        //trigger.Group = "group1";

        //// TimeSpan interval = TimeSpan.FromHours(1);//每隔1小时执行一次
        ////  Trigger trigger = new SimpleTrigger("trigger1", "group1", "job1", "group1", ts, null,SimpleTrigger.RepeatIndefinitely, interval);//每若干小时运行一次，小时间隔由appsettings中的IndexIntervalHour参数指定

        //sched.AddJob(job, true);
        //sched.ScheduleJob(trigger);
        //sched.Start();
        //***************以上是定时任务***************// 
        #endregion
    }
    /// <summary>
    /// 不管页面存不存在都一定会访问的
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Application_BeginRequest(object sender, EventArgs e)
    {
        string url = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;//获得用户要访问的资源
        Match match = Regex.Match(url, @"~/News/ViewNews-(\d+)\.aspx");
        //匹配成功才重写
        if (match.Success)
        {
            //网站后缀NewsId=24
            string NewsId = match.Groups[1].Value.ToString();
            //网页url重写
            HttpContext.Current.RewritePath(string.Format("~/News/ViewNews.aspx?NewsId={0}", NewsId));
        }
        
        
    }
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码
        logger.Error("程序未捕获的异常", HttpContext.Current.Server.GetLastError());
    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码
       
    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }
       
</script>
