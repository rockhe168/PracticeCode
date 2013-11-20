using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 简易计算器
{
    /// <summary>
    /// 减法类
    /// </summary>
    class OperationSub:Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = this.NumberA - this.NumberB;

            return result;
        }
    }
}
