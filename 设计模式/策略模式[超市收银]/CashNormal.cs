using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 策略模式_超市收银_
{
    /// <summary>
    /// 正常收费
    /// </summary>
    public class CashNormal:CashSuper
    {
        public override double AcceptCash(double money)
        {
            return money;
        }
    }
}
