using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 适配器模式_篮球翻译_
{
    public class Guards:Player
    {

        public Guards(string name)
        {
            Name = name;
        }

        public override void Attack()
        {
            Console.WriteLine("后卫 {0} 进攻", Name);
        }

        public override void Defense()
        {
            Console.WriteLine("后卫 {0} 防守", Name);
        }
    }
}
