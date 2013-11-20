using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Common;
using czcraft.BLL;

/// <summary>
///Pay 的摘要说明
/// </summary>
public class Pay
{
    //支付平台的配置信息
    public readonly static  PayConfig config=GetPayConfig();
    public Pay()
    {
      
       
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
   
    /// <summary>
    /// 支付类型
    /// </summary>
    public enum PayType
    {
        /// <summary>
        /// 支付宝
        /// </summary>
        Alipay = 0,
        /// <summary>
        /// 网银在线
        /// </summary>
        ChinaBank = 1
    }
    /// <summary>
    /// 回调状态码(支付宝才有)
    /// </summary>
    public enum ReturnCode
    {
        /// <summary>
        /// 支付成功!
        /// </summary>
        ok = 0,
        /// <summary>
        /// 支付失败!
        /// </summary>
        error = 1
    }

    #region 构造支付的URL
    /// <summary>
    /// 构造支付的URL(从配置文件中读取出支付平台配置信息然后构造支付的网关信息(支付平台由配置文件决定)(初步只提供网银在线和支付宝两种模式中的一种)
    /// </summary>
    /// <param name="Info">支付信息(支付宝支付需要输入总金额,产品名称,订单号,卖家邮箱)</param>
    /// <returns></returns>
    public string BuildURL(PayInfo Info)
    {
        //获取支付平台的配置信息
        //PayConfig config = GetPayConfig();
        //支付的地址
        string PayUrl = "";
        switch (config.PayType)
        {
            //支付宝支付
            case PayType.Alipay:
                PayUrl = BuildAlipayURL(Info, config);
                break;
            //网银在线支付
            case PayType.ChinaBank:
                PayUrl = BuildChinaBackUrl(Info, config);
                break;
            default:
               PayUrl= "#";
               break;
        }
        return PayUrl;
    }
    #endregion

    #region 支付完成回调处理
    /// <summary>
    /// 支付完成回调处理
    /// </summary>
    /// <param name="Msg">回调信息</param>
    /// <returns></returns>
    public PayCallBackInfo CallBackPayInfo()
    {
       string Msg = "";
        PayCallBackInfo CallBackInfo = new PayCallBackInfo();
        switch (config.PayType)
        {
            //支付宝支付
            case PayType.Alipay:
                CallBackInfo = CallBackAlipayInfo();
                break;
            //网银在线支付
            case PayType.ChinaBank:
                CallBackInfo = CallBackChinaBankInfo();
                break;
            default:
                CallBackInfo = null;
                break;
        }
        return CallBackInfo;
    }
    #region 支付宝支付完成回调处理
    /// <summary>
    /// 支付宝支付完成回调处理
    /// </summary>
    /// <param name="Msg">回调信息</param>
    /// <returns></returns>
    private PayCallBackInfo CallBackAlipayInfo()
    {
        //回调信息
       string Msg = "";
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        //订单号
        string OrderId = context.Request["out_trade_no"];
        //回调状态码
        string ReturnCode = context.Request["returncode"];
        //总金额
        string TotalFre = context.Request["total_fee"];
        //数字签名
        string Sign = context.Request["sign"];
        //数字签名(本地计算的)
        string Md5Sign = CommonHelper.GetMD5(OrderId + ReturnCode + TotalFre + config.v_pwd);
        //回调信息
        PayCallBackInfo CallBackInfo = new PayCallBackInfo();
        if (Md5Sign.Equals(Sign))
        {
            //支付成功!
            if (ReturnCode.Equals(Pay.ReturnCode.ok.ToString()))
            {
                Msg = "支付成功!";
                CallBackInfo.Msg = Msg;
                CallBackInfo.OrderId = OrderId;
                CallBackInfo.PayFre = TotalFre;
                CallBackInfo.ReturnCode = Pay.ReturnCode.ok;
            }
            else
            {
                Msg = "支付失败!";
             
                CallBackInfo.Msg = Msg;
                CallBackInfo.ReturnCode = Pay.ReturnCode.error;
            }

        }
        else
        {
            Msg = "数据被篡改!";
            CallBackInfo.Msg = Msg;
            CallBackInfo.ReturnCode = Pay.ReturnCode.error;
        }
        return CallBackInfo;
    } 
    #endregion
    #region 网银在线支付完成回调处理
    /// <summary>
    /// 网银在线支付完成回调处理(未实现)
    /// </summary>
    /// <param name="Msg">回调信息</param>
    /// <returns></returns>
    private PayCallBackInfo CallBackChinaBankInfo()
    {
        //回调信息
      string  Msg = "";
        PayCallBackInfo CallBackInfo = new PayCallBackInfo();
        return CallBackInfo;
    } 
    #endregion
    #endregion
    #region 支付宝平台的网关URL
    /// <summary>
    /// 支付宝平台的网关URL
    /// </summary>
    /// <param name="info">支付信息</param>
    /// <param name="config">系统支付配置</param>
    /// <returns></returns>
    private string BuildAlipayURL(PayInfo info, PayConfig config)
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        //为按顺序连接 总金额、 商户编号、订单号、商品名称、商户密钥的MD5值。
        //支付宝数字签名
        string SignMd5 = CommonHelper.GetMD5(info.TotalFre + config.v_mid + info.OrderId + info.ProductName + config.v_pwd);
        //回调网址
        string webpath = context.Server.UrlEncode(context.Request.Url.Scheme + "://" + context.Request.Url.Authority + System.Web.VirtualPathUtility.ToAbsolute("~/Member/Data/DealAlipayCallBack.ashx"));
        //商品名称
        string ProductName = System.Web.HttpContext.Current.Server.UrlEncode(info.ProductName);
        //备注
        string Remark = System.Web.HttpContext.Current.Server.UrlEncode(info.Remark);
        //支付的URL地址
        string PayURL = config.PayUrl + "?partner=" + config.v_mid + "&return_url=" + webpath + "&subject=" + ProductName + "&body=" + Remark + "&out_trade_no=" + info.OrderId + "&total_fee=" + info.TotalFre + "&seller_email=" + info.SaleEmail + "&sign=" + SignMd5;
        return PayURL;

    }
    #endregion

    #region 网银在线平台的网关URL
    /// <summary>
    /// 网银在线平台的网关URL(等待实现)
    /// </summary>
    /// <param name="info">支付信息</param>
    /// <param name="config">系统支付配置</param>
    /// <returns></returns>
    private string BuildChinaBackUrl(PayInfo info, PayConfig config)
    {
        return "";

    }
    #endregion

    #region 获取系统配置信息(支付相关)
    /// <summary>
    /// 获取系统配置信息(支付相关)
    /// </summary>
    /// <returns></returns>
    public static PayConfig GetPayConfig()
    {
        PayConfig info = new PayConfig();
        //读取配置文件信息
        string path = System.Web.HttpContext.Current.Server.MapPath(@"~/Admin/ConfigManage/config.xml");
        //系统配置中的支付类型
        string ConfigPayType = XMlHelper.Read(path, "/Root/Pay", "PayType");
        //商户帐号
        string v_mid = XMlHelper.Read(path, "/Root/Pay/" + ConfigPayType, "v_mid");
        //商户密码
        string v_pwd = XMlHelper.Read(path, "/Root/Pay/" + ConfigPayType, "v_pwd");
        //支付网关
        string PayUrl = XMlHelper.Read(path, "/Root/Pay/" + ConfigPayType + "/PayUrl", "");


        info.PayType = ConfigPayType == PayType.Alipay.ToString() ? PayType.Alipay : PayType.ChinaBank;
        info.v_mid = v_mid;
        info.v_pwd = v_pwd;
        info.PayUrl = PayUrl;

        return info;

    }
    #endregion

}
