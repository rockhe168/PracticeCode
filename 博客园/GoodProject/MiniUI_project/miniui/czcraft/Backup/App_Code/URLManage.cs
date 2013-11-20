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
using System.Text;
using System.Text.RegularExpressions;
using Common;

/// <summary>
///StaticHtmlPageManage用来控制静态页面连接重写
/// </summary>
public class URLManage
{
    /// <summary>
    /// 用于html页面生成和动态页面切换配置
    /// </summary>
    public URLManage()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 转化为绝对路径(为css提供)
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string ToAbsoluteURL(string path)
    {
        return VirtualPathUtility.ToAbsolute(path);  
    }
    /// <summary>
    /// 获得路径(暂时只做静态页面管理)(/*在这里可以扩展出URL重写*/)
    /// </summary>
    /// <param name="PageUrl">页面的URL(不包括扩展名)</param>
    /// <param name="QueryString">页面参数</param>
    /// <returns></returns>
    public static string GetURL(string PageUrl,string QueryString)
    {
        //页面路径
        string PagePath = "";
        
        //如果当前的参数不为空,则加上?
        if (QueryString != "")
            QueryString = "?" + QueryString;
        //如果是静态页面(从配置文件中读取静态页面状态(是否))
        if (ReadURLConfig(PageUrl) == true)
        {
            PagePath = PageUrl + ".htm";
        }
        //如果是动态页面
        else
            PagePath = PageUrl + ".aspx";
        //把相对路径转化为绝对路径
        return   System.Web.VirtualPathUtility.ToAbsolute(PagePath)+QueryString ;
    }
    /// <summary>
    /// 从配置文件中读取是否生成静态页面
    /// </summary>
    /// <param name="PageName">页面的名称</param>
    /// <returns></returns>
    public static bool ReadURLConfig(string PageURL)
    {
        //读取配置文件
        string path = HttpContext.Current.Server.MapPath(@"~/Admin/ConfigManage/URLConfig.xml");
        //XmlHelper.Read(path, "/Node/Element[@Attribute='Name']", "Attribute")
        //是否生成HTML
        string IsHtml="false";
        IsHtml=XMlHelper.Read(path, "/PageSettings/Page[@PageURL='"+PageURL+"']", "IsHtml");
        if (IsHtml.ToLower() == "true")
        {
            return true;
        }
        else return false;
       
    }
  
    /// <summary>
    /// url路径处理(转化为客户端的url,母板页也可以用,相当于加强版本的Page.ResolveUrl)
    /// </summary>
    /// <param name="relativeUrl">相对路径</param>
    /// <returns></returns>
    public static string ResolveUrl(string relativeUrl)
    {
        if (relativeUrl == null) throw new ArgumentNullException("relativeUrl");

        if (relativeUrl.Length == 0 || relativeUrl[0] == '/' ||
            relativeUrl[0] == '\\') return relativeUrl;

        int idxOfScheme =
          relativeUrl.IndexOf(@"://", StringComparison.Ordinal);
        if (idxOfScheme != -1)
        {
            int idxOfQM = relativeUrl.IndexOf('?');
            if (idxOfQM == -1 || idxOfQM > idxOfScheme) return relativeUrl;
        }

        StringBuilder sbUrl = new StringBuilder();
        sbUrl.Append(HttpRuntime.AppDomainAppVirtualPath);
        if (sbUrl.Length == 0 || sbUrl[sbUrl.Length - 1] != '/') sbUrl.Append('/');

        // found question mark already? query string, do not touch!
        bool foundQM = false;
        bool foundSlash; // the latest char was a slash?
        if (relativeUrl.Length > 1
            && relativeUrl[0] == '~'
            && (relativeUrl[1] == '/' || relativeUrl[1] == '\\'))
        {
            relativeUrl = relativeUrl.Substring(2);
            foundSlash = true;
        }
        else foundSlash = false;
        foreach (char c in relativeUrl)
        {
            if (!foundQM)
            {
                if (c == '?') foundQM = true;
                else
                {
                    if (c == '/' || c == '\\')
                    {
                        if (foundSlash) continue;
                        else
                        {
                            sbUrl.Append('/');
                            foundSlash = true;
                            continue;
                        }
                    }
                    else if (foundSlash) foundSlash = false;
                }
            }
            sbUrl.Append(c);
        }

        return sbUrl.ToString();
    }

}
