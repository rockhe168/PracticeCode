using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using System.Data.Common;
using System.Data.SqlClient;
namespace czcraft.DAL
{
    public partial class SystemLogDAL
    {
        #region 清空日志内容(不用加where)
        /// <summary>
        ///  清空日志内容(不用加where)
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public bool ClearSystemLog(string strWhere)
        {
            string condition = "";
            if (!string.IsNullOrEmpty(strWhere))
                condition = " where " + strWhere;
            string sql = "delete from SystemLog " + condition;
            return SqlHelper.ExecuteNonQuery(sql);
        } 
        #endregion
    }
}
