using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 代理模式_代追妹妹_
{
    class Program
    {
        static void Main(string[] args)
        {
            var mm = new SchoolGirl {Name = "美女妹妹"};

            var proxy = new Proxy(mm);
            proxy.GiveDolls();
            proxy.GiveFlowers();
            proxy.GiveChocolate();


            Console.ReadKey();

        }
    }
}
