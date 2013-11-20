using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/1 11:06:01
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///VFindProductInfo表Model
	 ///</summary>
	public partial class VFindProductInfo
	{
		public System.String TypeName {get;set;}
		public System.String Name {get;set;}
		public System.String Simplename {get;set;}
		public System.String Isshow {get;set;}
		public System.Int32? Belongstype {get;set;}
		public System.Int64? Num {get;set;}
		public System.Int64? Soldnum {get;set;}
		public System.Int64? hit {get;set;}
		public System.Int64? rank {get;set;}
		public System.String MasterName {get;set;}
		public System.String CompanyName {get;set;}
		public System.String Isrecomment {get;set;}
		public System.String Nongenetic {get;set;}
		public System.String Isexcellent {get;set;}
		public System.String Issell {get;set;}
		public System.Int32? Typeid {get;set;}
		public System.Int32? Masterid {get;set;}
		public System.Int32? Companyid {get;set;}
		public System.String CompanyState1 {get;set;}
		public System.String CompanyState {get;set;}
		public System.String MasterState {get;set;}
		public System.String MasterState1 {get;set;}
		public System.Int64? Id {get;set;}
	}
}
