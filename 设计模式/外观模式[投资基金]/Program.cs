using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 外观模式_投资基金_
{
    class Program
    {
        static void Main(string[] args)
        {
            var jijin=new Fund();

            jijin.Buy();

            jijin.Sell2();

            Console.ReadKey();
        }
    }
}
