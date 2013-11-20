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
    public partial class VOrdersDAL
    {
        #region 获取订单产品信息(确保已支付)
       /// <summary>
       /// 获取订单产品信息(确保已支付)
       /// </summary>
       /// <param name="Id"></param>
       /// <param name="MemberId">会员id</param>
       /// <param name="OgisticsStatus">送货状态</param>
       /// <returns></returns>
        public VOrders GetOrderInfo(string Id,string MemberId, string OgisticsStatus)
        {
            string sql = "select * from vOrders where Id=@Id and OgisticsStatus=@OgisticsStatus and OrderStatus!=@OrderStatus and UserId=@UserId";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("Id", Id), (DbParameter)new SqlParameter("OgisticsStatus",OgisticsStatus),(DbParameter)new SqlParameter("UserId",MemberId),
                (DbParameter)new SqlParameter("OrderStatus", 3)
                );
            if (dt.Rows.Count > 0)
                return ToModel(dt.Rows[0]);
            return null;

        } 
        #endregion
    }
}
