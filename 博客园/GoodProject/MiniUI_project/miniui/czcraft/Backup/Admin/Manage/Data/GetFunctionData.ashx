<%@ WebHandler Language="C#" Class="GetFunctionData" %>

using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
public class GetFunctionData : IHttpHandler
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
            case "SearchFunction":
                SearchFunction(context);
                break;
            case "SaveFunction":
                SaveFunction(context);
                break;
            case "RemoveFunction":
                RemoveFunction(context);
                break;
            case "GetFunction":
                GetFunction(context);
                break;
            default:
                return;


        }
    }
    /// <summary>
    /// 搜索调用
    /// </summary>
    /// <param name="context"></param>
    public void SearchFunction(HttpContext context)
    {
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
        string strCondition = "";
        WEB_SYS_FUNTIONBLL bll = new WEB_SYS_FUNTIONBLL();
        //分页数据读取
        IEnumerable<WEB_SYS_FUNTION> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = Common.FormatToJson.MiniUiListToJson<WEB_SYS_FUNTION>((IList<WEB_SYS_FUNTION>)list, totalPage, "");
        context.Response.Write(json);
    }
    /// <summary>
    /// 获取功能信息
    /// </summary>
    /// <param name="context">上下文</param>
    public void GetFunction(HttpContext context)
    {
        string strid = context.Request["id"];
        int id = 0;
        if (!string.IsNullOrEmpty(strid) && int.TryParse(strid, out id))
        {
            //获取功能信息
            WEB_SYS_FUNTION group = new WEB_SYS_FUNTIONBLL().Get(id);

            context.Response.Write(Common.FormatToJson.ScriptSerializationToJson(group));
        }
    }
    /// <summary>
    /// 保存资料业务
    /// </summary>
    /// <param name="context"></param>
    public void SaveFunction(HttpContext context)
    {
        //用户json数据读取
        //数据为[{"LOGNAME":"tianzh","FunctionID":"1","PASSWORD":"tian815100","REALNAME":"tianzhuanghu","MEMO":"tianzhuanghu"}]
        String FunctionStr = context.Request["Function"];
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(context.Server.MapPath("tianzh1.txt"), true);
        //sw.Write(FunctionStr);
      
        if (string.IsNullOrEmpty(FunctionStr))
            return;

        ////使用Newtonsoft.Json.dll组件解析json对象
        ////首先过滤掉json中的[和]
            string info = FunctionStr.TrimStart('[');
            info = info.TrimEnd(']');
            JObject o = JObject.Parse(info);
            string NAME = (string)o.SelectToken("NAME");
            string URL = (string)o.SelectToken("URL");
            string FATHER_ID =o.SelectToken("FATHER_ID").ToString ();
            string STATE = (string)o.SelectToken("STATE");
            string DESCRIPTION = (string)o.SelectToken("DESCRIPTION");
            WEB_SYS_FUNTION FUNTION = new WEB_SYS_FUNTION();

        FUNTION.FUNTION_ID = (int?)o.SelectToken("FUNTION_ID");
               
                //保存用户数据的model对象
            int F_ID=0;
            int.TryParse(FATHER_ID,out F_ID);
          
            FUNTION.FATHER_ID = F_ID;
            FUNTION.NAME = NAME;
            FUNTION.STATE = STATE=="true"?"1":"0";
            FUNTION.URL = URL;
            FUNTION.DESCRIPTION = DESCRIPTION;
            if (FUNTION.FUNTION_ID.HasValue)
            {
                if (new WEB_SYS_FUNTIONBLL().Update(FUNTION))
                    context.Response.Write("修改操作成功!");
                else context.Response.Write("修改操作失败!");
            }
            else
            {
                if (new WEB_SYS_FUNTIONBLL().AddNew(FUNTION) > 0)
                    context.Response.Write("增加操作成功!");
                else
                    context.Response.Write("增加操作失败!");
            }


    }
    /// <summary>
    /// 删除资料业务
    /// </summary>
    /// <param name="context"></param>
    public void RemoveFunction(HttpContext context)
    {
        String idStr = context.Request["id"];
        //检验客户端字符串
        if (Common.Tools.IsValidInput(ref idStr, true))
        {
            int id = Convert.ToInt32(idStr);
            if (new WEB_SYS_FUNTIONBLL().Delete(id))
                context.Response.Write("删除成功!");
            else context.Response.Write("删除失败!");
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