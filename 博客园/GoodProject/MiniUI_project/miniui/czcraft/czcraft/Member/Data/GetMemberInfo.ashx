<%@ WebHandler Language="C#" Class="GetMemberInfo" %>

using System;
using System.Web;
using Common;
using czcraft.Model;
using czcraft.BLL;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
public class GetMemberInfo : IHttpHandler, IRequiresSessionState
{
    //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public void ProcessRequest(HttpContext context)
    {
        //测试专用
        //context.Session["UserId"] = "20";
        //测试专用
       // context.Session["UserName"] = "tzh123456";
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
            case "GetArea":
                GetArea(context);
                break;
            case "UpdateUserInfo":
                UpdateUserInfo(context);
                break;
            case "CheckPwd":
                CheckPwd(context);
                break;
            case "UpdatePwd":
                UpdatePwd(context);
                break;
            case "ActivationMemberNumber":
                ActivationMemberNumber(context);
                break;
            case "ForgetPwd":
                ForgetPwd(context);
                break;
            case "GetUserInfo":
                GetUserInfo(context);
                break;
            case "CheckExistUserName":
                CheckExistUserName(context);
                break;
            case "MemberLogin":
                MemberLogin(context);
                break;
            case "SaveMemberInfo":
                SaveMemberInfo(context);
                break;
            case "CheckLoginStatus":
                CheckLoginStatus(context);
                break;
            case "MemberLogout":
                MemberLogout(context);
                break;
            case "SearchShoppingCart":
                SearchShoppingCart(context);
                break;
            case "SaveShoppingCart":
                SaveShoppingCart(context);
                break;
            case "RemoveShoppingCart":
                RemoveShoppingCart(context);
                break;
            case "GetCartInfo":
                GetCartInfo(context);
                break;
            case "SubmitOrderData":
                SubmitOrderData(context);
                break;
            case "SearchOrders":
                SearchOrders(context);
                break;
            case "GetMemberMoreInfo":
                GetMemberMoreInfo(context);
                break;
            case "CancelOrders":
                CancelOrders(context);
                break;
            case "PayOrders":
                PayOrders(context);
                break;
            case "SaveComment":
                SaveComment(context);
                break;
            case "SearchCollection":
                SearchCollection(context);
                break;
            case "RemoveCollection":
                RemoveCollection(context);
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
        memberBLL bll = new memberBLL();
        string UserName = context.Request["UserName"];
        string CheckCode = context.Request["CheckCode"];
        string Email = context.Request["Email"];
        //验证码校验
        if (!CheckCode.Equals(context.Session["checkcode"].ToString ()))
        {
            context.Response.Write(bll.WriteJsonForReturn(false, "验证码不正确!"));
            return;
        }
        //字符串sql注入检测
        if (Tools.IsValidInput(ref UserName, true) && Tools.IsValidInput(ref Email, true))
        {
            //获取用户邮箱
           
            //邮箱和用户名状态(正确与否)
            bool status = bll.CheckUserNameAndEmail(UserName,Email);
            //随机生成一个6位的新密码
            string NewPwd = bll.CreateNewPwd();
            if (!string.IsNullOrEmpty(Email) && status && bll.UpdatePwd(UserName, NewPwd))
            {
                SMTP smtp = new SMTP(Email);
                if (smtp.sendemail("潮州工艺品平台", "尊敬的" + UserName + "用户:恭喜您,您在" + DateTime.Now.ToString() + "使用找回密码功能重置密码,您的密码:" + NewPwd + ",请尽快修改密码并妥善保管!"))
                {
                    context.Response.Write(bll.WriteJsonForReturn(true, Tools.GetEmail(Email)));
                }
                else {
                    context.Response.Write(bll.WriteJsonForReturn(false , "邮箱发送失败!"));
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
    /// 激活帐号
    /// </summary>
    /// <param name="context"></param>
    public void ActivationMemberNumber(HttpContext context)
    {
        //注意要对url解码
        string UserName = context.Server.UrlDecode(context.Request["UserName"]);
        
        string VCode = context.Request["VCode"];
        memberBLL bll = new memberBLL();
        //激活
        if (Tools.IsValidInput(ref UserName, true) && Tools.IsValidInput(ref VCode, true))
        {
            context.Response.Write(bll.WriteJsonForReturn(bll.ActivationMemberNumber(UserName, VCode), "")); ;
        }
        else
        {
            context.Response.Write(bll.WriteJsonForReturn(false, ""));
        }
       
        
    }
    /// <summary>
    /// 更改密码
    /// </summary>
    /// <param name="context"></param>
    public void UpdatePwd(HttpContext context)
    {
        string SessionUserName = (string)context.Session["UserName"];
        string OldPWd=context.Request["txtOldPwd"];
        string NewPwd=context.Request["txtNewPwd"];
         memberBLL bll = new memberBLL();
        if (string.IsNullOrEmpty(SessionUserName))
        {
           context.Response.Write(bll.WriteJsonForReturn(false, ""));
        }
        else {
           
            context.Response.Write(bll.WriteJsonForReturn(bll.UpdatePassword(SessionUserName, OldPWd, NewPwd), SessionUserName));  
        }
        
    }
    /// <summary>
    /// 检验密码
    /// </summary>
    /// <param name="context"></param>
    public void CheckPwd(HttpContext context)
    { 
      
        string SessionUserName = (string)context.Session["UserName"];
       
        string fieldId = context.Request["fieldId"];
        string fieldValue = context.Request["fieldValue"];
        //返回格式为数组(切记)
        memberBLL bll = new memberBLL();
        string ReturnMsg = "";
        
        ReturnMsg = bll.ReturnValueValidateAjax(fieldId, true, "");
        context.Response.Write(ReturnMsg);
    
    }
    /// <summary>
    /// 更新用户信息
    /// </summary>
    /// <param name="context"></param>
    public void UpdateUserInfo(HttpContext context)
    {
        //用户表单读取
        string SessionUserName = (string)context.Session["UserName"];
        string UserName = context.Request["UserName"];
        string QQ = context.Request["QQ"];
        string Email = context.Request["Email"];
        string Sex = context.Request["Sex"];
        string Province = context.Request["Province"];
        string City = context.Request["City"];
        string Country = context.Request["Country"];
        string Address = context.Request["Address"];
        string ZipCode = context.Request["ZipCode"];
        string MobilePhone = context.Request["MobilePhone"];
        string TelPhone = context.Request["TelPhone"];
        string Nation = context.Request["Nation"];
        memberBLL bll = new memberBLL();
        //验证不成功!
        if (!SessionUserName.Equals(UserName) || !Tools.IsValidInput(ref QQ, true) || !Tools.IsValidInput(ref Email, true) || !Tools.IsValidInput(ref Sex, true) || !Tools.IsValidInput(ref Province, true) || !Tools.IsValidInput(ref City, true) || !Tools.IsValidInput(ref Country, true) || !Tools.IsValidInput(ref Address, true) || !Tools.IsValidInput(ref ZipCode, true) || !Tools.IsValidInput(ref MobilePhone, true) || !Tools.IsValidInput(ref TelPhone, true))
        {
            //验证失败!
            bll.WriteJsonForReturn(false, "");
        }
        else {
            member info = new member();
            info.qq = QQ;
            info.Email = Email;
            info.Sex = Sex;
            info.Address = Province + "|" + City + "|" + Country + "|" + Address;
            info.Zipcode = ZipCode;
            info.mobilephone = MobilePhone;
            info.Telephone = TelPhone;
            info.username = UserName;
            info.nation = Nation;
            
            //输出返回状态
           context.Response.Write(bll.WriteJsonForReturn(bll.UpdateUserInfo(info), info.username)) ;
           
        }
        //logger.Debug(UserName);
        
    }
    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <param name="context"></param>
    public void GetUserInfo(HttpContext context)
    {

        string UserName = (string)context.Session["UserName"];
        memberBLL bll = new memberBLL();
        if (!Tools.IsNullOrEmpty(UserName))
        {
            //如果session存在,直接返回用户状态
           context.Response.Write(bll.GetMemberInfoByJson(UserName));
        }
       
    }
    /// <summary>
    /// 获取地区(省市联动)
    /// </summary>
    /// <param name="context"></param>
    public void GetArea(HttpContext context)
    {
        //省市联动(根据父级id获取子级)
        string Pid = context.Request["CodeId"];
        if (Tools.IsValidInput(ref Pid, true))
        {

            context.Response.Write(new dbProvinceBLL().GetAreaByJson(Pid));
        }
    }
    /// <summary>
    /// 退出
    /// </summary>
    /// <param name="context"></param>
    public void MemberLogout(HttpContext context)
    {
        string UserName = (string)context.Session["UserName"];
        memberBLL bll = new memberBLL();
        if (!Tools.IsNullOrEmpty(UserName))
        {
            //如果session存在,清除session
            context.Session.Remove("UserName");
            context.Session.Remove("UserId");
        }
        //清除cookies
        CookieHelper.ClearCookie("UserName");
        CookieHelper.ClearCookie("Pwd");
        //页面跳转
        JScript.AlertAndRedirect("安全退出成功!欢迎下次前来访问!", "../../Default.aspx");
    }
    /// <summary>
    /// 检查用户登录状态
    /// </summary>
    /// <param name="context"></param>
    public void CheckLoginStatus(HttpContext context)
    {
        string UserName = (string)context.Session["UserName"];
        memberBLL bll = new memberBLL();
        bool Status = false;
        if (!Tools.IsNullOrEmpty(UserName))
        {
            //如果session存在,直接返回用户状态
          context.Response.Write(bll.WriteJsonForReturn(true, UserName));
        }
        else
        {
            //用户自动登录状态检测

            context.Response.Write(bll.CheckLoginStatus(out Status));
            //登录成功!
            if (Status)
            {
                context.Session["UserName"] = Common.CookieHelper.GetCookieValue("UserName");
            }
           
           
        }
        //如果登录成功,则把用户ID放在Session中
        if (Status == true&&Tools.IsNullOrEmpty(context.Session["UserId"]))
        {
        context.Session["UserId"]= bll.GetMemberId(UserName);
        }

    }
    /// <summary>
    /// 会员登录
    /// </summary>
    /// <param name="context"></param>
    public void MemberLogin(HttpContext context)
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
                member info = new member();
                memberBLL bll = new memberBLL();
                info.username = Name;
                info.password = Pwd;
                ReturnJson = bll.ReturnJson(info, out Status);
                if (Status) //如果成功登陆
                {
                    //记住帐号和密码
                    bll.RememberUserInfo(info, bll.GetRememberType(IsSaveName, IsSavePwd));

                    //保存登录状态
                    context.Session["UserName"] = info.username;
                    //如果登录成功,则把用户ID放在Session中
                    if (Tools.IsNullOrEmpty(context.Session["UserId"]))
                    {
                        context.Session["UserId"] = bll.GetMemberId(info.username);
                    }
                }
                context.Response.Write(ReturnJson);
            }
        }
        catch (Exception ex)
        {
            logger.Error("会员登录出错!", ex);
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
    /// 保存用户信息 
    /// </summary>
    /// <param name="context"></param>
    public void SaveMemberInfo(HttpContext context)
    {
        memberBLL bll = new memberBLL();
        try
        {
            //表单读取
            string txtUserName = context.Request["txtUserName"];
            string txtPwd = context.Request["txtPwd"];
            string txtEmail = context.Request["txtEmail"];
            string txtCheckCode = context.Request["txtCheckCode"];
            //验证码校验
            if (!txtCheckCode.Equals(context.Session["checkcode"].ToString()))
            {
                context.Response.Write(bll.WriteJsonForReturn(false, ""));
            }
            //字符串sql注入检测
            if (Tools.IsValidInput(ref txtUserName, true) && Tools.IsValidInput(ref txtPwd, true) && Tools.IsValidInput(ref txtEmail, true))
            {
                member info = new member();
                info.username = txtUserName;
                info.password =Tools.GetMD5(txtPwd);
                info.Email = txtEmail;
                info.states = "0";
               
                //加随机验证码
                info.VCode = Guid.NewGuid().ToString("N");
                //验证失效(1小时以内激活有效)
                info.VTime = DateTime.Now.AddHours(1);
               
                //验证用户名
                if (!bll.CheckExistUserName(info.username)) {
                    context.Response.Write(bll.WriteJsonForReturn(false, ""));
                    return;
                }
                if (bll.AddNew(info) > 0)
                {
                    SMTP smtp = new SMTP(info.Email);
                    //激活网址生成
                    string webpath = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/Member/EmailChecking.aspx")+"?UserName="+context.Server.UrlEncode(info.username)+"&YZM="+info.VCode;
                    //发送激活邮件
                    if (smtp.Activation(webpath, info.username))
                    {

                        context.Response.Write(bll.WriteJsonForReturn(true, Tools.GetEmail(info.Email)));
                     
                    }
                    else {
                        context.Response.Write(bll.WriteJsonForReturn(false, ""));
                    }
                }
                else
                {
                    context.Response.Write(bll.WriteJsonForReturn(false, ""));
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error("错误!", ex);
            context.Response.Write(bll.WriteJsonForReturn(false, ""));
        }
    }
    /// <summary>
    /// 购物车检索
    /// </summary>
    /// <param name="context"></param>
    public void SearchShoppingCart(HttpContext context)
    {
        //用户id
        string UserId = SessionHelper.GetSession("UserId").ToString();
       // string key = context.Request["key"];
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
        string strCondition = "";
        VCartProductInfoBLL bll = new VCartProductInfoBLL();
        if (Tools.IsNullOrEmpty(sortField))
            sortField = "Id";
        //查询条件
        strCondition = " MemberId=" + UserId;
        //分页数据读取
        IEnumerable<VCartProductInfo> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);

        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = Common.FormatToJson.MiniUiListToJson<VCartProductInfo>((IList<VCartProductInfo>)list, totalPage, "");
        context.Response.Write(json);
    }
    /// <summary>
    /// 保存到购物车
    /// </summary>
    /// <param name="context"></param>
    public void SaveShoppingCart(HttpContext context)
    {
        //数据读取
        String Cart = context.Request["ShoppingCart"];
        string info = Cart.TrimStart('[');
        info = info.TrimEnd(']');
        JObject o = JObject.Parse(info);
        Int64 Id = (Int64)o.SelectToken("Id");
        int Quantity = (int)o.SelectToken("Quantity");
        Int64 ProductId = (Int64)o.SelectToken("ProductId");
        //库存判断
        product CartInfo = new productBLL().Get(ProductId);
        if (Quantity > (int)(CartInfo.Num.Value - CartInfo.Soldnum.Value))
        {
            context.Response.Write(Tools.WriteJsonForReturn(false, "库存数量不足!"));
            return;
        }
        //更新购物车
        ShoppingCart Shop=new ShoppingCart ();
        Shop.Id=Id;
        Shop.Quantity=Quantity;
        bool Status=false;
       Status=new ShoppingCartBLL().UpdateShoppingCart(Shop);
       string Msg="";
       if (Status)
       {
           Msg = "";
       }
       else
           Msg = "库存不足!";
       context.Response.Write(Tools.WriteJsonForReturn(Status, Msg));
       
    }
    
    /// <summary>
    /// 获取购物车信息
    /// </summary>
    /// <param name="context"></param>
    public void GetCartInfo(HttpContext context)
    {
        string UserId = (string)context.Session["UserId"];
            
        context.Response.Write(new ShoppingCartBLL().GetCartInfo(UserId));
    }
    /// <summary>
    /// 删除购物车内容
    /// </summary>
    /// <param name="context"></param>
    public void RemoveShoppingCart(HttpContext context)
    {
        String idStr = context.Request["Id"];
        if (String.IsNullOrEmpty(idStr)) return;
        //检验客户端字符串
        if (Common.Tools.IsValidInput(ref idStr, true))
        {
            new ShoppingCartBLL().DeleteMoreID(idStr);
        }
    }
    /// <summary>
    /// 订单提交
    /// </summary>
    /// <param name="context"></param>
    public void SubmitOrderData(HttpContext context)
    {
          string UserId = (string)context.Session["UserId"];
        if(Tools.IsNullOrEmpty(UserId))
        {
            return;
        }
        string Name = context.Request["Name"];
        string Email = context.Request["Email"];
        string Province = context.Request["Province"];
        string City = context.Request["City"];
        string Country = context.Request["Country"];
        string Address = context.Request["Address"];
        string ZipCode = context.Request["ZipCode"];
        string MobilePhone = context.Request["MobilePhone"];
        string TelPhone = context.Request["TelPhone"];
        //订单信息保存
        orders order = new orders();
        order.ConsigneeName = Name;
        order.ConsigneeRealName = Name;
        order.ConsigneeEmail = Email;
        order.ConsigneeProvince = Province;
        order.ConsigneeZip = ZipCode;
        order.UserId =Convert.ToInt32(UserId);
        order.ConsigneeAddress = City + Country + Address;
        order.OrderDate = DateTime.Now;
        order.ConsigneePhone = MobilePhone;
        order.ConsigneeTel = TelPhone;
        order.OrderId = ordersBLL.GetOrderId();
        ordersBLL bll = new ordersBLL();
        string ReturnProductName = "";
        //下单
        bool Status = bll.SaveOrder(ref order, out ReturnProductName);
        //去除最后的,
        ReturnProductName = ReturnProductName.Remove(ReturnProductName.Length - 1, 1);
        string Data = "";
        //支付跳转URL
        string TurnURL = "";
        if (Status)
        {
            Data = "恭喜您!下单成功!";
            //支付平台的跳转URL生成
           // PayInfo info=new PayInfo ();
           // info.SaleEmail="tianzhuanghu@qq.com";
           // info.OrderId=order.OrderId;
           // info.ProductName = ReturnProductName;
           
           // info.Remark=order.ConsigneeName+"在"+order.ShopDate.Value.ToShortDateString()+"购买商品,共计:"+order.TotalPrice.Value.ToString ();
           // info.TotalFre = order.FactPrice.Value.ToString ();
           // Pay pay = new Pay();
           //TurnURL=pay.BuildURL(info);
        }
        else
            Data = "对不起!下单失败!";
        //返回的json数据
        string ReturnJson = "{\"Status\":\"" + Status + "\",\"Data\":\"" + Data + "\",\"URL\":\""+TurnURL+"\"}"; ;
         context.Response.Write(ReturnJson);
    
    }
    /// <summary>
    /// 订单信息
    /// </summary>
    /// <param name="context"></param>
    public void SearchOrders(HttpContext context)
    {
        //用户id
        string UserId = SessionHelper.GetSession("UserId").ToString();
         string key = context.Request["key"];
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
        string strCondition = "";
        VOrdersBLL bll = new VOrdersBLL();
        if (Tools.IsNullOrEmpty(sortField))
            sortField = "Id";
        //查询条件
        strCondition = " UserId=" + UserId;
        if (Tools.IsValidInput(ref key,true))
            strCondition += " and OrderId='" + key+"'";
        //分页数据读取
        IEnumerable<VOrders> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);

        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = Common.FormatToJson.MiniUiListToJson<VOrders>((IList<VOrders>)list, totalPage, "");
        context.Response.Write(json);
    }
    /// <summary>
    /// 搜索收藏夹
    /// </summary>
    /// <param name="context"></param>
    public void SearchCollection(HttpContext context)
    {
        //用户id
        string UserId = SessionHelper.GetSession("UserId").ToString();
        string key = context.Request["key"];
        //分页
        int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
        int pageSize = Convert.ToInt32(context.Request["pageSize"]);
        //字段排序
        String sortField = context.Request["sortField"];
        String sortOrder = context.Request["sortOrder"];
        string strCondition = "";
        VMemberCollectProductBLL bll = new VMemberCollectProductBLL();
        if (Tools.IsNullOrEmpty(sortField))
            sortField = "ProductId";
        //查询条件
        strCondition = " MemberId=" + UserId;
        if (key=="IsToday") //如果查询今日收藏
            strCondition += " and datediff(day ,AddTime ,getdate()) <=1";
        //分页数据读取
        IEnumerable<VMemberCollectProduct> list = bll.ListByPagination(sortField, pageSize, pageIndex + 1, sortOrder == "asc" ? "1" : "0", strCondition);

        //获取总页数
        int totalPage = bll.GetCount(strCondition);
        //JSON 序列化
        string json = Common.FormatToJson.MiniUiListToJson<VMemberCollectProduct>((IList<VMemberCollectProduct>)list, totalPage, "");
        context.Response.Write(json);
    }
    /// <summary>
    /// 删除收藏
    /// </summary>
    /// <param name="context"></param>
    public void RemoveCollection(HttpContext context)
    {

        String idStr = context.Request["Id"];
        if (String.IsNullOrEmpty(idStr)) return;
        //检验客户端字符串
        if (Common.Tools.IsValidInput(ref idStr, true))
        {

            new MemberCollectionBLL().DeleteMoreID(idStr);
        }
    }
    /// <summary>
    /// 获取会员更多信息
    /// </summary>
    /// <param name="context"></param>
    public void GetMemberMoreInfo(HttpContext context)
    {
        string strId = context.Request["id"];
        context.Response.Write(new ordersBLL().GetOrdersMemberInfo(strId)); 
    }
    /// <summary>
    /// 取消订单
    /// </summary>
    /// <param name="context"></param>
    public void CancelOrders(HttpContext context)
    {
        string strId = context.Request["OrderId"];
        //取消订单
        orders.ePaymentStatus Status = new orders.ePaymentStatus();
        Status = orders.ePaymentStatus.IsCancel;
        orders.eOrderStatus OrderStatus = orders.eOrderStatus.IsReturnPay;
        context.Response.Write(new ordersBLL().CancelOrdersStatus(strId, Status, OrderStatus));
   
    }
    /// <summary>
    /// 付款
    /// </summary>
    /// <param name="context"></param>
    public void PayOrders(HttpContext context)
    {
        string OrderId = context.Request["OrderId"];
        orders order = new ordersBLL().GetOrdersByOrderId(OrderId);
        //执行订单状态
        bool Status = false;
        //支付跳转的URL
        string TurnURL = "";
        //返回的消息
        string Data = "";
        //判断订单号是否正确
        if (order.Id.HasValue)
        {
            PayInfo info = new PayInfo();
            Status = true;
            info.SaleEmail = "tianzhuanghu@qq.com";
            info.OrderId = order.OrderId;
            info.ProductName = "潮州工艺品多件商品";
            info.Remark = order.ConsigneeName + "在" + order.ShopDate.Value.ToShortDateString() + "购买商品,共计:" + order.TotalPrice.Value.ToString();
            info.TotalFre = order.FactPrice.Value.ToString();
            Pay pay = new Pay();
           TurnURL = pay.BuildURL(info);
           Data = "支付跳转中...";
        }
        string ReturnJson = "{\"Status\":\"" + Status + "\",\"Data\":\"" + Data + "\",\"URL\":\"" + TurnURL + "\"}"; ;
        context.Response.Write(ReturnJson);
    }
    /// <summary>
    /// 保存评论
    /// </summary>
    /// <param name="context"></param>
    public void SaveComment(HttpContext context)
    {
        string Content = context.Request["Content"];
        string hidStar = context.Request["hidStar"];
        string CheckCode = context.Request["CheckCode"];
        string OrderProId = context.Request["OrderProId"];
        string MemberId = context.Request["UserName"];
        if (Tools.IsNullOrEmpty(MemberId))
        {
            context.Response.Write(Tools.WriteJsonForReturn(false, "未登录!"));
            return;
        }
        comment Info = new comment();
        Info.Time = DateTime.Now;
        Info.Grade = Convert.ToDouble(hidStar);
        Info.Content = Content;
        Info.MemberId =Convert.ToInt32(MemberId);
        context.Response.Write(new commentBLL().AddComment(Info,OrderProId));
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}