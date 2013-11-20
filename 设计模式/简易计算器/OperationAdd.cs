using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 简易计算器
{
    /// <summary>
    /// 加法类
    /// </summary>
    class OperationAdd:Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA + NumberB;

            return result;
        }
    }
}
