using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton_延迟初始化_
{
    class Singleton
    {
        private Singleton() { }

        public static Singleton Instance
        {
            get 
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            static Nested() { }

            internal static readonly Singleton instance = new Singleton();
        }
    }
}
