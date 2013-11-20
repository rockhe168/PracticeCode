using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/25 20:21:09
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///SystemLog表Model
	 ///</summary>
	public partial class SystemLog
	{
		public System.Int64? Id {get;set;}
		public System.String Title {get;set;}
		public System.DateTime? AddTime {get;set;}
		public System.String Url {get;set;}
		public System.String UserName {get;set;}
	}
}
