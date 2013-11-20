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
   public partial class company_typeDAL
    {
        #region 获取企业类别信息,通过企业id
        /// <summary>
        /// 获取企业类别信息,通过企业id
        /// </summary>
        /// <param name="CompanyId">企业id</param>
        /// <param name="TypeName">企业类别名称(数组)</param>
        /// <returns></returns>
        public string GetByCompanyId(int CompanyId, out string TypeName)
        {
            string sql = "select * from VCompanyType where Companyid=@CompanyId";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("CompanyId", CompanyId));
            string Types = "";
            TypeName = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                Types += dt.Rows[i]["Typeid"].ToString();
                TypeName += dt.Rows[i]["TypeName"].ToString();
                //如果不是最后一个
                if (i < dt.Rows.Count - 1)
                {
                    Types += ",";
                    TypeName += ",";
                }


            }

            return Types;
        }
        #endregion

    }
}
