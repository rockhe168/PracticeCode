﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 适配器模式_篮球翻译_
{
    /// <summary>
    /// 中锋
    /// </summary>
    public class Center:Player
    {
        public Center(string name)
        {
            Name = name;
        }

        public override void Attack()
        {
            Console.WriteLine("中锋 {0} 进攻", Name);
        }

        public override void Defense()
        {
            Console.WriteLine("中锋 {0} 防守", Name);
        }
    }
}
