<%@ WebHandler Language="C#" Class="GetUserInfoData" %>

using System;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using czcraft.Model;
using czcraft.BLL;
using Common;
public class GetUserInfoData : IHttpHandler {
    public void ProcessRequest(HttpContext context)
    {
        String methodName = context.Request["method"];
        if(!string.IsNullOrEmpty(methodName))
            CallMethod(methodName, context);
    }
   /// <summary>
    /// 根据业务需求调用不同的方法
   /// </summary>
   /// <param name="Method">方法</param>
   /// <param name="context">上下文</param>
    public void CallMethod(string Method,HttpContext context)
    {
        switch (Method)
        {
            case "SearchUserInfo": 
                SearchUserInfo(context);
                break;
            case "SaveUserInfo":
                SaveUserInfo(context);
                break;
            case "RemoveUserInfo":
                RemoveUserInfo(context);
                break;
            case "GetUserInfo":
                GetUserInfo(context);
                break;
            case "GetUserGroup":
                GetUserGroup(context);
                break;
            case "UpdateUserInfo":
                UpdateUserInfo(context);
                break;
            default:
                return;
                   
        
        }
    }
    /// <summary>
    /// 更新用户权限信息
    /// </summary>
    /// <param name="context"></param>
    public void UpdateUserInfo(HttpContext context)
    {
        WEB_USER user=new WEB_USER ();
        string id = context.Request["id"];
        string state = context.Request["state"];
        if (Tools.IsValidInput(ref id, true) && Tools.IsValidInput(ref state, true))
        { 
            user.ID=Convert.ToInt32(id);
            user.STATE=(state=="1"?"0":"1");//这里要反向操作
            context.Response.Write(new WEB_USERBLL().UpdateState(user));
        }
       }
    /// <summary>
    /// 搜索调用
    /// </summary>
    /// <param name="context"></param>
    public void SearchUserInfo(HttpContext context)
    {
        //查询条件
        string key = context.Request["key"];
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
       string strCondition="";
        //对搜索内容进行验证
       if (!Common.Tools.IsValidInput(ref key,false))
       {
           return;
       }
       else if(!string.IsNullOrEmpty(key))
           strCondition += "REALNAME like '%" + key + "%'";
        WEB_USERBLL bll = new WEB_USERBLL();
        //分页数据读取
        IEnumerable<WEB_USER> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
         //JSON 序列化
         string json =WEB_USERBLL.MiniUiListToJson(list, totalPage, "");
      
       
        context.Response.Write(json);
    }
    /// <summary>
    /// 获取用户组信息
    /// </summary>
    /// <param name="context">上下文</param>
    public void GetUserGroup(HttpContext context)
    {
        //获取用户组信息
        IEnumerable<WEB_USERGROUP> list = new WEB_USERGROUPBLL().ListAll();

        context.Response.Write(Common.FormatToJson.ListToJsonNoName((IList<WEB_USERGROUP>)list));
    }
   /// <summary>
   /// 保存资料业务
   /// </summary>
   /// <param name="context"></param>
    public void SaveUserInfo(HttpContext context)
    {
        //用户json数据读取
        //数据为[{"LOGNAME":"tianzh","USERGROUPID":"1","PASSWORD":"tian815100","REALNAME":"tianzhuanghu","MEMO":"tianzhuanghu"}]
        String UserInfoStr = context.Request["UserInfo"];
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(context.Server.MapPath("tzh.txt"));
        //sw.Write(UserInfoStr);
        //sw.Close();
        //使用Newtonsoft.Json.dll组件解析json对象
        //首先过滤掉json中的[和]
        string info = UserInfoStr.TrimStart('[');
        info = info.TrimEnd(']');
        JObject o = JObject.Parse(info);
        string LOGNAME = (string)o.SelectToken("LOGNAME");
        string USERGROUPID = (string)o.SelectToken("USERGROUPID");
        string PASSWORD = (string)o.SelectToken("PASSWORD");
        string REALNAME = (string)o.SelectToken("REALNAME");
        string MEMO = (string)o.SelectToken("MEMO");
       
        //保存用户数据的model对象
      WEB_USER user = new WEB_USER();
      //  //对象的赋值
        user.LOGNAME =LOGNAME ;
        WEB_USERGROUP group = new WEB_USERGROUP();
        group.ID =Convert.ToInt32(USERGROUPID);
        user.GROUP = group;
        user.PASSWORD = PASSWORD;
        user.REALNAME = REALNAME;
        user.MEMO = MEMO;
        user.REG_DATE = DateTime.Now;
        user.LAST_LOG_DATE = DateTime.Now;
        user.LOG_TIMES = 0;
        user.STATE = "0";
        user.ID= (int?)o.SelectToken("id");

        if (!user.ID.HasValue)
        {
            //执行增加操作
            new WEB_USERBLL().AddNew(user);
        }
        else {
           
            new WEB_USERBLL().Update(user);
        }
       
       
    }
    /// <summary>
    /// 删除资料业务
    /// </summary>
    /// <param name="context"></param>
    public void RemoveUserInfo(HttpContext context)
    {
        String idStr = context.Request["id"];
        if (String.IsNullOrEmpty(idStr)) return;
      //  String[] ids = idStr.Split(',');
        //检验客户端字符串
        if (Common.Tools.IsValidInput(ref idStr,true))
        {
            new WEB_USERBLL().DeleteMoreID(idStr);
        }  
    }
    /// <summary>
    /// 根据id获取信息业务
    /// </summary>
    /// <param name="context"></param>
    public void GetUserInfo(HttpContext context)
    {
        string strid=context.Request["id"];
        int id=0;
        if (!string.IsNullOrEmpty(strid) && int.TryParse(strid, out id))
        {
           WEB_USER user=new WEB_USERBLL().Get(id);
           string json =WEB_USERBLL.EditUserInfoToJson(user);
            context.Response.Write(json);
        }
    }
  
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}