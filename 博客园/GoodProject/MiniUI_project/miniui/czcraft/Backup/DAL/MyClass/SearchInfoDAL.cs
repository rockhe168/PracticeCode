using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace czcraft.DAL
{
   public partial class SearchInfoDAL
    {
        #region 建议搜索数据获取
        /// <summary>
        /// 建议搜索数据获取
        /// </summary>
        /// <param name="kw">关键字</param>
        /// <param name="Type">类别</param>
        /// <returns></returns>
        public IEnumerable<SearchSum> GetSuggestion(string kw, SearchSum.searchType Type)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(@"select top 5 KeyWord,Count(*) as SearchCount,SearchType from SearchInfo and SearchType=@SeachType
where datediff(day,[DateTime],getdate())<7 and KeyWord like @kw
group by KeyWord
order by Count(*) desc", (DbParameter)new SqlParameter("@kw", "%" + kw + "%"), (DbParameter)new SqlParameter("SeachType", Type.GetHashCode()));
            List<SearchSum> list = new List<SearchSum>();
            foreach (DataRow datarow in dt.Rows)
            {
                SearchSum ss = new SearchSum();
                ss.KeyWord = Convert.ToString(datarow["KeyWord"]);
                ss.Count = Convert.ToInt32(datarow["SearchCount"]);
                // ss.SearchType =ConvertToSearchType(datarow["SearchType"].ToString ());
                list.Add(ss);
            }
            return
                list;
        } 
        #endregion
        #region 转化为搜索类型
        /// <summary>
        /// 转化为搜索类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public SearchSum.searchType ConvertToSearchType(string obj)
        {
            SearchSum.searchType type = new SearchSum.searchType();
            switch (obj)
            {
                case "0":
                    type = SearchSum.searchType.News;
                    break;
                case "1":
                    type = SearchSum.searchType.Product;
                    break;
                case "2":
                    type = SearchSum.searchType.Knowledge;
                    break;
                default:
                    return SearchSum.searchType.Knowledge;

            }
            return type;
        } 
        #endregion
        #region 根据类别搜索热词
        /// <summary>
        /// 根据类别搜索热词
        /// </summary>
        /// <param name="Type">类别</param>
        /// <returns></returns>
        public IEnumerable<SearchSum> GetHotWords(SearchSum.searchType Type)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(@"select top 5 KeyWord,Count(*) as SearchCount from SearchInfo
where datediff(day,[DateTime],getdate())<7 and SearchType=@SeachType
group by KeyWord
order by Count(*) desc", (DbParameter)new SqlParameter("SeachType", Type.GetHashCode()));
            List<SearchSum> list = new List<SearchSum>();
            foreach (DataRow datarow in dt.Rows)
            {
                SearchSum ss = new SearchSum();
                ss.KeyWord = Convert.ToString(datarow["KeyWord"]);
                ss.Count = Convert.ToInt32(datarow["SearchCount"]);
                //ss.SearchType = ConvertToSearchType(datarow["SearchType"].ToString());
                list.Add(ss);
            }
            return list;
        } 
        #endregion
    }
}
