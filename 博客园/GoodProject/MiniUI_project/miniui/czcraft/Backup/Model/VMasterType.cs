using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/30 17:11:10
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///VMasterType表Model
	 ///</summary>
	public partial class VMasterType
	{
		public System.String TypeName {get;set;}
		public System.Int32? Typeid {get;set;}
		public System.Int32? Belongsid {get;set;}
		public System.Int32? level {get;set;}
		public System.String IsLeaf {get;set;}
		public System.String FId {get;set;}
		public System.Int32? Masterid {get;set;}
		public System.Int32? m_TypeId {get;set;}
	}
}
