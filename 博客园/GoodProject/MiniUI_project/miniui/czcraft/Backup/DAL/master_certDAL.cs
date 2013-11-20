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
 *  创建时间: 2012/4/14 15:17:39
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///master_cert表DAL
	 ///</summary>
	public partial class master_certDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加master_cert
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
        public long AddNew(master_cert model)
		{
			string sql="insert into master_cert(Name,Picpath,Masterid) output inserted.id values(@Name,@Picpath,@Masterid)";
            long id = (long)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Picpath",model.Picpath)
						,(DbParameter)new SqlParameter("Masterid",model.Masterid)
			);
			return id;
		}
		/// <summary>
		/// 更新master_cert实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(master_cert model)
		{
			string sql="update master_cert set Name=@Name,Picpath=@Picpath,Masterid=@Masterid where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("id",model.id)
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Picpath",model.Picpath)
						,(DbParameter)new SqlParameter("Masterid",model.Masterid)
			);
		}

		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static master_cert ToModel(DataRow row)
		{
			master_cert model=new master_cert();
			model.id =row.IsNull("id")?null:(System.Int64?)row["id"];
			model.Name =row.IsNull("Name")?null:(System.String)row["Name"];
			model.Picpath =row.IsNull("Picpath")?null:(System.String)row["Picpath"];
			model.Masterid =row.IsNull("Masterid")?null:(System.Int32?)row["Masterid"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public master_cert Get(long id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from master_cert where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			master_cert model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<master_cert> ListAll()
		{
			List<master_cert> list=new List<master_cert>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from master_cert");
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
		public IEnumerable<master_cert> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<master_cert> list=new List<master_cert>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from master_cert"+strWhere);
		}
	}
}
