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
	 ///VOrders表DAL
	 ///</summary>
	public partial class VOrdersDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加VOrders
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(VOrders model)
		{
			string sql="insert into VOrders(OrderId,ProId,ProImg,ProName,ProPrice,ProNum,TotalPrice,OrderStatus,PaymentStatus,Carriage,OgisticsStatus,OrderType,FactPrice,ConsigneeRealName,ConsigneeName,ConsigneePhone,ConsigneeProvince,ConsigneeAddress,ConsigneeZip,ConsigneeTel,ConsigneeEmail,PaymentType,ShopDate,OrderDate,UserId,AddTime,IsOrderNormal,BelongType,SupperlierId,SupperlierName) output inserted.Id values(@OrderId,@ProId,@ProImg,@ProName,@ProPrice,@ProNum,@TotalPrice,@OrderStatus,@PaymentStatus,@Carriage,@OgisticsStatus,@OrderType,@FactPrice,@ConsigneeRealName,@ConsigneeName,@ConsigneePhone,@ConsigneeProvince,@ConsigneeAddress,@ConsigneeZip,@ConsigneeTel,@ConsigneeEmail,@PaymentType,@ShopDate,@OrderDate,@UserId,@AddTime,@IsOrderNormal,@BelongType,@SupperlierId,@SupperlierName)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("OrderId",model.OrderId)
						,(DbParameter)new SqlParameter("ProId",model.ProId)
						,(DbParameter)new SqlParameter("ProImg",model.ProImg)
						,(DbParameter)new SqlParameter("ProName",model.ProName)
						,(DbParameter)new SqlParameter("ProPrice",model.ProPrice)
						,(DbParameter)new SqlParameter("ProNum",model.ProNum)
						,(DbParameter)new SqlParameter("TotalPrice",model.TotalPrice)
						,(DbParameter)new SqlParameter("OrderStatus",model.OrderStatus)
						,(DbParameter)new SqlParameter("PaymentStatus",model.PaymentStatus)
						,(DbParameter)new SqlParameter("Carriage",model.Carriage)
						,(DbParameter)new SqlParameter("OgisticsStatus",model.OgisticsStatus)
						,(DbParameter)new SqlParameter("OrderType",model.OrderType)
						,(DbParameter)new SqlParameter("FactPrice",model.FactPrice)
						,(DbParameter)new SqlParameter("ConsigneeRealName",model.ConsigneeRealName)
						,(DbParameter)new SqlParameter("ConsigneeName",model.ConsigneeName)
						,(DbParameter)new SqlParameter("ConsigneePhone",model.ConsigneePhone)
						,(DbParameter)new SqlParameter("ConsigneeProvince",model.ConsigneeProvince)
						,(DbParameter)new SqlParameter("ConsigneeAddress",model.ConsigneeAddress)
						,(DbParameter)new SqlParameter("ConsigneeZip",model.ConsigneeZip)
						,(DbParameter)new SqlParameter("ConsigneeTel",model.ConsigneeTel)
						,(DbParameter)new SqlParameter("ConsigneeEmail",model.ConsigneeEmail)
						,(DbParameter)new SqlParameter("PaymentType",model.PaymentType)
						,(DbParameter)new SqlParameter("ShopDate",model.ShopDate)
						,(DbParameter)new SqlParameter("OrderDate",model.OrderDate)
						,(DbParameter)new SqlParameter("UserId",model.UserId)
						,(DbParameter)new SqlParameter("AddTime",model.AddTime)
						,(DbParameter)new SqlParameter("IsOrderNormal",model.IsOrderNormal)
						,(DbParameter)new SqlParameter("BelongType",model.BelongType)
						,(DbParameter)new SqlParameter("SupperlierId",model.SupperlierId)
						,(DbParameter)new SqlParameter("SupperlierName",model.SupperlierName)
			);
			return id;
		}
		/// <summary>
		/// 更新VOrders实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VOrders model)
		{
			string sql="update VOrders set OrderId=@OrderId,ProId=@ProId,ProImg=@ProImg,ProName=@ProName,ProPrice=@ProPrice,ProNum=@ProNum,TotalPrice=@TotalPrice,OrderStatus=@OrderStatus,PaymentStatus=@PaymentStatus,Carriage=@Carriage,OgisticsStatus=@OgisticsStatus,OrderType=@OrderType,FactPrice=@FactPrice,ConsigneeRealName=@ConsigneeRealName,ConsigneeName=@ConsigneeName,ConsigneePhone=@ConsigneePhone,ConsigneeProvince=@ConsigneeProvince,ConsigneeAddress=@ConsigneeAddress,ConsigneeZip=@ConsigneeZip,ConsigneeTel=@ConsigneeTel,ConsigneeEmail=@ConsigneeEmail,PaymentType=@PaymentType,ShopDate=@ShopDate,OrderDate=@OrderDate,UserId=@UserId,AddTime=@AddTime,IsOrderNormal=@IsOrderNormal,BelongType=@BelongType,SupperlierId=@SupperlierId,SupperlierName=@SupperlierName where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("OrderId",model.OrderId)
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("ProId",model.ProId)
						,(DbParameter)new SqlParameter("ProImg",model.ProImg)
						,(DbParameter)new SqlParameter("ProName",model.ProName)
						,(DbParameter)new SqlParameter("ProPrice",model.ProPrice)
						,(DbParameter)new SqlParameter("ProNum",model.ProNum)
						,(DbParameter)new SqlParameter("TotalPrice",model.TotalPrice)
						,(DbParameter)new SqlParameter("OrderStatus",model.OrderStatus)
						,(DbParameter)new SqlParameter("PaymentStatus",model.PaymentStatus)
						,(DbParameter)new SqlParameter("Carriage",model.Carriage)
						,(DbParameter)new SqlParameter("OgisticsStatus",model.OgisticsStatus)
						,(DbParameter)new SqlParameter("OrderType",model.OrderType)
						,(DbParameter)new SqlParameter("FactPrice",model.FactPrice)
						,(DbParameter)new SqlParameter("ConsigneeRealName",model.ConsigneeRealName)
						,(DbParameter)new SqlParameter("ConsigneeName",model.ConsigneeName)
						,(DbParameter)new SqlParameter("ConsigneePhone",model.ConsigneePhone)
						,(DbParameter)new SqlParameter("ConsigneeProvince",model.ConsigneeProvince)
						,(DbParameter)new SqlParameter("ConsigneeAddress",model.ConsigneeAddress)
						,(DbParameter)new SqlParameter("ConsigneeZip",model.ConsigneeZip)
						,(DbParameter)new SqlParameter("ConsigneeTel",model.ConsigneeTel)
						,(DbParameter)new SqlParameter("ConsigneeEmail",model.ConsigneeEmail)
						,(DbParameter)new SqlParameter("PaymentType",model.PaymentType)
						,(DbParameter)new SqlParameter("ShopDate",model.ShopDate)
						,(DbParameter)new SqlParameter("OrderDate",model.OrderDate)
						,(DbParameter)new SqlParameter("UserId",model.UserId)
						,(DbParameter)new SqlParameter("AddTime",model.AddTime)
						,(DbParameter)new SqlParameter("IsOrderNormal",model.IsOrderNormal)
						,(DbParameter)new SqlParameter("BelongType",model.BelongType)
						,(DbParameter)new SqlParameter("SupperlierId",model.SupperlierId)
						,(DbParameter)new SqlParameter("SupperlierName",model.SupperlierName)
			);
		}
		/// <summary>
		/// 删除VOrders
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from VOrders where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除VOrders
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from VOrders where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static VOrders ToModel(DataRow row)
		{
			VOrders model=new VOrders();
			model.OrderId =row.IsNull("OrderId")?null:(System.String)row["OrderId"];
			model.Id =row.IsNull("Id")?null:(System.Int32?)row["Id"];
			model.ProId =row.IsNull("ProId")?null:(System.String)row["ProId"];
			model.ProImg =row.IsNull("ProImg")?null:(System.String)row["ProImg"];
			model.ProName =row.IsNull("ProName")?null:(System.String)row["ProName"];
			model.ProPrice =row.IsNull("ProPrice")?null:(System.Double?)row["ProPrice"];
			model.ProNum =row.IsNull("ProNum")?null:(System.Int32?)row["ProNum"];
			model.TotalPrice =row.IsNull("TotalPrice")?null:(System.Double?)row["TotalPrice"];
			model.OrderStatus =row.IsNull("OrderStatus")?null:(System.String)row["OrderStatus"];
			model.PaymentStatus =row.IsNull("PaymentStatus")?null:(System.String)row["PaymentStatus"];
			model.Carriage =row.IsNull("Carriage")?null:(System.Double?)row["Carriage"];
			model.OgisticsStatus =row.IsNull("OgisticsStatus")?null:(System.String)row["OgisticsStatus"];
			model.OrderType =row.IsNull("OrderType")?null:(System.String)row["OrderType"];
			model.FactPrice =row.IsNull("FactPrice")?null:(System.Double?)row["FactPrice"];
			model.ConsigneeRealName =row.IsNull("ConsigneeRealName")?null:(System.String)row["ConsigneeRealName"];
			model.ConsigneeName =row.IsNull("ConsigneeName")?null:(System.String)row["ConsigneeName"];
			model.ConsigneePhone =row.IsNull("ConsigneePhone")?null:(System.String)row["ConsigneePhone"];
			model.ConsigneeProvince =row.IsNull("ConsigneeProvince")?null:(System.String)row["ConsigneeProvince"];
			model.ConsigneeAddress =row.IsNull("ConsigneeAddress")?null:(System.String)row["ConsigneeAddress"];
			model.ConsigneeZip =row.IsNull("ConsigneeZip")?null:(System.String)row["ConsigneeZip"];
			model.ConsigneeTel =row.IsNull("ConsigneeTel")?null:(System.String)row["ConsigneeTel"];
			model.ConsigneeEmail =row.IsNull("ConsigneeEmail")?null:(System.String)row["ConsigneeEmail"];
			model.PaymentType =row.IsNull("PaymentType")?null:(System.String)row["PaymentType"];
			model.ShopDate =row.IsNull("ShopDate")?null:(System.DateTime?)row["ShopDate"];
			model.OrderDate =row.IsNull("OrderDate")?null:(System.DateTime?)row["OrderDate"];
			model.UserId =row.IsNull("UserId")?null:(System.Int32?)row["UserId"];
			model.AddTime =row.IsNull("AddTime")?null:(System.DateTime?)row["AddTime"];
			model.IsOrderNormal =row.IsNull("IsOrderNormal")?null:(System.Int32?)row["IsOrderNormal"];
			model.BelongType =row.IsNull("BelongType")?null:(System.Int32?)row["BelongType"];
			model.SupperlierId =row.IsNull("SupperlierId")?null:(System.Int32?)row["SupperlierId"];
			model.SupperlierName =row.IsNull("SupperlierName")?null:(System.String)row["SupperlierName"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VOrders Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VOrders where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			VOrders model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VOrders> ListAll()
		{
			List<VOrders> list=new List<VOrders>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VOrders");
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
		public IEnumerable<VOrders> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<VOrders> list=new List<VOrders>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from VOrders"+strWhere);
		}
	}
}
