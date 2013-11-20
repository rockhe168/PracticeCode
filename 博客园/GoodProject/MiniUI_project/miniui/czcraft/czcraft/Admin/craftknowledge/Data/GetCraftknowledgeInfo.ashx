<%@ WebHandler Language="C#" Class="GetCraftknowledgeInfo" %>

using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
public class GetCraftknowledgeInfo : IHttpHandler
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

            case "SaveCraftknowledge":
                SaveCraftknowledge(context);
                break;
            case "LoadCraftknowledge":
                LoadCraftknowledge(context);
                break;
            case "SearchCraftknowledgeContent":
                SearchCraftknowledgeContent(context);
                break;
            case "RemoveCraftknowledge":
                RemoveCraftknowledge(context);
                break;
            case "GetCraftknowledgeTypeForCombox":
                GetCraftknowledgeTypeForCombox(context);
                break;
            case "GetCraftknowledgeType":
                GetCraftknowledgeType(context);
                break;
         
            default:
                return;


        }
    }
    /// <summary>
    /// 加载工艺知识信息
    /// </summary>
    /// <param name="context"></param>
    public void LoadCraftknowledge(HttpContext context)
    {
       string id=context.Request["id"];
       if (Common.Tools.IsValidInput(ref id, true))
       {

           craftknowledge CraftknowledgeInfo = new craftknowledgeBLL().Get(Convert.ToInt32(id));

           context.Response.Write(craftknowledgeBLL.EditcraftknowledgeInfoToJson(CraftknowledgeInfo));
       }
    }
    /// <summary>
    /// 删除工艺知识
    /// </summary>
    /// <param name="context"></param>
    public void RemoveCraftknowledge(HttpContext context)
    {
        string id = context.Request["id"];
        if (Common.Tools.IsValidInput(ref id, true))
        {
            context.Response.Write(new craftknowledgeBLL().DeleteMoreID(id));
            //删除工艺知识索引
            IndexManager.GetInstance(IndexManager.JobSearchType.Knowledge).RemoveJob(Convert.ToInt32(id));
               
        }
    }
    /// <summary>
    /// 获取工艺知识内容
    /// </summary>
    /// <param name="Context"></param>
    public void SearchCraftknowledgeContent(HttpContext context)
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
        else if (!Common.Tools.IsNullOrEmpty(key))
            strCondition += "Title like '%" + key + "%'";
        craftknowledgeBLL bll = new craftknowledgeBLL();
        //分页数据读取
        IEnumerable<craftknowledge> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = craftknowledgeBLL.MiniUiListToJson(list, totalPage, "");


        context.Response.Write(json);
    }
    /// <summary>
    /// 添加工艺知识
    /// </summary>
    /// <param name="context"></param>
    public void SaveCraftknowledge(HttpContext context)
    {
        //[{"Title":"521521","CraftknowledgeTypeID":"3","Content":"21521521"}]
     
        craftknowledge CraftknowledgeInfo = new craftknowledge();
        string CraftknowledgeData = context.Request["CraftknowledgeData"];
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(context.Server.MapPath("tzt.txt"), true);
        //sw.Write(CraftknowledgeData);
        //sw.Close();
                //使用Newtonsoft.Json.dll组件解析json对象
            //首先过滤掉json中的[和]
                string info = CraftknowledgeData.TrimStart('[');
                info = info.TrimEnd(']');
        
                JObject o = JObject.Parse(info);    
            CraftknowledgeInfo.Title = (string)o.SelectToken("Title");
              
                string tempTypeId =(string)o.SelectToken("TypeID");
                CraftknowledgeInfo.type=new crafttype ();
                CraftknowledgeInfo.type.ID = Convert.ToInt32(tempTypeId);
                CraftknowledgeInfo.Time = DateTime.Now;
                CraftknowledgeInfo.Crafttype = (string)o.SelectToken("Crafttype");
                
                CraftknowledgeInfo.Content = (string)o.SelectToken("Content");
                CraftknowledgeInfo.Id = (int?)o.SelectToken("id");
                CraftknowledgeInfo.ArticleHtmlUrl = "#";
                if (!CraftknowledgeInfo.Id.HasValue)  
                {

                    int Id = new craftknowledgeBLL().AddNew(CraftknowledgeInfo);
                     IndexManager.GetInstance(IndexManager.JobSearchType.Knowledge).AddJob(Id);
                     context.Response.Write(Id > 0);
                    //加入索引库
                   
                   
                }
                else//修改
                {
                    context.Response.Write(new craftknowledgeBLL().Update(CraftknowledgeInfo));
         
                    //加入索引库
                    IndexManager.GetInstance(IndexManager.JobSearchType.Knowledge).AddJob(CraftknowledgeInfo.Id.Value);
                }
        
       
       
        
    }

    /// <summary>
    /// 为工艺知识类别下拉框json数据生成
    /// </summary>
    /// <param name="context"></param>
    public void GetCraftknowledgeTypeForCombox(HttpContext context)
    {
       // context.Response.Write(new craftknowledgeBLL().GetCraftknowledgeByJson());
    }
    /// <summary>
    /// 加载类别信息
    /// </summary>
    /// <param name="context"></param>
    public void GetCraftknowledgeType(HttpContext context)
    {
       // context.Response.Write(new craftknowledgeBLL().GetCraftknowledgeTypeInfoByJson());

    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}