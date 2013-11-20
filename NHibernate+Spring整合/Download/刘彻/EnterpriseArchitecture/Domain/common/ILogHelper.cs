using System;
using System.IO;

namespace Domain.common
{
    public interface ILogHelper
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
