using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videoContext;

namespace Web.Admin.Ajax
{
    using PetaPoco;

    /// <summary>
    /// ChannelHandler 的摘要说明
    /// </summary>
    public class ChannelHandler : BaseHandler
    {

        public void SyncData()
        {
            //查询最后一次同步时间
            channelhistoryarchivesync syncTime = channelhistoryarchivesync.SingleOrDefault("where id=1");

            if (syncTime == null)
            {
                syncTime = new channelhistoryarchivesync();
                syncTime.date = DateTime.Now.AddYears(-1);
                syncTime.date_created = DateTime.Now;
                syncTime.Insert();
            }

            DateTime syncDate = DateTime.Now.AddDays(-1).Date;

            //查询之前没有同步的数据
            Sql channelhistorySql = new Sql();
            channelhistorySql.Append("WHERE date_created >= @0", syncTime.date);
            channelhistorySql.Append("WHERE date_created < @0", syncDate);//前一天的

            channelhistory.Query(channelhistorySql);



            //同步的日期
            syncTime.date = syncDate;
            syncTime.Update();
        }
       
    }
}