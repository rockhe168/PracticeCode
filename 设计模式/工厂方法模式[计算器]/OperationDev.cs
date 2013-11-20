using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 工厂方法模式_计算器_
{
    class OperationDev:Operation
    {
        public override double GetResult()
        {
            if (this.NumberB == 0)
                throw new Exception("除数不能为零...!");
            return this.NumberA / this.NumberB;
        }
    }
}
