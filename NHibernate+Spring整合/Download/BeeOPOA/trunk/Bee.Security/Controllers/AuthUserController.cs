using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Web;
using Bee.Models;
using System.Data;
using Bee.Data;
using Bee.Util;
using Bee.Caching;

namespace Bee.Security.Controllers
{

    public class AuthUserController : AuthControllerBase<AuthUser>
    {
        static AuthUserController()
        {
            DataMapping.Instance.Register("AuthUsermapping", () => {
                using (DbSession dbSession = DbSession.Current)
                {
                    return dbSession.ExecuteCommand("select id, NickName from authuser", null);
                }
            });
        }

        public override PageResult Index(BeeDataAdapter dataAdapter)
        {
            return List(dataAdapter);
        }

        public override PageResult List(BeeDataAdapter dataAdapter)
        {
            PageResult baseResult = base.List(dataAdapter);

            return new PageResult(ControllerName, "UserList", baseResult.Model);
        }

        public override PageResult Show(int id)
        {
            PageResult baseResult = base.Show(id);

            using (DbSession dbSession = GetDbSession())
            {
                if (id >= 0)
                {
                    List<AuthUserRole> userRoleList =
                        dbSession.Query<AuthUserRole>(SqlCriteria.New.Equal("userid", id));
                    List<AuthUserGroup> userGroupList =
                        dbSession.Query<AuthUserGroup>(SqlCriteria.New.Equal("userid", id));

                    string userRole = string.Join(",", (from item in userRoleList
                                                        select item.RoleId.ToString()).ToArray());

                    string userGroup = string.Join(",", (from item in userGroupList
                                                         select item.GroupId.ToString()).ToArray());
                    ViewData.Add("userrole", userRole);
                    ViewData.Add("usergroup", userGroup);
                }

                ViewData.Add("roleinfo", dbSession.Query("AuthRole",
                    SqlCriteria.New.Equal("delflag", false)));
                ViewData.Add("groupinfo", dbSession.Query("AuthGroup",
                    SqlCriteria.New.Equal("delflag", false)));

            }

            return new PageResult(ControllerName, "UserShow", baseResult.Model);
        }

        public void Save(AuthUser tempUser, string userRole, string userGroup)
        {
            using (DbSession dbSession = GetDbSession(true))
            {
                AuthUser dbAuthUser = null;
                if (tempUser.Id <= 0)
                {
                    // 新增用户
                    if (dbSession.Query<AuthUser>(SqlCriteria.New.Equal("username", tempUser.UserName)).Count != 0)
                    {
                        throw new Exception("已有相同名称");
                    }
                    if (AuthManager.Instance.Md5Encryp)
                    {
                        tempUser.Password = SecurityUtil.MD5EncryptS(tempUser.Password);
                    }

                    dbAuthUser = tempUser;
                }
                else
                {
                    // 密码不能修改
                    dbAuthUser = dbSession.Query<AuthUser>(SqlCriteria.New.Equal("id", tempUser.Id)).FirstOrDefault();
                    if (string.IsNullOrEmpty(tempUser.Password))
                    {
                        tempUser.Password = dbAuthUser.Password;
                    }
                    else
                    {
                        if (AuthManager.Instance.Md5Encryp)
                        {
                            tempUser.Password = SecurityUtil.MD5EncryptS(tempUser.Password);
                        }
                    }
                }

                dbSession.Save(tempUser);
                int userId = tempUser.Id;
                dbSession.Delete<AuthUserGroup>(SqlCriteria.New.Equal("userid", userId));
                dbSession.Delete<AuthUserRole>(SqlCriteria.New.Equal("userid", userId));

                List<int> userRoleList = (from item in userRole.Split(new Char[]{','}, 
                                              StringSplitOptions.RemoveEmptyEntries)
                                          select int.Parse(item)).ToList();
                List<int> userGroupList = (from item in userGroup.Split(new Char[] { ',' },
                                              StringSplitOptions.RemoveEmptyEntries)
                                           select int.Parse(item)).ToList();

                AuthUserGroup authUserGroup = new AuthUserGroup();
                authUserGroup.UserId = userId;
                foreach (int groupId in userGroupList)
                {
                    authUserGroup.GroupId = groupId;
                    dbSession.Insert(authUserGroup);
                }

                AuthUserRole authUserRole = new AuthUserRole();
                authUserRole.UserId = userId;
                foreach (int roleId in userRoleList)
                {
                    authUserRole.RoleId = roleId;
                    dbSession.Insert(authUserRole);
                }

                dbSession.CommitTransaction();
            }

            DataMapping.Instance.Refresh("AuthUsermapping");
            CacheManager.Instance.RemoveCache(string.Format("{0}_{1}", Constants.UserAllPermission, tempUser.Id));
        }

        public override void Delete(int id)
        {
            using (DbSession dbSession = GetDbSession())
            {
                BeeDataAdapter data = new BeeDataAdapter();
                data.Add("delflag", 1);
                dbSession.Update("AuthUser", data, SqlCriteria.New.Equal("id", id));
            }
        }

        public PageResult ShowPermission(int id)
        {
            DataTable result;

            string sql = @"select d.id, d.parentid, d.name, d.title, d.dispindex, d.res, d.exres
                            from authuser a left join authuserrole b on a.id = b.userid
                            left join authaccess c on b.roleid = c.roleid 
                            left join authpermission d on c.permissionid = d.id
                            left join authrole e on b.roleid = e.id
                            where a.id = @userId and d.delflag = 0 and e.delflag = 0
                            union all
                            select d.id, d.parentid, d.name, d.title, d.dispindex, d.res, d.exres
                            from authusergroup a left join authgrouprole b on a.groupid = b.groupid
                            left join authrole e on b.roleid = e.id
                            left join authaccess c on b.roleid = c.roleid 
                            left join authpermission d on c.permissionid = d.id
                            left join authgroup f on a.groupid = f.id
                            where a.userid = @userId and e.delflag = 0 
                            and d.delflag=0 
                            and f.delflag = 0";
            List<string> permissionIdList = new List<string>();
            using (DbSession dbSession = GetDbSession())
            {
                result = dbSession.Query("AuthPermission", null);

                BeeDataAdapter dataAdapter = new BeeDataAdapter();
                dataAdapter.Add("userId", id);
                DataTable table = dbSession.ExecuteCommand(sql, dataAdapter);
                foreach (DataRow row in table.Rows)
                {
                    permissionIdList.Add(row["id"].ToString());
                }
            }

            string permission = string.Join(",", permissionIdList.ToArray());

            ViewData.Add("permission", permission);

            return View(ControllerName, "UserPermission", result);
        }

        public PageResult SuperList(BeeDataAdapter dataAdapter)
        {
            InitPagePara(dataAdapter);
            DataTable dataTable = null;
            using (DbSession dbSession = GetDbSession())
            {
                string tableName = "VAuthUserEx";
                SqlCriteria sqlCriteria = GetQueryCondition(typeof(AuthUserEx), dataAdapter);

                int pageNum = dataAdapter.TryGetValue<int>("pagenum", 1);
                int pageSize = dataAdapter.TryGetValue<int>("pagesize", 20);
                int recordCount = dataAdapter.TryGetValue<int>("recordcount", 0);

                string orderField = dataAdapter.TryGetValue<string>("orderField", "Id");
                string orderDirection = dataAdapter.TryGetValue<string>("orderDirection", "desc");

                dataTable =
                    dbSession.Query(tableName, "*", sqlCriteria, "{0} {1}".FormatWith(orderField, orderDirection),
                    pageNum, pageSize, ref recordCount);

                dataAdapter["recordcount"] = recordCount;
            }

            return View("SuperList", dataTable);
        }

        public PageResult SuperShow(int id)
        {
            using (DbSession dbSession = GetDbSession())
            {
                if (id >= 0)
                {
                    DataTable dataTable =
                        dbSession.Query("VAuthUserEx", SqlCriteria.New.Equal("id", id));
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        BeeDataAdapter dataAdapter = BeeDataAdapter.From(dataTable.Rows[0]);

                        ViewData.Merge(dataAdapter, true);
                    }

                    List<AuthUserRole> userRoleList =
                        dbSession.Query<AuthUserRole>(SqlCriteria.New.Equal("userid", id));
                    List<AuthUserGroup> userGroupList =
                        dbSession.Query<AuthUserGroup>(SqlCriteria.New.Equal("userid", id));

                    string userRole = string.Join(",", (from item in userRoleList
                                                        select item.RoleId.ToString()).ToArray());

                    string userGroup = string.Join(",", (from item in userGroupList
                                                         select item.GroupId.ToString()).ToArray());
                    ViewData.Add("userrole", userRole);
                    ViewData.Add("usergroup", userGroup);
                }

                ViewData.Add("roleinfo", dbSession.Query("AuthRole",
                    SqlCriteria.New.Equal("delflag", false)));
                ViewData.Add("groupinfo", dbSession.Query("AuthGroup",
                    SqlCriteria.New.Equal("delflag", false)));

            }

            return new PageResult(ControllerName, "SuperShow");
        }

        public void SuperSave(BeeDataAdapter dataAdapter)
        {
            AuthUser authUser = ConvertUtil.ConvertDataToObject<AuthUser>(dataAdapter);

            string userRole = dataAdapter.TryGetValue<string>("userrole", string.Empty);
            string userGroup = dataAdapter.TryGetValue<string>("userGroup", string.Empty);

            Save(authUser, userRole, userGroup);

            using (DbSession dbSession = GetDbSession())
            {
                DataTable dataTable = dbSession.Query("AuthUserEx", SqlCriteria.New.Equal("userid", authUser.Id));
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    dbSession.Update("AuthUserEx", dataAdapter, SqlCriteria.New.Equal("userid", authUser.Id));
                }
                else
                {
                    dbSession.Insert("AuthUserEx", dataAdapter);
                }
            }
        }


    }
}
