using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using videoContext;

namespace Web.Admin.Programs.Channel
{
    using PetaPoco;

    public partial class ChannelCountList : BasePager<channelinstallinfo>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //当前页
                if (Request["pageNum"] != null)
                {
                    DefaultListPagination.CurrentPageNo = int.Parse(Request["pageNum"]);
                }


                sql.Append(
                    "select channelinstallinfo.channelNo,channelinstallinfo.createdate,b.pvcounttemp ,c.installcounttemp ,d.ipcounttemp ,e.paymentsuccesscounttemp ,f.paymentcounttemp  from  channelinstallinfo ")
                    .Append(
                        "left join (select channelNo,createdate,count(*) as pvcounttemp from pvinfo group by channelNo,createdate) as b "
                        + "on channelinstallinfo.channelNo=b.channelNo and channelinstallinfo.createdate=b.createdate")
                    .Append(
                        "left join(select channelNo,createdate,count(*) as installcounttemp  from channelinstallhistoryinfo group by channelNo,createdate)as c "
                        + "on channelinstallinfo.channelNo=c.channelNo and channelinstallinfo.createdate=c.createdate")
                    .Append(
                        "left join(select channelNo,DATE_FORMAT(date_created,'%Y-%m-%d') as createdate,count(*) as ipcounttemp  from channelhistory group by channelNo,DATE_FORMAT(date_created,'%Y-%m-%d'))as d "
                        + "on channelinstallinfo.channelNo=d.channelNo and channelinstallinfo.createdate=d.createdate")
                    .Append(
                        "left join(select channelNo,DATE_FORMAT(date_created,'%Y-%m-%d') as createdate,count(*) as paymentsuccesscounttemp  from paymentinfo where ptype=2 group by channelNo,DATE_FORMAT(date_created,'%Y-%m-%d'))as e "
                        + "on channelinstallinfo.channelNo=e.channelNo and channelinstallinfo.createdate=e.createdate")
                    .Append(
                        "left join(select channelNo,DATE_FORMAT(date_created,'%Y-%m-%d') as createdate,count(*) as paymentcounttemp  from paymentinfo where ptype=1 group by channelNo,DATE_FORMAT(date_created,'%Y-%m-%d'))as f on "
                        + "channelinstallinfo.channelNo=f.channelNo and channelinstallinfo.createdate=f.createdate");

                   

                //出发日期
                if (Request["StartDate"] != null && !string.IsNullOrWhiteSpace(Request["StartDate"]))
                {
                    sql.Append("WHERE channelinstallinfo.createdate >= @0", Request["StartDate"]);
                }


                //结束日期
                if (Request["EndDate"] != null && !string.IsNullOrWhiteSpace(Request["EndDate"]))
                {
                    sql.Append("WHERE channelinstallinfo.createdate < @0", Convert.ToDateTime(Request["EndDate"]).AddDays(1));
                }

                //包Id
                if (Request["ChannelNo"] != null && !string.IsNullOrWhiteSpace(Request["ChannelNo"]))
                {
                    sql.Append("WHERE channelinstallinfo.channelNo = @0", Request["ChannelNo"]);
                }

                //结算状态
                if (Request["paymentstate"] != null && !string.IsNullOrWhiteSpace(Request["paymentstate"]))
                {
                    sql.Append("WHERE channelinstallinfo.paymentstate = @0", Convert.ToBoolean(Request["paymentstate"]));
                }
                sql.Append("group by channelinstallinfo.channelNo,channelinstallinfo.createdate");
                sql.Append("order by channelinstallinfo.date_created desc");

                PageData = videoContext.channelinstallinfo.Page(
                    DefaultListPagination.CurrentPageNo,
                    DefaultListPagination.PageSize,
                    sql);

            }
        }
    }
}