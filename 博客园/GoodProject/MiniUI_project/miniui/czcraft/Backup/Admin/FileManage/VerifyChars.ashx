<%@ WebHandler Language="C#" Class="VerifyChars" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Drawing.Imaging;
public class VerifyChars : IHttpHandler,IRequiresSessionState {
    /// <summary>
    /// 输出验证码信息
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest (HttpContext context) {
        
        context.Response.ContentType = "image/Png";
        // 在此处放置用户代码以初始化页面
        context.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache); //不缓存
      Common.YZMHelper   yz = new Common.YZMHelper ();
        yz.CreateImage();
        context.Session["checkcode"] = yz.Text; //将验证字符写入Session，供前台调用
        MemoryStream ms =new MemoryStream ();
        yz.Image.Save(ms,ImageFormat.Png);
        context.Response.ClearContent(); //需要输出图象信息 要修改HTTP头 

        context.Response.BinaryWrite(ms.ToArray());
        yz.Image.Dispose();
       
         context.Response.End();
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}