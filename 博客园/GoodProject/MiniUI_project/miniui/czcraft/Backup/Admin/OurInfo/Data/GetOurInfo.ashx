<%@ WebHandler Language="C#" Class="GetOurInfo" %>

using System;
using System.Web;
using czcraft.BLL;
using czcraft.Model;
using Newtonsoft.Json.Linq;
using System.Web.SessionState;
using System.Collections.Generic;
public class GetOurInfo : IHttpHandler,IRequiresSessionState {

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
            case "GetOurInfoData":
                GetOurInfoData(context);
                break;
            case "SaveOurInfo":
                SaveOurInfo(context);
                break;
            case "GetOurWebInfo":
                GetOurWebInfo(context);
                break;
     
            case "SearchWebMessage":
                SearchWebMessage(context);
               
                break;
            case "LoadComment":
                LoadComment(context);
                break;
            case "SaveComment":
                SaveComment(context);
                break;
            default:
                return;
        }
    }
    /// <summary>
    /// 保存总站留言
    /// </summary>
    /// <param name="context"></param>
    public void SaveComment(HttpContext context)
    {
        object UserName=Common.SessionHelper.GetSession("Admin");
        string id = context.Request["id"];
        string huifuContent = context.Request["huifuContent"];
        //对搜索内容进行验证
        if (!Common.Tools.IsValidInput(ref id, true) && !Common.Tools.IsValidInput(ref huifuContent, true)&&Common.Tools.IsNullOrEmpty(UserName))
        {
            return;
        }
        int Id;
        if (int.TryParse(id, out Id))
        {
            WebMessageBLL bll = new WebMessageBLL();
            WebMessage info = bll.Get(Id);
            info.huifuContent = huifuContent;
            info.huifuTime = DateTime.Now;
            info.HuifuName = UserName.ToString ();
            context.Response.Write(bll.UpdateComment(info));
        }
    }
    /// <summary>
    /// 加载评论信息
    /// </summary>
    /// <param name="context"></param>
    public void LoadComment(HttpContext context)
    {
        string id = context.Request["id"];
        //对搜索内容进行验证
        if (!Common.Tools.IsValidInput(ref id, true))
        {
            return;
        }
        int Id;
        if (int.TryParse(id, out Id))
        {
            WebMessage info = new WebMessageBLL().Get(Id);
            context.Response.Write(WebMessageBLL.MiniUiForSingeDataToJson(info));
        }
    }
    /// <summary>
    /// 搜索总站留言
    /// </summary>
    /// <param name="context"></param>
    public void SearchWebMessage(HttpContext context)
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
       // else
        //    strCondition = WebMessageBLL.ConfirmCondition(key);//判断查询条件
        WebMessageBLL bll = new WebMessageBLL();
        //分页数据读取
        IEnumerable<WebMessage> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "0" : "1", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = WebMessageBLL.MiniUiListToJson(list, totalPage, "");


        context.Response.Write(json);
    }
  
    /// <summary>
    /// 获取网站的web信息
    /// </summary>
    /// <param name="context"></param>
    public void GetOurWebInfo(HttpContext context)
    {
        ourinfo info = new ourinfoBLL ().Get(1);
        context.Response.Write(ourinfoBLL.OurWebInfoToJson(info));
    }
    /// <summary>
    /// 获取关于我们的信息
    /// </summary>
    /// <param name="context"></param>
    public void GetOurInfoData(HttpContext context)
    {
       ourinfo info=new ourinfoBLL().Get(1);
       context.Response.Write(ourinfoBLL.OurInfoToJson(info));
    }
    /// <summary>
    /// 保存关于我们的信息
    /// </summary>
    /// <param name="context"></param>
    public void SaveOurInfo(HttpContext context)
    {
        ourinfo info = new ourinfo();
        string id = context.Request["id"];
        string OurInfo = context.Request["OurInfo"];
        if (!Common.Tools.IsValidInput(ref id,true)) //注入检测
            return;
        //解析json数据
        JObject o = JObject.Parse(OurInfo);
        info.Id =Convert.ToInt32(id);
        info.Name = (string)o.SelectToken("Name");
        info.Representative = (string)o.SelectToken("Representative");
        info.Introduction = (string)o.SelectToken("Introduction");
        info.mobilephone = (string)o.SelectToken("mobilephone");
        info.Telephone = (string)o.SelectToken("Telephone");
        info.qq = (string)o.SelectToken("qq");
        info.Zipcode = (string)o.SelectToken("Zipcode");
        info.Website = (string)o.SelectToken("Website");
        info.Email = (string)o.SelectToken("Email");
        info.Address = (string)o.SelectToken("Address");
        context.Response.Write(new ourinfoBLL().Update(info));
      
        
       
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}