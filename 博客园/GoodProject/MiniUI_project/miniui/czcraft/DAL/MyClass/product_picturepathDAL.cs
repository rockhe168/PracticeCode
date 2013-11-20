using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
namespace czcraft.DAL
{
    public partial class product_picturepathDAL
    {
        #region 获取产品图片信息
        /// <summary>
        /// 获取产品图片信息
        /// </summary>
        /// <param name="ProductId">产品id</param>
        /// <returns></returns>
        public IEnumerable<product_picturepath> GetProductPic(string ProductId)
        {
            List<product_picturepath> list = new List<product_picturepath>();
            string sql = "select * from product_picturepath where Productid=@Productid";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("Productid", ProductId));
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;

        } 
        #endregion
        #region 添加多张图片
        /// <summary>
        /// 添加多张图片
        /// </summary>
        /// <param name="PicList">图片数组,用,隔开</param>
        /// <returns></returns>
        public bool AddMutiPic(string ProductId, string PicList)
        {
            StringBuilder sb = new StringBuilder();
            string[] picLists = PicList.Split(',');
            bool Status = false;
            foreach (string pic in picLists)
            {
                sb.Append("insert into product_picturepath(Productid,Picturepath) values(" + ProductId + ",'" + pic + "');");
            }
            SqlHelper.Open();
            //开始事务
            SqlHelper.BeginTrans();
            Status = SqlHelper.ExecuteNonQuery(sb.ToString());
            if (Status)
            {
                //提交事务
                SqlHelper.CommitTrans();
                SqlHelper.Close();
                return true;
            }
            else
            {
                SqlHelper.RollbackTrans();
                SqlHelper.Close();
                return false;
            }
        } 
        #endregion
        #region 获取多张图片信息
        /// <summary>
        /// 获取多张图片信息
        /// </summary>
        /// <param name="strIDs"></param>
        /// <returns></returns>
        public DataTable GetMoreOtherProductPicPath(string strIDs)
        {
            string sql = "select Picturepath from product_picturepath  where Id in (" + strIDs + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return dt;
        }
        /// <summary>
        /// 通过单个产品id获取其他图片
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public DataTable GetOtherProductPicByProductId(string ProductId)
        {
            string sql = "select Picturepath from product_picturepath where Productid=@Productid";
            DataTable dt = SqlHelper.ExecuteDataTable(sql,(DbParameter)new SqlParameter("Productid",ProductId));
            return dt;
        }
        /// <summary>
        /// 通过多个产品id获取其他图片
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public DataTable GetOtherProductPicByMoreProductIds(string ProductId)
        {
            string sql = "select Picturepath from product_picturepath where Productid in (" + ProductId + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            return dt;
        }
        #endregion
    }
}
