using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videoContext;
namespace Web.Admin
{
    public class BasePager : System.Web.UI.Page
    {

        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);

            if(UserInfo ==null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public userinfo UserInfo
        {
            get
            {
                userinfo userinfo = (userinfo)Session["userInfo"];
                return userinfo;
            }
        }

    }
}