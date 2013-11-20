  <%@ WebHandler Language="C#" Class="MasterZoneInfo" %>

using System;
using System.Web;

using czcraft.Model;
using czcraft.BLL;
using Common;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Web.SessionState;
public class MasterZoneInfo : IHttpHandler,IRequiresSessionState {

    //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public void ProcessRequest(HttpContext context)
    {
        //测试
        //SessionHelper.SetSession("MasterId", 11);
       // SessionHelper.SetSession("MasterName", "tianzh1");
        //设置产品id
        //SessionHelper.SetSession("ProductId", 12);
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
            case "SaveProduct":
                SaveProduct(context);
                break;
            case "SearchProduct":
                SearchProduct(context);
                break;
            case "GetProduct":
                GetProduct(context);
                break;
            case "GetProductType":
                GetProductType(context);
                break;
            case "SaveMaster":
                SaveMaster(context);
                break;
            case "GetMaster":
                GetMaster(context);
                break;
            case "GetMultiProductType":
                GetMultiProductType(context);
                break;
            case "SearchMasterRewardPic":
                SearchMasterRewardPic(context);
                break;
            case "GetMasterReward":
                GetMasterReward(context);
                break;
            case "SaveMasterReward":
                SaveMasterReward(context);
                break;
            case "RemoveMasterReward":
                RemoveMasterReward(context);
                break;
            case "SearchProductPic":
                SearchProductPic(context);
                break;
            case "SaveProductPic":
                SaveProductPic(context);
                break;
            case "RemoveOtherProductPic":
                RemoveOtherProductPic(context);
                break;
            case "ActivationMasterNumber":
                ActivationMasterNumber(context);
                break;
            case "UpdatePwd":
                UpdatePwd(context);
                break;
            case "CheckLoginStatus":
                CheckLoginStatus(context);
                break;
            case "ForgetPwd":
                ForgetPwd(context);
                break;
            case "MasterLogin":
                MasterLogin(context);
                break;
            case "MasterLogout":
                MasterLogout(context);
                break;
            default:
                return;


        }
    }
    /// <summary>
    /// 忘记密码
    /// </summary>
    /// <param name="context"></param>
    public void ForgetPwd(HttpContext context)
    {
        masterBLL bll = new masterBLL();
        string UserName = context.Request["UserName"];
        string CheckCode = context.Request["CheckCode"];
        string Email = context.Request["Email"];
        //验证码校验
        if (Tools.IsNullOrEmpty(context.Session["checkcode"])|| !CheckCode.Equals(context.Session["checkcode"].ToString()))
        {
            context.Response.Write(bll.WriteJsonForReturn(false, "验证码不正确!"));
            return;
        }
        //字符串sql注入检测
        if (Tools.IsValidInput(ref UserName, true) && Tools.IsValidInput(ref Email, true))
        {
            //获取用户邮箱

            //邮箱和用户名状态(正确与否)
            bool status = bll.CheckUserNameAndEmail(UserName, Email);
            //随机生成一个6位的新密码
            string NewPwd = bll.CreateNewPwd();
            if (!string.IsNullOrEmpty(Email) && status && bll.UpdatePwd(UserName, NewPwd))
            {
                SMTP smtp = new SMTP(Email);
                if (smtp.sendemail("潮州工艺品平台", "尊敬的" + UserName + "大师:恭喜您,您在" + DateTime.Now.ToString() + "使用找回密码功能重置密码,您的密码:" + NewPwd + ",请尽快修改密码并妥善保管!"))
                {
                    context.Response.Write(bll.WriteJsonForReturn(true, Tools.GetEmail(Email)));
                }
                else
                {
                    context.Response.Write(bll.WriteJsonForReturn(false, "邮箱发送失败!"));
                }
            }
            else
            {
                context.Response.Write(bll.WriteJsonForReturn(false, "用户名或邮箱不正确!"));
            }


        }
        else
        {
            context.Response.Write(bll.WriteJsonForReturn(false, "输入非法内容!"));
        }
    }
    /// <summary>
    /// 大师安全退出
    /// </summary>
    /// <param name="context"></param>
    public void MasterLogout(HttpContext context)
    {
        string MasterName = (string)context.Session["MasterName"];
        masterBLL bll = new masterBLL();
        if (!Tools.IsNullOrEmpty(MasterName))
        {
            //如果session存在,清除session
            context.Session.Remove("MasterName");
            context.Session.Remove("MasterId");
        }
        //清除cookies
        CookieHelper.ClearCookie("MasterName");
        CookieHelper.ClearCookie("MasterPwd");
        //页面跳转
        JScript.AlertAndRedirect("安全退出成功!欢迎下次前来访问!", "../../Default.aspx");
    }
    /// <summary>
    /// 大师登录
    /// </summary>
    /// <param name="context"></param>
    public void MasterLogin(HttpContext context)
    {
        try
        {
            //获取数据
            string Name = context.Request["Name"];
            string Pwd = context.Request["Pwd"];
            string IsSaveName = context.Request["cbName"];
            string IsSavePwd = context.Request["cbPwd"];
            //用户登录状态
            bool Status = false;
            //返回给客户端的json数据
            string ReturnJson = "";
            //sql注入检测
            if (Tools.IsValidInput(ref Name, true) && (Tools.IsValidInput(ref Pwd, true)) && (Tools.IsValidInput(ref IsSaveName, true)) && (Tools.IsValidInput(ref IsSavePwd, true)))
            {
                master info = new master();
                masterBLL bll = new masterBLL();
                info.Username = Name;
                info.Password = Pwd;
                ReturnJson = bll.ReturnJson(info, out Status);
                if (Status) //如果成功登陆
                {
                    //记住帐号和密码
                    bll.RememberUserInfo(info, bll.GetRememberType(IsSaveName, IsSavePwd));

                    //保存登录状态
                    context.Session["MasterName"] = info.Username;
                    //如果登录成功,则把用户ID放在Session中
                    if (Tools.IsNullOrEmpty(context.Session["MasterId"]))
                    {
                        context.Session["MasterId"] = bll.GetMasterId(info.Username);
                    }
                }
                context.Response.Write(ReturnJson);
            }
        }
        catch (Exception ex)
        {
            logger.Error("大师登录出错!", ex);
        }

    }
    /// <summary>
    /// 检查用户登录状态
    /// </summary>
    /// <param name="context"></param>
    public void CheckLoginStatus(HttpContext context)
    {
        string MasterName = (string)context.Session["MasterName"];
        masterBLL bll = new masterBLL();
        bool Status = false;
        if (!Tools.IsNullOrEmpty(MasterName))
        {
            //如果session存在,直接返回用户状态
            context.Response.Write(bll.WriteJsonForReturn(true, MasterName));
        }
        else
        {
            //用户自动登录状态检测

            context.Response.Write(bll.CheckLoginStatus(out Status));
            //登录成功!
            if (Status)
            {
                context.Session["MasterName"] = Common.CookieHelper.GetCookieValue("MasterName");
            }


        }
        //如果登录成功,则把用户ID放在Session中
        if (Status == true && Tools.IsNullOrEmpty(context.Session["MasterId"]))
        {
            context.Session["MasterId"] = bll.GetMasterId(MasterName);
        }
    }
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="context"></param>
    public void UpdatePwd(HttpContext context)
    {
        string SessionMasterName = (string)context.Session["MasterName"];
        string OldPWd = context.Request["txtOldPwd"];
        string NewPwd = context.Request["txtNewPwd"];
        masterBLL bll = new masterBLL();
        if (string.IsNullOrEmpty(SessionMasterName))
        {
            context.Response.Write(Tools.WriteJsonForReturn(false, "未登录"));
        }
        else
        {

            context.Response.Write(Tools.WriteJsonForReturn(bll.UpdatePassword(SessionMasterName, OldPWd, NewPwd), SessionMasterName));
        }
    }
    /// <summary>
    /// 激活帐号
    /// </summary>
    /// <param name="context"></param>
    public void ActivationMasterNumber(HttpContext context)
    {
        //注意要对url解码
        string UserName = context.Server.UrlDecode(context.Request["UserName"]);

        string VCode = context.Request["VCode"];
        masterBLL bll = new masterBLL();
        //激活
        if (Tools.IsValidInput(ref UserName, true) && Tools.IsValidInput(ref VCode, true))
        {
            context.Response.Write(Tools.WriteJsonForReturn(bll.ActivationMasterNumber(UserName, VCode), "")); ;
        }
        else
        {
            context.Response.Write(Tools.WriteJsonForReturn(false, ""));
        }
       
    }
    /// <summary>
    /// 删除大师荣誉证书
    /// </summary>
    /// <param name="context"></param>
    public void RemoveMasterReward(HttpContext context)
    {
        String idStr = context.Request["id"];
        //检验客户端字符串
        if (Common.Tools.IsValidInput(ref idStr, true))
        {
            new master_certBLL().DeleteMoreID(idStr);
        }
    }
    /// <summary>
    /// 保存大师荣誉证书
    /// </summary>
    /// <param name="context"></param>
    public void SaveMasterReward(HttpContext context)
    {
        string MasterId = SessionHelper.GetSession("MasterId").ToString();
        //用户json数据读取
       // String Reward = context.Request["Reward"];
        if (Tools.IsNullOrEmpty(MasterId))
            return;

        ////使用Newtonsoft.Json.dll组件解析json对象
        ////首先过滤掉json中的[和]
     
        string ImgPath = context.Request["ImgPath"];
        string Name = context.Request["Name"];
        master_cert Info = new master_cert();
        string Id = context.Request["Id"];
        if (!Tools.IsNullOrEmpty(Id))
            Info.id = Convert.ToInt64(Id);

        //保存用户数据的model对象
        Info.Masterid =Convert.ToInt32(MasterId);
        Info.Name = Name;
        
        Info.Picpath = ImgPath;

        if (Info.id.HasValue)
            new master_certBLL().Update(Info);
        else
            new master_certBLL().AddNew(Info);

    }
    /// <summary>
    /// 获取大师荣誉证书
    /// </summary>
    /// <param name="context"></param>
    public void GetMasterReward(HttpContext context)
    {
        string strid = context.Request["id"];
        long id = 0;
        if (!string.IsNullOrEmpty(strid) && long.TryParse(strid, out id))
        {
            //获取用户组信息
            master_cert group = new master_certBLL().Get(id);

            context.Response.Write(Common.FormatToJson.ScriptSerializationToJson(group));
        }
    }
    /// <summary>
    /// 查询大师荣誉证书信息
    /// </summary>
    /// <param name="context"></param>
    public void SearchMasterRewardPic(HttpContext context)
    {
        string MasterId = SessionHelper.GetSession("MasterId").ToString();
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
        string strCondition = "";
        if (Tools.IsValidInput(ref MasterId,true))
        {
            strCondition = " Masterid=" + MasterId;
        }
        master_certBLL bll = new master_certBLL();
       
        //分页数据读取
        IEnumerable<master_cert> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = Common.FormatToJson.MiniUiListToJson<master_cert>((IList<master_cert>)list, totalPage, "");
        context.Response.Write(json);
    }
    /// <summary>
    /// 获得类别(为大师多选服务)
    /// </summary>
    /// <param name="context"></param>
    public void GetMultiProductType(HttpContext context)
    {
        crafttypeBLL bll = new crafttypeBLL();
       context.Response.Write(bll.MultiProductTypeForJson());
    }
    /// <summary>
    /// 搜索产品图片信息
    /// </summary>
    /// <param name="context"></param>
    public void SearchProductPic(HttpContext context)
    {
        //string MasterId = SessionHelper.GetSession("MasterId").ToString();
        string key = context.Request["key"];
       
        
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
        string strCondition = "";
        if (Tools.IsNullOrEmpty(sortField))
            sortField = "Id";
        if (Tools.IsValidInput(ref key, true))
        {
            strCondition = " Productid=" + key;
        }
        VProductPicBLL bll = new VProductPicBLL();

        //分页数据读取
        IEnumerable<VProductPic> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = Common.FormatToJson.MiniUiListToJson<VProductPic>((IList<VProductPic>)list, totalPage, "");
        context.Response.Write(json);
    }
    /// <summary>
    /// 保存产品图片
    /// </summary>
    /// <param name="context"></param>
    public void SaveProductPic(HttpContext context)
    {
        string Id = context.Request["Id"];
        string PicList = context.Request["PicList"];
        if (!Tools.IsNullOrEmpty(Id))
        {
            product_picturepathBLL bll = new product_picturepathBLL();
            context.Response.Write(bll.AddMutiPic(Id, PicList));
        }
        else {
            context.Response.Write("请登录!");
        }
    }
    /// <summary>
    /// 删除产品其他图片
    /// </summary>
    /// <param name="context"></param>
    public void RemoveOtherProductPic(HttpContext context)
    {
        string Id = context.Request["Id"];
        if (!Tools.IsNullOrEmpty(Id))
        {
            product_picturepathBLL bll = new product_picturepathBLL();
           int PicId= Convert.ToInt32(Id);
           context.Response.Write(bll.Delete(PicId));
        }
        else
        {
            context.Response.Write("请登录!");
        }
    }
    /// <summary>
    /// 根据id获取信息业务
    /// </summary>
    /// <param name="context"></param>
    public void GetMaster(HttpContext context)
    {
       
        string MasterId = SessionHelper.GetSession("MasterId").ToString();
      
        int id = 0;
        if (!string.IsNullOrEmpty(MasterId) && int.TryParse(MasterId, out id))
        {
           
            string json = masterBLL.MasterEditForJson(id);
            context.Response.Write(json);
        }
    }
    /// <summary>
    /// 保存大师信息
    /// </summary>
    /// <param name="context"></param>
    public void SaveMaster(HttpContext context)
    {
      
            string MasterId = SessionHelper.GetSession("MasterId").ToString();
            //用户json数据读取
            master Info = new master();
            string CraftType = context.Request["ProductType"];
            String MasterStr = context.Request["Master"];
          
            string pic = context.Request["pic"];
            if (!Tools.IsValidInput(ref pic, true)&&!Tools.IsValidInput(ref CraftType,true))
            {
                return;
            }
            //图片保存
            //使用Newtonsoft.Json.dll组件解析json对象

            JObject o = JObject.Parse(MasterStr);
            Info.Id = Convert.ToInt32(MasterId);
            Info.Name = (string)o.SelectToken("Name");
            Info.Sex = (string)o.SelectToken("Sex");
            Info.Nation = (string)o.SelectToken("Nation");

            string time = (string)o.SelectToken("Birthday");
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
            Info.appreciation = (string)o.SelectToken("appreciation");
            Info.Reward = (string)o.SelectToken("Reward");
            Info.Introduction = (string)o.SelectToken("Introduction");
            Info.Picturepath = pic;
            new masterBLL().UpdateMasterForZone(Info, CraftType);
        
     

    }
    /// <summary>
    /// 获取产品信息
    /// </summary>
    /// <param name="context"></param>
    public void GetProduct(HttpContext context)
    {
        string strid = context.Request["id"];
        int id = 0;
        if (!string.IsNullOrEmpty(strid) && int.TryParse(strid, out id))
        {
            product Info = new productBLL().Get(id);
            string json = productBLL.MiniUiForSingeAddProductToJson(Info);
            context.Response.Write(json);
        }
    }
    /// <summary>
    /// 保存产品信息(这个是大师添加产品)
    /// </summary>
    /// <param name="context"></param>
    public void SaveProduct(HttpContext context)
    {
        //大师id
        string MasterId = SessionHelper.GetSession("MasterId").ToString ();
        if (Tools.IsNullOrEmpty(MasterId))
        {
            //context.Response.Write("未登录!");
            return;
        }
        //用户json数据读取
        product Info = new product();
        String ProductStr = context.Request["Product"];

        string id = context.Request["id"];
        string pic = context.Request["pic"];
        if (!Tools.IsValidInput(ref pic, false) || !Tools.IsValidInput(ref id, false))
        {
            return;
        }
        //图片保存
        //使用Newtonsoft.Json.dll组件解析json对象


        JObject o = JObject.Parse(ProductStr);
        Info.Name = (string)o.SelectToken("Name");
        Info.Simplename = (string)o.SelectToken("Simplename");
        Info.Material = (string)o.SelectToken("Material");
        Info.Weight = (string)o.SelectToken("Weight");
        Info.Volume = (string)o.SelectToken("Volume");
        Info.Specification = (string)o.SelectToken("Specification");
        Info.Model = (string)o.SelectToken("Model");
        Info.Volume = (string)o.SelectToken("Volume");
        Info.Explain = (string)o.SelectToken("Explain");
        //默认不是推荐作品
        Info.Isrecomment = "0";// ((string)o.SelectToken("Isrecomment")) == "true" ? "1" : "0";
        //默认不首页显示
        Info.Isshow = "0";// ((string)o.SelectToken("Isshow")) == "true" ? "1" : "0";
        Info.Issell = ((string)o.SelectToken("Issell")) == "true" ? "1" : "0";
        //默认不是佳作
        Info.Isexcellent = "0";// ((string)o.SelectToken("Isexcellent")) == "true" ? "1" : "0";
        Info.Nongenetic = ((string)o.SelectToken("Nongenetic")) == "true" ? "1" : "0";
        string TypeID = (string)o.SelectToken("Typeid");
        Info.Typeid = Convert.ToInt32(TypeID);
        Info.Belongstype =0;//这个是大师空间 添加,所以所属为-1,为0代表大师产品,为1代表企业产品
       
        Info.Masterid =Convert.ToInt32(MasterId);
        Info.Flashpath = "#";
        Info.Num = (long?)o.SelectToken("Num");
        Info.Soldnum = (long?)o.SelectToken("Soldnum");
        Info.Lsprice = Convert.ToDouble((string)o.SelectToken("Lsprice"));
        Info.Pfprice = Convert.ToDouble((string)o.SelectToken("Pfprice"));
        Info.Vipprice = Convert.ToDouble((string)o.SelectToken("Vipprice"));
        Info.MarketPrice = Convert.ToDouble((string)o.SelectToken("MarketPrice"));
        Info.Price1 = Convert.ToDouble((string)o.SelectToken("Price1"));
        Info.Price2 = Convert.ToDouble((string)o.SelectToken("Price2"));
        Info.Price3 = Convert.ToDouble((string)o.SelectToken("Price3"));
        Info.Price4 = Convert.ToDouble((string)o.SelectToken("Price4"));

        Info.Picturepath = pic;

        if (Tools.IsNumber(id))
            Info.Id = Convert.ToInt32(id);

        if (!Info.Id.HasValue)
        {
            Info.rank = 0;
            Info.hit = 0;
            //执行增加操作
            new productBLL().AddNew(Info);
        }
        else
        {
            new productBLL().Update(Info);
        }



    }
 
    /// <summary>
    /// 查找产品信息
    /// </summary>
    /// <param name="context"></param>
    public void SearchProduct(HttpContext context)
    {
        string strCondition = "";
        string MasterId = SessionHelper.GetSession("MasterId").ToString();
        if (Tools.IsNullOrEmpty(MasterId))
        {
            return;
        }
        else
        strCondition = " Masterid=" + MasterId;
        //查询条件
        string key = context.Request["key"];
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
        
        //对搜索内容进行验证
        if (!Common.Tools.IsValidInput(ref key, false))
        {
            return;
        }
        else{
            strCondition += " and "+ VFindProductInfoBLL.ConfirmCondition(key);//判断查询条件
         
        }
        VFindProductInfoBLL bll = new VFindProductInfoBLL();
        //分页数据读取
        IEnumerable<VFindProductInfo> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);
        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = VFindProductInfoBLL.MiniUiListToJson(list, totalPage, strCondition);


        context.Response.Write(json);
    }


    /// <summary>
    /// 加载类别信息
    /// </summary>
    /// <param name="context"></param>
    public void GetProductType(HttpContext context)
    {
        context.Response.Write(new crafttypeBLL().craftTypeTreeToJson());

    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}