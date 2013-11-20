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
using System.Collections.Generic;
using czcraft.BLL;
using Common;

public partial class Member_MyCollection : System.Web.UI.Page//BasePage
{ //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    //输出的PagerHtml代码
    public string PagerHtml = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           Session["UserName"] = "tianweihu1";
            Session["UserId"] = "16";
            //获取会员id
            string MemberId = Session["UserId"].ToString () ;
            string CollcetType = Request["Type"];
            //今日收藏(默认)
            bool Type = false;
            if (Tools.IsNullOrEmpty(MemberId))
            {
              MemberId=  new memberBLL().GetMemberId(Session["UserName"].ToString ());
            }
            if (CollcetType=="true")
            {
                Type = true;
            }
            //分页实现
            var pager = new Common.RupengPager();
            pager.UrlFormat = "MyCollection.aspx?pagenum={n}&Type="+Type;
            pager.PageSize = 1;
            pager.TryParseCurrentPageIndex(Request["pagenum"]);

            //分页数据读取
            VMemberCollectProductBLL bll = new VMemberCollectProductBLL();

            IEnumerable<Collection> list = bll.GetCollectProductsByToday(Type,MemberId);   
            
            //用LINQ获取当前记录数
            IEnumerable<Collection> CurrentList = list.Skip(pager.PageSize * (pager.CurrentPageIndex-1)).Take(pager.PageSize); 
            //获取总页数
            pager.TotalCount = list.Count();
            rpTodayData.DataSource = CurrentList;
            rpTodayData.DataBind();

            //渲染页码条HTML
            PagerHtml = pager.Render();
        }
        catch (Exception ex)
        {
            logger.Error("错误:", ex);
        }
    }
}
