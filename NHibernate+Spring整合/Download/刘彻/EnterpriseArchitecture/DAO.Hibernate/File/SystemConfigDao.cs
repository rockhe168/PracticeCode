using System;
using System.Linq;
using System.Xml.Linq;
using Domain.common;
using IDAO.IFile;

namespace DAO.Hibernate.File
{
    /// <summary>
    /// 配置数据DAO  刘彻 2012-10-11
    /// </summary>
    public class SystemConfigDao : ISystemConfigDao
    {
        public SystemConfigDao()
        {
                string path = System.Web.HttpContext.Current.Server.MapPath(@"~\Configs\systemConfig.xml");
                XDocument doc = XDocument.Load(path);
                string[] administrators = doc.Descendants("administrator").First().Value.Split('.');
                foreach (var administrator in administrators)
                {
                    SystemConfig.Administrators.Add(administrator, administrator);
                }
                SystemConfig.PageSize = Convert.ToInt32(doc.Descendants("pageSize").First().Value);
                SystemConfig.SafeLevel = Convert.ToInt32(doc.Descendants("safeLevel").First().Value);
                SystemConfig.PasswordType = Convert.ToInt32(doc.Descendants("passwordType").First().Value);
        }
        /// <summary>
        /// 获取列表页的分页大小
        /// </summary>
        /// <returns></returns>
        public int GetPageSizeConfig()
        {
            return Domain.common.SystemConfig.PageSize;
        }
    }
}
