using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 外观模式_投资基金_
{
    /// <summary>
    /// 房地产
    /// </summary>
    class Realty1 : Stock
    {
        public Realty1(string name)
        {
            this.Name = name;
        }
    }
}
