<%@ WebHandler Language="C#" Class="MasterInfo" %>

using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
using Common;
using System.Collections.Generic;
using System.Web.SessionState;
using CacheStorage;
public class MasterInfo : IHttpHandler,IRequiresSessionState {

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
            case "GetMasterReward":
                GetMasterReward(context);
                break;
            case "GetMasterIntro":
                GetMasterIntro(context);
                break;
            case "GetTopMasterForMain":
                GetTopMasterForMain(context);
                break;
            case "GetMasterInfo":
                GetMasterInfo(context);
                break;
            case "SearchMaster":
                SearchMaster(context);
                break;
            case "GetMasterWork":
                GetMasterWork(context);
                break;
            case "CheckExistUserName":
                CheckExistUserName(context);
                break;
            case "SaveMasterInfo":
                SaveMasterInfo(context);
                break;
            default:
                return;


        }
    }
   
    /// <summary>
    /// 验证用户名
    /// </summary>
    /// <param name="context"></param>
    public void CheckExistUserName(HttpContext context)
    {
        string username = context.Request["username"];
        if (Tools.IsValidInput(ref username, true))
        {
            context.Response.Write(new masterBLL().CheckExistUserName(username));
        }
    }
    /// <summary>
    /// 保存大师信息
    /// </summary>
    /// <param name="context"></param>
    public void SaveMasterInfo(HttpContext context)
    {
        masterBLL bll = new masterBLL();
        try
        {
            //表单读取
            string UserName = context.Request["UserName"];
            string Pwd = context.Request["Pwd"];
            string Birthday = context.Request["Birthday"];
            string Name = context.Request["Name"];
            string Sex = context.Request["Sex"];
            string MobilePhone = context.Request["MobilePhone"];
            string TelePhone = context.Request["TelePhone"];
            string QQ = context.Request["QQ"];
            string Introduce = context.Request["Introduce"];
            string Email = context.Request["Email"];
            string CheckCode = context.Request["CheckCode"];
            string PicturePath = context.Request["Picturepath"];
            
            //验证码校验
            if (Tools.IsNullOrEmpty(context.Session["checkcode"])||!CheckCode.Equals(context.Session["checkcode"].ToString()))
            {
                context.Response.Write(Tools.WriteJsonForReturn(false, "验证码错误!"));
            }
            //字符串sql注入检测
            if (Tools.IsValidInput(ref UserName, true) && Tools.IsValidInput(ref Pwd, true) && Tools.IsValidInput(ref Email, true))
            {
                //元素赋值
                master info = new master();
                info.Username = UserName;
                info.Email = Email;
                info.Name = Name;
                info.Password = Tools.GetMD5(Pwd);
                info.BirthDay =Convert.ToDateTime(Birthday);
                info.Introduction = Introduce;
                info.mobilephone = MobilePhone;
                info.Picturepath = PicturePath;
                info.QQ = QQ;
                info.Nation = "";
                info.Reward = "";
                info.appreciation = "";
                info.Zipcode = "";
                info.Address = "";
                info.Sex = Sex;
                info.rank = 0;
                info.hit = 0;
                info.Isrecommend = "0";
                info.Isshow = "0";
                info.state = "0";
                info.state1 = "0";
                info.Telephone = TelePhone;
                info.website = ""; //context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/Master/MasterInfo.aspx?MasterId="+info.Id);
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
                    string webpath = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/MasterZone/EmailChecking.aspx") + "?UserName=" + context.Server.UrlEncode(info.Username) + "&YZM=" + info.VCode;
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
    /// 大师展示
    /// </summary>
    /// <param name="context"></param>
    public void GetTopMasterForMain(HttpContext context)
    {
        //创建缓存工厂
        ICacheStorage Cache = CacheFactory.CreateCacheFactory();
        string cache = Convert.ToString(Cache.Get("TopMaster"));
        string JsonData = "";//返回的json数据
        if (string.IsNullOrEmpty(cache))//如果缓存为空
        {
            //读取排名前三的新闻并转化为json格式

            JsonData = masterBLL.GetMasterForMainByJson(3);
            //插入缓存(时间从配置文件中读取)
            Cache.Insert("TopMaster", JsonData, CacheManage.GetTimeConfig("DefaultContent"));
          
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
    /// 获取大师作品信息
    /// </summary>
    /// <param name="context"></param>
    public void GetMasterWork(HttpContext context)
    { 
      //获取大师id
        string MasterId = context.Request["MasterId"];
        if (Tools.IsValidInput(ref MasterId, true))
        {
            context.Response.Write(new VProductCraftTypeBLL().GetMasterWorkForJson(MasterId));
        }
    }
    /// <summary>
    /// 获取大师获奖信息
    /// </summary>
    /// <param name="context"></param>
    public void GetMasterReward(HttpContext context)
    {
        //获取大师id
        string MasterId = context.Request["MasterId"];
        if (Tools.IsValidInput(ref MasterId, true))
        {
            context.Response.Write(new masterBLL().GetMasterRewardForJson(MasterId));
        }
    }
    /// <summary>
    /// 获取大师简介信息
    /// </summary>
    /// <param name="context"></param>
    public void GetMasterIntro(HttpContext context)
    {
        //获取大师id
        string MasterId = context.Request["MasterId"];
        if (Tools.IsValidInput(ref MasterId, true))
        {
            context.Response.Write(new masterBLL().GetMasterIntroForJson(MasterId));
        }
    }
    /// <summary>
    /// 获取大师基本信息
    /// </summary>
    /// <param name="context"></param>
    public void GetMasterInfo(HttpContext context)
    { 
        //获取大师id
        string MasterId=context.Request["MasterId"];
        if (Tools.IsValidInput(ref MasterId, true))
        {
           context.Response.Write(new masterBLL().GetMasterInfoForJson(MasterId));
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}