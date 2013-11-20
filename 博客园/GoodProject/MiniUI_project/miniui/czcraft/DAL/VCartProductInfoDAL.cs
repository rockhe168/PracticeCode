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
 *  创建时间: 2012/5/16 0:10:11
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///VCartProductInfo表DAL
	 ///</summary>
	public partial class VCartProductInfoDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加VCartProductInfo
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
        public long AddNew(VCartProductInfo model)
		{
			string sql="insert into VCartProductInfo(ProductId,SupperlierId,Quantity,BelongType,SupperlierName,Price,MemberId,ProductName,Num,Soldnum,Picturepath) output inserted.Id values(@ProductId,@SupperlierId,@Quantity,@BelongType,@SupperlierName,@Price,@MemberId,@ProductName,@Num,@Soldnum,@Picturepath)";
            long id = (long)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("ProductId",model.ProductId)
						,(DbParameter)new SqlParameter("SupperlierId",model.SupperlierId)
						,(DbParameter)new SqlParameter("Quantity",model.Quantity)
						,(DbParameter)new SqlParameter("BelongType",model.BelongType)
						,(DbParameter)new SqlParameter("SupperlierName",model.SupperlierName)
						,(DbParameter)new SqlParameter("Price",model.Price)
						,(DbParameter)new SqlParameter("MemberId",model.MemberId)
						,(DbParameter)new SqlParameter("ProductName",model.ProductName)
						,(DbParameter)new SqlParameter("Num",model.Num)
						,(DbParameter)new SqlParameter("Soldnum",model.Soldnum)
						,(DbParameter)new SqlParameter("Picturepath",model.Picturepath)
			);
			return id;
		}
		/// <summary>
		/// 更新VCartProductInfo实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VCartProductInfo model)
		{
			string sql="update VCartProductInfo set ProductId=@ProductId,SupperlierId=@SupperlierId,Quantity=@Quantity,BelongType=@BelongType,SupperlierName=@SupperlierName,Price=@Price,MemberId=@MemberId,ProductName=@ProductName,Num=@Num,Soldnum=@Soldnum,Picturepath=@Picturepath where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("ProductId",model.ProductId)
						,(DbParameter)new SqlParameter("SupperlierId",model.SupperlierId)
						,(DbParameter)new SqlParameter("Quantity",model.Quantity)
						,(DbParameter)new SqlParameter("BelongType",model.BelongType)
						,(DbParameter)new SqlParameter("SupperlierName",model.SupperlierName)
						,(DbParameter)new SqlParameter("Price",model.Price)
						,(DbParameter)new SqlParameter("MemberId",model.MemberId)
						,(DbParameter)new SqlParameter("ProductName",model.ProductName)
						,(DbParameter)new SqlParameter("Num",model.Num)
						,(DbParameter)new SqlParameter("Soldnum",model.Soldnum)
						,(DbParameter)new SqlParameter("Picturepath",model.Picturepath)
			);
		}
		/// <summary>
		/// 删除VCartProductInfo
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
        public bool Delete(long id)
		{
		return SqlHelper.ExecuteNonQuery("delete from VCartProductInfo where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除VCartProductInfo
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from VCartProductInfo where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static VCartProductInfo ToModel(DataRow row)
		{
			VCartProductInfo model=new VCartProductInfo();
			model.Id =row.IsNull("Id")?null:(System.Int64?)row["Id"];
			model.ProductId =row.IsNull("ProductId")?null:(System.Int64?)row["ProductId"];
			model.SupperlierId =row.IsNull("SupperlierId")?null:(System.Int32?)row["SupperlierId"];
			model.Quantity =row.IsNull("Quantity")?null:(System.Int32?)row["Quantity"];
			model.BelongType =row.IsNull("BelongType")?null:(System.Int32?)row["BelongType"];
			model.SupperlierName =row.IsNull("SupperlierName")?null:(System.String)row["SupperlierName"];
			model.Price =row.IsNull("Price")?null:(System.Double?)row["Price"];
			model.MemberId =row.IsNull("MemberId")?null:(System.Int32?)row["MemberId"];
			model.ProductName =row.IsNull("ProductName")?null:(System.String)row["ProductName"];
			model.Num =row.IsNull("Num")?null:(System.Int64?)row["Num"];
			model.Soldnum =row.IsNull("Soldnum")?null:(System.Int64?)row["Soldnum"];
			model.Picturepath =row.IsNull("Picturepath")?null:(System.String)row["Picturepath"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
        public VCartProductInfo Get(long id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VCartProductInfo where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			VCartProductInfo model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VCartProductInfo> ListAll()
		{
			List<VCartProductInfo> list=new List<VCartProductInfo>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VCartProductInfo");
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
		public IEnumerable<VCartProductInfo> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<VCartProductInfo> list=new List<VCartProductInfo>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from VCartProductInfo"+strWhere);
		}
	}
}
