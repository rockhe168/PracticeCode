using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videoContext;

namespace Web.Ajax
{
    /// <summary>
    /// PaymentInfoHandler 的摘要说明
    /// </summary>
    public class PaymentInfoHandler : BaseHandler
    {
        public void AddPaymentInfo()
        {
            try
            {
                string mac = Context.Request["mac"];
                string ip = Context.Request["ip"];
                string channelNo = Context.Request["channelNo"];
                string orderid = Context.Request["orderId"];
                string pTypeStr = Context.Request["ptype"]; //1，=发起支付请求，2=支付成功，3=支付失败
                string payMoneyStr = Context.Request["payMoney"];
                string payType = Context.Request["payType"];//weixinpay代表微信支付，alipay代表支付
                string isDispalyStr = Context.Request["isDispaly"];//是否显示，true = 显示、 false = 不显示
                decimal payMoney;
                decimal.TryParse(payMoneyStr, out payMoney);
                bool isDisplay;
                if(bool.TryParse(isDispalyStr, out isDisplay))
                {

                }
                else
                {
                    isDisplay = true;
                }

                int pType;
                if (Int32.TryParse(pTypeStr, out pType) == false)
                {
                    PrintSuccessJson(false.ToString().ToLower());
                }
                else
                {
                    DateTime createDate = DateTime.Now.Date;

                    //channelinstallinfo channelInstalModel = channelinstallinfo.SingleOrDefault("where channelNo = @0 and createdate=@1", channelNo, createDate);
                    //if (channelInstalModel == null)
                    //{
                    //    channelInstalModel = new channelinstallinfo();
                    //}
                    if (pType == 1)
                    {
                        HandlerPaymentRequest(mac, ip, channelNo, orderid);
                    }
                    else if (pType == 2)
                    {
                        HandlerPaymentSuccess(mac, ip, channelNo, orderid,payMoney,payType,isDisplay);
                    }
                    else if (pType == 3)
                    {
                        HandlerPaymentFail(mac, ip, channelNo, orderid);
                    }
                }
            }
            catch (Exception e)
            {
                PrintSuccessJson(false.ToString().ToLower());
            }
        }

        void HandlerPaymentRequest(string mac, string ip, string channelNo, string orderid)
        {
            bool result = paymentinfo.Exists("mac = @0", (string.IsNullOrEmpty(mac) ? ip : mac));
            if (!result)
            {
                paymentinfo model = new paymentinfo();
                model.ip = ip;
                model.mac = (string.IsNullOrEmpty(mac) ? ip : mac);
                model.date_created = DateTime.Now;
                model.channelNo = channelNo;
                model.orderId = orderid;
                model.ptype = 1;
                object obj = model.Insert();
             
                int id = -1;
                if (int.TryParse(obj.ToString(), out id))
                {
                    if (id > 0)
                    {
                        PrintSuccessJson(true.ToString().ToLower());
                    }
                    else
                    {
                        PrintSuccessJson(false.ToString().ToLower());
                    }
                }
                else
                {
                    PrintSuccessJson(false.ToString().ToLower());
                }
            }
            else
            {
                PrintSuccessJson(false.ToString().ToLower());
            }
        }

        void HandlerPaymentSuccess(string mac, string ip, string channelNo, string orderid, decimal payMoney, string payType, bool isDisplay)
        {
            bool result = paymentinfo.Exists("mac = @0 and ptype=2", mac);
            if (!result)
            {
                paymentinfo model = new paymentinfo();
                model.ip = ip;
                model.mac = mac;
                model.date_created = DateTime.Now;
                model.channelNo = channelNo;
                model.orderId = orderid;
                model.ptype = 2;
                model.payMoney = payMoney;
                model.payType = payType;
                model.isdisplay = isDisplay;
                object obj = model.Insert();
                int id = -1;
                if (int.TryParse(obj.ToString(), out id))
                {
                    if (id > 0)
                    {
                        PrintSuccessJson(true.ToString().ToLower());
                    }
                    else
                    {
                        PrintSuccessJson(false.ToString().ToLower());
                    }
                }
                else
                {
                    PrintSuccessJson(false.ToString().ToLower());
                }
            }
            else
            {
                PrintSuccessJson(true.ToString().ToLower());
            }
        }

        void HandlerPaymentFail(string mac, string ip, string channelNo, string orderid)
        {
            paymentinfo model = new paymentinfo();
            model.ip = ip;
            model.mac = mac;
            model.date_created = DateTime.Now;
            model.channelNo = channelNo;
            model.orderId = orderid;
            model.ptype = 3;
            object obj = model.Insert();

            int id = -1;
            if (int.TryParse(obj.ToString(), out id))
            {
                if (id > 0)
                {
                    PrintSuccessJson(true.ToString().ToLower());
                }
                else
                {
                    PrintSuccessJson(false.ToString().ToLower());
                }
            }
            else
            {
                PrintSuccessJson(false.ToString().ToLower());
            }
        }

        public void IsExists()
        {
            string mac = Context.Request["mac"];

            bool result =  paymentinfo.Exists("mac = @0 and ptype=2", mac);

            PrintSuccessJson(result.ToString().ToLower());
            
        }
    }
}