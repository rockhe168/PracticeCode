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
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

/// <summary>
///URLXMLInfoManage 的摘要说明
/// </summary>
public class URLXMLInfoManage
{
    #region 字段
    //单例模式
    public static readonly URLXMLInfoManage XMLInfo = new URLXMLInfoManage();
    /// <summary>
    /// 路径(XML)
    /// </summary>
    private static readonly string XMLPath = "~/Admin/ConfigManage/URLConfig.xml";
    #endregion
    #region 实例化
    /// <summary>
    /// 私有实例化
    /// </summary>
    private URLXMLInfoManage()
    {
    }
    /// <summary>
    /// 实例化(静态)
    /// </summary>
    /// <param name="path">xml的路径</param>
    /// <returns></returns>
    public static URLXMLInfoManage Instance()
    {
        return XMLInfo;
    }
    #endregion
    #region 通过页面信息(返回json)
    /// <summary>
    /// 通过页面信息(返回json)
    /// </summary>
    /// <returns></returns>
    public string GetURLInfoForJson()
    {

        //加载XML
        XDocument xDoc = XDocument.Load(HttpContext.Current.Server.MapPath(XMLPath));

        IEnumerable<XElement> PageList = xDoc.Root.Descendants("Page");
        //linq分组(根据xml中Page的Type的名称分组
        var group = PageList.GroupBy(page => page.Attribute("Type").Value);
        //输出json格式数据
        StringBuilder json = new StringBuilder();
        StringWriter sw = new StringWriter(json);
        using (JsonWriter jsonWriter = new JsonTextWriter(sw))
        {
            jsonWriter.Formatting = Newtonsoft.Json.Formatting.Indented;
            jsonWriter.WriteStartArray();
            foreach (IGrouping<string, XElement> item in group)
            {
                jsonWriter.WriteStartObject();
                //-1代表不存在的id
                jsonWriter.WritePropertyName("id");
                jsonWriter.WriteValue(-1);
                jsonWriter.WritePropertyName("text");
                jsonWriter.WriteValue(item.First().Attribute("TypeName").Value);
                jsonWriter.WritePropertyName("expanded");
                jsonWriter.WriteValue(false);
                jsonWriter.WritePropertyName("children");

                jsonWriter.WriteStartArray();
                foreach (XElement XElem in item)
                {
                    //页面名称
                    string PageName = XElem.Attribute("PageName").Value;
                    //页面URL
                    string PageURL = XElem.Attribute("PageURL").Value;
                    //页面标识
                    string PageId = XElem.Attribute("Id").Value;
                    //是否是html页面
                    bool IsHtml = Convert.ToBoolean(XElem.Attribute("IsHtml").Value);
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("id");
                    jsonWriter.WriteValue(PageId);
                    jsonWriter.WritePropertyName("text");
                    jsonWriter.WriteValue(PageName);
                    jsonWriter.WritePropertyName("expanded");
                    jsonWriter.WriteValue(IsHtml);
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject();

            }
            jsonWriter.WriteEndArray();




        }
        return json.ToString();


    }

    #endregion
    #region 设置页面静态化信息
    /// <summary>
    /// 设置页面静态化信息
    /// </summary>
    /// <param name="Ids"></param>
    /// <returns></returns>
    public bool SetURLInfo(string Ids)
    {
        //获取URL的Id
        string[] IdList = Ids.Split(',');
        //加载XML
        XDocument xDoc = XDocument.Load(HttpContext.Current.Server.MapPath(XMLPath));

        IEnumerable<XElement> PageList = xDoc.Root.Descendants("Page");
        foreach (XElement Page in PageList)
        {
            //默认不生成HTML页面
            Page.SetAttributeValue("IsHtml", false);
            foreach (string Id in IdList)
            {
               
                if (Id == Page.Attribute("Id").Value)
                {
                    //页面静态化
                    CreateHTML(Page.Attribute("PageURL").Value);
                    //写回XML中
                    Page.SetAttributeValue("IsHtml", true);
                    break;
                }
            }
        }
        xDoc.Save(HttpContext.Current.Server.MapPath(XMLPath));
        return true;
    } 
    #endregion
    #region 页面静态化(不适合文章等纯HTML)
    /// <summary>
    /// 页面静态化(不适合文章等纯HTML)
    /// </summary>
    /// <param name="PathURL"></param>
    /// <returns></returns>
    public bool CreateHTML(string PathURL)
    {

        //保存路径
        string SavePath = PathURL + ".htm";
        //请求路径(删除前缀的~标识)
        string RequestPath = PathURL.TrimStart('~')+".aspx";
        //下载文件(原路径保存)
        Common.DownFile.CreateStaticByWebClient(RequestPath, SavePath);
        return true;
    } 
    #endregion
}
