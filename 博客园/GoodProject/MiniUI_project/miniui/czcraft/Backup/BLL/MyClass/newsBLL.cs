using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using System.IO;
using Newtonsoft.Json;
using czcraft.DAL;
using System.Data;

namespace czcraft.BLL
{
   public partial class newsBLL
    {
        #region 专门生成为MiniUi生成json数据(List->json)
        /// <summary>
        /// 专门生成为MiniUi生成json数据(List->json)
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="list">实现了Ilist接口的list</param>
        /// <param name="total">记录总数</param>
        /// <param name="paramMaxMin">这里放排序的参数例如,string para="\"maxAge\":37,\"avgAge\":27,\"minAge\":24"</param>
        /// <returns></returns>
        public static string MiniUiListToJson(IEnumerable<news> news, int total, string paramMaxMinAvg)
        {

            StringBuilder Json = new StringBuilder();
            StringWriter sw = new StringWriter(Json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("total");
                jsonWriter.WriteValue(total);
                jsonWriter.WritePropertyName("data");
                jsonWriter.WriteStartArray();
                foreach (news Info in news)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Id");
                    jsonWriter.WriteValue(Info.Id);
                    jsonWriter.WritePropertyName("Title");
                    jsonWriter.WriteValue(Info.Title);
                    jsonWriter.WritePropertyName("TypeName");
                    jsonWriter.WriteValue(Info.Type.Name);
                    jsonWriter.WritePropertyName("Content");
                    jsonWriter.WriteValue(Info.Content);
                    jsonWriter.WritePropertyName("Time");
                    if (Info.Time.HasValue)
                        jsonWriter.WriteValue(Info.Time.Value.GetDateTimeFormats('s')[0].ToString());
                    else
                        jsonWriter.WriteValue("");


                    jsonWriter.WritePropertyName("ArticleHtmlUrl");
                    jsonWriter.WriteValue(Info.ArticleHtmlUrl);
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();

            }
            return Json.ToString();

        } 
        #endregion
        #region 为新闻模块生成排名的json数据
        /// <summary>
        /// 为新闻模块生成排名的json数据
        /// </summary>
        /// <returns></returns>
        public static string GetNewsForMainByJson(int TopNum)
        {
            IEnumerable<news> NewsList = new newsDAL().GetTopNews(TopNum);
            bool Status = false;
            if (NewsList.Count() > 0)
                Status = true;
            StringBuilder Json = new StringBuilder();
            StringWriter sw = new StringWriter(Json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;

                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");
                jsonWriter.WriteStartArray();
                foreach (news Info in NewsList)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Id");
                    jsonWriter.WriteValue(Info.Id);

                    jsonWriter.WritePropertyName("Title");
                    jsonWriter.WriteValue(Info.Title);
                    jsonWriter.WritePropertyName("Time");
                    jsonWriter.WriteValue(Info.Time.Value.ToShortDateString());
                    jsonWriter.WritePropertyName("ArticleHtmlUrl");
                    jsonWriter.WriteValue(Info.ArticleHtmlUrl);
                    jsonWriter.WriteEndObject();
                }


                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject();


            }
            return Json.ToString();

        } 
        #endregion
        #region 返回编辑新闻信息的的json格式
        /// <summary>
        /// 返回编辑新闻信息的的json格式
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string EditNewsInfoToJson(news newInfo)
        {

            StringBuilder Json = new StringBuilder();
            StringWriter sw = new StringWriter(Json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;

                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("id");
                jsonWriter.WriteValue(newInfo.Id);
                jsonWriter.WritePropertyName("Title");
                jsonWriter.WriteValue(newInfo.Title);
                jsonWriter.WritePropertyName("NewsTypeID");
                jsonWriter.WriteValue(newInfo.Type.Id);
                //jsonWriter.WritePropertyName("TypeName");
                //jsonWriter.WriteValue(newInfo.Type.Name);
                jsonWriter.WritePropertyName("Time");
                jsonWriter.WriteValue(newInfo.Time.Value.ToString());
                //.GetDateTimeFormats('s')[0].
                jsonWriter.WritePropertyName("Content");
                jsonWriter.WriteValue(newInfo.Content);
                jsonWriter.WriteEndObject();


            }
            return Json.ToString();

        } 
        #endregion
        #region 分页获取数据
        /// <summary>
        ///分页获取数据
        /// </summary>
        /// <param name="sortId">排序的列名</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">页数</param>
        /// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
        /// <param name="strWhere">查询条件(注意: 不要加where) </param>
        public DataTable ListByPaginationForView(string sortId, int PageSize, int PageIndex, string OrderType, string strWhere)
        {
            return new DataAccessCommon().ListByPagination("VNewsList", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);

        } 
        #endregion
        #region 获取VNewsList的总行数
        /// <summary>
        /// 获取VNewsList的总行数
        /// </summary>
        /// <returns></returns>
        public int GetVNewsListCount(string strWhere)
        {
            return new DataAccessCommon().GetCountTable("VNewsList", strWhere);
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
            return new newsDAL().UpdateNewsArticle(Info);
        } 
        #endregion
        #region 根据时间获取上一条记录和下一条记录
        /// <summary>
        /// 根据时间获取上一条记录和下一条记录
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="PreNews">上一条记录</param>
        /// <param name="NextNews">下一条记录</param>
        public void GetPreAndNextItem(DateTime dt, out news PreNews, out news NextNews)
        {
            PreNews = new news();
            NextNews = new news();
            newsDAL DAL = new newsDAL();
            DataSet ds = DAL.GetPreAndNextItem(dt);

            if (ds.Tables[1].Rows.Count > 0) //在DataSet中第一张表代表下一条记录,第二张表代表上一条记录
            {
                DataRow row = ds.Tables[1].Rows[0];
                PreNews.Id = row.IsNull("Id") ? null : (System.Int32?)row["Id"];
                PreNews.Title = row.IsNull("Title") ? null : (System.String)(row["Title"]);
                PreNews.ArticleHtmlUrl = row.IsNull("ArticleHtmlUrl") ? null : (System.String)(row["ArticleHtmlUrl"]);

            }
            if (ds.Tables[0].Rows.Count > 0)  //上一条记录
            {
                DataRow row = ds.Tables[0].Rows[0];
                NextNews.Id = row.IsNull("Id") ? null : (System.Int32?)row["Id"];
                NextNews.Title = row.IsNull("Title") ? null : (System.String)(row["Title"]);
                NextNews.ArticleHtmlUrl = row.IsNull("ArticleHtmlUrl") ? null : (System.String)(row["ArticleHtmlUrl"]);
            }
        }
        
        #endregion
     
    }
}
