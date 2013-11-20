using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;
using Bee.Security;
using Bee.Util;

namespace Bee.Web
{
    public class AuthMvcDispatcher : MvcDispatcher
    {
        protected override void ActionExecuting(ActionExecutingArgs actionExcutingArgs)
        {
            string controllerName = actionExcutingArgs.ControllerName.ToLower();
            string actionName = actionExcutingArgs.ActionName.ToLower();

            if (HttpContext.Current.Session[Bee.Security.Constants.SessionUserId] != null)
            {
                bool validFlag = AuthManager.Instance.CheckGrant(actionExcutingArgs.ControllerName
                , actionExcutingArgs.ActionName, actionExcutingArgs.Data);
                if (!validFlag)
                {
                    actionExcutingArgs.CancelFlag = true;
                    actionExcutingArgs.Message = "无权限访问:/{0}/{1}.bee  data:{2}".FormatWith(actionExcutingArgs.ControllerName
                        , actionExcutingArgs.ActionName, actionExcutingArgs.Data);
                }
            }
            else
            {
                if (!(controllerName == "authmain" &&
                    (actionName == "login"
            || actionName == "validimage"
            || actionName == "index"
            || actionName == "siteshortcut")))
                {
                    actionExcutingArgs.CancelFlag = true;
                    actionExcutingArgs.Message = "请登入";
                }
            }
        }
    }
}
