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
   public partial class WEB_USERDAL
   {

       #region 登录验证,返回用户组信息
       /// <summary>
       /// 登录验证,返回用户组信息
       /// </summary>
       /// <param name="user">用户实体</param>
       /// <returns>返回用户组信息</returns>
       public int IsLogin(WEB_USER user)
       {
           return SqlHelper.ExecuteSelectFirstNum("select USERGROUPID from WEB_USER where LOGNAME=@LOGNAME and PASSWORD=@PASSWORD and State='1'", (DbParameter)new SqlParameter("@LOGNAME", user.LOGNAME), (DbParameter)new SqlParameter("@PASSWORD", user.PASSWORD));

       } 
       #endregion
       #region 更新状态信息
       /// <summary>
       /// 更新状态信息
       /// </summary>
       /// <param name="user"></param>
       /// <returns></returns>
       public bool UpdateState(WEB_USER user)
       {
           return SqlHelper.ExecuteNonQuery("update WEB_USER set STATE=@STATE where ID=@ID", (DbParameter)new SqlParameter("@STATE", user.STATE), (DbParameter)new SqlParameter("@ID", user.ID));
       } 
       #endregion
    }
}
