using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton_简单实现_
{

    public sealed class Singleton
    {
        private static Singleton instance=null;

        /// <summary>
        /// 私有的构造函数
        /// </summary>
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();

                return instance;
            }
        }
    }
}
