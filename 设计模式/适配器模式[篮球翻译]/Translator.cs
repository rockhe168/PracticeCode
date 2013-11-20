using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 适配器模式_篮球翻译_
{
    public class Translator:Player
    {
        private ForeignCenter _wjzf = null;

        public Translator(string name)
        {
            this.Name = name;
            _wjzf= new ForeignCenter(this.Name);
        }

        public override void Attack()
        {
            _wjzf.进攻();
        }

        public override void Defense()
        {
            _wjzf.防守();
        }
    }
}
