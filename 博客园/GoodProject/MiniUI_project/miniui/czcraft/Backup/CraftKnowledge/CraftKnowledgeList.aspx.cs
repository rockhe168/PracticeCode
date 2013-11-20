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
using czcraft.BLL;
using Common;

public partial class CraftKnowledge_CraftKnowledgeList : System.Web.UI.Page
{
    //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public string PagerHtml = "";//输出的PagerHtml代码
    protected void Page_Load(object sender, EventArgs e)
    {
        //查询条件
        string FId = Request["FId"];
        string strCondition = "";

        //sql注入检测
        if (!string.IsNullOrEmpty(FId) && Tools.IsValidInput(ref FId, true))
            strCondition = " FId like '%" + FId + "%'";
        try
        {
            //分页控件配置
            var pager = new Common.RupengPager();
            pager.UrlFormat = "CraftKnowledgeList.aspx?pagenum={n}&FId=" + FId;
            pager.PageSize = 10;
            pager.TryParseCurrentPageIndex(Request["pagenum"]);

            //分页数据读取
            craftknowledgeBLL bll = new craftknowledgeBLL();
            DataTable dt = bll.ListByPaginationForView("Time", pager.PageSize, pager.CurrentPageIndex, "1", strCondition);

            //获取总页数
            pager.TotalCount = bll.GetVCraftKnowledgeListCount(strCondition);
            rpData.DataSource = dt;
            rpData.DataBind();

            //渲染页码条HTML
            PagerHtml = pager.Render();
        }
        catch (Exception ex)
        {
            logger.Error("出错:", ex);
        }
    }
}
