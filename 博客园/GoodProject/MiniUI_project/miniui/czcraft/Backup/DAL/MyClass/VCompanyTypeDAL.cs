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
  public partial  class VCompanyTypeDAL
    {
        #region 根据id获取所有信息
        /// <summary>
        /// 根据id获取所有信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<VCompanyType> ListAllById(string id)
        {
            List<VCompanyType> list = new List<VCompanyType>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from VCompanyType where Companyid=@CompanyId", (DbParameter)new SqlParameter("CompanyId", id));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        } 
        #endregion
    }
}
