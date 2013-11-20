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
	 ///MemberCollection表Model
	 ///</summary>
	public partial class MemberCollection
	{
		public System.Int64? ProductId {get;set;}
		public System.Int32? MemberId {get;set;}
		public System.DateTime? AddTime {get;set;}
		public System.String IsBuy {get;set;}
		public System.String SupperName {get;set;}
	}
}
