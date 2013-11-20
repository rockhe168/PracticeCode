using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class Shipper : BusinessBase<int>
    {
        #region Declarations

		private string _companyName = String.Empty;
		private string _phone = null;
		
		
		private IList<Order> _orders = new List<Order>();
		
		#endregion
        
        #region Constructors

        public Shipper() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_companyName);
			sb.Append(_phone);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string CompanyName
        {
            get { return _companyName; }
			set
			{
				OnCompanyNameChanging();
				_companyName = value;
				OnCompanyNameChanged();
			}
        }
		partial void OnCompanyNameChanging();
		partial void OnCompanyNameChanged();
		
		public virtual string Phone
        {
            get { return _phone; }
			set
			{
				OnPhoneChanging();
				_phone = value;
				OnPhoneChanged();
			}
        }
		partial void OnPhoneChanging();
		partial void OnPhoneChanged();
		
		public virtual IList<Order> Orders
        {
            get { return _orders; }
            set
			{
				OnOrdersChanging();
				_orders = value;
				OnOrdersChanged();
			}
        }
		partial void OnOrdersChanging();
		partial void OnOrdersChanged();
		
        #endregion
        
        public static ShipperPropertyName PropertyNames=new ShipperPropertyName();
    }
        #region PropertiesName扩展代码，用于获取属性名称
        
        
        
        public class ShipperPropertyName
    {
        public readonly string Id=@"Id";
         public readonly string CompanyName=@"CompanyName";
         public readonly string Phone=@"Phone";
         public readonly string Orders=@"Orders";
    }
        #endregion
}
