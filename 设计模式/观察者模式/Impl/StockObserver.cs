using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 观察者模式.Impl
{
    public class StockObserver:Observer
    {
        public StockObserver(string name, ISubject subject) : base(name, subject)
        {
        }

        public override void Update()
        {
            Console.WriteLine("{0}--->{1} 关闭股票行情,继续工作。", this.name, this.subject.SubjectMessage);
        }
    }
}
