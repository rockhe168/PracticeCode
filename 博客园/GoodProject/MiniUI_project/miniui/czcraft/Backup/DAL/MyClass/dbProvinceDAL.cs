using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace czcraft.DAL
{
   public partial class dbProvinceDAL
    {
        #region 根据父级id获取下级
        /// <summary>
        /// 根据父级id获取下级
        /// </summary>
        /// <param name="id">父级id</param>
        /// <returns></returns>
        public IEnumerable<dbProvince> GetArea(string id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from dbProvince where parentid=@parentid", (DbParameter)new SqlParameter("parentid", id));
            List<dbProvince> list = new List<dbProvince>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;
        } 
        #endregion
    }
}
