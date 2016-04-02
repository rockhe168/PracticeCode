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
            try
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

                DateTime syncDate = DateTime.Now.Date;

                //查询之前没有同步的数据
                Sql channelhistorySql = new Sql();
                channelhistorySql.Append(
                    "select channelNo,DATE_FORMAT(date_created,'%Y-%m-%d') as datestr,count(id) as visitcount")
                    .Append("from channelHistory")
                    .Append("WHERE date_created > @0", syncTime.date)
                    .Append("WHERE date_created <= @0", syncDate)
                    .Append("group by datestr,channelNo");

                IEnumerable<channelhistory> channelhistoryDayList = videoContextDB.GetInstance().Query<channelhistory>(channelhistorySql);

                foreach (var channelhistory in channelhistoryDayList)
                {
                    bool isExists = channelhistoryarchive.Exists(
                         "where channelNo=@0 and date=@1",
                         channelhistory.channelNo,
                         channelhistory.datestr);

                    if (!isExists)
                    {
                        channelhistoryarchive channelhistoryarchiveModel = new channelhistoryarchive();
                        channelhistoryarchiveModel.channelNo = channelhistory.channelNo;
                        channelhistoryarchiveModel.date = channelhistory.datestr;
                        channelhistoryarchiveModel.realcount = channelhistory.visitcount;
                        channelhistoryarchiveModel.date_created = DateTime.Now;
                        channelhistoryarchiveModel.paymentstate = false;
                        channelhistoryarchiveModel.Insert();
                    }
                }
                //同步的日期
                syncTime.date = syncDate;
                syncTime.Update();

                this.OutPutDialogString(ResponseStatus.Success, "同步成功", "ChannelInfoArchiveList", string.Empty, CallbackType.forward, string.Empty);
            }
            catch (Exception ex)
            {
                this.OutPutDialogString(ResponseStatus.Fail, "同步失败", "ChannelInfoArchiveList", string.Empty, CallbackType.forward, string.Empty);
            }
            
        }


        public void SaveInputMoney()
        {
            try
            {
                int id = Convert.ToInt32(Context.Request["id"]);

                decimal unitprice = Convert.ToDecimal(Context.Request["unitprice"]);
                long inputcount = Convert.ToInt32(Context.Request["inputcount"]);
                decimal inputmoney = Convert.ToDecimal(Context.Request["inputmoney"]);
                bool paymentstate = Convert.ToBoolean(Context.Request["paymentstate"]);

                channelhistoryarchive currentModel =  channelhistoryarchive.SingleOrDefault("where id=@0", id);

                if (currentModel != null)
                {
                    currentModel.unitprice = unitprice;
                    currentModel.inputcount = inputcount;
                    currentModel.inputmoney = inputmoney;
                    currentModel.paymentstate = paymentstate;
                    currentModel.Update();
                }
                else
                {
                    this.OutPutDialogString(ResponseStatus.Fail, "保存失败", "ChannelInfoArchiveList", string.Empty, CallbackType.closeCurrent, string.Empty);
                }


                this.OutPutDialogString(ResponseStatus.Success, "保存成功", "ChannelInfoArchiveList", string.Empty, CallbackType.closeCurrent, string.Empty);
            }
            catch (Exception ex)
            {
                this.OutPutDialogString(ResponseStatus.Fail, "保存失败", "ChannelInfoArchiveList", string.Empty, CallbackType.closeCurrent, string.Empty);
            }
        }


        public void UpdateBalance()
        {
            try
            {
                string ids = Context.Request["id"];


                string[] idStringList = ids.Split(',');

                List<int> idList = new List<int>();

                foreach (var s in idStringList)
                {
                    idList.Add(Convert.ToInt32(s));
                }


                var currentList = channelhistoryarchive.Fetch("where id in (@0)", idList);

                foreach (var currentModel in currentList)
                {
                    currentModel.paymentstate = true;
                    currentModel.Update();
                }

                this.OutPutDialogString(ResponseStatus.Success, "保存成功", "ChannelInfoArchiveList", string.Empty, CallbackType.forward, string.Empty);
            }
            catch (Exception ex)
            {
                this.OutPutDialogString(ResponseStatus.Fail, "保存失败", "ChannelInfoArchiveList", string.Empty, CallbackType.forward, string.Empty);
            }
        }
       
    }
}