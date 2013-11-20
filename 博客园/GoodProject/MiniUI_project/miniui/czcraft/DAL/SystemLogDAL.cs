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
 *  创建时间: 2012/4/25 20:21:09
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///SystemLog表DAL
	 ///</summary>
	public partial class SystemLogDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加SystemLog
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
        public long AddNew(SystemLog model)
		{
			string sql="insert into SystemLog(Title,AddTime,Url,UserName) output inserted.Id values(@Title,@AddTime,@Url,@UserName)";
            long id = (long)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("Title",model.Title)
						,(DbParameter)new SqlParameter("AddTime",model.AddTime)
						,(DbParameter)new SqlParameter("Url",model.Url)
						,(DbParameter)new SqlParameter("UserName",model.UserName)
			);
			return id;
		}
		/// <summary>
		/// 更新SystemLog实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(SystemLog model)
		{
			string sql="update SystemLog set Title=@Title,AddTime=@AddTime,Url=@Url,UserName=@UserName where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("Title",model.Title)
						,(DbParameter)new SqlParameter("AddTime",model.AddTime)
						,(DbParameter)new SqlParameter("Url",model.Url)
						,(DbParameter)new SqlParameter("UserName",model.UserName)
			);
		}
		/// <summary>
		/// 删除SystemLog
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from SystemLog where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除SystemLog
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from SystemLog where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static SystemLog ToModel(DataRow row)
		{
			SystemLog model=new SystemLog();
			model.Id =row.IsNull("Id")?null:(System.Int64?)row["Id"];
			model.Title =row.IsNull("Title")?null:(System.String)row["Title"];
			model.AddTime =row.IsNull("AddTime")?null:(System.DateTime?)row["AddTime"];
			model.Url =row.IsNull("Url")?null:(System.String)row["Url"];
			model.UserName =row.IsNull("UserName")?null:(System.String)row["UserName"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public SystemLog Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from SystemLog where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			SystemLog model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<SystemLog> ListAll()
		{
			List<SystemLog> list=new List<SystemLog>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from SystemLog");
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
		public IEnumerable<SystemLog> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<SystemLog> list=new List<SystemLog>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from SystemLog"+strWhere);
		}
	}
}
