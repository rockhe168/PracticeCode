using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bee.Models
{
    public class AuthGroup
    {
        public AuthGroup()
        {
            GroupType = 1;
        }
        public int Id { get; set; }
        public int ParentId { get; set; }
        /// <summary>
        /// 1:普通 用户组 2：组织 用户组
        /// </summary>
        public int GroupType { get; set; }
        public string Name { get; set; }
        public bool DelFlag { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
