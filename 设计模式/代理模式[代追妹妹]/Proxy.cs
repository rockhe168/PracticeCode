using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 代理模式_代追妹妹_
{
    public class Proxy:IGiveGift
    {
        SchoolGirl mm;

        //真实的引用【真实的引用者】
        RealPursuer realPursuer;

        public Proxy(SchoolGirl mm)
        {
            this.mm = mm;
            this.realPursuer = new RealPursuer(mm);
        }

        public void GiveDolls()
        {
            realPursuer.GiveDolls();
        }

        public void GiveFlowers()
        {
            realPursuer.GiveFlowers();
        }

        public void GiveChocolate()
        {
            realPursuer.GiveChocolate();
        }
    }
}
