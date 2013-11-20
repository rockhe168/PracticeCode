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
 *  创建时间: 2012/4/30 17:11:10
 *  类说明: czcraft.DAL
 */ 
{
	 ///<summary>
	 ///VMasterType表DAL
	 ///</summary>
	public partial class VMasterTypeDAL
	{
		DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
		/// <summary>
		/// 增加VMasterType
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public int AddNew(VMasterType model)
		{
			string sql="insert into VMasterType(TypeName,Typeid,Belongsid,level,IsLeaf,FId,Masterid,m_TypeId) output inserted.Id values(@TypeName,@Typeid,@Belongsid,@level,@IsLeaf,@FId,@Masterid,@m_TypeId)";
			int id=(int)SqlHelper.ExecuteScalar(sql
						,(DbParameter)new SqlParameter("TypeName",model.TypeName)
						,(DbParameter)new SqlParameter("Typeid",model.Typeid)
						,(DbParameter)new SqlParameter("Belongsid",model.Belongsid)
						,(DbParameter)new SqlParameter("level",model.level)
						,(DbParameter)new SqlParameter("IsLeaf",model.IsLeaf)
						,(DbParameter)new SqlParameter("FId",model.FId)
						,(DbParameter)new SqlParameter("Masterid",model.Masterid)
						,(DbParameter)new SqlParameter("m_TypeId",model.m_TypeId)
			);
			return id;
		}
		/// <summary>
		/// 更新VMasterType实体
		/// </summary>
		/// <param name="model">tableName实体</param>
		/// <returns>执行状态</returns>
		public bool Update(VMasterType model)
		{
			string sql="update VMasterType set TypeName=@TypeName,Typeid=@Typeid,Belongsid=@Belongsid,level=@level,IsLeaf=@IsLeaf,FId=@FId,Masterid=@Masterid,m_TypeId=@m_TypeId where id=@id";
		return SqlHelper.ExecuteNonQuery(sql
						,(DbParameter)new SqlParameter("TypeName",model.TypeName)
						,(DbParameter)new SqlParameter("Typeid",model.Typeid)
						,(DbParameter)new SqlParameter("Belongsid",model.Belongsid)
						,(DbParameter)new SqlParameter("level",model.level)
						,(DbParameter)new SqlParameter("IsLeaf",model.IsLeaf)
						,(DbParameter)new SqlParameter("FId",model.FId)
						,(DbParameter)new SqlParameter("Masterid",model.Masterid)
						,(DbParameter)new SqlParameter("m_TypeId",model.m_TypeId)
			);
		}
		/// <summary>
		/// 删除VMasterType
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public bool Delete(int id)
		{
		return SqlHelper.ExecuteNonQuery("delete from VMasterType where id=@id",
						(DbParameter)new SqlParameter("id",id));
		}
		/// <summary>
		/// 删除VMasterType
		/// </summary>
		/// <param name="strID">strID,记得多个用,隔开</param>
		/// <returns>执行状态</returns>
		public bool DeleteMoreID(string strID)
		{
		return SqlHelper.ExecuteNonQuery("delete from VMasterType where id in ("+strID+")");
		}
		/// <summary>
		/// 将DataRow转化为Model实体
		/// </summary>
		/// <param name="row">DataRow信息</param>
		/// <returns>执行状态</returns>
		private static VMasterType ToModel(DataRow row)
		{
			VMasterType model=new VMasterType();
			model.TypeName =row.IsNull("TypeName")?null:(System.String)row["TypeName"];
			model.Typeid =row.IsNull("Typeid")?null:(System.Int32?)row["Typeid"];
			model.Belongsid =row.IsNull("Belongsid")?null:(System.Int32?)row["Belongsid"];
			model.level =row.IsNull("level")?null:(System.Int32?)row["level"];
			model.IsLeaf =row.IsNull("IsLeaf")?null:(System.String)row["IsLeaf"];
			model.FId =row.IsNull("FId")?null:(System.String)row["FId"];
			model.Masterid =row.IsNull("Masterid")?null:(System.Int32?)row["Masterid"];
			model.m_TypeId =row.IsNull("m_TypeId")?null:(System.Int32?)row["m_TypeId"];
			return model;
		}
		/// <summary>
		/// 根据id获取tableName实体信息
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>执行状态</returns>
		public VMasterType Get(int id)
		{
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VMasterType where id=@id",
(DbParameter)new SqlParameter("id",id));
			if(dt.Rows.Count>1){
			throw new Exception("more than 1 row was found");
			}
			if(dt.Rows.Count<=0){return null;}
			DataRow row=dt.Rows[0];
			VMasterType model=ToModel(row);
			return model;
		}
		/// <summary>
		/// 列出tableName所有的实体信息
		/// </summary>
		/// <returns>执行状态</returns>
		public IEnumerable<VMasterType> ListAll()
		{
			List<VMasterType> list=new List<VMasterType>();
			DataTable dt=SqlHelper.ExecuteDataTable("select * from VMasterType");
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
		public IEnumerable<VMasterType> ListByPagination(string tableName,string InnerJoin,string strGetFields,string sortId,int PageSize,int PageIndex,string OrderType,string strWhere)
		{
			List<VMasterType> list=new List<VMasterType>();
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
			return SqlHelper.ExecuteSelectFirstNum("select count(1) from VMasterType"+strWhere);
		}
	}
}
