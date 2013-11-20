using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 观察者模式.Impl;

namespace 观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //前台 通知
            ISubject mm=new MMSubject();
            mm.SubjectMessage = "老板回来了，赶快关闭NBA、股票行情啊...";
            mm.Add(new NBAObserver("Andy", mm));
            mm.Add(new StockObserver("Alice", mm));

            //发布消息
            mm.Notify();


            //boss 通知
            ISubject boss = new BossSubject();

            boss.Add(new NBAObserver("Rock", boss));

            boss.SubjectMessage = "看看你们，还在看NBA直播~~";

            //发布消息
            boss.Notify();



            Console.ReadKey();

        }
    }
}
