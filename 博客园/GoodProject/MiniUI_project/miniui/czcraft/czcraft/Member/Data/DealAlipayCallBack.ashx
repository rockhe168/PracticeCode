<%@ WebHandler Language="C#" Class="DealAlipayCallBack" %>

using System;
using System.Web;
using czcraft.Model;
using czcraft.BLL;
//处理关于支付宝回调
public class DealAlipayCallBack : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //支付回调
        Pay pay = new Pay();
        PayCallBackInfo CallBackInfo = pay.CallBackPayInfo();
        if (CallBackInfo.ReturnCode == Pay.ReturnCode.ok)
        {
            CallBackInfo.Msg = "恭喜您,支付成功!我们会尽快发货!如果您收货就可以继续确认收货!";
            //支付状态为已支付
            orders.ePaymentStatus PaymentStatus = orders.ePaymentStatus.IsPay;
            //已付款
            orders.eOrderStatus OrderStatus = orders.eOrderStatus.IsPay;
            //等待发货
            orders.eOgisticsStatus OgisticsStatus = orders.eOgisticsStatus.WaitSendProduct;
            bool DealStatus = new ordersBLL().UpdateOrdersStatus(CallBackInfo.OrderId, PaymentStatus,OgisticsStatus,OrderStatus);
        }
        else
            CallBackInfo.Msg = "对不起,支付失败!!失败信息 :" + CallBackInfo.Msg + "请联系支付宝有关人员!";
        //回调信息
        string Msg = System.Web.HttpContext.Current.Server.UrlEncode(CallBackInfo.Msg);
        Common.JScript.JavaScriptLocationHref("../PayCallBack.aspx?ReturnCode=" + CallBackInfo.ReturnCode.ToString() + "&Msg=" + Msg + "&OrderId=" + CallBackInfo.OrderId + "&PayFre=" + CallBackInfo.PayFre);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}