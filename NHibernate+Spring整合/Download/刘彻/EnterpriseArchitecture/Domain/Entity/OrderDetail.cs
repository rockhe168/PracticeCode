using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class OrderDetail : BusinessBase<string>
    {
        #region Declarations

		private int _orderID = default(Int32);
		private int _productID = default(Int32);
		private decimal _unitPrice = default(Decimal);
		private short _quantity = default(Int16);
		private float _discount = default(Single);
		
		
		
		#endregion
        
        #region Constructors

        public OrderDetail() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_orderID);
			sb.Append(_productID);
			sb.Append(_unitPrice);
			sb.Append(_quantity);
			sb.Append(_discount);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public override string Id
		{
			get
			{
				System.Text.StringBuilder uniqueId = new System.Text.StringBuilder();
				uniqueId.Append(_orderID.ToString());
				uniqueId.Append("^");
				uniqueId.Append(_productID.ToString());
				return uniqueId.ToString();
			}
		}
		
		public virtual int OrderID
        {
            get { return _orderID; }
			set
			{
				OnOrderIDChanging();
				_orderID = value;
				OnOrderIDChanged();
			}
        }
		partial void OnOrderIDChanging();
		partial void OnOrderIDChanged();
		
		public virtual int ProductID
        {
            get { return _productID; }
			set
			{
				OnProductIDChanging();
				_productID = value;
				OnProductIDChanged();
			}
        }
		partial void OnProductIDChanging();
		partial void OnProductIDChanged();
		
		public virtual decimal UnitPrice
        {
            get { return _unitPrice; }
			set
			{
				OnUnitPriceChanging();
				_unitPrice = value;
				OnUnitPriceChanged();
			}
        }
		partial void OnUnitPriceChanging();
		partial void OnUnitPriceChanged();
		
		public virtual short Quantity
        {
            get { return _quantity; }
			set
			{
				OnQuantityChanging();
				_quantity = value;
				OnQuantityChanged();
			}
        }
		partial void OnQuantityChanging();
		partial void OnQuantityChanged();
		
		public virtual float Discount
        {
            get { return _discount; }
			set
			{
				OnDiscountChanging();
				_discount = value;
				OnDiscountChanged();
			}
        }
		partial void OnDiscountChanging();
		partial void OnDiscountChanged();
		
        #endregion
        
        public static OrderDetailPropertyName PropertyNames=new OrderDetailPropertyName();
    }
        #region PropertiesName扩展代码，用于获取属性名称
        
        
        
        public class OrderDetailPropertyName
    {
        public readonly string Id=@"Id";
         public readonly string OrderID=@"OrderID";
         public readonly string ProductID=@"ProductID";
         public readonly string UnitPrice=@"UnitPrice";
         public readonly string Quantity=@"Quantity";
         public readonly string Discount=@"Discount";
    }
        #endregion
}
