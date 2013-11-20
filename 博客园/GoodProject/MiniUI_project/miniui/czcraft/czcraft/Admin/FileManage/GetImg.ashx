<%@ WebHandler Language="C#" Class="GetFile" %>

using System;
using System.Web;
using Common;
using System.IO;
using System.Configuration;
public class GetFile : IHttpHandler {
    public static string ServerPic = ConfigurationManager.AppSettings["PicServerPath"];
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

            case "GetMasterPic":
                GetMasterPic(context);
                break;
            case "GetMasterCert":
                GetMasterCert(context);
                break;
            case "GetCompanyCert":
                GetCompanyCert(context);
                break;
            case "GetCompanyPic":
                GetCompanyPic(context);
                break;
            case "GetLogoCompanyPic":
                GetLogoCompanyPic(context);
                break;
            case "GetMainProductPic":
                GetMainProductPic(context);
                break;
            case "GetOtherProductPic":
                GetOtherProductPic(context);
                break;
            default:
                return;
        }
    }
    /// <summary>
    /// 获得大师的荣誉信息图片
    /// </summary>
    /// <param name="context"></param>
    public void GetMasterCert(HttpContext context)
    {
        string type = context.Request["type"];//要访问的图片尺寸
        string fileName = context.Request["fileName"];//文件名称

        string VirtualPath = ServerPic + "Master/MasterCert/";//文件虚拟路径

        if (!Tools.IsValidInput(ref fileName, true))
        {
            return;
        }
        //真实路径
        string PicTypeDirectory = GetPicType(type);
        if (PicTypeDirectory != null)
            VirtualPath += GetPicType(type);
        else
            VirtualPath += ServerPic + "NoPic.jpg";
        
        WriteImg(context, VirtualPath + fileName);//输出图片
    }
    /// <summary>
    /// 获取产品其他图片
    /// </summary>
    /// <param name="context"></param>
    public void GetOtherProductPic(HttpContext context)
    {
        string type = context.Request["type"];//要访问的图片尺寸
        string fileName = context.Request["fileName"];//文件名称

        string VirtualPath = ServerPic + "Product/OtherProductPic/";//文件虚拟路径

        if (!Tools.IsValidInput(ref fileName, true))
        {
            return;
        }
        //真实路径
        string PicTypeDirectory = GetPicType(type);
        if (PicTypeDirectory != null)
            VirtualPath += GetPicType(type);
        else
            VirtualPath += ServerPic + "NoPic.jpg";

        WriteImg(context, VirtualPath + fileName);//输出图片
    }
    /// <summary>
    /// 获得产品的图片
    /// </summary>
    /// <param name="context"></param>
    public void GetMainProductPic(HttpContext context)
    {
        string type = context.Request["type"];//要访问的图片尺寸
        string fileName = context.Request["fileName"];//文件名称
        
        string VirtualPath = ServerPic+"Product/MainProductPic/";//文件虚拟路径
        
        if (!Tools.IsValidInput(ref fileName, true))
        {
            return;
        }
        //真实路径
        string PicTypeDirectory = GetPicType(type);
        if (PicTypeDirectory != null)
            VirtualPath += GetPicType(type);
        else
            VirtualPath += ServerPic + "NoPic.jpg";
        
        WriteImg(context,VirtualPath + fileName);//输出图片
    }
    /// <summary>
    /// 获得大师的图片
    /// </summary>
    /// <param name="context"></param>
    public void GetMasterPic(HttpContext context)
    {
        string type = context.Request["type"];//要访问的图片尺寸
        string fileName = context.Request["fileName"];//文件名称

        string VirtualPath =  ServerPic+"Master/MainMasterPic/";//文件虚拟路径
        if (!Tools.IsValidInput(ref fileName, true))
        {
            return;
        }
        //真实路径
        string PicTypeDirectory = GetPicType(type);
        if (PicTypeDirectory != null)
            VirtualPath += GetPicType(type);
        else
            VirtualPath += ServerPic + "NoPic.jpg";
        
        WriteImg(context, VirtualPath + fileName);//输出图片
    }
    /// <summary>
    /// 获得企业美景图
    /// </summary>
    /// <param name="context"></param>
    public void GetLogoCompanyPic(HttpContext context)
    {
        string type = context.Request["type"];//要访问的图片尺寸
        string fileName = context.Request["fileName"];//文件名称

        string VirtualPath = ServerPic + "Company/CompanyPic/";//文件虚拟路径
        if (!Tools.IsValidInput(ref fileName, true))
        {
            return;
        }
        //真实路径
        string PicTypeDirectory = GetPicType(type);
        if (PicTypeDirectory != null)
            VirtualPath += GetPicType(type);
        else
            VirtualPath += ServerPic + "NoPic.jpg";
        
        WriteImg(context, VirtualPath + fileName);//输出图片
    }
    /// <summary>
    /// 获得图片的尺寸类别(small,middle,Big)
    /// </summary>
    /// <param name="Type">类别</param>
    /// <returns></returns>
    public string GetPicType(string Type)
    {
        string Directory="";
        switch (Type)
        {
            case "Small":
                Directory = "Small/";
                break;
            case "medium":
                Directory = "";
                break;
            case "Big":
                Directory = "Big/";
                break;
            default:
                break;
        }
        return Directory;
    }
    /// <summary>
    /// 获得企业荣誉图片
    /// </summary>
    /// <param name="context"></param>
    public void GetCompanyCert(HttpContext context)
    {
        string type = context.Request["type"];//要访问的图片尺寸
        string fileName = context.Request["fileName"];//文件名称

        string VirtualPath = ServerPic + "Company/CompanyCert/";//文件虚拟路径

        if (!Tools.IsValidInput(ref fileName, true))
        {
            return;
        }
        //真实路径
        string PicTypeDirectory = GetPicType(type);
        if (PicTypeDirectory != null)
            VirtualPath += GetPicType(type);
        else
            VirtualPath += ServerPic + "NoPic.jpg";

        WriteImg(context, VirtualPath + fileName);//输出图片
    }
    /// <summary>
    /// 获得企业的图片
    /// </summary>
    /// <param name="context"></param>
    public void GetCompanyPic(HttpContext context)
    {
        string type = context.Request["type"];//要访问的图片尺寸
        string fileName = context.Request["fileName"];//文件名称

        string VirtualPath = ServerPic + "Company/MainCompanyPic/";//文件虚拟路径

        if (!Tools.IsValidInput(ref fileName, true))
        {
            return;
        }
        //真实路径
        string PicTypeDirectory = GetPicType(type);
        if (PicTypeDirectory != null)
            VirtualPath += GetPicType(type);
        else
            VirtualPath += ServerPic + "NoPic.jpg";
        
        WriteImg(context, VirtualPath + fileName);//输出图片
    }
    /// <summary>
    /// 输出图片信息
    /// </summary>
    /// <param name="context"></param>
    public void WriteImg(HttpContext context,string FileName)
    {
        string path = context.Server.MapPath(FileName);
        //获取图片文件的二进制数据。
        Real(context, path);
    }
   /// <summary>
    /// 按照文件类型输出
   /// </summary>
   /// <param name="context"></param>
   /// <param name="fileName"></param>
    private void Real(HttpContext context, string fileName)
    {
     
        FileInfo file =new FileInfo(fileName);
        if (file.Exists == false)
        {
            file = new FileInfo(context.Server.MapPath(ServerPic + "NoPic.jpg"));
        } 
        context.Response.Clear();

        context.Response.AddHeader("Content-Disposition", "filename=" + file.Name);

        context.Response.AddHeader("Content-Length", file.Length.ToString());

        string fileExtension = file.Extension.ToLower();

        //这里选择输出的文件格式

        //可以参考http://ewebapp.cnblogs.com/articles/234756.html增加对文件格式的支持.

        switch (fileExtension)
        {

            case ".mp3":

                context.Response.ContentType = "audio/mpeg3";

                break;

            case ".mpeg":

                context.Response.ContentType = "video/mpeg";

                break;

            case ".jpg":

                context.Response.ContentType = "image/jpeg";

                break;

            case ".bmp":

                context.Response.ContentType = "image/bmp";

                break;

            case ".gif":

                context.Response.ContentType = "image/gif";

                break;

            case ".doc":

                context.Response.ContentType = "application/msword";

                break;

            case ".css":

                context.Response.ContentType = "text/css";

                break;

            default:

                context.Response.ContentType = "application/octet-stream";

                break;

        }
        byte[] datas = System.IO.File.ReadAllBytes(file.FullName);
        context.Response.ClearContent(); //需要输出图象信息 要修改HTTP头 
        //context.Response.ContentType = "image/Jpeg";
        //将二进制数据写入到输出流中。
       // context.Response.OutputStream.Write(datas, 0, datas.Length);
        context.Response.BinaryWrite(datas);
        //context.Response.BinaryWrite(file.FullName);

        context.Response.End();

    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}