using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/14 15:17:39
 *  类说明: czcraft.BLL
 */ 
{
	public partial class company_typeBLL
	{
		/// <summary>
		/// 增加company_type
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(company_type model)
		{
			return new company_typeDAL().AddNew(model);
		}
		/// <summary>
		/// 删除company_type
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new company_typeDAL().Delete(id);
		}
		/// <summary>
		/// 删除company_type
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new company_typeDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新company_type实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(company_type model)
		{
			return new company_typeDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取company_type实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public company_type Get(int id)
		{
			return new company_typeDAL().Get(id);
		}
		/// <summary>
		/// 列出company_type所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<company_type>ListAll()
		{
			return new company_typeDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<company_type> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new company_typeDAL().ListByPagination("company_type", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new company_typeDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<company_type> company_typeInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (company_type Info in company_typeInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Companyid\":\"" + Info.Companyid + "\"");
					Json.Append(",");
					Json.Append("\"Typeid\":\"" + Info.Typeid + "\"");
					Json.Append("}");
					if(Info != company_typeInfo.Last())
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
		public static string MiniUiForSingeDataToJson(company_type Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Companyid\":\"" + Info.Companyid + "\"");
					Json.Append(",");
					Json.Append("\"Typeid\":\"" + Info.Typeid + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
