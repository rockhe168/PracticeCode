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

                int pType;
                if (Int32.TryParse(pTypeStr, out pType) == false)
                {
                    PrintSuccessJson(false.ToString().ToLower());
                }
                else
                {
                    DateTime createDate = DateTime.Now.Date;

                    channelinstallinfo channelInstalModel = channelinstallinfo.SingleOrDefault("where channelNo = @0 and createdate=@1", channelNo, createDate);
                    if (channelInstalModel == null)
                    {
                        channelInstalModel = new channelinstallinfo();
                    }
                    if (pType == 1)
                    {
                        HandlerPaymentRequest(mac, ip, channelNo, orderid, channelInstalModel);
                    }
                    else if (pType == 2)
                    {
                        HandlerPaymentSuccess(mac, ip, channelNo, orderid, channelInstalModel);
                    }
                    else if (pType == 3)
                    {
                        HandlerPaymentFail(mac, ip, channelNo, orderid, channelInstalModel);
                    }
                }
            }
            catch (Exception e)
            {
                PrintSuccessJson(false.ToString().ToLower());
            }
        }

        void HandlerPaymentRequest(string mac, string ip, string channelNo, string orderid,channelinstallinfo channelinstallModel)
        {
            paymentinfo model = new paymentinfo();
            model.ip = ip;
            model.mac = mac;
            model.date_created = DateTime.Now;
            model.channelNo = channelNo;
            model.orderId = orderid;
            model.ptype = 1;
            object obj = model.Insert();
            if (channelinstallModel.IsNew())
            {
                channelinstallModel.paymentcount = 1;
                channelinstallModel.createdate = DateTime.Now.Date;
                channelinstallModel.inputinstallcount = 0;
                channelinstallModel.channelNo = channelNo;
                channelinstallModel.paymentstate = false;
                channelinstallModel.date_created = DateTime.Now;
                channelinstallModel.Insert();
            }
            else
            {
                channelinstallModel.paymentcount += 1;
                channelinstallModel.Update();
            }

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

        void HandlerPaymentSuccess(string mac, string ip, string channelNo, string orderid, channelinstallinfo channelinstallModel)
        {
            bool result = paymentinfo.Exists("mac = @0", mac);
            if (!result)
            {
                paymentinfo model = new paymentinfo();
                model.ip = ip;
                model.mac = mac;
                model.date_created = DateTime.Now;
                model.channelNo = channelNo;
                model.orderId = orderid;
                model.ptype = 2;
                object obj = model.Insert();

                if (channelinstallModel.IsNew())
                {
                    channelinstallModel.paymentsuccesscount = 1;
                    channelinstallModel.paymentcount = 0;
                    channelinstallModel.createdate = DateTime.Now.Date;
                    channelinstallModel.inputinstallcount = 0;
                    channelinstallModel.channelNo = channelNo;
                    channelinstallModel.paymentstate = false;
                    channelinstallModel.date_created = DateTime.Now;
                    channelinstallModel.Insert();
                }
                else
                {
                    channelinstallModel.paymentsuccesscount += 1;
                    channelinstallModel.Update();
                }

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

        void HandlerPaymentFail(string mac, string ip, string channelNo, string orderid, channelinstallinfo channelinstallModel)
        {
            paymentinfo model = new paymentinfo();
            model.ip = ip;
            model.mac = mac;
            model.date_created = DateTime.Now;
            model.channelNo = channelNo;
            model.orderId = orderid;
            model.ptype = 3;
            object obj = model.Insert();

            if (channelinstallModel.IsNew())
            {
                channelinstallModel.paymentfailcount = 1;
                channelinstallModel.paymentsuccesscount = 0;
                channelinstallModel.paymentcount = 0;
                channelinstallModel.createdate = DateTime.Now.Date;
                channelinstallModel.inputinstallcount = 0;
                channelinstallModel.channelNo = channelNo;
                channelinstallModel.paymentstate = false;
                channelinstallModel.date_created = DateTime.Now;
                channelinstallModel.Insert();
            }
            else
            {
                channelinstallModel.paymentfailcount += 1;
                channelinstallModel.Update();
            }

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

            bool result =  paymentinfo.Exists("mac = @0", mac);

            PrintSuccessJson(result.ToString().ToLower());
            
        }
    }
}