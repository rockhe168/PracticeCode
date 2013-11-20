<%@ WebHandler Language="C#" Class="GetUserGroupData" %>

using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
public class GetUserGroupData : IHttpHandler {
    
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
            case "SearchUserGroup":
                SearchUserGroup(context);
                break;
            case "SaveUserGroup":
                SaveUserGroup(context);
                break;
            case "RemoveUserGroup":
                RemoveUserGroup(context);
                break;
            case "GetUserGroup":
                GetUserGroup(context);
                break;
            default:
                return;


        }
    }
    /// <summary>
    /// 搜索调用
    /// </summary>
    /// <param name="context"></param>
    public void SearchUserGroup(HttpContext context)
    {
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
        string strCondition = "";
        WEB_USERGROUPBLL bll = new WEB_USERGROUPBLL();
        //分页数据读取
        IEnumerable<WEB_USERGROUP> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json =Common.FormatToJson.MiniUiListToJson<WEB_USERGROUP>((IList<WEB_USERGROUP>)list, totalPage, "");
        context.Response.Write(json);
    }
    /// <summary>
    /// 获取用户组信息
    /// </summary>
    /// <param name="context">上下文</param>
    public void GetUserGroup(HttpContext context)
    {
          string strid=context.Request["id"];
        int id=0;
        if (!string.IsNullOrEmpty(strid) && int.TryParse(strid, out id))
        {
            //获取用户组信息
            WEB_USERGROUP group = new WEB_USERGROUPBLL().Get(id);

            context.Response.Write(Common.FormatToJson.ScriptSerializationToJson(group));
        }
    }
    /// <summary>
    /// 保存资料业务
    /// </summary>
    /// <param name="context"></param>
    public void SaveUserGroup(HttpContext context)
    {
        //用户json数据读取
        //数据为[{"LOGNAME":"tianzh","USERGROUPID":"1","PASSWORD":"tian815100","REALNAME":"tianzhuanghu","MEMO":"tianzhuanghu"}]
        String UserGroupStr = context.Request["UserGroup"];
        if (string.IsNullOrEmpty(UserGroupStr))
            return;

            ////使用Newtonsoft.Json.dll组件解析json对象
            ////首先过滤掉json中的[和]
            string info = UserGroupStr.TrimStart('[');
            info = info.TrimEnd(']');
            JObject o = JObject.Parse(info);
            string USERGROUP = (string)o.SelectToken("USERGROUP");
           string DESCRIPTION = (string)o.SelectToken("DESCRIPTION");

            WEB_USERGROUP group = new WEB_USERGROUP();         
            group.ID = (int?)o.SelectToken("ID");

            //保存用户数据的model对象
            group.USERGROUP = USERGROUP;
            group.DESCRIPTION = DESCRIPTION;

            if (group.ID.HasValue)
                new WEB_USERGROUPBLL().Update(group);
            else
                new WEB_USERGROUPBLL().AddNew(group);

       
     
    }
    /// <summary>
    /// 删除资料业务
    /// </summary>
    /// <param name="context"></param>
    public void RemoveUserGroup(HttpContext context)
    {
        String idStr = context.Request["id"];
        //检验客户端字符串
        if (Common.Tools.IsValidInput(ref idStr, true))
        {
            new WEB_USERGROUPBLL().DeleteMoreID(idStr);
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}