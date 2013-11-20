using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace czcraft.DAL
{
   public partial class ShoppingCartDAL
    {
        #region 更新购物车信息
        /// <summary>
        /// 更新购物车信息
        /// </summary>
        /// <param name="Cart"></param>
        /// <returns></returns>
        public bool UpdateCart(ShoppingCart Cart)
        {
            string sql = "update ShoppingCart set Quantity=@Quantity where Id=@Id";
            return SqlHelper.ExecuteNonQuery(sql, (DbParameter)new SqlParameter("Quantity", Cart.Quantity), (DbParameter)new SqlParameter("Id", Cart.Id));

        } 
        #endregion
        #region 查询购物车的总价和总数量
        /// <summary>
        /// 查询购物车的总价和总数量
        /// </summary>
        /// <param name="UserId">用户id</param>
        /// <param name="CartSum">购物车总价</param>
        /// <param name="CartCount">购物车总数量</param>
        /// <returns></returns>
        public bool GetCartInfo(string UserId, out  float CartSum, out int CartCount)
        {
            CartCount = 0;
            CartSum = 0;
            DataTable dt = SqlHelper.ExecuteDataTable("select Sum(Quantity*Price) as CartSum,Count(Id) as CartCount  from ShoppingCart where MemberId=@MemberId ", (DbParameter)new SqlParameter("MemberId", UserId));
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                CartSum = Convert.ToSingle(dr["CartSum"]);
                CartCount = Convert.ToInt32(dr["CartCount"]);
                return true;
            }
            return false;
        } 
        #endregion
    }
}
