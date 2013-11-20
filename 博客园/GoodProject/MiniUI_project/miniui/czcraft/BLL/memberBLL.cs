using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/5/5 10:13:44
 *  类说明: czcraft.BLL
 */ 
{
	public partial class memberBLL
	{
		/// <summary>
		/// 增加member
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(member model)
		{
			return new memberDAL().AddNew(model);
		}
		/// <summary>
		/// 删除member
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new memberDAL().Delete(id);
		}
		/// <summary>
		/// 删除member
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new memberDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新member实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(member model)
		{
			return new memberDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取member实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public member Get(int id)
		{
			return new memberDAL().Get(id);
		}
		/// <summary>
		/// 列出member所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<member>ListAll()
		{
			return new memberDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<member> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new memberDAL().ListByPagination("member", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new memberDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<member> memberInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (member Info in memberInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"username\":\"" + Info.username + "\"");
					Json.Append(",");
					Json.Append("\"password\":\"" + Info.password + "\"");
					Json.Append(",");
					Json.Append("\"Sex\":\"" + Info.Sex + "\"");
					Json.Append(",");
					Json.Append("\"nation\":\"" + Info.nation + "\"");
					Json.Append(",");
					Json.Append("\"mobilephone\":\"" + Info.mobilephone + "\"");
					Json.Append(",");
					Json.Append("\"Telephone\":\"" + Info.Telephone + "\"");
					Json.Append(",");
					Json.Append("\"Email\":\"" + Info.Email + "\"");
					Json.Append(",");
					Json.Append("\"qq\":\"" + Info.qq + "\"");
					Json.Append(",");
					Json.Append("\"Zipcode\":\"" + Info.Zipcode + "\"");
					Json.Append(",");
					Json.Append("\"Address\":\"" + Info.Address + "\"");
					Json.Append(",");
					Json.Append("\"states\":\"" + Info.states + "\"");
					Json.Append(",");
					Json.Append("\"VCode\":\"" + Info.VCode + "\"");
					Json.Append(",");
					Json.Append("\"VTime\":\"" + Info.VTime + "\"");
					Json.Append("}");
					if(Info != memberInfo.Last())
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
		public static string MiniUiForSingeDataToJson(member Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"username\":\"" + Info.username + "\"");
					Json.Append(",");
					Json.Append("\"password\":\"" + Info.password + "\"");
					Json.Append(",");
					Json.Append("\"Sex\":\"" + Info.Sex + "\"");
					Json.Append(",");
					Json.Append("\"nation\":\"" + Info.nation + "\"");
					Json.Append(",");
					Json.Append("\"mobilephone\":\"" + Info.mobilephone + "\"");
					Json.Append(",");
					Json.Append("\"Telephone\":\"" + Info.Telephone + "\"");
					Json.Append(",");
					Json.Append("\"Email\":\"" + Info.Email + "\"");
					Json.Append(",");
					Json.Append("\"qq\":\"" + Info.qq + "\"");
					Json.Append(",");
					Json.Append("\"Zipcode\":\"" + Info.Zipcode + "\"");
					Json.Append(",");
					Json.Append("\"Address\":\"" + Info.Address + "\"");
					Json.Append(",");
					Json.Append("\"states\":\"" + Info.states + "\"");
					Json.Append(",");
					Json.Append("\"VCode\":\"" + Info.VCode + "\"");
					Json.Append(",");
					Json.Append("\"VTime\":\"" + Info.VTime + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
