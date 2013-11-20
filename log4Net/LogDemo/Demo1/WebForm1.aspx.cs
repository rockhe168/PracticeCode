using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo1
{
    public partial class WebForm1 : BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            throw new Exception("这里是异常信息、哥们2.");
        }
    }
}