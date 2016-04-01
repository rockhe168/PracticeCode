using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using videoContext;

namespace Web.Admin
{
    using System.Collections;

    using PetaPoco;

    public partial class Login :System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string username = this.txtUserName.Value;
            string pass = this.txtPass.Value;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
            {
                this.errorMsg.Visible = true;
                //Response.End();
            }
            else
            {

                userinfo user = userinfo.SingleOrDefault("where username=@0 and pass=@1", username, pass);

                if (user == null || user.id == 0)
                {
                    this.errorMsg.Visible = true;
                }
                else
                {
                    Session[SystemConstant.CurrentUserInfo] = user;
                    Response.Redirect("Index.aspx");
                }
            }
        }
    }
}