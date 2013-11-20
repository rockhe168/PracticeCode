using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_PreInit(object sender,EventArgs e)
    {
        Response.Write("Page_PreInit---------->默认在这个事件里加载一些个性化信息或主题，主要可以做一些动态服务器控件的生成、.... <br>");
    }

    protected void Page_Init(object sender,EventArgs e)
    {
        Response.Write("Page_Init------->可以设置控件的属性值.<br>");
    }

    protected  void Page_InitComplete(object sender,EventArgs e)
    {
        Response.Write("Page_InitComplete-------->处理页面控件已经全部初始化完毕.<br>");
    }

    protected void Page_PreLoad(object sender,EventArgs e)
    {
       Response.Write("Page_PreLoad----------->如果需要在Load之前进行页面与控件进行处理，请用此事件进行....<br>");  
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       Response.Write("Page_Load <br>");
    }

    protected void Page_LoadComplete(object sender,EventArgs e)
    {
        Response.Write("Page_LoadComplete----><br>");
    }

    protected void Page_PreRender(object sender,EventArgs e)
    {
        Response.Write("Page_PreRender-----><br>");
    }

    protected void Page_SaveStateComplete(object sender,EventArgs e)
    {
        Response.Write("Page_SaveStateComplete----><br>");
    }

    protected override void Render(HtmlTextWriter writer)
    {
        base.Render(writer);

        Response.Write("Page_Render----><br>");
    }

    protected void Page_Unload(object sender,EventArgs e)
    {
        //Response.Write("Page_Unload-----><br>");
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("我是Button,My Event triggered....<br> ");
    }
}