using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISegregate.ICommon
{
    public interface ILogSeg
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
