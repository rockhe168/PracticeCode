using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/5/1 11:06:01
 *  类说明: czcraft.BLL
 */ 
{
	public partial class productBLL
	{
		/// <summary>
		/// 增加product
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public long AddNew(product model)
		{
			return new productDAL().AddNew(model);
		}
	
		/// <summary>
		/// 更新product实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(product model)
		{
			return new productDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取product实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public product Get(long id)
		{
			return new productDAL().Get(id);
		}
		/// <summary>
		/// 列出product所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<product>ListAll()
		{
			return new productDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<product> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new productDAL().ListByPagination("product", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new productDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<product> productInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (product Info in productInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Simplename\":\"" + Info.Simplename + "\"");
					Json.Append(",");
					Json.Append("\"Explain\":\"" + Info.Explain + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append(",");
					Json.Append("\"Flashpath\":\"" + Info.Flashpath + "\"");
					Json.Append(",");
					Json.Append("\"Material\":\"" + Info.Material + "\"");
					Json.Append(",");
					Json.Append("\"Weight\":\"" + Info.Weight + "\"");
					Json.Append(",");
					Json.Append("\"Volume\":\"" + Info.Volume + "\"");
					Json.Append(",");
					Json.Append("\"Specification\":\"" + Info.Specification + "\"");
					Json.Append(",");
					Json.Append("\"Model\":\"" + Info.Model + "\"");
					Json.Append(",");
					Json.Append("\"Issell\":\"" + Info.Issell + "\"");
					Json.Append(",");
					Json.Append("\"Isexcellent\":\"" + Info.Isexcellent + "\"");
					Json.Append(",");
					Json.Append("\"Nongenetic\":\"" + Info.Nongenetic + "\"");
					Json.Append(",");
					Json.Append("\"Isrecomment\":\"" + Info.Isrecomment + "\"");
					Json.Append(",");
					Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
					Json.Append(",");
					Json.Append("\"Typeid\":\"" + Info.Typeid + "\"");
					Json.Append(",");
					Json.Append("\"Belongstype\":\"" + Info.Belongstype + "\"");
					Json.Append(",");
					Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
					Json.Append(",");
					Json.Append("\"Companyid\":\"" + Info.Companyid + "\"");
					Json.Append(",");
					Json.Append("\"Num\":\"" + Info.Num + "\"");
					Json.Append(",");
					Json.Append("\"Soldnum\":\"" + Info.Soldnum + "\"");
					Json.Append(",");
					Json.Append("\"Lsprice\":\"" + Info.Lsprice + "\"");
					Json.Append(",");
					Json.Append("\"Pfprice\":\"" + Info.Pfprice + "\"");
					Json.Append(",");
					Json.Append("\"Vipprice\":\"" + Info.Vipprice + "\"");
					Json.Append(",");
					Json.Append("\"MarketPrice\":\"" + Info.MarketPrice + "\"");
					Json.Append(",");
					Json.Append("\"Price1\":\"" + Info.Price1 + "\"");
					Json.Append(",");
					Json.Append("\"Price2\":\"" + Info.Price2 + "\"");
					Json.Append(",");
					Json.Append("\"Price3\":\"" + Info.Price3 + "\"");
					Json.Append(",");
					Json.Append("\"Price4\":\"" + Info.Price4 + "\"");
					Json.Append(",");
					Json.Append("\"hit\":\"" + Info.hit + "\"");
					Json.Append(",");
					Json.Append("\"rank\":\"" + Info.rank + "\"");
					Json.Append("}");
					if(Info != productInfo.Last())
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
		public static string MiniUiForSingeDataToJson(product Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Simplename\":\"" + Info.Simplename + "\"");
					Json.Append(",");
					Json.Append("\"Explain\":\"" + Info.Explain + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append(",");
					Json.Append("\"Flashpath\":\"" + Info.Flashpath + "\"");
					Json.Append(",");
					Json.Append("\"Material\":\"" + Info.Material + "\"");
					Json.Append(",");
					Json.Append("\"Weight\":\"" + Info.Weight + "\"");
					Json.Append(",");
					Json.Append("\"Volume\":\"" + Info.Volume + "\"");
					Json.Append(",");
					Json.Append("\"Specification\":\"" + Info.Specification + "\"");
					Json.Append(",");
					Json.Append("\"Model\":\"" + Info.Model + "\"");
					Json.Append(",");
					Json.Append("\"Issell\":\"" + Info.Issell + "\"");
					Json.Append(",");
					Json.Append("\"Isexcellent\":\"" + Info.Isexcellent + "\"");
					Json.Append(",");
					Json.Append("\"Nongenetic\":\"" + Info.Nongenetic + "\"");
					Json.Append(",");
					Json.Append("\"Isrecomment\":\"" + Info.Isrecomment + "\"");
					Json.Append(",");
					Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
					Json.Append(",");
					Json.Append("\"Typeid\":\"" + Info.Typeid + "\"");
					Json.Append(",");
					Json.Append("\"Belongstype\":\"" + Info.Belongstype + "\"");
					Json.Append(",");
					Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
					Json.Append(",");
					Json.Append("\"Companyid\":\"" + Info.Companyid + "\"");
					Json.Append(",");
					Json.Append("\"Num\":\"" + Info.Num + "\"");
					Json.Append(",");
					Json.Append("\"Soldnum\":\"" + Info.Soldnum + "\"");
					Json.Append(",");
					Json.Append("\"Lsprice\":\"" + Info.Lsprice + "\"");
					Json.Append(",");
					Json.Append("\"Pfprice\":\"" + Info.Pfprice + "\"");
					Json.Append(",");
					Json.Append("\"Vipprice\":\"" + Info.Vipprice + "\"");
					Json.Append(",");
					Json.Append("\"MarketPrice\":\"" + Info.MarketPrice + "\"");
					Json.Append(",");
					Json.Append("\"Price1\":\"" + Info.Price1 + "\"");
					Json.Append(",");
					Json.Append("\"Price2\":\"" + Info.Price2 + "\"");
					Json.Append(",");
					Json.Append("\"Price3\":\"" + Info.Price3 + "\"");
					Json.Append(",");
					Json.Append("\"Price4\":\"" + Info.Price4 + "\"");
					Json.Append(",");
					Json.Append("\"hit\":\"" + Info.hit + "\"");
					Json.Append(",");
					Json.Append("\"rank\":\"" + Info.rank + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
