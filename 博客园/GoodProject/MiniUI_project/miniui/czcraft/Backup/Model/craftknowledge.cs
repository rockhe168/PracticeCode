using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/13 0:30:07
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///craftknowledge表Model
	 ///</summary>
	public partial class craftknowledge
	{
        public System.Int32? Id { get; set; }
        public System.String Crafttype { get; set; }
        public crafttype type { get; set; }
        //public System.Int32? Typeid {get;set;}
		public System.String Title {get;set;}
		public System.String Content {get;set;}
		public System.DateTime? Time {get;set;}
		public System.String ArticleHtmlUrl {get;set;}
        
    }
    
}
