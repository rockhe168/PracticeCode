using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/15 16:32:37
 *  类说明: czcraft.BLL
 */ 
{
	public partial class companyBLL
	{
		/// <summary>
		/// 增加company
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(company model)
		{
			return new companyDAL().AddNew(model);
		}
		
		/// <summary>
		/// 更新company实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(company model)
		{
			return new companyDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取company实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public company Get(int id)
		{
			return new companyDAL().Get(id);
		}
		/// <summary>
		/// 列出company所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<company>ListAll()
		{
			return new companyDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<company> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new companyDAL().ListByPagination("company", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new companyDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<company> companyInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (company Info in companyInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Username\":\"" + Info.Username + "\"");
					Json.Append(",");
					Json.Append("\"Password\":\"" + Info.Password + "\"");
					Json.Append(",");
					Json.Append("\"Introduction\":\"" + Info.Introduction + "\"");
					Json.Append(",");
					Json.Append("\"Representative\":\"" + Info.Representative + "\"");
					Json.Append(",");
					Json.Append("\"Isrecommend\":\"" + Info.Isrecommend + "\"");
					Json.Append(",");
					Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append(",");
					Json.Append("\"Website\":\"" + Info.Website + "\"");
					Json.Append(",");
					Json.Append("\"mobilephone\":\"" + Info.mobilephone + "\"");
					Json.Append(",");
					Json.Append("\"Telephone\":\"" + Info.Telephone + "\"");
					Json.Append(",");
					Json.Append("\"Fac\":\"" + Info.Fac + "\"");
					Json.Append(",");
					Json.Append("\"Email\":\"" + Info.Email + "\"");
					Json.Append(",");
					Json.Append("\"QQ\":\"" + Info.QQ + "\"");
					Json.Append(",");
					Json.Append("\"Zipcode\":\"" + Info.Zipcode + "\"");
					Json.Append(",");
					Json.Append("\"Address\":\"" + Info.Address + "\"");
					Json.Append(",");
					Json.Append("\"Award\":\"" + Info.Award + "\"");
					Json.Append(",");
					Json.Append("\"State\":\"" + Info.State + "\"");
					Json.Append(",");
					Json.Append("\"State1\":\"" + Info.State1 + "\"");
					Json.Append(",");
					Json.Append("\"hit\":\"" + Info.hit + "\"");
					Json.Append(",");
					Json.Append("\"rank\":\"" + Info.rank + "\"");
					Json.Append("}");
					if(Info != companyInfo.Last())
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
		public static string MiniUiForSingeDataToJson(company Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Username\":\"" + Info.Username + "\"");
					Json.Append(",");
					Json.Append("\"Password\":\"" + Info.Password + "\"");
					Json.Append(",");
					Json.Append("\"Introduction\":\"" + Info.Introduction + "\"");
					Json.Append(",");
					Json.Append("\"Representative\":\"" + Info.Representative + "\"");
					Json.Append(",");
					Json.Append("\"Isrecommend\":\"" + Info.Isrecommend + "\"");
					Json.Append(",");
					Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append(",");
					Json.Append("\"Website\":\"" + Info.Website + "\"");
					Json.Append(",");
					Json.Append("\"mobilephone\":\"" + Info.mobilephone + "\"");
					Json.Append(",");
					Json.Append("\"Telephone\":\"" + Info.Telephone + "\"");
					Json.Append(",");
					Json.Append("\"Fac\":\"" + Info.Fac + "\"");
					Json.Append(",");
					Json.Append("\"Email\":\"" + Info.Email + "\"");
					Json.Append(",");
					Json.Append("\"QQ\":\"" + Info.QQ + "\"");
					Json.Append(",");
					Json.Append("\"Zipcode\":\"" + Info.Zipcode + "\"");
					Json.Append(",");
					Json.Append("\"Address\":\"" + Info.Address + "\"");
					Json.Append(",");
					Json.Append("\"Award\":\"" + Info.Award + "\"");
					Json.Append(",");
					Json.Append("\"State\":\"" + Info.State + "\"");
					Json.Append(",");
					Json.Append("\"State1\":\"" + Info.State1 + "\"");
					Json.Append(",");
					Json.Append("\"hit\":\"" + Info.hit + "\"");
					Json.Append(",");
					Json.Append("\"rank\":\"" + Info.rank + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
