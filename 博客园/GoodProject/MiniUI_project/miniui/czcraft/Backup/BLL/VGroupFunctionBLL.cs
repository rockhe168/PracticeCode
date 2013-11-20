using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/10 9:26:55
 *  类说明: czcraft.BLL
 */ 
{
	public partial class VGroupFunctionBLL
	{
		/// <summary>
		/// 增加VGroupFunction
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(VGroupFunction model)
		{
			return new VGroupFunctionDAL().AddNew(model);
		}
		/// <summary>
		/// 删除VGroupFunction
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new VGroupFunctionDAL().Delete(id);
		}
		/// <summary>
		/// 删除VGroupFunction
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new VGroupFunctionDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新VGroupFunction实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VGroupFunction model)
		{
			return new VGroupFunctionDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取VGroupFunction实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VGroupFunction Get(int id)
		{
			return new VGroupFunctionDAL().Get(id);
		}
		/// <summary>
		/// 列出VGroupFunction所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VGroupFunction>ListAll()
		{
			return new VGroupFunctionDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<VGroupFunction> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new VGroupFunctionDAL().ListByPagination("VGroupFunction", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
        return new VGroupFunctionDAL().GetCount(strWhere);
		}
	}
}
