using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/10 9:26:55
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///VGroupFunction表Model
	 ///</summary>
	public partial class VGroupFunction
	{
		public System.String NAME {get;set;}
		public System.String function_state {get;set;}
		public System.String group_function_state {get;set;}
		public System.String DESCRIPTION {get;set;}
		public System.Int32? USERGROUPID {get;set;}
		public System.Int32? ID {get;set;}
		public System.Int32? FUNTION_ID {get;set;}
	}
}
