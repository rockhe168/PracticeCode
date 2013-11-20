using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace czcraft.Model
{
   public partial class Collection
    {

            public System.Int64? ProductId { get; set; }
            public System.Int32? MemberId { get; set; }
            public System.DateTime? AddTime { get; set; }
            public System.String BelongType { get; set; }
            public System.String BelongSell { get; set; }
            public System.String BelongId { get; set; }
            public System.String Name { get; set; }
            public System.String Material { get; set; }
            public System.Double? LsPrice { get; set; }
            public System.String PicturePath { get; set; }
            public System.String IsBusy { get; set; }
        
    }
}
