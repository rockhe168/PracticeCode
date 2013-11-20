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
using czcraft;
using czcraft.BLL;
using Common;
using czcraft.Model;
using System.Collections.Generic;

public partial class Search_SearchKnowledge : System.Web.UI.Page
{
    //分页控件
    public string PageHtml { get;private set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载热词
        repeaterHotWords.DataSource = new SearchInfoBLL().GetHotWords(SearchSum.searchType.Knowledge);
        repeaterHotWords.DataBind();

        //如果kw为空，则是第一次进入界面
        string kw = Request["kw"]; 

        if (!Tools.IsValidInput(ref kw,true)||string.IsNullOrEmpty(kw))
        {
            return;
        }
        //把搜索记录加入数据库
        SearchInfo kwLog = new SearchInfo();
        kwLog.KeyWord = kw;
        kwLog.DateTime = DateTime.Now;
        kwLog.Ip = Request.UserHostAddress;
        kwLog.SearchType = SearchSum.searchType.Knowledge.GetHashCode().ToString ();
        new SearchInfoBLL().AddNew(kwLog);

        var pager =new Common.RupengPager();
        pager.UrlFormat = "SearchKnowledge.aspx?pagenum={n}&kw=" + Server.UrlEncode(kw);
        pager.PageSize = 10;
        //解析当前页面
        pager.TryParseCurrentPageIndex(Request["pagenum"]);
        int startRowIndex = (pager.CurrentPageIndex - 1) * pager.PageSize;

        int totalCount;
        IEnumerable<SearchResult> result = new SearchBLL().Search(kw, startRowIndex, 10, out totalCount, SearchSum.searchType.Knowledge);
        pager.TotalCount = totalCount;
        PageHtml = pager.Render();//渲染页码条HTML

        repeaterResult.DataSource = result;
        repeaterResult.DataBind();            

    }
}
