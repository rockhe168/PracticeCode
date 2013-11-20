using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace Common
{
    /// <summary>
    /// 潮州工艺品图片删除
    /// </summary>
   public  class CzcraftDeletePic
    {
       public enum DeletePicType
       {
           /// <summary>
           /// 大师图片
           /// </summary>
           GetMasterPic=0,
           /// <summary>
           /// 大师荣誉图片
           /// </summary>
           GetMasterCert=1,
           /// <summary>
           /// 企业荣誉图片
           /// </summary>
           GetCompanyCert=2,
           /// <summary>
           /// 企业主图片
           /// </summary>
           GetLogoCompanyPic=3,
           /// <summary>
           /// 企业美景图
           /// </summary>
           GetCompanyPic=4,
           /// <summary>
           /// 产品主图片
           /// </summary>
           GetMainProductPic=5,
           /// <summary>
           /// 产品副图片
           /// </summary>
           GetOtherProductPic=6
       }
       /// <summary>
        /// 潮州工艺品图片删除
       /// </summary>
        /// <param name="FileType">文件类别(GetMasterPic,GetMasterCert,GetCompanyCert,GetLogoCompanyPic,GetMainProductPic,GetOtherProductPic)</param>
       /// <param name="FileName">文件名</param>
       public static void FileDelete(DeletePicType FileType, string FileName)
       {
          string VirtualPath= GetPicPath(FileType, FileName);
           //删除文件
          FileOperate.FileDelete(VirtualPath, true);
       }
       /// <summary>
       /// 获取文件路径(根据文件类别)
       /// </summary>
       /// <param name="FileType">文件类别</param>
       /// <param name="FileName">文件名</param>
       /// <returns></returns>
       public static string GetPicPath(DeletePicType FileType, string FileName)
       {
           string PicServerPath = ConfigurationManager.AppSettings["PicServerPath"];
           string VirtualFilePath = PicServerPath;
           switch (FileType)
           { 
               case DeletePicType.GetMasterPic:
                   VirtualFilePath += "Master/MainMasterPic/";
                   break;
               case DeletePicType.GetMasterCert:
                   VirtualFilePath += "Master/MasterCert/";
                   break;
               case DeletePicType.GetCompanyCert:
                   VirtualFilePath += "Company/CompanyCert/";
                   break;
               case DeletePicType.GetCompanyPic:
                   VirtualFilePath += "Company/MainCompanyPic/";
                   break;
               case DeletePicType.GetLogoCompanyPic:
                   VirtualFilePath += "Company/CompanyPic/";
                   break;
               case DeletePicType.GetMainProductPic:
                   VirtualFilePath += "Product/MainProductPic/";
                   break;
               case DeletePicType.GetOtherProductPic:
                   VirtualFilePath += "Product/OtherProductPic/"; ;
                   break;
               default:
                throw new Exception("文件类别输入有误!");
                


           }
           VirtualFilePath += FileName;
           return VirtualFilePath;
       }
    }
}
