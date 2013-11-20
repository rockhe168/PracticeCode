using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Package.Framework2.Logging;

namespace CtripLogDemo
{
    using System.Reflection;

    public partial class Demo1 : System.Web.UI.Page
    {
        protected static readonly ILog Loger = LogManager.GetLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
           {
               this.TestFalut();
           }
        }



        void TestFalut()
        {
            int s= 0;
            try
            {
                int a = 8 / s;
            }
            catch (Exception ex)
            {
                Loger.Fault("请求天气预报_" + MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}