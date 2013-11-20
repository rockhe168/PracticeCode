using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bee.Models
{
    public class SystemConfig
    {
        #region Properties

        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Value { get; set; }
        public DateTime ModifyTime { get; set; }

        #endregion

    }
}
