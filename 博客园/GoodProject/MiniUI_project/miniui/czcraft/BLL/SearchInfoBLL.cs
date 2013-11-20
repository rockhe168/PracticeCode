using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/29 10:43:11
 *  类说明: czcraft.BLL
 */ 
{
	public partial class SearchInfoBLL
	{
		/// <summary>
		/// 增加SearchInfo
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public long AddNew(SearchInfo model)
		{
			return new SearchInfoDAL().AddNew(model);
		}
		/// <summary>
		/// 删除SearchInfo
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
        public bool Delete(long id)
		{
			return new SearchInfoDAL().Delete(id);
		}
		/// <summary>
		/// 删除SearchInfo
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new SearchInfoDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新SearchInfo实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(SearchInfo model)
		{
			return new SearchInfoDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取SearchInfo实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
        public SearchInfo Get(long id)
		{
			return new SearchInfoDAL().Get(id);
		}
		/// <summary>
		/// 列出SearchInfo所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<SearchInfo>ListAll()
		{
			return new SearchInfoDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<SearchInfo> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new SearchInfoDAL().ListByPagination("SearchInfo", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new SearchInfoDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<SearchInfo> SearchInfoInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (SearchInfo Info in SearchInfoInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Ip\":\"" + Info.Ip + "\"");
					Json.Append(",");
					Json.Append("\"DateTime\":\"" + Info.DateTime + "\"");
					Json.Append(",");
					Json.Append("\"KeyWord\":\"" + Info.KeyWord + "\"");
					Json.Append(",");
					Json.Append("\"SearchType\":\"" + Info.SearchType + "\"");
					Json.Append("}");
					if(Info != SearchInfoInfo.Last())
					{
						Json.Append(",");
					}
				}
			Json.Append("]}");
			return Json.ToString();
		}
		/// <summary>
		/// 专门生成为MiniUi单个数据生成json数据(T->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <returns>返回json数据</returns>
		public static string MiniUiForSingeDataToJson(SearchInfo Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Ip\":\"" + Info.Ip + "\"");
					Json.Append(",");
					Json.Append("\"DateTime\":\"" + Info.DateTime + "\"");
					Json.Append(",");
					Json.Append("\"KeyWord\":\"" + Info.KeyWord + "\"");
					Json.Append(",");
					Json.Append("\"SearchType\":\"" + Info.SearchType + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
