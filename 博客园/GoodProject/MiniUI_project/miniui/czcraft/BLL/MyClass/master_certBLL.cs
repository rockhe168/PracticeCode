using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using czcraft.BLL;
using System.Data;
namespace czcraft.BLL
{
    public partial class master_certBLL
    {
        #region 删除图片
        #region 获取大师荣誉图片
        /// <summary>
        /// 获取大师荣誉图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMasterCertPath(long id)
        {
            master_certDAL dal = new master_certDAL();
            master_cert pic = dal.Get(id);
            return pic.Picpath;
        }

        #endregion
        #region 删除多张大师荣誉图片
        /// <summary>
        /// 删除多张大师荣誉图片
        /// </summary>
        public void DeleteMoreMasterCertPic(DataTable dt)
        {
            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetMasterCert, dr["Picpath"].ToString());
            }

        }
        #endregion
        #endregion
        #region 删除master_cert
        /// <summary>
        /// 删除master_cert
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {
            //获取大师荣誉图片
            string Picturepath = GetMasterCertPath(id);
            master_certDAL dal = new master_certDAL();
            bool Status = dal.Delete(id);
            //如果执行成功,则删除图片
            if (Status)
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetMasterCert, Picturepath);
            return Status;

        }
        #endregion
        #region 删除master_cert
        /// <summary>
        /// 删除master_cert
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            DataTable dtMasterCert = new master_certDAL().GetMoreMasterCertPath(strID);
            bool Status = new master_certDAL().DeleteMoreID(strID);
            if (Status)
                DeleteMoreMasterCertPic(dtMasterCert);
            return Status;

        }
        #endregion
    }
}
