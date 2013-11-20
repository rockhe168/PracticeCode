using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
namespace czcraft.DAL
/*
 *   作者: Sweet
 *  创建时间: 2012/4/29 10:43:11
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///SearchInfo表DAL
	 ///</summary>
	public partial class SearchInfoDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加SearchInfo
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
        public long AddNew(SearchInfo model)
		{
			string sql="insert into SearchInfo(Ip,[DateTime],KeyWord,SearchType) output inserted.Id values(@Ip,@DateTime,@KeyWord,@SearchType)";
            long id = (long)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("Ip",model.Ip)
						,(DbParameter)new SqlParameter("DateTime",model.DateTime.Value)
						,(DbParameter)new SqlParameter("KeyWord",model.KeyWord)
						,(DbParameter)new SqlParameter("SearchType",model.SearchType)
			);
			return id;
		}
		/// <summary>
		/// 更新SearchInfo实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(SearchInfo model)
		{
			string sql="update SearchInfo set Ip=@Ip,DateTime=@DateTime,KeyWord=@KeyWord,SearchType=@SearchType where Id=@Id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("Ip",model.Ip)
						,(DbParameter)new SqlParameter("DateTime",model.DateTime)
						,(DbParameter)new SqlParameter("KeyWord",model.KeyWord)
						,(DbParameter)new SqlParameter("SearchType",model.SearchType)
			);
		}
		/// <summary>
		/// 删除SearchInfo
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
        public bool Delete(long id)
		{
		return SqlHelper.ExecuteNonQuery("delete from SearchInfo where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除SearchInfo
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from SearchInfo where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static SearchInfo ToModel(DataRow row)
		{
			SearchInfo model=new SearchInfo();
			model.Id =row.IsNull("Id")?null:(System.Int64?)row["Id"];
			model.Ip =row.IsNull("Ip")?null:(System.String)row["Ip"];
			model.DateTime =row.IsNull("DateTime")?null:(System.DateTime?)row["DateTime"];
			model.KeyWord =row.IsNull("KeyWord")?null:(System.String)row["KeyWord"];
			model.SearchType =row.IsNull("SearchType")?null:(System.String)row["SearchType"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
        public SearchInfo Get(long id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from SearchInfo where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			SearchInfo model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<SearchInfo> ListAll()
		{
			List<SearchInfo> list=new List<SearchInfo>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from SearchInfo");
			foreach(DataRow row in dt.Rows){
			list.Add(ToModel(row));
			}
			return list;
		}

		/// <summary>
		///分页获取数据
		/// </summary>
		/// <param name="tableName">表名</param>
		/// <param name="InnerJoin">内连接</param>
		/// <param name="strGetFields">返回的列信息</param>
		 /// <param name="sortId">排序的列名</param>
		/// <param name="PageSize">每页记录数</param>
		/// <param name="PageIndex">页数</param>
		/// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
		/// <param name="strWhere">查询条件(注意: 不要加where) </param>
		public IEnumerable<SearchInfo> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<SearchInfo> list=new List<SearchInfo>();
			DataTable dt=SqlHelper.ExecuteDataTable("exec[pagination]  @tableName,@InnerJoin,@strGetFields,@sortId,@PageSize,@PageIndex,@doCount,@OrderType,@strWhere",(DbParameter)new SqlParameter("tableName",tableName),(DbParameter)new SqlParameter("@InnerJoin",InnerJoin),(DbParameter)new SqlParameter("@strGetFields",strGetFields),(DbParameter)new SqlParameter("@sortId",sortId),(DbParameter)new SqlParameter("@PageSize",PageSize),(DbParameter)new SqlParameter("@PageIndex",PageIndex),(DbParameter)new SqlParameter("@doCount","0"),(DbParameter)new SqlParameter("@OrderType",OrderType),(DbParameter)new SqlParameter("@strWhere",strWhere));
			foreach(DataRow row in dt.Rows){
			list.Add(ToModel(row));
			}
			return list;
		}
		/// <summary>
		///获取表总记录个数(不用加where)
		/// <param name="strWhere">查询条件(不用加where)</param>
		/// <summary>
		public int GetCount(string strWhere)
		{
			if(!string.IsNullOrEmpty(strWhere))
			strWhere=" where "+strWhere;
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from SearchInfo"+strWhere);
		}
	}
}
