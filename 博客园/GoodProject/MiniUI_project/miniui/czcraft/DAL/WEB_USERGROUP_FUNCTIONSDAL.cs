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
 *  创建时间: 2012/4/7 18:46:37
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///WEB_USERGROUP_FUNCTIONS表DAL
	 ///</summary>
	public partial class WEB_USERGROUP_FUNCTIONSDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加WEB_USERGROUP_FUNCTIONS
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(WEB_USERGROUP_FUNCTIONS model)
		{
			string sql="insert into WEB_USERGROUP_FUNCTIONS(USERGROUPID,FUNCTION_ID,STATE) output inserted.ID values(@USERGROUPID,@FUNCTION_ID,@STATE)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("USERGROUPID",model.USERGROUPID)
						,(DbParameter)new SqlParameter("FUNCTION_ID",model.FUNCTION_ID)
						,(DbParameter)new SqlParameter("STATE",model.STATE)
			);
			return id;
		}
		/// <summary>
		/// 更新WEB_USERGROUP_FUNCTIONS实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(WEB_USERGROUP_FUNCTIONS model)
		{
            string sql = "update WEB_USERGROUP_FUNCTIONS set USERGROUPID=@USERGROUPID,FUNCTION_ID=@FUNCTION_ID,STATE=@STATE where ID=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("ID",model.ID)
						,(DbParameter)new SqlParameter("USERGROUPID",model.USERGROUPID)
						,(DbParameter)new SqlParameter("FUNCTION_ID",model.FUNCTION_ID)
						,(DbParameter)new SqlParameter("STATE",model.STATE)
			);
		}
		/// <summary>
		/// 删除WEB_USERGROUP_FUNCTIONS
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from WEB_USERGROUP_FUNCTIONS where ID=@id",
						(DbParameter)new SqlParameter("id",id));
		}
        /// <summary>
        /// 删除WEB_USERGROUP_FUNCTIONS
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from WEB_USERGROUP_FUNCTIONS where ID in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static WEB_USERGROUP_FUNCTIONS ToModel(DataRow row)
		{
			WEB_USERGROUP_FUNCTIONS model=new WEB_USERGROUP_FUNCTIONS();
			model.ID =row.IsNull("ID")?null:(System.Int32?)row["ID"];
			model.USERGROUPID =row.IsNull("USERGROUPID")?null:(System.Int32?)row["USERGROUPID"];
            //model.FUNTION=new WEB_SYS_FUNTIONDAL().Get((int)row["FUNCTION_ID"]);
            model.FUNCTION_ID=row.IsNull("FUNCTION_ID")?null:(System.Int32?)row["FUNCTION_ID"];
			model.STATE =row.IsNull("STATE")?null:(System.String)row["STATE"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public WEB_USERGROUP_FUNCTIONS Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from WEB_USERGROUP_FUNCTIONS where ID=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			WEB_USERGROUP_FUNCTIONS model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<WEB_USERGROUP_FUNCTIONS> ListAll()
		{
			List<WEB_USERGROUP_FUNCTIONS> list=new List<WEB_USERGROUP_FUNCTIONS>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from WEB_USERGROUP_FUNCTIONS");
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
		public IEnumerable<WEB_USERGROUP_FUNCTIONS> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<WEB_USERGROUP_FUNCTIONS> list=new List<WEB_USERGROUP_FUNCTIONS>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from WEB_USERGROUP_FUNCTIONS"+strWhere);
		}
	}
}
