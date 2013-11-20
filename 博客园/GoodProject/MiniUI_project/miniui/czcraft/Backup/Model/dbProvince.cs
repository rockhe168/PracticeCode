using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/3 16:10:28
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///dbProvince表Model
	 ///</summary>
	public partial class dbProvince
	{
		public System.Int32? codeid {get;set;}
		public System.Int32? parentid {get;set;}
		public System.String cityName {get;set;}
	}
}
