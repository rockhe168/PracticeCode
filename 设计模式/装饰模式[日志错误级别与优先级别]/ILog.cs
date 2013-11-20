using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 装饰模式_日志错误级别与优先级别_
{
    public abstract class Log
    {
        public abstract void Writer(string log);
    }
}
