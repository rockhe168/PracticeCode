using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 观察者模式
{
    /// <summary>
    /// 主题【抽象的通知者】
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// 添加需要通知的对象【观察者--订阅者】
        /// </summary>
        /// <param name="observer">观察者</param>
        void Add(Observer observer);

        /// <summary>
        /// 移除需要通知的对象【观察者--订阅者】
        /// </summary>
        /// <param name="observer">订阅者</param>
        void Delete(Observer observer);


        /// <summary>
        /// 主题状态【发布的消息】
        /// </summary>
        string SubjectMessage { set; get; }

        /// <summary>
        /// 发布通知【发布通知所有订阅的订阅者】
        /// </summary>
        void Notify();

    }
}
