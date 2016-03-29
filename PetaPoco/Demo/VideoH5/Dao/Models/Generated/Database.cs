
// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `videoContext`
//     Provider:               `MySql.Data.MySqlClient`
//     Connection String:      `Server=sdm209639120.my3w.com;Uid=sdm209639120;Pwd=yuantao8888;Database=sdm209639120_db;Port=3306`
//     Schema:                 ``
//     Include Views:          `False`

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace videoContext
{
	public partial class videoContextDB : Database
	{
		public videoContextDB() 
			: base("videoContext")
		{
			CommonConstruct();
		}

		public videoContextDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			videoContextDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static videoContextDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new videoContextDB();
        }

		[ThreadStatic] static videoContextDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        
		public class Record<T> where T:new()
		{
			public static videoContextDB repo { get { return videoContextDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }
			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }
			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }
		}
	}
	

    
	[TableName("sdm209639120_db.channel")]
	[PrimaryKey("id")]
	[ExplicitColumns]
    public partial class channel : videoContextDB.Record<channel>  
    {
		[Column] public long id { get; set; }
		[Column] public string channelNo { get; set; }
		[Column] public long count { get; set; }
		[Column] public DateTime date_created { get; set; }
	}
    
	[TableName("sdm209639120_db.channelHistory")]
	[PrimaryKey("id")]
	[ExplicitColumns]
    public partial class channelHistory : videoContextDB.Record<channelHistory>  
    {
		[Column] public long id { get; set; }
		[Column] public string channelNo { get; set; }
		[Column] public string ip { get; set; }
		[Column] public string url { get; set; }
		[Column] public DateTime date_created { get; set; }
	}
    
	[TableName("sdm209639120_db.paymentinfo")]
	[PrimaryKey("id")]
	[ExplicitColumns]
    public partial class paymentinfo : videoContextDB.Record<paymentinfo>  
    {
		[Column] public long id { get; set; }
		[Column] public string mac { get; set; }
		[Column] public string ip { get; set; }
		[Column] public DateTime date_created { get; set; }
		[Column] public string channelNo { get; set; }
		[Column] public string orderId { get; set; }
	}
}


