using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using System.IO;
using PanGu;

namespace czcraft
{
    public class CommonHelper
    {
        /// <summary>
        /// 盘古分词
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>字符数组</returns>
        public static string[] SplitWord(string str)
        {
            List<string> list = new List<string>();
            Analyzer analyzer = new PanGuAnalyzer();
            TokenStream tokenStream = analyzer.TokenStream("", new StringReader(str));
            Lucene.Net.Analysis.Token token = null;
            while ((token = tokenStream.Next()) != null)
            {
                list.Add(token.TermText());
            }
            return list.ToArray();
        }
    }
}