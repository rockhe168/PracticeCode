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
	public partial class VProductCraftTypeBLL
	{
		/// <summary>
		/// 增加VProductCraftType
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public long AddNew(VProductCraftType model)
		{
			return new VProductCraftTypeDAL().AddNew(model);
		}
		/// <summary>
		/// 删除VProductCraftType
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new VProductCraftTypeDAL().Delete(id);
		}
		/// <summary>
		/// 删除VProductCraftType
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new VProductCraftTypeDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新VProductCraftType实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VProductCraftType model)
		{
			return new VProductCraftTypeDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取VProductCraftType实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VProductCraftType Get(long id)
		{
			return new VProductCraftTypeDAL().Get(id);
		}
		/// <summary>
		/// 列出VProductCraftType所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VProductCraftType>ListAll()
		{
			return new VProductCraftTypeDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<VProductCraftType> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new VProductCraftTypeDAL().ListByPagination("VProductCraftType", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new VProductCraftTypeDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<VProductCraftType> VProductCraftTypeInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (VProductCraftType Info in VProductCraftTypeInfo)
				{
					Json.Append("{");
					Json.Append("\"TypeName\":\"" + Info.TypeName + "\"");
					Json.Append(",");
					Json.Append("\"TypeId\":\"" + Info.TypeId + "\"");
					Json.Append(",");
					Json.Append("\"FId\":\"" + Info.FId + "\"");
					Json.Append(",");
					Json.Append("\"rank\":\"" + Info.rank + "\"");
					Json.Append(",");
					Json.Append("\"hit\":\"" + Info.hit + "\"");
					Json.Append(",");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Simplename\":\"" + Info.Simplename + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Explain\":\"" + Info.Explain + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append(",");
					Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
					Json.Append(",");
					Json.Append("\"Belongstype\":\"" + Info.Belongstype + "\"");
					Json.Append(",");
					Json.Append("\"Companyid\":\"" + Info.Companyid + "\"");
					Json.Append(",");
					Json.Append("\"Lsprice\":\"" + Info.Lsprice + "\"");
					Json.Append(",");
					Json.Append("\"Num\":\"" + Info.Num + "\"");
					Json.Append(",");
					Json.Append("\"Soldnum\":\"" + Info.Soldnum + "\"");
					Json.Append(",");
					Json.Append("\"Pfprice\":\"" + Info.Pfprice + "\"");
					Json.Append(",");
					Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
					Json.Append(",");
					Json.Append("\"Isrecomment\":\"" + Info.Isrecomment + "\"");
					Json.Append(",");
					Json.Append("\"Nongenetic\":\"" + Info.Nongenetic + "\"");
					Json.Append(",");
					Json.Append("\"Isexcellent\":\"" + Info.Isexcellent + "\"");
					Json.Append(",");
					Json.Append("\"Issell\":\"" + Info.Issell + "\"");
					Json.Append("}");
					if(Info != VProductCraftTypeInfo.Last())
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
		public static string MiniUiForSingeDataToJson(VProductCraftType Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"TypeName\":\"" + Info.TypeName + "\"");
					Json.Append(",");
					Json.Append("\"TypeId\":\"" + Info.TypeId + "\"");
					Json.Append(",");
					Json.Append("\"FId\":\"" + Info.FId + "\"");
					Json.Append(",");
					Json.Append("\"rank\":\"" + Info.rank + "\"");
					Json.Append(",");
					Json.Append("\"hit\":\"" + Info.hit + "\"");
					Json.Append(",");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Simplename\":\"" + Info.Simplename + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Explain\":\"" + Info.Explain + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append(",");
					Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
					Json.Append(",");
					Json.Append("\"Belongstype\":\"" + Info.Belongstype + "\"");
					Json.Append(",");
					Json.Append("\"Companyid\":\"" + Info.Companyid + "\"");
					Json.Append(",");
					Json.Append("\"Lsprice\":\"" + Info.Lsprice + "\"");
					Json.Append(",");
					Json.Append("\"Num\":\"" + Info.Num + "\"");
					Json.Append(",");
					Json.Append("\"Soldnum\":\"" + Info.Soldnum + "\"");
					Json.Append(",");
					Json.Append("\"Pfprice\":\"" + Info.Pfprice + "\"");
					Json.Append(",");
					Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
					Json.Append(",");
					Json.Append("\"Isrecomment\":\"" + Info.Isrecomment + "\"");
					Json.Append(",");
					Json.Append("\"Nongenetic\":\"" + Info.Nongenetic + "\"");
					Json.Append(",");
					Json.Append("\"Isexcellent\":\"" + Info.Isexcellent + "\"");
					Json.Append(",");
					Json.Append("\"Issell\":\"" + Info.Issell + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
