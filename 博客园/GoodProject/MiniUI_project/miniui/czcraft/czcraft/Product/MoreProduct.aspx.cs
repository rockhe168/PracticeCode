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
using System.Collections.Generic;

public partial class Product_MoreProduct : System.Web.UI.Page
{
     //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    //输出的PagerHtml代码
    public string PagerHtml = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            VProductCraftTypeBLL bll = new VProductCraftTypeBLL();
            string Condition = Request["Condition"];
            //查询条件
            string strCondition = "";
            string title = "";
            //字符串注入检测
            if (!string.IsNullOrEmpty(Condition) && Tools.IsValidInput(ref Condition, true))
                //获取查询条件(并把显示的标题赋值给前台)
                strCondition = bll.ConfirmCondition(Condition, out title);
           
            //分页实现
            var pager = new Common.RupengPager();
            pager.UrlFormat = "MoreProduct.aspx?pagenum={n}&Condition=" + Condition;
            pager.PageSize = 10;
            pager.TryParseCurrentPageIndex(Request["pagenum"]);

            //分页数据读取
            IEnumerable<VProductCraftType> list = bll.ListByPagination("rank", pager.PageSize, pager.CurrentPageIndex, "1", strCondition);

            //获取总页数
            pager.TotalCount = bll.GetCount(strCondition);
            rpData.DataSource = list;
            rpData.DataBind();

            //标题显示
            ltTitle.Text = title;
            //渲染页码条HTML
            PagerHtml = pager.Render();
        }
        catch (Exception ex)
        {
            logger.Error("错误:", ex);
        }
    }
}
