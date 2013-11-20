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
 *  创建时间: 2012/4/13 0:30:07
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///craftknowledge表DAL
	 ///</summary>
	public partial class craftknowledgeDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加craftknowledge
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(craftknowledge model)
		{
			string sql="insert into craftknowledge(Crafttype,Typeid,Title,Content,Time,ArticleHtmlUrl) output inserted.id values(@Crafttype,@Typeid,@Title,@Content,@Time,@ArticleHtmlUrl)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("Crafttype",model.Crafttype)
						,(DbParameter)new SqlParameter("Typeid",model.type.ID)
						,(DbParameter)new SqlParameter("Title",model.Title)
						,(DbParameter)new SqlParameter("Content",model.Content)
						,(DbParameter)new SqlParameter("Time",model.Time)
						,(DbParameter)new SqlParameter("ArticleHtmlUrl",model.ArticleHtmlUrl)
			);
			return id;
		}
		/// <summary>
		/// 更新craftknowledge实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(craftknowledge model)
		{
			string sql="update craftknowledge set Crafttype=@Crafttype,Typeid=@Typeid,Title=@Title,Content=@Content,Time=@Time,ArticleHtmlUrl=@ArticleHtmlUrl where ID=@ID";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("ID",model.Id)
						,(DbParameter)new SqlParameter("Crafttype",model.Crafttype)
						,(DbParameter)new SqlParameter("Typeid",model.type.ID)
						,(DbParameter)new SqlParameter("Title",model.Title)
						,(DbParameter)new SqlParameter("Content",model.Content)
						,(DbParameter)new SqlParameter("Time",model.Time)
						,(DbParameter)new SqlParameter("ArticleHtmlUrl",model.ArticleHtmlUrl)
			);
		}
		/// <summary>
		/// 删除craftknowledge
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from craftknowledge where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除craftknowledge
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from craftknowledge where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static craftknowledge ToModel(DataRow row)
		{
			craftknowledge model=new craftknowledge();
			model.Id =row.IsNull("Id")?null:(System.Int32?)row["Id"];
			model.Crafttype =row.IsNull("Crafttype")?null:(System.String)row["Crafttype"];
			model.type =row.IsNull("Typeid")?null:new crafttypeDAL().Get((int)row["Typeid"]);
			model.Title =row.IsNull("Title")?null:(System.String)row["Title"];
			model.Content =row.IsNull("Content")?null:(System.String)row["Content"];
			model.Time =row.IsNull("Time")?null:(System.DateTime?)row["Time"];
			model.ArticleHtmlUrl =row.IsNull("ArticleHtmlUrl")?null:(System.String)row["ArticleHtmlUrl"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public craftknowledge Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from craftknowledge where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			craftknowledge model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<craftknowledge> ListAll()
		{
			List<craftknowledge> list=new List<craftknowledge>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from craftknowledge");
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
		public IEnumerable<craftknowledge> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<craftknowledge> list=new List<craftknowledge>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from craftknowledge"+strWhere);
		}
	}
}
