using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 简易计算器
{
    /// <summary>
    /// 除法类
    /// </summary>
    class OperationDev : Operation
    {
        public override double GetResult()
        {
            double result=0;
            if(this.NumberB==0)
                throw new Exception("除数不能为零...!");

            result = this.NumberA / this.NumberB;

            return result;
        }
    }
}
