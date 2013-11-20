using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/11 15:06:59
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///VProductPic表Model
	 ///</summary>
	public partial class VProductPic
	{
		public System.Int64? Productid {get;set;}
		public System.String Picturepath {get;set;}
		public System.Int32? Id {get;set;}
		public System.String Name {get;set;}
		public System.Int32? Masterid {get;set;}
		public System.Int32? Companyid {get;set;}
	}
}
