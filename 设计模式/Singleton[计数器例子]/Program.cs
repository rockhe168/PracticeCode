using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton_计数器例子_
{
    class Program
    {
        static void Main(string[] args)
        {
            var countMutilThread = new CountMutilThread();

            countMutilThread.StartMain();


            Console.ReadLine();
        }
    }
}
