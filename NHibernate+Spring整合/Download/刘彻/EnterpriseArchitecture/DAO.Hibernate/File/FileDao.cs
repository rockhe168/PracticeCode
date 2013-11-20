using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAO.IFile;

namespace DAO.Hibernate.File
{
    /// <summary>
    /// 文件读取保存删除更新Dao   刘彻 2012-12-28
    /// </summary>
    public class FileDao : IFileDao
    {
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path">路径</param>
        public void DeteleFile(string path)
        {

            path = System.Web.HttpContext.Current.Server.MapPath("~" + path);
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
