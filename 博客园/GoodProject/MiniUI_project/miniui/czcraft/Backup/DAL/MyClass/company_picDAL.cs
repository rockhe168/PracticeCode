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
   public partial class company_picDAL
    {
        #region 根据Companyid获取所有信息
        /// <summary>
        /// 根据Companyid获取所有信息
        /// </summary>
        /// <param name="Companyid"></param>
        /// <returns></returns>
        public IEnumerable<company_pic> ListAllById(string Companyid)
        {
            List<company_pic> list = new List<company_pic>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from company_pic where Companyid=@Companyid", (DbParameter)new SqlParameter("Companyid", Companyid));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        } 
        #endregion
        #region 获取多张企业图片信息
        /// <summary>
        /// 获取多张企业图片信息
        /// </summary>
        /// <param name="strIDs"></param>
        /// <returns></returns>
        public DataTable GetMoreCompanyPicPath(string strIDs)
        {
            string sql = "select Picpath from company_pic where Id in (" + strIDs + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return dt;
        }
        /// <summary>
        /// 通过单个CompanyId获取其他图片
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public DataTable GetCompanyPicByCompanyId(string CompanyId)
        {
            string sql = "select Picpath from company_pic where Companyid=@Companyid";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("Companyid", CompanyId));
            return dt;
        }
        /// <summary>
        /// 通过多个CompanyId获取其他图片
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public DataTable GetCompanyPicByMoreCompanyIds(string CompanyId)
        {
            string sql = "select Picpath from company_pic where Companyid in (" + CompanyId + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return dt;
        }
        #endregion
    }
}
