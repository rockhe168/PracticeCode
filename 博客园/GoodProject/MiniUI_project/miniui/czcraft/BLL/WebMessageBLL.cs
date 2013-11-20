using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/5/8 8:34:36
 *  类说明: czcraft.BLL
 */ 
{
	public partial class WebMessageBLL
	{
		/// <summary>
		/// 增加WebMessage
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
        public long AddNew(WebMessage model)
		{
			return new WebMessageDAL().AddNew(model);
		}
		/// <summary>
		/// 删除WebMessage
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new WebMessageDAL().Delete(id);
		}
		/// <summary>
		/// 删除WebMessage
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new WebMessageDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新WebMessage实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(WebMessage model)
		{
			return new WebMessageDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取WebMessage实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public WebMessage Get(int id)
		{
			return new WebMessageDAL().Get(id);
		}
		/// <summary>
		/// 列出WebMessage所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<WebMessage>ListAll()
		{
			return new WebMessageDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<WebMessage> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new WebMessageDAL().ListByPagination("WebMessage", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new WebMessageDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<WebMessage> WebMessageInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (WebMessage Info in WebMessageInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"liuyanName\":\"" + Info.liuyanName + "\"");
					Json.Append(",");
					Json.Append("\"liuyanContent\":\"" + Info.liuyanContent + "\"");
					Json.Append(",");
					Json.Append("\"liuyanTime\":\"" + Info.liuyanTime + "\"");
					Json.Append(",");
					Json.Append("\"HuifuName\":\"" + Info.HuifuName + "\"");
					Json.Append(",");
					Json.Append("\"huifuTime\":\"" + Info.huifuTime + "\"");
					Json.Append(",");
					Json.Append("\"huifuContent\":\"" + Info.huifuContent + "\"");
					Json.Append(",");
					Json.Append("\"MobilePhone\":\"" + Info.MobilePhone + "\"");
					Json.Append(",");
					Json.Append("\"Email\":\"" + Info.Email + "\"");
					Json.Append("}");
					if(Info != WebMessageInfo.Last())
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
		public static string MiniUiForSingeDataToJson(WebMessage Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"liuyanName\":\"" + Info.liuyanName + "\"");
					Json.Append(",");
					Json.Append("\"liuyanContent\":\"" + Info.liuyanContent + "\"");
					Json.Append(",");
					Json.Append("\"liuyanTime\":\"" + Info.liuyanTime + "\"");
					Json.Append(",");
					Json.Append("\"HuifuName\":\"" + Info.HuifuName + "\"");
					Json.Append(",");
					Json.Append("\"huifuTime\":\"" + Info.huifuTime + "\"");
					Json.Append(",");
					Json.Append("\"huifuContent\":\"" + Info.huifuContent + "\"");
					Json.Append(",");
					Json.Append("\"MobilePhone\":\"" + Info.MobilePhone + "\"");
					Json.Append(",");
					Json.Append("\"Email\":\"" + Info.Email + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
