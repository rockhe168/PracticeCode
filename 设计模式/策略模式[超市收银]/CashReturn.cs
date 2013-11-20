using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 策略模式_超市收银_
{
    /// <summary>
    /// 反利收费
    /// </summary>
    public class CashReturn:CashSuper
    {

        /// <summary>
        /// 活动促销价格
        /// </summary>
        private double MoneyCondition { get; set; }

        /// <summary>
        /// 送的money数
        /// </summary>
        private double MoneyReturn { get; set; }

        public CashReturn(double moneyCondition,double moneyReturn)
        {
            this.MoneyCondition = moneyCondition;
            this.MoneyReturn = moneyReturn;
        }

        public override double AcceptCash(double money)
        {
            double result = 0;

            if (money >= MoneyCondition)
                result = money - MoneyReturn;
            else
                result = money;

           return result;
        }
    }
}
