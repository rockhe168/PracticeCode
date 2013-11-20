using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 观察者模式.Impl
{
    /// <summary>
    /// 具体的发布者【具体的通知人Boss】
    /// </summary>
    public class BossSubject:ISubject
    {
        /// <summary>
        /// 主题需要通知的订阅者
        /// </summary>
        public IList<Observer> ObserverList=new List<Observer>(); 

        public void Add(Observer observer)
        {
            ObserverList.Add(observer);
        }

        public void Delete(Observer observer)
        {
            ObserverList.Add(observer);
        }

        public string sujectMessage;
        public string SubjectMessage
        {
            get { return sujectMessage; }
            set { sujectMessage = value; }
        }


        public void Notify()
        {
            foreach (var observer in ObserverList)
            {
                observer.Update();
            }
        }
    }
}
