using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 装饰模式_日志错误级别与优先级别_
{
    public class LogErrorWarpper:LogWarpper
    {
        public LogErrorWarpper(Log log) : base(log)
        {
        }

        private void SetError()
        {
            Console.WriteLine("设置具体的错误级别...");
        }

        public override void Writer(string log)
        {
            //设置错误级别
            SetError();

            base.Writer(log);
        }
    }
}
