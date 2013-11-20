using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton_静态初始化_
{
    public sealed class Singleton
    {
        /// <summary>
        /// 在运行期间就初始化【那么在空闲的时候会不会导致垃圾回收器给回收掉呢？？？】
        /// </summary>
        static readonly Singleton instance = new Singleton();

        /// <summary>
        /// 私有的构造函数
        /// </summary>
        private Singleton() { }

        public static Singleton Instance
        {
            get 
            {
                return instance;
            }
        }
    }
}
