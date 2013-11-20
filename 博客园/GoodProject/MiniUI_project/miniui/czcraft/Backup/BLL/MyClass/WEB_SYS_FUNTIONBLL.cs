using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Data;

namespace czcraft.BLL
{
    public partial class WEB_SYS_FUNTIONBLL
    {
        #region 列出一级菜单
        /// <summary>
        ///  列出一级菜单
        /// </summary>
        /// <returns>执行状态</returns>
        public IEnumerable<WEB_SYS_FUNTION> ListAllTopMenu()
        {
            return new WEB_SYS_FUNTIONDAL().ListAllTopMenu();

        } 
        #endregion
        #region 列出二级菜单
        /// <summary>
        /// 列出二级菜单
        /// </summary>
        /// <returns>执行状态</returns>
        public IEnumerable<WEB_SYS_FUNTION> ListAllTwoMenu()
        {
            return new WEB_SYS_FUNTIONDAL().ListAllTwoMenu();
        } 
        #endregion
        #region 分页获取数据
        /// <summary>
        ///分页获取数据
        /// </summary>
        public int GetCount(string tableName, string strWhere)
        {
            return new WEB_SYS_FUNTIONDAL().GetCount(tableName, strWhere);
        }
        
        #endregion
    }
}
