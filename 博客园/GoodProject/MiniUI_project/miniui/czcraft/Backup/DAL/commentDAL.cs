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
 *  创建时间: 2012/5/22 9:22:31
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///comment表DAL
	 ///</summary>
	public partial class commentDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加comment
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(comment model)
		{
			string sql="insert into comment(Content,Time,Productid,huifuContent,Grade,MemberId) output inserted.Id values(@Content,@Time,@Productid,@huifuContent,@Grade,@MemberId)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("Content",model.Content)
						,(DbParameter)new SqlParameter("Time",model.Time)
						,(DbParameter)new SqlParameter("Productid",model.Productid)
						,(DbParameter)new SqlParameter("huifuContent",model.huifuContent)
						,(DbParameter)new SqlParameter("Grade",model.Grade)
						,(DbParameter)new SqlParameter("MemberId",model.MemberId)
			);
			return id;
		}
		/// <summary>
		/// 更新comment实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(comment model)
		{
			string sql="update comment set Content=@Content,Time=@Time,Productid=@Productid,huifuContent=@huifuContent,Grade=@Grade,MemberId=@MemberId where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("Content",model.Content)
						,(DbParameter)new SqlParameter("Time",model.Time)
						,(DbParameter)new SqlParameter("Productid",model.Productid)
						,(DbParameter)new SqlParameter("huifuContent",model.huifuContent)
						,(DbParameter)new SqlParameter("Grade",model.Grade)
						,(DbParameter)new SqlParameter("MemberId",model.MemberId)
			);
		}
		/// <summary>
		/// 删除comment
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from comment where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除comment
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from comment where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static comment ToModel(DataRow row)
		{
			comment model=new comment();
			model.Id =row.IsNull("Id")?null:(System.Int64?)row["Id"];
			model.Content =row.IsNull("Content")?null:(System.String)row["Content"];
			model.Time =row.IsNull("Time")?null:(System.DateTime?)row["Time"];
			model.Productid =row.IsNull("Productid")?null:(System.Int64?)row["Productid"];
			model.huifuContent =row.IsNull("huifuContent")?null:(System.String)row["huifuContent"];
			model.Grade =row.IsNull("Grade")?null:(System.Double?)row["Grade"];
			model.MemberId =row.IsNull("MemberId")?null:(System.Int32?)row["MemberId"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public comment Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from comment where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			comment model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<comment> ListAll()
		{
			List<comment> list=new List<comment>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from comment");
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
		public IEnumerable<comment> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<comment> list=new List<comment>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from comment"+strWhere);
		}
	}
}
