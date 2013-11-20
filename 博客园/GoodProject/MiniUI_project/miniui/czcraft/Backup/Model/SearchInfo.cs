using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/29 10:43:11
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///SearchInfo表Model
	 ///</summary>
	public partial class SearchInfo
	{
		public System.Int64? Id {get;set;}
		public System.String Ip {get;set;}
		public System.DateTime? DateTime {get;set;}
		public System.String KeyWord {get;set;}
		public System.String SearchType {get;set;}
	}
}
