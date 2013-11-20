<%@ WebHandler Language="C#" Class="MasterInfo" %>
using System;
using System.Web;
using czcraft.BLL;
using czcraft.Model;
using Common;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
public class MasterInfo : IHttpHandler {

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
            case "UpdateMasterRank":
                UpdateMasterRank(context);
                break;
            case "SearchMaster":
                SearchMaster(context);
                break;
            case "SaveMaster":
                SaveMaster(context);
                break;
            case "RemoveMaster":
                RemoveMaster(context);
                break;
            case "GetMaster":
                GetMaster(context);
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
        string username = context.Request["Username"];
        if (Tools.IsValidInput(ref username, true))
        {

            context.Response.Write(new masterBLL().CheckExistUserName(username));
        }
    }
    /// <summary>
    /// 更新大师排名信息
    /// </summary>
    /// <param name="context"></param>
    public void UpdateMasterRank(HttpContext context)
    {
        master Info = new master();
        String MasterStr = context.Request["Masterdata"];
        JObject o = JObject.Parse(MasterStr);
        string id = (string)o.SelectToken("id");
      
        if(!Tools.IsValidInput(ref id,true))
            return ;
        Info.Id = Convert.ToInt32(id);
        Info.rank = (long?)o.SelectToken("rank");
       context.Response.Write(new masterBLL().UpdateMasterRank(Info));
    }
   
    /// <summary>
    /// 搜索调用
    /// </summary>
    /// <param name="context"></param>
    public void SearchMaster(HttpContext context)
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
            strCondition = masterBLL.ConfirmCondition(key);//判断查询条件
        masterBLL bll = new masterBLL();
        //分页数据读取
        IEnumerable<master> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = masterBLL.MiniUiListToJson(list, totalPage, "");


        context.Response.Write(json);
    }
    /// <summary>
    /// 保存资料业务
    /// </summary>
    /// <param name="context"></param>
    public void SaveMaster(HttpContext context)
    {
        //用户json数据读取
        master Info=new master ();
        String MasterStr = context.Request["Master"];
        string id=context.Request["id"];
        string pic = context.Request["pic"];
        if (!Tools.IsValidInput(ref pic, true) || !Tools.IsValidInput(ref id, true))
        {
            return;
        }
      //图片保存
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(context.Server.MapPath("tzt.txt"), true);
        //sw.Write(MasterStr);
        //sw.Close();
        //使用Newtonsoft.Json.dll组件解析json对象
     
        JObject o = JObject.Parse(MasterStr);
        Info.Username = (string)o.SelectToken("Username");
       
        Info.Password = (string)o.SelectToken("Password");
        Info.Name = (string)o.SelectToken("Name");
        Info.Sex = (string)o.SelectToken("Sex");
        Info.Nation = (string)o.SelectToken("Nation");
        Info.Isrecommend = ((string)o.SelectToken("Isrecommend"))=="true" ? "1" : "0";
        Info.Isshow = ((string)o.SelectToken("Isshow")) == "true" ? "1" : "0";
        Info.state = ((string)o.SelectToken("state")) == "true" ? "1" : "0";
        Info.state1 = ((string)o.SelectToken("state1")) == "true" ? "1" : "0";
        string time =(string) o.SelectToken("Birthday");
        if (time != null)
        {

            string[] BirStr = time.Split('T');
            Info.BirthDay = DateTime.Parse(BirStr[0]);
        }
        else
        {
            Info.BirthDay = null;
        }

        Info.Zipcode = (string)o.SelectToken("Zipcode");
        Info.QQ = (string)o.SelectToken("qq");
        Info.Telephone = (string)o.SelectToken("Telephone");
        Info.mobilephone = (string)o.SelectToken("mobilephone");
        Info.Email = (string)o.SelectToken("Email");
        Info.Address = (string)o.SelectToken("Address");
        Info.website = (string)o.SelectToken("website");
        Info.appreciation = (string)o.SelectToken("appreciation");
        Info.Reward = (string)o.SelectToken("Reward");
        Info.Introduction = (string)o.SelectToken("Introduction");
        Info.Picturepath = pic;

        if (!string.IsNullOrEmpty(id))
            Info.Id = Convert.ToInt32(id);

        if (!Info.Id.HasValue)
        {
            Info.rank = 0 ;
            Info.hit = 0;
            if (!new masterBLL().CheckExistUserName(Info.Username))
            {
                context.Response.Write(false);
                return;
            }
            //执行增加操作
            new masterBLL().AddNew(Info);
            SMTP smtp = new SMTP(Info.Email);
            string webpath = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/Default.aspx");
            smtp.Activation(webpath, Info.Name);//发送激活邮件
        }
        else
        {
            new masterBLL().Update(Info);
        }


    }
    /// <summary>
    /// 删除资料业务
    /// </summary>
    /// <param name="context"></param>
    public void RemoveMaster(HttpContext context)
    {
        String idStr = context.Request["id"];
        if (String.IsNullOrEmpty(idStr)) return;
        //  String[] ids = idStr.Split(',');
        //检验客户端字符串
        if (Common.Tools.IsValidInput(ref idStr, true))
        {
            new masterBLL().DeleteMoreID(idStr);
        }
    }
    /// <summary>
    /// 根据id获取信息业务
    /// </summary>
    /// <param name="context"></param>
    public void GetMaster(HttpContext context)
    {
        string strid = context.Request["id"];
        int id = 0;
        if (!string.IsNullOrEmpty(strid) && int.TryParse(strid, out id))
        {
            master Info = new masterBLL().Get(id);
            string json = masterBLL.MiniUiForSingeDataToJson(Info);
            context.Response.Write(json);
        }
    }

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}