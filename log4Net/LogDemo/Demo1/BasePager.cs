using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo1
{
    public class BasePager : System.Web.UI.Page
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger("ADONetAppender");
        protected void Page_Error(object sender, EventArgs args)
        {
            //获取最新的异常信息
            var ex = Server.GetLastError();
            //记录异常信息
            Log.Error(ex.Message, ex);

            Log.Info("这是一般日志信息2.....",ex);
            //清空异常信息
            Server.ClearError();
        }

    }
}