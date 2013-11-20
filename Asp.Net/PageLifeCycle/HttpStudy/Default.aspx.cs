using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Response.Write("Page_PreInit<br/>");
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        Response.Write("Page_Init<br/>");

    }
    protected void Page_InitComplete(object sender, EventArgs e)
    {
        Response.Write("Page_InitComplete<br/>");

    }
    protected void Page_PreLoad(object sender, EventArgs e)
    {
        Response.Write("Page_PreLoad<br/>");

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("Page_Load<br/>");

    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        Response.Write("Page_LoadComplete<br/>");

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        Response.Write("Page_PreRender<br/>");

    }
    protected void Page_SaveStateComplete(object sender, EventArgs e)
    {
        Response.Write("Page_SaveStateComplete<br/>");

    }

   
    protected void Page_Unload(object sender, EventArgs e)
    {
        int i = 0;
        i++;//这行代码是用来设置断点的，为什么不用Response.Write？你说呢？

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "ControlEvent";
        Response.Write("Button事件触发！<br/>");
    }
}


