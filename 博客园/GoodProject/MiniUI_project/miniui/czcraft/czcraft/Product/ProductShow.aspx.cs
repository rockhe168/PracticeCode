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
using Common;
public partial class Product_ProductShow : System.Web.UI.Page
{
    //  //记录日志
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
             //缓存
        List<VProductCraftType> listIsRecomment = (List<VProductCraftType>)Cache["listIsRecomment"];
            List<VProductCraftType> listIsexcellent=(List<VProductCraftType>)Cache["listIsexcellent"];
            if (listIsRecomment == null || listIsexcellent == null)//如果缓存为空
            {
                //读取配置文件缓存信息
                string path = Server.MapPath(@"~/Admin/ConfigManage/config.xml");

                int Day = Convert.ToInt32(XMlHelper.Read(path, "/Root/Cache/ProductShow/Day", ""));
                int Hour = Convert.ToInt32(XMlHelper.Read(path, "/Root/Cache/ProductShow/Hour", ""));
                //业务数据读取
                VProductCraftTypeBLL bll = new VProductCraftTypeBLL();
                listIsRecomment = new List<VProductCraftType>();
                listIsexcellent = new List<VProductCraftType>();
                bll.ListTopProductIsRecommentAndIsexcellent(out listIsRecomment, out listIsexcellent);
                TimeSpan TimeOut = new TimeSpan(Day, Hour, 0, 0, 0);//设置缓存时间为2个小时
                HttpContext.Current.Cache.Insert("listIsRecomment", listIsRecomment, null, DateTime.MaxValue, TimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null); //插入数据缓存
                HttpContext.Current.Cache.Insert("listIsexcellent", listIsexcellent, null, DateTime.MaxValue, TimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null); //插入数据缓存

            }
           
            //绑定数据
            rpIsexcellentData.DataSource = listIsexcellent;
            rpIsexcellentData.DataBind();
            rpRecommentData.DataSource = listIsRecomment;
            rpRecommentData.DataBind();

        }
        catch (Exception ex)
        {
            logger.Error("错误:", ex);
        }
    }
}
