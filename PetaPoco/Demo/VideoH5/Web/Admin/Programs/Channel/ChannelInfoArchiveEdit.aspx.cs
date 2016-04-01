using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Admin.Programs.Channel
{
    using videoContext;

    public partial class ChannelInfoArchiveEdit : BasePager<channelhistoryarchive>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DefaultObject = channelhistoryarchive.SingleOrDefault("where id=@0", Request["id"]);
            }
        }
    }
}