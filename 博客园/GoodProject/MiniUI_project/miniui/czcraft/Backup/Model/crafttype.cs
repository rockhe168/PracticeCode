using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/11 15:10:16
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///crafttype表Model
	 ///</summary>
	public partial class crafttype
	{
		public System.Int32? ID {get;set;}
		public System.String Name {get;set;}
		public System.Int32? level {get;set;}
		public System.Int32? Belongsid {get;set;}
		public System.String IsLeaf {get;set;}
        public System.String FId { get; set; }
	}
}
