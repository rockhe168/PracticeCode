using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/5/12 23:37:47
 *  类说明: czcraft.BLL
 */ 
{
	public partial class masterBLL
	{
		/// <summary>
		/// 增加master
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(master model)
		{
			return new masterDAL().AddNew(model);
		}
	
		/// <summary>
		/// 更新master实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(master model)
		{
			return new masterDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取master实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public master Get(int id)
		{
			return new masterDAL().Get(id);
		}
		/// <summary>
		/// 列出master所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<master>ListAll()
		{
			return new masterDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<master> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new masterDAL().ListByPagination("master", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new masterDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<master> masterInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (master Info in masterInfo)
				{
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Username\":\"" + Info.Username + "\"");
					Json.Append(",");
					Json.Append("\"Password\":\"" + Info.Password + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Introduction\":\"" + Info.Introduction + "\"");
					Json.Append(",");
					Json.Append("\"Isrecommend\":\"" + Info.Isrecommend + "\"");
					Json.Append(",");
					Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append(",");
					Json.Append("\"Sex\":\"" + Info.Sex + "\"");
					Json.Append(",");
					Json.Append("\"Nation\":\"" + Info.Nation + "\"");
					Json.Append(",");
					Json.Append("\"mobilephone\":\"" + Info.mobilephone + "\"");
					Json.Append(",");
					Json.Append("\"Telephone\":\"" + Info.Telephone + "\"");
					Json.Append(",");
					Json.Append("\"Email\":\"" + Info.Email + "\"");
					Json.Append(",");
					Json.Append("\"QQ\":\"" + Info.QQ + "\"");
					Json.Append(",");
					Json.Append("\"Zipcode\":\"" + Info.Zipcode + "\"");
					Json.Append(",");
					Json.Append("\"Address\":\"" + Info.Address + "\"");
					Json.Append(",");
					Json.Append("\"appreciation\":\"" + Info.appreciation + "\"");
					Json.Append(",");
					Json.Append("\"website\":\"" + Info.website + "\"");
					Json.Append(",");
					Json.Append("\"Reward\":\"" + Info.Reward + "\"");
					Json.Append(",");
					Json.Append("\"BirthDay\":\"" + Info.BirthDay + "\"");
					Json.Append(",");
					Json.Append("\"state\":\"" + Info.state + "\"");
					Json.Append(",");
					Json.Append("\"state1\":\"" + Info.state1 + "\"");
					Json.Append(",");
					Json.Append("\"hit\":\"" + Info.hit + "\"");
					Json.Append(",");
					Json.Append("\"rank\":\"" + Info.rank + "\"");
					Json.Append(",");
					Json.Append("\"VCode\":\"" + Info.VCode + "\"");
					Json.Append(",");
					Json.Append("\"VTime\":\"" + Info.VTime + "\"");
					Json.Append("}");
					if(Info != masterInfo.Last())
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
		public static string MiniUiForSingeDataToJson(master Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"Id\":\"" + Info.Id + "\"");
					Json.Append(",");
					Json.Append("\"Username\":\"" + Info.Username + "\"");
					Json.Append(",");
					Json.Append("\"Password\":\"" + Info.Password + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Introduction\":\"" + Info.Introduction + "\"");
					Json.Append(",");
					Json.Append("\"Isrecommend\":\"" + Info.Isrecommend + "\"");
					Json.Append(",");
					Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
					Json.Append(",");
					Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
					Json.Append(",");
					Json.Append("\"Sex\":\"" + Info.Sex + "\"");
					Json.Append(",");
					Json.Append("\"Nation\":\"" + Info.Nation + "\"");
					Json.Append(",");
					Json.Append("\"mobilephone\":\"" + Info.mobilephone + "\"");
					Json.Append(",");
					Json.Append("\"Telephone\":\"" + Info.Telephone + "\"");
					Json.Append(",");
					Json.Append("\"Email\":\"" + Info.Email + "\"");
					Json.Append(",");
					Json.Append("\"QQ\":\"" + Info.QQ + "\"");
					Json.Append(",");
					Json.Append("\"Zipcode\":\"" + Info.Zipcode + "\"");
					Json.Append(",");
					Json.Append("\"Address\":\"" + Info.Address + "\"");
					Json.Append(",");
					Json.Append("\"appreciation\":\"" + Info.appreciation + "\"");
					Json.Append(",");
					Json.Append("\"website\":\"" + Info.website + "\"");
					Json.Append(",");
					Json.Append("\"Reward\":\"" + Info.Reward + "\"");
					Json.Append(",");
					Json.Append("\"BirthDay\":\"" + Info.BirthDay + "\"");
					Json.Append(",");
					Json.Append("\"state\":\"" + Info.state + "\"");
					Json.Append(",");
					Json.Append("\"state1\":\"" + Info.state1 + "\"");
					Json.Append(",");
					Json.Append("\"hit\":\"" + Info.hit + "\"");
					Json.Append(",");
					Json.Append("\"rank\":\"" + Info.rank + "\"");
					Json.Append(",");
					Json.Append("\"VCode\":\"" + Info.VCode + "\"");
					Json.Append(",");
					Json.Append("\"VTime\":\"" + Info.VTime + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
