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
	 ///product表Model
	 ///</summary>
	public partial class product
	{
		public System.Int64? Id {get;set;}
		public System.String Name {get;set;}
		public System.String Simplename {get;set;}
		public System.String Explain {get;set;}
		public System.String Picturepath {get;set;}
		public System.String Flashpath {get;set;}
		public System.String Material {get;set;}
		public System.String Weight {get;set;}
		public System.String Volume {get;set;}
		public System.String Specification {get;set;}
		public System.String Model {get;set;}
		public System.String Issell {get;set;}
		public System.String Isexcellent {get;set;}
		public System.String Nongenetic {get;set;}
		public System.String Isrecomment {get;set;}
		public System.String Isshow {get;set;}
		public System.Int32? Typeid {get;set;}
		public System.Int32? Belongstype {get;set;}
		public System.Int32? Masterid {get;set;}
		public System.Int32? Companyid {get;set;}
		public System.Int64? Num {get;set;}
		public System.Int64? Soldnum {get;set;}
		public System.Double? Lsprice {get;set;}
		public System.Double? Pfprice {get;set;}
		public System.Double? Vipprice {get;set;}
		public System.Double? MarketPrice {get;set;}
		public System.Double? Price1 {get;set;}
		public System.Double? Price2 {get;set;}
		public System.Double? Price3 {get;set;}
		public System.Double? Price4 {get;set;}
		public System.Int64? hit {get;set;}
		public System.Int64? rank {get;set;}
	}
}
