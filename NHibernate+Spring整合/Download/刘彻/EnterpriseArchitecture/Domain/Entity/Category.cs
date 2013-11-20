using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class Category : BusinessBase<int>
    {
        #region Declarations

		private string _categoryName = String.Empty;
		private string _description = null;
		private byte[] _picture = null;
		
		
		private IList<Product> _products = new List<Product>();
		
		#endregion
        
        #region Constructors

        public Category() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_categoryName);
			sb.Append(_description);
			sb.Append(_picture);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string CategoryName
        {
            get { return _categoryName; }
			set
			{
				OnCategoryNameChanging();
				_categoryName = value;
				OnCategoryNameChanged();
			}
        }
		partial void OnCategoryNameChanging();
		partial void OnCategoryNameChanged();
		
		public virtual string Description
        {
            get { return _description; }
			set
			{
				OnDescriptionChanging();
				_description = value;
				OnDescriptionChanged();
			}
        }
		partial void OnDescriptionChanging();
		partial void OnDescriptionChanged();
		
		public virtual byte[] Picture
        {
            get { return _picture; }
			set
			{
				OnPictureChanging();
				_picture = value;
				OnPictureChanged();
			}
        }
		partial void OnPictureChanging();
		partial void OnPictureChanged();
		
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
        
        public static CategoryPropertyName PropertyNames=new CategoryPropertyName();
    }
        #region PropertiesName扩展代码，用于获取属性名称
        
        
        
        public class CategoryPropertyName
    {
        public readonly string Id=@"Id";
         public readonly string CategoryName=@"CategoryName";
         public readonly string Description=@"Description";
         public readonly string Picture=@"Picture";
         public readonly string Products=@"Products";
    }
        #endregion
}
