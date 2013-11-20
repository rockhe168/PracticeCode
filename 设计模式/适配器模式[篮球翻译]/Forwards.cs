using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 适配器模式_篮球翻译_
{
    /// <summary>
    /// 前锋
    /// </summary>
    public class Forwards:Player
    {
        public Forwards(string name)
        {
            Name = name;
        }

        public override void Attack()
        {
            Console.WriteLine("前锋 {0} 进攻",Name);
        }

        public override void Defense()
        {
            Console.WriteLine("前锋 {0} 防守", Name);
        }
    }
}
