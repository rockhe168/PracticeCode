using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videoContext;

namespace Web.Ajax
{
    /// <summary>
    /// PVHandler 的摘要说明
    /// </summary>
    public class PVHandler : BaseHandler
    {

        public void AddPv()
        {
            string ip = Context.Request["ip"];
            string mac = Context.Request["mac"];
            string channelNo = Context.Request["channelNo"];

            DateTime date = DateTime.Now.Date;
            bool isExists = pvinfo.Exists("where ip = @0 and createdate=", ip,date);

            if (!isExists)
            {
                pvinfo model = new pvinfo();
                model.channelNo = channelNo;
                model.createdate = date;
                model.ip = ip;
                model.mac = mac;
                model.date_created = DateTime.Now;
                object obj = model.Insert();

                channelinstallinfo channelInstalModel = channelinstallinfo.SingleOrDefault("where channelNo = @0 and createdate=@1", channelNo, date);
                if (channelInstalModel == null)
                {
                    channelInstalModel = new channelinstallinfo();
                }
                if (channelInstalModel.IsNew())
                {
                    channelInstalModel.pvcount = 1;
                    channelInstalModel.createdate = DateTime.Now.Date;
                    channelInstalModel.inputinstallcount = 0;
                    channelInstalModel.channelNo = channelNo;
                    channelInstalModel.paymentstate = false;
                    channelInstalModel.date_created = DateTime.Now;
                    channelInstalModel.Insert();
                }
                else
                {
                    channelInstalModel.pvcount += 1;
                    channelInstalModel.Update();
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

    }
}