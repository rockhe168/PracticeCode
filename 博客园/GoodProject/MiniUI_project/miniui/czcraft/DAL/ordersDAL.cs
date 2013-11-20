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
 *  创建时间: 2012/5/21 7:50:43
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///orders表DAL
	 ///</summary>
	public partial class ordersDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加orders
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(orders model)
		{
			string sql="insert into orders(OrderId,UserId,ShopDate,OrderDate,ConsigneeRealName,ConsigneeName,ConsigneePhone,ConsigneeProvince,ConsigneeAddress,ConsigneeZip,ConsigneeTel,ConsigneeEmail,PaymentType,Payment,Courier,TotalPrice,FactPrice,Invoice,Remark,OrderStatus,PaymentStatus,OgisticsStatus,Carriage,OrderType,IsOrderNormal) output inserted.Id values(@OrderId,@UserId,@ShopDate,@OrderDate,@ConsigneeRealName,@ConsigneeName,@ConsigneePhone,@ConsigneeProvince,@ConsigneeAddress,@ConsigneeZip,@ConsigneeTel,@ConsigneeEmail,@PaymentType,@Payment,@Courier,@TotalPrice,@FactPrice,@Invoice,@Remark,@OrderStatus,@PaymentStatus,@OgisticsStatus,@Carriage,@OrderType,@IsOrderNormal)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("OrderId",model.OrderId)
						,(DbParameter)new SqlParameter("UserId",model.UserId)
						,(DbParameter)new SqlParameter("ShopDate",model.ShopDate)
						,(DbParameter)new SqlParameter("OrderDate",model.OrderDate)
						,(DbParameter)new SqlParameter("ConsigneeRealName",model.ConsigneeRealName)
						,(DbParameter)new SqlParameter("ConsigneeName",model.ConsigneeName)
						,(DbParameter)new SqlParameter("ConsigneePhone",model.ConsigneePhone)
						,(DbParameter)new SqlParameter("ConsigneeProvince",model.ConsigneeProvince)
						,(DbParameter)new SqlParameter("ConsigneeAddress",model.ConsigneeAddress)
						,(DbParameter)new SqlParameter("ConsigneeZip",model.ConsigneeZip)
						,(DbParameter)new SqlParameter("ConsigneeTel",model.ConsigneeTel)
						,(DbParameter)new SqlParameter("ConsigneeEmail",model.ConsigneeEmail)
						,(DbParameter)new SqlParameter("PaymentType",model.PaymentType)
						,(DbParameter)new SqlParameter("Payment",model.Payment)
						,(DbParameter)new SqlParameter("Courier",model.Courier)
						,(DbParameter)new SqlParameter("TotalPrice",model.TotalPrice)
						,(DbParameter)new SqlParameter("FactPrice",model.FactPrice)
						,(DbParameter)new SqlParameter("Invoice",model.Invoice)
						,(DbParameter)new SqlParameter("Remark",model.Remark)
						,(DbParameter)new SqlParameter("OrderStatus",model.OrderStatus)
						,(DbParameter)new SqlParameter("PaymentStatus",model.PaymentStatus)
						,(DbParameter)new SqlParameter("OgisticsStatus",model.OgisticsStatus)
						,(DbParameter)new SqlParameter("Carriage",model.Carriage)
						,(DbParameter)new SqlParameter("OrderType",model.OrderType)
						,(DbParameter)new SqlParameter("IsOrderNormal",model.IsOrderNormal)
			);
			return id;
		}
		/// <summary>
		/// 更新orders实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(orders model)
		{
			string sql="update orders set OrderId=@OrderId,UserId=@UserId,ShopDate=@ShopDate,OrderDate=@OrderDate,ConsigneeRealName=@ConsigneeRealName,ConsigneeName=@ConsigneeName,ConsigneePhone=@ConsigneePhone,ConsigneeProvince=@ConsigneeProvince,ConsigneeAddress=@ConsigneeAddress,ConsigneeZip=@ConsigneeZip,ConsigneeTel=@ConsigneeTel,ConsigneeEmail=@ConsigneeEmail,PaymentType=@PaymentType,Payment=@Payment,Courier=@Courier,TotalPrice=@TotalPrice,FactPrice=@FactPrice,Invoice=@Invoice,Remark=@Remark,OrderStatus=@OrderStatus,PaymentStatus=@PaymentStatus,OgisticsStatus=@OgisticsStatus,Carriage=@Carriage,OrderType=@OrderType,IsOrderNormal=@IsOrderNormal where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("OrderId",model.OrderId)
						,(DbParameter)new SqlParameter("UserId",model.UserId)
						,(DbParameter)new SqlParameter("ShopDate",model.ShopDate)
						,(DbParameter)new SqlParameter("OrderDate",model.OrderDate)
						,(DbParameter)new SqlParameter("ConsigneeRealName",model.ConsigneeRealName)
						,(DbParameter)new SqlParameter("ConsigneeName",model.ConsigneeName)
						,(DbParameter)new SqlParameter("ConsigneePhone",model.ConsigneePhone)
						,(DbParameter)new SqlParameter("ConsigneeProvince",model.ConsigneeProvince)
						,(DbParameter)new SqlParameter("ConsigneeAddress",model.ConsigneeAddress)
						,(DbParameter)new SqlParameter("ConsigneeZip",model.ConsigneeZip)
						,(DbParameter)new SqlParameter("ConsigneeTel",model.ConsigneeTel)
						,(DbParameter)new SqlParameter("ConsigneeEmail",model.ConsigneeEmail)
						,(DbParameter)new SqlParameter("PaymentType",model.PaymentType)
						,(DbParameter)new SqlParameter("Payment",model.Payment)
						,(DbParameter)new SqlParameter("Courier",model.Courier)
						,(DbParameter)new SqlParameter("TotalPrice",model.TotalPrice)
						,(DbParameter)new SqlParameter("FactPrice",model.FactPrice)
						,(DbParameter)new SqlParameter("Invoice",model.Invoice)
						,(DbParameter)new SqlParameter("Remark",model.Remark)
						,(DbParameter)new SqlParameter("OrderStatus",model.OrderStatus)
						,(DbParameter)new SqlParameter("PaymentStatus",model.PaymentStatus)
						,(DbParameter)new SqlParameter("OgisticsStatus",model.OgisticsStatus)
						,(DbParameter)new SqlParameter("Carriage",model.Carriage)
						,(DbParameter)new SqlParameter("OrderType",model.OrderType)
						,(DbParameter)new SqlParameter("IsOrderNormal",model.IsOrderNormal)
			);
		}
		/// <summary>
		/// 删除orders
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
        {
            bool status = false;
            SqlHelper.Open();
            SqlHelper.BeginTrans();

            status= SqlHelper.ExecuteNonQuery("delete from orderproduct where OrderId=@id; delete from orders where id=@id",
		 				(DbParameter)new SqlParameter("id",id));
            if (status)
            {
                SqlHelper.CommitTrans();
                return true;
            }
            else
            {
                SqlHelper.RollbackTrans();
                return false;
            }
        }
		/// <summary>
		/// 删除orders
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
            bool status = false;
            string[] IDs = strID.Split(',');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < IDs.Length; i++)
                sb.Append("delete from orderproduct where OrderId=" + IDs[i] + ";");
            sb.Append("delete from orders where id in (" + strID + ")");

            SqlHelper.Open();
            SqlHelper.BeginTrans();
            if (SqlHelper.ExecuteNonQuery(sb.ToString()))
            {
                status = true;
                SqlHelper.CommitTrans();
            }
            else
            {
                status = false;
                SqlHelper.RollbackTrans();
            }

            return status;
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static orders ToModel(DataRow row)
		{
			orders model=new orders();
			model.Id =row.IsNull("Id")?null:(System.Int32?)row["Id"];
			model.OrderId =row.IsNull("OrderId")?null:(System.String)row["OrderId"];
			model.UserId =row.IsNull("UserId")?null:(System.Int32?)row["UserId"];
			model.ShopDate =row.IsNull("ShopDate")?null:(System.DateTime?)row["ShopDate"];
			model.OrderDate =row.IsNull("OrderDate")?null:(System.DateTime?)row["OrderDate"];
			model.ConsigneeRealName =row.IsNull("ConsigneeRealName")?null:(System.String)row["ConsigneeRealName"];
			model.ConsigneeName =row.IsNull("ConsigneeName")?null:(System.String)row["ConsigneeName"];
			model.ConsigneePhone =row.IsNull("ConsigneePhone")?null:(System.String)row["ConsigneePhone"];
			model.ConsigneeProvince =row.IsNull("ConsigneeProvince")?null:(System.String)row["ConsigneeProvince"];
			model.ConsigneeAddress =row.IsNull("ConsigneeAddress")?null:(System.String)row["ConsigneeAddress"];
			model.ConsigneeZip =row.IsNull("ConsigneeZip")?null:(System.String)row["ConsigneeZip"];
			model.ConsigneeTel =row.IsNull("ConsigneeTel")?null:(System.String)row["ConsigneeTel"];
			model.ConsigneeEmail =row.IsNull("ConsigneeEmail")?null:(System.String)row["ConsigneeEmail"];
			model.PaymentType =row.IsNull("PaymentType")?null:(System.String)row["PaymentType"];
			model.Payment =row.IsNull("Payment")?null:(System.Double?)row["Payment"];
			model.Courier =row.IsNull("Courier")?null:(System.String)row["Courier"];
			model.TotalPrice =row.IsNull("TotalPrice")?null:(System.Double?)row["TotalPrice"];
			model.FactPrice =row.IsNull("FactPrice")?null:(System.Double?)row["FactPrice"];
			model.Invoice =row.IsNull("Invoice")?null:(System.Int32?)row["Invoice"];
			model.Remark =row.IsNull("Remark")?null:(System.String)row["Remark"];
			model.OrderStatus =row.IsNull("OrderStatus")?null:(System.String)row["OrderStatus"];
			model.PaymentStatus =row.IsNull("PaymentStatus")?null:(System.String)row["PaymentStatus"];
			model.OgisticsStatus =row.IsNull("OgisticsStatus")?null:(System.String)row["OgisticsStatus"];
			model.Carriage =row.IsNull("Carriage")?null:(System.Double?)row["Carriage"];
			model.OrderType =row.IsNull("OrderType")?null:(System.String)row["OrderType"];
			model.IsOrderNormal =row.IsNull("IsOrderNormal")?null:(System.Int32?)row["IsOrderNormal"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public orders Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from orders where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			orders model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<orders> ListAll()
		{
			List<orders> list=new List<orders>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from orders");
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
		public IEnumerable<orders> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<orders> list=new List<orders>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from orders"+strWhere);
		}
	}
}
