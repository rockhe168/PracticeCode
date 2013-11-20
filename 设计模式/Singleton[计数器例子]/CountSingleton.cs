using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Singleton_计数器例子_
{
    /// <summary>
    /// 简单的计数器
    /// </summary>
    public class CountSingleton
    {

        //唯一instance
        private static CountSingleton instance = new CountSingleton();

        //私有构造函数【防止其他地方new本类的实例】
        private CountSingleton() 
        {
            System.Diagnostics.Debug.WriteLine("构造函数执行开始...");
            //线程延迟2000
            //Thread.Sleep(2000);
            System.Diagnostics.Debug.WriteLine("构造函数执行结束...");
        }

        //公开本身实例
        public static CountSingleton Instance
        { 
           get
            {
                return instance;
            }
        }


        #region 计数部分
        private int totNum = 0;

        public void Add()
        {
            totNum++;
        }

        public int GetTotNumer()
        {
            return totNum;
        }
        #endregion
    }
}
