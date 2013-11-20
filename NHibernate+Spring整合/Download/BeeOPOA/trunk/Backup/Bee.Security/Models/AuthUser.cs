using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Data;
using Bee.Web;

namespace Bee.Models
{
    [Model(DefaultOrderField = "Id", PageSize=20, DefaultOrderAscFlag=false)]
    public class AuthUser
    {
        [ModelProperty(ColumnWidth = 30, Description = "Id", OrderableFlag = true)]
        public int Id { get; set; }
        [ModelProperty(ColumnWidth = 80, Description = "用户名", OrderableFlag = true,
            Queryable = true, QueryType = ModelQueryType.Contains)]
        public string UserName { get; set; }

        [ModelProperty(ColumnWidth = 80, Description = "昵称", OrderableFlag = true,
            Queryable = true, QueryType = ModelQueryType.Contains)]
        public string NickName { get; set; }

        [ModelProperty(ColumnWidth = 80, Description = "密码", Visible=false)]
        public string Password { get; set; }
        [ModelProperty(ColumnWidth = 80, Description = "Email",
            Queryable = true, QueryType = ModelQueryType.Contains)]
        public string Email { get; set; }
        [ModelProperty(ColumnWidth = 80, Description = "内置账号",
            Queryable = true, QueryType = ModelQueryType.Equal)]
        public bool InnerFlag { get; set; }
        [ModelProperty(ColumnWidth = 80, Description = "是否删除", 
            Queryable = true, QueryType = ModelQueryType.Equal)]
        public bool DelFlag { get; set; }
        [ModelProperty(ColumnWidth = 100, Description = "创建时间", Align="center",
             Queryable = true, QueryType = ModelQueryType.Between)]
        public DateTime CreateTime { get; set; }
    }

    [OrmTable(TableName="VAuthUserEx")]
    public class AuthUserEx : AuthUser
    {
        public string WorkCode { get; set; }
        public string CardId { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
    }

}
