using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Web;
using Bee.Models;
using Bee.Data;
using System.Data;
using Bee.Util;
using Bee.Caching;

namespace Bee.Security.Controllers
{
    public class AuthGroupController : AuthControllerBase<AuthGroup>
    {
        public override PageResult Index(BeeDataAdapter dataAdapter)
        {
            DataTable result;
            using (DbSession dbSession = GetDbSession())
            {
                result = dbSession.Query(TableName, null);

                ViewData.Add("roleinfo", dbSession.Query("AuthRole", SqlCriteria.New.Equal("delflag", false)));
            }

            return View(ControllerName, "Index", result);
        }

        public void Save(AuthGroup authGroup, string roleInfo)
        {
            using (DbSession dbSession = GetDbSession())
            {
                dbSession.Save(authGroup);

                int groupId = authGroup.Id;
                dbSession.Delete<AuthGroupRole>(SqlCriteria.New.Equal("groupid", groupId));

                List<int> groupRoleList = (from item in roleInfo.Split(new Char[] { ',' },
                                              StringSplitOptions.RemoveEmptyEntries)
                                          select int.Parse(item)).ToList();

                AuthGroupRole authGroupRole = new AuthGroupRole();
                authGroupRole.GroupId = groupId;
                foreach (int roleId in groupRoleList)
                {
                    authGroupRole.RoleId = roleId;
                    dbSession.Insert(authGroupRole);
                }
            }

            CacheManager.Instance.RemoveCategoryCache(Constants.UserAllPermission);
        }

        public BeeDataAdapter Detail(int id)
        {
            BeeDataAdapter dataAdapter;
            AuthGroup result = null;

            using (DbSession dbSession = GetDbSession())
            {
                result = dbSession.Query<AuthGroup>(SqlCriteria.New.Equal("id", id)).FirstOrDefault();

                List<AuthGroupRole> groupRoleList =
                       dbSession.Query<AuthGroupRole>(SqlCriteria.New.Equal("groupid", id));

                string groupRole = string.Join(",", (from item in groupRoleList
                                                     select item.RoleId.ToString()).ToArray());

                dataAdapter = BeeDataAdapter.From(result);
                dataAdapter.Add("roleinfo", groupRole);
            }

            return dataAdapter;
        }

        public PageResult OrgIndex(BeeDataAdapter dataAdapter)
        {
            DataTable result = null;
            using (DbSession dbSession = GetDbSession())
            {
                result = dbSession.Query("VAuthOrganization", SqlCriteria.New.Equal("grouptype", 2)); // 组织用户组

                ViewData.Add("roleinfo", dbSession.Query("AuthRole", SqlCriteria.New.Equal("delflag", false)));
            }

            return View("OrgIndex", result);
        }

        public void OrgSave(BeeDataAdapter dataAdapter)
        {
            AuthGroup authGroup = ConvertUtil.ConvertDataToObject<AuthGroup>(dataAdapter);
            string roleInfo = dataAdapter.TryGetValue<string>("roleinfo", string.Empty);

            authGroup.GroupType = 2; // 1 为正常用户组， 2：为组织用户组

            Save(authGroup, roleInfo);

            using (DbSession dbSession = GetDbSession())
            {
                DataTable dataTable = dbSession.Query("AuthOrganization", SqlCriteria.New.Equal("groupid", authGroup.Id));
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    dbSession.Update("AuthOrganization", dataAdapter, SqlCriteria.New.Equal("groupid", authGroup.Id));
                }
                else
                {
                    dataAdapter["groupid"] = authGroup.Id;
                    dataAdapter["OrgCode"] = GetOrgCode(authGroup);
                    dbSession.Insert("AuthOrganization", dataAdapter);
                }
            }
        }

        public BeeDataAdapter OrgDetail(int id)
        {
            BeeDataAdapter result = Detail(id);
            using (DbSession dbSession = GetDbSession())
            {
                DataTable table = dbSession.Query("AuthOrganization", SqlCriteria.New.Equal("groupid", id));
                if (table != null && table.Rows.Count > 0)
                {
                    result.Merge(BeeDataAdapter.From(table.Rows[0]), false);
                }
            }

            return result;
        }

        private string GetOrgCode(AuthGroup authGroup)
        {
            string result = string.Empty;
            DataTable dataTable = null;
            
            dataTable = DbSession.Current.QueryTop("VAuthOrganization", SqlCriteria.New.NotEqual("id", authGroup.Id).Equal("parentid", authGroup.ParentId), "id desc", 1);
            if (dataTable.Rows.Count > 0)
            {
                string orgCode = dataTable.Rows[0]["orgcode"].ToString();
                int length = orgCode.Length;
                int index = int.Parse(orgCode.Substring(length - 3, 3));
                index++;
                if (length > 3)
                {
                    result = orgCode.Substring(0, length - 3) + "{0:D3}".FormatWith(index);
                }
                else
                {
                    result = "{0:D3}".FormatWith(index);
                }
            }
            else
            {
                if (authGroup.ParentId == 0)
                {
                    result = "001";
                }
                else
                {
                    dataTable = DbSession.Current.QueryTop("VAuthOrganization", SqlCriteria.New.Equal("id", authGroup.ParentId), "id desc", 1);
                    string orgCode = dataTable.Rows[0]["orgcode"].ToString();
                    result = "{0}001".FormatWith(orgCode);
                }
            }

            return result;
        }
    }
}
