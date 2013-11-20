<%@ WebHandler Language="C#" Class="CraftKnowledgeInfo" %>

using System;
using System.Web;
using czcraft.BLL;
using Common;
public class CraftKnowledgeInfo : IHttpHandler {

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

            case "GetCraftKnowledgeForMain":
                GetCraftKnowledgeForMain(context);
                break;
            //case "GetNewsTypeForCombox":
            //    GetNewsTypeForCombox(context);
            //    break;

            default:
                return;


        }
    }
    /// <summary>
    /// 工艺知识展示
    /// </summary>
    /// <param name="context"></param>
    public void GetCraftKnowledgeForMain(HttpContext context)
    {
        //创建缓存工厂
        CacheStorage.ICacheStorage Cache = CacheStorage.CacheFactory.CreateCacheFactory();
        string cache = Convert.ToString(Cache.Get("TopCraftKnowledge"));
        string JsonData = "";//返回的json数据
        if (string.IsNullOrEmpty(cache))//如果缓存为空
        {
            //读取排名前三的新闻并转化为json格式
            
            JsonData =craftknowledgeBLL.GetCraftKnowledgeForMainByJson(3);

            //插入缓存(时间从配置文件中读取)
            Cache.Insert("TopCraftKnowledge", JsonData, CacheManage.GetTimeConfig("ProductType"));
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