using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class HtmlEncode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string TestString = "This is a <Test String>.";
                string EncodedString = Server.HtmlEncode(TestString);

                Response.Write("Encoded End:"+EncodedString);
            }

        }
    }
}