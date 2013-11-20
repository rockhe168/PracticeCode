using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 工厂方法模式_计算器_
{
    /// <summary>
    /// 运算类
    /// </summary>
    public abstract class Operation
    {
        public double NumberA { get; set; }

        public double NumberB { get; set; }

        public abstract double GetResult();
    }
}
