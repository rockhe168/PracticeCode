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
	 ///WEB_SYS_FUNTION表Model
	 ///</summary>
	public partial class WEB_SYS_FUNTION
	{
		public System.Int32? FUNTION_ID {get;set;}
		public System.String NAME {get;set;}
		public System.String URL {get;set;}
        public System.Int32? FATHER_ID { get; set; }
		public System.String STATE {get;set;}
		public System.String DESCRIPTION {get;set;}
	}
}
