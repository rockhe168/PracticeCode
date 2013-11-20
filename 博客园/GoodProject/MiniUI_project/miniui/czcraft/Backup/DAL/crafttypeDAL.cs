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
 *  创建时间: 2012/4/11 15:10:17
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///crafttype表DAL
	 ///</summary>
	public partial class crafttypeDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加crafttype
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(crafttype model)
		{
            string sql = "insert into crafttype(Name,level,Belongsid,IsLeaf,FId) output inserted.ID values(@Name,@level,@Belongsid,@IsLeaf,@FId)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("level",model.level)
						,(DbParameter)new SqlParameter("Belongsid",model.Belongsid)
						,(DbParameter)new SqlParameter("IsLeaf",model.IsLeaf)
			,(DbParameter)new SqlParameter("FId",model.Belongsid));
           
           
			return id;
		}
       
		/// <summary>
		/// 更新crafttype实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(crafttype model)
		{
			string sql="update crafttype set Name=@Name,level=@level,Belongsid=@Belongsid,IsLeaf=@IsLeaf where ID=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("ID",model.ID)
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("level",model.level)
						,(DbParameter)new SqlParameter("Belongsid",model.Belongsid)
						,(DbParameter)new SqlParameter("IsLeaf",model.IsLeaf)
			);
		}
	
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static crafttype ToModel(DataRow row)
		{
			crafttype model=new crafttype();
			model.ID =row.IsNull("ID")?null:(System.Int32?)row["ID"];
			model.Name =row.IsNull("Name")?null:(System.String)row["Name"];
			model.level =row.IsNull("level")?null:(System.Int32?)row["level"];
			model.Belongsid =row.IsNull("Belongsid")?null:(System.Int32?)row["Belongsid"];
            model.FId = row.IsNull("FId") ? null : (System.String)row["FId"];
			model.IsLeaf =row.IsNull("IsLeaf")?null:(System.String)row["IsLeaf"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public crafttype Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from crafttype where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			crafttype model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<crafttype> ListAll()
		{
			List<crafttype> list=new List<crafttype>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from crafttype");
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
		public IEnumerable<crafttype> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<crafttype> list=new List<crafttype>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from crafttype"+strWhere);
		}
	}
}
