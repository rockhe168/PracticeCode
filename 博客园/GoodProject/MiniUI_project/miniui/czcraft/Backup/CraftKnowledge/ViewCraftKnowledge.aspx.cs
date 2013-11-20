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

public partial class CraftKnowledge_ViewCraftKnowledge : System.Web.UI.Page
{
    //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    protected craftknowledge CraftKnowledgeInfo = new craftknowledge();  //当前记录
    protected craftknowledge PreCraftKnowledge = new craftknowledge();//上一条记录
    protected craftknowledge NextCraftKnowledge = new craftknowledge();//下一条记录
    protected void Page_Load(object sender, EventArgs e)
    {
        string strId = Request["KnowledgeId"];
        int ID;
        //sql注入检测
        if (string.IsNullOrEmpty(strId) || !Tools.IsValidInput(ref strId, true)) 
        {
            Response.Redirect(string.Format("../Error.aspx?msg={0}&return={1}", "您访问的页面不存在!", Request.UrlReferrer));
        }
        else
        {
            try
            {
                int.TryParse(strId, out ID);
                craftknowledgeBLL bll = new craftknowledgeBLL();
                CraftKnowledgeInfo = bll.Get(ID);
                if (CraftKnowledgeInfo==null)  //做空值判断
                {
                    Response.Redirect(string.Format("../Error.aspx?msg={0}", "您访问的页面不存在!"));
                }
                //获取上一条记录和下一条记录
                bll.GetPreAndNextItem(CraftKnowledgeInfo.Time.Value, out PreCraftKnowledge, out NextCraftKnowledge);
                //判断静态页面是否存在
                if (Tools.IsNullOrEmpty(PreCraftKnowledge.ArticleHtmlUrl))
                {
                    PreCraftKnowledge.ArticleHtmlUrl = "#";
                }
                if (Tools.IsNullOrEmpty(NextCraftKnowledge.ArticleHtmlUrl))
                {
                    NextCraftKnowledge.ArticleHtmlUrl = "#";
                }
            }
            catch (Exception ex)
            {
                logger.Error("错误:", ex);
            }
        }
    }
}
