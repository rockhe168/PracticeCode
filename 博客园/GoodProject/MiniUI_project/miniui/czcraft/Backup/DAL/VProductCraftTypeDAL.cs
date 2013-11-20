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
	 ///VProductCraftType表DAL
	 ///</summary>
	public partial class VProductCraftTypeDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加VProductCraftType
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
        public long AddNew(VProductCraftType model)
		{
			string sql="insert into VProductCraftType(TypeName,TypeId,FId,rank,hit,Simplename,Name,Explain,Picturepath,Masterid,Belongstype,Companyid,Lsprice,Num,Soldnum,Pfprice,Isshow,Isrecomment,Nongenetic,Isexcellent,Issell) output inserted.Id values(@TypeName,@TypeId,@FId,@rank,@hit,@Simplename,@Name,@Explain,@Picturepath,@Masterid,@Belongstype,@Companyid,@Lsprice,@Num,@Soldnum,@Pfprice,@Isshow,@Isrecomment,@Nongenetic,@Isexcellent,@Issell)";
            long id = (long)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("TypeName",model.TypeName)
						,(DbParameter)new SqlParameter("TypeId",model.TypeId)
						,(DbParameter)new SqlParameter("FId",model.FId)
						,(DbParameter)new SqlParameter("rank",model.rank)
						,(DbParameter)new SqlParameter("hit",model.hit)
						,(DbParameter)new SqlParameter("Simplename",model.Simplename)
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Explain",model.Explain)
						,(DbParameter)new SqlParameter("Picturepath",model.Picturepath)
						,(DbParameter)new SqlParameter("Masterid",model.Masterid)
						,(DbParameter)new SqlParameter("Belongstype",model.Belongstype)
						,(DbParameter)new SqlParameter("Companyid",model.Companyid)
						,(DbParameter)new SqlParameter("Lsprice",model.Lsprice)
						,(DbParameter)new SqlParameter("Num",model.Num)
						,(DbParameter)new SqlParameter("Soldnum",model.Soldnum)
						,(DbParameter)new SqlParameter("Pfprice",model.Pfprice)
						,(DbParameter)new SqlParameter("Isshow",model.Isshow)
						,(DbParameter)new SqlParameter("Isrecomment",model.Isrecomment)
						,(DbParameter)new SqlParameter("Nongenetic",model.Nongenetic)
						,(DbParameter)new SqlParameter("Isexcellent",model.Isexcellent)
						,(DbParameter)new SqlParameter("Issell",model.Issell)
			);
			return id;
		}
		/// <summary>
		/// 更新VProductCraftType实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VProductCraftType model)
		{
			string sql="update VProductCraftType set TypeName=@TypeName,TypeId=@TypeId,FId=@FId,rank=@rank,hit=@hit,Simplename=@Simplename,Name=@Name,Explain=@Explain,Picturepath=@Picturepath,Masterid=@Masterid,Belongstype=@Belongstype,Companyid=@Companyid,Lsprice=@Lsprice,Num=@Num,Soldnum=@Soldnum,Pfprice=@Pfprice,Isshow=@Isshow,Isrecomment=@Isrecomment,Nongenetic=@Nongenetic,Isexcellent=@Isexcellent,Issell=@Issell where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("TypeName",model.TypeName)
						,(DbParameter)new SqlParameter("TypeId",model.TypeId)
						,(DbParameter)new SqlParameter("FId",model.FId)
						,(DbParameter)new SqlParameter("rank",model.rank)
						,(DbParameter)new SqlParameter("hit",model.hit)
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("Simplename",model.Simplename)
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Explain",model.Explain)
						,(DbParameter)new SqlParameter("Picturepath",model.Picturepath)
						,(DbParameter)new SqlParameter("Masterid",model.Masterid)
						,(DbParameter)new SqlParameter("Belongstype",model.Belongstype)
						,(DbParameter)new SqlParameter("Companyid",model.Companyid)
						,(DbParameter)new SqlParameter("Lsprice",model.Lsprice)
						,(DbParameter)new SqlParameter("Num",model.Num)
						,(DbParameter)new SqlParameter("Soldnum",model.Soldnum)
						,(DbParameter)new SqlParameter("Pfprice",model.Pfprice)
						,(DbParameter)new SqlParameter("Isshow",model.Isshow)
						,(DbParameter)new SqlParameter("Isrecomment",model.Isrecomment)
						,(DbParameter)new SqlParameter("Nongenetic",model.Nongenetic)
						,(DbParameter)new SqlParameter("Isexcellent",model.Isexcellent)
						,(DbParameter)new SqlParameter("Issell",model.Issell)
			);
		}
		/// <summary>
		/// 删除VProductCraftType
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from VProductCraftType where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除VProductCraftType
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from VProductCraftType where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static VProductCraftType ToModel(DataRow row)
		{
			VProductCraftType model=new VProductCraftType();
			model.TypeName =row.IsNull("TypeName")?null:(System.String)row["TypeName"];
			model.TypeId =row.IsNull("TypeId")?null:(System.Int32?)row["TypeId"];
			model.FId =row.IsNull("FId")?null:(System.String)row["FId"];
			model.rank =row.IsNull("rank")?null:(System.Int64?)row["rank"];
			model.hit =row.IsNull("hit")?null:(System.Int64?)row["hit"];
			model.Id =row.IsNull("Id")?null:(System.Int64?)row["Id"];
			model.Simplename =row.IsNull("Simplename")?null:(System.String)row["Simplename"];
			model.Name =row.IsNull("Name")?null:(System.String)row["Name"];
			model.Explain =row.IsNull("Explain")?null:(System.String)row["Explain"];
			model.Picturepath =row.IsNull("Picturepath")?null:(System.String)row["Picturepath"];
			model.Masterid =row.IsNull("Masterid")?null:(System.Int32?)row["Masterid"];
			model.Belongstype =row.IsNull("Belongstype")?null:(System.Int32?)row["Belongstype"];
			model.Companyid =row.IsNull("Companyid")?null:(System.Int32?)row["Companyid"];
			model.Lsprice =row.IsNull("Lsprice")?null:(System.Double?)row["Lsprice"];
			model.Num =row.IsNull("Num")?null:(System.Int64?)row["Num"];
			model.Soldnum =row.IsNull("Soldnum")?null:(System.Int64?)row["Soldnum"];
			model.Pfprice =row.IsNull("Pfprice")?null:(System.Double?)row["Pfprice"];
			model.Isshow =row.IsNull("Isshow")?null:(System.String)row["Isshow"];
			model.Isrecomment =row.IsNull("Isrecomment")?null:(System.String)row["Isrecomment"];
			model.Nongenetic =row.IsNull("Nongenetic")?null:(System.String)row["Nongenetic"];
			model.Isexcellent =row.IsNull("Isexcellent")?null:(System.String)row["Isexcellent"];
			model.Issell =row.IsNull("Issell")?null:(System.String)row["Issell"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VProductCraftType Get(long id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VProductCraftType where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			VProductCraftType model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VProductCraftType> ListAll()
		{
			List<VProductCraftType> list=new List<VProductCraftType>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VProductCraftType");
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
		public IEnumerable<VProductCraftType> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<VProductCraftType> list=new List<VProductCraftType>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from VProductCraftType"+strWhere);
		}
	}
}
