using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using System.IO;
using PanGu;

namespace czcraft.BLL
{
    public class CommonHelper
    {
        #region 盘古分词
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
        #endregion
        #region 得到字符串的MD5散列值
        /// <summary>
        /// 得到字符串的MD5散列值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String GetMD5(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        } 
        #endregion
    }
}