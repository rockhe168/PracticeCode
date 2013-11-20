using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.DAL;
using czcraft.Model;
using Common;
using Newtonsoft.Json;
using System.IO;
using System.Data;
namespace czcraft.BLL
{
   public partial class productBLL
    {
        #region 判定查询条件
        /// <summary>
        /// 判定查询条件
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string ConfirmCondition(string info)
        {
            string condition = "";//查询条件
            if (Tools.IsNumber(info)) //如果是数字,则查询id
            {
                condition = "Id like '%" + info + "%'";
            }
            else condition = "Name like '%" + info + "%'"; //查询用户名
            return condition;
        } 
        #endregion
        #region 根据排名查询首页显示的前n个商品
       /// <summary>
        /// 根据排名查询首页显示的前n个商品
       /// </summary>
       /// <param name="TopNum">10</param>
       /// <returns></returns>
       public static IEnumerable<product> GetTopProductForMainShow(int TopNum)
        {
            IEnumerable<product> Productlist = new productDAL().GetTopProductByRank(TopNum);
            return Productlist;
        }
       /// <summary>
        /// 根据排名查询首页显示的前n个商品
        /// </summary>
        /// <param name="TopNum">排名</param>
        /// <returns></returns>
        public static string GetTopProductForMain(int TopNum)
        {
            IEnumerable<product> Productlist = new productDAL().GetTopProductByRank(TopNum);
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;

                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(true);
                jsonWriter.WritePropertyName("Data");
                jsonWriter.WriteStartArray();
                //产品排名
                foreach (product Info in Productlist)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Id");
                    jsonWriter.WriteValue(Info.Id);
                    jsonWriter.WritePropertyName("Name");
                    jsonWriter.WriteValue(Info.Name);
                    jsonWriter.WritePropertyName("PicturePath");
                    jsonWriter.WriteValue(Info.Picturepath);
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();
            }
            return json.ToString();

        } 
        #endregion
        #region 根据排名前5寻找企业大师和产品
        /// <summary>
        /// 根据排名前5寻找企业大师和产品
        /// </summary>
        /// <returns></returns>
        public string GetTopByRankByJson()
        {
            IEnumerable<product> Productlist = new productDAL().GetTopProductByRank(5);
            IEnumerable<master> Masterlist = new masterDAL().GetTopMasterByRank(5);
            IEnumerable<company> Companylist = new companyDAL().GetTopCompanyByRank(5);
            ////加载状态
            //bool Status = false;
            //转化为json格式
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;

                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(true);
                jsonWriter.WritePropertyName("Data");
                jsonWriter.WriteStartArray();
                //产品排名
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("ProductData");
                jsonWriter.WriteStartArray();
                foreach (product Info in Productlist)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Id");
                    jsonWriter.WriteValue(Info.Id);
                    jsonWriter.WritePropertyName("Name");
                    jsonWriter.WriteValue(Info.Name);
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();
                //大师排名
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("MasterData");
                jsonWriter.WriteStartArray();
                foreach (master Info in Masterlist)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Id");
                    jsonWriter.WriteValue(Info.Id);
                    jsonWriter.WritePropertyName("Name");
                    jsonWriter.WriteValue(Info.Name);
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();
                //企业排名Companylist
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("CompanyData");
                jsonWriter.WriteStartArray();
                foreach (company Info in Companylist)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Id");
                    jsonWriter.WriteValue(Info.Id);
                    jsonWriter.WritePropertyName("Name");
                    jsonWriter.WriteValue(Info.Name);
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
        #region 根据排名前8寻找大师
        /// <summary>
        /// 根据排名前8寻找大师
        /// </summary>
        /// <returns></returns>
        public string GetTopProductByRankByJson()
        {
            IEnumerable<product> list = new productDAL().GetTopProductByRank(5);
            //加载状态
            bool Status = false;
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
                foreach (product Info in list)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Id");
                    jsonWriter.WriteValue(Info.Id);
                    jsonWriter.WritePropertyName("Name");
                    jsonWriter.WriteValue(Info.Name);
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();
            }
            return json.ToString();

        } 
        #endregion
        #region 获取产品信息
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="ProductId">产品id</param>
        /// <returns></returns>
        public string GetProductJson(long ProductId)
        {
            bool Status = false;

            VProductCraftTypeDAL dal = new VProductCraftTypeDAL();
            VProductCraftType Info = dal.Get(ProductId);
            if (Info.Id.HasValue)
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
                jsonWriter.WritePropertyName("ProductId");
                jsonWriter.WriteValue(Info.Id);
                jsonWriter.WritePropertyName("ProductName");
                jsonWriter.WriteValue(Info.Name);
                jsonWriter.WritePropertyName("TypeName");
                jsonWriter.WriteValue(Info.TypeName);

                //所属企业
                if (Info.Belongstype == 1)
                {
                    company companyInfo = new companyDAL().Get(Info.Companyid.Value);
                    jsonWriter.WritePropertyName("BelongType");
                    jsonWriter.WriteValue(Info.Belongstype);
                    jsonWriter.WritePropertyName("BelongId");
                    jsonWriter.WriteValue(Info.Companyid);
                    jsonWriter.WritePropertyName("BelongName");
                    jsonWriter.WriteValue(companyInfo.Name);
                }
                //所属大师
                else if (Info.Belongstype == 0)
                {
                    master masterInfo = new masterDAL().Get(Info.Masterid.Value);
                    jsonWriter.WritePropertyName("BelongType");
                    jsonWriter.WriteValue(Info.Belongstype);

                    jsonWriter.WritePropertyName("BelongId");
                    jsonWriter.WriteValue(Info.Masterid);
                    jsonWriter.WritePropertyName("BelongName");
                    jsonWriter.WriteValue(masterInfo.Name);

                }
                else
                //潮州工艺品官方提供
                {
                    company companyInfo = new companyDAL().Get(Info.Companyid.Value);
                    jsonWriter.WritePropertyName("BelongType");
                    jsonWriter.WriteValue(Info.Belongstype);
                    jsonWriter.WritePropertyName("BelongId");
                    jsonWriter.WriteValue(Info.Companyid);
                    jsonWriter.WritePropertyName("BelongName");
                    jsonWriter.WriteValue(companyInfo.Name);
                }
                jsonWriter.WritePropertyName("LsPrice");
                jsonWriter.WriteValue(Info.Lsprice);
                jsonWriter.WritePropertyName("Num");
                jsonWriter.WriteValue(Info.Num);
                jsonWriter.WritePropertyName("SoldNum");
                jsonWriter.WriteValue(Info.Soldnum);
                jsonWriter.WritePropertyName("PicturePath");
                jsonWriter.WriteValue(Info.Picturepath);
                jsonWriter.WritePropertyName("Explain");
                jsonWriter.WriteValue(Info.Explain);
                jsonWriter.WriteEndObject();


                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject();
            }
            return json.ToString();

        } 
        #endregion
        #region 更新大师排名信息
        /// <summary>
        /// 更新大师排名信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateProductRank(product model)
        {
            return new productDAL().UpdateproductRank(model);
        } 
        #endregion
        #region 专门生成为MiniUi单个数据生成json数据(T->json)
        /// <summary>
        /// 专门生成为MiniUi单个数据生成json数据(T->json)
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <returns>返回json数据</returns>
        public static string MiniUiForSingeAddProductToJson(product Info)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{");
            Json.Append("\"Id\":\"" + Info.Id + "\"");
            Json.Append(",");
            Json.Append("\"Name\":\"" + Info.Name + "\"");
            Json.Append(",");
            Json.Append("\"Simplename\":\"" + Info.Simplename + "\"");
            Json.Append(",");
            Json.Append("\"Explain\":\"" + Info.Explain + "\"");
            Json.Append(",");
            Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
            Json.Append(",");
            Json.Append("\"Flashpath\":\"" + Info.Flashpath + "\"");
            Json.Append(",");
            Json.Append("\"Material\":\"" + Info.Material + "\"");
            Json.Append(",");
            Json.Append("\"Weight\":\"" + Info.Weight + "\"");
            Json.Append(",");
            Json.Append("\"Volume\":\"" + Info.Volume + "\"");
            Json.Append(",");
            Json.Append("\"Specification\":\"" + Info.Specification + "\"");
            Json.Append(",");
            Json.Append("\"Model\":\"" + Info.Model + "\"");
            Json.Append(",");
            Json.Append("\"Issell\":\"" + Info.Issell + "\"");
            Json.Append(",");
            Json.Append("\"Isexcellent\":\"" + Info.Isexcellent + "\"");
            Json.Append(",");
            Json.Append("\"Nongenetic\":\"" + Info.Nongenetic + "\"");
            Json.Append(",");
            Json.Append("\"Isrecomment\":\"" + Info.Isrecomment + "\"");
            Json.Append(",");
            Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
            Json.Append(",");
            Json.Append("\"Typeid\":\"" + Info.Typeid + "\"");
            Json.Append(",");
            string TypeName = "";
            if (Info.Typeid.HasValue)
            {
                TypeName = new crafttypeDAL().Get((int)Info.Typeid).Name;

            }
            Json.Append("\"Typename\":\"" + TypeName + "\"");
            Json.Append(",");
            Json.Append("\"Belongstype\":\"" + Info.Belongstype + "\"");
            Json.Append(",");
            Json.Append("\"Masterid\":\"" + Info.Masterid + "\"");
            Json.Append(",");
            Json.Append("\"Companyid\":\"" + Info.Companyid + "\"");
            Json.Append(",");
            Json.Append("\"Num\":\"" + Info.Num + "\"");
            Json.Append(",");
            Json.Append("\"Soldnum\":\"" + Info.Soldnum + "\"");
            Json.Append(",");
            Json.Append("\"Lsprice\":\"" + Info.Lsprice + "\"");
            Json.Append(",");
            Json.Append("\"Pfprice\":\"" + Info.Pfprice + "\"");
            Json.Append(",");
            Json.Append("\"Vipprice\":\"" + Info.Vipprice + "\"");
            Json.Append(",");
            Json.Append("\"MarketPrice\":\"" + Info.MarketPrice + "\"");
            Json.Append(",");
            Json.Append("\"Price1\":\"" + Info.Price1 + "\"");
            Json.Append(",");
            Json.Append("\"Price2\":\"" + Info.Price2 + "\"");
            Json.Append(",");
            Json.Append("\"Price3\":\"" + Info.Price3 + "\"");
            Json.Append(",");
            Json.Append("\"Price4\":\"" + Info.Price4 + "\"");
            Json.Append(",");
            Json.Append("\"hit\":\"" + Info.hit + "\"");
            Json.Append(",");
            Json.Append("\"rank\":\"" + Info.rank + "\"");
            Json.Append("}");
            return Json.ToString();
        } 
        #endregion
        #region 删除图片
        #region 获取产品主图片
        /// <summary>
        /// 获取产品主图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetProductPicPath(long id)
        {
            productDAL dal = new productDAL();
            product pic = dal.Get(id);
            return pic.Picturepath;
        } 
        #endregion
        #region 删除产品图片
        /// <summary>
        /// 删除产品其他图片
        /// </summary>
        /// <param name="dt"></param>
        public void DeleteMoreOtherProductPicByProductId(DataTable dt)
        {
            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {

                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetOtherProductPic, dr["Picturepath"].ToString());
            }

        } 
        #endregion
        #region 删除多张产品图片
        /// <summary>
        /// 删除多张产品图片
        /// </summary>
        /// <param name="dt"></param>
        public void DeleteProductPic(DataTable dt)
        {

            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {

                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetMainProductPic, dr["Picturepath"].ToString());
            }

        } 
        #endregion
        #endregion
        #region 删除
        /// <summary>
        /// 删除product
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(long id)
        {
            //获取产品图片
            string Picturepath = GetProductPicPath(id);
            //获取其他图片
            DataTable dtOtherProductPic=new product_picturepathDAL().GetOtherProductPicByProductId(id.ToString ());

            productDAL dal= new productDAL();
            bool Status = dal.Delete(id);
            //如果执行成功,则删除图片
            if (Status)
            {
                //删除产品主图片
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetMainProductPic, Picturepath);
                //删除产品副图片
                DeleteMoreOtherProductPicByProductId(dtOtherProductPic);

            }
            return Status;
        }
        /// <summary>
        /// 删除products
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            //获取所有产品主图片
            DataTable dtProducts = new productDAL().GetMoreProductPic(strID);
            //获取其他图片
            DataTable dtOtherProductPic = new product_picturepathDAL().GetOtherProductPicByProductId(strID);
            bool Status = new productDAL().DeleteMoreID(strID);
            if (Status)
            {
                //删除产品主图片
                DeleteProductPic(dtProducts);
                //删除产品其他图片
                DeleteMoreOtherProductPicByProductId(dtOtherProductPic);
            }
            return Status;
        }
        #endregion
    }
}
