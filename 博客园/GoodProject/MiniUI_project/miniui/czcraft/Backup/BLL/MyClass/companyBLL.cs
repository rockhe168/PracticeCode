using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using Common;
using Newtonsoft.Json;
using System.IO;
using System.Data;
namespace czcraft.BLL
{
   public partial class companyBLL
    {
        //企业信息
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
        #region 为企业模块生成排名的json数据
        /// <summary>
        /// 为企业模块生成排名的json数据
        /// </summary>
        /// <returns></returns>
        public static string GetCompanyForMainByJson(int TopNum)
        {
            IEnumerable<company> CompanyList = new companyDAL().GetTopCompany(TopNum);
            bool Status = false;
            if (CompanyList.Count() > 0)
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
                foreach (company Info in CompanyList)
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
            return Json.ToString();

        } 
        #endregion
        #region 根据排名前8寻找企业
        /// <summary>
        /// 根据排名前8寻找企业
        /// </summary>
        /// <returns></returns>
        public string GetTopCompanyByRankByJson()
        {
            IEnumerable<company> list = new companyDAL().GetTopCompanyByRank(5);
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
                foreach (company Info in list)
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
        #region 更新(企业空间自己的部分更新)
        /// <summary>
        /// 更新(企业空间自己的部分更新)
        /// </summary>
        /// <param name="Info">企业信息</param>
        /// <param name="CraftType">企业类别信息</param>
        /// <returns></returns>
        public bool UpdateCompanyForZone(company Info, string CraftType)
        {
            return new companyDAL().UpdateCompanyForZone(Info, CraftType);
        }
        #endregion
        #region 更新企业排名信息
        /// <summary>
        /// 更新企业排名信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCompanyRank(company model)
        {
            return new companyDAL().UpdateCompanyRank(model);
        } 
        #endregion
        #region 获取企业简介信息
        /// <summary>
        /// 获取企业简介信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCompanyIntroForJson(string id)
        {
            //加载状态
            bool Status = false;
            int CompanyId = Convert.ToInt32(id);
            //获取企业基本信息
            company Info = new companyDAL().Get(CompanyId);

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
        #region 获取企业获奖信息
        /// <summary>
        /// 获取企业获奖信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCompanyRewardForJson(string id)
        {
            //加载状态
            bool Status = false;
            //获取企业荣誉证书
            IEnumerable<company_cert> companyCertList = new company_certDAL().ListAllById(id);
            int CompanyId = Convert.ToInt32(id);
            //获取企业基本信息
            company Info = new companyDAL().Get(CompanyId);

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
                jsonWriter.WriteValue(Info.Award);

                jsonWriter.WritePropertyName("CertPicList");
                jsonWriter.WriteStartArray();
                foreach (company_cert cert in companyCertList)
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
        #region 获取企业美景信息
        /// <summary>
        /// 获取企业美景信息
        /// </summary>
        /// <param name="id">企业id</param>
        /// <returns></returns>
        public string GetCompanyPicForJson(string id)
        {
            //加载状态
            bool Status = false;
            //获取企业美景信息
            IEnumerable<company_pic> company_picList = new company_picDAL().ListAllById(id);
            //转化为json格式
            StringBuilder json = new StringBuilder();
            StringWriter sw = new StringWriter(json);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                //判断数据读取状态
                if (company_picList.Count() > 0)
                {
                    Status = true;
                }
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Status");
                jsonWriter.WriteValue(Status);
                jsonWriter.WritePropertyName("Data");

                jsonWriter.WriteStartArray();
                foreach (var pic in company_picList)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("PicId");
                    jsonWriter.WriteValue(pic.Id);
                    jsonWriter.WritePropertyName("PicName");
                    jsonWriter.WriteValue(pic.Name);
                    jsonWriter.WritePropertyName("PicPath");
                    jsonWriter.WriteValue(pic.Picpath);
                    jsonWriter.WritePropertyName("CompanyId");
                    jsonWriter.WriteValue(pic.Companyid);
                    jsonWriter.WriteEndObject();
                }



                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject();

            }
            return json.ToString();
        } 
        #endregion
        #region 企业编辑信息获取(包括企业类别)
        /// <summary>
        /// 企业编辑信息获取(包括企业类别)
        /// </summary>
        /// <param name="Id">企业Id</param>
        /// <returns></returns>
        public static string CompanyEditForJson(int Id)
        {

            company Info = new companyDAL().Get(Id);
            string TypeName = "";
            string Types = new company_typeDAL().GetByCompanyId(Id, out TypeName);

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
            Json.Append("\"Representative\":\"" + Info.Representative + "\"");
            Json.Append(",");
            Json.Append("\"Fac\":\"" + Info.Fac + "\"");
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
            Json.Append("\"Award\":\"" + Info.Award + "\"");
            Json.Append(",");
            Json.Append("\"website\":\"" + Info.Website + "\"");
            Json.Append(",");
            Json.Append("\"state\":\"" + Info.State + "\"");
            Json.Append(",");
            Json.Append("\"state1\":\"" + Info.State1 + "\"");
            Json.Append(",");
            Json.Append("\"hit\":\"" + Info.hit + "\"");
            Json.Append(",");
            Json.Append("\"rank\":\"" + Info.rank + "\"");
            Json.Append("}");
            return Json.ToString();
        } 
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
            return new companyDAL().GetCount(string.Format(" Username='{0}'", userName)) == 0;
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
            companyDAL dal = new companyDAL();
            company info = dal.GetCompanyInfo(UserName);
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
            return new companyDAL().UpdatePassword(UserName, Tools.GetMD5(Pwd));
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
            companyDAL dal = new companyDAL();
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
        public bool ActivationCompanyNumber(string UserName, string GuidInfo)
        {
            companyDAL dal = new companyDAL();
            //获取过期时间
            DateTime dt = dal.GetCompanyVTime(UserName, GuidInfo);
            //如果已经过期
            if (dt < DateTime.Now)
            {
                return false;
            }
            else
            {
                //激活帐号
                return dal.ActivationCompanyStatus(UserName);
            }
        }
        #endregion
        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info">model</param>
        /// <returns></returns>
        public bool CompanyLogin(company info)
        {
            info.Password = Tools.GetMD5(info.Password);
            return new companyDAL().CompanyLogin(info);
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
            string Pwd = Tools.GetMD5(new companyDAL().GetPassword(UserName));
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
        public string ReturnJson(company info, out bool Status)
        {
            //登录状态
            Status = CompanyLogin(info);
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
        public string GetCompanyId(string UserName)
        {
            company info = new companyDAL().GetCompanyInfo(UserName);
            return info.Id.ToString();
        }
        #endregion
        #region 根据用户名获取用户信息(返回json数据)

        ///// <summary>
        ///// 根据用户名获取用户信息(返回json数据)
        ///// </summary>
        ///// <param name="UserName">用户名</param>
        ///// <returns></returns>
        //public string GetCompanyInfoByJson(string UserName)
        //{
        //    bool Status = false;
        //    company info = new companyDAL().GetCompanyInfo(UserName);
        //    if (info.Id.HasValue)
        //    {
        //        Status = true;
        //    }
        //    StringBuilder json = new StringBuilder();
        //    StringWriter sw = new StringWriter(json);
        //    using (JsonWriter jsonWriter = new JsonTextWriter(sw))
        //    {
        //        jsonWriter.Formatting = Formatting.Indented;
        //        jsonWriter.WriteStartObject();
        //        jsonWriter.WritePropertyName("Status");
        //        jsonWriter.WriteValue(Status);
        //        jsonWriter.WritePropertyName("Data");
        //        jsonWriter.WriteStartArray();
        //        jsonWriter.WriteStartObject();
        //        jsonWriter.WritePropertyName("UserName");
        //        jsonWriter.WriteValue(info.Username);
        //        jsonWriter.WritePropertyName("Sex");
        //        jsonWriter.WriteValue(info.Sex);
        //        jsonWriter.WritePropertyName("Nation");
        //        jsonWriter.WriteValue(info.Nation);
        //        //mobilephone Telephone Email qq Zipcode Address
        //        jsonWriter.WritePropertyName("MobilePhone");
        //        jsonWriter.WriteValue(info.mobilephone);
        //        jsonWriter.WritePropertyName("TelePhone");
        //        jsonWriter.WriteValue(info.Telephone);
        //        jsonWriter.WritePropertyName("Email");
        //        jsonWriter.WriteValue(info.Email);
        //        jsonWriter.WritePropertyName("QQ");
        //        jsonWriter.WriteValue(info.QQ);
        //        jsonWriter.WritePropertyName("ZipCode");
        //        jsonWriter.WriteValue(info.Zipcode);
        //        //地址处理

        //        string[] strAddresss = GetSplitAddress(info.Address);
        //        string Province = "";
        //        string City = "";
        //        string Country = "";
        //        string Address = "";
        //        if (strAddresss.Count() > 4)
        //        {
        //            Province = strAddresss[0];
        //            City = strAddresss[1];
        //            Country = strAddresss[2];
        //            Address = strAddresss[3];

        //        }
        //        jsonWriter.WritePropertyName("Province");
        //        jsonWriter.WriteValue(Province);
        //        jsonWriter.WritePropertyName("City");
        //        jsonWriter.WriteValue(City);
        //        jsonWriter.WritePropertyName("Country");
        //        jsonWriter.WriteValue(Country);
        //        jsonWriter.WritePropertyName("Address");
        //        jsonWriter.WriteValue(Address);
        //        jsonWriter.WriteEndObject();

        //        jsonWriter.WriteEndArray();
        //        jsonWriter.WriteEndObject();
        //    }
        //    return json.ToString();
        //}
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
            string UserName = Common.CookieHelper.GetCookieValue("CompanyName");
            //如果cookies为空,直接返回
            if (Tools.IsNullOrEmpty(UserName))
            {
                Status = false;
            }
            string Pwd = Common.CookieHelper.GetCookieValue("CompanyPwd");
            if (Tools.IsNullOrEmpty(Pwd))
            {
                Status = false;
            }
            else
            {
                //查找该用户真实密码,并进行md5加密
                string password = new companyDAL().GetPassword(UserName);
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
        public bool RememberUserInfo(company info, RememberType type)
        {
            if (type == RememberType.RememberName)
            {
                //记住帐号7天
                CookieHelper.SetCookie("CompanyName", info.Username, DateTime.Now.AddDays(7));
            }
            else if (type == RememberType.RememberNameAndPwd)
            {

                //md5哈希加密
                string sercret = Tools.GetMD5(info.Password);
                //同时记住帐号和密码7天
                CookieHelper.SetCookie("CompanyName", info.Username, DateTime.Now.AddDays(7));
                CookieHelper.SetCookie("CompanyPwd", sercret, DateTime.Now.AddDays(7));
            }
            else
            {
                return false;
            }
            return true;

        }
        #endregion
        #region 删除企业图片
        #region 获取企业图片
        /// <summary>
        /// 获取企业图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCompanyPath(int id)
        {
            companyDAL dal = new companyDAL();
            company pic = dal.Get(id);
            return pic.Picturepath;
        }
        #endregion
        #region 通过企业id删除产品
        /// <summary>
        /// 通过企业id删除产品
        /// </summary>
        /// <param name="CompanyId"></param>
        public void DeleteProdoctsByCompanyId(DataTable dt)
        {
            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {
               
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetMainProductPic, dr["Picturepath"].ToString());
            }

          

        }
        #endregion 
        #region 删除企业美景图
       
        /// <summary>
        /// 删除企业美景图(根据企业美景)
        /// </summary>
        /// <param name="CompanyId"></param>
        public void DeleteCompanyPic(DataTable dt)
        {

            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetCompanyPic, dr["Picpath"].ToString());
            }
        }
        #endregion
        #region 删除企业荣誉证书
        /// <summary>
        /// 删除企业荣誉证书
        /// </summary>
        /// <param name="CompanyId"></param>
        public void DeleteCompanyCertPic(DataTable dt)
        {
            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetCompanyCert, dr["Picpath"].ToString());
            }
        }
      
        #endregion 
        #region 删除多张企业主图片
        /// <summary>
        /// 删除多张企业主图片
        /// </summary>
        /// <param name="strID"></param>
        public void DeleteMainCompanyPath(DataTable dt)
        {
            //循环删除图片
            foreach (DataRow dr in dt.Rows)
            {

                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetLogoCompanyPic, dr["Picturepath"].ToString());
            }

        }  
        #endregion
        
        #endregion
        #region 删除
        #region 删除company
        /// <summary>
        /// 删除company
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>执行状态</returns>
        public bool Delete(int id)
        {
            //获取产品图片
            string Picturepath = GetCompanyPath(id);
            string strId = id.ToString();
            //获取企业美景图
            DataTable dtCompanyPic = new company_picDAL().GetCompanyPicByCompanyId(strId);
            //获取企业荣誉图片
            DataTable dtCompanyCert = new company_certDAL().GetCompanyCertByCompanyId(strId);
            //获取企业产品主图片
            DataTable dtCompanyProducts = new productDAL().GetProductsPicByCompanyId(strId);
            //获取企业其他产品图片
            StringBuilder ProductIds=new StringBuilder ();
            foreach (DataRow dr in dtCompanyProducts.Rows)
            {
                ProductIds.Append(dr["Id"].ToString());
            }
            ProductIds.Remove(ProductIds.Length - 1, 1);
            DataTable dtProductOtherProducts = new product_picturepathDAL().GetMoreOtherProductPicPath(ProductIds.ToString ());
         
            //删除
            companyDAL dal = new companyDAL();
            bool Status = dal.Delete(id);
            //如果执行成功,则删除图片
            if (Status)
            {
                //删除企业主图片
                Common.CzcraftDeletePic.FileDelete(Common.CzcraftDeletePic.DeletePicType.GetLogoCompanyPic, Picturepath);
                //产品id
               
               //删除企业美景图
                DeleteCompanyPic(dtCompanyPic);
                //删除企业荣誉证书
              
                DeleteCompanyCertPic(dtCompanyCert);
                //删除所有产品图片
              
              DeleteProdoctsByCompanyId(dtCompanyProducts);
                //删除产品其他图片
              new product_picturepathBLL().DeleteMoreOtherProductPic(dtProductOtherProducts);

            }
            return Status;
          
        } 
        #endregion
        #region 删除company
        /// <summary>
        /// 删除company
        /// </summary>
        /// <param name="strID">strID,记得多个用,隔开</param>
        /// <returns>执行状态</returns>
        public bool DeleteMoreID(string strID)
        {
            //获取企业主图片
            DataTable dtCompanyPath = new companyDAL().GetCompanyMainPic(strID);
            //获取企业美景图
            DataTable dtCompanyPic = new company_picDAL().GetCompanyPicByMoreCompanyIds(strID);
            //获取企业荣誉图片
            DataTable dtCompanyCert = new company_certDAL().GetMoreCompanyCertPath(strID);
            //获取企业产品图片
            DataTable dtCompanyProducts = new productDAL().GetProductsPicByMoreCompanyIds(strID);
            //获取企业其他产品图片
            StringBuilder ProductIds = new StringBuilder();
            foreach (DataRow dr in dtCompanyProducts.Rows)
            {
                ProductIds.Append(dr["Id"].ToString());
            }
            ProductIds.Remove(ProductIds.Length - 1, 1);
            DataTable dtProductOtherProducts = new product_picturepathDAL().GetMoreOtherProductPicPath(ProductIds.ToString());
            //数据库删除
            bool Status = new companyDAL().DeleteMoreID(strID);
            //如果执行成功,则删除图片
            if (Status)
            {
            
                //删除企业主图片
                DeleteMainCompanyPath(dtCompanyPath);
                //删除企业美景图
                
             
                DeleteCompanyPic(dtCompanyPic);

                //删除多个企业荣誉图片
             
                DeleteCompanyCertPic(dtCompanyCert);
                //删除所有产品图片
               
                 DeleteProdoctsByCompanyId(dtCompanyProducts);
                 //删除产品其他图片
                 new product_picturepathBLL().DeleteMoreOtherProductPic(dtProductOtherProducts);

            }
                return Status;
           
        } 
        #endregion
        #endregion
    }
}
