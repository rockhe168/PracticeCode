using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 观察者模式之事件委托.Impl;

namespace 观察者模式之事件委托
{
    class Program
    {
        static void Main(string[] args)
        {
            //mm通知
            ISubject mm=new MMSubject();
            mm.Message = "老板回来了~~";
            mm.Public+=new PublicMessageHandler(new NBAObserver("Andy",mm).CloseNBA直播);
            mm.Public+=new PublicMessageHandler(new StockObserver("Alic",mm).Close彩票行情);

            mm.Public();

            //老板通知
            ISubject boss=new BossSubject();
            boss.Message = "看看你，还在看NBA直播~~";
            boss.Public+=new PublicMessageHandler(new NBAObserver("Rock",boss).CloseNBA直播);
            boss.Public();

            Console.ReadKey();


        }
    }
}
