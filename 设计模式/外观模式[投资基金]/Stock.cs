using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 外观模式_投资基金_
{
    abstract class Stock
    {
        public string Name { get; set; }

        public virtual void Buy()
        {
            Console.WriteLine("Buy --->" + this.Name);
        }

        public virtual void Sell()
        {
            Console.WriteLine("Sell--->" + this.Name);
        }
    }
}
