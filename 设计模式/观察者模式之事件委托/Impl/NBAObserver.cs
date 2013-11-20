using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 观察者模式之事件委托.Impl
{
    public class NBAObserver
    {
         /// <summary>
        /// 观察者的名称【需要提醒人的名字】
        /// </summary>
        protected string name;

        /// <summary>
        /// 主题的抽象【通知人的抽象】
        /// </summary>
        protected ISubject subject;

        public NBAObserver(string name, ISubject subject)
        {
            this.name = name;
            this.subject = subject;
        }

        /// <summary>
        /// 更改自己的状态【根据主题的状态进行自己状态的更改】
        /// </summary>
        public void CloseNBA直播()
        {
            Console.WriteLine("{0}--->{1} 关闭NBA直播,继续工作。", this.name, this.subject.Message);
        }
    }
}
