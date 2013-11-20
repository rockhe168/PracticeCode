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
   public partial class company_picBLL
    {
        #region 获取企业图片
        /// <summary>
        /// 获取企业图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCompanyPicPath(int id)
        {
            company_picDAL dal = new company_picDAL();
            company_pic pic = dal.Get(id);
            return pic.Picpath;
        } 
        #endregion
        #region 删除多张企业图片
        /// <summary>
        /// 删除多张企业图片
        /// </summary>
        /// <param name="dt"></param>
        public void DeleteMoreCompanyPic(DataTable dt)
        {
            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetCompanyPic, dr["Picpath"].ToString());
            }

        } 
        #endregion
        #region  删除company_pic
        /// <summary>
        /// 删除company_pic
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {    //获取产品图片
            string Picturepath = GetCompanyPicPath(id);
            company_picDAL dal = new company_picDAL();
            bool Status = dal.Delete(id);
            //如果执行成功,则删除图片
            if (Status)
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetOtherProductPic, Picturepath);
            return Status;
        } 
        #endregion
        #region 删除company_pic
        /// <summary>
        /// 删除company_pic
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            //获取所有企业图片
            DataTable dtProductPic = new company_picDAL().GetMoreCompanyPicPath(strID);

            bool Status = new company_picDAL().DeleteMoreID(strID);
            if (Status)
                DeleteMoreCompanyPic(dtProductPic);
            return Status;
         
        } 
        #endregion
    }
}
