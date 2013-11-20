using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using System.Data;
namespace czcraft.BLL
{
    public partial class product_picturepathBLL
    {
        #region 获取图片信息
        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public IEnumerable<product_picturepath> GetProductPic(string ProductId)
        {
            List<product_picturepath> list = (List<product_picturepath>)new product_picturepathDAL().GetProductPic(ProductId);
            //主图片信息:
            long Id = Convert.ToInt64(ProductId);
            product Info = new productDAL().Get(Id);
            product_picturepath pic = new product_picturepath();
            pic.Id = -1;
            pic.Picturepath = Info.Picturepath;
            pic.Productid = Info.Id;
            list.Add(pic);
            return list;
        } 
        #endregion
        #region 添加多张图片
        /// <summary>
        /// 添加多张图片
        /// </summary>
        /// <param name="PicList">图片数组,用,隔开</param>
        /// <returns></returns>
        public bool AddMutiPic(string ProductId, string PicList)
        {
            return new product_picturepathDAL().AddMutiPic(ProductId, PicList);
        } 
        #endregion
        #region 获取所有的产品图片信息
        /// <summary>
        /// 获取所有的产品图片信息
        /// </summary>
        /// <param name="ProductId">产品id</param>
        /// <returns></returns>
        public string GetProductPicForJson(string ProductId)
        {
            IEnumerable<product_picturepath> list = new product_picturepathDAL().GetProductPic(ProductId);
            bool Status = false;


            if (list.Count() > 0)
            {
                Status = true;
            }
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartObject();

                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");
                jsonWriter.WriteStartArray();

                jsonWriter.WriteStartObject();
                //主图片信息:
                long Id = Convert.ToInt64(ProductId);
                product Info = new productDAL().Get(Id);
                jsonWriter.WritePropertyName("MainPic");
                jsonWriter.WriteValue(Info.Picturepath);
                jsonWriter.WritePropertyName("OtherPic");
                jsonWriter.WriteStartArray();
                //输出附属图片信息
                foreach (product_picturepath pic in list)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("PicturePath");
                    jsonWriter.WriteValue(pic.Picturepath);
                    jsonWriter.WriteEndObject();

                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();

                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject();
            }
            return json.ToString();

        } 
        #endregion
        #region 删除
        /// <summary>
        /// 获取产品主图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetOtherProductPicPath(int id)
        {
            product_picturepathDAL dal = new product_picturepathDAL();
            product_picturepath pic = dal.Get(id);
            return pic.Picturepath;
        }
        /// <summary>
        /// 删除product_picturepath
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {
            //获取产品图片
            string Picturepath = GetOtherProductPicPath(id);
            product_picturepathDAL dal=new product_picturepathDAL ();
            bool Status=dal.Delete(id);
            //如果执行成功,则删除图片
            if (Status)
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetOtherProductPic, Picturepath);
            return Status;
        }
        /// <summary>
        /// 删除多张产品其他图片
        /// </summary>
        public void DeleteMoreOtherProductPic(DataTable dt)
        {

            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {
                
        Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetOtherProductPic, dr["Picturepath"].ToString());
            }
         
        }
        /// <summary>
        /// 删除product_picturepath
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            product_picturepathDAL dal= new product_picturepathDAL();
            DataTable dtProductPics = dal.GetOtherProductPicByMoreProductIds(strID);
            bool Status= dal.DeleteMoreID(strID);
            if (Status)
                DeleteMoreOtherProductPic(dtProductPics);
            return Status;
        }
        #endregion
    }
}
