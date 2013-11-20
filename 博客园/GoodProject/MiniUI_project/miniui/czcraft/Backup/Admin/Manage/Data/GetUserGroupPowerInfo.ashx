<%@WebHandler Language="C#" Class="GetUserGroupPowerInfo" %>
using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
public class GetUserGroupPowerInfo : IHttpHandler
{

   
    public void ProcessRequest(HttpContext context)
    {
        String methodName = context.Request["method"];
        if (!string.IsNullOrEmpty(methodName))
            CallMethod(methodName, context);
    }
   #region 业务调用
		 /// <summary>
    /// 根据业务需求调用不同的方法
    /// </summary>
    /// <param name="Method">方法</param>
    /// <param name="context">上下文</param>
    public void CallMethod(string Method, HttpContext context)
    {
        switch (Method)
        {
            case "SearchPower":
                SearchPower(context);
                break;
            case "SaveGroupPowerInfo":
                SaveGroupPowerInfo(context);
                break;
            case "RemoveGroupPowerInfo":
                RemoveGroupPowerInfo(context);
                break;
            case "GetGroupPowerNotHaveInfo":
                GetGroupPowerNotHaveInfo(context);
                break;
            //case "GetFunction":
            //    GetFunction(context);
            //    break;
            default:
                return;


        }
    }
    /// <summary>
    /// 保存当前用户组功能信息
    /// </summary>
    /// <param name="context"></param>
    public void SaveGroupPowerInfo(HttpContext context)
    {
        //增加:{"FUNTION_ID":12,"group_function_state":"1","DESCRIPTION":"1111"}
        //更新{"FUNTION_ID":11,"group_function_state":"1","DESCRIPTION":"二级菜单","ID":7}
        String GroupPowerStr = context.Request["GroupPower"];
        string USERGROUPID = context.Request["group"];
        if (string.IsNullOrEmpty(GroupPowerStr) ||!Common.Tools.IsNumber(USERGROUPID)) //做传参验证
            return;
        ////使用Newtonsoft.Json.dll组件解析json对象
        ////首先过滤掉json中的[和]
        string info = GroupPowerStr.TrimStart('[');
        info = info.TrimEnd(']');
        JObject o = JObject.Parse(info);
        string STATE = (string)o.SelectToken("group_function_state");
        string DESCRIPTION = (string)o.SelectToken("DESCRIPTION");
        int FUNTION_ID;
        FUNTION_ID = (int)o.SelectToken("FUNTION_ID");

        WEB_USERGROUP_FUNCTIONS USERGROUPFUNTION = new WEB_USERGROUP_FUNCTIONS();

        USERGROUPFUNTION.ID = (int?)o.SelectToken("ID");
        USERGROUPFUNTION.STATE = STATE;
        USERGROUPFUNTION.FUNCTION_ID = FUNTION_ID;
        USERGROUPFUNTION.USERGROUPID =Convert.ToInt32( USERGROUPID);
       string resultInfo;
       if (USERGROUPFUNTION.ID.HasValue)//做修改操作
       {

           if (new WEB_USERGROUP_FUNCTIONSBLL().Update(USERGROUPFUNTION))
           {
               resultInfo = "修改成功!";
           }
           else {
               resultInfo = "修改失败!";
           }
       }
       else {
           if (new WEB_USERGROUP_FUNCTIONSBLL().AddNew(USERGROUPFUNTION)>0)
           {
               resultInfo = "新增成功!";
           }
           else
           {
               resultInfo = "新增失败!";
           }
       }
       context.Response.Write(resultInfo);
        
    }
    /// <summary>
    /// 去除当前用户功能组
    /// </summary>
    /// <param name="context"></param>
    public void RemoveGroupPowerInfo(HttpContext context)
    {
        String idStr = context.Request["id"];
        if (String.IsNullOrEmpty(idStr)) return;
        //检验客户端字符串
        if (Common.Tools.IsValidInput(ref idStr, true))
        {
            if (new WEB_USERGROUP_FUNCTIONSBLL().DeleteMoreID(idStr))
            {
                context.Response.Write("删除成功!");
            }
            else {
                context.Response.Write("删除失败!");
            }
        }  
    }
	#endregion
    /// <summary>
    /// 获取当前用户组未拥有的功能组
    /// </summary>
    /// <param name="context"></param>
    public void GetGroupPowerNotHaveInfo(HttpContext context)
    {
        //查询条件
        string key = context.Request["key"];
      
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = "NAME";
        String sortOrder = "asc";
        if (!Common.Tools.IsNullOrEmpty(context.Request["sortField"]))
        {
            sortField = context.Request["sortField"].ToString();
        }
        if (!Common.Tools.IsNullOrEmpty(context.Request["sortOrder"]))
        {
            sortOrder = context.Request["sortOrder"].ToString();
        }
        string strCondition = "";
        //对搜索内容进行验证
        if (!Common.Tools.IsValidInput(ref key, false))
        {
            return;
        }
        else if (!string.IsNullOrEmpty(key))
            strCondition += "USERGROUPID !=" + key + " or USERGROUPID is NULL";
          string View="VUserGroupNotHaveFunction";
        //分页数据读取
          WEB_SYS_FUNTIONBLL bll = new WEB_SYS_FUNTIONBLL();
          DataTable dt = bll.ListByPaginationByTable(View, sortField, "[NAME],DESCRIPTION,FUNTION_ID", pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
          
           
        //获取总页数
          int totalPage = bll.GetCount(View,strCondition);
        //JSON 序列化
        
        string json = Common.FormatToJson.MiniUiToJsonFormat(Common.FormatToJson.ToJson(dt),totalPage);
        context.Response.Write(json);
    
    }
    #region 搜索
    /// <summary>
    /// 搜索调用
    /// </summary>
    /// <param name="context"></param>
    public void SearchPower(HttpContext context)
    {   //查询条件
        string key = context.Request["key"];
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);

        //字段排序
        String sortField = "NAME";
        String sortOrder = "asc";
        if (!Common.Tools.IsNullOrEmpty(context.Request["sortField"]))
        {
            sortField = context.Request["sortField"].ToString();
        }
        if (!Common.Tools.IsNullOrEmpty(context.Request["sortOrder"]))
        {
            sortOrder = context.Request["sortOrder"].ToString();
        }
        string strCondition = "";
        //对搜索内容进行验证
        if (!Common.Tools.IsValidInput(ref key, false))
        {
            return;
        }
        else if (!string.IsNullOrEmpty(key))
            strCondition += " USERGROUPID = " + key;
        VGroupFunctionBLL bll = new VGroupFunctionBLL();
        //分页数据读取
        IEnumerable<VGroupFunction> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化sortField=NAME&sortOrder=asc&pageIndex=0&pageSize=10
        string json = Common.FormatToJson.MiniUiListToJson<VGroupFunction>((IList<VGroupFunction>)list, totalPage, "");
        context.Response.Write(json);
    } 
    #endregion
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}