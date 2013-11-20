using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/22 9:22:31
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///comment表Model
	 ///</summary>
	public partial class comment
	{
		public System.Int64? Id {get;set;}
		public System.String Content {get;set;}
		public System.DateTime? Time {get;set;}
		public System.Int64? Productid {get;set;}
		public System.String huifuContent {get;set;}
		public System.Double? Grade {get;set;}
		public System.Int32? MemberId {get;set;}
	}
}
