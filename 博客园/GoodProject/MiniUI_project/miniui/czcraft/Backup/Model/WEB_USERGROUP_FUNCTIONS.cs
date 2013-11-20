using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/7 12:40:09
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///WEB_USERGROUP_FUNCTIONS表Model
	 ///</summary>
	public partial class WEB_USERGROUP_FUNCTIONS
	{
		public System.Int32? ID {get;set;}
        public System.Int32? USERGROUPID { get; set; }
        public System.Int32? FUNCTION_ID { get; set; }
       //public WEB_SYS_FUNTION FUNTION { get; set; }
		public System.String STATE {get;set;}
	}
}
