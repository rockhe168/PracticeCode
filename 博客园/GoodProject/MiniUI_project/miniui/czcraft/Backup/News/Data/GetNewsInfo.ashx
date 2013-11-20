<%@ WebHandler Language="C#" Class="GetNewsInfo" %>

using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
using Common;
public class GetNewsInfo : IHttpHandler {
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

            case "GetTopNewsForMain":
                GetTopNewsForMain(context);
                break;
            case "GetNewsTypeForCombox":
                GetNewsTypeForCombox(context);
                break;
        
            default:
                return;


        }
    }
    /// <summary>
    /// 新闻展示
    /// </summary>
    /// <param name="context"></param>
    public void GetTopNewsForMain(HttpContext context)
    {  //创建缓存工厂
        CacheStorage.ICacheStorage Cache = CacheStorage.CacheFactory.CreateCacheFactory();
        string cache = Convert.ToString(Cache.Get("TopNews"));
        string JsonData = "";//返回的json数据
        if (string.IsNullOrEmpty(cache))//如果缓存为空
        {

         
            //读取排名前三的新闻并转化为json格式
            JsonData = newsBLL.GetNewsForMainByJson(3);
            //插入缓存(时间从配置文件中读取)
            Cache.Insert("TopNews", JsonData, CacheManage.GetTimeConfig("TopRankInfo"));
         
        }
        else
        {
            JsonData = cache;
        }


        context.Response.Write(JsonData);
        
    }
    /// <summary>
    /// 为新闻类别下拉框json数据生成
    /// </summary>
    /// <param name="context"></param>
    public void GetNewsTypeForCombox(HttpContext context)
    { //创建缓存工厂
        CacheStorage.ICacheStorage Cache = CacheStorage.CacheFactory.CreateCacheFactory();
        string cache = Convert.ToString(Cache.Get("GetNewsType"));
        string JsonData = "";//返回的json数据
        if (string.IsNullOrEmpty(cache))//如果缓存为空
        {
         
            //读取数据并转化为json格式
            JsonData = new newstypeBLL().GetNewsTypeInfoForNewsByJson();
            //插入缓存(时间从配置文件中读取)
            Cache.Insert("GetNewsType", JsonData, CacheManage.GetTimeConfig("NewsType"));
           
        }
        else
        {
            JsonData = cache;
        }


        context.Response.Write(JsonData);

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}