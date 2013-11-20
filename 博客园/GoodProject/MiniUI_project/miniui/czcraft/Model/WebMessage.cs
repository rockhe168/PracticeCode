using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/8 8:34:36
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///WebMessage表Model
	 ///</summary>
	public partial class WebMessage
	{
		public System.Int64? Id {get;set;}
		public System.String liuyanName {get;set;}
		public System.String liuyanContent {get;set;}
		public System.DateTime? liuyanTime {get;set;}
		public System.String HuifuName {get;set;}
		public System.DateTime? huifuTime {get;set;}
		public System.String huifuContent {get;set;}
		public System.String MobilePhone {get;set;}
		public System.String Email {get;set;}

	}
}
