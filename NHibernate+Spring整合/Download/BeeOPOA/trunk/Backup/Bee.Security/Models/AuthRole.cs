using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Web;

namespace Bee.Models
{
    public class AuthRole
    {
        [ModelProperty(ColumnWidth = 30, Description = "Id", OrderableFlag = true
            , Queryable = true, QueryType = ModelQueryType.Between)]
        public int Id { get; set; }
        [ModelProperty(ColumnWidth = 80, Description = "角色名", OrderableFlag = true,
            Queryable = true, QueryType = ModelQueryType.Contains)]
        public string Name { get; set; }
        [ModelProperty(ColumnWidth = 80, Description = "内置账号")]
        public bool InnerFlag { get; set; }
        [ModelProperty(ColumnWidth = 80, Description = "是否删除")]
        public bool DelFlag { get; set; }
        [ModelProperty(ColumnWidth = 100, Description = "创建时间", Align = "center",
            Queryable = true, QueryType = ModelQueryType.Between)]
        public DateTime CreateTime { get; set; }
    }
}
