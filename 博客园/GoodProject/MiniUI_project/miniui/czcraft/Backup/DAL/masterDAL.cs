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
 *  创建时间: 2012/5/12 23:37:47
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///master表DAL
	 ///</summary>
	public partial class masterDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加master
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(master model)
		{
			string sql="insert into master(Username,Password,Name,Introduction,Isrecommend,Isshow,Picturepath,Sex,Nation,mobilephone,Telephone,Email,QQ,Zipcode,Address,appreciation,website,Reward,BirthDay,state,state1,hit,rank,VCode,VTime) output inserted.Id values(@Username,@Password,@Name,@Introduction,@Isrecommend,@Isshow,@Picturepath,@Sex,@Nation,@mobilephone,@Telephone,@Email,@QQ,@Zipcode,@Address,@appreciation,@website,@Reward,@BirthDay,@state,@state1,@hit,@rank,@VCode,@VTime)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("Username",model.Username)
						,(DbParameter)new SqlParameter("Password",model.Password)
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Introduction",model.Introduction)
						,(DbParameter)new SqlParameter("Isrecommend",model.Isrecommend)
						,(DbParameter)new SqlParameter("Isshow",model.Isshow)
						,(DbParameter)new SqlParameter("Picturepath",model.Picturepath)
						,(DbParameter)new SqlParameter("Sex",model.Sex)
						,(DbParameter)new SqlParameter("Nation",model.Nation)
						,(DbParameter)new SqlParameter("mobilephone",model.mobilephone)
						,(DbParameter)new SqlParameter("Telephone",model.Telephone)
						,(DbParameter)new SqlParameter("Email",model.Email)
						,(DbParameter)new SqlParameter("QQ",model.QQ)
						,(DbParameter)new SqlParameter("Zipcode",model.Zipcode)
						,(DbParameter)new SqlParameter("Address",model.Address)
						,(DbParameter)new SqlParameter("appreciation",model.appreciation)
						,(DbParameter)new SqlParameter("website",model.website)
						,(DbParameter)new SqlParameter("Reward",model.Reward)
						,(DbParameter)new SqlParameter("BirthDay",model.BirthDay)
						,(DbParameter)new SqlParameter("state",model.state)
						,(DbParameter)new SqlParameter("state1",model.state1)
						,(DbParameter)new SqlParameter("hit",model.hit)
						,(DbParameter)new SqlParameter("rank",model.rank)
						,(DbParameter)new SqlParameter("VCode",model.VCode)
						,(DbParameter)new SqlParameter("VTime",model.VTime)
			);
			return id;
		}
		/// <summary>
		/// 更新master实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(master model)
		{
			string sql="update master set Username=@Username,Password=@Password,Name=@Name,Introduction=@Introduction,Isrecommend=@Isrecommend,Isshow=@Isshow,Picturepath=@Picturepath,Sex=@Sex,Nation=@Nation,mobilephone=@mobilephone,Telephone=@Telephone,Email=@Email,QQ=@QQ,Zipcode=@Zipcode,Address=@Address,appreciation=@appreciation,website=@website,Reward=@Reward,BirthDay=@BirthDay,state=@state,state1=@state1,hit=@hit,rank=@rank,VCode=@VCode,VTime=@VTime where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("Username",model.Username)
						,(DbParameter)new SqlParameter("Password",model.Password)
						,(DbParameter)new SqlParameter("Name",model.Name)
						,(DbParameter)new SqlParameter("Introduction",model.Introduction)
						,(DbParameter)new SqlParameter("Isrecommend",model.Isrecommend)
						,(DbParameter)new SqlParameter("Isshow",model.Isshow)
						,(DbParameter)new SqlParameter("Picturepath",model.Picturepath)
						,(DbParameter)new SqlParameter("Sex",model.Sex)
						,(DbParameter)new SqlParameter("Nation",model.Nation)
						,(DbParameter)new SqlParameter("mobilephone",model.mobilephone)
						,(DbParameter)new SqlParameter("Telephone",model.Telephone)
						,(DbParameter)new SqlParameter("Email",model.Email)
						,(DbParameter)new SqlParameter("QQ",model.QQ)
						,(DbParameter)new SqlParameter("Zipcode",model.Zipcode)
						,(DbParameter)new SqlParameter("Address",model.Address)
						,(DbParameter)new SqlParameter("appreciation",model.appreciation)
						,(DbParameter)new SqlParameter("website",model.website)
						,(DbParameter)new SqlParameter("Reward",model.Reward)
						,(DbParameter)new SqlParameter("BirthDay",model.BirthDay)
						,(DbParameter)new SqlParameter("state",model.state)
						,(DbParameter)new SqlParameter("state1",model.state1)
						,(DbParameter)new SqlParameter("hit",model.hit)
						,(DbParameter)new SqlParameter("rank",model.rank)
						,(DbParameter)new SqlParameter("VCode",model.VCode)
						,(DbParameter)new SqlParameter("VTime",model.VTime)
			);
		}
	
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static master ToModel(DataRow row)
		{
			master model=new master();
			model.Id =row.IsNull("Id")?null:(System.Int32?)row["Id"];
			model.Username =row.IsNull("Username")?null:(System.String)row["Username"];
			model.Password =row.IsNull("Password")?null:(System.String)row["Password"];
			model.Name =row.IsNull("Name")?null:(System.String)row["Name"];
			model.Introduction =row.IsNull("Introduction")?null:(System.String)row["Introduction"];
			model.Isrecommend =row.IsNull("Isrecommend")?null:(System.String)row["Isrecommend"];
			model.Isshow =row.IsNull("Isshow")?null:(System.String)row["Isshow"];
			model.Picturepath =row.IsNull("Picturepath")?null:(System.String)row["Picturepath"];
			model.Sex =row.IsNull("Sex")?null:(System.String)row["Sex"];
			model.Nation =row.IsNull("Nation")?null:(System.String)row["Nation"];
			model.mobilephone =row.IsNull("mobilephone")?null:(System.String)row["mobilephone"];
			model.Telephone =row.IsNull("Telephone")?null:(System.String)row["Telephone"];
			model.Email =row.IsNull("Email")?null:(System.String)row["Email"];
			model.QQ =row.IsNull("QQ")?null:(System.String)row["QQ"];
			model.Zipcode =row.IsNull("Zipcode")?null:(System.String)row["Zipcode"];
			model.Address =row.IsNull("Address")?null:(System.String)row["Address"];
			model.appreciation =row.IsNull("appreciation")?null:(System.String)row["appreciation"];
			model.website =row.IsNull("website")?null:(System.String)row["website"];
			model.Reward =row.IsNull("Reward")?null:(System.String)row["Reward"];
			model.BirthDay =row.IsNull("BirthDay")?null:(System.DateTime?)row["BirthDay"];
			model.state =row.IsNull("state")?null:(System.String)row["state"];
			model.state1 =row.IsNull("state1")?null:(System.String)row["state1"];
			model.hit =row.IsNull("hit")?null:(System.Int64?)row["hit"];
			model.rank =row.IsNull("rank")?null:(System.Int64?)row["rank"];
			model.VCode =row.IsNull("VCode")?null:(System.String)row["VCode"];
			model.VTime =row.IsNull("VTime")?null:(System.DateTime?)row["VTime"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public master Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from master where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			master model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<master> ListAll()
		{
			List<master> list=new List<master>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from master");
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
		public IEnumerable<master> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<master> list=new List<master>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from master"+strWhere);
		}
	}
}
