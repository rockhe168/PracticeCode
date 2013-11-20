using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 适配器模式_篮球翻译_
{
    /// <summary>
    /// 外籍中锋
    /// </summary>
    public class ForeignCenter
    {
        public string Name { get; set; }

        public ForeignCenter(string name)
        {
            this.Name = name;
        }

        public void 进攻()
        {
            Console.WriteLine("外籍中锋 {0} 进攻", Name);
        }

        public void 防守()
        {
            Console.WriteLine("外籍后卫 {0} 防守", Name);
        }
    }
}
