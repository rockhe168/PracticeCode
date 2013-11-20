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
 *  创建时间: 2012/4/13 19:36:03
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///ourinfo表DAL
	 ///</summary>
	public partial class ourinfoDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加ourinfo
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(ourinfo model)
		{
			string sql="insert into ourinfo(Name,Introduction,Representative,Website,mobilephone,Telephone,Email,qq,Zipcode,Address) output inserted.id values(@Name,@Introduction,@Representative,@Website,@mobilephone,@Telephone,@Email,@qq,@Zipcode,@Address)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Introduction",model.Introduction)
						,(DbParameter)new SqlParameter("Representative",model.Representative)
						,(DbParameter)new SqlParameter("Website",model.Website)
						,(DbParameter)new SqlParameter("mobilephone",model.mobilephone)
						,(DbParameter)new SqlParameter("Telephone",model.Telephone)
						,(DbParameter)new SqlParameter("Email",model.Email)
						,(DbParameter)new SqlParameter("qq",model.qq)
						,(DbParameter)new SqlParameter("Zipcode",model.Zipcode)
						,(DbParameter)new SqlParameter("Address",model.Address)
			);
			return id;
		}
		/// <summary>
		/// 更新ourinfo实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(ourinfo model)
		{
			string sql="update ourinfo set Name=@Name,Introduction=@Introduction,Representative=@Representative,Website=@Website,mobilephone=@mobilephone,Telephone=@Telephone,Email=@Email,qq=@qq,Zipcode=@Zipcode,Address=@Address where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Introduction",model.Introduction)
						,(DbParameter)new SqlParameter("Representative",model.Representative)
						,(DbParameter)new SqlParameter("Website",model.Website)
						,(DbParameter)new SqlParameter("mobilephone",model.mobilephone)
						,(DbParameter)new SqlParameter("Telephone",model.Telephone)
						,(DbParameter)new SqlParameter("Email",model.Email)
						,(DbParameter)new SqlParameter("qq",model.qq)
						,(DbParameter)new SqlParameter("Zipcode",model.Zipcode)
						,(DbParameter)new SqlParameter("Address",model.Address)
			);
		}
		/// <summary>
		/// 删除ourinfo
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from ourinfo where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除ourinfo
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from ourinfo where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static ourinfo ToModel(DataRow row)
		{
			ourinfo model=new ourinfo();
			model.Id =row.IsNull("Id")?null:(System.Int32?)row["Id"];
			model.Name =row.IsNull("Name")?null:(System.String)row["Name"];
			model.Introduction =row.IsNull("Introduction")?null:(System.String)row["Introduction"];
			model.Representative =row.IsNull("Representative")?null:(System.String)row["Representative"];
			model.Website =row.IsNull("Website")?null:(System.String)row["Website"];
			model.mobilephone =row.IsNull("mobilephone")?null:(System.String)row["mobilephone"];
			model.Telephone =row.IsNull("Telephone")?null:(System.String)row["Telephone"];
			model.Email =row.IsNull("Email")?null:(System.String)row["Email"];
			model.qq =row.IsNull("qq")?null:(System.String)row["qq"];
			model.Zipcode =row.IsNull("Zipcode")?null:(System.String)row["Zipcode"];
			model.Address =row.IsNull("Address")?null:(System.String)row["Address"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public ourinfo Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from ourinfo where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			ourinfo model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<ourinfo> ListAll()
		{
			List<ourinfo> list=new List<ourinfo>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from ourinfo");
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
		public IEnumerable<ourinfo> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<ourinfo> list=new List<ourinfo>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from ourinfo"+strWhere);
		}
	}
}
