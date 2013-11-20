using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/13 19:36:03
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///ourinfo表Model
	 ///</summary>
	public partial class ourinfo
	{
		public System.Int32? Id {get;set;}
		public System.String Name {get;set;}
		public System.String Introduction {get;set;}
		public System.String Representative {get;set;}
		public System.String Website {get;set;}
		public System.String mobilephone {get;set;}
		public System.String Telephone {get;set;}
		public System.String Email {get;set;}
		public System.String qq {get;set;}
		public System.String Zipcode {get;set;}
		public System.String Address {get;set;}
	}
}
