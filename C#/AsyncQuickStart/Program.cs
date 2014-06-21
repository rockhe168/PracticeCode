using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncQuickStart
{
    class Program
    {
        delegate long Mydel(int first, int second);
        static void Main(string[] args)
        {
            Mydel del = new Mydel(Sum);

            Console.WriteLine("Before BeginInvoke...");

            IAsyncResult iar = del.BeginInvoke(3, 5, new AsyncCallback(CallWhereDone), null);


            Console.WriteLine("Doning more work in Main");

            Thread.Sleep(500);

            Console.WriteLine("Don with Main.Exiting");

            Console.ReadKey();
        }

        static long Sum(int x,int y)
        {
            Console.WriteLine("                      Insid Sum");

            Thread.Sleep(100);

            return x + y;
            
        }

        static void CallWhereDone(IAsyncResult iar)
        {
            Console.WriteLine("                 Insid CallWhereDone");
            AsyncResult ar = (AsyncResult)iar;

            Mydel del = (Mydel)ar.AsyncDelegate;

            long result = del.EndInvoke(iar);

            Console.WriteLine("                The result is:{0}",result);
        }
    }
}
