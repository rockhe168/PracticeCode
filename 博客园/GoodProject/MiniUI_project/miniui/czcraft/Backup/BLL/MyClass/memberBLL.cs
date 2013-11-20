using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.IO;
using Newtonsoft.Json;//记得引入组件
using Common;
using System.Web;
namespace czcraft.BLL
{
    public partial class memberBLL
    {
        #region 判定查询条件
        /// <summary>
        /// 判定查询条件
        /// </summary> 
        /// <param name="info"></param>
        /// <returns></returns>
        public static string ConfirmCondition(string info)
        {
            string condition = "";//查询条件
            if (Tools.IsNumber(info)) //如果是数字,则查询id
            {
                condition = "id like '%" + info + "%'";
            }
            else condition = "username like '%" + info + "%'"; //查询用户名
            return condition;
        } 
        #endregion
        #region 检查用户名和邮箱
        /// <summary>
        /// 检查用户名和邮箱
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Email">邮箱</param>
        /// <returns></returns>
        public bool CheckUserNameAndEmail(string UserName, string Email)
        {
            memberDAL dal = new memberDAL();
            member info = dal.GetMemberInfo(UserName);
            return Email == info.Email;
        } 
        #endregion
        #region 随机生成一个6位的密码
        /// <summary>
        /// 随机生成一个6位的密码
        /// </summary>
        /// <returns></returns>
        public string CreateNewPwd()
        {
            string Pwd = "";
            Random ran = new Random(DateTime.Now.Second);
            for (int i = 0; i < 6; i++)
            {
                Pwd += ran.Next(1, 10);
            }
            return Pwd;
        } 
        #endregion
        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        public bool UpdatePwd(string UserName, string Pwd)
        {
            return new memberDAL().UpdatePassword(UserName, Tools.GetMD5(Pwd));
        } 
        
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        public bool UpdatePassword(string UserName, string oldPwd, string newPwd)
        {
            memberDAL dal = new memberDAL();
            string Pwd = dal.GetPassword(UserName);
            if (Pwd == Tools.GetMD5(oldPwd))
            {
                //加密并且更新
               return dal.UpdatePassword(UserName, Tools.GetMD5(newPwd));
            }
            return false;
        }
        #endregion
        #region  更新member实体
        /// <summary>
        /// 更新member实体
        /// </summary>
        /// <param name="model">member实体</param>
        /// <param name="IsUserNameUpdate">是否采用用户名更新</param>
        /// <returns></returns>
        public bool UpdateUserInfo(member model)
        {
            return new memberDAL().Update(model, true);
        } 
        #endregion
        #region 检验用户名是否存在
        /// <summary>
        /// 检验用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckExistUserName(string userName)
        {
            return new memberDAL().GetCount(string.Format(" username='{0}'", userName)) == 0;
        } 
        #endregion
        #region 验证用户信息
        /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="GuidInfo">guid随机码</param>
        public bool ActivationMemberNumber(string UserName, string GuidInfo)
        {
            memberDAL dal = new memberDAL();
            //获取过期时间
            DateTime dt = dal.GetMemberVTime(UserName, GuidInfo);
            //如果已经过期
            if (dt < DateTime.Now)
            {
                return false;
            }
            else
            {
                //激活帐号
                return dal.ActivationMemberStatus(UserName);
            }
        } 
        #endregion
        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info">会员model</param>
        /// <returns></returns>
        public bool MemberLogin(member info)
        {
            info.password = Tools.GetMD5(info.password);
            return new memberDAL().MemberLogin(info);
        } 
        #endregion
        #region 检验密码是否正确
        /// <summary>
        /// 检验密码是否正确
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public bool CheckPwd(string UserName, string Password)
        {
            //先不加密,以后全部都要加密
            string Pwd = Tools.GetMD5(new memberDAL().GetPassword(UserName));
            if (Password == Pwd)
            {
                return true;
            }
            else
                return false;
        } 
        #endregion
        #region 返回验证组件的数组格式(Validate)
        /// <summary>
        /// 返回验证组件的数组格式(Validate)
        /// </summary>
        /// <param name="fieldId">字段</param>
        /// <param name="Status">状态</param>
        /// <param name="errorMsg">错误消息(没有则"")</param>
        /// <returns></returns>
        public string ReturnValueValidateAjax(string fieldId, bool Status, string errorMsg)
        {

            if (string.IsNullOrEmpty(errorMsg))
            {
                return "[\"" + fieldId + "\",\"" + Status + "\"]";
            }
            return "[\"" + fieldId + "\",\"" + Status + "\",\"" + errorMsg + "\"]";

        } 
        #endregion
        #region 返回给客户端的json格式数据
        /// <summary>
        /// 返回给客户端的json格式数据(用于根据用户登录状态决定)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public string ReturnJson(member info, out bool Status)
        {
            //登录状态
            Status = MemberLogin(info);
            //生成json格式数据
            return WriteJsonForReturn(Status, info.username);

        } 
        #endregion
        #region 记住帐号和密码的枚举
        /// <summary>
        /// 记住帐号和密码的枚举
        /// </summary>
        public enum RememberType
        {
            /// <summary>
            /// 记住帐号
            /// </summary>
            RememberName = 0,
            /// <summary>
            /// 同时记住帐号和密码
            /// </summary>
            RememberNameAndPwd = 1,
            /// <summary>
            /// 不记住帐号密码
            /// </summary>
            NoRemember = 2
        } 
        #endregion
        #region 根据保存帐号密码状态判断是保存帐号还是同时保存帐号和密码
        /// <summary>
        /// 根据保存帐号密码状态判断是保存帐号还是同时保存帐号和密码
        /// </summary>
        /// <param name="IsSaveName">"1"代表保存,"0"代表不保存</param>
        /// <param name="IsSavePwd">"1"代表保存,"0"代表不保存</param>
        /// <returns></returns>
        public RememberType GetRememberType(string IsSaveName, string IsSavePwd)
        {
            RememberType SaveType = RememberType.NoRemember;

            //保存帐号和密码
            if (IsSaveName.Equals("1") && IsSavePwd.Equals("1"))
            {
                SaveType = RememberType.RememberNameAndPwd;
            }
            //保存帐号
            if (IsSaveName.Equals("1") && !IsSavePwd.Equals("1"))
            {
                SaveType = RememberType.RememberName;
            }
            else if (!IsSaveName.Equals("1"))
            {
                SaveType = RememberType.NoRemember;
            }
            return SaveType;
        } 
        #endregion
        #region 获取用户id
        /// <summary>
        /// 获取用户id
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public string GetMemberId(string UserName)
        {
            member info = new memberDAL().GetMemberInfo(UserName);
            return info.Id.ToString();
        } 
        #endregion
        #region 根据用户名获取用户信息(返回json数据)
        /// <summary>
        /// 根据用户名获取用户信息(返回json数据)
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public string GetMemberInfoByJson(string UserName)
        {
            bool Status = false;
            member info = new memberDAL().GetMemberInfo(UserName);
            if (info.Id.HasValue)
            {
                Status = true;
            }
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");
                jsonWriter.WriteStartArray();
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("UserName");
                jsonWriter.WriteValue(info.username);
                jsonWriter.WritePropertyName("Sex");
                jsonWriter.WriteValue(info.Sex);
                jsonWriter.WritePropertyName("Nation");
                jsonWriter.WriteValue(info.nation);
                //mobilephone Telephone Email qq Zipcode Address
                jsonWriter.WritePropertyName("MobilePhone");
                jsonWriter.WriteValue(info.mobilephone);
                jsonWriter.WritePropertyName("TelePhone");
                jsonWriter.WriteValue(info.Telephone);
                jsonWriter.WritePropertyName("Email");
                jsonWriter.WriteValue(info.Email);
                jsonWriter.WritePropertyName("QQ");
                jsonWriter.WriteValue(info.qq);
                jsonWriter.WritePropertyName("ZipCode");
                jsonWriter.WriteValue(info.Zipcode);
                //地址处理

                string[] strAddresss = GetSplitAddress(info.Address);
                string Province = "";
                string City = "";
                string Country = "";
                string Address = "";
                if (strAddresss.Count() > 4)
                {
                    Province = strAddresss[0];
                    City = strAddresss[1];
                    Country = strAddresss[2];
                    Address = strAddresss[3];

                }
                jsonWriter.WritePropertyName("Province");
                jsonWriter.WriteValue(Province);
                jsonWriter.WritePropertyName("City");
                jsonWriter.WriteValue(City);
                jsonWriter.WritePropertyName("Country");
                jsonWriter.WriteValue(Country);
                jsonWriter.WritePropertyName("Address");
                jsonWriter.WriteValue(Address);
                jsonWriter.WriteEndObject();

                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();
            }
            return json.ToString();
        } 
        #endregion
        #region 地址分割
        /// <summary>
        /// 地址分割(将用户信息表中的地址分割成 省(编号) 市(编号) 县(编号) 家住址
        /// </summary>
        /// <param name="Address">地址</param>
        /// <returns></returns>
        public string[] GetSplitAddress(string Address)
        {
            string[] str = Address.Split('|');
            return str;
        } 
        #endregion
        #region 检查用户登录状态,用于验证自动登录
        /// <summary>
        /// 检查用户登录状态,用于验证自动登录(并返回json格式)
        /// </summary>
        /// <returns></returns>
        public string CheckLoginStatus(out bool Status)
        {

            //登录状态
            Status = true;
            string UserName = Common.CookieHelper.GetCookieValue("UserName");
            //如果cookies为空,直接返回
            if (Tools.IsNullOrEmpty(UserName))
            {
                Status = false;
            }
            string Pwd = Common.CookieHelper.GetCookieValue("Pwd");
            if (Tools.IsNullOrEmpty(Pwd))
            {
                Status = false;
            }
            else
            {
                //查找该用户真实密码,并进行md5加密
                string password = new memberDAL().GetPassword(UserName);
                //如果两次密码相同则可以自动登陆了
                if (password != Pwd)
                {
                    Status = false;
                }
            }

            //生成json格式数据
            return WriteJsonForReturn(Status, UserName);
        } 
        #endregion
        #region 为用户登录写入json数据
        /// <summary>
        /// 为用户登录写入json数据
        /// </summary>
        /// <param name="Status">登录状态</param>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public string WriteJsonForReturn(bool Status, string UserName)
        {
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("UserName");
                jsonWriter.WriteValue(UserName);
                jsonWriter.WriteEndObject();
            }
            return json.ToString();
        } 
        #endregion
        #region 记住用户信息
        /// <summary>
        /// 记住用户信息
        /// </summary>
        /// <param name="Type">记住用户信息类别</param>
        /// <returns></returns>
        public bool RememberUserInfo(member info, RememberType type)
        {
            if (type == RememberType.RememberName)
            {
                //记住帐号7天
                CookieHelper.SetCookie("UserName", info.username, DateTime.Now.AddDays(7));
            }
            else if (type == RememberType.RememberNameAndPwd)
            {

                //md5哈希加密
                string sercret = Tools.GetMD5(info.password);
                //同时记住帐号和密码7天
                CookieHelper.SetCookie("UserName", info.username, DateTime.Now.AddDays(7));
                CookieHelper.SetCookie("Pwd", sercret, DateTime.Now.AddDays(7));
            }
            else
            {
                return false;
            }
            return true;

        }
        
        #endregion

    }
}
