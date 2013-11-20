using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/15 23:57:19
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///ShoppingCart表Model
	 ///</summary>
	public partial class ShoppingCart
	{
		public System.Int64? Id {get;set;}
		public System.Int64? ProductId {get;set;}
		public System.Int32? SupperlierId {get;set;}
		public System.Int32? BelongType {get;set;}
		public System.Int32? Quantity {get;set;}
		public System.String SupperlierName {get;set;}
		public System.Double? Price {get;set;}
		public System.Int32? MemberId {get;set;}
		public System.String ProductName {get;set;}
	}
}
