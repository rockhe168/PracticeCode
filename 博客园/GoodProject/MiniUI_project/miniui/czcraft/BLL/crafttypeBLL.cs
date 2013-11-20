using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/11 15:10:17
 *  类说明: czcraft.BLL
 */ 
{
	public partial class crafttypeBLL
	{
		/// <summary>
		/// 增加crafttype
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool AddNew(crafttype model)
		{
            crafttypeDAL DAL = new crafttypeDAL();
            model.FId = GetFId((int)model.Belongsid);
            int id = DAL.AddNew(model);
           return DAL.UpdateLeaf(id);//将它的双亲的IsLeaf设置为false
           
		}
      
		
		/// <summary>
		/// 更新crafttype实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(crafttype model)
		{
			return new crafttypeDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取crafttype实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public crafttype Get(int id)
		{
			return new crafttypeDAL().Get(id);
		}
		/// <summary>
		/// 列出crafttype所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<crafttype>ListAll()
		{
			return new crafttypeDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<crafttype> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new crafttypeDAL().ListByPagination("crafttype", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
return new crafttypeDAL().GetCount(strWhere);
		}
	}
}
