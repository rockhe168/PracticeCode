using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 外观模式_投资基金_
{
    class Fund
    {
        public Stock1 Stock1 { get; set; }
        public Stock2 Stock2 { get; set; }
        public Stock3 Stock3 { get; set; }
        public NationalDebt1 NationalDebt1 { get; set; }
        public Realty1 Realty1 { get; set; }


        public Fund()
        {
            Stock1=new Stock1("Stock1");
            Stock2=new Stock2("Stock2");
            Stock3=new Stock3("Stock3");
            NationalDebt1=new NationalDebt1("国债");
            Realty1=new Realty1("房地产");
        }

        public void Buy()
        {
            Stock1.Buy();
            Stock2.Buy();
            NationalDebt1.Buy();
            Realty1.Buy();
        }

        public void Sell()
        {
            Stock1.Sell();
            Realty1.Sell();
        }

        public void Buy2()
        {
            Stock3.Buy();
            Realty1.Buy();
        }

        public void Sell2()
        {
            Stock2.Sell();
            NationalDebt1.Sell();
        }
    }
}
