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
   public partial class companyDAL
    {
        #region 更新(企业空间自己的部分更新)
        /// <summary>
        /// 更新(企业空间自己的部分更新)
        /// </summary>
        /// <param name="model">企业信息</param>
        /// <param name="CraftType">企业类别信息</param>
        /// <returns></returns>
        public bool UpdateCompanyForZone(company model, string CraftType)
        {
            SqlHelper.Open();
            SqlHelper.BeginTrans();
            StringBuilder sql = new StringBuilder("update company set Name=@Name,Representative=@Representative,Fac=@Fac,Zipcode=@Zipcode,qq=@qq,Telephone=@Telephone,mobilephone=@mobilephone,Email=@Email,Address=@Address,Award=@Award,Introduction=@Introduction,Picturepath=@Picturepath where Id=@Id;");
            //删除企业类别
            sql.Append("delete from company_type where CompanyId=@Id;");
            string[] Types = CraftType.Split(',');
            //循环插入企业类别信息
            foreach (string str in Types)
            {
                sql.Append("insert into company_type(CompanyId,Typeid) values(" + model.Id + "," + str + ");");
            }
            bool Status = SqlHelper.ExecuteNonQuery(sql.ToString()
                         , (DbParameter)new SqlParameter("Id", model.Id)
                        , (DbParameter)new SqlParameter("Name", model.Name)
                         , (DbParameter)new SqlParameter("Introduction", model.Introduction)
                        , (DbParameter)new SqlParameter("Picturepath", model.Picturepath)
                         , (DbParameter)new SqlParameter("Representative", model.Representative)
                         , (DbParameter)new SqlParameter("mobilephone", model.mobilephone)
                         , (DbParameter)new SqlParameter("Telephone", model.Telephone)
                         , (DbParameter)new SqlParameter("Email", model.Email)
                         , (DbParameter)new SqlParameter("QQ", model.QQ)
                         , (DbParameter)new SqlParameter("Zipcode", model.Zipcode)
                         , (DbParameter)new SqlParameter("Address", model.Address)
                         , (DbParameter)new SqlParameter("Fac", model.Fac)
                         , (DbParameter)new SqlParameter("Award", model.Award)
                        
             );
            //如果执行成功!
            if (Status)
            {
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
        #region 更新企业排名信息
        /// <summary>
        /// 更新企业排名信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCompanyRank(company model)
        {

            string sql = "update company set rank=@rank where Id=@Id";
            return SqlHelper.ExecuteNonQuery(sql
                            , (DbParameter)new SqlParameter("Id", model.Id)
                            , (DbParameter)new SqlParameter("rank", model.rank)
                );

        } 
        #endregion
        #region 获取前n条企业
        /// <summary>
        /// 获取前n条企业
        /// </summary>
        /// <param name="TopNum">前n</param>
        /// <returns></returns>
        public IEnumerable<company> GetTopCompany(int TopNum)
        {
            string sql = "select top (" + TopNum + ") * from company where state='1' and state1='1'  and Isshow='1' order by rank desc";
            List<company> list = new List<company>();
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;
        } 
        #endregion
        #region 根据排名寻找企业
        /// <summary>
        /// 根据排名寻找企业
        /// </summary>
        /// <param name="TopNum">排名</param>
        /// <returns></returns>
        public IEnumerable<company> GetTopCompanyByRank(int TopNum)
        {
            string sql = "select top (" + TopNum + ") * from company order by rank desc";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            List<company> list = new List<company>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;
        } 
        #endregion
        #region 用户登录

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info">会员model</param>
        /// <returns></returns>
        public bool CompanyLogin(company info)
        {
            string sql = "select count(*) from company where username=@username and password=@password and state='1'";
            return SqlHelper.ExecuteSelectFirstNum(sql, (DbParameter)new SqlParameter("username", info.Username), (DbParameter)new SqlParameter("password", info.Password)) > 0;
        }
        #endregion
        #region 根据用户名和随即验证码查找用户激活帐号的过期时间
        /// <summary>
        /// 根据用户名和随即验证码查找用户激活帐号的过期时间
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="VCode">激活码</param>
        /// <returns></returns>
        public DateTime GetCompanyVTime(string UserName, string VCode)
        {
            string sql = "select VTime from company where username=@username and VCode=@VCode";
            return (DateTime)SqlHelper.ExecuteScalar(sql, (DbParameter)new SqlParameter("username", UserName), (DbParameter)new SqlParameter("VCode", VCode));
        }
        #endregion
        #region 激活帐号
        /// <summary>
        /// 激活帐号
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public bool ActivationCompanyStatus(string UserName)
        {
            string sql = "update company set state='1' where username=@username ";
            return SqlHelper.ExecuteNonQuery(sql, (DbParameter)new SqlParameter("username", UserName));

        }
        #endregion
        #region 根据用户名获取用户信息
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public company GetCompanyInfo(string UserName)
        {
            string sql = "select * from company where username=@username";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("username", UserName));
            if (dt.Rows.Count > 0)
                return ToModel(dt.Rows[0]);
            else
                return null;
        }
        #endregion
        #region 修改密码

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public bool UpdatePassword(string UserName, string Password)
        {

            string sql = "update company set password=@password from company where username=@username and state='1'";
            return SqlHelper.ExecuteNonQuery(sql, (DbParameter)new SqlParameter("username", UserName), (DbParameter)new SqlParameter("password", Password));
        }
        #endregion
        #region 获取用户密码
        /// <summary>
        /// 获取用户密码
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public string GetPassword(string UserName)
        {
            string sql = "select password from company where username=@username and state='1'";
            return (string)SqlHelper.ExecuteScalar(sql, (DbParameter)new SqlParameter("username", UserName));
        }

        #endregion
        #region 删除
       /// <summary>
       /// 删除company的sql语句生成
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        internal string GetCompanyDeleteSql(int id)
        {
            string sql = "select Id from product where  Companyid=" + id;
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            StringBuilder sb = new StringBuilder();
            productDAL dal = new productDAL();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(dal.GetDeleteProductSqlString(dr["Id"].ToString()));
            }
            sb.Append(";delete from company_pic where Companyid=" + id);
            sb.Append(";delete from company_cert where  Companyid=" + id);
            sb.Append(";delete from company_type where  Companyid=" + id);
            sb.Append(";delete from company where Id="+id+";");
            return sb.ToString(); 
        }
        /// <summary>
        /// 删除company
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {
            bool status = false;
            SqlHelper.Open();
            SqlHelper.BeginTrans();
            if (SqlHelper.ExecuteNonQuery(GetCompanyDeleteSql(id)))
            {
                status = true;
                SqlHelper.CommitTrans();
            }
            else
            {
                status = false;
                SqlHelper.RollbackTrans();
            }

            return status;
        }
       /// <summary>
       /// 通过多个company的id获取删除产品Sql信息
       /// </summary>
       /// <param name="strID"></param>
       /// <returns></returns>
 
        internal string GetDeleteSqlByMoreCompany(string strID)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select Id from product where  Companyid in (" + strID + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            productDAL dal = new productDAL();
           foreach(DataRow dr in dt.Rows)
            sb.Append(dal.GetDeleteProductSqlString(dr["Id"].ToString ()));
           return sb.ToString();
       
        }
        /// <summary>
        /// 删除company
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
               bool status = false;
            string[] IDs = strID.Split(',');
            StringBuilder sb = new StringBuilder();
           sb.Append(GetDeleteSqlByMoreCompany(strID));
            for (int i = 0; i < IDs.Length; i++)
            {
                sb.Append(";delete from company_pic where Companyid=" + IDs[i]);
                sb.Append(";delete from company_cert where  Companyid=" + IDs[i]);
                sb.Append(";delete from company_type where  Companyid=" + IDs[i]);
            }
            sb.Append(";delete from company where Id in (" + strID + ")");
            SqlHelper.Open();
            SqlHelper.BeginTrans();
            if (SqlHelper.ExecuteNonQuery(sb.ToString()))
            {
                status = true;
                SqlHelper.CommitTrans();
            }
            else
            {
                status = false;
                SqlHelper.RollbackTrans();
            } 

            return status;
        }
        #endregion
        #region 获得所有的产品图片
      
        /// <summary>
        /// 获得所有的企业主图片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable GetCompanyMainPic(string Ids)
        {
            string sql = "select Picturepath from Company where Id in(" + Ids + ")";
            return SqlHelper.ExecuteDataTable(sql);
        }
        #endregion
        #region 获得所有企业id和图片信息
        /// <summary>
        /// 获得所有企业id和图片信息
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public DataTable GetAllCompanyByCraftType(string TypeId)
        {
            string sql = "select Companyid from company_type where Typeid in (" + TypeId + ")";
            return SqlHelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取多个的企业主图片
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public DataTable GetAllCompanyMainPic(string Ids)
        {
            string sql = "select Picturepath from company where Id in (" + Ids + ")";
            return SqlHelper.ExecuteDataTable(sql);
        }
        #endregion
    }
}
