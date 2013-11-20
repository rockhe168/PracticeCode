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
	 ///VFindProductInfo表DAL
	 ///</summary>
	public partial class VFindProductInfoDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加VFindProductInfo
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(VFindProductInfo model)
		{
			string sql="insert into VFindProductInfo(TypeName,Name,Simplename,Isshow,Belongstype,Num,Soldnum,hit,rank,MasterName,CompanyName,Isrecomment,Nongenetic,Isexcellent,Issell,Typeid,Masterid,Companyid,CompanyState1,CompanyState,MasterState,MasterState1) output inserted.id values(@TypeName,@Name,@Simplename,@Isshow,@Belongstype,@Num,@Soldnum,@hit,@rank,@MasterName,@CompanyName,@Isrecomment,@Nongenetic,@Isexcellent,@Issell,@Typeid,@Masterid,@Companyid,@CompanyState1,@CompanyState,@MasterState,@MasterState1)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("TypeName",model.TypeName)
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Simplename",model.Simplename)
						,(DbParameter)new SqlParameter("Isshow",model.Isshow)
						,(DbParameter)new SqlParameter("Belongstype",model.Belongstype)
						,(DbParameter)new SqlParameter("Num",model.Num)
						,(DbParameter)new SqlParameter("Soldnum",model.Soldnum)
						,(DbParameter)new SqlParameter("hit",model.hit)
						,(DbParameter)new SqlParameter("rank",model.rank)
						,(DbParameter)new SqlParameter("MasterName",model.MasterName)
						,(DbParameter)new SqlParameter("CompanyName",model.CompanyName)
						,(DbParameter)new SqlParameter("Isrecomment",model.Isrecomment)
						,(DbParameter)new SqlParameter("Nongenetic",model.Nongenetic)
						,(DbParameter)new SqlParameter("Isexcellent",model.Isexcellent)
						,(DbParameter)new SqlParameter("Issell",model.Issell)
						,(DbParameter)new SqlParameter("Typeid",model.Typeid)
						,(DbParameter)new SqlParameter("Masterid",model.Masterid)
						,(DbParameter)new SqlParameter("Companyid",model.Companyid)
						,(DbParameter)new SqlParameter("CompanyState1",model.CompanyState1)
						,(DbParameter)new SqlParameter("CompanyState",model.CompanyState)
						,(DbParameter)new SqlParameter("MasterState",model.MasterState)
						,(DbParameter)new SqlParameter("MasterState1",model.MasterState1)
			);
			return id;
		}
		/// <summary>
		/// 更新VFindProductInfo实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VFindProductInfo model)
		{
			string sql="update VFindProductInfo set TypeName=@TypeName,Name=@Name,Simplename=@Simplename,Isshow=@Isshow,Belongstype=@Belongstype,Num=@Num,Soldnum=@Soldnum,hit=@hit,rank=@rank,MasterName=@MasterName,CompanyName=@CompanyName,Isrecomment=@Isrecomment,Nongenetic=@Nongenetic,Isexcellent=@Isexcellent,Issell=@Issell,Typeid=@Typeid,Masterid=@Masterid,Companyid=@Companyid,CompanyState1=@CompanyState1,CompanyState=@CompanyState,MasterState=@MasterState,MasterState1=@MasterState1 where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("TypeName",model.TypeName)
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Simplename",model.Simplename)
						,(DbParameter)new SqlParameter("Isshow",model.Isshow)
						,(DbParameter)new SqlParameter("Belongstype",model.Belongstype)
						,(DbParameter)new SqlParameter("Num",model.Num)
						,(DbParameter)new SqlParameter("Soldnum",model.Soldnum)
						,(DbParameter)new SqlParameter("hit",model.hit)
						,(DbParameter)new SqlParameter("rank",model.rank)
						,(DbParameter)new SqlParameter("MasterName",model.MasterName)
						,(DbParameter)new SqlParameter("CompanyName",model.CompanyName)
						,(DbParameter)new SqlParameter("Isrecomment",model.Isrecomment)
						,(DbParameter)new SqlParameter("Nongenetic",model.Nongenetic)
						,(DbParameter)new SqlParameter("Isexcellent",model.Isexcellent)
						,(DbParameter)new SqlParameter("Issell",model.Issell)
						,(DbParameter)new SqlParameter("Typeid",model.Typeid)
						,(DbParameter)new SqlParameter("Masterid",model.Masterid)
						,(DbParameter)new SqlParameter("Companyid",model.Companyid)
						,(DbParameter)new SqlParameter("CompanyState1",model.CompanyState1)
						,(DbParameter)new SqlParameter("CompanyState",model.CompanyState)
						,(DbParameter)new SqlParameter("MasterState",model.MasterState)
						,(DbParameter)new SqlParameter("MasterState1",model.MasterState1)
						,(DbParameter)new SqlParameter("Id",model.Id)
			);
		}
		/// <summary>
		/// 删除VFindProductInfo
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from VFindProductInfo where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除VFindProductInfo
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from VFindProductInfo where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static VFindProductInfo ToModel(DataRow row)
		{
			VFindProductInfo model=new VFindProductInfo();
			model.TypeName =row.IsNull("TypeName")?null:(System.String)row["TypeName"];
			model.Name =row.IsNull("Name")?null:(System.String)row["Name"];
			model.Simplename =row.IsNull("Simplename")?null:(System.String)row["Simplename"];
			model.Isshow =row.IsNull("Isshow")?null:(System.String)row["Isshow"];
			model.Belongstype =row.IsNull("Belongstype")?null:(System.Int32?)row["Belongstype"];
			model.Num =row.IsNull("Num")?null:(System.Int64?)row["Num"];
			model.Soldnum =row.IsNull("Soldnum")?null:(System.Int64?)row["Soldnum"];
			model.hit =row.IsNull("hit")?null:(System.Int64?)row["hit"];
			model.rank =row.IsNull("rank")?null:(System.Int64?)row["rank"];
			model.MasterName =row.IsNull("MasterName")?null:(System.String)row["MasterName"];
			model.CompanyName =row.IsNull("CompanyName")?null:(System.String)row["CompanyName"];
			model.Isrecomment =row.IsNull("Isrecomment")?null:(System.String)row["Isrecomment"];
			model.Nongenetic =row.IsNull("Nongenetic")?null:(System.String)row["Nongenetic"];
			model.Isexcellent =row.IsNull("Isexcellent")?null:(System.String)row["Isexcellent"];
			model.Issell =row.IsNull("Issell")?null:(System.String)row["Issell"];
			model.Typeid =row.IsNull("Typeid")?null:(System.Int32?)row["Typeid"];
			model.Masterid =row.IsNull("Masterid")?null:(System.Int32?)row["Masterid"];
			model.Companyid =row.IsNull("Companyid")?null:(System.Int32?)row["Companyid"];
			model.CompanyState1 =row.IsNull("CompanyState1")?null:(System.String)row["CompanyState1"];
			model.CompanyState =row.IsNull("CompanyState")?null:(System.String)row["CompanyState"];
			model.MasterState =row.IsNull("MasterState")?null:(System.String)row["MasterState"];
			model.MasterState1 =row.IsNull("MasterState1")?null:(System.String)row["MasterState1"];
			model.Id =row.IsNull("Id")?null:(System.Int64?)row["Id"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VFindProductInfo Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VFindProductInfo where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			VFindProductInfo model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VFindProductInfo> ListAll()
		{
			List<VFindProductInfo> list=new List<VFindProductInfo>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VFindProductInfo");
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
		public IEnumerable<VFindProductInfo> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<VFindProductInfo> list=new List<VFindProductInfo>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from VFindProductInfo"+strWhere);
		}
	}
}
