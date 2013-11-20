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
using czcraft.Model;
using System.Collections.Generic;
using System.Text;
using Common;
public partial class Product_NongeneticProduct : System.Web.UI.Page
{ //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    /// <summary>
    /// 输出非遗作品信息
    /// </summary>
    public void ResponseNongeneticProduct()
    {
        //创建缓存工厂
        CacheStorage.ICacheStorage Cache = CacheStorage.CacheFactory.CreateCacheFactory();
        //缓存
        DataTable dtCache = (DataTable)Cache.Get("NongeneticProductType");
        //获取作品信息
        DataTable dtProduct = new DataTable();
        if (dtCache==null)//如果缓存为空
        {
         
            dtProduct = new VProductCraftTypeBLL().ListAllByNongeneticToDatable() ;
            //插入缓存(时间从配置文件中读取)
            Cache.Insert("NongeneticProductType", dtProduct, CacheManage.GetTimeConfig("Nongenetic"));
        
        }
        else
        {
            dtProduct = dtCache;
        }


        //如果不存在作品,则不输出
        if (dtProduct.Rows.Count == 0)
            return;
        StringBuilder sb = new StringBuilder();
        //Num代表列表的循环变量,CurrentNum代表当前TypeId中当前的计数
        int Num = 0, CurrentNum = 1;
        //先输出第一个类别

        sb.AppendFormat("<div class='show_title'><h4>{0}</h4>", dtProduct.Rows[0]["TypeName"].ToString());
        sb.AppendFormat(" <p class='hide'> <a href='"+URLManage.GetURL("~/Product/SearchProduct","")+"?FId={0}&Condition=Nongenetic'>更多</a></p></div>", dtProduct.Rows[0]["FId"].ToString());
        sb.AppendFormat("<div class='show_t'><ul id='IsRecomment'>");
        for (; Num < dtProduct.Rows.Count; Num++, CurrentNum++)
        {
            //该类别下总的产品个数
            int TotalNum = Convert.ToInt32(dtProduct.Rows[Num]["total"]);
            //如果该类别下还存在产品
            if (CurrentNum <= TotalNum)
            {

                sb.AppendFormat(" <li><a href='" + URLManage.GetURL("~/Product/Product", "") + "?ProductId={0}' class='c_pic_a'>", dtProduct.Rows[Num]["Id"].ToString());
                sb.AppendFormat("<img src='../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName={0}' alt='{1}' title='{1}' /></a> <a href='" + URLManage.GetURL("~/Product/Product", "") + "?ProductId={2}' class='a_title'>{1}<br /><span class='rad2'>￥{3}</span></a></li>", dtProduct.Rows[Num]["Picturepath"].ToString(), dtProduct.Rows[Num]["Name"].ToString(), dtProduct.Rows[Num]["Id"].ToString(), dtProduct.Rows[Num]["Lsprice"].ToString());

            }
            else
            {
                sb.AppendFormat("</ul></div><div class='show_b'></div>");
                //下一个类别开始
                sb.AppendFormat("<div class='show_title'><h4>{0}</h4>", dtProduct.Rows[Num]["TypeName"].ToString());
                sb.AppendFormat(" <p class='hide'> <a href='" + URLManage.GetURL("~/Product/SearchProduct", "") + "?FId={0}&Condition=Nongenetic'>更多</a></p></div>", dtProduct.Rows[Num]["FId"].ToString());
                sb.AppendFormat("<div class='show_t'><ul id='IsRecomment'>");
                //将下一个类别的计数置为1
                CurrentNum = 1;
            }
        }
        sb.AppendFormat("</ul></div><div class='show_b'></div>");
        Response.Write(sb.ToString());
    }
}
