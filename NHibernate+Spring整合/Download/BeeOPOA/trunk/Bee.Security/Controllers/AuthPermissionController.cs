using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Web;
using Bee.Models;
using Bee.Data;
using System.Data;
using Bee.Caching;

namespace Bee.Security.Controllers
{
    public class AuthPermissionController : AuthControllerBase<AuthPermission>
    {
        public override PageResult Index(BeeDataAdapter dataAdapter)
        {
            DataTable result;
            using (DbSession dbSession = GetDbSession())
            {
                result = dbSession.Query(TableName, null);
            }

            return View(ControllerName, "Index", result);
        }

        public override void Save(AuthPermission obj)
        {
            base.Save(obj);

            CacheManager.Instance.RemoveCategoryCache(Constants.AllShownPermission);

            CacheManager.Instance.RemoveCategoryCache(Constants.UserAllPermission);
        }


        public AuthPermission Detail(int id)
        {
            AuthPermission result = null;

            using (DbSession dbSession = GetDbSession())
            {
                result = dbSession.Query<AuthPermission>(SqlCriteria.New.Equal("id", id)).FirstOrDefault();
            }

            return result;
        }
    }
}
