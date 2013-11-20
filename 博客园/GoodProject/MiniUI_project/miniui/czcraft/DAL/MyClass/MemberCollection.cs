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
  public partial  class MemberCollectionDAL
    {
        #region 更新收藏夹信息
        /// <summary>
        /// 更新收藏夹信息
        /// </summary>
        /// <param name="Cart"></param>
        /// <returns></returns>
      public bool UpdateCollection(MemberCollection model)
        {
            string sql = "update MemberCollection set AddTime=getdate() where ProductId=@ProductId and MemberId=@MemberId";
            return SqlHelper.ExecuteNonQuery(sql, (DbParameter)new SqlParameter("ProductId", model.ProductId), (DbParameter)new SqlParameter("MemberId", model.MemberId));

        }
        #endregion
    }
}
