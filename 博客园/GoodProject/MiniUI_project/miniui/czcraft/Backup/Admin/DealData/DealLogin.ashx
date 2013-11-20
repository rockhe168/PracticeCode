<%@ WebHandler Language="C#" Class="DealLogin" %>

using System;
using System.Web;
using Common;
using System.Web.SessionState;
using System.Data.Common;
using System.Data.SqlClient;
using log4net;
using log4net.Config;  
public class DealLogin : IHttpHandler, IRequiresSessionState
{
   //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public void ProcessRequest(HttpContext context)
    {
        CallMoreMethod(context);
    }
    /// <summary>
    /// 调用各种方法的入口
    /// </summary>
    public void CallMoreMethod(HttpContext context)
    {
       
        if (!Common.Tools.IsNullOrEmpty((object)context.Request["method"]))
        {
            string method = context.Request["method"].ToString();
            switch (method)
            {
                case "login":
                    CallLoginMethod(context);
                    break;
                case "exit":
                    CallExitMethod(context);
                    break;
                default:
                    return;
            }

        }
    }
 
    /// <summary>
    /// 调用安全退出方法
    /// </summary>
    /// <param name="context"></param>
    public void CallExitMethod(HttpContext context)
    {
        czcraft.Model.WEB_USER user =(czcraft.Model.WEB_USER)context.Session["User"] ;
        context.Cache.Remove(user.LOGNAME);
        context.Session.Remove("User");
        context.Response.Write("安全退出成功!");
    }
    /// <summary>
    /// 调用登录的方法
    /// </summary>    
    public void CallLoginMethod(HttpContext context)
    {
        string LoginIp = context.Request.UserHostAddress;//获取用户ip地址
        string checkcode = QueryString.FormRequest("vdcode");
        czcraft.Model.WEB_USER user = new czcraft.Model.WEB_USER();
        try
        {
            user.LOGNAME = QueryString.FormRequest("username");
            user.PASSWORD = QueryString.FormRequest("userpass");
            string sUser=Convert.ToString(context.Cache[user.LOGNAME]);
            if (context.Session["checkcode"].ToString().Equals(checkcode))
            {
                int groupID = new czcraft.BLL.WEB_USERBLL().IsLogin(user);
                if (groupID > 0)
                {
                    //这里要判断单点登录的情况
                    if (sUser==null||sUser==string.Empty)
                    {
                        TimeSpan SessTimeOut = new TimeSpan(0, 0,1 , 0, 0);//取得Session的过期时间System.Web.HttpContext.Current.Session.Timeout(这里设置为1分钟)
                        HttpContext.Current.Cache.Insert(user.LOGNAME, user.LOGNAME, null, DateTime.MaxValue, SessTimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null);//将值放入cache己方便单点登录
                        user.GROUP = new czcraft.Model.WEB_USERGROUP();
                        user.GROUP.ID = groupID;
                        context.Session["User"] = user;
                        new czcraft.BLL.SystemLogBLL().SaveSystemLog("登录成功!");
                       
                        //logger.Info(user.LOGNAME + "登录成功!");
                      //  WriteSysLog log = new WriteSysLog();
                     // log.WriteSystemLog(LoginIp+"于"+DateTime.Now.ToString ()+"以"+user.LOGNAME+"帐号登录系统");
                        JScript.JavaScriptLocationHref("../main.htm");
                    }
                    else if (context.Cache[sUser].ToString() == user.LOGNAME)//如果这个账号已经登录
                    {
                        JScript.AlertAndRedirect("该用户已登录!!", "../login.htm");
                        return;
                    }
                    else{
                        
                       context.Session.Abandon();//这段主要是为了避免不必要的错误导致不能登录
                    }
                  
                }
                else
                    JScript.AlertAndRedirect("帐号或密码错误,或者用户组被禁用!", "../login.htm");
                
            }
            else
                JScript.AlertAndRedirect("验证码出错!!", "../login.htm");
        }
        catch (Exception ex)
        {
            logger.Error("登录出错!登录ip:" + LoginIp+"登录时间:"+DateTime.Now.ToString(), ex);
        
            JScript.AlertAndRedirect("系统出错!", "../login.htm") ;
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}