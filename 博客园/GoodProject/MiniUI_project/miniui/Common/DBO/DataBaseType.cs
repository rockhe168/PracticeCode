using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
namespace Zys.DBO
{
    /// <summary>
    /// 数据库连接类工厂模式公共接口
    /// </summary>
   public class DataBaseType
    {
        public static string type = "sql server";
        public static string connectionstring = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //public static string connectionstring = "max pool size=512;server=(local);database=czcraft;user=sa;password=tian815100";

    }
}
