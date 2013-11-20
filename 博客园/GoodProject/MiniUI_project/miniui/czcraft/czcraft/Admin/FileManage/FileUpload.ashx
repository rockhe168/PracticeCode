<%@ WebHandler Language="C#" Class="FileUpload" %>

using System;
using System.Web;
using System.IO;
public class FileUpload : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

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

            case "UpLoadMasterPic":
                UpLoadMasterPic(context);
                break;
            case "UploadMasterCert":
                UploadMasterCert(context);
                break;
            case "UpLoadCompanyPic":
                UpLoadCompanyPic(context);
                break;
            case "UploadCompanyCert":
                UploadCompanyCert(context);
                break;
            case "UpLoadProductPic":
                UpLoadProductPic(context);
                break;
            case "UpLoadOtherProductPic":
                UpLoadOtherProductPic(context);
                break;
            default:
                return;


        }
    }
   
    /// <summary>
    /// 上传产品图片
    /// </summary>
    /// <param name="context"></param>
    public void UpLoadProductPic(HttpContext context)
    {
        //上传图片到产品的主目录下
        string filePath = context.Server.MapPath("../Pictures/Product/MainProductPic");
        //返回的文件名
        string outFileName;
        //返回的json格式
        string returnJson = Common.FileUpload.FileUploadSingle(context, filePath, out outFileName);
        //135*135规格小图片保存
        string small_pic_path = filePath + "/small/";
        //调用缩略图算法
        Common.pic_zip.getzip_pic(135, 135, filePath+"/", small_pic_path, outFileName);
        string middle_pic_Path = filePath + "/middle/";
        //308*305规格中等图片
        Common.pic_zip.getzip_pic(308, 305, filePath + "/", middle_pic_Path, outFileName);
        context.Response.Write(returnJson);
    }
    /// <summary>
    /// 上传产品副图片
    /// </summary>
    /// <param name="context"></param>
    public void UpLoadOtherProductPic(HttpContext context)
    {
        //上传图片到产品的主目录下
        string filePath = context.Server.MapPath("../Pictures/Product/OtherProductPic");
        //返回的文件数组名
        string[] outFileName;
        //返回的json格式
        string returnJson = Common.FileUpload.FileUploadMulti(context, filePath, out outFileName);
        //135*135规格小图片保存
        string small_pic_path = filePath + "/small/";
        string middle_pic_Path = filePath + "/middle/";
        //生成缩略图
        foreach (string str in outFileName)
        {
            //调用缩略图算法
            Common.pic_zip.getzip_pic(135, 135, filePath + "/", small_pic_path, str);

            //308*305规格中等图片
            Common.pic_zip.getzip_pic(308, 305, filePath + "/", middle_pic_Path, str);
        }
        context.Response.Write(returnJson);
    
    
    }
    /// <summary>
    /// 上传大师主图片
    /// </summary>
    /// <param name="context"></param>
    public void UpLoadMasterPic(HttpContext context)
    {
            //上传图片到大师的主目录下
        string filePath = context.Server.MapPath("../Pictures/Master/MainMasterPic");
        //返回的文件名
        string outFileName;
        //返回的json格式
        string returnJson = Common.FileUpload.FileUploadSingle(context, filePath, out outFileName);
        //135*135规格小图片保存
        string small_pic_path = filePath + "/small/";
        //调用缩略图算法
        Common.pic_zip.getzip_pic(135, 135, filePath + "/", small_pic_path, outFileName);
        //308*305规格中等图片
        // Common.pic_zip.getzip_pic(308, 305, filePath, middle_pic_path,outFileName );
        context.Response.Write(returnJson);
        
       
    }
    /// <summary>
    /// 上传大师荣誉证书图片
    /// </summary>
    /// <param name="context"></param>
    public void UploadMasterCert(HttpContext context)
    {
        //上传图片到大师的主目录下
        string filePath = context.Server.MapPath("../Pictures/Master/MasterCert");
        //返回的文件名
        string outFileName;
        //返回的json格式
        string returnJson = Common.FileUpload.FileUploadSingle(context, filePath, out outFileName);
        //135*135规格小图片保存
        string small_pic_path = filePath + "/small/";
        //调用缩略图算法
        Common.pic_zip.getzip_pic(135, 135, filePath + "/", small_pic_path, outFileName);
        //308*305规格中等图片
        // Common.pic_zip.getzip_pic(308, 305, filePath, middle_pic_path,outFileName );
        context.Response.Write(returnJson);
    }
    /// <summary>
    /// 上传企业荣誉证书
    /// </summary>
    /// <param name="context"></param>
    public void UploadCompanyCert(HttpContext context)
    {
        //上传图片到大师的主目录下
        string filePath = context.Server.MapPath("../Pictures/Company/CompanyCert");
        //返回的文件名
        string outFileName;
        //返回的json格式
        string returnJson = Common.FileUpload.FileUploadSingle(context, filePath, out outFileName);
        //135*135规格小图片保存
        string small_pic_path = filePath + "/small/";
        //调用缩略图算法
        Common.pic_zip.getzip_pic(135, 135, filePath + "/", small_pic_path, outFileName);
        //308*305规格中等图片
        // Common.pic_zip.getzip_pic(308, 305, filePath, middle_pic_path,outFileName );
        context.Response.Write(returnJson);
    }
    /// <summary>
    /// 上传企业主图片
    /// </summary>
    /// <param name="context"></param>
    public void UpLoadCompanyPic(HttpContext context)
    {
        //上传图片到企业的主目录下
        string filePath = context.Server.MapPath("../Pictures/Company/CompanyPic");
        //返回的文件名
        string outFileName;
        //返回的json格式
        string returnJson = Common.FileUpload.FileUploadSingle(context, filePath, out outFileName);
        //135*135规格小图片保存
        string small_pic_path = filePath + "/small/";
        //调用缩略图算法
        Common.pic_zip.getzip_pic(135, 135, filePath + "/", small_pic_path, outFileName);
        //308*305规格中等图片
        // Common.pic_zip.getzip_pic(308, 305, filePath, middle_pic_path,outFileName );
        
        context.Response.Write(returnJson);
        
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}