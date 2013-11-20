using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Data;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/7 18:46:37
 *  类说明: czcraft.BLL
 */ 
{
	public partial class WEB_SYS_FUNTIONBLL
	{
		/// <summary>
		/// 增加WEB_SYS_FUNTION
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(WEB_SYS_FUNTION model)
		{
            return new WEB_SYS_FUNTIONDAL().AddNew(model);
		}
		/// <summary>
		/// 删除WEB_SYS_FUNTION
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new WEB_SYS_FUNTIONDAL().Delete(id);
		}
        /// <summary>
        /// 获取用户组功能表
        /// </summary>
        /// <param name="groupID">用户组id</param>
        /// <returns>数据表</returns>
        public DataTable ListAllItem(int groupID)
        {
          return  new WEB_SYS_FUNTIONDAL().ListAllItem(groupID);
        }

        /// <summary>
        /// 删除WEB_SYS_FUNTION
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            return new WEB_SYS_FUNTIONDAL().DeleteMoreID(strID);
        }
		/// <summary>
		/// 更新WEB_SYS_FUNTION实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(WEB_SYS_FUNTION model)
		{
			return new WEB_SYS_FUNTIONDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取WEB_SYS_FUNTION实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public WEB_SYS_FUNTION Get(int id)
		{
			return new WEB_SYS_FUNTIONDAL().Get(id);
		}
		/// <summary>
		/// 列出WEB_SYS_FUNTION所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<WEB_SYS_FUNTION>ListAll()
		{
			return new WEB_SYS_FUNTIONDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<WEB_SYS_FUNTION> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new WEB_SYS_FUNTIONDAL().ListByPagination("WEB_SYS_FUNTION", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}
        /// <summary>
        ///分页获取数据(通用Table返回)
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="sortId">排序的列名</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">页数</param>
        /// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
        /// <param name="strWhere">查询条件(注意: 不要加where) </param>
        public DataTable ListByPaginationByTable(string tablename,string sortId,string field, int PageSize, int PageIndex, string OrderType, string strWhere)
        {
            return new WEB_SYS_FUNTIONDAL().ListByPaginationByTable(tablename, "", field, sortId, PageSize, PageIndex, OrderType, strWhere);
        }
		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
        return new WEB_SYS_FUNTIONDAL().GetCount(strWhere);
		}
	}
}
