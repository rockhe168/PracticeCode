using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 适配器模式_篮球翻译_
{
    class Program
    {
        static void Main(string[] args)
        {
            Player forwards=new Forwards("巴蒂尔");
            forwards.Attack();

            Player guards=new Guards("煤矿各里的");
            guards.Defense();

            //Player center=new Center("姚明");
            //center.Attack();
            //center.Defense();

            Player center = new Translator("姚明");
            center.Attack();
            center.Defense();

            Console.ReadKey();

        }
    }
}
