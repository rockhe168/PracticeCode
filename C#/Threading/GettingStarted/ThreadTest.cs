using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GettingStarted
{
    class ThreadTest
    {
        static void Main()
        {
            #region 1, 怎么样建立一个线程
            //Thread t=new Thread(WritY);
            //t.Start();

            ////new Thread(WritY).Start();

            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.Write("x");
            //}
            #endregion

            #region 2, Join and Sleep Method wait for another thread to end

            //Thread t=new Thread(WritY);
            //t.Start();

            ////让主线程等待 t 运行完毕  t.Join()==Thread.Sleep(500);
            ////t.Join();
            //Thread.Sleep(500);

            #endregion

            Console.Write("thread end.........");

            Console.ReadLine();
        }

        private static void WritY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }
        }
    }
}
