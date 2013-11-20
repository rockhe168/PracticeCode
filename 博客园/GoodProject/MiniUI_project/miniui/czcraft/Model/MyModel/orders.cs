using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace czcraft.Model
{
    public partial class orders
    {
        /// <summary>
        /// 支付状态
        /// </summary>
        public enum ePaymentStatus
        {
            /// <summary>
            /// 等待付款
            /// </summary>
            WaitPay = 0,
            /// <summary>
            /// 已处理
            /// </summary>
            IsDeal = 1,
            /// <summary>
            /// 已付款
            /// </summary>
            IsPay = 2,
            /// <summary>
            /// 已退款
            /// </summary>
            IsReturnPay = 3,
            /// <summary>
            /// 已拒绝
            /// </summary>
            IsRefuse = 4,
            /// <summary>
            /// 已取消
            /// </summary>
            IsCancel = 5

        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public enum eOrderStatus
        {
            /// <summary>
            /// 未付款
            /// </summary>
            NotPay = 0,
            /// <summary>
            /// 已付款
            /// </summary>
            IsPay = 1,
            /// <summary>
            /// 已发货
            /// </summary>
            IsSendProduct = 2,
            /// <summary>
            /// 交易完成
            /// </summary>
            IsDone = 3,
            /// <summary>
            /// 已退款
            /// </summary>
            IsReturnPay = 4
        }
        /// <summary>
        /// 送货状态
        /// </summary>
        public enum eOgisticsStatus
        {
            /// <summary>
            /// 等待发货
            /// </summary>
            WaitSendProduct = 0,
            /// <summary>
            /// 发货中
            /// </summary>
            SendingProduct = 1,
            /// <summary>
            /// 等待签收
            /// </summary>
            WaitSign = 2,
            /// <summary>
            /// 已签收
            /// </summary>
            IsSign = 3
        }

    }
}
