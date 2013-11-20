<%@ WebHandler Language="C#" Class="GetOtherInfo" %>

using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
public class GetOtherInfo : IHttpHandler {

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

            case "GetOurInfo":
                GetOurInfo(context);
                break;
            //case "GetNewsTypeForCombox":
            //    GetNewsTypeForCombox(context);
            //    break;

            default:
                return;


        }
    }
    /// <summary>
    /// 获取我们的信息
    /// </summary>
    /// <param name="context"></param>
    public void GetOurInfo(HttpContext context)
    {
        ourinfo info = new ourinfoBLL().Get(1);
        context.Response.Write(ourinfoBLL.OurInfoToJson(info));
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}