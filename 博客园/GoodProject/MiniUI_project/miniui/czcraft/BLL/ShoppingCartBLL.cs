using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/5/15 23:57:19
 *  类说明: czcraft.BLL
 */ 
{
	public partial class ShoppingCartBLL
	{
		/// <summary>
		/// 增加ShoppingCart
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
        public long AddNew(ShoppingCart model)
		{
			return new ShoppingCartDAL().AddNew(model);
		}
		/// <summary>
		/// 删除ShoppingCart
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new ShoppingCartDAL().Delete(id);
		}
		/// <summary>
		/// 删除ShoppingCart
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new ShoppingCartDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新ShoppingCart实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(ShoppingCart model)
		{
			return new ShoppingCartDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取ShoppingCart实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public ShoppingCart Get(int id)
		{
			return new ShoppingCartDAL().Get(id);
		}
		/// <summary>
		/// 列出ShoppingCart所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<ShoppingCart>ListAll()
		{
			return new ShoppingCartDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<ShoppingCart> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new ShoppingCartDAL().ListByPagination("ShoppingCart", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new ShoppingCartDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<ShoppingCart> ShoppingCartInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (ShoppingCart Info in ShoppingCartInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"ProductId\":\"" + Info.ProductId + "\"");
					Json.Append(",");
					Json.Append("\"SupperlierId\":\"" + Info.SupperlierId + "\"");
					Json.Append(",");
					Json.Append("\"BelongType\":\"" + Info.BelongType + "\"");
					Json.Append(",");
					Json.Append("\"Quantity\":\"" + Info.Quantity + "\"");
					Json.Append(",");
					Json.Append("\"SupperlierName\":\"" + Info.SupperlierName + "\"");
					Json.Append(",");
					Json.Append("\"Price\":\"" + Info.Price + "\"");
					Json.Append(",");
					Json.Append("\"MemberId\":\"" + Info.MemberId + "\"");
					Json.Append(",");
					Json.Append("\"ProductName\":\"" + Info.ProductName + "\"");
					Json.Append("}");
					if(Info != ShoppingCartInfo.Last())
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
		public static string MiniUiForSingeDataToJson(ShoppingCart Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"ProductId\":\"" + Info.ProductId + "\"");
					Json.Append(",");
					Json.Append("\"SupperlierId\":\"" + Info.SupperlierId + "\"");
					Json.Append(",");
					Json.Append("\"BelongType\":\"" + Info.BelongType + "\"");
					Json.Append(",");
					Json.Append("\"Quantity\":\"" + Info.Quantity + "\"");
					Json.Append(",");
					Json.Append("\"SupperlierName\":\"" + Info.SupperlierName + "\"");
					Json.Append(",");
					Json.Append("\"Price\":\"" + Info.Price + "\"");
					Json.Append(",");
					Json.Append("\"MemberId\":\"" + Info.MemberId + "\"");
					Json.Append(",");
					Json.Append("\"ProductName\":\"" + Info.ProductName + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
