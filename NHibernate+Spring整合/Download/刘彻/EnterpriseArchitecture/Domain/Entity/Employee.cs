using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class Employee : BusinessBase<int>
    {
        #region Declarations

		private string _lastName = String.Empty;
		private string _firstName = String.Empty;
		private string _title = null;
		private string _titleOfCourtesy = null;
		private System.DateTime? _birthDate = null;
		private System.DateTime? _hireDate = null;
		private string _address = null;
		private string _city = null;
		private string _region = null;
		private string _postalCode = null;
		private string _country = null;
		private string _homePhone = null;
		private string _extension = null;
		private byte[] _photo = null;
		private string _notes = null;
		private string _photoPath = null;
		
		private Employee _employeeMember = null;
		
		
		#endregion
        
        #region Constructors

        public Employee() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_lastName);
			sb.Append(_firstName);
			sb.Append(_title);
			sb.Append(_titleOfCourtesy);
			sb.Append(_birthDate);
			sb.Append(_hireDate);
			sb.Append(_address);
			sb.Append(_city);
			sb.Append(_region);
			sb.Append(_postalCode);
			sb.Append(_country);
			sb.Append(_homePhone);
			sb.Append(_extension);
			sb.Append(_photo);
			sb.Append(_notes);
			sb.Append(_photoPath);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string LastName
        {
            get { return _lastName; }
			set
			{
				OnLastNameChanging();
				_lastName = value;
				OnLastNameChanged();
			}
        }
		partial void OnLastNameChanging();
		partial void OnLastNameChanged();
		
		public virtual string FirstName
        {
            get { return _firstName; }
			set
			{
				OnFirstNameChanging();
				_firstName = value;
				OnFirstNameChanged();
			}
        }
		partial void OnFirstNameChanging();
		partial void OnFirstNameChanged();
		
		public virtual string Title
        {
            get { return _title; }
			set
			{
				OnTitleChanging();
				_title = value;
				OnTitleChanged();
			}
        }
		partial void OnTitleChanging();
		partial void OnTitleChanged();
		
		public virtual string TitleOfCourtesy
        {
            get { return _titleOfCourtesy; }
			set
			{
				OnTitleOfCourtesyChanging();
				_titleOfCourtesy = value;
				OnTitleOfCourtesyChanged();
			}
        }
		partial void OnTitleOfCourtesyChanging();
		partial void OnTitleOfCourtesyChanged();
		
		public virtual System.DateTime? BirthDate
        {
            get { return _birthDate; }
			set
			{
				OnBirthDateChanging();
				_birthDate = value;
				OnBirthDateChanged();
			}
        }
		partial void OnBirthDateChanging();
		partial void OnBirthDateChanged();
		
		public virtual System.DateTime? HireDate
        {
            get { return _hireDate; }
			set
			{
				OnHireDateChanging();
				_hireDate = value;
				OnHireDateChanged();
			}
        }
		partial void OnHireDateChanging();
		partial void OnHireDateChanged();
		
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
		
		public virtual string HomePhone
        {
            get { return _homePhone; }
			set
			{
				OnHomePhoneChanging();
				_homePhone = value;
				OnHomePhoneChanged();
			}
        }
		partial void OnHomePhoneChanging();
		partial void OnHomePhoneChanged();
		
		public virtual string Extension
        {
            get { return _extension; }
			set
			{
				OnExtensionChanging();
				_extension = value;
				OnExtensionChanged();
			}
        }
		partial void OnExtensionChanging();
		partial void OnExtensionChanged();
		
		public virtual byte[] Photo
        {
            get { return _photo; }
			set
			{
				OnPhotoChanging();
				_photo = value;
				OnPhotoChanged();
			}
        }
		partial void OnPhotoChanging();
		partial void OnPhotoChanged();
		
		public virtual string Notes
        {
            get { return _notes; }
			set
			{
				OnNotesChanging();
				_notes = value;
				OnNotesChanged();
			}
        }
		partial void OnNotesChanging();
		partial void OnNotesChanged();
		
		public virtual string PhotoPath
        {
            get { return _photoPath; }
			set
			{
				OnPhotoPathChanging();
				_photoPath = value;
				OnPhotoPathChanged();
			}
        }
		partial void OnPhotoPathChanging();
		partial void OnPhotoPathChanged();
		
		public virtual Employee EmployeeMember
        {
            get { return _employeeMember; }
			set
			{
				OnEmployeeMemberChanging();
				_employeeMember = value;
				OnEmployeeMemberChanged();
			}
        }
		partial void OnEmployeeMemberChanging();
		partial void OnEmployeeMemberChanged();
		
        #endregion
        
        public static EmployeePropertyName PropertyNames=new EmployeePropertyName();
    }
        #region PropertiesName扩展代码，用于获取属性名称
        
        
        
        public class EmployeePropertyName
    {
        public readonly string Id=@"Id";
         public readonly string LastName=@"LastName";
         public readonly string FirstName=@"FirstName";
         public readonly string Title=@"Title";
         public readonly string TitleOfCourtesy=@"TitleOfCourtesy";
         public readonly string BirthDate=@"BirthDate";
         public readonly string HireDate=@"HireDate";
         public readonly string Address=@"Address";
         public readonly string City=@"City";
         public readonly string Region=@"Region";
         public readonly string PostalCode=@"PostalCode";
         public readonly string Country=@"Country";
         public readonly string HomePhone=@"HomePhone";
         public readonly string Extension=@"Extension";
         public readonly string Photo=@"Photo";
         public readonly string Notes=@"Notes";
         public readonly string PhotoPath=@"PhotoPath";
         public readonly string EmployeeMember=@"EmployeeMember";
    }
        #endregion
}
