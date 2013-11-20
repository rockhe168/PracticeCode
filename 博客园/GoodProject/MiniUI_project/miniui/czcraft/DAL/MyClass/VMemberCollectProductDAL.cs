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
    public partial class VMemberCollectProductDAL
    {

        #region 获得收藏数据
        /// <summary>
        /// 获得收藏数据
        /// </summary>
        /// <param name="IsToday">是否是今天的收藏数据</param>
        /// <param name="MemberId">会员id</param>
        /// <returns></returns>
        public IEnumerable<VMemberCollectProduct> GetCollectProductsByToday(bool IsToday, string MemberId)
        {
            string sql = "select * from VMemberCollectProduct where MemberId=@MemberId ";
            //如果今日收藏
            if (IsToday)
                sql += " and  datediff(day ,AddTime ,getdate()) <=1";

            List<VMemberCollectProduct> list = new List<VMemberCollectProduct>();
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("MemberId", MemberId));
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;


        } 
        #endregion



    }
}
