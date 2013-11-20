using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Quartz;
using log4net;
using Lucene.Net.Store;
using Lucene.Net.Index;
using mshtml;
using System.Net;
using System.IO;
using System.Text;
using Lucene.Net.Documents;
using Lucene.Net.Analysis.PanGu;
using System.Web.Hosting;

namespace czcraft
{

    public class IndexJob : IJob
    {


        #region IJob 成员
        public void Execute(JobExecutionContext context)
        {
            // 1、对数据进行索引
            CreateSearchIndex createIndex = new CreateSearchIndex();
            createIndex.CreateIndex();


        }

        #endregion


    }
}
