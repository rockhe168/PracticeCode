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
 *  创建时间: 2012/5/1 11:06:01
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///product表DAL
	 ///</summary>
	public partial class productDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();

	
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static product ToModel(DataRow row)
		{
			product model=new product();
			model.Id =row.IsNull("Id")?null:(System.Int64?)row["Id"];
			model.Name =row.IsNull("Name")?null:(System.String)row["Name"];
			model.Simplename =row.IsNull("Simplename")?null:(System.String)row["Simplename"];
			model.Explain =row.IsNull("Explain")?null:(System.String)row["Explain"];
			model.Picturepath =row.IsNull("Picturepath")?null:(System.String)row["Picturepath"];
			model.Flashpath =row.IsNull("Flashpath")?null:(System.String)row["Flashpath"];
			model.Material =row.IsNull("Material")?null:(System.String)row["Material"];
			model.Weight =row.IsNull("Weight")?null:(System.String)row["Weight"];
			model.Volume =row.IsNull("Volume")?null:(System.String)row["Volume"];
			model.Specification =row.IsNull("Specification")?null:(System.String)row["Specification"];
			model.Model =row.IsNull("Model")?null:(System.String)row["Model"];
			model.Issell =row.IsNull("Issell")?null:(System.String)row["Issell"];
			model.Isexcellent =row.IsNull("Isexcellent")?null:(System.String)row["Isexcellent"];
			model.Nongenetic =row.IsNull("Nongenetic")?null:(System.String)row["Nongenetic"];
			model.Isrecomment =row.IsNull("Isrecomment")?null:(System.String)row["Isrecomment"];
			model.Isshow =row.IsNull("Isshow")?null:(System.String)row["Isshow"];
			model.Typeid =row.IsNull("Typeid")?null:(System.Int32?)row["Typeid"];
			model.Belongstype =row.IsNull("Belongstype")?null:(System.Int32?)row["Belongstype"];
			model.Masterid =row.IsNull("Masterid")?null:(System.Int32?)row["Masterid"];
			model.Companyid =row.IsNull("Companyid")?null:(System.Int32?)row["Companyid"];
			model.Num =row.IsNull("Num")?null:(System.Int64?)row["Num"];
			model.Soldnum =row.IsNull("Soldnum")?null:(System.Int64?)row["Soldnum"];
			model.Lsprice =row.IsNull("Lsprice")?null:(System.Double?)row["Lsprice"];
			model.Pfprice =row.IsNull("Pfprice")?null:(System.Double?)row["Pfprice"];
			model.Vipprice =row.IsNull("Vipprice")?null:(System.Double?)row["Vipprice"];
			model.MarketPrice =row.IsNull("MarketPrice")?null:(System.Double?)row["MarketPrice"];
			model.Price1 =row.IsNull("Price1")?null:(System.Double?)row["Price1"];
			model.Price2 =row.IsNull("Price2")?null:(System.Double?)row["Price2"];
			model.Price3 =row.IsNull("Price3")?null:(System.Double?)row["Price3"];
			model.Price4 =row.IsNull("Price4")?null:(System.Double?)row["Price4"];
			model.hit =row.IsNull("hit")?null:(System.Int64?)row["hit"];
			model.rank =row.IsNull("rank")?null:(System.Int64?)row["rank"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public product Get(long id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from product where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			product model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<product> ListAll()
		{
			List<product> list=new List<product>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from product");
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
		public IEnumerable<product> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<product> list=new List<product>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from product"+strWhere);
		}
	}
}
