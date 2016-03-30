using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Web.Ajax
{
    /// <summary>
    /// BaseHandler 的摘要说明
    /// </summary>
    public class BaseHandler : IHttpHandler
    {

        protected string ContentType = "text/plain";
        protected string ActionName = "action";


        //获取当前的http context        
        protected HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = this.ContentType;
            try
            {
                //1、检查权限，是否登录用户
                //...

                //2、动态调用方法 当然  你还可以在这里加上是否为同域名请求的判断
                this.DynamicMethod();
            }
            catch (AmbiguousMatchException amEx)
            {
                this.PrintErrorJson(string.Format("根据该参数{0}找到了多个方法", amEx.Message));
            }
            catch (ArgumentException argEx)
            {
                this.PrintErrorJson("参数异常" + argEx.Message);
            }
            catch (ApplicationException apEx)
            {
                this.PrintErrorJson("程序异常" + apEx.Message+apEx.InnerException);
            }

        }

        private void DynamicMethod()
        {
            //根据指定的请求类型获取方法名            
            string action = this.Context.Request[ActionName];

            if (!string.IsNullOrEmpty(action))
            {
                //获取方法的实例  非静态 需要Public访问权限 忽略大小写
                MethodInfo methodInfo = this.GetType().GetMethod(action, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (methodInfo != null)
                {
                    //调用方法
                    methodInfo.Invoke(this, null);
                }
                else
                {
                    throw new ApplicationException(string.Format("没有找到方法{0}", action));
                }
            }
            else
            {
                throw new ArgumentNullException("没有找到调用方法参数或者方法名为空");
            }

        }

        #region 打印Json的相关处理
        /// <summary>
        /// 打印遇到异常的json
        /// </summary>
        /// <param name="msg"></param>
        protected void PrintErrorJson(string msg)
        {
            this.PrintJson("error", msg);
        }

        /// <summary>
        /// 打印成功处理的json
        /// </summary>
        /// <param name="msg"></param>
        protected void PrintSuccessJson(string msg)
        {
            this.PrintJson("success", msg);
        }

        /// <summary>
        /// 打印json
        /// </summary>
        /// <param name="state"></param>
        /// <param name="msg"></param>
        protected void PrintJson(string state, string msg)
        {
            this.Context.Response.Write("{\"state\":\"" + state + "\",\"data\":\"" + msg + "\"}");
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}