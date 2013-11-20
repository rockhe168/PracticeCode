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
using System.Text;

public partial class Product_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 输出图片信息
    /// </summary>
    public void ReponseProductPic()
    {
        StringBuilder sb = new StringBuilder();
        string ProductId = Request["ProductId"];
        if (Tools.IsValidInput(ref ProductId, true)&&!Tools.IsNullOrEmpty(ProductId))
        {
            IEnumerable<product_picturepath> list = new product_picturepathBLL().GetProductPic(ProductId);
            foreach (product_picturepath pic in list)
            {
                string MethodType="";
                if(pic.Id==-1)
                    MethodType="GetMainProductPic";
                else
                     MethodType="GetOtherProductPic";

                string PicSrc="../Admin/FileManage/GetImg.ashx?method="+MethodType+"&type=medium&fileName="+pic.Picturepath;
                sb.Append("<li><img class=\"curr_base\"  src=\"" + PicSrc + "\"/></li>");

            }
            Response.Write(sb.ToString());

        }
    }
}
