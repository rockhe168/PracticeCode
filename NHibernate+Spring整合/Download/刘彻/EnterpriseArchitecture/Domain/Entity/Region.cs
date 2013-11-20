using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class Region : BusinessBase<int>
    {
        #region Declarations

		private string _regionDescription = String.Empty;
		
		
		private IList<Territory> _territories = new List<Territory>();
		
		#endregion
        
        #region Constructors

        public Region() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_regionDescription);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string RegionDescription
        {
            get { return _regionDescription; }
			set
			{
				OnRegionDescriptionChanging();
				_regionDescription = value;
				OnRegionDescriptionChanged();
			}
        }
		partial void OnRegionDescriptionChanging();
		partial void OnRegionDescriptionChanged();
		
		public virtual IList<Territory> Territories
        {
            get { return _territories; }
            set
			{
				OnTerritoriesChanging();
				_territories = value;
				OnTerritoriesChanged();
			}
        }
		partial void OnTerritoriesChanging();
		partial void OnTerritoriesChanged();
		
        #endregion
        
        public static RegionPropertyName PropertyNames=new RegionPropertyName();
    }
        #region PropertiesName扩展代码，用于获取属性名称
        
        
        
        public class RegionPropertyName
    {
        public readonly string Id=@"Id";
         public readonly string RegionDescription=@"RegionDescription";
         public readonly string Territories=@"Territories";
    }
        #endregion
}
