using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 简易计算器
{
    /// <summary>
    /// 简单工厂类
    /// </summary>
    public class OperationFactory
    {
        public static Operation createOperation(string operate)
        {
            Operation oper = null;

            switch (operate)
            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                case "*":
                    oper = new OperationMul();
                    break;
                case "/":
                    oper = new OperationDev();
                    break;
                default:
                    break;
            }

            return oper;
        }
    }
}
