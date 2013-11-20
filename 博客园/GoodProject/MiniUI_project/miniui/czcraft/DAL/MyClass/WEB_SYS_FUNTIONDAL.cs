using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace czcraft.DAL
{
   public partial class WEB_SYS_FUNTIONDAL
    {
        #region 列出一级菜单
        /// <summary>
        /// 列出一级菜单
        /// </summary>
        /// <returns>执行状态</returns>
        public IEnumerable<WEB_SYS_FUNTION> ListAllTopMenu()
        {
            List<WEB_SYS_FUNTION> list = new List<WEB_SYS_FUNTION>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from WEB_SYS_FUNTION where FATHER_ID=0");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        } 
        #endregion
        #region  列出二级菜单
        /// <summary>
        /// 列出二级菜单
        /// </summary>
        /// <returns>执行状态</returns>
        public IEnumerable<WEB_SYS_FUNTION> ListAllTwoMenu()
        {
            List<WEB_SYS_FUNTION> list = new List<WEB_SYS_FUNTION>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from WEB_SYS_FUNTION where FATHER_ID>0");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        } 
        #endregion
        #region 获取用户组功能表
        /// <summary>
        /// 获取用户组功能表
        /// </summary>
        /// <param name="groupID">用户组id</param>
        /// <returns>数据表</returns>
        public DataTable ListAllItem(int groupID)
        {
            return SqlHelper.ExecuteDataTable("select * from VGroupFunction where USERGROUPID=@USERGROUPID", (DbParameter)new SqlParameter("USERGROUPID", groupID));

        } 
        #endregion
        #region 分页获取数据(通用DataTable返回)
        /// <summary>
        ///分页获取数据(通用DataTable返回)
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="sortId">排序的列名</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">页数</param>
        /// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
        /// <param name="strWhere">查询条件(注意: 不要加where) </param>
        public DataTable ListByPaginationByTable(string tableName, string InnerJoin, string strGetFields, string sortId, int PageSize, int PageIndex, string OrderType, string strWhere)
        {

            DataTable dt = SqlHelper.ExecuteDataTable("exec[pagination]  @tableName,@InnerJoin,@strGetFields,@sortId,@PageSize,@PageIndex,@doCount,@OrderType,@strWhere", (DbParameter)new SqlParameter("tableName", tableName), (DbParameter)new SqlParameter("@InnerJoin", InnerJoin), (DbParameter)new SqlParameter("@strGetFields", strGetFields), (DbParameter)new SqlParameter("@sortId", sortId), (DbParameter)new SqlParameter("@PageSize", PageSize), (DbParameter)new SqlParameter("@PageIndex", PageIndex), (DbParameter)new SqlParameter("@doCount", "0"), (DbParameter)new SqlParameter("@OrderType", OrderType), (DbParameter)new SqlParameter("@strWhere", strWhere));
            return dt;
        } 
        #endregion
        #region 获取表总记录个数(不用加where)
        /// <summary>
        ///获取表总记录个数(不用加where)
        /// <param name="strWhere">查询条件(不用加where)</param>
        /// <summary>
        public int GetCount(string tableName, string strWhere)
        {
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = " where " + strWhere;
            return SqlHelper.ExecuteSelectFirstNum("select count(1) from " + tableName + strWhere);
        } 
        #endregion

    }
}
