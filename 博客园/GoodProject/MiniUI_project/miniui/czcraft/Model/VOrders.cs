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
	 ///VOrders表Model
	 ///</summary>
	public partial class VOrders
	{
		public System.String OrderId {get;set;}
		public System.Int32? Id {get;set;}
		public System.String ProId {get;set;}
		public System.String ProImg {get;set;}
		public System.String ProName {get;set;}
		public System.Double? ProPrice {get;set;}
		public System.Int32? ProNum {get;set;}
		public System.Double? TotalPrice {get;set;}
		public System.String OrderStatus {get;set;}
		public System.String PaymentStatus {get;set;}
		public System.Double? Carriage {get;set;}
		public System.String OgisticsStatus {get;set;}
		public System.String OrderType {get;set;}
		public System.Double? FactPrice {get;set;}
		public System.String ConsigneeRealName {get;set;}
		public System.String ConsigneeName {get;set;}
		public System.String ConsigneePhone {get;set;}
		public System.String ConsigneeProvince {get;set;}
		public System.String ConsigneeAddress {get;set;}
		public System.String ConsigneeZip {get;set;}
		public System.String ConsigneeTel {get;set;}
		public System.String ConsigneeEmail {get;set;}
		public System.String PaymentType {get;set;}
		public System.DateTime? ShopDate {get;set;}
		public System.DateTime? OrderDate {get;set;}
		public System.Int32? UserId {get;set;}
		public System.DateTime? AddTime {get;set;}
		public System.Int32? IsOrderNormal {get;set;}
		public System.Int32? BelongType {get;set;}
		public System.Int32? SupperlierId {get;set;}
		public System.String SupperlierName {get;set;}
	}
}
