using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/14 15:17:39
 *  类说明: czcraft.BLL
 */ 
{
	public partial class master_certBLL
	{
		/// <summary>
		/// 增加master_cert
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public long AddNew(master_cert model)
		{
			return new master_certDAL().AddNew(model);
		}

		/// <summary>
		/// 更新master_cert实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(master_cert model)
		{
			return new master_certDAL().Update(model);
		}
		/// <summary>
		/// 根据id获取master_cert实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public master_cert Get(long id)
		{
			return new master_certDAL().Get(id);
		}
		/// <summary>
		/// 列出master_cert所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<master_cert>ListAll()
		{
			return new master_certDAL().ListAll();
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<master_cert> ListByPagination(string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			return new master_certDAL().ListByPagination("master_cert", "", "*", sortId, PageSize, PageIndex, OrderType, strWhere);
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		public int GetCount(string strWhere)
		{
			return new master_certDAL().GetCount(strWhere);
		}
		/// <summary>
		/// 专门生成为MiniUi生成json数据(List->json)
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="list">实现了Ilist接口的list</param>
		/// <param name="total">记录总数</param>
		/// <param name="paramMaxMin">这里放排序的参数例如,string para=""maxAge":37,"avgAge":27,"minAge":24"</param>
		/// <returns>返回json数据</returns>
		public static string MiniUiListToJson(IEnumerable<master_cert> master_certInfo, int total, string paramMaxMinAvg)
		{
			StringBuilder Json = new StringBuilder();
			Json.Append("{\"total\":"+total+",\"data\":");
			Json.Append("[");
				foreach (master_cert Info in master_certInfo)
				{
					Json.Append("{");
					Json.Append("\"id\":\"" + Info.id + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Picpath\":\"" + Info.Picpath + "\"");
					Json.Append(",");
					Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
					Json.Append("}");
					if(Info != master_certInfo.Last())
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
		public static string MiniUiForSingeDataToJson(master_cert Info)
		{
			StringBuilder Json = new StringBuilder();
					Json.Append("{");
					Json.Append("\"id\":\"" + Info.id + "\"");
					Json.Append(",");
					Json.Append("\"Name\":\"" + Info.Name + "\"");
					Json.Append(",");
					Json.Append("\"Picpath\":\"" + Info.Picpath + "\"");
					Json.Append(",");
					Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
					Json.Append("}");
			return Json.ToString();
		}
	}
}
