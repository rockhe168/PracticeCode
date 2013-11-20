using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.common;
using IService.ICommon;

namespace Service.Common
{
    public class LogService : ILogService
    {
        private ILogHelper LogHelper { get; set; }
        /// <summary>
        ///  添加info信息
        /// </summary>
        /// <param name="info"></param>
        public void WriteLog(string info)
        {
            LogHelper.WriteLog(info);
        }
        /// <summary>
        /// 添加异常信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        public void WriteLog(string info, Exception se)
        {
            LogHelper.WriteLog(info,se);
        }
    }
}
