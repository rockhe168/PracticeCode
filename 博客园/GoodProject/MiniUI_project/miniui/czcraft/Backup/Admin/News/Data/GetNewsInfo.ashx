<%@ WebHandler Language="C#" Class="GetNewsInfo" %>

using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
public class GetNewsInfo : IHttpHandler
{

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

            case "SaveNews":
                SaveNews(context);
                break;
            case "LoadNewsInfo":
                LoadNewsInfo(context);
                break;
            case "SearchNewsContent":
                SearchNewsContent(context);
                break;
            case "RemoveNews":
                RemoveNews(context);
                break;
            case "GetNewsType":
                GetNewsType(context);
                break;
            case "AddNewsType":
                AddNewsType(context);
                break;
            case "RemoveNewsType":
                RemoveNewsType(context);
                break;
            case "SaveNewsType":
                SaveNewsType(context);
                break;
            default:
                return;


        }
    }
    /// <summary>
    /// 加载新闻信息
    /// </summary>
    /// <param name="context"></param>
    public void LoadNewsInfo(HttpContext context)
    {
       string id=context.Request["id"];
       if (Common.Tools.IsValidInput(ref id, true))
       {

           news newsInfo = new newsBLL().Get(Convert.ToInt32(id));

           context.Response.Write(newsBLL.EditNewsInfoToJson(newsInfo));
       }
    }
    /// <summary>
    /// 删除新闻
    /// </summary>
    /// <param name="context"></param>
    public void RemoveNews(HttpContext context)
    {
        string id = context.Request["id"];
        if (Common.Tools.IsValidInput(ref id, true))
        {
            context.Response.Write(new newsBLL().DeleteMoreID(id));
            IndexManager.GetInstance(IndexManager.JobSearchType.News).RemoveJob(Convert.ToInt32(id));
        }
    }
    /// <summary>
    /// 获取新闻内容
    /// </summary>
    /// <param name="Context"></param>
    public void SearchNewsContent(HttpContext context)
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
        else if (!string.IsNullOrEmpty(key))
            strCondition += "Title like '%" + key + "%'";
        newsBLL bll = new newsBLL();
        //分页数据读取
        IEnumerable<news> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = newsBLL.MiniUiListToJson(list, totalPage, "");


        context.Response.Write(json);
    }
    /// <summary>
    /// 添加新闻
    /// </summary>
    /// <param name="context"></param>
    public void SaveNews(HttpContext context)
    {
        //[{"Title":"521521","NewsTypeID":"3","Content":"21521521"}]
            news newsInfo = new news();
            string NewsData = context.Request["NewsData"];

                //使用Newtonsoft.Json.dll组件解析json对象
            //首先过滤掉json中的[和]
                string info = NewsData.TrimStart('[');
                info = info.TrimEnd(']');
        
                JObject o = JObject.Parse(info);    
            newsInfo.Title = (string)o.SelectToken("Title");
              
                string tempId =(string)o.SelectToken("NewsTypeID");
                newsInfo.Type=new newstype ();
                newsInfo.Type.Id= Convert.ToInt32(tempId);
                newsInfo.Time = DateTime.Now;
                newsInfo.Content = (string)o.SelectToken("Content");
                newsInfo.Id = (int?)o.SelectToken("id");
                newsInfo.ArticleHtmlUrl = "#";
                if (!newsInfo.Id.HasValue)  
                {
                    int Id=new newsBLL().AddNew(newsInfo);
                    IndexManager.GetInstance(IndexManager.JobSearchType.News).AddJob(Id);
                    context.Response.Write(Id > 0);
                    
                   
                }
                else//修改
                {
                   context.Response.Write(new newsBLL().Update(newsInfo));
                   IndexManager.GetInstance(IndexManager.JobSearchType.News).AddJob(newsInfo.Id.Value);
                }
        
       
       
        
    }
    /// <summary>
    /// 保存新闻类别信息
    /// </summary>
    /// <param name="context"></param>
    public void SaveNewsType(HttpContext context)
    {

        bool result = false;
        string id = context.Request["id"];
        string text = context.Request["text"];
        if (Common.Tools.IsValidInput(ref id, true) && Common.Tools.IsValidInput(ref text, true))
        {
            newstype type = new newstype();
            type.Id =Convert.ToInt32(id);
            type.Name = text;
            result = new newstypeBLL().Update(type);

        }
        context.Response.Write(result);
    }
    /// <summary>
    /// 添加类别信息
    /// </summary>
    /// <param name="context"></param>
    public void AddNewsType(HttpContext context)
    {
        newstype type = new newstype();
        string text = context.Request["text"];
        if (Common.Tools.IsValidInput(ref text, true))
        {
            type.Name = text;
            context.Response.Write(new newstypeBLL().AddNew(type) > 0);
        }
        else context.Response.Write(false);
    }
 
    /// <summary>
    /// 加载类别信息
    /// </summary>
    /// <param name="context"></param>
    public void GetNewsType(HttpContext context)
    {
        context.Response.Write(new newstypeBLL().GetNewsTypeInfoByJson());

    }
    /// <summary>
    /// 删除类别信息
    /// </summary>
    /// <param name="context"></param>
    public void RemoveNewsType(HttpContext context)
    {
        string id = context.Request["id"];
        if (Common.Tools.IsValidInput(ref id, true))
        {
            context.Response.Write(new newstypeBLL().DeleteMoreID(id));
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