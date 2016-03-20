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
                string ip =Context.Request["ip"];

                channel model = channel.SingleOrDefault("where channelNo = @0", channelNo);
                

                if(model==null)
                {
                    model =new channel();
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
                    bool isExists = channelHistory.Exists("channelNo = @0 and ip = @1", channelNo, ip);
                    if(!isExists)
                    {
                        model.count += 1;
                        model.Update();
                    }
                }
                channelHistory channelHistoryModel = new channelHistory();
                channelHistoryModel.channelNo = channelNo;
                channelHistoryModel.date_created = DateTime.Now;
                channelHistoryModel.url = url;
                channelHistoryModel.ip = ip;
                channelHistoryModel.Insert();

                PrintSuccessJson(true.ToString().ToLower());
            }catch(Exception ex){
                 PrintSuccessJson(false.ToString().ToLower());
            }
        }

        public void SelectChannelCount()
        {

        }
      
    }
}