using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using czcraft.Model;
using System.Data.Common;
using System.Data.SqlClient;

namespace czcraft.DAL
{
   public partial class newsDAL
    {
        #region 根据时间获取上一条记录和下一条记录
        /// <summary>
        /// 根据时间获取上一条记录和下一条记录
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns>DataSet值</returns>
        public DataSet GetPreAndNextItem(DateTime dt)
        {
            string sql = string.Format("select top 1 * from news where [Time] > '{0}' order by Time desc; select top 1 * from news where [Time] < '{0}' order by Time desc", dt);

            return SqlHelper.GetDataSet(sql);
        } 
        #endregion
        #region  获取前n条新闻
        /// <summary>
        /// 获取前n条新闻
        /// </summary>
        /// <param name="TopNum">前n</param>
        /// <returns></returns>
        public IEnumerable<news> GetTopNews(int TopNum)
        {
            string sql = "select top (" + TopNum + ") * from news order by Time desc";
            List<news> list = new List<news>();
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;
        } 
        #endregion
        #region 更新新闻静态页面
        /// <summary>
        /// 更新新闻静态页面
        /// </summary>
        /// <param name="Info">新闻</param>
        /// <returns></returns>
        public bool UpdateNewsArticle(news Info)
        {
            string sql = "update news set ArticleHtmlUrl=@ArticleHtmlUrl where Id=@Id";
            return SqlHelper.ExecuteNonQuery(sql, (DbParameter)new SqlParameter("ArticleHtmlUrl", Info.ArticleHtmlUrl), (DbParameter)new SqlParameter("Id", Info.Id));
        } 
        #endregion
    }
}
