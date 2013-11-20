using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.DAL;
using czcraft.Model;
using Newtonsoft.Json;
using System.IO;
using System.Data;
namespace czcraft.BLL
{
    public partial class craftknowledgeBLL
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
        public static string MiniUiListToJson(IEnumerable<craftknowledge> news, int total, string paramMaxMinAvg)
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
                foreach (craftknowledge Info in news)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Id");
                    jsonWriter.WriteValue(Info.Id);
                    jsonWriter.WritePropertyName("Title");
                    jsonWriter.WriteValue(Info.Title);
                    jsonWriter.WritePropertyName("TypeName");
                    jsonWriter.WriteValue(Info.type.Name);
                    jsonWriter.WritePropertyName("Crafttype");
                    jsonWriter.WriteValue(Info.Crafttype);
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
        #region 为工艺知识模块生成排名的json数据
        /// <summary>
        /// 为工艺知识模块生成排名的json数据
        /// </summary>
        /// <returns></returns>
        public static string GetCraftKnowledgeForMainByJson(int TopNum)
        {
            IEnumerable<craftknowledge> CraftList = new craftknowledgeDAL().GetTopCraftKnowledge(TopNum);
            bool Status = false;
            if (CraftList.Count() > 0)
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
                foreach (craftknowledge Info in CraftList)
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
        #region 返回编辑工艺知识信息的的json格式
        /// <summary>
        /// 返回编辑工艺知识信息的的json格式
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string EditcraftknowledgeInfoToJson(craftknowledge craftInfo)
        {

            StringBuilder Json = new StringBuilder();
            StringWriter sw = new StringWriter(Json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;

                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("id");
                jsonWriter.WriteValue(craftInfo.Id);
                jsonWriter.WritePropertyName("Title");
                jsonWriter.WriteValue(craftInfo.Title);
                jsonWriter.WritePropertyName("TypeID");
                jsonWriter.WriteValue(craftInfo.type.ID);
                jsonWriter.WritePropertyName("TypeName");
                jsonWriter.WriteValue(craftInfo.type.Name);
                jsonWriter.WritePropertyName("Crafttype");
                jsonWriter.WriteValue(craftInfo.Crafttype);
                jsonWriter.WritePropertyName("Time");
                jsonWriter.WriteValue(craftInfo.Time.Value.ToString());
                //.GetDateTimeFormats('s')[0].
                jsonWriter.WritePropertyName("Content");
                jsonWriter.WriteValue(craftInfo.Content);
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
            return new DataAccessCommon().ListByPagination("VCraftKnowledgeList", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);

        } 
        #endregion
        #region 获取VCraftKnowledgeList的总行数
        /// <summary>
        /// 获取VCraftKnowledgeList的总行数
        /// </summary>
        /// <returns></returns>
        public int GetVCraftKnowledgeListCount(string strWhere)
        {
            return new DataAccessCommon().GetCountTable("VCraftKnowledgeList", strWhere);
        } 
        #endregion
        #region 根据时间获取上一条记录和下一条记录
        /// <summary>
        /// 根据时间获取上一条记录和下一条记录
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="PreCraftKnowledge">上一条记录</param>
        /// <param name="NextCraftKnowledge">下一条记录</param>
        public void GetPreAndNextItem(DateTime dt, out craftknowledge PreCraftKnowledge, out craftknowledge NextCraftKnowledge)
        {
            PreCraftKnowledge = new craftknowledge();
            NextCraftKnowledge = new craftknowledge();
            craftknowledgeDAL DAL = new craftknowledgeDAL();
            DataSet ds = DAL.GetPreAndNextItem(dt);

            if (ds.Tables[1].Rows.Count > 0) //在DataSet中第一张表代表下一条记录,第二张表代表上一条记录
            {
                DataRow row = ds.Tables[1].Rows[0];
                PreCraftKnowledge.Id = row.IsNull("Id") ? null : (System.Int32?)row["Id"];
                PreCraftKnowledge.Title = row.IsNull("Title") ? null : (System.String)(row["Title"]);
                PreCraftKnowledge.ArticleHtmlUrl = row.IsNull("ArticleHtmlUrl") ? null : (System.String)(row["ArticleHtmlUrl"]);

            }
            if (ds.Tables[0].Rows.Count > 0)  //上一条记录
            {
                DataRow row = ds.Tables[0].Rows[0];
                NextCraftKnowledge.Id = row.IsNull("Id") ? null : (System.Int32?)row["Id"];
                NextCraftKnowledge.Title = row.IsNull("Title") ? null : (System.String)(row["Title"]);
                NextCraftKnowledge.ArticleHtmlUrl = row.IsNull("ArticleHtmlUrl") ? null : (System.String)(row["ArticleHtmlUrl"]);
            }
        } 
        #endregion
        #region 获取最大记录号
        /// <summary>
        /// 获取最大记录号
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return new craftknowledgeDAL().GetMaxId();
        } 
        #endregion

    }
}
