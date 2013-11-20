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
 *  创建时间: 2012/5/21 7:53:52
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///orderproduct表DAL
	 ///</summary>
	public partial class orderproductDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加orderproduct
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(orderproduct model)
		{
			string sql="insert into orderproduct(OrderId,ProId,ProClass,ProName,ProImg,ProPrice,ProNum,AddTime,ProOtherPara,Specification,Remark,SupperlierId,BelongType,SupperlierName) output inserted.Id values(@OrderId,@ProId,@ProClass,@ProName,@ProImg,@ProPrice,@ProNum,@AddTime,@ProOtherPara,@Specification,@Remark,@SupperlierId,@BelongType,@SupperlierName)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("OrderId",model.OrderId)
						,(DbParameter)new SqlParameter("ProId",model.ProId)
						,(DbParameter)new SqlParameter("ProClass",model.ProClass)
						,(DbParameter)new SqlParameter("ProName",model.ProName)
						,(DbParameter)new SqlParameter("ProImg",model.ProImg)
						,(DbParameter)new SqlParameter("ProPrice",model.ProPrice)
						,(DbParameter)new SqlParameter("ProNum",model.ProNum)
						,(DbParameter)new SqlParameter("AddTime",model.AddTime)
						,(DbParameter)new SqlParameter("ProOtherPara",model.ProOtherPara)
						,(DbParameter)new SqlParameter("Specification",model.Specification)
						,(DbParameter)new SqlParameter("Remark",model.Remark)
						,(DbParameter)new SqlParameter("SupperlierId",model.SupperlierId)
						,(DbParameter)new SqlParameter("BelongType",model.BelongType)
						,(DbParameter)new SqlParameter("SupperlierName",model.SupperlierName)
			);
			return id;
		}
		/// <summary>
		/// 更新orderproduct实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(orderproduct model)
		{
			string sql="update orderproduct set OrderId=@OrderId,ProId=@ProId,ProClass=@ProClass,ProName=@ProName,ProImg=@ProImg,ProPrice=@ProPrice,ProNum=@ProNum,AddTime=@AddTime,ProOtherPara=@ProOtherPara,Specification=@Specification,Remark=@Remark,SupperlierId=@SupperlierId,BelongType=@BelongType,SupperlierName=@SupperlierName where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("OrderId",model.OrderId)
						,(DbParameter)new SqlParameter("ProId",model.ProId)
						,(DbParameter)new SqlParameter("ProClass",model.ProClass)
						,(DbParameter)new SqlParameter("ProName",model.ProName)
						,(DbParameter)new SqlParameter("ProImg",model.ProImg)
						,(DbParameter)new SqlParameter("ProPrice",model.ProPrice)
						,(DbParameter)new SqlParameter("ProNum",model.ProNum)
						,(DbParameter)new SqlParameter("AddTime",model.AddTime)
						,(DbParameter)new SqlParameter("ProOtherPara",model.ProOtherPara)
						,(DbParameter)new SqlParameter("Specification",model.Specification)
						,(DbParameter)new SqlParameter("Remark",model.Remark)
						,(DbParameter)new SqlParameter("SupperlierId",model.SupperlierId)
						,(DbParameter)new SqlParameter("BelongType",model.BelongType)
						,(DbParameter)new SqlParameter("SupperlierName",model.SupperlierName)
			);
		}
		/// <summary>
		/// 删除orderproduct
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from orderproduct where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除orderproduct
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from orderproduct where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static orderproduct ToModel(DataRow row)
		{
			orderproduct model=new orderproduct();
			model.Id =row.IsNull("Id")?null:(System.Int32?)row["Id"];
			model.OrderId =row.IsNull("OrderId")?null:(System.String)row["OrderId"];
			model.ProId =row.IsNull("ProId")?null:(System.String)row["ProId"];
			model.ProClass =row.IsNull("ProClass")?null:(System.String)row["ProClass"];
			model.ProName =row.IsNull("ProName")?null:(System.String)row["ProName"];
			model.ProImg =row.IsNull("ProImg")?null:(System.String)row["ProImg"];
			model.ProPrice =row.IsNull("ProPrice")?null:(System.Double?)row["ProPrice"];
			model.ProNum =row.IsNull("ProNum")?null:(System.Int32?)row["ProNum"];
			model.AddTime =row.IsNull("AddTime")?null:(System.DateTime?)row["AddTime"];
			model.ProOtherPara =row.IsNull("ProOtherPara")?null:(System.String)row["ProOtherPara"];
			model.Specification =row.IsNull("Specification")?null:(System.String)row["Specification"];
			model.Remark =row.IsNull("Remark")?null:(System.String)row["Remark"];
			model.SupperlierId =row.IsNull("SupperlierId")?null:(System.Int32?)row["SupperlierId"];
			model.BelongType =row.IsNull("BelongType")?null:(System.Int32?)row["BelongType"];
			model.SupperlierName =row.IsNull("SupperlierName")?null:(System.String)row["SupperlierName"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public orderproduct Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from orderproduct where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			orderproduct model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<orderproduct> ListAll()
		{
			List<orderproduct> list=new List<orderproduct>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from orderproduct");
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
		public IEnumerable<orderproduct> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<orderproduct> list=new List<orderproduct>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from orderproduct"+strWhere);
		}
	}
}
