<%@ WebHandler Language="C#" Class="UrlInfo" %>

using System;
using System.Web;
using czcraft.BLL;
using czcraft.Model;
using Common;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
public class UrlInfo : IHttpHandler {


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
            case "GetURLInfo":
                GetURLInfo(context);
                break;
            case "ToHtml":
                ToHtml(context);
                break;
            case "SearchSystemLog":
                SearchSystemLog(context);
                break;
            case "RemoveSystemLog":
                RemoveSystemLog(context);
                break;
            case "SearchCacheInfo":
                SearchCacheInfo(context);
                break;
            case "UpdateCacheInfo":
                UpdateCacheInfo(context);
                break;
                
            default:
                return;


        }
    }
    /// <summary>
    /// 更新缓存信息
    /// </summary>
    /// <param name="context"></param>
    public void UpdateCacheInfo(HttpContext context)
    {
        string CacheInfo = context.Request["CacheInfo"];
      CacheInfo=CacheInfo.Trim(new char[] { '[', ']' });
      JObject o = JObject.Parse(CacheInfo);
    string Id=(string)o.SelectToken("Id");
    int Day = (int)o.SelectToken("Day");
    int Hour = (int)o.SelectToken("Hour");
    context.Response.Write(new CacheManage().UpdateCacheInfo(Id, Day, Hour));
    }
    /// <summary>
    ///  查询缓存信息
    /// </summary>
    /// <param name="context"></param>
    public void SearchCacheInfo(HttpContext context)
    {
        //查询条件
       // string key = context.Request["key"];
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        ////字段排序
        //String sortField = context.Request["sortField"];
        //String sortOrder = context.Request["sortOrder"];
        //JSON 序列化
        string json = new CacheManage().GetCacheAllInfoForMiniUIJson(pageIndex,pageSize);
        context.Response.Write(json);
    }
    /// <summary>
    /// 删除系统日志
    /// </summary>
    /// <param name="context">删除系统日志</param>
    public void RemoveSystemLog(HttpContext context)
    {
        //清空三天前的日志
        context.Response.Write(new SystemLogBLL().ClearSystemLog());
    }
    /// <summary>
    /// 获取系统日志信息
    /// </summary>
    /// <param name="context"></param>
    public void SearchSystemLog(HttpContext context)
    {
        //查询条件
        string key = context.Request["key"];
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
        string strCondition = "";
        //对搜索内容进行验证
        if (!Common.Tools.IsValidInput(ref key, false))
        {
            return;
        }
        else
            strCondition = SystemLogBLL.ConfirmCondition(key);//判断查询条件
        SystemLogBLL bll = new SystemLogBLL();
        //分页数据读取
        IEnumerable<SystemLog> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "0" : "1", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = SystemLogBLL.MiniUiListToJson(list, totalPage, "");


        context.Response.Write(json);
    }
    
    /// <summary>
    /// 页面html
    /// </summary>
    /// <param name="context"></param>
    public void ToHtml(HttpContext context)
    {
      string Ids= context.Request["Id"];
       
        URLXMLInfoManage xmlManage = URLXMLInfoManage.Instance();
        //写回XML中
       context.Response.Write(xmlManage.SetURLInfo(Ids)); 
    }
    /// <summary>
    /// 获取URL信息(生成html的)
    /// </summary>
    /// <param name="context"></param>
    public void GetURLInfo(HttpContext context)
    {
        URLXMLInfoManage xmlManage = URLXMLInfoManage.Instance();

        context.Response.Write(xmlManage.GetURLInfoForJson());
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}