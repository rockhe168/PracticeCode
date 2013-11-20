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
using Common;
using System.Collections.Generic;
using czcraft.Model;
using czcraft.BLL;
public partial class News_NewsList : System.Web.UI.Page
{
    //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    //输出的PagerHtml代码
    public string PagerHtml = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string TypeId = Request["TypeId"];
            //查询条件
            string strCondition = "";
            //字符串注入检测
            if (!string.IsNullOrEmpty(TypeId) && Tools.IsValidInput(ref TypeId, true))
                strCondition = "TypeId=" + TypeId;

            //分页实现
            var pager = new Common.RupengPager();
            pager.UrlFormat = "NewsList.aspx?pagenum={n}&TypeId=" + TypeId;
            pager.PageSize = 10;
            pager.TryParseCurrentPageIndex(Request["pagenum"]);

            //分页数据读取
            newsBLL bll = new newsBLL();
            DataTable dt = bll.ListByPaginationForView("Time", pager.PageSize, pager.CurrentPageIndex, "1", strCondition);

            //获取总页数
            pager.TotalCount = bll.GetVNewsListCount(strCondition);
            rpData.DataSource = dt;
            rpData.DataBind();

            //渲染页码条HTML
            PagerHtml = pager.Render();
        }
        catch (Exception ex)
        {
            logger.Error("错误:", ex);
        }
    }
}
