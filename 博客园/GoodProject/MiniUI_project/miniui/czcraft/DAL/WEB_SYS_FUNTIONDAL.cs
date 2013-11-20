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
	 ///WEB_SYS_FUNTION表DAL
	 ///</summary>
    public partial class WEB_SYS_FUNTIONDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加WEB_SYS_FUNTION
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(WEB_SYS_FUNTION model)
		{
			string sql="insert into WEB_SYS_FUNTION(NAME,URL,FATHER_ID,STATE,DESCRIPTION) output inserted.FUNTION_ID values(@NAME,@URL,@FATHER_ID,@STATE,@DESCRIPTION)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("NAME",model.NAME)
						,(DbParameter)new SqlParameter("URL",model.URL)
						,(DbParameter)new SqlParameter("FATHER_ID",model.FATHER_ID)
						,(DbParameter)new SqlParameter("STATE",model.STATE)
						,(DbParameter)new SqlParameter("DESCRIPTION",model.DESCRIPTION)
			);
			return id;
		}
		/// <summary>
		/// 更新WEB_SYS_FUNTION实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(WEB_SYS_FUNTION model)
		{
            string sql = "update WEB_SYS_FUNTION set NAME=@NAME,URL=@URL,FATHER_ID=@FATHER_ID,STATE=@STATE,DESCRIPTION=@DESCRIPTION where FUNTION_ID=@FUNTION_ID";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("NAME",model.NAME)
						,(DbParameter)new SqlParameter("URL",model.URL)
						,(DbParameter)new SqlParameter("FATHER_ID",model.FATHER_ID)
						,(DbParameter)new SqlParameter("STATE",model.STATE)
                        , (DbParameter)new SqlParameter("DESCRIPTION", model.DESCRIPTION)    , (DbParameter)new SqlParameter("FUNTION_ID", model.FUNTION_ID)
			);
		}
		/// <summary>
		/// 删除WEB_SYS_FUNTION
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
            bool status = false;
            SqlHelper.Open();
            SqlHelper.BeginTrans();

            if (SqlHelper.ExecuteNonQuery("delete from WEB_USERGROUP_FUNCTIONS where FUNCTION_ID=@id;delete from WEB_SYS_FUNTION where FUNTION_ID=@id",
                            (DbParameter)new SqlParameter("id", id)))
            {
                SqlHelper.CommitTrans();
                status = true;
            }
            else
            {

                SqlHelper.RollbackTrans();
                status = false;
            }
            SqlHelper.Close();
            return status;
		}
        /// <summary>
        /// 删除WEB_SYS_FUNTION
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
		{

            bool status = false;
            string[] IDs = strID.Split(',');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < IDs.Length; i++)
                sb.Append("delete from WEB_USERGROUP_FUNCTIONS where FUNCTION_ID=" + IDs[i] + ";");
            sb.Append("delete from WEB_SYS_FUNTION where FUNCTION_ID in (" + strID + ")");
            SqlHelper.Open();
            SqlHelper.BeginTrans();
            if (SqlHelper.ExecuteNonQuery(sb.ToString()))
            {
                status = true;
                SqlHelper.CommitTrans();
            }
            else
            {
                status = false;
                SqlHelper.RollbackTrans();
            }

            return status;
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static WEB_SYS_FUNTION ToModel(DataRow row)
		{
			WEB_SYS_FUNTION model=new WEB_SYS_FUNTION();
			model.FUNTION_ID =row.IsNull("FUNTION_ID")?null:(System.Int32?)row["FUNTION_ID"];
			model.NAME =row.IsNull("NAME")?null:(System.String)row["NAME"];
			model.URL =row.IsNull("URL")?null:(System.String)row["URL"];
			model.FATHER_ID =row.IsNull("FATHER_ID")?null:(System.Int32?)row["FATHER_ID"];
			model.STATE =row.IsNull("STATE")?null:(System.String)row["STATE"];
			model.DESCRIPTION =row.IsNull("DESCRIPTION")?null:(System.String)row["DESCRIPTION"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public WEB_SYS_FUNTION Get(int id)
		{
            DataTable dt = SqlHelper.ExecuteDataTable("select * from WEB_SYS_FUNTION where FUNTION_ID=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			WEB_SYS_FUNTION model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<WEB_SYS_FUNTION> ListAll()
		{
			List<WEB_SYS_FUNTION> list=new List<WEB_SYS_FUNTION>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from WEB_SYS_FUNTION");
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
		public IEnumerable<WEB_SYS_FUNTION> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<WEB_SYS_FUNTION> list=new List<WEB_SYS_FUNTION>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from WEB_SYS_FUNTION"+strWhere);
		}
	}
}
