using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 工厂方法模式_计算器_
{
    class AddFactory:IFactory
    {
        public override Operation CreateOperation()
        {
            return new OperationAdd();
        }
    }
}
