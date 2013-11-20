using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace czcraft.Model
{
    public partial class SearchSum
    {
        public string KeyWord { get; set; }
        public int Count { get; set; }
       public enum searchType
        {
            News=0, Product=1, Knowledge=2
        }
        public searchType SearchType { get; set; }
        
    }
}