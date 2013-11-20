using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/15 16:32:37
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///company表Model
	 ///</summary>
	public partial class company
	{
		public System.Int32? Id {get;set;}
		public System.String Name {get;set;}
		public System.String Username {get;set;}
		public System.String Password {get;set;}
		public System.String Introduction {get;set;}
		public System.String Representative {get;set;}
		public System.String Isrecommend {get;set;}
		public System.String Isshow {get;set;}
		public System.String Picturepath {get;set;}
		public System.String Website {get;set;}
		public System.String mobilephone {get;set;}
		public System.String Telephone {get;set;}
		public System.String Fac {get;set;}
		public System.String Email {get;set;}
		public System.String QQ {get;set;}
		public System.String Zipcode {get;set;}
		public System.String Address {get;set;}
		public System.String Award {get;set;}
		public System.String State {get;set;}
		public System.String State1 {get;set;}
		public System.Int64? hit {get;set;}
		public System.Int64? rank {get;set;}
        public System.String VCode { get; set; }
        public System.DateTime? VTime { get; set; }
	}
}
