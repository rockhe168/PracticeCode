using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 策略模式_超市收银_
{
    public class CashContext
    {
        private CashSuper cashSuper = null;

        public CashContext(string type)
        {
            switch (type)
            {
                case "正常收费":
                    cashSuper=new CashNormal();
                    break;
                case "打8折":
                    cashSuper = new CashRebate(0.8);
                    break;
                case "满300送100":
                    cashSuper=new CashReturn(300,100);
                    break;
                default:
                    break;
            }
        }

        public double GetResult(double money)
        {
            return cashSuper.AcceptCash(money);
        }
    }
}
