using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lucene.Net.Store;
using System.IO;
using Lucene.Net.Index;
using Lucene.Net.Analysis.PanGu;
using System.Net;
using Lucene.Net.Documents;
using log4net;
using Lucene.Net.Search;
using System.Text;
using mshtml;
using PanGu;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using czcraft.BLL;
using czcraft.Model;
using System.Collections;
using System.Web.Hosting;
using System.Configuration;

namespace czcraft.BLL
{
    public partial class SearchBLL
    {
        private ILog logger = LogManager.GetLogger(typeof(SearchBLL));
        #region 搜索

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="kw">关键词</param>
        /// <param name="startIndex">开始页码</param>
        /// <param name="pageSize">每页显示个数</param>
        /// <param name="totalCount">总个数</param>
        /// <returns></returns>
        public IEnumerable<SearchResult> Search(string kw, int startIndex, int pageSize, out int totalCount, SearchSum.searchType Type)
        {
            string indexPath = System.IO.Path.Combine(HostingEnvironment.ApplicationPhysicalPath, ConfigurationManager.AppSettings["path"] + @"\" + Type.ToString());
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NoLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);
            PhraseQuery query = new PhraseQuery();

            //todo:把用户输入的关键词进行拆词

            foreach (string word in CommonHelper.SplitWord(kw))//先用空格，让用户去分词，空格分隔的就是词“计算机 专业”
            {
                query.Add(new Term("body", word));
            }

            query.SetSlop(50);
            TopScoreDocCollector collector = TopScoreDocCollector.create(1000, true);
            searcher.Search(query, null, collector);
            totalCount = collector.GetTotalHits();//返回总条数
            ScoreDoc[] docs = collector.TopDocs(startIndex, pageSize).scoreDocs;
            List<SearchResult> listResult = new List<SearchResult>();
            for (int i = 0; i < docs.Length; i++)
            {
                int docId = docs[i].doc;//取到文档的编号（主键，这个是Lucene .net分配的）
                //检索结果中只有文档的id，如果要取Document，则需要Doc再去取
                //降低内容占用
                Document doc = searcher.Doc(docId);//根据id找Document
                string number = doc.Get("number");
                string title = doc.Get("title");
                string body = doc.Get("body");
                string ArticleHtmlUrl = doc.Get("ArticleHtmlUrl");
                SearchResult result = new SearchResult();
                result.Number = number;
                result.Title = title;


                result.BodyPreview = Preview(body, kw);
                result.ArticleHtmlUrl = ArticleHtmlUrl;
                listResult.Add(result);
            }
            return listResult;
        } 
        #endregion
        #region 设置高亮显示
        /// <summary>
        /// 设置高亮显示
        /// </summary>
        /// <param name="body">文章主体</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        private static string Preview(string body, string keyword)
        {
            //创建HTMLFormatter,参数为高亮单词的前后缀 
            PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter =
                   new PanGu.HighLight.SimpleHTMLFormatter("<font color=\"red\">", "</font>");
            //创建 Highlighter ，输入HTMLFormatter 和 盘古分词对象Semgent 
            PanGu.HighLight.Highlighter highlighter =
                            new PanGu.HighLight.Highlighter(simpleHTMLFormatter,
                            new Segment());
            //设置每个摘要段的字符数 
            highlighter.FragmentSize = 100;
            //获取最匹配的摘要段 
            String bodyPreview = highlighter.GetBestFragment(keyword, body);
            return bodyPreview;
        } 
        #endregion
    }
}
