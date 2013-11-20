using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using czcraft.Model;
using System.Data.Common;
using System.Data.SqlClient;

namespace czcraft.DAL
{
   public partial class WEB_USERGROUPDAL
    {
        #region 根据用户组ID查找该用户组所有功能(视图中已做作权限判断)
        /// <summary>
        /// 根据用户组ID查找该用户组所有功能(视图中已做作权限判断)
        /// </summary>
        /// <param name="groupID">用户组信息id</param>
        /// <returns></returns>
        public DataTable GetUserGroupFunction(int? groupID)
        {
            return SqlHelper.ExecuteDataTable("select * from VUserFunctionMenu where USERGROUPID=@USERGROUPID", (DbParameter)(new SqlParameter("USERGROUPID", groupID)));
        } 
        #endregion
    }
}
