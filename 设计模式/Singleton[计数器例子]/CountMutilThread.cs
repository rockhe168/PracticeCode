using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Singleton_计数器例子_
{
    /// <summary>
    /// 一个多线程的计数器类
    /// </summary>
    public class CountMutilThread
    {

        public CountMutilThread() { }

        public static void DoSomeWorking()
        { 
            //创建一个Singleton实例
            var counterInstance = CountSingleton.Instance;

            //循环调用四次
            for (int i = 1; i < 5; i++)
            {
                
                //开始计数
                counterInstance.Add();

                //组建输出字符串
                var result = "线程";
                result += Thread.CurrentThread.Name+"-->";
                result += "当前的计数：";
                result += counterInstance.GetTotNumer().ToString()+"-->";
                result += "当前单列对象的标识为"+counterInstance.GetHashCode();
                result += "\n";

                Console.WriteLine(result);

            }
        }

        public void StartMain()
        {
            Thread threadMain = Thread.CurrentThread;
            threadMain.Name = "threadMain";

            Thread thread01 = new Thread(new ThreadStart(DoSomeWorking));
            thread01.Name = "thread01";

            Thread thread02 = new Thread(new ThreadStart(DoSomeWorking));
            thread02.Name = "thread02";

            Thread thread03 = new Thread(new ThreadStart(DoSomeWorking));
            thread03.Name = "thread03";

            thread01.Start();

            thread02.Start();

            thread03.Start();

            ///主线程也只执行和其他线程相同的工作
            DoSomeWorking();
        }

    }
}
