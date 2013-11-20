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
   public partial class VMasterTypeDAL
    {
        #region 根据id获取所有信息
        /// <summary>
        /// 根据id获取所有信息
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public IEnumerable<VMasterType> ListAllById(string id)
        {
            List<VMasterType> list = new List<VMasterType>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from VMasterType where MasterId=@MasterId", (DbParameter)new SqlParameter("MasterId", id));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        } 
        #endregion
    }
}
