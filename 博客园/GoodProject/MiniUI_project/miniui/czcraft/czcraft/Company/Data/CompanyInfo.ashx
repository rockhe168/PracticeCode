<%@ WebHandler Language="C#" Class="CompanyInfo" %>
using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
using Common;
using System.Collections.Generic;
using System.Web.SessionState;
using CacheStorage;
public class CompanyInfo : IHttpHandler,IRequiresSessionState
{
    //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
            case "GetCompanyReward":
                GetCompanyReward(context);
                break;
            case "GetCompanyIntro":
                GetCompanyIntro(context);
                break;
            case "GetTopCompanyForMain":
                GetTopCompanyForMain(context);
                break;
            case "GetCompanyPic":
                GetCompanyPic(context);
                break;
            case "SearchCompany":
                SearchCompany(context);
                break;
            case "GetCompanyWork":
                GetCompanyWork(context);
                break;
            case "CheckExistUserName":
                CheckExistUserName(context);
                break;
            case "SaveCompanyInfo":
                SaveCompanyInfo(context);
                break;
            default:
                return;


        }
    }
    /// <summary>
    /// 保存企业信息
    /// </summary>
    /// <param name="context"></param>
    public void SaveCompanyInfo(HttpContext context)
    {
        companyBLL bll = new companyBLL();
        try
        {
            //表单读取
            string UserName = context.Request["UserName"];
            string Pwd = context.Request["Pwd"];
            string Representative = context.Request["Representative"];
            string Name = context.Request["Name"];
            string MobilePhone = context.Request["MobilePhone"];
            string TelePhone = context.Request["TelePhone"];
            string QQ = context.Request["QQ"];
            string Introduce = context.Request["Introduce"];
            string Email = context.Request["Email"];
            string CheckCode = context.Request["CheckCode"];
            string PicturePath = context.Request["Picturepath"];

            //验证码校验
            if (Tools.IsNullOrEmpty(context.Session["checkcode"]) || !CheckCode.Equals(context.Session["checkcode"].ToString()))
            {
                context.Response.Write(Tools.WriteJsonForReturn(false, "验证码错误!"));
            }
            //字符串sql注入检测
            if (Tools.IsValidInput(ref UserName, true) && Tools.IsValidInput(ref Pwd, true) && Tools.IsValidInput(ref Email, true))
            {
                //元素赋值
                company info = new company();
                info.Username = UserName;
                info.Email = Email;
                info.Name = Name;
                info.Password = Tools.GetMD5(Pwd);
                info.Representative = Representative ;
                info.Introduction = Introduce;
                info.mobilephone = MobilePhone;
                info.Picturepath = PicturePath;
                info.QQ = QQ;
                info.Award = "";
                info.Fac = "";
                info.Zipcode = "";
                info.Address = "";
                info.rank = 0;
                info.hit = 0;
                info.Isrecommend = "0";
                info.Isshow = "0";
                info.State = "0";
                info.State1 = "0";
                info.Telephone = TelePhone;
                info.Website = ""; //context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/Master/MasterInfo.aspx?MasterId="+info.Id);
                //加随机验证码
                info.VCode = Guid.NewGuid().ToString("N");
                //验证失效(1小时以内激活有效)
                info.VTime = DateTime.Now.AddHours(1);

                //验证用户名
                if (!bll.CheckExistUserName(info.Username))
                {
                    context.Response.Write(Tools.WriteJsonForReturn(false, "用户名重复"));
                    return;
                }
                if (bll.AddNew(info) > 0)
                {
                    SMTP smtp = new SMTP(info.Email);
                    //激活网址生成
                    string webpath = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/CompanyZone/EmailChecking.aspx") + "?UserName=" + context.Server.UrlEncode(info.Username) + "&YZM=" + info.VCode;
                    //发送激活邮件
                    if (smtp.Activation(webpath, info.Username))
                    {

                        context.Response.Write(Tools.WriteJsonForReturn(true, Tools.GetEmail(info.Email)));

                    }
                    else
                    {
                        context.Response.Write(Tools.WriteJsonForReturn(false, "发送激活邮件失败!"));
                    }
                }
                else
                {
                    context.Response.Write(Tools.WriteJsonForReturn(false, "注册失败!"));
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error("错误!", ex);
            context.Response.Write(Tools.WriteJsonForReturn(false, "系统出错!"));
        }
    }
    /// <summary>
    /// 验证企业用户名是否存在
    /// </summary>
    /// <param name="context"></param>
    public void CheckExistUserName(HttpContext context)
    {
        string username = context.Request["username"];
        if (Tools.IsValidInput(ref username, true))
        {
            context.Response.Write(new companyBLL().CheckExistUserName(username));
        }
    }
    /// <summary>
    /// 企业展示
    /// </summary>
    /// <param name="context"></param>
    public void GetTopCompanyForMain(HttpContext context)
    {
        //创建缓存工厂
      ICacheStorage Cache=CacheFactory.CreateCacheFactory();
      string cache = Convert.ToString(Cache.Get("TopCompany"));
        string JsonData = "";//返回的json数据
        if (string.IsNullOrEmpty(cache))//如果缓存为空
        {
           
            //读取排名前三的新闻并转化为json格式

            JsonData = companyBLL.GetCompanyForMainByJson(3);
            //插入缓存(时间从配置文件中读取)
            Cache.Insert("TopCompany", JsonData, CacheManage.GetTimeConfig("DefaultContent"));
        }
        else
        {
            JsonData = cache;
        }


        context.Response.Write(JsonData);

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
    /// 获取企业作品信息
    /// </summary>
    /// <param name="context"></param>
    public void GetCompanyWork(HttpContext context)
    {
        //获取企业id
        string CompanyId = context.Request["CompanyId"];
        if (Tools.IsValidInput(ref CompanyId, true))
        {
            context.Response.Write(new VProductCraftTypeBLL().GetCompanyWorkForJson(CompanyId));
        }
    }
    /// <summary>
    /// 获取企业获奖信息
    /// </summary>
    /// <param name="context"></param>
    public void GetCompanyReward(HttpContext context)
    {
        //获取企业id
        string CompanyId = context.Request["CompanyId"];
        if (Tools.IsValidInput(ref CompanyId, true))
        {
            context.Response.Write(new companyBLL().GetCompanyRewardForJson(CompanyId));
        }
    }
    /// <summary>
    /// 获取企业简介信息
    /// </summary>
    /// <param name="context"></param>
    public void GetCompanyIntro(HttpContext context)
    {
        //获取企业id
        string CompanyId = context.Request["CompanyId"];
        if (Tools.IsValidInput(ref CompanyId, true))
        {
            context.Response.Write(new companyBLL().GetCompanyIntroForJson(CompanyId));
        }
    }
    /// <summary>
    /// 获取企业基本信息
    /// </summary>
    /// <param name="context"></param>
    public void GetCompanyPic(HttpContext context)
    {
        //获取企业id
        string CompanyId = context.Request["CompanyId"];
        if (Tools.IsValidInput(ref CompanyId, true))
        {
            context.Response.Write(new companyBLL().GetCompanyPicForJson(CompanyId));
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
            