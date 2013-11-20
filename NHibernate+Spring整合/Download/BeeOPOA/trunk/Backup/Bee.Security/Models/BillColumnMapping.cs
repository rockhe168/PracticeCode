using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bee.Web;

namespace Bee.Models
{
    public class BillColumnMapping
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public string Mapping { get; set; }
        public DateTime ModifyTime { get; set; }

        public List<BillColumnField> ColumnMapping
        {
            get;
            set;
        }
    }

    public class BillColumnField
    {
        public string Name { get; set; }
        public string Title { get; set; }
        
        public string itemtype { get; set; }
        public string itemname { get; set; }
        public string itemlookupurl { get; set; }
        public string itemlookupgroup { get; set; }
    }
}
