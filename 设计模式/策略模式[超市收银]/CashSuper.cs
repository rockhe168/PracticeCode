using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 策略模式_超市收银_
{
    /// <summary>
    /// 收银
    /// </summary>
    public abstract class CashSuper
    {
        /// <summary>
        /// 获取活动后的价格
        /// </summary>
        /// <param name="money">原始价格</param>
        /// <returns>实际活动后的价格</returns>
        public abstract double AcceptCash(double money);
    }
}
