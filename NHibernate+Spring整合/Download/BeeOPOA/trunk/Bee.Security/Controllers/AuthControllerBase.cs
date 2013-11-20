using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Web;
using Bee.Util;
using Bee.Data;

namespace Bee.Security.Controllers
{
    public class AuthControllerBase<T> : ControllerBase<T>
        where T : class
    {
        protected override DbSession GetDbSession(bool useTransaction)
        {
            string AuthConnString = ConfigUtil.GetAppSettingValue<string>("Bee.Auth.DataSource");
            DbSession dbSession = null;
            if (string.IsNullOrEmpty(AuthConnString))
            {
                dbSession = DbSession.Current;
            }
            else
            {
                dbSession = new DbSession(AuthConnString, useTransaction);
            }

            return dbSession;
        }
    }

    public class AuthControllerBase : ControllerBase
    {
        protected override DbSession GetDbSession(bool useTransaction)
        {
            string AuthConnString = ConfigUtil.GetAppSettingValue<string>("Bee.Auth.DataSource");
            DbSession dbSession = null;
            if (string.IsNullOrEmpty(AuthConnString))
            {
                dbSession = DbSession.Current;
            }
            else
            {
                dbSession = new DbSession(AuthConnString, useTransaction);
            }

            return dbSession;
        }
    }
}
