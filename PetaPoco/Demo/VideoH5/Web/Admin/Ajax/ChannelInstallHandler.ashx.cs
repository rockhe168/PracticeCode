using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videoContext;

namespace Web.Admin.Ajax
{
    using PetaPoco;

    /// <summary>
    /// ChannelInstallHandler 的摘要说明
    /// </summary>
    public class ChannelInstallHandler :  BaseHandler
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


                //1,同步IP流量
                //查询之前没有同步的数据
                Sql channelipSql = new Sql();
                channelipSql.Append(
                    "select channelNo,DATE_FORMAT(date_created,'%Y-%m-%d') as datestr,count(id) as visitcount")
                    .Append("from channelHistory")
                    .Append("WHERE date_created > @0", syncTime.date)
                    .Append("WHERE date_created <= @0", syncDate)
                    .Append("group by datestr,channelNo");

                IEnumerable<channelhistory> channelipDayList = videoContextDB.GetInstance().Query<channelhistory>(channelipSql);
                //2,同步安装量
                Sql channelinstallSql = new Sql();
                channelinstallSql.Append(
                    "select channelNo,createdate,count(id) as installcount")
                    .Append("from channelinstallhistoryinfo")
                    .Append("WHERE date_created > @0", syncTime.date)
                    .Append("WHERE date_created <= @0", syncDate)
                    .Append("group by channelNo,createdate");

                IEnumerable<channelinstallhistoryinfo> channelinstallList = videoContextDB.GetInstance().Query<channelinstallhistoryinfo>(channelinstallSql);

                //3,同步Pv
                Sql channelpvSql = new Sql();
                channelpvSql.Append(
                    "select channelNo,createdate,count(id) as pvcount")
                    .Append("from pvinfo")
                    .Append("WHERE date_created > @0", syncTime.date)
                    .Append("WHERE date_created <= @0", syncDate)
                    .Append("group by channelNo,createdate");

                IEnumerable<pvinfo> channelpvList = videoContextDB.GetInstance().Query<pvinfo>(channelpvSql);

                //4，同步支付成功
                Sql channelpaymentsuccessSql = new Sql();
                channelpaymentsuccessSql.Append(
                    "select channelNo,createdate,count(id) as paymentcount")
                    .Append("from paymentinfo")
                    .Append("WHERE date_created > @0", syncTime.date)
                    .Append("WHERE date_created <= @0 and ptype=2", syncDate)
                    .Append("group by channelNo,createdate");
                IEnumerable<paymentinfo> channelpaymentsuccessList = videoContextDB.GetInstance().Query<paymentinfo>(channelpaymentsuccessSql); 
            
                //5,同步支付请求数
                Sql channelpaymentSql = new Sql();
                channelpaymentSql.Append(
                    "select channelNo,createdate,count(id) as paymentcount")
                    .Append("from paymentinfo")
                    .Append("WHERE date_created > @0", syncTime.date)
                    .Append("WHERE date_created <= @0 and ptype=1", syncDate)
                    .Append("group by channelNo,createdate");
                IEnumerable<paymentinfo> channelpaymentList = videoContextDB.GetInstance().Query<paymentinfo>(channelpaymentSql);      

                //相差同步时间差
                TimeSpan sp = syncDate.Subtract(syncTime.date);

                int days = sp.Days;

                for (int i = 0; i < days; i++)
                {
                    
                }
               



                this.OutPutDialogString(ResponseStatus.Success, "同步成功", "ChannelCountList", string.Empty, CallbackType.forward, string.Empty);
            }
            catch (Exception ex)
            {
                this.OutPutDialogString(ResponseStatus.Fail, "同步失败", "ChannelCountList", string.Empty, CallbackType.forward, string.Empty);
            }

        }
        public void SaveInputMoney()
        {
            try
            {
                int id = Convert.ToInt32(Context.Request["id"]);

                decimal unitprice = Convert.ToDecimal(Context.Request["unitprice"]);
                long inputcount = Convert.ToInt32(Context.Request["inputinstallcount"]);
                decimal inputmoney = Convert.ToDecimal(Context.Request["inputmoney"]);
                bool paymentstate = Convert.ToBoolean(Context.Request["paymentstate"]);

                channelinstallinfo currentModel = channelinstallinfo.SingleOrDefault("where id=@0", id);

                if (currentModel != null)
                {
                    currentModel.unitprice = unitprice;
                    currentModel.inputinstallcount = inputcount;
                    currentModel.inputmoney = inputmoney;
                    currentModel.paymentstate = paymentstate;
                    currentModel.Update();
                }
                else
                {
                    this.OutPutDialogString(ResponseStatus.Fail, "保存失败", "ChannelInstallList", string.Empty, CallbackType.closeCurrent, string.Empty);
                }


                this.OutPutDialogString(ResponseStatus.Success, "保存成功", "ChannelInstallList", string.Empty, CallbackType.closeCurrent, string.Empty);
            }
            catch (Exception ex)
            {
                this.OutPutDialogString(ResponseStatus.Fail, "保存失败", "ChannelInstallList", string.Empty, CallbackType.closeCurrent, string.Empty);
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


                var currentList = channelinstallinfo.Fetch("where id in (@0)", idList);

                foreach (var currentModel in currentList)
                {
                    currentModel.paymentstate = true;
                    currentModel.Update();
                }

                this.OutPutDialogString(ResponseStatus.Success, "保存成功", "ChannelInstallList", string.Empty, CallbackType.forward, string.Empty);
            }
            catch (Exception ex)
            {
                this.OutPutDialogString(ResponseStatus.Fail, "保存失败", "ChannelInstallList", string.Empty, CallbackType.forward, string.Empty);
            }
        }
    }
}