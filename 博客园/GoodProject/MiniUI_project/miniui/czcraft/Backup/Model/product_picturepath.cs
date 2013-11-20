using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/1 11:06:01
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///product_picturepath表Model
	 ///</summary>
	public partial class product_picturepath
	{
		public System.Int32? Id {get;set;}
		public System.Int64? Productid {get;set;}
		public System.String Picturepath {get;set;}
	}
}
