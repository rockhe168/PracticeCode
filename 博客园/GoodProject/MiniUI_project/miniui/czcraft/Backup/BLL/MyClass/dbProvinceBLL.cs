using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.IO;
using Newtonsoft.Json;
namespace czcraft.BLL
{
   public partial class dbProvinceBLL
    {
        #region 根据父级id获取下级
        /// <summary>
        /// 根据父级id获取下级
        /// </summary>
        /// <param name="id">父级id</param>
        /// <returns></returns>
        public IEnumerable<dbProvince> GetArea(string id)
        {
            return new dbProvinceDAL().GetArea(id);
        } 
        #endregion
        #region 根据父级id获取下级
        /// <summary>
        /// 根据父级id获取下级
        /// </summary>
        /// <param name="id">父级id</param>
        /// <returns></returns>
        public string GetAreaByJson(string id)
        {
            //查询状态
            bool Status = false;
            //根据父级id获取下级
            IEnumerable<dbProvince> list = new dbProvinceDAL().GetArea(id);
            //转化为json格式
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;
                //判断数据读取状态
                if (list.Count() > 0)
                {
                    Status = true;
                }
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");

                jsonWriter.WriteStartArray();
                if (Status == true)
                {
                    foreach (dbProvince dbInfo in list)
                    {
                        jsonWriter.WriteStartObject();
                        jsonWriter.WritePropertyName("CodeId");
                        jsonWriter.WriteValue(dbInfo.codeid);
                        jsonWriter.WritePropertyName("CityName");
                        jsonWriter.WriteValue(dbInfo.cityName);
                        jsonWriter.WriteEndObject();
                    }
                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();

            }
            return json.ToString();
        } 
        #endregion
    }
}
