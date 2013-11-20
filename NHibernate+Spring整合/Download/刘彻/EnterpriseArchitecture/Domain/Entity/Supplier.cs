using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class Supplier : BusinessBase<int>
    {
        #region Declarations

		private string _companyName = String.Empty;
		private string _contactName = null;
		private string _contactTitle = null;
		private string _address = null;
		private string _city = null;
		private string _region = null;
		private string _postalCode = null;
		private string _country = null;
		private string _phone = null;
		private string _fax = null;
		private string _homePage = null;
		
		
		private IList<Product> _products = new List<Product>();
		
		#endregion
        
        #region Constructors

        public Supplier() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_companyName);
			sb.Append(_contactName);
			sb.Append(_contactTitle);
			sb.Append(_address);
			sb.Append(_city);
			sb.Append(_region);
			sb.Append(_postalCode);
			sb.Append(_country);
			sb.Append(_phone);
			sb.Append(_fax);
			sb.Append(_homePage);

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
		
		public virtual string ContactName
        {
            get { return _contactName; }
			set
			{
				OnContactNameChanging();
				_contactName = value;
				OnContactNameChanged();
			}
        }
		partial void OnContactNameChanging();
		partial void OnContactNameChanged();
		
		public virtual string ContactTitle
        {
            get { return _contactTitle; }
			set
			{
				OnContactTitleChanging();
				_contactTitle = value;
				OnContactTitleChanged();
			}
        }
		partial void OnContactTitleChanging();
		partial void OnContactTitleChanged();
		
		public virtual string Address
        {
            get { return _address; }
			set
			{
				OnAddressChanging();
				_address = value;
				OnAddressChanged();
			}
        }
		partial void OnAddressChanging();
		partial void OnAddressChanged();
		
		public virtual string City
        {
            get { return _city; }
			set
			{
				OnCityChanging();
				_city = value;
				OnCityChanged();
			}
        }
		partial void OnCityChanging();
		partial void OnCityChanged();
		
		public virtual string Region
        {
            get { return _region; }
			set
			{
				OnRegionChanging();
				_region = value;
				OnRegionChanged();
			}
        }
		partial void OnRegionChanging();
		partial void OnRegionChanged();
		
		public virtual string PostalCode
        {
            get { return _postalCode; }
			set
			{
				OnPostalCodeChanging();
				_postalCode = value;
				OnPostalCodeChanged();
			}
        }
		partial void OnPostalCodeChanging();
		partial void OnPostalCodeChanged();
		
		public virtual string Country
        {
            get { return _country; }
			set
			{
				OnCountryChanging();
				_country = value;
				OnCountryChanged();
			}
        }
		partial void OnCountryChanging();
		partial void OnCountryChanged();
		
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
		
		public virtual string Fax
        {
            get { return _fax; }
			set
			{
				OnFaxChanging();
				_fax = value;
				OnFaxChanged();
			}
        }
		partial void OnFaxChanging();
		partial void OnFaxChanged();
		
		public virtual string HomePage
        {
            get { return _homePage; }
			set
			{
				OnHomePageChanging();
				_homePage = value;
				OnHomePageChanged();
			}
        }
		partial void OnHomePageChanging();
		partial void OnHomePageChanged();
		
		public virtual IList<Product> Products
        {
            get { return _products; }
            set
			{
				OnProductsChanging();
				_products = value;
				OnProductsChanged();
			}
        }
		partial void OnProductsChanging();
		partial void OnProductsChanged();
		
        #endregion
        
        public static SupplierPropertyName PropertyNames=new SupplierPropertyName();
    }
        #region PropertiesName扩展代码，用于获取属性名称
        
        
        
        public class SupplierPropertyName
    {
        public readonly string Id=@"Id";
         public readonly string CompanyName=@"CompanyName";
         public readonly string ContactName=@"ContactName";
         public readonly string ContactTitle=@"ContactTitle";
         public readonly string Address=@"Address";
         public readonly string City=@"City";
         public readonly string Region=@"Region";
         public readonly string PostalCode=@"PostalCode";
         public readonly string Country=@"Country";
         public readonly string Phone=@"Phone";
         public readonly string Fax=@"Fax";
         public readonly string HomePage=@"HomePage";
         public readonly string Products=@"Products";
    }
        #endregion
}
