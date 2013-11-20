using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAO.IFile
{
    public interface IFileDao
    {
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path">路径</param>
        void DeteleFile(string path);
    }
}
