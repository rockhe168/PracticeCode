using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 观察者模式.Impl
{
    /// <summary>
    /// 看NBA的订阅者
    /// </summary>
    public class NBAObserver:Observer
    {
        public NBAObserver(string name, ISubject subject) : base(name, subject)
        {
        }

        public override void Update()
        {
            Console.WriteLine("{0}--->{1} 关闭NBA直播,继续工作。",this.name,this.subject.SubjectMessage);
        }
    }
}
