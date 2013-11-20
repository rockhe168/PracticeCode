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
   public partial class masterDAL
    {
        #region 更新大师排名信息
        /// <summary>
        /// 更新大师排名信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMasterRank(master model)
        {

            string sql = "update master set rank=@rank where Id=@Id";
            return SqlHelper.ExecuteNonQuery(sql
                            , (DbParameter)new SqlParameter("Id", model.Id)
                            , (DbParameter)new SqlParameter("rank", model.rank)
                );

        } 
        #endregion
        #region 更新(大师空间自己的部分更新)
        /// <summary>
        /// 更新(大师空间自己的部分更新)
        /// </summary>
        /// <param name="model">大师信息</param>
        /// <param name="CraftType">大师类别信息</param>
        /// <returns></returns>
        public bool UpdateMasterForZone(master model, string CraftType)
        {
            SqlHelper.Open();
            SqlHelper.BeginTrans();
            StringBuilder sql = new StringBuilder("update master set Name=@Name,Sex=@Sex,Nation=@Nation,Birthday=@Birthday,Zipcode=@Zipcode,qq=@qq,Telephone=@Telephone,mobilephone=@mobilephone,Email=@Email,Address=@Address,appreciation=@appreciation,Reward=@Reward,Introduction=@Introduction,Picturepath=@Picturepath where Id=@Id;");
            //删除大师类别
            sql.Append("delete from master_type where MasterId=@Id;");
            string[] Types = CraftType.Split(',');
            //循环插入大师类别信息
            foreach (string str in Types)
            {
                sql.Append("insert into master_type(MasterId,Typeid) values(" + model.Id + "," + str + ");");
            }
            bool Status = SqlHelper.ExecuteNonQuery(sql.ToString()
                         , (DbParameter)new SqlParameter("Id", model.Id)
                        , (DbParameter)new SqlParameter("Name", model.Name)
                         , (DbParameter)new SqlParameter("Introduction", model.Introduction)
                        , (DbParameter)new SqlParameter("Picturepath", model.Picturepath)
                         , (DbParameter)new SqlParameter("Sex", model.Sex)
                         , (DbParameter)new SqlParameter("Nation", model.Nation)
                         , (DbParameter)new SqlParameter("mobilephone", model.mobilephone)
                         , (DbParameter)new SqlParameter("Telephone", model.Telephone)
                         , (DbParameter)new SqlParameter("Email", model.Email)
                         , (DbParameter)new SqlParameter("QQ", model.QQ)
                         , (DbParameter)new SqlParameter("Zipcode", model.Zipcode)
                         , (DbParameter)new SqlParameter("Address", model.Address)
                         , (DbParameter)new SqlParameter("appreciation", model.appreciation)
                         , (DbParameter)new SqlParameter("Reward", model.Reward)
                         , (DbParameter)new SqlParameter("BirthDay", model.BirthDay.HasValue ? model.BirthDay.Value.ToShortDateString() : "")
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
        #region 获取前n条大师
        /// <summary>
        /// 获取前n条大师
        /// </summary>
        /// <param name="TopNum">前n</param>
        /// <returns></returns>
        public IEnumerable<master> GetTopMaster(int TopNum)
        {
            string sql = "select top (" + TopNum + ") * from master where state='1' and state1='1'  and Isshow='1' order by rank desc";
            List<master> list = new List<master>();
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;
        } 
        #endregion
        #region 根据排名寻找大师
        /// <summary>
        /// 根据排名寻找大师
        /// </summary>
        /// <param name="TopNum">排名</param>
        /// <returns></returns>
        public IEnumerable<master> GetTopMasterByRank(int TopNum)
        {
            string sql = "select top (" + TopNum + ")  * from master order by rank desc";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            List<master> list = new List<master>();
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
        public bool MasterLogin(master info)
        {
            string sql = "select count(*) from master where username=@username and password=@password and state='1'";
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
        public DateTime GetMasterVTime(string UserName, string VCode)
        {
            string sql = "select VTime from master where username=@username and VCode=@VCode";
            return (DateTime)SqlHelper.ExecuteScalar(sql, (DbParameter)new SqlParameter("username", UserName), (DbParameter)new SqlParameter("VCode", VCode));
        } 
        #endregion
        #region 激活帐号
        /// <summary>
        /// 激活帐号
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public bool ActivationMasterStatus(string UserName)
        {
            string sql = "update master set state='1' where username=@username ";
            return SqlHelper.ExecuteNonQuery(sql, (DbParameter)new SqlParameter("username", UserName));

        } 
        #endregion
        #region 根据用户名获取用户信息
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public master GetMasterInfo(string UserName)
        {
            string sql = "select * from master where username=@username";
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

            string sql = "update master set password=@password from master where username=@username and state='1'";
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
            string sql = "select password from master where username=@username and state='1'";
            return (string)SqlHelper.ExecuteScalar(sql, (DbParameter)new SqlParameter("username", UserName));
        }
        
        #endregion
        #region 删除
        /// <summary>
        /// 删除master的sql语句生成
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal string GetMasterDeleteSql(int id)
        {
            string sql = "select Id from product where Belongstype='0' and Masterid=" + id;
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            StringBuilder sb = new StringBuilder();
            productDAL dal = new productDAL();
            foreach (DataRow dr in dt.Rows)
            {
                //获取删除产品所有信息的SQL(构造出sql)
                sb.Append(dal.GetDeleteProductSqlString(dr["Id"].ToString()));
            }
            sb.Append(";delete from master_cert where  Masterid=" + id);
            sb.Append(";delete from master_type where  Masterid=" + id);
            sb.Append(";delete from master where Id=" + id + ";");
            return sb.ToString();
        }
        /// <summary>
        /// 删除master
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {
            bool status = false;
            SqlHelper.Open();
            SqlHelper.BeginTrans();
            if (SqlHelper.ExecuteNonQuery(GetMasterDeleteSql(id)))
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
        /// 通过多个master的id获取删除产品Sql信息
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>

        internal string GetDeleteSqlByMoreMaster(string strID)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select Id from product where Belongstype='0' and  Masterid in (" + strID + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            productDAL dal = new productDAL();
            foreach (DataRow dr in dt.Rows)
                sb.Append(dal.GetDeleteProductSqlString(dr["Id"].ToString()));
            return sb.ToString();

        }
        /// <summary>
        /// 删除master
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            bool status = false;
            string[] IDs = strID.Split(',');
            StringBuilder sb = new StringBuilder();
            sb.Append(GetDeleteSqlByMoreMaster(strID));
            for (int i = 0; i < IDs.Length; i++)
            {

                sb.Append(";delete from master_cert where  Masterid=" + IDs[i]);
                sb.Append(";delete from master_type where  Masterid=" + IDs[i]);
            }
            sb.Append(";delete from master where Id in (" + strID + ")");
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
        /// 获得所有的大师主图片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable GetMasterMainPic(string Ids)
        {
            string sql = "select Picturepath from Master where Id in(" + Ids + ")";
            return SqlHelper.ExecuteDataTable(sql);
        }
        #endregion
        #region 获得所有大师id和图片信息
       /// <summary>
        /// 获得所有大师id和图片信息
       /// </summary>
       /// <param name="TypeId"></param>
       /// <returns></returns>
        public DataTable GetAllMasterByCraftType(string TypeId)
        {
            string sql = "select Masterid from master_type where Typeid in (" + TypeId + ")";
           return SqlHelper.ExecuteDataTable(sql);
        }
       /// <summary>
       /// 获取多个的大师主图片
       /// </summary>
       /// <param name="Ids"></param>
       /// <returns></returns>
       public DataTable GetAllMasterMainPic(string Ids)
        {
            string sql = "select Picturepath from master where Id in (" + Ids + ")";
          return  SqlHelper.ExecuteDataTable(sql);
        }
        #endregion
  
    }
}
