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
using System.Net;
using czcraft.Model;
using czcraft.BLL;
using System.Text;
public partial class CreateNewsHtml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        newsBLL artbll = new newsBLL();
        var arts = artbll.ListAll();
        foreach (var art in arts)
        {
            // WebClient client = new WebClient();
            string path = "~/ArtHtml/" + art.Id.Value + ".htm";
            // client.Encoding = Encoding.UTF8;
            string RequestPath = "/News/ViewNews.aspx?NewsId=" + art.Id;
            //通过WebClient向服务器发出get请求,返回html内容
            //client.DownloadFile(,
            //下载文件
            Common.DownFile.CreateStaticByWebClient(RequestPath, path);

        }
    }

}
