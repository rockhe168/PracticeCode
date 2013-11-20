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
	public partial class product_picturepathBLL
	{
		/// <summary>
		/// 增加product_picturepath
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(product_picturepath model)
		{
			return new product_picturepathDAL().AddNew(model);
		}
	
		/// <summary>
		/// 更新product_picturepath实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(product_picturepath model)
		{
			return new product_picturepathDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取product_picturepath实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public product_picturepath Get(int id)
		{
			return new product_picturepathDAL().Get(id);
		}
		/// <summary>
		/// 列出product_picturepath所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<product_picturepath>ListAll()
		{
			return new product_picturepathDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<product_picturepath> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new product_picturepathDAL().ListByPagination("product_picturepath", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new product_picturepathDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<product_picturepath> product_picturepathInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (product_picturepath Info in product_picturepathInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Productid\":\"" + Info.Productid + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append("}");
					if(Info != product_picturepathInfo.Last())
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
		public static string MiniUiForSingeDataToJson(product_picturepath Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Productid\":\"" + Info.Productid + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
