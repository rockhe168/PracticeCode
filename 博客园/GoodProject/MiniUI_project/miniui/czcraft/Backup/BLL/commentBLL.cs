using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/5/22 9:22:31
 *  类说明: czcraft.BLL
 */ 
{
	public partial class commentBLL
	{
		/// <summary>
		/// 增加comment
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(comment model)
		{
			return new commentDAL().AddNew(model);
		}
		/// <summary>
		/// 删除comment
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new commentDAL().Delete(id);
		}
		/// <summary>
		/// 删除comment
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new commentDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新comment实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(comment model)
		{
			return new commentDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取comment实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public comment Get(int id)
		{
			return new commentDAL().Get(id);
		}
		/// <summary>
		/// 列出comment所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<comment>ListAll()
		{
			return new commentDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<comment> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new commentDAL().ListByPagination("comment", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new commentDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<comment> commentInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (comment Info in commentInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Content\":\"" + Info.Content + "\"");
					Json.Append(",");
					Json.Append("\"Time\":\"" + Info.Time + "\"");
					Json.Append(",");
					Json.Append("\"Productid\":\"" + Info.Productid + "\"");
					Json.Append(",");
					Json.Append("\"huifuContent\":\"" + Info.huifuContent + "\"");
					Json.Append(",");
					Json.Append("\"Grade\":\"" + Info.Grade + "\"");
					Json.Append(",");
					Json.Append("\"MemberId\":\"" + Info.MemberId + "\"");
					Json.Append("}");
					if(Info != commentInfo.Last())
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
		public static string MiniUiForSingeDataToJson(comment Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Content\":\"" + Info.Content + "\"");
					Json.Append(",");
					Json.Append("\"Time\":\"" + Info.Time + "\"");
					Json.Append(",");
					Json.Append("\"Productid\":\"" + Info.Productid + "\"");
					Json.Append(",");
					Json.Append("\"huifuContent\":\"" + Info.huifuContent + "\"");
					Json.Append(",");
					Json.Append("\"Grade\":\"" + Info.Grade + "\"");
					Json.Append(",");
					Json.Append("\"MemberId\":\"" + Info.MemberId + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
