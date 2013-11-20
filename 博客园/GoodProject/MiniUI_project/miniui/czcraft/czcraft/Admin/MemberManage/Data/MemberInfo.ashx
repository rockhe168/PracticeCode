<%@ WebHandler Language="C#" Class="MemberInfo" %>

using System;
using System.Web;
using czcraft.BLL;
using czcraft.Model;
using Common;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
public class MemberInfo : IHttpHandler {

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
            case "CheckExistUserName":
                CheckExistUserName(context);
                break;
            case "SearchMember":
                SearchMember(context);
                break;
            case "SaveMember":
                SaveMember(context);
                break;
            case "RemoveMember":
                RemoveMember(context);
                break;
            case "GetMember":
                GetMember(context);
                break;
            default:
                return;


        }
    }
    /// <summary>
    /// 验证帐号是否存在
    /// </summary>
    /// <param name="context"></param>
    public void CheckExistUserName(HttpContext context)
    {
        string username = context.Request["username"];
        if (Tools.IsValidInput(ref username, true))
        {
           
            context.Response.Write(new memberBLL().CheckExistUserName(username));
        }
    }
    /// <summary>
    /// 搜索调用
    /// </summary>
    /// <param name="context"></param>
    public void SearchMember(HttpContext context)
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
            strCondition = memberBLL.ConfirmCondition(key);//判断查询条件
        memberBLL bll = new memberBLL();
        //分页数据读取
        IEnumerable<member> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = memberBLL.MiniUiListToJson(list, totalPage, "");


        context.Response.Write(json);
    }
    /// <summary>
    /// 保存资料业务
    /// </summary>
    /// <param name="context"></param>
    public void SaveMember(HttpContext context)
    {
      
        //用户json数据读取
        //{"username":"12421","password":"12521","Sex":"1","nation":"1","mobilephone":"12521","Telephone":"12521","qq":"12521","Zipcode":"12521","Email":"12521","Address":"12521"}
        member Info=new member ();
        String MemberStr = context.Request["Member"];
      
        string id=context.Request["id"];
        //使用Newtonsoft.Json.dll组件解析json对象
        //首先过滤掉json中的[和]
        JObject o = JObject.Parse(MemberStr);
        Info.username = (string)o.SelectToken("username");
        if (!new memberBLL().CheckExistUserName(Info.username))
        {
            context.Response.Write(false);
            return;
        }
        Info.password = (string)o.SelectToken("password");
        Info.Sex = (string)o.SelectToken("Sex");
        Info.nation = (string)o.SelectToken("nation");
        Info.mobilephone = (string)o.SelectToken("mobilephone");
        Info.Telephone = (string)o.SelectToken("Telephone");
        Info.qq = (string)o.SelectToken("qq");
        Info.Zipcode = (string)o.SelectToken("Zipcode");
        Info.Email = (string)o.SelectToken("Email");
        Info.Address = (string)o.SelectToken("Address");
        if (!string.IsNullOrEmpty(id))
            Info.Id = Convert.ToInt32(id); 
        Info.states = "0";
        if (!Info.Id.HasValue)
        {
            //执行增加操作
            new memberBLL().AddNew(Info);
            SMTP smtp = new SMTP(Info.Email);
            string webpath = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/Default.aspx");
            smtp.Activation(webpath, Info.username);//发送激活邮件
        }
        else
        {

            new memberBLL().Update(Info);
        }


    }
    /// <summary>
    /// 删除资料业务
    /// </summary>
    /// <param name="context"></param>
    public void RemoveMember(HttpContext context)
    {
        String idStr = context.Request["id"];
        if (String.IsNullOrEmpty(idStr)) return;
        //  String[] ids = idStr.Split(',');
        //检验客户端字符串
        if (Common.Tools.IsValidInput(ref idStr, true))
        {
            //new memberBLL().Delete(Convert.ToInt32(idStr));
            new memberBLL().DeleteMoreID(idStr);
        }
    }
    /// <summary>
    /// 根据id获取信息业务
    /// </summary>
    /// <param name="context"></param>
    public void GetMember(HttpContext context)
    {
        string strid = context.Request["id"];
        int id = 0;
        if (!string.IsNullOrEmpty(strid) && int.TryParse(strid, out id))
        {
            member Info = new memberBLL().Get(id);
            string json = memberBLL.MiniUiForSingeDataToJson(Info);
            context.Response.Write(json);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}