using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/21 7:53:52
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///orderproduct表Model
	 ///</summary>
	public partial class orderproduct
	{
		public System.Int32? Id {get;set;}
		public System.String OrderId {get;set;}
		public System.String ProId {get;set;}
		public System.String ProClass {get;set;}
		public System.String ProName {get;set;}
		public System.String ProImg {get;set;}
		public System.Double? ProPrice {get;set;}
		public System.Int32? ProNum {get;set;}
		public System.DateTime? AddTime {get;set;}
		public System.String ProOtherPara {get;set;}
		public System.String Specification {get;set;}
		public System.String Remark {get;set;}
		public System.Int32? SupperlierId {get;set;}
		public System.Int32? BelongType {get;set;}
		public System.String SupperlierName {get;set;}
	}
}
