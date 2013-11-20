using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 装饰模式_日志错误级别与优先级别_
{
    class Program
    {
        static void Main(string[] args)
        {
            Log log=new DataBaseLog();

            LogWarpper logWarpper=new LogErrorWarpper(log);

            var logPriorityWarpper = new LogPriorityWarpper(logWarpper);

            logPriorityWarpper.Writer("Log Information");

            Console.ReadKey();
        }
    }
}
