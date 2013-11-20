using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class Order : BusinessBase<int>
    {
        #region Declarations

		private System.DateTime? _orderDate = null;
		private System.DateTime? _requiredDate = null;
		private System.DateTime? _shippedDate = null;
		private decimal? _freight = null;
		private string _shipName = null;
		private string _shipAddress = null;
		private string _shipCity = null;
		private string _shipRegion = null;
		private string _shipPostalCode = null;
		private string _shipCountry = null;
		
		private Customer _customer = null;
		private Employee _employee = null;
		private Shipper _shipper = null;
		
		
		#endregion
        
        #region Constructors

        public Order() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_orderDate);
			sb.Append(_requiredDate);
			sb.Append(_shippedDate);
			sb.Append(_freight);
			sb.Append(_shipName);
			sb.Append(_shipAddress);
			sb.Append(_shipCity);
			sb.Append(_shipRegion);
			sb.Append(_shipPostalCode);
			sb.Append(_shipCountry);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual System.DateTime? OrderDate
        {
            get { return _orderDate; }
			set
			{
				OnOrderDateChanging();
				_orderDate = value;
				OnOrderDateChanged();
			}
        }
		partial void OnOrderDateChanging();
		partial void OnOrderDateChanged();
		
		public virtual System.DateTime? RequiredDate
        {
            get { return _requiredDate; }
			set
			{
				OnRequiredDateChanging();
				_requiredDate = value;
				OnRequiredDateChanged();
			}
        }
		partial void OnRequiredDateChanging();
		partial void OnRequiredDateChanged();
		
		public virtual System.DateTime? ShippedDate
        {
            get { return _shippedDate; }
			set
			{
				OnShippedDateChanging();
				_shippedDate = value;
				OnShippedDateChanged();
			}
        }
		partial void OnShippedDateChanging();
		partial void OnShippedDateChanged();
		
		public virtual decimal? Freight
        {
            get { return _freight; }
			set
			{
				OnFreightChanging();
				_freight = value;
				OnFreightChanged();
			}
        }
		partial void OnFreightChanging();
		partial void OnFreightChanged();
		
		public virtual string ShipName
        {
            get { return _shipName; }
			set
			{
				OnShipNameChanging();
				_shipName = value;
				OnShipNameChanged();
			}
        }
		partial void OnShipNameChanging();
		partial void OnShipNameChanged();
		
		public virtual string ShipAddress
        {
            get { return _shipAddress; }
			set
			{
				OnShipAddressChanging();
				_shipAddress = value;
				OnShipAddressChanged();
			}
        }
		partial void OnShipAddressChanging();
		partial void OnShipAddressChanged();
		
		public virtual string ShipCity
        {
            get { return _shipCity; }
			set
			{
				OnShipCityChanging();
				_shipCity = value;
				OnShipCityChanged();
			}
        }
		partial void OnShipCityChanging();
		partial void OnShipCityChanged();
		
		public virtual string ShipRegion
        {
            get { return _shipRegion; }
			set
			{
				OnShipRegionChanging();
				_shipRegion = value;
				OnShipRegionChanged();
			}
        }
		partial void OnShipRegionChanging();
		partial void OnShipRegionChanged();
		
		public virtual string ShipPostalCode
        {
            get { return _shipPostalCode; }
			set
			{
				OnShipPostalCodeChanging();
				_shipPostalCode = value;
				OnShipPostalCodeChanged();
			}
        }
		partial void OnShipPostalCodeChanging();
		partial void OnShipPostalCodeChanged();
		
		public virtual string ShipCountry
        {
            get { return _shipCountry; }
			set
			{
				OnShipCountryChanging();
				_shipCountry = value;
				OnShipCountryChanged();
			}
        }
		partial void OnShipCountryChanging();
		partial void OnShipCountryChanged();
		
		public virtual Customer Customer
        {
            get { return _customer; }
			set
			{
				OnCustomerChanging();
				_customer = value;
				OnCustomerChanged();
			}
        }
		partial void OnCustomerChanging();
		partial void OnCustomerChanged();
		
		public virtual Employee Employee
        {
            get { return _employee; }
			set
			{
				OnEmployeeChanging();
				_employee = value;
				OnEmployeeChanged();
			}
        }
		partial void OnEmployeeChanging();
		partial void OnEmployeeChanged();
		
		public virtual Shipper Shipper
        {
            get { return _shipper; }
			set
			{
				OnShipperChanging();
				_shipper = value;
				OnShipperChanged();
			}
        }
		partial void OnShipperChanging();
		partial void OnShipperChanged();
		
        #endregion
        
        public static OrderPropertyName PropertyNames=new OrderPropertyName();
    }
        #region PropertiesName扩展代码，用于获取属性名称
        
        
        
        public class OrderPropertyName
    {
        public readonly string Id=@"Id";
         public readonly string OrderDate=@"OrderDate";
         public readonly string RequiredDate=@"RequiredDate";
         public readonly string ShippedDate=@"ShippedDate";
         public readonly string Freight=@"Freight";
         public readonly string ShipName=@"ShipName";
         public readonly string ShipAddress=@"ShipAddress";
         public readonly string ShipCity=@"ShipCity";
         public readonly string ShipRegion=@"ShipRegion";
         public readonly string ShipPostalCode=@"ShipPostalCode";
         public readonly string ShipCountry=@"ShipCountry";
         public readonly string Customer=@"Customer";
         public readonly string Employee=@"Employee";
         public readonly string Shipper=@"Shipper";
    }
        #endregion
}
