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
 *  创建时间: 2012/5/24 7:38:42
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///VMemberCollectProduct表DAL
	 ///</summary>
	public partial class VMemberCollectProductDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加VMemberCollectProduct
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(VMemberCollectProduct model)
		{
			string sql="insert into VMemberCollectProduct(Name,Simplename,Explain,Picturepath,Flashpath,Material,Weight,Volume,Specification,Issell,Model,Isexcellent,Nongenetic,Isrecomment,Isshow,Typeid,Belongstype,Num,Soldnum,Masterid,Companyid,Lsprice,rank,hit,Pfprice,ProductId,MemberId,AddTime,IsBuy,SupperName) output inserted.Id values(@Name,@Simplename,@Explain,@Picturepath,@Flashpath,@Material,@Weight,@Volume,@Specification,@Issell,@Model,@Isexcellent,@Nongenetic,@Isrecomment,@Isshow,@Typeid,@Belongstype,@Num,@Soldnum,@Masterid,@Companyid,@Lsprice,@rank,@hit,@Pfprice,@ProductId,@MemberId,@AddTime,@IsBuy,@SupperName)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Simplename",model.Simplename)
						,(DbParameter)new SqlParameter("Explain",model.Explain)
						,(DbParameter)new SqlParameter("Picturepath",model.Picturepath)
						,(DbParameter)new SqlParameter("Flashpath",model.Flashpath)
						,(DbParameter)new SqlParameter("Material",model.Material)
						,(DbParameter)new SqlParameter("Weight",model.Weight)
						,(DbParameter)new SqlParameter("Volume",model.Volume)
						,(DbParameter)new SqlParameter("Specification",model.Specification)
						,(DbParameter)new SqlParameter("Issell",model.Issell)
						,(DbParameter)new SqlParameter("Model",model.Model)
						,(DbParameter)new SqlParameter("Isexcellent",model.Isexcellent)
						,(DbParameter)new SqlParameter("Nongenetic",model.Nongenetic)
						,(DbParameter)new SqlParameter("Isrecomment",model.Isrecomment)
						,(DbParameter)new SqlParameter("Isshow",model.Isshow)
						,(DbParameter)new SqlParameter("Typeid",model.Typeid)
						,(DbParameter)new SqlParameter("Belongstype",model.Belongstype)
						,(DbParameter)new SqlParameter("Num",model.Num)
						,(DbParameter)new SqlParameter("Soldnum",model.Soldnum)
						,(DbParameter)new SqlParameter("Masterid",model.Masterid)
						,(DbParameter)new SqlParameter("Companyid",model.Companyid)
						,(DbParameter)new SqlParameter("Lsprice",model.Lsprice)
						,(DbParameter)new SqlParameter("rank",model.rank)
						,(DbParameter)new SqlParameter("hit",model.hit)
						,(DbParameter)new SqlParameter("Pfprice",model.Pfprice)
						,(DbParameter)new SqlParameter("ProductId",model.ProductId)
						,(DbParameter)new SqlParameter("MemberId",model.MemberId)
						,(DbParameter)new SqlParameter("AddTime",model.AddTime)
						,(DbParameter)new SqlParameter("IsBuy",model.IsBuy)
						,(DbParameter)new SqlParameter("SupperName",model.SupperName)
			);
			return id;
		}
		/// <summary>
		/// 更新VMemberCollectProduct实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VMemberCollectProduct model)
		{
			string sql="update VMemberCollectProduct set Name=@Name,Simplename=@Simplename,Explain=@Explain,Picturepath=@Picturepath,Flashpath=@Flashpath,Material=@Material,Weight=@Weight,Volume=@Volume,Specification=@Specification,Issell=@Issell,Model=@Model,Isexcellent=@Isexcellent,Nongenetic=@Nongenetic,Isrecomment=@Isrecomment,Isshow=@Isshow,Typeid=@Typeid,Belongstype=@Belongstype,Num=@Num,Soldnum=@Soldnum,Masterid=@Masterid,Companyid=@Companyid,Lsprice=@Lsprice,rank=@rank,hit=@hit,Pfprice=@Pfprice,ProductId=@ProductId,MemberId=@MemberId,AddTime=@AddTime,IsBuy=@IsBuy,SupperName=@SupperName where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Simplename",model.Simplename)
						,(DbParameter)new SqlParameter("Explain",model.Explain)
						,(DbParameter)new SqlParameter("Picturepath",model.Picturepath)
						,(DbParameter)new SqlParameter("Flashpath",model.Flashpath)
						,(DbParameter)new SqlParameter("Material",model.Material)
						,(DbParameter)new SqlParameter("Weight",model.Weight)
						,(DbParameter)new SqlParameter("Volume",model.Volume)
						,(DbParameter)new SqlParameter("Specification",model.Specification)
						,(DbParameter)new SqlParameter("Issell",model.Issell)
						,(DbParameter)new SqlParameter("Model",model.Model)
						,(DbParameter)new SqlParameter("Isexcellent",model.Isexcellent)
						,(DbParameter)new SqlParameter("Nongenetic",model.Nongenetic)
						,(DbParameter)new SqlParameter("Isrecomment",model.Isrecomment)
						,(DbParameter)new SqlParameter("Isshow",model.Isshow)
						,(DbParameter)new SqlParameter("Typeid",model.Typeid)
						,(DbParameter)new SqlParameter("Belongstype",model.Belongstype)
						,(DbParameter)new SqlParameter("Num",model.Num)
						,(DbParameter)new SqlParameter("Soldnum",model.Soldnum)
						,(DbParameter)new SqlParameter("Masterid",model.Masterid)
						,(DbParameter)new SqlParameter("Companyid",model.Companyid)
						,(DbParameter)new SqlParameter("Lsprice",model.Lsprice)
						,(DbParameter)new SqlParameter("rank",model.rank)
						,(DbParameter)new SqlParameter("hit",model.hit)
						,(DbParameter)new SqlParameter("Pfprice",model.Pfprice)
						,(DbParameter)new SqlParameter("ProductId",model.ProductId)
						,(DbParameter)new SqlParameter("MemberId",model.MemberId)
						,(DbParameter)new SqlParameter("AddTime",model.AddTime)
						,(DbParameter)new SqlParameter("IsBuy",model.IsBuy)
						,(DbParameter)new SqlParameter("SupperName",model.SupperName)
			);
		}
		/// <summary>
		/// 删除VMemberCollectProduct
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from VMemberCollectProduct where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除VMemberCollectProduct
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from VMemberCollectProduct where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static VMemberCollectProduct ToModel(DataRow row)
		{
			VMemberCollectProduct model=new VMemberCollectProduct();
			model.Name =row.IsNull("Name")?null:(System.String)row["Name"];
			model.Simplename =row.IsNull("Simplename")?null:(System.String)row["Simplename"];
			model.Explain =row.IsNull("Explain")?null:(System.String)row["Explain"];
			model.Picturepath =row.IsNull("Picturepath")?null:(System.String)row["Picturepath"];
			model.Flashpath =row.IsNull("Flashpath")?null:(System.String)row["Flashpath"];
			model.Material =row.IsNull("Material")?null:(System.String)row["Material"];
			model.Weight =row.IsNull("Weight")?null:(System.String)row["Weight"];
			model.Volume =row.IsNull("Volume")?null:(System.String)row["Volume"];
			model.Specification =row.IsNull("Specification")?null:(System.String)row["Specification"];
			model.Issell =row.IsNull("Issell")?null:(System.String)row["Issell"];
			model.Model =row.IsNull("Model")?null:(System.String)row["Model"];
			model.Isexcellent =row.IsNull("Isexcellent")?null:(System.String)row["Isexcellent"];
			model.Nongenetic =row.IsNull("Nongenetic")?null:(System.String)row["Nongenetic"];
			model.Isrecomment =row.IsNull("Isrecomment")?null:(System.String)row["Isrecomment"];
			model.Isshow =row.IsNull("Isshow")?null:(System.String)row["Isshow"];
			model.Typeid =row.IsNull("Typeid")?null:(System.Int32?)row["Typeid"];
			model.Belongstype =row.IsNull("Belongstype")?null:(System.Int32?)row["Belongstype"];
			model.Num =row.IsNull("Num")?null:(System.Int64?)row["Num"];
			model.Soldnum =row.IsNull("Soldnum")?null:(System.Int64?)row["Soldnum"];
			model.Masterid =row.IsNull("Masterid")?null:(System.Int32?)row["Masterid"];
			model.Companyid =row.IsNull("Companyid")?null:(System.Int32?)row["Companyid"];
			model.Lsprice =row.IsNull("Lsprice")?null:(System.Double?)row["Lsprice"];
			model.rank =row.IsNull("rank")?null:(System.Int64?)row["rank"];
			model.hit =row.IsNull("hit")?null:(System.Int64?)row["hit"];
			model.Pfprice =row.IsNull("Pfprice")?null:(System.Double?)row["Pfprice"];
			model.ProductId =row.IsNull("ProductId")?null:(System.Int64?)row["ProductId"];
			model.MemberId =row.IsNull("MemberId")?null:(System.Int32?)row["MemberId"];
			model.AddTime =row.IsNull("AddTime")?null:(System.DateTime?)row["AddTime"];
			model.IsBuy =row.IsNull("IsBuy")?null:(System.String)row["IsBuy"];
			model.SupperName =row.IsNull("SupperName")?null:(System.String)row["SupperName"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VMemberCollectProduct Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VMemberCollectProduct where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			VMemberCollectProduct model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VMemberCollectProduct> ListAll()
		{
			List<VMemberCollectProduct> list=new List<VMemberCollectProduct>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VMemberCollectProduct");
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
		public IEnumerable<VMemberCollectProduct> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<VMemberCollectProduct> list=new List<VMemberCollectProduct>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from VMemberCollectProduct"+strWhere);
		}
	}
}
