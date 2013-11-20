using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace czcraft.Model
{
    /// <summary>
    /// 解析json的实体对象
    /// </summary>
   public class AddUserInfoTempModel
    {
        public System.String LOGNAME { get; set; }
        public System.String PASSWORD { get; set; }
        public System.String REALNAME { get; set; }
        public System.Int32? USERGROUPID { get; set; }
        //public WEB_USERGROUP GROUP { get; set; }
        public System.String STATE { get; set; }
       // public System.DateTime? REG_DATE { get; set; }
       // public System.DateTime? LAST_LOG_DATE { get; set; }
        public System.Int32? LOG_TIMES { get; set; }
        public System.String MEMO { get; set; }
        //public System.Int32? ID { get; set; }
    }
}
