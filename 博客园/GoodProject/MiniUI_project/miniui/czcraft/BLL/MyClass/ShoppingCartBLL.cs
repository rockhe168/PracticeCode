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
    
   public partial class ShoppingCartBLL
    {
        #region 加入购物车
        /// <summary>
        /// 加入购物车
        /// </summary>
        /// <param name="model">ShoppingCart实体</param>
        /// <returns></returns>
        public bool AddNewCart(ShoppingCart model)
        {
            //获取产品信息
            product Info = new productDAL().Get(model.ProductId.Value);
            model.Price = Info.Lsprice;
            if (Info.Belongstype == 1) //供应商是企业
                model.SupperlierId = Info.Companyid.Value;
            else if (Info.Belongstype == 0) //供应商是大师
                model.SupperlierId = Info.Masterid.Value;
            else //供应商是官方
                model.SupperlierId = Info.Companyid.Value;
            model.BelongType = Info.Belongstype;
            model.ProductName = Info.Name;
            //如果库存不足
            if (Info.Num.Value - Info.Soldnum.Value < model.Quantity.Value)
            {
                return false;
            }
            return new ShoppingCartDAL().AddNew(model) > 0;
        }
        
        #endregion
        #region 更新购物车信息
        /// <summary>
        /// 更新购物车信息
        /// </summary>
        /// <param name="model">购物车</param>
        /// <returns></returns>
        public bool UpdateShoppingCart(ShoppingCart model)
        {
            return new ShoppingCartDAL().UpdateCart(model);

        } 
        #endregion
        #region 检验购物车是否已经加入该类产品
        /// <summary>
        /// 检验购物车是否已经加入该类产品,如果加入则不能再次加入
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public bool CheckCartExist(long ProductId)
        {
            int Count = new ShoppingCartDAL().GetCount(" ProductId=" + ProductId);
            return Count == 0;
        } 
        #endregion
        #region 获取会员购物车总价和总数量信息(返回json格式)
        /// <summary>
        /// 获取会员购物车总价和总数量信息(返回json格式)
        /// </summary>
        /// <param name="UserId">会员id</param>
        /// <returns></returns>
        public string GetCartInfo(string UserId)
        {
            //执行状态
            bool Status = false;
            //总数量(购物车)
            int CartCount;
            //总价(购物车)
            float CartSum;
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;
                //判断数据读取状态
                if (new ShoppingCartDAL().GetCartInfo(UserId, out CartSum, out CartCount))
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

                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("CartSum");
                    jsonWriter.WriteValue(CartSum);
                    jsonWriter.WritePropertyName("CartCount");
                    jsonWriter.WriteValue(CartCount);
                    jsonWriter.WriteEndObject();

                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();
            }
            return json.ToString();
        } 
        #endregion
    }
}
