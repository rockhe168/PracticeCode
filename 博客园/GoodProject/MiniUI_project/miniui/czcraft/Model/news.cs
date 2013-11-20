using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
/*
 *   作者: Sweet
 *  创建时间: 2012/4/10 18:04:17
 *  类说明: czcraft.Model
 */ 
{
	 ///<summary>
	 ///news表Model
	 ///</summary>
	public partial class news
	{
		public System.Int32? Id {get;set;}
		public System.String Title {get;set;}
		public System.String Content {get;set;}
        //public System.Int32? Typeid {get;set;}
        public newstype Type { get; set; }
		public System.DateTime? Time {get;set;}
		public System.String ArticleHtmlUrl {get;set;}
	}
}
