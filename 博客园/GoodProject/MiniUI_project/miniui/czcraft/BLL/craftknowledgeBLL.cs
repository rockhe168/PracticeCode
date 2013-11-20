using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/13 0:30:08
 *  类说明: czcraft.BLL
 */ 
{
	public partial class craftknowledgeBLL
	{
		/// <summary>
		/// 增加craftknowledge
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(craftknowledge model)
		{
			return new craftknowledgeDAL().AddNew(model);
		}
		/// <summary>
		/// 删除craftknowledge
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new craftknowledgeDAL().Delete(id);
		}
		/// <summary>
		/// 删除craftknowledge
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new craftknowledgeDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新craftknowledge实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(craftknowledge model)
		{
			return new craftknowledgeDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取craftknowledge实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public craftknowledge Get(int id)
		{
			return new craftknowledgeDAL().Get(id);
		}
		/// <summary>
		/// 列出craftknowledge所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<craftknowledge>ListAll()
		{
			return new craftknowledgeDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<craftknowledge> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new craftknowledgeDAL().ListByPagination("craftknowledge", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
return new craftknowledgeDAL().GetCount(strWhere);
		}
	}
}
