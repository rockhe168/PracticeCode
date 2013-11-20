using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/1 17:55:54
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///VCompanyType表Model
	 ///</summary>
	public partial class VCompanyType
	{
		public System.Int32? Id {get;set;}
		public System.Int32? Companyid {get;set;}
		public System.String Name {get;set;}
		public System.Int32? level {get;set;}
		public System.Int32? Belongsid {get;set;}
		public System.String IsLeaf {get;set;}
		public System.String FId {get;set;}
		public System.Int32? Typeid {get;set;}
	}
}
