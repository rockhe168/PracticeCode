using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/25 20:21:09
 *  类说明: czcraft.BLL
 */ 
{
	public partial class SystemLogBLL
	{
		/// <summary>
		/// 增加SystemLog
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public long AddNew(SystemLog model)
		{
			return new SystemLogDAL().AddNew(model);
		}
		/// <summary>
		/// 删除SystemLog
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new SystemLogDAL().Delete(id);
		}
		/// <summary>
		/// 删除SystemLog
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new SystemLogDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新SystemLog实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(SystemLog model)
		{
			return new SystemLogDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取SystemLog实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public SystemLog Get(int id)
		{
			return new SystemLogDAL().Get(id);
		}
		/// <summary>
		/// 列出SystemLog所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<SystemLog>ListAll()
		{
			return new SystemLogDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<SystemLog> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new SystemLogDAL().ListByPagination("SystemLog", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new SystemLogDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<SystemLog> SystemLogInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (SystemLog Info in SystemLogInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Title\":\"" + Info.Title + "\"");
					Json.Append(",");
                    Json.Append("\"AddTime\":\"" + Info.AddTime.Value.GetDateTimeFormats('s')[0].ToString() + "\"");
					Json.Append(",");
					Json.Append("\"Url\":\"" + Info.Url + "\"");
					Json.Append(",");
					Json.Append("\"UserName\":\"" + Info.UserName + "\"");
					Json.Append("}");
					if(Info != SystemLogInfo.Last())
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
		public static string MiniUiForSingeDataToJson(SystemLog Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Title\":\"" + Info.Title + "\"");
					Json.Append(",");
					Json.Append("\"AddTime\":\"" + Info.AddTime + "\"");
					Json.Append(",");
					Json.Append("\"Url\":\"" + Info.Url + "\"");
					Json.Append(",");
					Json.Append("\"UserName\":\"" + Info.UserName + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
