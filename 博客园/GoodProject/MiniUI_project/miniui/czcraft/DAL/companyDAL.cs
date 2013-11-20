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
 *  创建时间: 2012/4/15 16:32:37
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///company表DAL
	 ///</summary>
	public partial class companyDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加company
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(company model)
		{
            string sql = "insert into company(Name,Username,Password,Introduction,Representative,Isrecommend,Isshow,Picturepath,Website,mobilephone,Telephone,Fac,Email,QQ,Zipcode,Address,Award,State,State1,hit,rank,VCode,VTime) output inserted.id values(@Name,@Username,@Password,@Introduction,@Representative,@Isrecommend,@Isshow,@Picturepath,@Website,@mobilephone,@Telephone,@Fac,@Email,@QQ,@Zipcode,@Address,@Award,@State,@State1,@hit,@rank,@VCode,@VTime)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Username",model.Username)
						,(DbParameter)new SqlParameter("Password",model.Password)
						,(DbParameter)new SqlParameter("Introduction",model.Introduction)
						,(DbParameter)new SqlParameter("Representative",model.Representative)
						,(DbParameter)new SqlParameter("Isrecommend",model.Isrecommend)
						,(DbParameter)new SqlParameter("Isshow",model.Isshow)
						,(DbParameter)new SqlParameter("Picturepath",model.Picturepath)
						,(DbParameter)new SqlParameter("Website",model.Website)
						,(DbParameter)new SqlParameter("mobilephone",model.mobilephone)
						,(DbParameter)new SqlParameter("Telephone",model.Telephone)
						,(DbParameter)new SqlParameter("Fac",model.Fac)
						,(DbParameter)new SqlParameter("Email",model.Email)
						,(DbParameter)new SqlParameter("QQ",model.QQ)
						,(DbParameter)new SqlParameter("Zipcode",model.Zipcode)
						,(DbParameter)new SqlParameter("Address",model.Address)
						,(DbParameter)new SqlParameter("Award",model.Award)
						,(DbParameter)new SqlParameter("State",model.State)
						,(DbParameter)new SqlParameter("State1",model.State1)
						,(DbParameter)new SqlParameter("hit",model.hit)
						,(DbParameter)new SqlParameter("rank",model.rank)
                         , (DbParameter)new SqlParameter("VCode", model.VCode)
                        , (DbParameter)new SqlParameter("VTime", model.VTime)
            );
			return id;
		}
		/// <summary>
		/// 更新company实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(company model)
		{
			string sql="update company set Name=@Name,Username=@Username,Password=@Password,Introduction=@Introduction,Representative=@Representative,Isrecommend=@Isrecommend,Isshow=@Isshow,Picturepath=@Picturepath,Website=@Website,mobilephone=@mobilephone,Telephone=@Telephone,Fac=@Fac,Email=@Email,QQ=@QQ,Zipcode=@Zipcode,Address=@Address,Award=@Award,State=@State,State1=@State1 where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Username",model.Username)
						,(DbParameter)new SqlParameter("Password",model.Password)
						,(DbParameter)new SqlParameter("Introduction",model.Introduction)
						,(DbParameter)new SqlParameter("Representative",model.Representative)
						,(DbParameter)new SqlParameter("Isrecommend",model.Isrecommend)
						,(DbParameter)new SqlParameter("Isshow",model.Isshow)
						,(DbParameter)new SqlParameter("Picturepath",model.Picturepath)
						,(DbParameter)new SqlParameter("Website",model.Website)
						,(DbParameter)new SqlParameter("mobilephone",model.mobilephone)
						,(DbParameter)new SqlParameter("Telephone",model.Telephone)
						,(DbParameter)new SqlParameter("Fac",model.Fac)
						,(DbParameter)new SqlParameter("Email",model.Email)
						,(DbParameter)new SqlParameter("QQ",model.QQ)
						,(DbParameter)new SqlParameter("Zipcode",model.Zipcode)
						,(DbParameter)new SqlParameter("Address",model.Address)
						,(DbParameter)new SqlParameter("Award",model.Award)
						,(DbParameter)new SqlParameter("State",model.State)
						,(DbParameter)new SqlParameter("State1",model.State1)
			);
		}

		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static company ToModel(DataRow row)
		{
			company model=new company();
			model.Id =row.IsNull("Id")?null:(System.Int32?)row["Id"];
			model.Name =row.IsNull("Name")?null:(System.String)row["Name"];
			model.Username =row.IsNull("Username")?null:(System.String)row["Username"];
			model.Password =row.IsNull("Password")?null:(System.String)row["Password"];
			model.Introduction =row.IsNull("Introduction")?null:(System.String)row["Introduction"];
			model.Representative =row.IsNull("Representative")?null:(System.String)row["Representative"];
			model.Isrecommend =row.IsNull("Isrecommend")?null:(System.String)row["Isrecommend"];
			model.Isshow =row.IsNull("Isshow")?null:(System.String)row["Isshow"];
			model.Picturepath =row.IsNull("Picturepath")?null:(System.String)row["Picturepath"];
			model.Website =row.IsNull("Website")?null:(System.String)row["Website"];
			model.mobilephone =row.IsNull("mobilephone")?null:(System.String)row["mobilephone"];
			model.Telephone =row.IsNull("Telephone")?null:(System.String)row["Telephone"];
			model.Fac =row.IsNull("Fac")?null:(System.String)row["Fac"];
			model.Email =row.IsNull("Email")?null:(System.String)row["Email"];
			model.QQ =row.IsNull("QQ")?null:(System.String)row["QQ"];
			model.Zipcode =row.IsNull("Zipcode")?null:(System.String)row["Zipcode"];
			model.Address =row.IsNull("Address")?null:(System.String)row["Address"];
			model.Award =row.IsNull("Award")?null:(System.String)row["Award"];
			model.State =row.IsNull("State")?null:(System.String)row["State"];
			model.State1 =row.IsNull("State1")?null:(System.String)row["State1"];
			model.hit =row.IsNull("hit")?null:(System.Int64?)row["hit"];
			model.rank =row.IsNull("rank")?null:(System.Int64?)row["rank"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public company Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from company where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			company model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<company> ListAll()
		{
			List<company> list=new List<company>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from company");
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
		public IEnumerable<company> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<company> list=new List<company>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from company"+strWhere);
		}
	}
}
