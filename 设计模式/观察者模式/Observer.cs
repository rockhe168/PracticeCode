using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 观察者模式
{

    /// <summary>
    /// 抽象观察者
    /// </summary>
    public abstract class Observer
    {

        /// <summary>
        /// 观察者的名称【需要提醒人的名字】
        /// </summary>
        protected string name;

        /// <summary>
        /// 主题的抽象【通知人的抽象】
        /// </summary>
        protected ISubject subject;

        protected Observer(string name,ISubject subject)
        {
            this.name = name;
            this.subject = subject;
        }

        /// <summary>
        /// 更改自己的状态【根据主题的状态进行自己状态的更改】
        /// </summary>
        public abstract void Update();
    }
}
