using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISegregate.ICommon;
using IService.ICommon;

namespace Segregate.Common
{
    /// <summary>
    /// 日志隔离类
    /// </summary>
    public class LogSeg : ILogSeg
    {
        private ILogService LogService { get; set; }
        /// <summary>
        ///  添加info信息
        /// </summary>
        /// <param name="info"></param>
        public void WriteLog(string info)
        {
            LogService.WriteLog(info);
        }
        /// <summary>
        /// 添加异常信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        public void WriteLog(string info, Exception se)
        {
            LogService.WriteLog(info, se);
        }
    }
}
