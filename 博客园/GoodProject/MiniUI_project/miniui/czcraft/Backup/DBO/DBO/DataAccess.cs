using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
namespace DBO
{
    /// <summary>
    /// 
    /// </summary>
   public class DataAccess
    {
       public static readonly string connstr =
           ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
       /// <summary>
       /// 数据库类型枚举
       /// </summary>
       public enum DataType {
       Sql,Access
       };
        //注意引用 System.Web.Configuration名空间,然后在webconfig中AppSettings节点中配置key为Conn数据库连接字符串,当然可以在这里做数据库字符串加密操作保证数据库连接的安全性
       

    }
}
