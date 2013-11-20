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
	 ///company_cert表Model
	 ///</summary>
	public partial class company_cert
	{
		public System.Int64? Id {get;set;}
		public System.String Name {get;set;}
		public System.String Picpath {get;set;}
		public System.Int32? Companyid {get;set;}
	}
}
