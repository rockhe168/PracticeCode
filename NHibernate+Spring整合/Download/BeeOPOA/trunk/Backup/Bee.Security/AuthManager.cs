using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Data;
using Bee.Util;
using System.Data;
using Bee.Models;
using Bee.Caching;
using Bee.Core;
using System.Text.RegularExpressions;

namespace Bee.Security
{
    public class AuthManager
    {
        private static readonly string AuthConnString = ConfigUtil.GetAppSettingValue<string>("Bee.Auth.DataSource");
        private static AuthManager instance = new AuthManager();

        private static readonly Regex ExAttributeRegex = new Regex("(?<name>[^?&]*?)=(?<value>[^&]+?)");

        private List<WeakReference> SessionList = new List<WeakReference>();

        private AuthManager()
        {

        }

        public static AuthManager Instance
        {
            get
            {
                return instance;
            }
        }

        public AuthUser CurrentUser
        {
            get
            {
                AuthUser authUser = null;
                if (HttpContext.Current.Session != null)
                {
                    authUser =
                        HttpContext.Current.Session[Constants.SessionUserId] as AuthUser;
                    if (authUser == null)
                    {
                        throw new CoreException("Session过期或丢失， 请重新登入");
                    }
                }

                return authUser;
            }
        }

        public bool Md5Encryp
        {
            get
            {
                bool result = false;
                bool.TryParse(SystemConfigManager.Instance.GetConfigValue("MD5Encryp"), out result);
                return result;
            }
        }

        public bool ChangePassword(int userId, string password, string newPassword)
        {
            using (DbSession dbSession = new DbSession(AuthConnString))
            {
                string md5Password = password;
                md5Password = SecurityUtil.MD5EncryptS(password);
                if (Md5Encryp)
                {
                    newPassword = SecurityUtil.MD5EncryptS(newPassword);
                }

                AuthUser user =
                    dbSession.Query<AuthUser>(SqlCriteria.New.Equal("id", userId)).FirstOrDefault();
                if (user.Password == password || user.Password == md5Password)
                {
                    user.Password = newPassword;
                    dbSession.Save(user);
                    return true;
                }
                else
                {

                    throw new Bee.Core.CoreException("原密码有误， 请确认！");

                }
            }
        }

        public void ChangeUserInfo(int userId, string email, string nickname)
        {
            using (DbSession dbSession = new DbSession(AuthConnString))
            {
                BeeDataAdapter dataAdapter = new BeeDataAdapter();
                dataAdapter.Add("email", email);
                dataAdapter.Add("nickname", nickname);
                dbSession.Update("AuthUser", dataAdapter, SqlCriteria.New.Equal("id", userId));
            }

            DataMapping.Instance.Refresh("AuthUsermapping");

        }

        public AuthUser AuthLogin(string userName, string password, bool logFlag)
        {
            using (DbSession dbSession = new DbSession(AuthConnString))
            {
                AuthUser user =
                    dbSession.Query<AuthUser>(SqlCriteria.New.Equal("UserName", userName)
                    .Equal("DelFlag", false)).FirstOrDefault();

                if (user != null)
                {
                    // 无论系统设置如何， 加密还是未加密， 均可登入。
                    string md5Password = password;
                    md5Password = SecurityUtil.MD5EncryptS(password);

                    if (user.Password == password || user.Password == md5Password)
                    {
                        HttpContext.Current.Session[Constants.SessionUserId] = user;
                        WeakReference weakReference = new WeakReference(HttpContext.Current.Session);
                        SessionList.Add(weakReference);

                        if (logFlag)
                        {
                            LoginLog loginLog = new LoginLog();
                            loginLog.UserId = user.Id;
                            loginLog.IP = HttpContextUtil.RemoteIP;

                            dbSession.Insert(loginLog);
                        }
                    }
                    else
                    {
                        user = null;
                    }
                }

                return user;
            }
        }

        public DataTable AuthMenu(int userId)
        {

            BeeDataAdapter dataAdapter = new BeeDataAdapter();
            dataAdapter.Add("userId", userId);

            DataTable template = GetAllShownPermission();

            DataTable result = null;
            if (userId == 1)
            {
                result = template;
            }
            else
            {
                DataRow[] rows = GetUserAllPermission(userId).Select(SqlCriteria.New.Equal("showflag", 1).FilterClause);
                if (rows.Length > 0)
                {
                    result = rows.CopyToDataTable();
                }
                else
                {
                    result = new DataTable();
                }
                result = ConstructMenu(result, template);
            }

            return result;
        }

        //public bool CheckGrant(int permissionId)
        //{
        //    if (CurrentUser.Id == 1) return true;

        //    DataTable result = GetUserAllPermission(CurrentUser.Id);

        //    DataRow[] rows = result.Select(SqlCriteria.New.Equal("id", permissionId).FilterClause);

        //    return rows != null && rows.Length > 0;
        //}

        public bool CheckGrant(string res)
        {
            if (CurrentUser.Id == 1) return true;

            DataTable result = GetUserAllPermission(CurrentUser.Id);

            DataRow[] rows = result.Select(SqlCriteria.New.Equal("res", res).FilterClause);

            return rows != null && rows.Length > 0;
        }

        public bool CheckGrant(string controllerName, string actionName, BeeDataAdapter dataAdapter)
        {
            bool valid = false;

            int userId = CurrentUser.Id;

            if (userId == 1) return true;

            DataTable allPermission = GetAllShownPermission();
            DataRow[] allRows = allPermission.Select("res like '/{0}/{1}.bee%'".FormatWith(controllerName, actionName));
            if (allRows.Length == 0)
            {
                // 若该权限项未被声明， 则视为有权限。
                return true;
            }

            DataTable result = GetUserAllPermission(userId);

            DataRow[] rows = result.Select("res like '/{0}/{1}.bee%'".FormatWith(controllerName, actionName));

            if (rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    string res = HttpUtility.HtmlDecode(row["res"].ToString().ToLower());
                    int charIndex = res.IndexOf('?');
                    if (charIndex >= 0)
                    {
                        res = res.Substring(charIndex + 1);
                        MatchCollection matchs = ExAttributeRegex.Matches(res);
                        bool validFlag = true;
                        foreach (Match match in matchs)
                        {
                            string name = match.Groups["name"].Value;
                            string value = match.Groups["value"].Value;

                            validFlag = dataAdapter.ContainsKey(name) && dataAdapter[name].ToString().ToLower() == value;

                            if (!validFlag)
                            {
                                break;
                            }
                        }

                        valid = validFlag;

                        if (valid)
                        {
                            break;
                        }
                    }
                    else
                    {
                        valid = true;
                        break;
                    }
                }
            }

            return valid;
        }

        private DataTable GetUserAllPermission(int userId)
        {
            return CacheManager.Instance.GetEntity<DataTable, int>(Constants.UserAllPermission, userId, TimeSpan.FromHours(2), pUserId =>
            {
                using (DbSession dbSession = new DbSession(AuthConnString))
                {
                    string sql = @"select d.id, d.parentid, d.name, d.title, d.dispindex, d.res, d.exres, d.showflag
                            from authuser a left join authuserrole b on a.id = b.userid
                            left join authaccess c on b.roleid = c.roleid 
                            left join authpermission d on c.permissionid = d.id
                            left join authrole e on b.roleid = e.id
                            where a.id = @userId and d.delflag = 0 and e.delflag = 0
                            union all
                            select d.id, d.parentid, d.name, d.title, d.dispindex, d.res, d.exres, d.showflag
                            from authusergroup a left join authgrouprole b on a.groupid = b.groupid
                            left join authrole e on b.roleid = e.id
                            left join authaccess c on b.roleid = c.roleid 
                            left join authpermission d on c.permissionid = d.id
                            left join authgroup f on a.groupid = f.id
                            where a.userid = @userId and e.delflag = 0 
                            and d.delflag=0 
                            and f.delflag = 0";

                    BeeDataAdapter dataAdapter = new BeeDataAdapter();
                    dataAdapter.Add("userId", pUserId);
                    return dbSession.ExecuteCommand(sql, dataAdapter);
                }
            });
        }

        private DataTable GetAllShownPermission()
        {
            return CacheManager.Instance.GetEntity<DataTable, string>(Constants.AllShownPermission, string.Empty, TimeSpan.FromHours(2), key =>
            {
                using (DbSession dbSession = new DbSession(AuthConnString))
                {
                    return dbSession.ExecuteCommand(@"select d.id, d.parentid, d.name, d.title, d.dispindex, d.res, d.exres, d.showflag
                                        from authpermission d where showflag=1 and delflag=0", null);
                }
            });
        }

        private DataTable ConstructMenu(DataTable srcTable, DataTable templateTable)
        {
            DataTable result = srcTable.Copy();
            foreach (DataRow row in srcTable.Rows)
            {
                FindParent(row, result, templateTable);
            }

            return result;
        }

        private void FindParent(DataRow row, DataTable srcTable, DataTable templateTable)
        {
            DataRow[] rows = srcTable.Select("id=" + row["parentid"]);
            if (rows.Length == 0)
            {
                rows = templateTable.Select("id=" + row["parentid"]);

                if (rows.Length != 0)
                {
                    DataRow newRow = srcTable.NewRow();

                    CopyRow(newRow, rows[0]);

                    srcTable.Rows.Add(newRow);

                    FindParent(newRow, srcTable, templateTable);
                }
            }
        }

        private void CopyRow(DataRow destRow, DataRow srcRow)
        {
            foreach (DataColumn column in destRow.Table.Columns)
            {
                destRow[column.ColumnName] = srcRow[column.ColumnName];
            }
        }

    }
}
