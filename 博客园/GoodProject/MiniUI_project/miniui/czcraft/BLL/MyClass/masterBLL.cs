using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using Common;
using System.Data;
using System.IO;
using Newtonsoft.Json;
namespace czcraft.BLL
{
    public partial class masterBLL
    {
        //大师基本信息
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
                condition = "Id like '%" + info + "%'";
            }
            else condition = "Name like '%" + info + "%'"; //查询用户名
            return condition;
        } 
        #endregion
        #region 为大师信息模块生成排名的json数据
        /// <summary>
        /// 为大师信息模块生成排名的json数据
        /// </summary>
        /// <returns></returns>
        public static string GetMasterForMainByJson(int TopNum)
        {
            IEnumerable<master> MasterList = new masterDAL().GetTopMaster(TopNum);
            bool Status = false;
            if (MasterList.Count() > 0)
                Status = true;
            StringBuilder Json = new StringBuilder();
            StringWriter sw = new StringWriter(Json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;

                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");
                jsonWriter.WriteStartArray();
                foreach (master Info in MasterList)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Id");
                    jsonWriter.WriteValue(Info.Id);

                    jsonWriter.WritePropertyName("Name");
                    jsonWriter.WriteValue(Info.Name);
                    jsonWriter.WritePropertyName("PicturePath");
                    jsonWriter.WriteValue(Info.Picturepath);
                    jsonWriter.WriteEndObject();
                }


                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject();


            }
            return Json.ToString();

        } 
        #endregion
        #region 根据排名前8寻找大师
        /// <summary>
        /// 根据排名前8寻找大师
        /// </summary>
        /// <returns></returns>
        public string GetTopMasterByRankByJson()
        {
            IEnumerable<master> list = new masterDAL().GetTopMasterByRank(5);
            //加载状态
            bool Status = false;
            //转化为json格式
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                //判断数据读取状态
                if (list.Count() > 0)
                {
                    Status = true;
                }
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");
                jsonWriter.WriteStartArray();
                foreach (master Info in list)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("Id");
                    jsonWriter.WriteValue(Info.Id);
                    jsonWriter.WritePropertyName("Name");
                    jsonWriter.WriteValue(Info.Name);
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();
            }
            return json.ToString();

        } 
        #endregion
        #region 更新(大师空间自己的部分更新)
        /// <summary>
        /// 更新(大师空间自己的部分更新)
        /// </summary>
        /// <param name="Info">大师信息</param>
        /// <param name="CraftType">大师类别信息</param>
        /// <returns></returns>
        public bool UpdateMasterForZone(master Info, string CraftType)
        {
            return new masterDAL().UpdateMasterForZone(Info, CraftType);
        } 
        #endregion
        #region 更新大师排名信息
        /// <summary>
        /// 更新大师排名信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMasterRank(master model)
        {
            return new masterDAL().UpdateMasterRank(model);
        } 
        #endregion
        #region 获取大师简介信息
        /// <summary>
        /// 获取大师简介信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMasterIntroForJson(string id)
        {
            //加载状态
            bool Status = false;
            int MasterId = Convert.ToInt32(id);
            //获取大师基本信息
            master Info = new masterDAL().Get(MasterId);

            //转化为json格式
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                //判断数据读取状态
                if (Info.Id.HasValue)
                {
                    Status = true;
                }
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");

                jsonWriter.WriteStartArray();
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Introduction");
                jsonWriter.WriteValue(Info.Introduction);
                jsonWriter.WriteEndObject();
                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject();

            }
            return json.ToString();
        } 
        #endregion
        #region 获取大师获奖信息
        /// <summary>
        /// 获取大师获奖信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMasterRewardForJson(string id)
        {
            //加载状态
            bool Status = false;
            //获取大师荣誉证书
            IEnumerable<master_cert> masterCertList = new master_certDAL().ListAllById(id);
            int MasterId = Convert.ToInt32(id);
            //获取大师基本信息
            master Info = new masterDAL().Get(MasterId);

            //转化为json格式
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                //判断数据读取状态
                if (Info.Id.HasValue)
                {
                    Status = true;
                }
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");

                jsonWriter.WriteStartArray();
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Reward");
                jsonWriter.WriteValue(Info.Reward);

                jsonWriter.WritePropertyName("CertPicList");
                jsonWriter.WriteStartArray();
                foreach (master_cert cert in masterCertList)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("CertName");
                    jsonWriter.WriteValue(cert.Name);
                    jsonWriter.WritePropertyName("CertPic");
                    jsonWriter.WriteValue(cert.Picpath);
                    jsonWriter.WriteEndObject();

                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();


                jsonWriter.WriteEndObject();

            }
            return json.ToString();
        } 
        #endregion
        #region 获取大师基本信息
        /// <summary>
        /// 获取大师基本信息
        /// </summary>
        /// <param name="id">大师id</param>
        /// <returns></returns>
        public string GetMasterInfoForJson(string id)
        {
            //加载状态
            bool Status = false;
            //获取大师类别信息
            IEnumerable<VMasterType> masterTypeList = new VMasterTypeDAL().ListAllById(id);
            //拼接大师类别信息
            StringBuilder sbTypeName = new StringBuilder();
            foreach (var masterType in masterTypeList)
            {
                sbTypeName.Append(masterType.TypeName);

                if (masterType != masterTypeList.Last())
                {
                    sbTypeName.Append(",");
                }
            }

            int MasterId = Convert.ToInt32(id);
            //获取大师基本信息
            master Info = new masterDAL().Get(MasterId);

            //转化为json格式
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                //判断数据读取状态
                if (Info.Id.HasValue)
                {
                    Status = true;
                }
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");

                jsonWriter.WriteStartArray();
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Name");
                jsonWriter.WriteValue(Info.Name);
                jsonWriter.WritePropertyName("Sex");
                jsonWriter.WriteValue(Info.Sex == "1" ? "男" : "女");
                jsonWriter.WritePropertyName("Birthday");
                jsonWriter.WriteValue(Info.BirthDay.Value.ToShortDateString());
                jsonWriter.WritePropertyName("PicturePath");
                jsonWriter.WriteValue(Info.Picturepath);
                jsonWriter.WritePropertyName("TypeName");
                jsonWriter.WriteValue(sbTypeName.ToString());
                jsonWriter.WriteEndObject();
                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject();

            }
            return json.ToString();
        } 
        #endregion
        #region 大师编辑信息获取(包括大师类别)
        /// <summary>
        /// 大师编辑信息获取(包括大师类别)
        /// </summary>
        /// <param name="Id">大师Id</param>
        /// <returns></returns>
        public static string MasterEditForJson(int Id)
        {

            master Info = new masterDAL().Get(Id);
            string TypeName = "";
            string Types = new master_typeDAL().GetByMasterId(Id, out TypeName);

            StringBuilder Json = new StringBuilder();
            Json.Append("{");
            Json.Append("\"Id\":\"" + Info.Id + "\"");
            Json.Append(",");
            Json.Append("\"CraftTypes\":\"" + Types + "\"");
            Json.Append(",");
            Json.Append("\"CraftTypesName\":\"" + TypeName + "\"");
            Json.Append(",");
            Json.Append("\"Username\":\"" + Info.Username + "\"");
            Json.Append(",");
            Json.Append("\"Password\":\"" + Info.Password + "\"");
            Json.Append(",");
            Json.Append("\"Name\":\"" + Info.Name + "\"");
            Json.Append(",");
            Json.Append("\"Introduction\":\"" + Info.Introduction + "\"");
            Json.Append(",");
            Json.Append("\"Isrecommend\":\"" + Info.Isrecommend + "\"");
            Json.Append(",");
            Json.Append("\"Isshow\":\"" + Info.Isshow + "\"");
            Json.Append(",");
            Json.Append("\"Picturepath\":\"" + Info.Picturepath + "\"");
            Json.Append(",");
            Json.Append("\"Sex\":\"" + Info.Sex + "\"");
            Json.Append(",");
            Json.Append("\"Nation\":\"" + Info.Nation + "\"");
            Json.Append(",");
            Json.Append("\"mobilephone\":\"" + Info.mobilephone + "\"");
            Json.Append(",");
            Json.Append("\"Telephone\":\"" + Info.Telephone + "\"");
            Json.Append(",");
            Json.Append("\"Email\":\"" + Info.Email + "\"");
            Json.Append(",");
            Json.Append("\"QQ\":\"" + Info.QQ + "\"");
            Json.Append(",");
            Json.Append("\"Zipcode\":\"" + Info.Zipcode + "\"");
            Json.Append(",");
            Json.Append("\"Address\":\"" + Info.Address + "\"");
            Json.Append(",");
            Json.Append("\"appreciation\":\"" + Info.appreciation + "\"");
            Json.Append(",");
            Json.Append("\"website\":\"" + Info.website + "\"");
            Json.Append(",");
            Json.Append("\"Reward\":\"" + Info.Reward + "\"");
            Json.Append(",");
            if (Info.BirthDay.HasValue)
                Json.Append("\"BirthDay\":\"" + Info.BirthDay.Value.GetDateTimeFormats('s')[0].ToString() + "\"");
            else
            {
                Json.Append("\"BirthDay\":\"\"");
            }
            Json.Append(",");
            Json.Append("\"state\":\"" + Info.state + "\"");
            Json.Append(",");
            Json.Append("\"state1\":\"" + Info.state1 + "\"");
            Json.Append(",");
            Json.Append("\"hit\":\"" + Info.hit + "\"");
            Json.Append(",");
            Json.Append("\"rank\":\"" + Info.rank + "\"");
            Json.Append("}");
            return Json.ToString();
        } 
        #endregion
        #region 更新master实体
        //     /// <summary>
        //    /// 更新master实体
        //    /// </summary>
        //    /// <param name="model">master实体</param>
        //    /// <param name="IsUserNameUpdate">是否采用用户名更新</param>
        //    /// <returns></returns>
        //    public bool UpdateUserInfo(master model)
        //    {
        //        return new masterDAL().Update(model, true);
        //    }

        #endregion

        //登录信息相关
        #region 检验用户名是否存在
        /// <summary>
        /// 检验用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckExistUserName(string userName)
        {
            return new masterDAL().GetCount(string.Format(" Username='{0}'", userName)) == 0;
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
            masterDAL dal = new masterDAL();
            master info = dal.GetMasterInfo(UserName);
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
            return new masterDAL().UpdatePassword(UserName, Tools.GetMD5(Pwd));
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
            masterDAL dal = new masterDAL();
            string Pwd = dal.GetPassword(UserName);
            if (Pwd == Tools.GetMD5(oldPwd))
            {
                //加密并且更新
                return dal.UpdatePassword(UserName, Tools.GetMD5(newPwd));
            }
            return false;
        } 
	#endregion
        #region 验证用户信息
		 /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="GuidInfo">guid随机码</param>
        public bool ActivationMasterNumber(string UserName, string GuidInfo)
        {
            masterDAL dal = new masterDAL();
            //获取过期时间
            DateTime dt = dal.GetMasterVTime(UserName, GuidInfo);
            //如果已经过期
            if (dt < DateTime.Now)
            {
                return false;
            }
            else
            {
                //激活帐号
                return dal.ActivationMasterStatus(UserName);
            }
        } 
	#endregion
        #region 用户登录
		/// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info">model</param>
        /// <returns></returns>
        public bool MasterLogin(master info)
        {
            info.Password = Tools.GetMD5(info.Password);
            return new masterDAL().MasterLogin(info);
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
            string Pwd = Tools.GetMD5(new masterDAL().GetPassword(UserName));
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
        #region 返回给客户端的json格式数据(用于根据用户登录状态决定)
		/// <summary>
        /// 返回给客户端的json格式数据(用于根据用户登录状态决定)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public string ReturnJson(master info, out bool Status)
        {
            //登录状态
            Status = MasterLogin(info);
            //生成json格式数据
            return WriteJsonForReturn(Status, info.Username);

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
        public string GetMasterId(string UserName)
        {
            master info = new masterDAL().GetMasterInfo(UserName);
            return info.Id.ToString();
        } 
	#endregion
        #region 根据用户名获取用户信息(返回json数据)
		/// <summary>
        /// 根据用户名获取用户信息(返回json数据)
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public string GetMasterInfoByJson(string UserName)
        {
            bool Status = false;
            master info = new masterDAL().GetMasterInfo(UserName);
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
                jsonWriter.WriteValue(info.Username);
                jsonWriter.WritePropertyName("Sex");
                jsonWriter.WriteValue(info.Sex);
                jsonWriter.WritePropertyName("Nation");
                jsonWriter.WriteValue(info.Nation);
                //mobilephone Telephone Email qq Zipcode Address
                jsonWriter.WritePropertyName("MobilePhone");
                jsonWriter.WriteValue(info.mobilephone);
                jsonWriter.WritePropertyName("TelePhone");
                jsonWriter.WriteValue(info.Telephone);
                jsonWriter.WritePropertyName("Email");
                jsonWriter.WriteValue(info.Email);
                jsonWriter.WritePropertyName("QQ");
                jsonWriter.WriteValue(info.QQ);
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
      #region 地址分割(将用户信息表中的地址分割成 省(编号) 市(编号) 县(编号) 家住址
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
        #region 检查用户登录状态,用于验证自动登录(并返回json格式)
		/// <summary>
        /// 检查用户登录状态,用于验证自动登录(并返回json格式)
        /// </summary>
        /// <returns></returns>
        public string CheckLoginStatus(out bool Status)
        {

            //登录状态
            Status = true;
            string UserName = Common.CookieHelper.GetCookieValue("MasterName");
            //如果cookies为空,直接返回
            if (Tools.IsNullOrEmpty(UserName))
            {
                Status = false;
            }
            string Pwd = Common.CookieHelper.GetCookieValue("MasterPwd");
            if (Tools.IsNullOrEmpty(Pwd))
            {
                Status = false;
            }
            else
            {
                //查找该用户真实密码,并进行md5加密
                string password = new masterDAL().GetPassword(UserName);
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
        public bool RememberUserInfo(master info, RememberType type)
        {
            if (type == RememberType.RememberName)
            {
                //记住帐号7天
                CookieHelper.SetCookie("MasterName", info.Username, DateTime.Now.AddDays(7));
            }
            else if (type == RememberType.RememberNameAndPwd)
            {

                //md5哈希加密
                string sercret = Tools.GetMD5(info.Password);
                //同时记住帐号和密码7天
                CookieHelper.SetCookie("MasterName", info.Username, DateTime.Now.AddDays(7));
                CookieHelper.SetCookie("MasterPwd", sercret, DateTime.Now.AddDays(7));
            }
            else
            {
                return false;
            }
            return true;

        }  
        #endregion
        #region 删除大师图片
        #region 获取大师图片
        /// <summary>
        /// 获取大师图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMasterPath(int id)
        {
            masterDAL dal = new masterDAL();
            master pic = dal.Get(id);
            return pic.Picturepath;
        }
        #endregion
        #region 通过大师id删除产品
        /// <summary>
        /// 通过大师id删除产品
        /// </summary>
        /// <param name="MasterId"></param>
        public void DeleteProdoctsByMasterId(DataTable dt)
        {
            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {

                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetMainProductPic, dr["Picturepath"].ToString());
            }



        }
        #endregion
    
        #region 删除大师荣誉证书
        /// <summary>
        /// 删除大师荣誉证书
        /// </summary>
        /// <param name="MasterId"></param>
        public void DeleteMasterCertPic(DataTable dt)
        {
            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetMasterCert, dr["Picpath"].ToString());
            }
        }

        #endregion
        #region 删除多张大师主图片
        /// <summary>
        /// 删除多张大师主图片
        /// </summary>
        /// <param name="strID"></param>
        public void DeleteMainMasterPath(DataTable dt)
        {
            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {

                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetMasterPic, dr["Picturepath"].ToString());
            }

        }
        #endregion

        #endregion
        #region 删除
        #region 删除master
        /// <summary>
        /// 删除master
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {
            //获取产品图片
            string Picturepath = GetMasterPath(id);
            string strId = id.ToString();

            //获取大师荣誉图片
            DataTable dtMasterCert = new master_certDAL().GetMasterCertByMasterId(strId);
            //获取大师产品主图片
            DataTable dtMasterProducts = new productDAL().GetProductsPicByMasterId(strId);
            //获取大师其他产品图片
            StringBuilder ProductIds = new StringBuilder();
            foreach (DataRow dr in dtMasterProducts.Rows)
            {
                ProductIds.Append(dr["Id"].ToString());
            }
            ProductIds.Remove(ProductIds.Length - 1, 1);
            DataTable dtProductOtherProducts = new product_picturepathDAL().GetMoreOtherProductPicPath(ProductIds.ToString());

            //删除
            masterDAL dal = new masterDAL();
            bool Status = dal.Delete(id);
            //如果执行成功,则删除图片
            if (Status)
            {
                //删除大师主图片
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetMasterPic, Picturepath);
                //产品id

                //删除大师荣誉证书

                DeleteMasterCertPic(dtMasterCert);
                //删除所有产品图片

                DeleteProdoctsByMasterId(dtMasterProducts);
                //删除产品其他图片
                new product_picturepathBLL().DeleteMoreOtherProductPic(dtProductOtherProducts);

            }
            return Status;

        }
        #endregion
        #region 删除master
        /// <summary>
        /// 删除master
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            //获取大师主图片
            DataTable dtMasterPath = new masterDAL().GetMasterMainPic(strID);
            //获取大师荣誉图片
            DataTable dtMasterCert = new master_certDAL().GetMoreMasterCertPath(strID);
            //获取大师产品图片
            DataTable dtMasterProducts = new productDAL().GetProductsPicByMoreMasterIds(strID);
            //获取大师其他产品图片
            StringBuilder ProductIds = new StringBuilder();
            foreach (DataRow dr in dtMasterProducts.Rows)
            {
                ProductIds.Append(dr["Id"].ToString());
            }
            ProductIds.Remove(ProductIds.Length - 1, 1);
            DataTable dtProductOtherProducts = new product_picturepathDAL().GetMoreOtherProductPicPath(ProductIds.ToString());
            //数据库删除
            bool Status = new masterDAL().DeleteMoreID(strID);
            //如果执行成功,则删除图片
            if (Status)
            {

                //删除大师主图片
                DeleteMainMasterPath(dtMasterPath);
                //删除多个大师荣誉图片

                DeleteMasterCertPic(dtMasterCert);
                //删除所有产品图片

                DeleteProdoctsByMasterId(dtMasterProducts);
                //删除产品其他图片
                new product_picturepathBLL().DeleteMoreOtherProductPic(dtProductOtherProducts);

            }
            return Status;

        }
        #endregion
        #endregion
    }
}
