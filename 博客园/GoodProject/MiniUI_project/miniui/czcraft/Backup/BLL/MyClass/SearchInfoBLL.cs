using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
{
    public partial class SearchInfoBLL
    {
        #region 获取建议词汇
        /// <summary>
        /// 获取建议词汇
        /// </summary>
        /// <param name="kw"></param>
        /// <param name="searchType"></param>
        /// <returns></returns>
        public IEnumerable<SearchSum> GetSuggestion(string kw, SearchSum.searchType searchType)
        {
            return new SearchInfoDAL().GetSuggestion(kw, searchType);
        } 
        #endregion
        #region 获取热词
        /// <summary>
        /// 获取热词
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SearchSum> GetHotWords(SearchSum.searchType searchType)
        {
            //如果不加缓存，则每次页面打开都会执行一次“Sum”数据库查询
            //非常消耗资源
            //因为对所有人在一段时间内的热词都几乎一样
            //所以对查询结果进行缓存，这样无论多大的访问量
            //都只查询一次数据库

            //把缓存的处理放到BLL中
            //HttpRuntime.Cache

            //面试时关于缓存的应用的一个侃点
            //先到缓存中查，如果缓存中没有（或者过期）则直接管DAL要

            var data = HttpRuntime.Cache[searchType.ToString()];
            if (data == null)
            {
                IEnumerable<SearchSum> hotwords = new SearchInfoDAL().GetHotWords(searchType);
                //将数据放入缓存，key为"hotwords"，缓存30秒
                //第一个参数为缓存项的key，第二个参数为值
                //第四个参数为超时时间
                HttpRuntime.Cache.Insert(searchType.ToString(), hotwords, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
                return hotwords;
            }
            else
            {
                return (IEnumerable<SearchSum>)data;
            }
        } 
        #endregion


    }
}

