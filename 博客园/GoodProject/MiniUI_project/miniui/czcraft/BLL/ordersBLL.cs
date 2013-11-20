using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/5/21 7:50:43
 *  类说明: czcraft.BLL
 */ 
{
	public partial class ordersBLL
	{
		/// <summary>
		/// 增加orders
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(orders model)
		{
			return new ordersDAL().AddNew(model);
		}
		/// <summary>
		/// 删除orders
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new ordersDAL().Delete(id);
		}
		/// <summary>
		/// 删除orders
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new ordersDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新orders实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(orders model)
		{
			return new ordersDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取orders实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public orders Get(int id)
		{
			return new ordersDAL().Get(id);
		}
		/// <summary>
		/// 列出orders所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<orders>ListAll()
		{
			return new ordersDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<orders> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new ordersDAL().ListByPagination("orders", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new ordersDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<orders> ordersInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (orders Info in ordersInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"OrderId\":\"" + Info.OrderId + "\"");
					Json.Append(",");
					Json.Append("\"UserId\":\"" + Info.UserId + "\"");
					Json.Append(",");
					Json.Append("\"ShopDate\":\"" + Info.ShopDate + "\"");
					Json.Append(",");
					Json.Append("\"OrderDate\":\"" + Info.OrderDate + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeRealName\":\"" + Info.ConsigneeRealName + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeName\":\"" + Info.ConsigneeName + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneePhone\":\"" + Info.ConsigneePhone + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeProvince\":\"" + Info.ConsigneeProvince + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeAddress\":\"" + Info.ConsigneeAddress + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeZip\":\"" + Info.ConsigneeZip + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeTel\":\"" + Info.ConsigneeTel + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeEmail\":\"" + Info.ConsigneeEmail + "\"");
					Json.Append(",");
					Json.Append("\"PaymentType\":\"" + Info.PaymentType + "\"");
					Json.Append(",");
					Json.Append("\"Payment\":\"" + Info.Payment + "\"");
					Json.Append(",");
					Json.Append("\"Courier\":\"" + Info.Courier + "\"");
					Json.Append(",");
					Json.Append("\"TotalPrice\":\"" + Info.TotalPrice + "\"");
					Json.Append(",");
					Json.Append("\"FactPrice\":\"" + Info.FactPrice + "\"");
					Json.Append(",");
					Json.Append("\"Invoice\":\"" + Info.Invoice + "\"");
					Json.Append(",");
					Json.Append("\"Remark\":\"" + Info.Remark + "\"");
					Json.Append(",");
					Json.Append("\"OrderStatus\":\"" + Info.OrderStatus + "\"");
					Json.Append(",");
					Json.Append("\"PaymentStatus\":\"" + Info.PaymentStatus + "\"");
					Json.Append(",");
					Json.Append("\"OgisticsStatus\":\"" + Info.OgisticsStatus + "\"");
					Json.Append(",");
					Json.Append("\"Carriage\":\"" + Info.Carriage + "\"");
					Json.Append(",");
					Json.Append("\"OrderType\":\"" + Info.OrderType + "\"");
					Json.Append(",");
					Json.Append("\"IsOrderNormal\":\"" + Info.IsOrderNormal + "\"");
					Json.Append("}");
					if(Info != ordersInfo.Last())
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
		public static string MiniUiForSingeDataToJson(orders Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"OrderId\":\"" + Info.OrderId + "\"");
					Json.Append(",");
					Json.Append("\"UserId\":\"" + Info.UserId + "\"");
					Json.Append(",");
					Json.Append("\"ShopDate\":\"" + Info.ShopDate + "\"");
					Json.Append(",");
					Json.Append("\"OrderDate\":\"" + Info.OrderDate + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeRealName\":\"" + Info.ConsigneeRealName + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeName\":\"" + Info.ConsigneeName + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneePhone\":\"" + Info.ConsigneePhone + "\"");
			//		Json.Append(",");
			//		Json.Append("\"ConsigneeProvince\":\"" + Info.ConsigneeProvince + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeAddress\":\"" +Info.ConsigneeProvince+ Info.ConsigneeAddress + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeZip\":\"" + Info.ConsigneeZip + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeTel\":\"" + Info.ConsigneeTel + "\"");
					Json.Append(",");
					Json.Append("\"ConsigneeEmail\":\"" + Info.ConsigneeEmail + "\"");
					Json.Append(",");
					Json.Append("\"PaymentType\":\"" + Info.PaymentType + "\"");
					Json.Append(",");
					Json.Append("\"Payment\":\"" + Info.Payment + "\"");
					Json.Append(",");
					Json.Append("\"Courier\":\"" + Info.Courier + "\"");
					Json.Append(",");
					Json.Append("\"TotalPrice\":\"" + Info.TotalPrice + "\"");
					Json.Append(",");
					Json.Append("\"FactPrice\":\"" + Info.FactPrice + "\"");
					Json.Append(",");
					Json.Append("\"Invoice\":\"" + Info.Invoice + "\"");
					Json.Append(",");
					Json.Append("\"Remark\":\"" + Info.Remark + "\"");
					Json.Append(",");
					Json.Append("\"OrderStatus\":\"" + Info.OrderStatus + "\"");
					Json.Append(",");
					Json.Append("\"PaymentStatus\":\"" + Info.PaymentStatus + "\"");
					Json.Append(",");
					Json.Append("\"OgisticsStatus\":\"" + Info.OgisticsStatus + "\"");
					Json.Append(",");
					Json.Append("\"Carriage\":\"" + Info.Carriage + "\"");
					Json.Append(",");
					Json.Append("\"OrderType\":\"" + Info.OrderType + "\"");
					Json.Append(",");
					Json.Append("\"IsOrderNormal\":\"" + Info.IsOrderNormal + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
