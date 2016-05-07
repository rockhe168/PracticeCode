using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videoContext;

namespace Web.Ajax
{
    /// <summary>
    /// ChannelHandler 的摘要说明
    /// </summary>
    public class ChannelHandler : BaseHandler
    {

        public void AddChannelHistory()
        {
            try
            {
                string channelNo = Context.Request["channelNo"];
                string url = Context.Request["url"];
                string ip = Context.Request["ip"];
                string mac = Context.Request["mac"];

                DateTime createDate = DateTime.Now.Date;
                bool isExists = channelhistory.Exists("channelNo = @0 and ip = @1 and createdate=@2", channelNo, (string.IsNullOrWhiteSpace(mac) ? ip : mac), createDate);

                if (isExists)
                {
                    PrintSuccessJson(true.ToString().ToLower());
                }
                else
                {

                    channel model = channel.SingleOrDefault("where channelNo = @0", channelNo);
                    if (model == null)
                    {
                        model = new channel();
                    }

                    if (model.IsNew())
                    {
                        model.count = 1;
                        model.date_created = DateTime.Now;
                        model.channelNo = channelNo;
                        model.Insert();
                    }
                    else
                    {
                        model.count += 1;
                        model.Update();
                    }
                    channelhistory channelHistoryModel = new channelhistory();
                    channelHistoryModel.channelNo = channelNo;
                    channelHistoryModel.date_created = DateTime.Now;
                    channelHistoryModel.url = url;
                    channelHistoryModel.createdate = createDate;
                    channelHistoryModel.ip = string.IsNullOrWhiteSpace(mac) ? ip :mac;
                    channelHistoryModel.Insert();

                    //安装量、ip流量统计
                    channelinstallinfo installmodel = channelinstallinfo.SingleOrDefault("where channelNo = @0 and createdate=@1", channelNo, createDate);
                    if (installmodel == null)
                    {
                        installmodel = new channelinstallinfo();
                    }

                    if (installmodel.IsNew())
                    {
                        installmodel.ipcount = 1;
                        installmodel.realinstallcount = 0;
                        installmodel.createdate = createDate;
                        installmodel.inputinstallcount = 0;
                        installmodel.channelNo = channelNo;
                        installmodel.paymentstate = false;
                        installmodel.date_created = DateTime.Now;
                        installmodel.Insert();
                    }
                    else
                    {
                        installmodel.ipcount += 1;
                        installmodel.Update();
                    }


                    PrintSuccessJson(true.ToString().ToLower());
                }
            }
            catch (Exception ex)
            {
                PrintSuccessJson(false.ToString().ToLower());
            }
        }


        public void AddChannelInstall()
        {
            try
            {
                string channelNo = Context.Request["channelNo"];
                string mac = Context.Request["mac"];
                string ip = Context.Request["ip"];
                DateTime createDate = DateTime.Now.Date;

                bool isExists = channelinstallhistoryinfo.Exists("channelNo = @0 and mac = @1 and createdate=@2", channelNo, (string.IsNullOrWhiteSpace(mac) ? ip : mac), createDate);
                if (isExists)
                {
                    PrintSuccessJson(true.ToString().ToLower());
                }
                else
                {
                    
                    channelinstallinfo model = channelinstallinfo.SingleOrDefault("where channelNo = @0 and createdate=@1", channelNo, createDate);
                    if (model == null)
                    {
                        model = new channelinstallinfo();
                    }

                    if (model.IsNew())
                    {
                        model.realinstallcount = 1;
                        model.paymentsuccesscount = 0;
                        model.paymentcount = 0;
                        model.paymentfailcount = 0;
                        model.inputinstallcount = 0;
                        model.pvcount = 0;
                        model.ipcount = 0;
                        model.createdate = createDate;
                        model.channelNo = channelNo;
                        model.paymentstate = false;
                        model.date_created = DateTime.Now;
                        model.Insert();
                    }
                    else
                    {
                        model.realinstallcount += 1;
                        model.Update();
                    }
                    channelinstallhistoryinfo channelHistoryModel = new channelinstallhistoryinfo();
                    channelHistoryModel.channelNo = channelNo;
                    channelHistoryModel.mac = string.IsNullOrWhiteSpace(mac) ? ip : mac;
                    channelHistoryModel.createdate = createDate;
                    channelHistoryModel.date_created = DateTime.Now;
                    channelHistoryModel.Insert();

                    PrintSuccessJson(true.ToString().ToLower());
                }
            }
            catch (Exception ex)
            {
                PrintSuccessJson(false.ToString().ToLower());
            }
        }

    }
}