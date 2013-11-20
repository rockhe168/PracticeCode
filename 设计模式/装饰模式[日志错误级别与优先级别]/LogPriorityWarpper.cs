using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 装饰模式_日志错误级别与优先级别_
{
    public class LogPriorityWarpper:LogWarpper
    {
        public LogPriorityWarpper(Log log) : base(log)
        {
        }

        public void SetPriorityWarpper()
        {
            //具体的日志优先级别设置
            Console.WriteLine("设置具体的优先级别...");
        }

        public override void Writer(string log)
        {
            //设置写入的优先级别
            SetPriorityWarpper();

            base.Writer(log);
        }
    }
}
