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
	 ///WEB_USERGROUP表DAL
	 ///</summary>
	public partial class WEB_USERGROUPDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加WEB_USERGROUP
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(WEB_USERGROUP model)
		{
			string sql="insert into WEB_USERGROUP(USERGROUP,DESCRIPTION) output inserted.id values(@USERGROUP,@DESCRIPTION)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("USERGROUP",model.USERGROUP)
						,(DbParameter)new SqlParameter("DESCRIPTION",model.DESCRIPTION)
			);
			return id;
		}
		/// <summary>
		/// 更新WEB_USERGROUP实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(WEB_USERGROUP model)
		{
			string sql="update WEB_USERGROUP set USERGROUP=@USERGROUP,DESCRIPTION=@DESCRIPTION where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("USERGROUP",model.USERGROUP)
						,(DbParameter)new SqlParameter("DESCRIPTION",model.DESCRIPTION)
						,(DbParameter)new SqlParameter("ID",model.ID)
			);
		}
		/// <summary>
		/// 删除WEB_USERGROUP
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
            bool status = false;
            SqlHelper.Open();
            SqlHelper.BeginTrans();

            if (SqlHelper.ExecuteNonQuery("delete from WEB_USERGROUP_FUNCTIONS where USERGROUPID=@id;delete from WEB_USERGROUP where ID=@id",
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
        /// 删除WEB_USERGROUP
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
		{

            bool status = false;
            string[] IDs = strID.Split(',');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < IDs.Length; i++)
                sb.Append("delete from WEB_USERGROUP_FUNCTIONS where USERGROUPID=" + IDs[i] + ";");
            sb.Append("delete from WEB_USERGROUP where ID in (" + strID + ")");
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
		private static WEB_USERGROUP ToModel(DataRow row)
		{
			WEB_USERGROUP model=new WEB_USERGROUP();
			model.USERGROUP =row.IsNull("USERGROUP")?null:(System.String)row["USERGROUP"];
			model.DESCRIPTION =row.IsNull("DESCRIPTION")?null:(System.String)row["DESCRIPTION"];
			model.ID =row.IsNull("ID")?null:(System.Int32?)row["ID"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public WEB_USERGROUP Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from WEB_USERGROUP where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			WEB_USERGROUP model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<WEB_USERGROUP> ListAll()
		{
			List<WEB_USERGROUP> list=new List<WEB_USERGROUP>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from WEB_USERGROUP");
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
		public IEnumerable<WEB_USERGROUP> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<WEB_USERGROUP> list=new List<WEB_USERGROUP>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from WEB_USERGROUP"+strWhere);
		}
	}
}
