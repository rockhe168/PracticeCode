using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using czcraft.Model;
using czcraft.BLL;
using Common;

public partial class News_ViewNews : System.Web.UI.Page
{
    //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    protected news NewInfo = new news();  //当前记录
    protected news PreNews = new news();//上一条记录
    protected news NextNews = new news();//下一条记录
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strId = Request["NewsId"];
            int ID;

            if (string.IsNullOrEmpty(strId) || !Tools.IsValidInput(ref strId, true)) //如果页面空
            {
                Response.Redirect(string.Format("../Error.aspx?msg={0}&return={1}", "您访问的页面不存在!", Request.UrlReferrer));
            }
            else
            {
                int.TryParse(strId, out ID);
                NewInfo = new newsBLL().Get(ID);
                if (NewInfo == null)
                {
                    Response.Redirect(string.Format("../Error.aspx?msg={0}", "您访问的页面不存在!"));
                }
                //获取上一条记录和下一条记录
                new newsBLL().GetPreAndNextItem(NewInfo.Time.Value, out PreNews, out NextNews);
                //判断静态页面是否存在
                if (Tools.IsNullOrEmpty(PreNews.ArticleHtmlUrl))
                {
                    PreNews.ArticleHtmlUrl = "#";
                }
                if (Tools.IsNullOrEmpty(NextNews.ArticleHtmlUrl))
                {
                    NextNews.ArticleHtmlUrl = "#";
                }
                
                

            }
        }
        catch (Exception ex)
        {
            logger.Error("错误:", ex);
        }
    }

}
