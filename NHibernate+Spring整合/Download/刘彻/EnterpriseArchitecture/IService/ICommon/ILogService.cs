using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IService.ICommon
{
    public interface ILogService
    {
        /// <summary>
        ///  添加info信息
        /// </summary>
        /// <param name="info"></param>
        void WriteLog(string info);
        /// <summary>
        /// 添加异常信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        void WriteLog(string info, Exception se);
    }
}
