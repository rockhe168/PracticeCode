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
using log4net;
using System.Web.Hosting;
using Lucene.Net.Store;
using Lucene.Net.Index;
using System.IO;
using Lucene.Net.Analysis.PanGu;
using System.Net;
using czcraft.BLL;
using mshtml;
using czcraft;
using System.Text;
using Lucene.Net.Documents;
using System.Text.RegularExpressions;
/// <summary>
///CreateSearchIndex 的摘要说明
/// </summary>
public class CreateSearchIndex
{
    private  ILog logger = LogManager.GetLogger(typeof(CreateSearchIndex));

    public CreateSearchIndex()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 创建索引
    /// </summary>
    public  void CreateIndex()
    {
        string indexPath = System.IO.Path.Combine(HostingEnvironment.ApplicationPhysicalPath, ConfigurationManager.AppSettings["path"]);
        FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
        bool isUpdate = IndexReader.IndexExists(directory);
        if (isUpdate)
        {
            //如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁
            if (IndexWriter.IsLocked(directory))
            {
                IndexWriter.Unlock(directory);
            }
        }
        IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);
        WebClient wc = new WebClient();


        wc.Encoding = Encoding.UTF8;//否则下载的是乱码
        int MaxCraftKnowledgeNumber = new craftknowledgeBLL().GetMaxId();
        //string strSql = "";
        for (int i = 1; i < MaxCraftKnowledgeNumber; i++)
        {
            try   //一般情况下不需要catch,不过这个是特殊情况,
            {
              string url=  HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/czcraft" + "/CraftKnowledge/ViewCraftKnowledge.aspx?KnowledgeId=" + i; //注意中间的参数是为了本地测试使用
             
                //string url = "http://localhost:4834/czcraft/CraftKnowledge/ViewCraftKnowledge.aspx?KnowledgeId=" + i; //这个动态采集的网页http://localhost:3098/czcraft/Search/CreateIndex.aspx


                string txt = wc.DownloadString(url);
                HTMLDocumentClass doc = new HTMLDocumentClass();
                doc.designMode = "on";//不让解析引擎去尝试运行JavaScript
                doc.IHTMLDocument2_write(txt);
                doc.close();
                if (doc.title.Contains("出错了")) //页面无法访问
                {
                    continue;
                }
               
                    Document document = new Document();
                    writer.DeleteDocuments(new Term("KnowledgeId", i.ToString()));
                    //只有需要全文检索的字段才ANALYZED
                    document.Add(new Field("KnowledgeId", i.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                   
                document.Add(new Field("url", url, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
                  
                    document.Add(new Field("title", doc.getElementById("InfoTitle").innerText, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS)); //文章标题

                    document.Add(new Field("body", doc.getElementById("craft").innerText, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS)); //文章主要内容
                    writer.AddDocument(document);
                    logger.Debug("索引完毕" + i + "!");
              
            }
            catch (WebException ex) //只捕捉这种异常,
            {
                logger.Error("索引异常:", ex);
            }
        }
        writer.Close();
        directory.Close();//不要忘了Close，否则索引结果搜不到

    }
}
