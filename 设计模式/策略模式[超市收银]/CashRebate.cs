using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 策略模式_超市收银_
{
    /// <summary>
    /// 打折收费
    /// </summary>
    public class CashRebate:CashSuper
    {
        /// <summary>
        /// 折扣数
        /// </summary>
        private double MoneyRebate { get; set; }      

        public CashRebate(double moneyRebate)
        {
            this.MoneyRebate = moneyRebate;
        }

        public override double AcceptCash(double money)
        {
            double result = 0d;

            result = MoneyRebate * money;

            return result;
        }
    }
}
