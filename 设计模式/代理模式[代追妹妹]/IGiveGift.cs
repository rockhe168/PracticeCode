using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 代理模式_代追妹妹_
{
    /// <summary>
    /// 送礼物
    /// </summary>
    public interface IGiveGift
    {
        /// <summary>
        /// 送洋娃娃
        /// </summary>
        void GiveDolls();

        /// <summary>
        /// 送鲜花
        /// </summary>
        void GiveFlowers();

        /// <summary>
        /// 送巧克力
        /// </summary>
        void GiveChocolate();
    }
}
