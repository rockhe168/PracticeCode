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
	 ///WEB_USER表Model
	 ///</summary>
	public partial class WEB_USER
	{
		public System.String LOGNAME {get;set;}
		public System.String PASSWORD {get;set;}
		public System.String REALNAME {get;set;}
        //public System.Int32? USERGROUPID { get; set; }
        public WEB_USERGROUP GROUP { get; set; }
		public System.String STATE {get;set;}
		public System.DateTime? REG_DATE {get;set;}
		public System.DateTime? LAST_LOG_DATE {get;set;}
		public System.Int32? LOG_TIMES {get;set;}
		public System.String MEMO {get;set;}
		public System.Int32? ID {get;set;}
	}
}
