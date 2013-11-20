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
    #region web
    ///<summary>
    ///WEB_USER表DAL
    ///</summary>
    public partial class WEB_USERDAL
    {
        DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
        /// <summary>
        /// 增加WEB_USER
        /// </summary>
        /// <param name="model">tableName实体</param>
        /// <returns>执行状态</returns>
        public int AddNew(WEB_USER model)
        {
            string sql = "insert into WEB_USER(LOGNAME,PASSWORD,REALNAME,USERGROUPID,STATE,REG_DATE,LAST_LOG_DATE,LOG_TIMES,MEMO) output inserted.ID values(@LOGNAME,@PASSWORD,@REALNAME,@USERGROUPID,@STATE,@REG_DATE,@LAST_LOG_DATE,@LOG_TIMES,@MEMO)";
            int id = (int)SqlHelper.ExecuteScalar(sql
                        , (DbParameter)new SqlParameter("LOGNAME", model.LOGNAME)
                        , (DbParameter)new SqlParameter("PASSWORD", model.PASSWORD)
                        , (DbParameter)new SqlParameter("REALNAME", model.REALNAME)
                        , (DbParameter)new SqlParameter("USERGROUPID", model.GROUP.ID)
                        , (DbParameter)new SqlParameter("STATE", model.STATE)
                        , (DbParameter)new SqlParameter("REG_DATE", model.REG_DATE)
                        , (DbParameter)new SqlParameter("LAST_LOG_DATE", model.LAST_LOG_DATE)
                        , (DbParameter)new SqlParameter("LOG_TIMES", model.LOG_TIMES)
                        , (DbParameter)new SqlParameter("MEMO", model.MEMO)
            );
            return id;
        } 
    #endregion
		/// <summary>
		/// 更新WEB_USER实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(WEB_USER model)
		{
			string sql="update WEB_USER set LOGNAME=@LOGNAME,PASSWORD=@PASSWORD,REALNAME=@REALNAME,USERGROUPID=@USERGROUPID,STATE=@STATE,REG_DATE=@REG_DATE,LAST_LOG_DATE=@LAST_LOG_DATE,LOG_TIMES=@LOG_TIMES,MEMO=@MEMO where ID=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("LOGNAME",model.LOGNAME)
						,(DbParameter)new SqlParameter("PASSWORD",model.PASSWORD)
						,(DbParameter)new SqlParameter("REALNAME",model.REALNAME)
                        , (DbParameter)new SqlParameter("USERGROUPID", model.GROUP.ID)
						,(DbParameter)new SqlParameter("STATE",model.STATE)
						,(DbParameter)new SqlParameter("REG_DATE",model.REG_DATE)
						,(DbParameter)new SqlParameter("LAST_LOG_DATE",model.LAST_LOG_DATE)
						,(DbParameter)new SqlParameter("LOG_TIMES",model.LOG_TIMES)
						,(DbParameter)new SqlParameter("MEMO",model.MEMO)
                        , (DbParameter)new SqlParameter("id", model.ID)
			);
		}
		/// <summary>
		/// 删除WEB_USER
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from WEB_USER where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
        /// <summary>
        /// 删除WEB_USER
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from WEB_USER where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static WEB_USER ToModel(DataRow row)
		{
			WEB_USER model=new WEB_USER();
			model.LOGNAME =row.IsNull("LOGNAME")?null:(System.String)row["LOGNAME"];
			model.PASSWORD =row.IsNull("PASSWORD")?null:(System.String)row["PASSWORD"];
			model.REALNAME =row.IsNull("REALNAME")?null:(System.String)row["REALNAME"];
            //model.USERGROUPID =row.IsNull("USERGROUPID")?null:(WEB_USERGROUP)row["USERGROUPID"];
           model.GROUP=new WEB_USERGROUPDAL().Get((int)row["USERGROUPID"]);
			model.STATE =row.IsNull("STATE")?null:(System.String)row["STATE"];
			model.REG_DATE =row.IsNull("REG_DATE")?null:(System.DateTime?)row["REG_DATE"];
			model.LAST_LOG_DATE =row.IsNull("LAST_LOG_DATE")?null:(System.DateTime?)row["LAST_LOG_DATE"];
			model.LOG_TIMES =row.IsNull("LOG_TIMES")?null:(System.Int32?)row["LOG_TIMES"];
			model.MEMO =row.IsNull("MEMO")?null:(System.String)row["MEMO"];
			model.ID =row.IsNull("ID")?null:(System.Int32?)row["ID"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public WEB_USER Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from WEB_USER where ID=@ID",
(DbParameter)new SqlParameter("ID", id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			WEB_USER model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<WEB_USER> ListAll()
		{
			List<WEB_USER> list=new List<WEB_USER>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from WEB_USER");
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
		public IEnumerable<WEB_USER> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<WEB_USER> list=new List<WEB_USER>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from WEB_USER"+strWhere);
		}
	}
}
