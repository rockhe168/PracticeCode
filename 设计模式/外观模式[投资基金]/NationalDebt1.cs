using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 外观模式_投资基金_
{
    /// <summary>
    /// 国债
    /// </summary>
    class NationalDebt1 : Stock
    {
        public NationalDebt1(string name)
        {
            this.Name = name;
        }
    }
}
