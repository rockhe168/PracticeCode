using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bee.Util;
using Bee.Data;
using Bee.Models;
using Bee.BLL;

namespace Bee
{
    public class SystemConfigManager
    {
        private static SystemConfigManager instance = new SystemConfigManager();
        private static readonly string AuthConnString = ConfigUtil.GetAppSettingValue<string>("Bee.Auth.DataSource");
        

        private SystemConfigManager()
        {
            DataMapping.Instance.Register("SystemConfig", () => {
                using (DbSession dbSession = new DbSession(AuthConnString))
                {
                    return dbSession.Query("SystemConfig", null);
                }
            });
        }

        public static SystemConfigManager Instance
        {
            get
            {
                return instance;
            }
        }

        public string GetConfigValue(string name)
        {
            string result = string.Empty;

            result = DataMapping.Instance.Mapping("SystemConfig", name, "name", "value");

            return result;
        }

        public void SetConfigValue(string name, string value)
        {
            BeeDataAdapter dataAdapter = new BeeDataAdapter();
            dataAdapter.Add("value", value);
            using (DbSession dbSession = new DbSession(AuthConnString))
            {
                dbSession.Update("SystemConfig", dataAdapter, SqlCriteria.New.Equal("name", name));
            }

            DataMapping.Instance.Refresh("SystemConfig");

            // 刷新配置
            GBillSettingManager.Instance.RefreshMapping();
        }

    }
}
