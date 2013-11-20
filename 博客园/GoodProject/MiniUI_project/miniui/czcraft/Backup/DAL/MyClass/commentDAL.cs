using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Data.Common;
using System.Data.SqlClient;
namespace czcraft.DAL
{
    public partial class commentDAL
    {
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="Comment">评论信息</param>
        /// <param name="OrderId">订单号</param>
        /// <returns></returns>
        public bool AddComment(comment model,string OrderId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update orders set OrdersStatus='3' where OrderId=@OrderId;");
            sql.Append("insert into comment(Content,Time,Productid,huifuContent,Grade,MemberId) output inserted.Id values(@Content,@Time,@Productid,@huifuContent,@Grade,@MemberId)");
            SqlHelper.Open();
            SqlHelper.BeginTrans();
          bool Status=SqlHelper.ExecuteNonQuery(sql.ToString ()
                        , (DbParameter)new SqlParameter("Content", model.Content)
                        , (DbParameter)new SqlParameter("Time", model.Time)
                        , (DbParameter)new SqlParameter("Productid", model.Productid)
                        , (DbParameter)new SqlParameter("huifuContent", model.huifuContent)
                        , (DbParameter)new SqlParameter("Grade", model.Grade)
                        , (DbParameter)new SqlParameter("MemberId", model.MemberId)
                        , (DbParameter)new SqlParameter("OrderId", OrderId)
            );
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
    }
}
