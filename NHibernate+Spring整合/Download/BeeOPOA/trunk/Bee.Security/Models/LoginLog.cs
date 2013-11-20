using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bee.Web;

namespace Bee.Models
{
    public class LoginLog
    {
        #region Properties

        public Int32 Id { get; set; }
        [ModelProperty(Description="登入用户", Queryable=true, QueryType=ModelQueryType.Equal)]
        public Int32 UserId { get; set; }
        public String IP { get; set; }
        [ModelProperty(Description = "登入时间", Queryable = true, QueryType = ModelQueryType.Between)]
        public DateTime CreateTime { get; set; }

        #endregion

    }
}
