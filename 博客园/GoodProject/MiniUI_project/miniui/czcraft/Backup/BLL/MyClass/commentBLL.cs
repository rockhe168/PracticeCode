using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
namespace czcraft.BLL
{
   public partial class commentBLL
    {

        #region 添加评论
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="Comment">评论实体</param>
        /// <param name="orderproductId">订单产品id</param>
        /// <returns></returns>
        public bool AddComment(comment Comment, string orderproductId)
        {
            VOrders VOrder = new VOrdersDAL().GetOrderInfo(orderproductId, Comment.MemberId.Value.ToString(), orders.eOgisticsStatus.IsSign.GetHashCode().ToString());
            if (VOrder.Id.HasValue)
            {
                //添加产品
                Comment.Productid = Convert.ToInt64(VOrder.ProId);
                return new commentDAL().AddComment(Comment, VOrder.OrderId);
            }
            return false;
        } 
        #endregion
    }
}
