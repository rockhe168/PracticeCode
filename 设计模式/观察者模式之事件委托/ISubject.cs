using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 观察者模式之事件委托
{
    /// <summary>
    /// 抽象的发布者
    /// </summary>
    public abstract class ISubject
    {
        /// <summary>
        ///  消息
        ///  </summary>
        public string Message { get; set; }

        /// <summary>
        /// 消息发布
        /// </summary>
        public PublicMessageHandler Public;
    }


    /// <summary>
    /// 消息发布者事件委托
    /// </summary>
    public delegate void PublicMessageHandler();
}
