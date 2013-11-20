using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton_安全的线程_
{
   public sealed  class Singleton
    {
       private static Singleton instance = null;
       static readonly object padlock=new object();

       /// <summary>
       /// 私有的构造函数
       /// </summary>
       private Singleton() { }

       public static Singleton Instance
       {
           get
           {
               lock (padlock)
               {
                   if (instance == null)
                       instance = new Singleton();
               }

               return instance;
           }
          
       }
    }
}
