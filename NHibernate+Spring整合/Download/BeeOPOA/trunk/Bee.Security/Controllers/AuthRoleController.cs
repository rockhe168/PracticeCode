using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Web;
using Bee.Models;
using System.Data;
using Bee.Data;
using Bee.Caching;

namespace Bee.Security.Controllers
{

    public class AuthRoleController : AuthControllerBase<AuthRole>
    {
        public override PageResult Index(BeeDataAdapter dataAdapter)
        {
            return List(dataAdapter);
        }

        public override PageResult List(BeeDataAdapter dataAdapter)
        {
            PageResult baseResult = base.List(dataAdapter);

            return new PageResult(ControllerName, "RoleList", baseResult.Model);
        }

        public PageResult ShowPermission(int id)
        {
            DataTable result;
            AuthRole role = null;
            List<AuthAccess> authAccessList = null;
            using (DbSession dbSession = GetDbSession())
            {
                result = dbSession.Query("AuthPermission", null);

                role = dbSession.Query<AuthRole>(SqlCriteria.New.Equal("id", id)).FirstOrDefault();

                authAccessList = dbSession.Query<AuthAccess>(SqlCriteria.New.Equal("roleid", id));
            }

            string permission = string.Join(",", (from item in authAccessList
                         select item.PermissionId.ToString()).ToArray());

            ViewData.Add("roleinfo", role);
            ViewData.Add("permission", permission);

            return View(ControllerName, "RolePermission", result);
        }

        public string SavePermission(int id, string permission)
        {
            List<int> permissionList = (from item in permission.Split(',')
             select int.Parse(item)).ToList();

            AuthAccess authAccess = new AuthAccess();
            authAccess.RoleId = id;
            using (DbSession dbSession = GetDbSession(true))
            {
                dbSession.Delete<AuthAccess>(SqlCriteria.New.Equal("roleid", id));
                foreach (int permissionId in permissionList)
                {
                    authAccess.PermissionId = permissionId;
                    dbSession.Insert(authAccess);
                }

                dbSession.CommitTransaction();
            }

            CacheManager.Instance.RemoveCategoryCache(Constants.UserAllPermission);

            return @"{""status"":""true""}";
        }
    }
}
