using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Security;
using Bee.Logging;
using Bee.Web;
using Bee.Util;

namespace Bee.Security
{
    public class BeeAuthModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(Application_AcquireRequestState);
        }

        public void Application_AcquireRequestState(object sender, EventArgs e)
        {
            return;

            /*
            HttpApplication application = sender as HttpApplication;
            HttpContext context = application.Context;
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            string url = request.Url.ToString();
            if (url.IndexOf("/js/", StringComparison.CurrentCultureIgnoreCase) > 0
                || url.EndsWith(".css", StringComparison.CurrentCultureIgnoreCase)
                || url.EndsWith(".js", StringComparison.CurrentCultureIgnoreCase)
                || url.EndsWith(".htm", StringComparison.CurrentCultureIgnoreCase)
                || url.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase)
                || url.IndexOf("/themes/", StringComparison.CurrentCultureIgnoreCase) > 0)
            {
                return;
            }
            try
            {
                int permissionId = AuthManager.Instance.IsPermissionResource(request.Url.ToString());
                if (permissionId != 0)
                {
                    if (AuthManager.Instance.CurrentUser == null)
                    {
                        application.CompleteRequest();
                        BeeMvcResult mvcResult = new BeeMvcResult();
                        mvcResult.message = "当前未登入！请重新登入！";
                        mvcResult.status = false;

                        application.Context.Response.Write(SerializeUtil.ToJson(mvcResult));
                    }
                    else
                    {
                        if (!AuthManager.Instance.CheckGrant(permissionId))
                        {
                            application.CompleteRequest();
                            BeeMvcResult mvcResult = new BeeMvcResult();
                            mvcResult.message = "无访问权限！";
                            mvcResult.status = false;

                            application.Context.Response.Write(SerializeUtil.ToJson(mvcResult));
                        }
                    }
                }
                else  // 若是非访问资源
                {
                    if (AuthManager.Instance.CurrentUser == null
                        && url.IndexOf("/authmain/login.bee", StringComparison.CurrentCultureIgnoreCase) < 0
                        && url.IndexOf("/authmain/logout.bee", StringComparison.CurrentCultureIgnoreCase) < 0 
                        && url.IndexOf("/authmain/index.bee", StringComparison.CurrentCultureIgnoreCase) < 0)
                    {
                        application.CompleteRequest();
                        BeeMvcResult mvcResult = new BeeMvcResult();
                        mvcResult.message = "当前未登入！请重新登入！";
                        mvcResult.status = false;

                        application.Context.Response.Write(SerializeUtil.ToJson(mvcResult));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("BeeAuthModule 验证出错！", ex);

                application.CompleteRequest();
                BeeMvcResult mvcResult = new BeeMvcResult();
                mvcResult.message = ex.ToString();
                mvcResult.status = false;

                application.Context.Response.Write(SerializeUtil.ToJson(mvcResult));
            }
             * 
             * */
        }

    }
}
