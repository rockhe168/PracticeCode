<%@ WebHandler Language="C#" Class="CommentInfo" %>

using System;
using System.Web;
using czcraft.BLL;
using czcraft.Model;
using Common;
using System.Web.SessionState;
public class CommentInfo : IHttpHandler,IRequiresSessionState {

    //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public void ProcessRequest(HttpContext context)
    {

        String methodName = context.Request["method"];
        if (!string.IsNullOrEmpty(methodName))
            CallMethod(methodName, context);
    }
    /// <summary>
    /// 根据业务需求调用不同的方法
    /// </summary>
    /// <param name="Method">方法</param>
    /// <param name="context">上下文</param>
    public void CallMethod(string Method, HttpContext context)
    {
        switch (Method)
        {
            case "SaveWebComment":
                SaveWebComment(context);
                break;
         
            default:
                return;


        }
    }
    /// <summary>
    /// 保存总站留言
    /// </summary>
    /// <param name="context"></param>
    public void SaveWebComment(HttpContext context)
    {

        WebMessageBLL bll = new WebMessageBLL();
        try
        {
            //表单读取
            string UserName = context.Request["UserName"];
            string TelePhone = context.Request["TelePhone"];
            string Email = context.Request["Email"];
            string CheckCode = context.Request["CheckCode"];
            string Content = context.Request["Content"];
            if (Tools.IsNullOrEmpty(context.Session["checkcode"]))
            {
                context.Response.Write(Tools.WriteJsonForReturn(false, "验证码出错!!"));
                return;
            }
            //验证码校验
            if (!CheckCode.Equals(context.Session["checkcode"].ToString ()))
            {
                context.Response.Write(Tools.WriteJsonForReturn(false, "验证码出错!")); 
                return;
            }
            //字符串sql注入检测
            if(Tools.IsValidInput(ref UserName, false) && Tools.IsValidInput(ref Email, true) && Tools.IsValidInput(ref TelePhone, true)&&Tools.IsValidInput(ref Content,true))
            {
                WebMessage Info = new WebMessage();
                Info.liuyanName = UserName;
                Info.MobilePhone = TelePhone;
                Info.Email = Email;
                Info.liuyanContent = Content;
                Info.liuyanTime = DateTime.Now;
                if (bll.AddNew(Info)>0)
                {
                    context.Response.Write(Tools.WriteJsonForReturn(true, "回复成功!"));
                }
                else
                {
                    context.Response.Write(Tools.WriteJsonForReturn(false, "回复出错!"));
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error("错误!", ex);
            context.Response.Write(Tools.WriteJsonForReturn(false, "系统异常!"));
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}