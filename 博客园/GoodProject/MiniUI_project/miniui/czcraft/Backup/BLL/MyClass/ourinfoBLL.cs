using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.DAL;
using czcraft.Model;
using System.IO;
using Newtonsoft.Json;
using System.Web;
namespace czcraft.BLL
{
   public partial class ourinfoBLL
    {
        #region 关于我们信息的的json格式
        /// <summary>
        /// 关于我们信息的的json格式
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string OurInfoToJson(ourinfo Info)
        {

            StringBuilder Json = new StringBuilder();
            StringWriter sw = new StringWriter(Json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;

                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("id");
                jsonWriter.WriteValue(Info.Id);
                jsonWriter.WritePropertyName("Name");
                jsonWriter.WriteValue(Info.Name);
                jsonWriter.WritePropertyName("Introduction");
                jsonWriter.WriteValue(Info.Introduction);
                jsonWriter.WritePropertyName("Representative");
                jsonWriter.WriteValue(Info.Representative);
                jsonWriter.WritePropertyName("Website");
                jsonWriter.WriteValue(Info.Website);
                jsonWriter.WritePropertyName("mobilephone");
                jsonWriter.WriteValue(Info.mobilephone);
                jsonWriter.WritePropertyName("Telephone");
                jsonWriter.WriteValue(Info.Telephone);
                jsonWriter.WritePropertyName("Email");
                jsonWriter.WriteValue(Info.Email);
                jsonWriter.WritePropertyName("qq");
                jsonWriter.WriteValue(Info.qq);
                jsonWriter.WritePropertyName("Zipcode");
                jsonWriter.WriteValue(Info.Zipcode);
                jsonWriter.WritePropertyName("Address");
                jsonWriter.WriteValue(Info.Address);

                jsonWriter.WriteEndObject();


            }
            return Json.ToString();

        } 
        #endregion
        #region 关于网站信息的的json格式
        /// <summary>
        /// 关于网站信息的的json格式
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string OurWebInfoToJson(ourinfo Info)
        {
            //服务器名称
            string MachineName = HttpContext.Current.Server.MachineName;
            //服务器ip
            string LocalIp = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
            //.net版本
            string NetFramework = Environment.Version.ToString();
            //操作系统版本
            string OSVersion = Environment.OSVersion.ToString();
            //iis版本
            string IISVersion = HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"];
            //服务器端口
            string ServerPort = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            //虚拟目录绝对路径
            string RealDirectory = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
            //https支持
            string SupportHttps = HttpContext.Current.Request.ServerVariables["HTTPS"];
            //session总数
            string SessionCount = HttpContext.Current.Session.Keys.Count.ToString();

            StringBuilder Json = new StringBuilder();
            StringWriter sw = new StringWriter(Json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;

                jsonWriter.WriteStartObject();
                //网站信息
                jsonWriter.WritePropertyName("MachineName");
                jsonWriter.WriteValue(MachineName);
                jsonWriter.WritePropertyName("LocalIp");
                jsonWriter.WriteValue(LocalIp);
                jsonWriter.WritePropertyName("NetFramework");
                jsonWriter.WriteValue(NetFramework);
                jsonWriter.WritePropertyName("OSVersion");
                jsonWriter.WriteValue(OSVersion);
                jsonWriter.WritePropertyName("IISVersion");
                jsonWriter.WriteValue(IISVersion);
                jsonWriter.WritePropertyName("ServerPort");
                jsonWriter.WriteValue(ServerPort);
                jsonWriter.WritePropertyName("RealDirectory");
                jsonWriter.WriteValue(RealDirectory);
                jsonWriter.WritePropertyName("SupportHttps");
                jsonWriter.WriteValue(SupportHttps);
                jsonWriter.WritePropertyName("SessionCount");
                jsonWriter.WriteValue(SessionCount);

                //公司信息
                jsonWriter.WritePropertyName("id");
                jsonWriter.WriteValue(Info.Id);
                jsonWriter.WritePropertyName("Name");
                jsonWriter.WriteValue(Info.Name);
                jsonWriter.WritePropertyName("Introduction");
                jsonWriter.WriteValue(Info.Introduction);
                jsonWriter.WritePropertyName("Representative");
                jsonWriter.WriteValue(Info.Representative);
                jsonWriter.WritePropertyName("Website");
                jsonWriter.WriteValue(Info.Website);
                jsonWriter.WritePropertyName("mobilephone");
                jsonWriter.WriteValue(Info.mobilephone);
                jsonWriter.WritePropertyName("Telephone");
                jsonWriter.WriteValue(Info.Telephone);
                jsonWriter.WritePropertyName("Email");
                jsonWriter.WriteValue(Info.Email);
                jsonWriter.WritePropertyName("qq");
                jsonWriter.WriteValue(Info.qq);
                jsonWriter.WritePropertyName("Zipcode");
                jsonWriter.WriteValue(Info.Zipcode);
                jsonWriter.WritePropertyName("Address");
                jsonWriter.WriteValue(Info.Address);

                jsonWriter.WriteEndObject();


            }
            return Json.ToString();

        } 
        #endregion
    }
}
