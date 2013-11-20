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
   public partial class company_certDAL
    {
        #region 通过CompanyId获取所有荣誉证书
        /// <summary>
        /// 通过CompanyId获取所有荣誉证书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<company_cert> ListAllById(string CompanyId)
        {
            List<company_cert> list = new List<company_cert>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from company_cert where Companyid=@Companyid", (DbParameter)new SqlParameter("Companyid", CompanyId));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        } 
        #endregion
        #region 获取多张企业荣誉证书信息
        /// <summary>
        /// 获取多张企业荣誉证书信息
        /// </summary>
        /// <param name="strIDs"></param>
        /// <returns></returns>
        public DataTable GetMoreCompanyCertPath(string strIDs)
        {
            string sql = "select Picpath from company_cert where Id in (" + strIDs + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return dt;
        }
        /// <summary>
        /// 通过单个CompanyId获取企业荣誉证书图片
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public DataTable GetCompanyCertByCompanyId(string CompanyId)
        {
            string sql = "select Picpath from company_cert where Companyid=@Companyid";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("Companyid", CompanyId));
            return dt;
        }
        /// <summary>
        /// 通过多个CompanyId获取其他图片
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public DataTable GetCompanyCertByMoreCompanyIds(string CompanyId)
        {
            string sql = "select Picpath from company_cert where Companyid in (" + CompanyId + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return dt;
        }
        #endregion
        #region 删除company_cert
        /// <summary>
        /// 删除company_cert
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {
            return SqlHelper.ExecuteNonQuery("delete from company_cert where id=@id",
                            (DbParameter)new SqlParameter("id", id));
        } 
        #endregion
        #region  删除company_cert
        /// <summary>
        /// 删除company_cert
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            return SqlHelper.ExecuteNonQuery("delete from company_cert where id in (" + strID + ")");
        } 
        #endregion
    }
}
