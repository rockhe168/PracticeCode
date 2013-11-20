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

/// <summary>
///PayInfo 的摘要说明
/// </summary>
public class PayInfo
{
    public PayInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 商户
    /// </summary>
    public string SaleManId { get; set; }
    /// <summary>
    /// 回调地址
    /// </summary>
    public string CallBackUrl { get; set; }
    /// <summary>
    /// 产品名称
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// 订单号
    /// </summary>
    public string OrderId { get; set; }
    /// <summary>
    /// 总金额
    /// </summary>
    public string TotalFre { get; set; }
    /// <summary>
    /// 卖家邮箱
    /// </summary>
    public string SaleEmail { get; set; }
    /// <summary>
    /// 数字签名
    /// </summary>
    public string Sign { get; set; }
    /// <summary>
    /// 备注信息
    /// </summary>
    public string Remark { get; set; }

}
/// <summary>
/// 支付回调信息
/// </summary>
public class PayCallBackInfo
{
    /// <summary>
    /// 支付类型
    /// </summary>
    public Pay.PayType PayType { get; set; }
    /// <summary>
    /// 订单号
    /// </summary>
    public string OrderId { get; set; }
    /// <summary>
    /// 支付机构
    /// </summary>
    public string PayMode { get; set; }
    /// <summary>
    /// 支付金额
    /// </summary>
    public string PayFre { get; set; }
    /// <summary>
    /// 金额币种
    /// </summary>
    public string MoneyType { get; set; }
    /// <summary>
    /// 备注1
    /// </summary>
    public string Remark1 { get; set; }
    /// <summary>
    /// 备注2
    /// </summary>
    public string Remark2 { get; set; }
    /// <summary>
    /// 数字签名
    /// </summary>
    public string Sign { get; set; }
    /// <summary>
    /// 状态码
    /// </summary>
    public Pay.ReturnCode ReturnCode { get; set; }
    /// <summary>
    /// 回发的消息
    /// </summary>
    public string Msg { get; set; }
}
/// <summary>
/// 支付配置信息
/// </summary>
public class PayConfig
{
    /// <summary>
    /// 支付类型
    /// </summary>
    public Pay.PayType PayType { get; set; }
    /// <summary>
    /// 商户帐号
    /// </summary>
    public string v_mid { get; set; }
    /// <summary>
    /// 商户密码
    /// </summary>
    public string v_pwd { get; set; }
    /// <summary>
    /// 网关地址
    /// </summary>
    public string PayUrl { get; set; }
}
