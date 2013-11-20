using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Reflection;
using Common;
using System.IO;
using Newtonsoft.Json;
namespace czcraft.BLL
{
   public partial class WEB_USERBLL
    {
       #region 登录验证,返回用户组信息
        /// <summary>
        /// 登录验证,返回用户组信息
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>返回用户组信息</returns>
       public int IsLogin(WEB_USER user)
       {
           int num = 0;
          num=new WEB_USERDAL().IsLogin(user);
              return num;
          
       } 
	#endregion
       #region 专门生成为MiniUi生成json数据(List->json)
       /// <summary>
       /// 专门生成为MiniUi生成json数据(List->json)
       /// </summary>
       /// <typeparam name="T">泛型</typeparam>
       /// <param name="list">实现了Ilist接口的list</param>
       /// <param name="total">记录总数</param>
       /// <param name="paramMaxMin">这里放排序的参数例如,string para="\"maxAge\":37,\"avgAge\":27,\"minAge\":24"</param>
       /// <returns></returns>
       public static string MiniUiListToJson(IEnumerable<WEB_USER> webUser, int total, string paramMaxMinAvg)
       {

           StringBuilder Json = new StringBuilder();
           StringWriter sw = new StringWriter(Json);
           using (JsonWriter jsonWriter = new JsonTextWriter(sw))
           {

               jsonWriter.Formatting = Formatting.Indented;
               jsonWriter.WriteStartObject();
               jsonWriter.WritePropertyName("total");
               jsonWriter.WriteValue(total);
               jsonWriter.WritePropertyName("data");
               jsonWriter.WriteStartArray();
               foreach (WEB_USER user in webUser)
               {
                   jsonWriter.WriteStartObject();
                   jsonWriter.WritePropertyName("LOGNAME");
                   jsonWriter.WriteValue(user.LOGNAME);
                   //jsonWriter.WritePropertyName("PASSWORD");
                   //jsonWriter.WriteValue(user.PASSWORD);
                   jsonWriter.WritePropertyName("USERGROUP");
                   jsonWriter.WriteValue(user.GROUP.USERGROUP);
                   jsonWriter.WritePropertyName("REALNAME");
                   jsonWriter.WriteValue(user.REALNAME);
                   jsonWriter.WritePropertyName("STATE");
                   jsonWriter.WriteValue(user.STATE);
                   jsonWriter.WritePropertyName("REG_DATE");
                   jsonWriter.WriteValue(user.REG_DATE.Value.GetDateTimeFormats('s')[0].ToString());
                   jsonWriter.WritePropertyName("LAST_LOG_DATE");
                   jsonWriter.WriteValue(user.LAST_LOG_DATE.Value.GetDateTimeFormats('s')[0].ToString());
                   jsonWriter.WritePropertyName("LOG_TIMES");
                   jsonWriter.WriteValue(user.LOG_TIMES.ToString());
                   jsonWriter.WritePropertyName("MEMO");
                   jsonWriter.WriteValue(user.MEMO);
                   jsonWriter.WritePropertyName("id");
                   jsonWriter.WriteValue(user.ID);

                   jsonWriter.WriteEndObject();
               }
               jsonWriter.WriteEndArray();
               jsonWriter.WriteEndObject();

           }
           return Json.ToString();

       } 
       #endregion
       #region 更新状态信息
       /// <summary>
       /// 更新状态信息
       /// </summary>
       /// <param name="user"></param>
       /// <returns></returns>
       public bool UpdateState(WEB_USER user)
       {
           return new WEB_USERDAL().UpdateState(user);
       } 
       #endregion
       #region 更新状态信息
       /// <summary>
       /// 返回编辑用户信息的的json格式
       /// </summary>
       /// <param name="user"></param>
       /// <returns></returns>
       public static string EditUserInfoToJson(WEB_USER user)
       {

           StringBuilder Json = new StringBuilder();
           StringWriter sw = new StringWriter(Json);
           using (JsonWriter jsonWriter = new JsonTextWriter(sw))
           {

               jsonWriter.Formatting = Formatting.Indented;

               jsonWriter.WriteStartObject();
               jsonWriter.WritePropertyName("LOGNAME");
               jsonWriter.WriteValue(user.LOGNAME);
               jsonWriter.WritePropertyName("REALNAME");
               jsonWriter.WriteValue(user.REALNAME);
               jsonWriter.WritePropertyName("USERGROUPID");
               jsonWriter.WriteValue(user.GROUP.ID);
               //jsonWriter.WritePropertyName("USERGROUP");
               //jsonWriter.WriteValue(user.GROUP.USERGROUP);
               jsonWriter.WritePropertyName("STATE");
               jsonWriter.WriteValue(user.STATE);
               jsonWriter.WritePropertyName("MEMO");
               jsonWriter.WriteValue(user.MEMO);
               jsonWriter.WritePropertyName("id");
               jsonWriter.WriteValue(user.ID);
               jsonWriter.WriteEndObject();


           }
           return Json.ToString();

       }
        
       #endregion
       
    }
}
