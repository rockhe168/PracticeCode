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
   public partial class master_certDAL
    {
        #region 通过MasterId获取所有荣誉证书
        /// <summary>
        /// 通过MasterId获取所有荣誉证书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<master_cert> ListAllById(string MasterId)
        {
            List<master_cert> list = new List<master_cert>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from master_cert where Masterid=@Masterid", (DbParameter)new SqlParameter("Masterid", MasterId));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        }
        #endregion
        #region 获取多张大师荣誉证书信息
        /// <summary>
        /// 获取多张大师荣誉证书信息
        /// </summary>
        /// <param name="strIDs"></param>
        /// <returns></returns>
        public DataTable GetMoreMasterCertPath(string strIDs)
        {
            string sql = "select Picpath from master_cert where Id in (" + strIDs + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return dt;
        }
        /// <summary>
        /// 通过单个MasterId获取大师荣誉证书图片
        /// </summary>
        /// <param name="MasterId"></param>
        /// <returns></returns>
        public DataTable GetMasterCertByMasterId(string MasterId)
        {
            string sql = "select Picpath from master_cert where Masterid=@Masterid";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("Masterid", MasterId));
            return dt;
        }
        /// <summary>
        /// 通过多个MasterId获取其他图片
        /// </summary>
        /// <param name="MasterId"></param>
        /// <returns></returns>
        public DataTable GetMasterCertByMoreMasterIds(string MasterId)
        {
            string sql = "select Picpath from master_cert where Masterid in (" + MasterId + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return dt;
        }
        #endregion
        #region 删除master_cert
        /// <summary>
        /// 删除master_cert
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {
            return SqlHelper.ExecuteNonQuery("delete from master_cert where id=@id",
                            (DbParameter)new SqlParameter("id", id));
        }
        #endregion
        #region  删除master_cert
        /// <summary>
        /// 删除master_cert
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            return SqlHelper.ExecuteNonQuery("delete from master_cert where id in (" + strID + ")");
        }
        #endregion
    }
}
