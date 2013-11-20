using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.IO;
using Newtonsoft.Json;
using System.Data;
namespace czcraft.BLL
{
    public partial class VProductCraftTypeBLL
    {
        #region 根据条件判断查询
        /// <summary>
        /// 根据条件判断查询
        /// </summary>
        /// <param name="Condition">查询条件</param>
        /// <param name="Title">标题</param>
        /// <returns></returns>
        public string ConfirmCondition(string Condition, out string Title)
        {
            string strConditon = "";
            Title = "";
            switch (Condition)
            {
                case "Isrecomment":
                    strConditon = " Isrecomment='1'";
                    Title = "推荐作品";
                    break;
                case "Isexcellent":
                    strConditon = " Isexcellent='1'";
                    Title = "佳作鉴赏";
                    break;
                case "Nongenetic":
                    strConditon = " Nongenetic='1' ";
                    Title = "非遗精品";
                    break;
                default:
                    break;
            }
            return strConditon;
        } 
        #endregion
        #region 查找非遗作品(每种分别显示前8个)
        /// <summary>
        /// 查找非遗作品(每种分别显示前8个)
        /// </summary>
        /// <returns></returns>
        public DataTable ListAllByNongeneticToDatable()
        {
            return new VProductCraftTypeDAL().ListAllByNongeneticToDatable();
        } 
        #endregion
        #region 根据企业id查找企业的产品信息(每种分别显示前8个)
        /// <summary>
        /// 根据企业id查找企业的产品信息(每种分别显示前8个)
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public string GetCompanyWorkForJson(string CompanyId)
        {
            //查询状态
            bool Status = false;
            //获取企业的产品信息(每种显示前8个)
            DataTable dtListProduct = new VProductCraftTypeDAL().ListAllByCompanyIdToDatable(CompanyId);
            //转化为json格式
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);

            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;
                //判断数据读取状态
                if (dtListProduct.Rows.Count > 0)
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
                    //先输出第一个元素的类别信息
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("TypeId");
                    jsonWriter.WriteValue(dtListProduct.Rows[0]["TypeId"].ToString());
                    jsonWriter.WritePropertyName("TypeName");
                    jsonWriter.WriteValue(dtListProduct.Rows[0]["TypeName"].ToString());
                    //第一个元素的开始
                    jsonWriter.WritePropertyName("Product");
                    jsonWriter.WriteStartArray();

                    //按照类别分组
                    //产品计数(一个分组下的产品,从1开始算起)

                    for (int num = 0, numProduct = 1; num < dtListProduct.Rows.Count; num++, numProduct++)
                    {

                        //获取该类别下的分组总个数
                        int Total = Convert.ToInt32(dtListProduct.Rows[num]["total"]);
                        //如果该类别下还存在未输出的产品
                        if (numProduct <= Total)
                        {


                            jsonWriter.WriteStartObject();
                            jsonWriter.WritePropertyName("ProductId");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["Id"].ToString());
                            jsonWriter.WritePropertyName("Name");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["Name"].ToString());
                            jsonWriter.WritePropertyName("SimpleName");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["SimpleName"].ToString());
                            jsonWriter.WritePropertyName("Lsprice");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["Lsprice"].ToString());
                            jsonWriter.WritePropertyName("Picturepath");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["Picturepath"].ToString());
                            jsonWriter.WriteEndObject();

                        }
                        else
                        {
                            //将该类别的产品计数重置为1
                            numProduct = 1;
                            //这里给上一个类别的产品结束标记

                            jsonWriter.WriteEndArray();
                            jsonWriter.WriteEndObject();

                            jsonWriter.WriteStartObject();
                            jsonWriter.WritePropertyName("TypeId");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["TypeId"].ToString());
                            jsonWriter.WritePropertyName("TypeName");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["TypeName"].ToString());
                            //如果还存在产品
                            if (num < dtListProduct.Rows.Count)
                            {
                                //下一个元素的开始
                                jsonWriter.WritePropertyName("Product");
                                jsonWriter.WriteStartArray();

                            }

                        }
                    }
                }


                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();

            }
            return json.ToString();
        } 
        #endregion
        #region 查询出展示或者佳作的前8位作品(联合查询),
        /// <summary>
        /// 查询出展示或者佳作的前8位作品(联合查询),
        /// </summary>
        /// <param name="listRecomment">推荐作品</param>
        /// <param name="listIsexcellent">佳作</param>
        /// <returns></returns>
        public bool ListTopProductIsRecommentAndIsexcellent(out List<VProductCraftType> listRecomment, out List<VProductCraftType> listIsexcellent)
        {
            listRecomment = new List<VProductCraftType>();
            listIsexcellent = new List<VProductCraftType>();
            //查询状态
            bool Status = false;
            //获取产品信息(每种显示前8个)
            IEnumerable<VProductCraftType> list = new VProductCraftTypeDAL().ListTopProductIsRecommentAndIsexcellent();
            if (list.Count() > 0)
                Status = true;
            foreach (VProductCraftType product in list)
            {
                //添加到推荐作品list中
                if (product.Isrecomment == "1")
                {
                    listRecomment.Add(product);
                }
                //添加到佳作list中
                if (product.Isexcellent == "1")
                {
                    listIsexcellent.Add(product);
                }
            }
            return Status;

        } 
        #endregion
        #region 查询出展示或者佳作的前8位作品(联合查询),返回json数据格式
        /// <summary>
        /// 查询出展示或者佳作的前8位作品(联合查询),返回json数据格式
        /// </summary>
        /// <returns></returns>
        public string ListTopProductIsRecommentAndIsexcellent()
        {
            //查询状态
            bool Status = false;
            //获取产品信息(每种显示前8个)
            IEnumerable<VProductCraftType> list = new VProductCraftTypeDAL().ListTopProductIsRecommentAndIsexcellent();
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
                if (Status)
                {
                    //IsRecomment   Isexcellent
                    //输出推荐作品
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("IsRecommentData");
                    jsonWriter.WriteStartArray();
                    foreach (VProductCraftType product in list)
                    {
                        if (product.Isrecomment == "1")
                        {
                            jsonWriter.WriteStartObject();
                            jsonWriter.WritePropertyName("ProductId");
                            jsonWriter.WriteValue(product.Id);
                            jsonWriter.WritePropertyName("Name");
                            jsonWriter.WriteValue(product.Name);
                            jsonWriter.WritePropertyName("SimpleName");
                            jsonWriter.WriteValue(product.Simplename);
                            jsonWriter.WritePropertyName("Lsprice");
                            jsonWriter.WriteValue(product.Lsprice);
                            jsonWriter.WritePropertyName("PicturePath");
                            jsonWriter.WriteValue(product.Picturepath);
                            jsonWriter.WritePropertyName("Isrecomment");
                            jsonWriter.WriteValue("Isrecomment");
                            jsonWriter.WriteEndObject();
                        }
                    }
                    jsonWriter.WriteEndArray();
                    jsonWriter.WriteEndObject();
                    //IsRecomment   Isexcellent
                    //输出佳作
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("IsExcellentData");
                    jsonWriter.WriteStartArray();
                    foreach (VProductCraftType product in list)
                    {

                        if (product.Isexcellent == "1")
                        {
                            jsonWriter.WriteStartObject();
                            jsonWriter.WritePropertyName("ProductId");
                            jsonWriter.WriteValue(product.Id);
                            jsonWriter.WritePropertyName("Name");
                            jsonWriter.WriteValue(product.Name);
                            jsonWriter.WritePropertyName("SimpleName");
                            jsonWriter.WriteValue(product.Simplename);
                            jsonWriter.WritePropertyName("Lsprice");
                            jsonWriter.WriteValue(product.Lsprice);
                            jsonWriter.WritePropertyName("PicturePath");
                            jsonWriter.WriteValue(product.Picturepath);
                            jsonWriter.WritePropertyName("IsExcellent");
                            jsonWriter.WriteValue("Isrecomment");
                            jsonWriter.WriteEndObject();
                        }
                    }
                    jsonWriter.WriteEndArray();
                    jsonWriter.WriteEndObject();


                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();
            }
            return json.ToString();

        } 
        #endregion
        #region 根据大师id查找大师的产品信息(每种分别显示前8个)
        /// <summary>
        /// 根据大师id查找大师的产品信息(每种分别显示前8个)
        /// </summary>
        /// <param name="MasterId">大师Id</param>
        /// <returns></returns>
        public string GetMasterWorkForJson(string MasterId)
        {
            //查询状态
            bool Status = false;
            //获取大师的产品信息(每种显示前8个)
            DataTable dtListProduct = new VProductCraftTypeDAL().ListAllByMasterIdToDatable(MasterId);
            //转化为json格式
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);

            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;
                //判断数据读取状态
                if (dtListProduct.Rows.Count > 0)
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
                    //先输出第一个元素的类别信息
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("TypeId");
                    jsonWriter.WriteValue(dtListProduct.Rows[0]["TypeId"].ToString());
                    jsonWriter.WritePropertyName("TypeName");
                    jsonWriter.WriteValue(dtListProduct.Rows[0]["TypeName"].ToString());
                    //第一个元素的开始
                    jsonWriter.WritePropertyName("Product");
                    jsonWriter.WriteStartArray();

                    //按照类别分组
                    //产品计数(一个分组下的产品,从1开始算起)

                    for (int num = 0, numProduct = 1; num < dtListProduct.Rows.Count; num++, numProduct++)
                    {

                        //获取该类别下的分组总个数
                        int Total = Convert.ToInt32(dtListProduct.Rows[num]["total"]);
                        //如果该类别下还存在未输出的产品
                        if (numProduct <= Total)
                        {


                            jsonWriter.WriteStartObject();
                            jsonWriter.WritePropertyName("ProductId");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["Id"].ToString());
                            jsonWriter.WritePropertyName("Name");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["Name"].ToString());
                            jsonWriter.WritePropertyName("SimpleName");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["SimpleName"].ToString());
                            jsonWriter.WritePropertyName("Lsprice");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["Lsprice"].ToString());
                            jsonWriter.WritePropertyName("Picturepath");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["Picturepath"].ToString());
                            jsonWriter.WriteEndObject();

                        }
                        else
                        {
                            //将该类别的产品计数重置为1
                            numProduct = 1;
                            //这里给上一个类别的产品结束标记

                            jsonWriter.WriteEndArray();
                            jsonWriter.WriteEndObject();

                            jsonWriter.WriteStartObject();
                            jsonWriter.WritePropertyName("TypeId");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["TypeId"].ToString());
                            jsonWriter.WritePropertyName("TypeName");
                            jsonWriter.WriteValue(dtListProduct.Rows[num]["TypeName"].ToString());
                            //如果还存在产品
                            if (num < dtListProduct.Rows.Count)
                            {
                                //下一个元素的开始
                                jsonWriter.WritePropertyName("Product");
                                jsonWriter.WriteStartArray();

                            }

                        }
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
