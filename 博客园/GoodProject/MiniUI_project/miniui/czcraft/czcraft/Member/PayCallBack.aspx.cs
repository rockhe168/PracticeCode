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

public partial class Member_PayCallBack : System.Web.UI.Page
{
    /// <summary>
    /// 支付回调信息
    /// </summary>
    public PayCallBackInfo CallBackInfo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //支付回调
        Pay pay = new Pay();
       CallBackInfo =pay.CallBackPayInfo();
       if (CallBackInfo.ReturnCode == Pay.ReturnCode.ok)
       {
           CallBackInfo.Msg = "恭喜您,支付成功!我们会尽快发货!如果您收货就可以继续确认收货!";
       }
       else
           CallBackInfo.Msg = "对不起,支付失败!!失败信息 :"+CallBackInfo.Msg+"请联系支付宝有关人员!";
    }
}
