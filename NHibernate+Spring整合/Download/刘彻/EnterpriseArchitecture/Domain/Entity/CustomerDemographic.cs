using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class CustomerDemographic : BusinessBase<string>
    {
        #region Declarations

		private string _customerDesc = null;
		
		
		private IList<Customer> _customers = new List<Customer>();
		
		#endregion
        
        #region Constructors

        public CustomerDemographic() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_customerDesc);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string CustomerDesc
        {
            get { return _customerDesc; }
			set
			{
				OnCustomerDescChanging();
				_customerDesc = value;
				OnCustomerDescChanged();
			}
        }
		partial void OnCustomerDescChanging();
		partial void OnCustomerDescChanged();
		
		public virtual IList<Customer> Customers
        {
            get { return _customers; }
            set
			{
				OnCustomersChanging();
				_customers = value;
				OnCustomersChanged();
			}
        }
		partial void OnCustomersChanging();
		partial void OnCustomersChanged();
		
        #endregion
        
        public static CustomerDemographicPropertyName PropertyNames=new CustomerDemographicPropertyName();
    }
        #region PropertiesName扩展代码，用于获取属性名称
        
        
        
        public class CustomerDemographicPropertyName
    {
        public readonly string Id=@"Id";
         public readonly string CustomerDesc=@"CustomerDesc";
         public readonly string Customers=@"Customers";
    }
        #endregion
}
