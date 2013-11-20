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
   public partial class WebMessageDAL
    {
       /// <summary>
       /// 总站回复内容
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public bool UpdateComment(WebMessage model)
       {
           string sql = "update WebMessage set huifuContent=@huifuContent,huifuTime=@huifuTime,huifuName=@huifuName where Id=@Id";
        return   SqlHelper.ExecuteNonQuery(sql, (DbParameter)new SqlParameter("huifuContent", model.huifuContent),
               (DbParameter)new SqlParameter("huifuTime", model.huifuTime),
               (DbParameter)new SqlParameter("huifuName", model.HuifuName),
               (DbParameter)new SqlParameter("Id", model.Id));
       
       }
    }
}
