using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using videoContext;

namespace Web.Admin.Programs.Channel
{
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

                //出发日期
                if (Request["StartDate"] != null && !string.IsNullOrWhiteSpace(Request["StartDate"]))
                {
                    sql.Append("WHERE createdate >= @0", Request["StartDate"]);
                }


                //结束日期
                if (Request["EndDate"] != null && !string.IsNullOrWhiteSpace(Request["EndDate"]))
                {
                    sql.Append("WHERE createdate < @0", Convert.ToDateTime(Request["EndDate"]).AddDays(1));
                }

                //包Id
                if (Request["ChannelNo"] != null && !string.IsNullOrWhiteSpace(Request["ChannelNo"]))
                {
                    sql.Append("WHERE channelNo = @0", Request["ChannelNo"]);
                }

                //结算状态
                if (Request["paymentstate"] != null && !string.IsNullOrWhiteSpace(Request["paymentstate"]))
                {
                    sql.Append("WHERE paymentstate = @0", Convert.ToBoolean(Request["paymentstate"]));
                }
                sql.Append("order by date_created desc");

                PageData = videoContext.channelinstallinfo.Page(
                    DefaultListPagination.CurrentPageNo,
                    DefaultListPagination.PageSize,
                    sql);

            }
        }
    }
}