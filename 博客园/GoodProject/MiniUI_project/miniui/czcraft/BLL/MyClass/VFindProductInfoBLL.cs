using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace czcraft.BLL
{
   public partial class VFindProductInfoBLL
    {
        #region 判定查询条件
        /// <summary>
        /// 判定查询条件
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string ConfirmCondition(string info)
        {
            string condition = "";//查询条件
            if (Tools.IsNumber(info)) //如果是数字,则查询id
            {
                condition = "Id like '%" + info + "%'";
            }
            else condition = "Name like '%" + info + "%'"; //查询用户名
            return condition;
        } 
        #endregion
    }
}
