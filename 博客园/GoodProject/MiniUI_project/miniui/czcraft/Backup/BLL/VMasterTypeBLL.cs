using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/30 17:11:10
 *  类说明: czcraft.BLL
 */ 
{
	public partial class VMasterTypeBLL
	{
		/// <summary>
		/// 增加VMasterType
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(VMasterType model)
		{
			return new VMasterTypeDAL().AddNew(model);
		}
		/// <summary>
		/// 删除VMasterType
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new VMasterTypeDAL().Delete(id);
		}
		/// <summary>
		/// 删除VMasterType
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new VMasterTypeDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新VMasterType实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VMasterType model)
		{
			return new VMasterTypeDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取VMasterType实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VMasterType Get(int id)
		{
			return new VMasterTypeDAL().Get(id);
		}
		/// <summary>
		/// 列出VMasterType所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VMasterType>ListAll()
		{
			return new VMasterTypeDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<VMasterType> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new VMasterTypeDAL().ListByPagination("VMasterType", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new VMasterTypeDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<VMasterType> VMasterTypeInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (VMasterType Info in VMasterTypeInfo)
				{
					Json.Append("{");
					Json.Append("\"TypeName\":\"" + Info.TypeName + "\"");
					Json.Append(",");
					Json.Append("\"Typeid\":\"" + Info.Typeid + "\"");
					Json.Append(",");
					Json.Append("\"Belongsid\":\"" + Info.Belongsid + "\"");
					Json.Append(",");
					Json.Append("\"level\":\"" + Info.level + "\"");
					Json.Append(",");
					Json.Append("\"IsLeaf\":\"" + Info.IsLeaf + "\"");
					Json.Append(",");
					Json.Append("\"FId\":\"" + Info.FId + "\"");
					Json.Append(",");
					Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
					Json.Append(",");
					Json.Append("\"m_TypeId\":\"" + Info.m_TypeId + "\"");
					Json.Append("}");
					if(Info != VMasterTypeInfo.Last())
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
		public static string MiniUiForSingeDataToJson(VMasterType Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"TypeName\":\"" + Info.TypeName + "\"");
					Json.Append(",");
					Json.Append("\"Typeid\":\"" + Info.Typeid + "\"");
					Json.Append(",");
					Json.Append("\"Belongsid\":\"" + Info.Belongsid + "\"");
					Json.Append(",");
					Json.Append("\"level\":\"" + Info.level + "\"");
					Json.Append(",");
					Json.Append("\"IsLeaf\":\"" + Info.IsLeaf + "\"");
					Json.Append(",");
					Json.Append("\"FId\":\"" + Info.FId + "\"");
					Json.Append(",");
					Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
					Json.Append(",");
					Json.Append("\"m_TypeId\":\"" + Info.m_TypeId + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
