using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Data;

namespace Bee.Models
{
    public class AuthPermission
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Res { get; set; }
        public string ExRes { get; set; }
        public int DispIndex { get; set; }
        public bool ShowFlag { get; set; }
        public bool DelFlag { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
