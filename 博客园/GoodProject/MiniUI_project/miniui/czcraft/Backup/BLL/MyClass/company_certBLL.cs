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
    public partial class company_certBLL
    {
        #region 删除图片
        #region 获取企业荣誉图片
        /// <summary>
        /// 获取企业荣誉图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCompanyCertPath(long id)
        {
            company_certDAL dal = new company_certDAL();
            company_cert pic = dal.Get(id);
            return pic.Picpath;
        }

        #endregion
        #region 删除多张企业荣誉图片
        /// <summary>
        /// 删除多张企业荣誉图片
        /// </summary>
        public void DeleteMoreCompanyCertPic(DataTable dt)
        {
            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetCompanyCert, dr["Picpath"].ToString());
            }

        } 
        #endregion
        #endregion
        #region 删除company_cert
        /// <summary>
        /// 删除company_cert
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        { 
            //获取企业荣誉图片
            string Picturepath = GetCompanyCertPath(id);
            company_certDAL dal = new company_certDAL();
            bool Status = dal.Delete(id);
            //如果执行成功,则删除图片
            if (Status)
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetCompanyCert, Picturepath);
            return Status;
           
        } 
        #endregion
        #region 删除company_cert
        /// <summary>
        /// 删除company_cert
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            DataTable dtCompanyCert = new company_certDAL().GetMoreCompanyCertPath(strID);
            bool Status = new company_certDAL().DeleteMoreID(strID);
            if (Status)
                DeleteMoreCompanyCertPic(dtCompanyCert);
            return Status;
          
        } 
        #endregion
    }
}
