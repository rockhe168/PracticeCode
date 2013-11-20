using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Bee.Caching;
using Bee.Data;
using Bee;
using Bee.Util;

namespace Bee.BLL
{
    public class DataDictManager
    {
        private static DataDictManager instance = new DataDictManager();

        private DataDictManager()
        {
        }

        public static DataDictManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void RegistDataMappingAll()
        {
            using (DbSession dbSession = new DbSession(ConfigUtil.GetAppSettingValue<string>("Bee.Auth.DataSource")))
            {
                DataTable dataTable = dbSession.Query("datadict", null);
                foreach (DataRow row in dataTable.Rows)
                {
                    string name = row["name"].ToString();
                    DataMapping.Instance.Register(name, () =>
                    {
                        return GetDataDict(name);
                    });
                }
            }
        }

        public DataTable GetDataDict(string dictName)
        {
            using (DbSession dbSession = new DbSession(ConfigUtil.GetAppSettingValue<string>("Bee.Auth.DataSource")))
            {
                string sql = @"select b.optionid as id, b.optionvalue as name
from datadict a left join datadictmapping b on a.id = b.datadictid
where a.name = @name and b.enableflag = 1";
                BeeDataAdapter dataAdapter = new BeeDataAdapter();
                dataAdapter.Add("name", dictName);

                return dbSession.ExecuteCommand(sql, dataAdapter);
            }
        }
    }
}
