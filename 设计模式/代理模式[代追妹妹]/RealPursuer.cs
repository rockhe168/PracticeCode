using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 代理模式_代追妹妹_
{
    /// <summary>
    /// 真实的追求者
    /// </summary>
    class RealPursuer:IGiveGift
    {

        SchoolGirl mm;

        public RealPursuer(SchoolGirl mm)
        {
            this.mm = mm;
        }

        public void GiveDolls()
        {
            Console.WriteLine(mm.Name+",送你洋娃娃...");
        }

        public void GiveFlowers()
        {
            Console.WriteLine(mm.Name + ",送你鲜花...");
        }

        public void GiveChocolate()
        {
            Console.WriteLine(mm.Name + ",送你巧克力...");
        }
    }
}
