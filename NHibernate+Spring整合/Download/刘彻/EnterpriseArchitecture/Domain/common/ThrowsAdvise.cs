using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Spring.Aop;

namespace Domain.common
{
    /// <summary>
    /// 异常通知。记录异常日志  刘彻 2012-12-15
    /// </summary>
    public class ThrowsAdvise : IThrowsAdvice
    {
        private ILogHelper LogHelper { get; set; }
        public void AfterThrowing(MethodInfo method, object[] args, object target,Exception ex)
        {
            string arg = "";
            if (args != null)
            {
                foreach (object a in args)
                {
                    arg += "," + a;
                }
            } 

            string errorMsg = string.Format("异常通知：{0}方法异常；参数:{1}", target+"."+ method.Name,arg);
            LogHelper.WriteLog(errorMsg,ex);
        } 
    }
}
