using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 装饰模式_日志错误级别与优先级别_
{
    public abstract class LogWarpper:Log
    {
        private Log _log;

        public LogWarpper(Log log)
        {
            this._log = log;
        }

        public override void Writer(string log)
        {
            _log.Writer(log);
        }
    }
}
