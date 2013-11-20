using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Web;
using System.Data;
using System.Configuration;
using Bee.Data;
using System.Drawing;
using System.IO;
using Bee.Util;
using Bee.Models;
using Bee.Caching;
using System.Collections;

namespace Bee.Security.Controllers
{

    [DefaultController]
    public class AuthMainController : ControllerBase
    {
        static AuthMainController()
        {
            Bee.Constants.DateTimeFormat = SystemConfigManager.Instance.GetConfigValue("DateTimeFormat");
            Bee.Constants.NumberFormat = SystemConfigManager.Instance.GetConfigValue("NumberFormat");
        }

        public ActionResult Index()
        {
            AuthUser user = Session[Constants.SessionUserId] as AuthUser;
            if(user == null)
            {
                return Redirect(ControllerName, "Login");
            }
            else
            {
                ViewData["nickname"] = user.NickName;
                ViewData["username"] = user.UserName;

                DataTable table = AuthManager.Instance.AuthMenu(user.Id);

                return View(ControllerName, "Index", table);
            }
        }

        public ActionResult Login()
        {
            if (Session[Constants.SessionUserId] == null)
            {
                return View("Login");
            }
            else
            {
                return Redirect(ControllerName, "Index");
            }
        }

        public ActionResult Logout()
        {
            Session[Constants.SessionUserId] = null;
            return Redirect(ControllerName, "Login");
        }

        public ActionResult Login(string username, string password)
        {
            //string validId = ViewData.TryGetValue<string>("validid", string.Empty);
            //if (Session[Constants.SessionValidId] != null 
            //    && string.Compare(validId, Session[Constants.SessionValidId].ToString(), true) != 0)
            //{
            //    ViewData["errorMsg"] = "验证码有误";

            //    return View("Login");
            //}

            if (Session[Constants.SessionUserId] == null)
            {
                AuthUser user = AuthManager.Instance.AuthLogin(username, password, true);
                if(user != null)
                {
                    return Redirect(ControllerName, "Index");
                }
                else
                {
                    ViewData["errorMsg"] = "用户名密码不匹配";

                    return View("Login");
                }
            }
            else
            {
                return Redirect(ControllerName, "Index");
            }
        }

        public ActionResult Cache()
        {
            List<string> list = new List<string>();
            foreach (DictionaryEntry item in HttpRuntime.Cache)
            {
                list.Add(item.Key.ToString());
            }

            return Json(list);
        }

        public ActionResult ChangePassword(BeeDataAdapter dataAdapter)
        {
            AuthUser user = AuthManager.Instance.CurrentUser;

            string password = dataAdapter["password"] as string;
            string newPassword = dataAdapter["newpassword"] as string;
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(newPassword))
            {
                return View("ChangePassword");
            }
            else
            {
                bool result = AuthManager.Instance.ChangePassword(user.Id, password, newPassword);

                return Json(result);
            }
        }

        public ActionResult ChangeUserInfo(BeeDataAdapter dataAdapter)
        {
            AuthUser user = AuthManager.Instance.CurrentUser;

            string email = dataAdapter["email"] as string;
            if (string.IsNullOrEmpty(email))
            {
                ViewData["email"] = user.Email;
                ViewData["nickname"] = user.NickName;

                return View("ChangeUserInfo");
            }
            else
            {
                string nickname = dataAdapter["nickname"] as string;
                AuthManager.Instance.ChangeUserInfo(user.Id, email, nickname);
                user.Email = email;

                return Json(true);
            }
        }

        public PageResult TableToCode()
        {
            List<string> connList = new List<string>();
            foreach (ConnectionStringSettings item in ConfigurationManager.ConnectionStrings)
            {
                if (!string.IsNullOrEmpty(item.ConnectionString)
                    && !string.IsNullOrEmpty(item.ProviderName)
                    && item.ElementInformation.IsPresent)
                {
                    connList.Add(item.Name);
                }
            }

            ViewData["ConnectionString"] = connList;

            
            return View("TableToCode");
        }

        public PageResult GetDbSchema(string connString)
        {
            using (DbSession dbSession = new DbSession(connString))
            {
                return View(ControllerName, "DbObjectTree", (from item in dbSession.GetDbObject()
                                                                 where item.ObjectType != DbObjectType.SP
                                                                 orderby item.DbObjectName
                                                                 select item).ToList());
            }
        }

        public PageResult GetCode(string connString, string dbObject)
        {
            using (DbSession dbSession = new DbSession(connString))
            {
                TableSchema tableSchema = dbSession.GetTableSchema(dbObject);

                return View(ControllerName, "GetCode", tableSchema);
            }
        }

        public PageResult SystemConfig()
        {
            DataTable systemConfig = DataMapping.Instance.GetMapping("systemconfig") as DataTable;
            if (systemConfig != null)
            {
                foreach (DataRow row in systemConfig.Rows)
                {
                    ViewData.Add(row["name"].ToString(), row["value"]);
                }
            }

            return View();
        }

        public void SaveConfig(string name, string value)
        {
            SystemConfigManager.Instance.SetConfigValue(name, value);
        }

        public bool HeartBeat()
        {
            return Session[Constants.SessionUserId] != null;
        }

        public StreamResult SiteShortCut()
        {
            string url = HttpContextUtil.CurrentHttpContext.Request.UrlReferrer.ToString();
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(string.Format(@"[InternetShortcut]
URL={0}", url));
            writer.Flush();
            
            stream.Position = 0;

            return new StreamResult(SystemConfigManager.Instance.GetConfigValue("SiteName") + ".url", stream);
        }


        public StreamResult ValidImage()
        {
            string id = Bee.Util.StringUtil.GetRandomString(4);
            Session[Constants.SessionValidId] = id;

            Bitmap bimap = Bee.Util.DrawingUtil.CreateImage(id);

            MemoryStream stream = new MemoryStream();
            bimap.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
            stream.Position = 0;

            return new StreamResult("gif", stream);
        }
    }
}
