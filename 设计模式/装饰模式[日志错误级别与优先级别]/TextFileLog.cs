using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 装饰模式_日志错误级别与优先级别_
{
    public class TextFileLog:Log
    {
        public override void Writer(string log)
        {
            Console.WriteLine("日志内容 "+log+" 被写入文件...");
        }
    }
}
