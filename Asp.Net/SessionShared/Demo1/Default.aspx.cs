using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSetSession_Click(object sender, EventArgs e)
        {
            Session["sharedKey"] = "会话共享值test，设置时间:" + DateTime.Now.ToString();
        }

        protected void btnGetSession_Click(object sender, EventArgs e)
        {
            this.lblSession.Text = Session["sharedKey"] == null ? "" : Session["sharedKey"].ToString();
        }
    }
}