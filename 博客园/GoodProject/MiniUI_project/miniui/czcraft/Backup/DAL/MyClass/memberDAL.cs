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
    /// <summary>
    /// 
    /// </summary>
    public partial class memberDAL
    {
        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info">会员model</param>
        /// <returns></returns>
        public bool MemberLogin(member info)
        {
            string sql = "select count(*) from member where username=@username and password=@password and states='1'";
            return SqlHelper.ExecuteSelectFirstNum(sql, (DbParameter)new SqlParameter("username", info.username), (DbParameter)new SqlParameter("password", info.password)) > 0;
        } 
        #endregion
        #region 根据用户名和随即验证码查找用户激活帐号的过期时间
        /// <summary>
        /// 根据用户名和随即验证码查找用户激活帐号的过期时间
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="VCode">激活码</param>
        /// <returns></returns>
        public DateTime GetMemberVTime(string UserName, string VCode)
        {
            string sql = "select VTime from member where username=@username and VCode=@VCode";
            return (DateTime)SqlHelper.ExecuteScalar(sql, (DbParameter)new SqlParameter("username", UserName), (DbParameter)new SqlParameter("VCode", VCode));
        } 
        #endregion
        #region 激活帐号
        /// <summary>
        /// 激活帐号
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public bool ActivationMemberStatus(string UserName)
        {
            string sql = "update member set states='1' where username=@username ";
            return SqlHelper.ExecuteNonQuery(sql, (DbParameter)new SqlParameter("username", UserName));

        } 
        #endregion
        #region 根据用户名获取用户信息
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public member GetMemberInfo(string UserName)
        {
            string sql = "select * from member where username=@username";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("username", UserName));
            if (dt.Rows.Count > 0)
                return ToModel(dt.Rows[0]);
            else
                return null;
        } 
        #endregion
        #region 更新member实体
        /// <summary>
        /// 更新member实体
        /// </summary>
        /// <param name="model">member实体</param>
        /// <param name="IsUserNameUpdate">是否采用用户名更新</param>
        /// <returns></returns>
        public bool Update(member model, bool IsUserNameUpdate)
        {
            //普通更新方式
            if (!IsUserNameUpdate)
                return Update(model);

            string sql = "update member set Sex=@Sex,nation=@nation,mobilephone=@mobilephone,Telephone=@Telephone,qq=@qq,Zipcode=@Zipcode,Address=@Address where username=@username";
            return SqlHelper.ExecuteNonQuery(sql

                            , (DbParameter)new SqlParameter("username", model.username)

                            , (DbParameter)new SqlParameter("Sex", model.Sex)
                            , (DbParameter)new SqlParameter("nation", model.nation)
                            , (DbParameter)new SqlParameter("mobilephone", model.mobilephone)
                            , (DbParameter)new SqlParameter("Telephone", model.Telephone)
                //, (DbParameter)new SqlParameter("Email", model.Email)
                            , (DbParameter)new SqlParameter("qq", model.qq)
                            , (DbParameter)new SqlParameter("Zipcode", model.Zipcode)
                            , (DbParameter)new SqlParameter("Address", model.Address)

                );
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

            string sql = "update member set password=@password from member where username=@username and states='1'";
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
            string sql = "select password from member where username=@username and states='1'";
            return (string)SqlHelper.ExecuteScalar(sql, (DbParameter)new SqlParameter("username", UserName));
        } 
        #endregion
        #region 删除
        /// <summary>
        /// 删除member
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {
            bool status = false;
            SqlHelper.Open();
            SqlHelper.BeginTrans();

            status=SqlHelper.ExecuteNonQuery("delete from MemberCollection where MemberId=@id;delete from ShoppingCart where MemberId=@id;delete from comment where MemberId=@id; delete from member where id=@id",
                            (DbParameter)new SqlParameter("id", id));
            if (status)
            {
                SqlHelper.CommitTrans();
                return true;
            }
            else
            {
                SqlHelper.RollbackTrans();
                return false;
            }
        }
        /// <summary>
        /// 删除member
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            bool status = false;
            string[] IDs = strID.Split(',');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < IDs.Length; i++)
            {
                sb.Append("delete from MemberCollection where MemberId=" + IDs[i] + ";");
                sb.Append("delete from ShoppingCart where MemberId=" + IDs[i] + ";");
                sb.Append("delete from comment where MemberId=" + IDs[i] + ";");
               
            }
            sb.Append("delete from member where id in (" + strID + ")");
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
    }
}
