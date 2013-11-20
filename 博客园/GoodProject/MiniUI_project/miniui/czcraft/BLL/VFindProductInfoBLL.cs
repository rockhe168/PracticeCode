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
	public partial class VFindProductInfoBLL
	{
		/// <summary>
		/// 增加VFindProductInfo
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(VFindProductInfo model)
		{
			return new VFindProductInfoDAL().AddNew(model);
		}
		/// <summary>
		/// 删除VFindProductInfo
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
			return new VFindProductInfoDAL().Delete(id);
		}
		/// <summary>
		/// 删除VFindProductInfo
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
			return new VFindProductInfoDAL().DeleteMoreID(strID);
		}
		/// <summary>
		/// 更新VFindProductInfo实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VFindProductInfo model)
		{
			return new VFindProductInfoDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取VFindProductInfo实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VFindProductInfo Get(int id)
		{
			return new VFindProductInfoDAL().Get(id);
		}
		/// <summary>
		/// 列出VFindProductInfo所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VFindProductInfo>ListAll()
		{
			return new VFindProductInfoDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<VFindProductInfo> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new VFindProductInfoDAL().ListByPagination("VFindProductInfo", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new VFindProductInfoDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<VFindProductInfo> VFindProductInfoInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (VFindProductInfo Info in VFindProductInfoInfo)
				{
					Json.Append("{");
					Json.Append("\"TypeName\":\"" + Info.TypeName + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Simplename\":\"" + Info.Simplename + "\"");
					Json.Append(",");
					Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
					Json.Append(",");
					Json.Append("\"Belongstype\":\"" + Info.Belongstype + "\"");
					Json.Append(",");
					Json.Append("\"Num\":\"" + Info.Num + "\"");
					Json.Append(",");
					Json.Append("\"Soldnum\":\"" + Info.Soldnum + "\"");
					Json.Append(",");
					Json.Append("\"hit\":\"" + Info.hit + "\"");
					Json.Append(",");
					Json.Append("\"rank\":\"" + Info.rank + "\"");
					Json.Append(",");
					Json.Append("\"MasterName\":\"" + Info.MasterName + "\"");
					Json.Append(",");
					Json.Append("\"CompanyName\":\"" + Info.CompanyName + "\"");
					Json.Append(",");
					Json.Append("\"Isrecomment\":\"" + Info.Isrecomment + "\"");
					Json.Append(",");
					Json.Append("\"Nongenetic\":\"" + Info.Nongenetic + "\"");
					Json.Append(",");
					Json.Append("\"Isexcellent\":\"" + Info.Isexcellent + "\"");
					Json.Append(",");
					Json.Append("\"Issell\":\"" + Info.Issell + "\"");
					Json.Append(",");
					Json.Append("\"Typeid\":\"" + Info.Typeid + "\"");
					Json.Append(",");
					Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
					Json.Append(",");
					Json.Append("\"Companyid\":\"" + Info.Companyid + "\"");
					Json.Append(",");
					Json.Append("\"CompanyState1\":\"" + Info.CompanyState1 + "\"");
					Json.Append(",");
					Json.Append("\"CompanyState\":\"" + Info.CompanyState + "\"");
					Json.Append(",");
					Json.Append("\"MasterState\":\"" + Info.MasterState + "\"");
					Json.Append(",");
					Json.Append("\"MasterState1\":\"" + Info.MasterState1 + "\"");
					Json.Append(",");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append("}");
					if(Info != VFindProductInfoInfo.Last())
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
		public static string MiniUiForSingeDataToJson(VFindProductInfo Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"TypeName\":\"" + Info.TypeName + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Simplename\":\"" + Info.Simplename + "\"");
					Json.Append(",");
					Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
					Json.Append(",");
					Json.Append("\"Belongstype\":\"" + Info.Belongstype + "\"");
					Json.Append(",");
					Json.Append("\"Num\":\"" + Info.Num + "\"");
					Json.Append(",");
					Json.Append("\"Soldnum\":\"" + Info.Soldnum + "\"");
					Json.Append(",");
					Json.Append("\"hit\":\"" + Info.hit + "\"");
					Json.Append(",");
					Json.Append("\"rank\":\"" + Info.rank + "\"");
					Json.Append(",");
					Json.Append("\"MasterName\":\"" + Info.MasterName + "\"");
					Json.Append(",");
					Json.Append("\"CompanyName\":\"" + Info.CompanyName + "\"");
					Json.Append(",");
					Json.Append("\"Isrecomment\":\"" + Info.Isrecomment + "\"");
					Json.Append(",");
					Json.Append("\"Nongenetic\":\"" + Info.Nongenetic + "\"");
					Json.Append(",");
					Json.Append("\"Isexcellent\":\"" + Info.Isexcellent + "\"");
					Json.Append(",");
					Json.Append("\"Issell\":\"" + Info.Issell + "\"");
					Json.Append(",");
					Json.Append("\"Typeid\":\"" + Info.Typeid + "\"");
					Json.Append(",");
					Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
					Json.Append(",");
					Json.Append("\"Companyid\":\"" + Info.Companyid + "\"");
					Json.Append(",");
					Json.Append("\"CompanyState1\":\"" + Info.CompanyState1 + "\"");
					Json.Append(",");
					Json.Append("\"CompanyState\":\"" + Info.CompanyState + "\"");
					Json.Append(",");
					Json.Append("\"MasterState\":\"" + Info.MasterState + "\"");
					Json.Append(",");
					Json.Append("\"MasterState1\":\"" + Info.MasterState1 + "\"");
					Json.Append(",");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
