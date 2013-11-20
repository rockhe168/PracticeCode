using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/5/16 0:10:11
 *  类说明: czcraft.BLL
 */ 
{
	public partial class VCartProductInfoBLL
	{
		/// <summary>
		/// 增加VCartProductInfo
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public long AddNew(VCartProductInfo model)
		{
			return new VCartProductInfoDAL().AddNew(model);
		}
		/// <summary>
		/// 删除VCartProductInfo
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new VCartProductInfoDAL().Delete(id);
		}
		/// <summary>
		/// 删除VCartProductInfo
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new VCartProductInfoDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新VCartProductInfo实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VCartProductInfo model)
		{
			return new VCartProductInfoDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取VCartProductInfo实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VCartProductInfo Get(long id)
		{
			return new VCartProductInfoDAL().Get(id);
		}
		/// <summary>
		/// 列出VCartProductInfo所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VCartProductInfo>ListAll()
		{
			return new VCartProductInfoDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<VCartProductInfo> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new VCartProductInfoDAL().ListByPagination("VCartProductInfo", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new VCartProductInfoDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<VCartProductInfo> VCartProductInfoInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (VCartProductInfo Info in VCartProductInfoInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"ProductId\":\"" + Info.ProductId + "\"");
					Json.Append(",");
					Json.Append("\"SupperlierId\":\"" + Info.SupperlierId + "\"");
					Json.Append(",");
					Json.Append("\"Quantity\":\"" + Info.Quantity + "\"");
					Json.Append(",");
					Json.Append("\"BelongType\":\"" + Info.BelongType + "\"");
					Json.Append(",");
					Json.Append("\"SupperlierName\":\"" + Info.SupperlierName + "\"");
					Json.Append(",");
					Json.Append("\"Price\":\"" + Info.Price + "\"");
					Json.Append(",");
					Json.Append("\"MemberId\":\"" + Info.MemberId + "\"");
					Json.Append(",");
					Json.Append("\"ProductName\":\"" + Info.ProductName + "\"");
					Json.Append(",");
					Json.Append("\"Num\":\"" + Info.Num + "\"");
					Json.Append(",");
					Json.Append("\"Soldnum\":\"" + Info.Soldnum + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append("}");
					if(Info != VCartProductInfoInfo.Last())
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
		public static string MiniUiForSingeDataToJson(VCartProductInfo Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"ProductId\":\"" + Info.ProductId + "\"");
					Json.Append(",");
					Json.Append("\"SupperlierId\":\"" + Info.SupperlierId + "\"");
					Json.Append(",");
					Json.Append("\"Quantity\":\"" + Info.Quantity + "\"");
					Json.Append(",");
					Json.Append("\"BelongType\":\"" + Info.BelongType + "\"");
					Json.Append(",");
					Json.Append("\"SupperlierName\":\"" + Info.SupperlierName + "\"");
					Json.Append(",");
					Json.Append("\"Price\":\"" + Info.Price + "\"");
					Json.Append(",");
					Json.Append("\"MemberId\":\"" + Info.MemberId + "\"");
					Json.Append(",");
					Json.Append("\"ProductName\":\"" + Info.ProductName + "\"");
					Json.Append(",");
					Json.Append("\"Num\":\"" + Info.Num + "\"");
					Json.Append(",");
					Json.Append("\"Soldnum\":\"" + Info.Soldnum + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
