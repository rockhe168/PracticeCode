using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/14 15:17:39
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///master_cert表Model
	 ///</summary>
	public partial class master_cert
	{
		public System.Int64? id {get;set;}
		public System.String Name {get;set;}
		public System.String Picpath {get;set;}
		public System.Int32? Masterid {get;set;}
	}
}
