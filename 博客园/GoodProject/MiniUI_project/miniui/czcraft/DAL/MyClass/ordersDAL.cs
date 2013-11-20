using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
namespace czcraft.DAL
{
    public partial class ordersDAL
    {
        #region 获取订单号
        /// <summary>
        /// 订单号前缀
        /// </summary>
        public readonly string PreOrderStr = "CZ";
        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <returns></returns>
        public string GetOrderId()
        {

            string sql = "EXEC  [dbo].[dpPMT_SGetMaintainSeq] " + PreOrderStr;
            return SqlHelper.ExecuteScalar(sql).ToString();
        }
        #endregion
        #region 下单
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="model">tableName实体</param>
        /// <returns>执行状态</returns>
        public int AddOrders(orders model)
        {
            string sql = "insert into orders(OrderId,UserId,ShopDate,OrderDate,ConsigneeRealName,ConsigneeName,ConsigneePhone,ConsigneeProvince,ConsigneeAddress,ConsigneeZip,ConsigneeTel,ConsigneeEmail,TotalPrice,FactPrice,Remark,OrderStatus,PaymentStatus,IsOrderNormal) output inserted.Id values(@OrderId,@UserId,@ShopDate,@OrderDate,@ConsigneeRealName,@ConsigneeName,@ConsigneePhone,@ConsigneeProvince,@ConsigneeAddress,@ConsigneeZip,@ConsigneeTel,@ConsigneeEmail,@TotalPrice,@FactPrice,@Remark,@OrderStatus,@PaymentStatus,@IsOrderNormal)";
            int id = (int)SqlHelper.ExecuteScalar(sql
                        , (DbParameter)new SqlParameter("OrderId", model.OrderId)
                        , (DbParameter)new SqlParameter("UserId", model.UserId)
                        , (DbParameter)new SqlParameter("ShopDate", model.ShopDate)
                        , (DbParameter)new SqlParameter("OrderDate", model.OrderDate)
                        , (DbParameter)new SqlParameter("ConsigneeRealName", model.ConsigneeRealName)
                        , (DbParameter)new SqlParameter("ConsigneeName", model.ConsigneeName)
                        , (DbParameter)new SqlParameter("ConsigneePhone", model.ConsigneePhone)
                        , (DbParameter)new SqlParameter("ConsigneeProvince", model.ConsigneeProvince)
                        , (DbParameter)new SqlParameter("ConsigneeAddress", model.ConsigneeAddress)
                        , (DbParameter)new SqlParameter("ConsigneeZip", model.ConsigneeZip)
                        , (DbParameter)new SqlParameter("ConsigneeTel", model.ConsigneeTel)
                        , (DbParameter)new SqlParameter("ConsigneeEmail", model.ConsigneeEmail)
                        , (DbParameter)new SqlParameter("TotalPrice", model.TotalPrice)
                        , (DbParameter)new SqlParameter("FactPrice", model.FactPrice)
                        , (DbParameter)new SqlParameter("Remark", model.Remark)
                        , (DbParameter)new SqlParameter("OrderStatus", model.OrderStatus)
                        , (DbParameter)new SqlParameter("PaymentStatus", model.PaymentStatus)
                        , (DbParameter)new SqlParameter("IsOrderNormal", model.IsOrderNormal)
            );
            return id;
        }
        #endregion
        #region 下单
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="Info">订单信息</param>
        /// <param name="OrderProductsList">订单产品信息</param>
        /// <returns></returns>
        public bool AddOrders(orders order, IEnumerable<orderproduct> OrderProductsList)
        {
            //执行事务状态
            bool Status = false;
            StringBuilder sb = new StringBuilder();
            SqlHelper.Open();
            //开始事务
            SqlHelper.BeginTrans();
            foreach (orderproduct product in OrderProductsList)
            {
                //插入订单产品表信息
                sb.AppendFormat("insert into orderproduct(OrderId,ProId,ProClass,ProName,ProImg,ProPrice,ProNum,AddTime,ProOtherPara,Specification,Remark) output inserted.Id values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');", product.OrderId, product.ProId, product.ProClass, product.ProName, product.ProImg, product.ProPrice, product.ProNum, product.AddTime, product.ProOtherPara, product.Specification, product.Remark);
                //产品数量修改
                sb.AppendFormat("update product set Num=Num-{0},Soldnum=Soldnum+{0} where Id={1};", product.ProNum, product.ProId);
                //删除购物车中的产品
                sb.AppendFormat("delete from ShoppingCart where ProductId={0} and MemberId={1};", product.ProId, order.UserId);

            }
            //订单信息添加
            sb.AppendFormat("insert into orders(OrderId,UserId,ShopDate,OrderDate,ConsigneeRealName,ConsigneeName,ConsigneePhone,ConsigneeProvince,ConsigneeAddress,ConsigneeZip,ConsigneeTel,ConsigneeEmail,TotalPrice,FactPrice,Remark,OrderStatus,PaymentStatus,IsOrderNormal) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}');", order.OrderId, order.UserId, order.ShopDate, order.OrderDate, order.ConsigneeRealName, order.ConsigneeName, order.ConsigneePhone, order.ConsigneeProvince, order.ConsigneeAddress, order.ConsigneeZip, order.ConsigneeTel, order.ConsigneeEmail, order.TotalPrice, order.FactPrice, order.Remark, order.OrderStatus, order.PaymentStatus, order.IsOrderNormal);
            Status = SqlHelper.ExecuteNonQuery(sb.ToString());
            if (Status)
            {
                SqlHelper.CommitTrans();
                return true;
            }
            else
            {
                SqlHelper.RollbackTrans();
                return false;
            }


        }
        #endregion
        #region 获取订单的发货信息
        /// <summary>
        /// 获取订单的发货信息 
        /// </summary>
        /// <param name="OrderId">订单id</param>
        /// <returns></returns>
        public orders GetOrdersMemberInfo(string OrderId) 
        {
            string sql = "select * from orders where OrderId=@OrderId";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("OrderId", OrderId));
            if (dt.Rows.Count > 0)
                return ToModel(dt.Rows[0]);
            return null;
        }
        #endregion
        #region 取消订单
       /// <summary>
       /// 取消订单
       /// </summary>
       /// <param name="Id"></param>
       /// <param name="PayStatus">支付状态</param>
       /// <param name="OrderStatus">订单状态</param>
       /// <returns></returns>
        public bool CancelOrdersStatus(string Id, string PaymentStatus, string OrderStatus)
        {
           string sql = "update orders set OrderStatus=@OrderStatus , PaymentStatus=@PaymentStatus  where OrderId=@OrderId";
            return SqlHelper.ExecuteNonQuery(sql,
             (DbParameter)new SqlParameter("PaymentStatus", PaymentStatus), 
             (DbParameter)new SqlParameter("OrderStatus", OrderStatus), 
              (DbParameter)new SqlParameter("OrderId", Id));
        
        } 
        #endregion
        #region 修改订单
        /// <summary>
        /// 订单状态修改
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="PaymentStatus">支付状态</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <param name="OgisticsStatus">送货状态</param>
        /// <returns></returns>
        public bool UpdateOrdersStatus(string Id, string PaymentStatus, string OrderStatus, string OgisticsStatus)
        {
            string sql = "update orders set OrderStatus=@OrderStatus , PaymentStatus=@PaymentStatus , OgisticsStatus=@OgisticsStatus  where OrderId=@OrderId";
            return SqlHelper.ExecuteNonQuery(sql,
             (DbParameter)new SqlParameter("PaymentStatus", PaymentStatus), 
             (DbParameter)new SqlParameter("OgisticsStatus", OgisticsStatus),
             (DbParameter)new SqlParameter("OrderStatus", OrderStatus), 
              (DbParameter)new SqlParameter("OrderId", Id));
        
        }
        #endregion
    }
}
