using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bee.Data;
using Bee.Util;
using Bee.Models;
using Bee.Caching;

namespace Bee.BLL
{
    public class GBillSettingManager
    {
        private static GBillSettingManager instance = new GBillSettingManager();

        private List<BillColumnMapping> list;

        private GBillSettingManager()
        {

        }

        public static GBillSettingManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void RefreshMapping()
        {
            using (DbSession dbSession = GetDbSession(false))
            {
                list = dbSession.Query<BillColumnMapping>();

                foreach (BillColumnMapping item in list)
                {
                    item.ColumnMapping = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BillColumnField>>(item.Mapping);

                    if (item.ColumnMapping != null && item.ColumnMapping.Count != 0)
                    {
                        Dictionary<string, string> newDict = new Dictionary<string, string>();
                        foreach (BillColumnField billColumnField in item.ColumnMapping)
                        {
                            string value = billColumnField.Title;
                            if (value.StartsWith("{") && value.EndsWith("}"))
                            {
                                billColumnField.Title = SystemConfigManager.Instance.GetConfigValue(value.Substring(1, value.Length - 2));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取默认的单据列表设定
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="billId">单据类型</param>
        /// <returns>单据列表设定</returns>
        public List<BillColumnField> GetBillColumnSetting(int userId, int billId)
        {
            List<BillColumnSetting> defaultSetting = GetBillColumnSettingFromCache(1);
            List<BillColumnSetting> userSetting = GetBillColumnSettingFromCache(userId);

            List<BillColumnField> result = new List<BillColumnField>();
            BillColumnSetting billColumnSetting = (from item in userSetting where item.BillId == billId 
                                                   orderby item.SettingType descending select item).FirstOrDefault();
            if (billColumnSetting == null)
            {
                billColumnSetting = (from item in defaultSetting where item.BillId == billId 
                                     orderby item.SettingType descending select item).FirstOrDefault();
            }

            if (billColumnSetting != null)
            {
                result = billColumnSetting.ColumnList;
            }

            return result;
        }

        public List<BillColumnSetting> GetBillColumnSettingFromCache(int userId)
        {
            return CacheManager.Instance.GetEntity<List<BillColumnSetting>, int>(Bee.Security.Constants.UserAllBillColumnSetting, userId, TimeSpan.FromHours(2), pUserId =>
            {
                List<BillColumnSetting> result = new List<BillColumnSetting>();

                using (DbSession dbSession = GetDbSession(false))
                {
                    result = dbSession.ExecuteCommand<BillColumnSetting>(
                        @"select * from billcolumnsetting where userid= {0}".FormatWith(userId), null);
                }

                return result;
            });
        }

        public BillColumnSetting GetBillColumnSetting(int settingId)
        {
            using (DbSession dbSession = GetDbSession(false))
            {
                return dbSession.Query<BillColumnSetting>(SqlCriteria.New.Equal("id", settingId)).FirstOrDefault();
            }
        }

        public void SaveBillColumnSetting(int userId, int billId, int settingId, string settingName, string setting, int settingType)
        {
            using (DbSession dbSession = GetDbSession(false))
            {
                BillColumnSetting billColumnSetting
                    = dbSession.Query<BillColumnSetting>(
                    SqlCriteria.New.Equal("userid", userId)
                    .Equal("billid", billId).Equal("id", settingId)).FirstOrDefault();
                if (billColumnSetting != null)
                {
                    billColumnSetting.Name = settingName;
                    billColumnSetting.SettingType = settingType;
                    billColumnSetting.Setting = setting;
                }
                else
                {
                    billColumnSetting = new BillColumnSetting();
                    billColumnSetting.UserId = userId;
                    billColumnSetting.BillId = billId;
                    billColumnSetting.Name = settingName;
                    billColumnSetting.SettingType = settingType;
                    billColumnSetting.Setting = setting;
                }

                dbSession.Save(billColumnSetting);

                CacheManager.Instance.RemoveCache("{0}_{1}".FormatWith(Bee.Security.Constants.UserAllBillColumnSetting, userId));
            }
        }

        public BillColumnMapping this[int billId]
        {
            get
            {
                lock (this)
                {
                    if (list == null)
                    {
                        RefreshMapping();
                    }

                    BillColumnMapping result = (from item in list
                                                where item.BillId == billId
                                                select item).FirstOrDefault();
                    return result;
                }
            }
        }

        private DbSession GetDbSession(bool useTransaction)
        {
            string AuthConnString = ConfigUtil.GetAppSettingValue<string>("Bee.Auth.DataSource");
            DbSession dbSession = null;
            if (string.IsNullOrEmpty(AuthConnString))
            {
                dbSession = DbSession.Current;
            }
            else
            {
                dbSession = new DbSession(AuthConnString, useTransaction);
            }

            return dbSession;
        }

    }
}
