using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/13 19:36:04
 *  类说明: czcraft.BLL
 */ 
{
	public partial class ourinfoBLL
	{
		/// <summary>
		/// 增加ourinfo
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(ourinfo model)
		{
			return new ourinfoDAL().AddNew(model);
		}
		/// <summary>
		/// 删除ourinfo
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new ourinfoDAL().Delete(id);
		}
		/// <summary>
		/// 删除ourinfo
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new ourinfoDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新ourinfo实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(ourinfo model)
		{
			return new ourinfoDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取ourinfo实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public ourinfo Get(int id)
		{
			return new ourinfoDAL().Get(id);
		}
		/// <summary>
		/// 列出ourinfo所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<ourinfo>ListAll()
		{
			return new ourinfoDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<ourinfo> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new ourinfoDAL().ListByPagination("ourinfo", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
return new ourinfoDAL().GetCount(strWhere);
		}
	}
}
