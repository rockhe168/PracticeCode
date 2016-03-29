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
            string mac = Context.Request["mac"];
            string ip = Context.Request["ip"];
            string channelNo = Context.Request["channelNo"];
            string orderid = Context.Request["orderId"];

            bool result =  paymentinfo.Exists("mac = @0", mac);
            if(!result)
            {
                paymentinfo model = new paymentinfo();
                model.ip = ip;
                model.mac = mac;
                model.date_created = DateTime.Now;
                model.channelNo = channelNo;
                model.orderId = orderid;
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
            }else
            {
                PrintSuccessJson(true.ToString().ToLower());
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