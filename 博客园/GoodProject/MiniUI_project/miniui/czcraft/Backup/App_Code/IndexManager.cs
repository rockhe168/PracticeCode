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
using Quartz.Collection;
using System.Collections.Generic;
using System.Threading;

/// <summary>
///IndexManager 只能通过Instance实例化
/// </summary>
public class IndexManager
{
    //单例模式
    public readonly static IndexManager Instance = new IndexManager();
    /// <summary>
    /// 任务是否停止
    /// </summary>
    private bool IsStopped;
    /// <summary>
    /// 搜索类别枚举
    /// </summary>
    public enum JobSearchType
    {
        Product, News, Knowledge
    }
    /// <summary>
    /// 搜索类别
    /// </summary>
    public JobSearchType jobSearchType { get; set; }
    /// <summary>
    /// 索引任务集合列表
    /// </summary>
    private List<IndexJobItem> jobs = new List<IndexJobItem>();
    private static ILog log = LogManager.GetLogger(typeof(IndexManager));
    /// <summary>
    /// 私有构造函数所有的地方要对索引库进行修改都通过IndexManger,所以要单例,因为同时只能有一个在写索引库,所以由"消费者"来进行写,
    /// 别的地方要写索引库要请求"消费者"来进行AddAritcle
    /// </summary>
    private IndexManager()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 启动任务
    /// </summary>
    public void Start()
    {
        IsStopped = false;
        Thread thread = new Thread(ScanThread);
        //背景线程
        thread.IsBackground = true;
        thread.Start();

    }
    /// <summary>
    /// 停止任务
    /// </summary>
    public void Stop()
    {
        IsStopped = true;

    }
    /// <summary>
    /// 扫描线程
    /// </summary>
    private void ScanThread()
    {
        //如果停止,则不在无限循环
        while (!IsStopped)
        {
            //休息5秒钟,尽可能多的积累任务
            Thread.Sleep(5000);
            if (jobs.Count <= 0)
            {
                //如果没有任务,线程等待
                //log.Debug("没有任务,继续线程等待");
                Thread.Sleep(10 * 1000);
                continue;
            }
            //为什么每次循环都要打开,关闭索引库,因为关闭索引库以后才会把写入的数据提交到索引库中.也可以每次操作都"提交"(参考Lucene.net文档)
            //Enum.Parse(typeof(JobSearchType), jobSearchType).ToString()获取枚举名称
            string indexPath = System.IO.Path.Combine(HostingEnvironment.ApplicationPhysicalPath, ConfigurationManager.AppSettings["path"] + @"\" + Enum.Parse(typeof(JobSearchType), jobSearchType.ToString ()).ToString());
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());

            bool isUpdate = IndexReader.IndexExists(directory);
            log.Debug("索引库是否存在:" + isUpdate);
            if (isUpdate)
            {
                //如果索引目录被锁定(比如索引过程中程序异常退出),则首先解锁
                if (IndexWriter.IsLocked(directory))
                {
                    log.Debug("开始解锁索引库");
                    IndexWriter.Unlock(directory);
                    log.Debug("解锁库完成");
                }
            }
            //索引
            IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);

            //开始建立索引
            ProcessJob(writer);

            writer.Close();
            //不要忘了close
            directory.Close();
            log.Debug("全部索引完毕");
        }
    }
    /// <summary>
    /// 索引任务
    /// </summary>
    /// <param name="writer"></param>
    private void ProcessJob(IndexWriter writer)
    {
        foreach (var job in jobs.ToArray())
        {
            //删除任务
            jobs.Remove(job);
            //因为自己的网站,直接读取数据库,不用WebClient
            //为避免重复索引,所以先删除number=i的记录,再重新添加
            writer.DeleteDocuments(new Term("number", job.Id.ToString()));
            //索引
            Document document = new Document();
            string TypeName = "";
            //如果"添加" 任务则再添加
            if (job.ItemType == IndexJobItem.JobType.Add)
            {
                switch (jobSearchType)
                {
                    //索引工艺知识
                    case JobSearchType.Knowledge:
                        document = AddDocumentBycraftknowledge(job);
                        TypeName = "工艺知识";
                        break;
                    case JobSearchType.News:
                        document = AddDocumentByNews(job);
                        TypeName = "新闻";
                        break;
                    case JobSearchType.Product:
                        AddDocumentByProduct(job);
                        TypeName = "商品";
                        break;
                    default:
                        log.Debug("未设置JobSearchType属性,无法索引");
                        return;



                }

                writer.AddDocument(document);
                log.Debug("索引" + TypeName + ":" + job.Id + "完成!");



            }
        }
    }
    /// <summary>
    /// 给商品添加索引
    /// </summary>
    /// <param name="job"></param>
    /// <returns></returns>
    public Document AddDocumentByProduct(IndexJobItem job)
    {
        return null;
    
    }
    /// <summary>
    /// 给新闻添加索引
    /// </summary>
    /// <param name="job"></param>
    /// <returns></returns>
    public Document AddDocumentByNews(IndexJobItem job)
    {
        newsBLL bll = new newsBLL();
        //有可能刚添加就被删除了
        if (bll == null)
        {
            return null;

        }
        var craftknowledge = bll.Get(job.Id);
        string title = craftknowledge.Title;
        //这里要去除标签
        string body = Common.Tools.HtmlToTxt(craftknowledge.Content);
        Document document = new Document();
        document.Add(new Field("number", job.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
        document.Add(new Field("ArticleHtmlUrl", craftknowledge.ArticleHtmlUrl, Field.Store.YES, Field.Index.NOT_ANALYZED));
        //以下内容要索引
        document.Add(new Field("title", title, Field.Store.YES, Field.Index.ANALYZED));
        document.Add(new Field("body", body, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
        return document;
    }
    /// <summary>
    /// 给工艺知识添加索引
    /// </summary>
    /// <returns></returns>
    public Document AddDocumentBycraftknowledge(IndexJobItem job)
    {
        craftknowledgeBLL bll = new craftknowledgeBLL();
        //有可能刚添加就被删除了
        if (bll == null)
        {
            return null;

        }
        var craftknowledge = bll.Get(job.Id);
        string title = craftknowledge.Title;
        //这里要去除标签
        string body = Common.Tools.HtmlToTxt(craftknowledge.Content);
        Document document = new Document();
        document.Add(new Field("number", job.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
        document.Add(new Field("ArticleHtmlUrl", craftknowledge.ArticleHtmlUrl, Field.Store.YES, Field.Index.NOT_ANALYZED));
        //以下内容要索引
        document.Add(new Field("title", title, Field.Store.YES, Field.Index.ANALYZED));
        document.Add(new Field("body", body, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
        return document;
    }
    /// <summary>
    /// 添加任务
    /// </summary>
    /// <param name="Id">根据id</param>
    public void AddJob(int Id)
    {
        IndexJobItem job = new IndexJobItem();
        job.Id = Id;
        job.ItemType = IndexJobItem.JobType.Add;
        log.Debug(Id + "加入到任务列表中");
        //把任务加入任务列表
        jobs.Add(job);

    }
    /// <summary>
    /// 删除任务
    /// </summary>
    /// <param name="Id">根据Id</param>
    public void RemoveJob(int Id)
    {
        IndexJobItem job = new IndexJobItem();
        job.Id = Id;
        job.ItemType = IndexJobItem.JobType.Delete;
        log.Debug(Id + "加入删除任务列表");
        jobs.Add(job);
    }
    /// <summary>
    /// 实例化
    /// </summary>
    /// <returns></returns>
    public static IndexManager GetInstance(JobSearchType jobType)
    {
        //设置job的类别为
        Instance.jobSearchType = jobType;
         return Instance;
    }



}
