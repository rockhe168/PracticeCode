using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using videoContext;

namespace Web.Admin.Programs.Channel
{
    public partial class ChannelInstallEdit : BasePager<channelinstallinfo>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DefaultObject = channelinstallinfo.SingleOrDefault("where id=@0", Request["id"]);
            }
        }
    }
}