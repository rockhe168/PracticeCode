using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 简易计算器
{
    /// <summary>
    /// 运算的抽象类【运算类】
    /// </summary>
    public abstract class Operation
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }

        public abstract double GetResult();
    }

    
}