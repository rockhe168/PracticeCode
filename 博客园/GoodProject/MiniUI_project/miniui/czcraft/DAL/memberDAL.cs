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
 *  创建时间: 2012/5/5 10:13:44
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///member表DAL
	 ///</summary>
	public partial class memberDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加member
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(member model)
		{
			string sql="insert into member(username,password,Sex,nation,mobilephone,Telephone,Email,qq,Zipcode,Address,states,VCode,VTime) output inserted.Id values(@username,@password,@Sex,@nation,@mobilephone,@Telephone,@Email,@qq,@Zipcode,@Address,@states,@VCode,@VTime)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("username",model.username)
						,(DbParameter)new SqlParameter("password",model.password)
						,(DbParameter)new SqlParameter("Sex",model.Sex)
						,(DbParameter)new SqlParameter("nation",model.nation)
						,(DbParameter)new SqlParameter("mobilephone",model.mobilephone)
						,(DbParameter)new SqlParameter("Telephone",model.Telephone)
						,(DbParameter)new SqlParameter("Email",model.Email)
						,(DbParameter)new SqlParameter("qq",model.qq)
						,(DbParameter)new SqlParameter("Zipcode",model.Zipcode)
						,(DbParameter)new SqlParameter("Address",model.Address)
						,(DbParameter)new SqlParameter("states",model.states)
						,(DbParameter)new SqlParameter("VCode",model.VCode)
						,(DbParameter)new SqlParameter("VTime",model.VTime)
			);
			return id;
		}
		/// <summary>
		/// 更新member实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(member model)
		{
			string sql="update member set username=@username,password=@password,Sex=@Sex,nation=@nation,mobilephone=@mobilephone,Telephone=@Telephone,Email=@Email,qq=@qq,Zipcode=@Zipcode,Address=@Address,states=@states where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("username",model.username)
						,(DbParameter)new SqlParameter("password",model.password)
						,(DbParameter)new SqlParameter("Sex",model.Sex)
						,(DbParameter)new SqlParameter("nation",model.nation)
						,(DbParameter)new SqlParameter("mobilephone",model.mobilephone)
						,(DbParameter)new SqlParameter("Telephone",model.Telephone)
						,(DbParameter)new SqlParameter("Email",model.Email)
						,(DbParameter)new SqlParameter("qq",model.qq)
						,(DbParameter)new SqlParameter("Zipcode",model.Zipcode)
						,(DbParameter)new SqlParameter("Address",model.Address)
						,(DbParameter)new SqlParameter("states",model.states)
                        //,(DbParameter)new SqlParameter("VCode",model.VCode)
                        //,(DbParameter)new SqlParameter("VTime",model.VTime)
			);
		}
	
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static member ToModel(DataRow row)
		{
			member model=new member();
			model.Id =row.IsNull("Id")?null:(System.Int32?)row["Id"];
			model.username =row.IsNull("username")?null:(System.String)row["username"];
			model.password =row.IsNull("password")?null:(System.String)row["password"];
			model.Sex =row.IsNull("Sex")?null:(System.String)row["Sex"];
			model.nation =row.IsNull("nation")?null:(System.String)row["nation"];
			model.mobilephone =row.IsNull("mobilephone")?null:(System.String)row["mobilephone"];
			model.Telephone =row.IsNull("Telephone")?null:(System.String)row["Telephone"];
			model.Email =row.IsNull("Email")?null:(System.String)row["Email"];
			model.qq =row.IsNull("qq")?null:(System.String)row["qq"];
			model.Zipcode =row.IsNull("Zipcode")?null:(System.String)row["Zipcode"];
			model.Address =row.IsNull("Address")?null:(System.String)row["Address"];
			model.states =row.IsNull("states")?null:(System.String)row["states"];
			model.VCode =row.IsNull("VCode")?null:(System.String)row["VCode"];
			model.VTime =row.IsNull("VTime")?null:(System.DateTime?)row["VTime"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public member Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from member where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			member model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<member> ListAll()
		{
			List<member> list=new List<member>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from member");
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
		public IEnumerable<member> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<member> list=new List<member>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from member"+strWhere);
		}
	}
}
