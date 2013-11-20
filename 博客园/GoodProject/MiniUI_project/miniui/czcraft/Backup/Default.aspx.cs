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
using System.Web.Hosting;
using czcraft.BLL;
using czcraft.Model;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Common;

public partial class _Default : System.Web.UI.Page
{
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    protected void Page_Load(object sender, EventArgs e)
    {

      //  Response.Write(Path.GetDirectoryName("~/Default.aspx"));
    }
    /// <summary>
    /// 展示产品
    /// </summary>
    /// <param name="num"></param>
    protected void ShowProduct(int num)
    {
        //创建缓存工厂
        CacheStorage.ICacheStorage Cache = CacheStorage.CacheFactory.CreateCacheFactory();
        IEnumerable<product> ProductList = null;
        IEnumerable<product> cache = (IEnumerable<product>)Cache.Get("TopProduct");
        if (Tools.IsNullOrEmpty(cache))//如果缓存为空
        {

            //读取排名20的产品信息并转化为json格式

            ProductList = productBLL.GetTopProductForMainShow(num);
            //插入缓存(时间从配置文件中读取)
            Cache.Insert("TopProduct", ProductList, CacheManage.GetTimeConfig("DefaultContent"));
        }
        else
        {
            ProductList = cache;
        }
        //输出产品信息
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat(" <div id='List1'>");
        foreach (product item in ProductList)
        {
            sb.AppendFormat(" <div class='pic'><a href='{0}?ProductId={1}' target='_blank' class='pic_a'><img src='/Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=small&fileName={2}' alt='pic1' /></a></div>", URLManage.GetURL("~/Product/Product",""),item.Id,item.Picturepath);
        }
        sb.AppendFormat("</div>");
        Response.Write(sb.ToString());

    }

}
