using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/5/21 7:50:43
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///orders表Model
	 ///</summary>
	public partial class orders
	{
		public System.Int32? Id {get;set;}
		public System.String OrderId {get;set;}
		public System.Int32? UserId {get;set;}
		public System.DateTime? ShopDate {get;set;}
		public System.DateTime? OrderDate {get;set;}
		public System.String ConsigneeRealName {get;set;}
		public System.String ConsigneeName {get;set;}
		public System.String ConsigneePhone {get;set;}
		public System.String ConsigneeProvince {get;set;}
		public System.String ConsigneeAddress {get;set;}
		public System.String ConsigneeZip {get;set;}
		public System.String ConsigneeTel {get;set;}
		public System.String ConsigneeEmail {get;set;}
		public System.String PaymentType {get;set;}
		public System.Double? Payment {get;set;}
		public System.String Courier {get;set;}
		public System.Double? TotalPrice {get;set;}
		public System.Double? FactPrice {get;set;}
		public System.Int32? Invoice {get;set;}
		public System.String Remark {get;set;}
		public System.String OrderStatus {get;set;}
		public System.String PaymentStatus {get;set;}
		public System.String OgisticsStatus {get;set;}
		public System.Double? Carriage {get;set;}
		public System.String OrderType {get;set;}
		public System.Int32? IsOrderNormal {get;set;}
	}
}
