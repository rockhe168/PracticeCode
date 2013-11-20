using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Web;
using Common;
namespace czcraft.BLL
{
   public partial class SystemLogBLL
    {
        #region 保存系统日志
        /// <summary>
        /// 保存系统日志
        /// </summary>
        /// <param name="Title">日志信息</param>
        /// <returns></returns>
        public bool SaveSystemLog(string Title)
        {
            SystemLog log = new SystemLog();
            log.AddTime = DateTime.Now;
            log.Title = Title;
            //获取远程ip地址
            log.Url = HttpContext.Current.Request.UserHostAddress;
            WEB_USER user = (WEB_USER)HttpContext.Current.Session["User"];
            log.UserName = user.LOGNAME;
            return new SystemLogDAL().AddNew(log) > 0;
        } 
        #endregion
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
            else condition = "UserName like '%" + info + "%'"; //查询用户名
            return condition;
        } 
        #endregion
        #region 清空日志(强制保留三天内的日志)
        /// <summary>
        /// 清空日志(强制保留三天内的日志)
        /// </summary>
        /// <returns></returns>
        public bool ClearSystemLog()
        {
            //清空三天前的日志
            string Condition = " AddTime<dateadd(DAY,-3,GETDATE())";
            return new SystemLogDAL().ClearSystemLog(Condition);
        } 
        #endregion
    }
}
