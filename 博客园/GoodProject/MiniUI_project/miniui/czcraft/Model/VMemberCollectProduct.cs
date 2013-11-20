using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/24 7:38:42
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///VMemberCollectProduct表Model
	 ///</summary>
	public partial class VMemberCollectProduct
	{
		public System.String Name {get;set;}
		public System.String Simplename {get;set;}
		public System.String Explain {get;set;}
		public System.String Picturepath {get;set;}
		public System.String Flashpath {get;set;}
		public System.String Material {get;set;}
		public System.String Weight {get;set;}
		public System.String Volume {get;set;}
		public System.String Specification {get;set;}
		public System.String Issell {get;set;}
		public System.String Model {get;set;}
		public System.String Isexcellent {get;set;}
		public System.String Nongenetic {get;set;}
		public System.String Isrecomment {get;set;}
		public System.String Isshow {get;set;}
		public System.Int32? Typeid {get;set;}
		public System.Int32? Belongstype {get;set;}
		public System.Int64? Num {get;set;}
		public System.Int64? Soldnum {get;set;}
		public System.Int32? Masterid {get;set;}
		public System.Int32? Companyid {get;set;}
		public System.Double? Lsprice {get;set;}
		public System.Int64? rank {get;set;}
		public System.Int64? hit {get;set;}
		public System.Double? Pfprice {get;set;}
		public System.Int64? ProductId {get;set;}
		public System.Int32? MemberId {get;set;}
		public System.DateTime? AddTime {get;set;}
		public System.String IsBuy {get;set;}
		public System.String SupperName {get;set;}
	}
}
