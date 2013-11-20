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
 *  创建时间: 2012/4/10 9:26:55
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///VGroupFunction表DAL
	 ///</summary>
	public partial class VGroupFunctionDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加VGroupFunction
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(VGroupFunction model)
		{
			string sql="insert into VGroupFunction(NAME,function_state,group_function_state,DESCRIPTION,USERGROUPID,FUNTION_ID) output inserted.id values(@NAME,@function_state,@group_function_state,@DESCRIPTION,@USERGROUPID,@FUNTION_ID)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("NAME",model.NAME)
						,(DbParameter)new SqlParameter("function_state",model.function_state)
						,(DbParameter)new SqlParameter("group_function_state",model.group_function_state)
						,(DbParameter)new SqlParameter("DESCRIPTION",model.DESCRIPTION)
						,(DbParameter)new SqlParameter("USERGROUPID",model.USERGROUPID)
						,(DbParameter)new SqlParameter("FUNTION_ID",model.FUNTION_ID)
			);
			return id;
		}
		/// <summary>
		/// 更新VGroupFunction实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VGroupFunction model)
		{
			string sql="update VGroupFunction set NAME=@NAME,function_state=@function_state,group_function_state=@group_function_state,DESCRIPTION=@DESCRIPTION,USERGROUPID=@USERGROUPID,FUNTION_ID=@FUNTION_ID where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("NAME",model.NAME)
						,(DbParameter)new SqlParameter("function_state",model.function_state)
						,(DbParameter)new SqlParameter("group_function_state",model.group_function_state)
						,(DbParameter)new SqlParameter("DESCRIPTION",model.DESCRIPTION)
						,(DbParameter)new SqlParameter("USERGROUPID",model.USERGROUPID)
						,(DbParameter)new SqlParameter("ID",model.ID)
						,(DbParameter)new SqlParameter("FUNTION_ID",model.FUNTION_ID)
			);
		}
		/// <summary>
		/// 删除VGroupFunction
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from VGroupFunction where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除VGroupFunction
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from VGroupFunction where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static VGroupFunction ToModel(DataRow row)
		{
			VGroupFunction model=new VGroupFunction();
			model.NAME =row.IsNull("NAME")?null:(System.String)row["NAME"];
			model.function_state =row.IsNull("function_state")?null:(System.String)row["function_state"];
			model.group_function_state =row.IsNull("group_function_state")?null:(System.String)row["group_function_state"];
			model.DESCRIPTION =row.IsNull("DESCRIPTION")?null:(System.String)row["DESCRIPTION"];
			model.USERGROUPID =row.IsNull("USERGROUPID")?null:(System.Int32?)row["USERGROUPID"];
			model.ID =row.IsNull("ID")?null:(System.Int32?)row["ID"];
			model.FUNTION_ID =row.IsNull("FUNTION_ID")?null:(System.Int32?)row["FUNTION_ID"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VGroupFunction Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VGroupFunction where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			VGroupFunction model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VGroupFunction> ListAll()
		{
			List<VGroupFunction> list=new List<VGroupFunction>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VGroupFunction");
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
		public IEnumerable<VGroupFunction> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<VGroupFunction> list=new List<VGroupFunction>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from VGroupFunction"+strWhere);
		}
	}
}
