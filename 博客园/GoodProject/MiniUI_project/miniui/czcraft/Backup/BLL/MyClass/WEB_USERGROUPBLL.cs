using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Data;
using Newtonsoft.Json;
using System.IO;
namespace czcraft.BLL
{
   public partial class WEB_USERGROUPBLL
    {
        #region 根据用户组ID查找该用户组所有功能(视图中已做作权限判断)
        /// <summary>
        /// 根据用户组ID查找该用户组所有功能(视图中已做作权限判断)
        /// </summary>
        /// <param name="groupID">用户组信息</param>
        /// <returns></returns>
        public DataTable GetUserGroupFunction(int? groupID)
        {
            return new WEB_USERGROUPDAL().GetUserGroupFunction(groupID);
        } 
        #endregion
        #region 获取后台首页菜单数据(格式为json)
        /// <summary>
        /// 获取后台首页菜单数据(格式为json)
        /// </summary>
        /// <param name="user">user的model实体</param>
        /// <returns></returns>
        public string GetMenuByJson(WEB_USER user)
        {
            //这里要获取功能表中,一级菜单
            IEnumerable<WEB_SYS_FUNTION> functions = new WEB_SYS_FUNTIONDAL().ListAllTopMenu();
            DataTable dt = new WEB_USERGROUPDAL().GetUserGroupFunction(user.GROUP.ID);
            StringBuilder Json = new StringBuilder();
            StringWriter sw = new StringWriter(Json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.WriteStartArray();
                foreach (WEB_SYS_FUNTION funtion in functions)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("id");
                    jsonWriter.WriteValue(funtion.FUNTION_ID);
                    jsonWriter.WritePropertyName("text");
                    jsonWriter.WriteValue(funtion.NAME);
                    jsonWriter.WritePropertyName("expanded");
                    jsonWriter.WriteValue("false");
                    jsonWriter.WritePropertyName("children");//接下来是一个集合
                    jsonWriter.WriteStartArray();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if ((int)dr["FATHER_ID"] == funtion.FUNTION_ID)
                        {

                            jsonWriter.WriteStartObject();
                            jsonWriter.WritePropertyName("id");
                            jsonWriter.WriteValue(dr["FUNTION_ID"].ToString());
                            jsonWriter.WritePropertyName("url");
                            jsonWriter.WriteValue(dr["URL"].ToString());
                            jsonWriter.WritePropertyName("text");
                            jsonWriter.WriteValue(dr["NAME"].ToString());
                            jsonWriter.WritePropertyName("expanded");
                            jsonWriter.WriteValue("false");
                            jsonWriter.WriteEndObject();
                        }
                    }
                    jsonWriter.WriteEndArray();
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();
            }
            return Json.ToString();

        } 
        #endregion
        #region 获取菜单数据
        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <returns></returns>
        public string GetMenu(WEB_USER user)
        {
            //这里要获取功能表中,一级菜单
            IEnumerable<WEB_SYS_FUNTION> functions = new WEB_SYS_FUNTIONDAL().ListAllTopMenu();
            DataTable dt = new WEB_USERGROUPDAL().GetUserGroupFunction(user.GROUP.ID);
            StringBuilder sb = new StringBuilder();

            foreach (WEB_SYS_FUNTION funtion in functions)
            {
                sb.AppendFormat("<li><span value=\"crud\" expanded=\"false\">{0}</span>", funtion.NAME);
                sb.Append("<ul>");
                foreach (DataRow dr in dt.Rows)
                {
                    if ((int)dr["FATHER_ID"] == funtion.FUNTION_ID)
                    {
                        sb.AppendFormat("<li><a href=\"{0}\" target=\"main\">{1}</a></li>", dr["URL"].ToString(), dr["NAME"].ToString());
                    }

                }
                sb.Append("</ul>");
                sb.Append("</li>");
            }
            return sb.ToString();
        } 
        #endregion
    }
}
