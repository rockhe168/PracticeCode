using System.Collections;

namespace Domain.common
{
    /// <summary>
    /// 系统全局配置  刘彻  2012-10-12
    /// </summary>
    public class SystemConfig
    {
        /// <summary>
        /// 分页大小
        /// </summary>
        public static int PageSize=4 ;
        /// <summary>
        /// 超级管理员
        /// </summary>
        public static Hashtable Administrators=new Hashtable();
        /// <summary>
        /// 身份验证安全级别
        /// </summary>
        public static int SafeLevel = 2;
        /// <summary>
        /// 密码。0为明文，1为密文
        /// </summary>
        public static int PasswordType = 1;
    }
}
