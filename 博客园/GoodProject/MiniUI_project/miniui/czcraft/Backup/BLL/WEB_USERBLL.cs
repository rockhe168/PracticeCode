using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/7 18:46:37
 *  类说明: czcraft.BLL
 */ 
{
	public partial class WEB_USERBLL
	{
		/// <summary>
		/// 增加WEB_USER
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(WEB_USER model)
		{
			return new WEB_USERDAL().AddNew(model);
		}
		/// <summary>
		/// 删除WEB_USER
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new WEB_USERDAL().Delete(id);
		}
        /// <summary>
        /// 删除WEB_USER
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            return new WEB_USERDAL().DeleteMoreID(strID);
        }
		/// <summary>
		/// 更新WEB_USER实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(WEB_USER model)
		{
			return new WEB_USERDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取WEB_USER实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public WEB_USER Get(int id)
		{
			return new WEB_USERDAL().Get(id);
		}
		/// <summary>
		/// 列出WEB_USER所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<WEB_USER>ListAll()
		{
			return new WEB_USERDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<WEB_USER> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new WEB_USERDAL().ListByPagination("WEB_USER", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
return new WEB_USERDAL().GetCount(strWhere);
		}
	}
}
