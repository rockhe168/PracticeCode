<%@ WebHandler Language="C#" Class="CompanyInfo" %>
using System;
using System.Web;
using czcraft.BLL;
using czcraft.Model;
using Common;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
public class CompanyInfo : IHttpHandler {

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
            case "UpdateCompanyRank":
                UpdateCompanyRank(context);
                break;
            case "SearchCompany":
                SearchCompany(context);
                break;
            case "SaveCompany":
                SaveCompany(context);
                break;
            case "RemoveCompany":
                RemoveCompany(context);
                break;
            case "GetCompany":
                GetCompany(context);
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

            context.Response.Write(new companyBLL().CheckExistUserName(username));
        }
    }
    /// <summary>
    /// 更新企业排名信息
    /// </summary>
    /// <param name="context"></param>
    public void UpdateCompanyRank(HttpContext context)
    {
        company Info = new company();
        String CompanyStr = context.Request["Companydata"];
        JObject o = JObject.Parse(CompanyStr);
        string id = (string)o.SelectToken("id");
      
        if(!Tools.IsValidInput(ref id,true))
            return ;
        Info.Id = Convert.ToInt32(id);
        Info.rank = (long?)o.SelectToken("rank");
       context.Response.Write(new companyBLL().UpdateCompanyRank(Info));
    }
   
    /// <summary>
    /// 搜索调用
    /// </summary>
    /// <param name="context"></param>
    public void SearchCompany(HttpContext context)
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
            strCondition = companyBLL.ConfirmCondition(key);//判断查询条件
        companyBLL bll = new companyBLL();
        //分页数据读取
        IEnumerable<company> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = companyBLL.MiniUiListToJson(list, totalPage, "");


        context.Response.Write(json);
    }
    /// <summary>
    /// 保存资料业务
    /// </summary>
    /// <param name="context"></param>
    public void SaveCompany(HttpContext context)
    {
        //用户json数据读取
        company Info=new company ();
        String CompanyStr = context.Request["Company"];
        string id=context.Request["id"];
        string pic = context.Request["pic"];
        if (!Tools.IsValidInput(ref pic, true) || !Tools.IsValidInput(ref id, true))
        {
            return;
        }
      //图片保存
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(context.Server.MapPath("tzt.txt"), true);
        //sw.Write(CompanyStr);
        //sw.Close();
        //使用Newtonsoft.Json.dll组件解析json对象
     
        JObject o = JObject.Parse(CompanyStr);
        Info.Username = (string)o.SelectToken("Username");
        if (!new companyBLL().CheckExistUserName(Info.Username))
        {
            context.Response.Write(false);
            return;
        }
        Info.Password = (string)o.SelectToken("Password");
        Info.Name = (string)o.SelectToken("Name");
        Info.Isrecommend = ((string)o.SelectToken("Isrecommend"))=="true" ? "1" : "0";
        Info.Fac = (string)o.SelectToken("Fac");
        Info.Representative = (string)o.SelectToken("Representative");
        Info.Isshow = ((string)o.SelectToken("Isshow")) == "true" ? "1" : "0";
        Info.State = ((string)o.SelectToken("State")) == "true" ? "1" : "0";
        Info.State1 = ((string)o.SelectToken("State1")) == "true" ? "1" : "0";
       
        Info.Zipcode = (string)o.SelectToken("Zipcode");
        Info.QQ = (string)o.SelectToken("QQ");
        Info.Telephone = (string)o.SelectToken("Telephone");
        Info.mobilephone = (string)o.SelectToken("mobilephone");
        Info.Email = (string)o.SelectToken("Email");
        Info.Address = (string)o.SelectToken("Address");
        Info.Website = (string)o.SelectToken("Website");
        Info.Award = (string)o.SelectToken("Award");
        Info.Introduction = (string)o.SelectToken("Introduction");
        Info.Picturepath = pic;

        if (!string.IsNullOrEmpty(id))
            Info.Id = Convert.ToInt32(id);

        if (!Info.Id.HasValue)
        {
            Info.rank = 0;
            Info.hit = 0;
            //执行增加操作
            new companyBLL().AddNew(Info);
            SMTP smtp = new SMTP(Info.Email);
            string webpath = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/Default.aspx");
            smtp.Activation(webpath, Info.Name);//发送激活邮件
        }
        else
        {
            new companyBLL().Update(Info);
        }


    }
    /// <summary>
    /// 删除资料业务
    /// </summary>
    /// <param name="context"></param>
    public void RemoveCompany(HttpContext context)
    {
        String idStr = context.Request["id"];
        if (String.IsNullOrEmpty(idStr)) return;
        //  String[] ids = idStr.Split(',');
        //检验客户端字符串
        if (Common.Tools.IsValidInput(ref idStr, true))
        {
            new companyBLL().DeleteMoreID(idStr);
        }
    }
    /// <summary>
    /// 根据id获取信息业务
    /// </summary>
    /// <param name="context"></param>
    public void GetCompany(HttpContext context)
    {
        string strid = context.Request["id"];
        int id = 0;
        if (!string.IsNullOrEmpty(strid) && int.TryParse(strid, out id))
        {
            company Info = new companyBLL().Get(id);
            string json = companyBLL.MiniUiForSingeDataToJson(Info);
            context.Response.Write(json);
        }
    }

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}