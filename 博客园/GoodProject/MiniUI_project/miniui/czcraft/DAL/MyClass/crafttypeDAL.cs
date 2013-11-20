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
   public partial class crafttypeDAL
    {
        #region 更新叶子状态(1代表叶子节点,0代表树枝)
        /// <summary>
        /// 更新叶子状态(1代表叶子节点,0代表树枝)
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public bool UpdateLeaf(int id)
        {
            string UpdateType = "update crafttype set IsLeaf='0' where belongsid=@ID";
            return SqlHelper.ExecuteNonQuery(UpdateType
                , (DbParameter)new SqlParameter("ID", id));
        } 
        #endregion
        #region 获取顶级的产品类别信息
        /// <summary>
        /// 获取顶级的产品类别信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<crafttype> GetTopTypeInfo(int belongsid)
        {
            string buffer = "select *  from crafttype  where belongsid=@belongsid";
            DataTable dt = SqlHelper.ExecuteDataTable(buffer, (DbParameter)new SqlParameter("belongsid", belongsid));
            List<crafttype> list = new List<crafttype>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        } 
        #endregion
        #region 查询父级功能id信息
        /// <summary>
        /// 查询父级功能id信息
        /// </summary>
        /// <returns></returns>
        public string GetFatherMaxChildFId(int belongsid)
        {
            string buffer = "select ISNULL(max(FId),(select Fid+'00' from crafttype where ID=@belongsid)) as MaxChild from crafttype  where belongsid=@belongsid";  //查询出最大的子元素的FId如果没有,就拼接父级Fid+'00'
            return (string)SqlHelper.ExecuteScalar(buffer, (DbParameter)new SqlParameter("belongsid", belongsid));

        } 
        #endregion
        #region 增加crafttype
        /// <summary>
        /// 增加crafttype
        /// </summary>
        /// <param name="model">tableName实体</param>
        /// <returns>执行状态</returns>
        public bool AddNewAndUpdateLeaf(crafttype model)
        {
            string sql = "insert into crafttype(Name,level,Belongsid,IsLeaf,FId) output inserted.ID values(@Name,@level,@Belongsid,@IsLeaf,@FId);";
            string[] strparam = { "@Name", "@level", "@Belongsid", "@IsLeaf", "@FId" };
            object[] objparam = { model.Name, model.level, model.Belongsid, model.IsLeaf, model.FId };
            string id = SqlHelper.SearchValue(sql, strparam, objparam);
            string UpdateType = "update crafttype set IsLeaf='0' where ID=@ID";
            string[] strparamType = { "@ID" };
            object[] objparamType = { model.Belongsid };
            return SqlHelper.ExecuteUpdate(UpdateType, strparamType, objparamType);

        } 
        #endregion
        #region 删除
        #region 获得属于该类别的大师的删除语句
        /// <summary>
        /// 获得属于该类别的大师的删除语句
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        internal string GetDeleteMastersSql(string Id)
        {
            string sql = "select Masterid from master_type where  Typeid=" + Id;
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            StringBuilder sb = new StringBuilder();
            masterDAL dal = new masterDAL();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(dal.GetMasterDeleteSql(Convert.ToInt32(dr["Masterid"])));
            }
            return sb.ToString();
        } 
        #endregion
        #region 获得属于该类别的企业的删除语句
        /// <summary>
        /// 获得属于该类别的企业的删除语句
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        internal string GetDeleteCompanySql(string Id)
        {
            string sql = "select Companyid from company_type where  Typeid=" + Id;
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            StringBuilder sb = new StringBuilder();
            companyDAL dal = new companyDAL();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(dal.GetCompanyDeleteSql(Convert.ToInt32(dr["Companyid"])));
            }
            return sb.ToString();
        } 
        #endregion
        #region 获得属于多个类别的大师的删除语句
        /// <summary>
        /// 获得属于多个类别的大师的删除语句
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        internal string GetDeleteMoreMastersSql(string Ids)
        {
            string sql = "select Masterid from master_type where  Typeid in (" + Ids + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            StringBuilder sb = new StringBuilder();
            masterDAL dal = new masterDAL();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(dal.GetMasterDeleteSql(Convert.ToInt32(dr["Masterid"])));
            }
            return sb.ToString();
        }
        #endregion
        #region 获得属于多个类别的企业的删除语句
        /// <summary>
        /// 获得属于多个类别的企业的删除语句
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        internal string GetDeleteMoreCompanySql(string Ids)
        {
            string sql = "select Companyid from company_type where  Typeid in (" + Ids + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            StringBuilder sb = new StringBuilder();
            companyDAL dal = new companyDAL();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(dal.GetCompanyDeleteSql(Convert.ToInt32(dr["Companyid"])));
            }
            return sb.ToString();
        }
        #endregion
        #region 删除crafttype
        /// <summary>
        /// 删除crafttype
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {
            StringBuilder sb = new StringBuilder();
            // 获取删除企业的sql语句
            sb.Append(GetDeleteCompanySql(id.ToString ()));
            //获取删除大师的sql语句
            sb.Append(GetDeleteMastersSql(id.ToString ()));
            sb.Append("delete from craftknowledge where Typeid=" + id);
            sb.Append("delete from crafttype where id=" + id);
            bool status = false;
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
        #region 删除crafttype(多选)
        /// <summary>
        /// 删除crafttype(多选)
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            bool status = false;
            string[] IDs = strID.Split(',');
            StringBuilder sb = new StringBuilder();
            sb.Append(GetDeleteMoreMastersSql(strID));
            sb.Append(GetDeleteMoreCompanySql(strID));
            for (int i = 0; i < IDs.Length; i++)
            {
             sb.Append(";delete from craftknowledge where  Typeid=" + IDs[i]);
            }
            sb.Append(";delete from crafttype where id in (" + strID + ")");
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
        #endregion
    }
}
