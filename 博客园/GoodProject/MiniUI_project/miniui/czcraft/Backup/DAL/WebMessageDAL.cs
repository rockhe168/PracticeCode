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
 *  创建时间: 2012/5/8 8:34:36
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///WebMessage表DAL
	 ///</summary>
	public partial class WebMessageDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加WebMessage
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
        public long AddNew(WebMessage model)
		{
			string sql="insert into WebMessage(liuyanName,liuyanContent,liuyanTime,MobilePhone,Email) output inserted.Id values(@liuyanName,@liuyanContent,@liuyanTime,@MobilePhone,@Email)";
            //@HuifuName,@huifuTime,@huifuContent, HuifuName,huifuTime,huifuContent,
            long id = (long)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("liuyanName",model.liuyanName)
						,(DbParameter)new SqlParameter("liuyanContent",model.liuyanContent)
						,(DbParameter)new SqlParameter("liuyanTime",model.liuyanTime)
						//,(DbParameter)new SqlParameter("HuifuName",model.HuifuName)
						//,(DbParameter)new SqlParameter("huifuTime",model.huifuTime)
						//,(DbParameter)new SqlParameter("huifuContent",model.huifuContent)
						,(DbParameter)new SqlParameter("MobilePhone",model.MobilePhone)
						,(DbParameter)new SqlParameter("Email",model.Email)
			);
			return id;
		}
		/// <summary>
		/// 更新WebMessage实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(WebMessage model)
		{
			string sql="update WebMessage set liuyanName=@liuyanName,liuyanContent=@liuyanContent,liuyanTime=@liuyanTime,HuifuName=@HuifuName,huifuTime=@huifuTime,huifuContent=@huifuContent,MobilePhone=@MobilePhone,Email=@Email where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("Id",model.Id)
						,(DbParameter)new SqlParameter("liuyanName",model.liuyanName)
						,(DbParameter)new SqlParameter("liuyanContent",model.liuyanContent)
						,(DbParameter)new SqlParameter("liuyanTime",model.liuyanTime)
						,(DbParameter)new SqlParameter("HuifuName",model.HuifuName)
						,(DbParameter)new SqlParameter("huifuTime",model.huifuTime)
						,(DbParameter)new SqlParameter("huifuContent",model.huifuContent)
						,(DbParameter)new SqlParameter("MobilePhone",model.MobilePhone)
						,(DbParameter)new SqlParameter("Email",model.Email)
			);
		}
		/// <summary>
		/// 删除WebMessage
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
        public bool Delete(long id)
		{
		return SqlHelper.ExecuteNonQuery("delete from WebMessage where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除WebMessage
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from WebMessage where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static WebMessage ToModel(DataRow row)
		{
			WebMessage model=new WebMessage();
			model.Id =row.IsNull("Id")?null:(System.Int64?)row["Id"];
			model.liuyanName =row.IsNull("liuyanName")?null:(System.String)row["liuyanName"];
			model.liuyanContent =row.IsNull("liuyanContent")?null:(System.String)row["liuyanContent"];
			model.liuyanTime =row.IsNull("liuyanTime")?null:(System.DateTime?)row["liuyanTime"];
			model.HuifuName =row.IsNull("HuifuName")?null:(System.String)row["HuifuName"];
			model.huifuTime =row.IsNull("huifuTime")?null:(System.DateTime?)row["huifuTime"];
			model.huifuContent =row.IsNull("huifuContent")?null:(System.String)row["huifuContent"];
			model.MobilePhone =row.IsNull("MobilePhone")?null:(System.String)row["MobilePhone"];
			model.Email =row.IsNull("Email")?null:(System.String)row["Email"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
        public WebMessage Get(long id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from WebMessage where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			WebMessage model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<WebMessage> ListAll()
		{
			List<WebMessage> list=new List<WebMessage>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from WebMessage");
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
		public IEnumerable<WebMessage> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<WebMessage> list=new List<WebMessage>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from WebMessage"+strWhere);
		}
	}
}
