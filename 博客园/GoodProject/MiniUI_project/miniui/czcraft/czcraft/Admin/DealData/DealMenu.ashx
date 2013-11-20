<%@ WebHandler Language="C#" Class="DealMenu" %>

using System;
using System.Web;
using System.Web.SessionState;
using czcraft.Model;
using czcraft.BLL;
using System.Data;
using System.Collections;
using System.Text;
public class DealMenu : IHttpHandler,IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        //(WEB_USER)context.Session["User"]
        WEB_USER user = new WEB_USER ();
        user.LOGNAME = "tianzhuanghu";
        user.PASSWORD = "tian815100";
        user.GROUP = new WEB_USERGROUP();
        user.GROUP.ID = 1;
        
     context.Response.Write(new WEB_USERGROUPBLL().GetMenuByJson(user));
    }
   
    public bool IsReusable {
        get {
            return false;
        }
    }

}