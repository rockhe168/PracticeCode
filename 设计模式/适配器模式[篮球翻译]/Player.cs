using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 适配器模式_篮球翻译_
{
    public abstract class Player
    {
        /// <summary>
        /// 球员的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 进攻
        /// </summary>
        public abstract void Attack();

        /// <summary>
        /// 防守
        /// </summary>
        public abstract void Defense();
    }
}
