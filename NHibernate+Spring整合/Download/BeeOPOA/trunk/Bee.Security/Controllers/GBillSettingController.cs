using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bee.Models;
using Bee.Web;
using Bee.BLL;
using System.Data;
using Bee.Security;

namespace Bee.Security.Controllers
{
    public class GBillSettingController : AuthControllerBase
    {
        static GBillSettingController()
        {
            DataMapping.Instance.Register("BillMapping", () =>
            {
                return DataDictManager.Instance.GetDataDict("BillMapping");
            });
        }

        public PageResult Index()
        {
            return View("Index");
        }

        public PageResult Detail(int billId, int settingId)
        {
            BillColumnMapping billColumnMapping = GBillSettingManager.Instance[billId];
            if (billColumnMapping != null)
            {
                ViewData["All"] = billColumnMapping.ColumnMapping;

                BillColumnSetting billColumnSetting = GBillSettingManager.Instance.GetBillColumnSetting(settingId);
                ViewData.Merge(BeeDataAdapter.From<BillColumnSetting>(billColumnSetting), false);

                List<BillColumnField> setting = new List<BillColumnField>();
                if (billColumnSetting != null)
                {
                    setting = billColumnSetting.ColumnList;
                }
                else
                {
                    setting = GBillSettingManager.Instance.GetBillColumnSetting(1, billId);
                }

                ViewData["Setting"] = setting;
            }

            return View("Detail");
        }

        public List<string> SettingList(int billId)
        {
            List<BillColumnSetting> list = GBillSettingManager.Instance.GetBillColumnSettingFromCache(AuthManager.Instance.CurrentUser.Id);
            List<string> result = (from item in list
                                   where item.BillId == billId
                                   orderby item.SettingType descending
                                   select string.Format("{0}${1}", item.Id, item.Name)).ToList();
            if (result.Count == 0)
            {
                list = GBillSettingManager.Instance.GetBillColumnSettingFromCache(1);
                result = (from item in list
                          where item.BillId == billId
                          orderby item.SettingType descending
                          select string.Format("{0}${1}", item.Id, item.Name)).ToList();
            }

            return result;
        }

        public void Save(BeeDataAdapter dataAdapter)
        {
            int billId = dataAdapter.TryGetValue<int>("billId", 0);
            int id = dataAdapter.TryGetValue<int>("id", 0);
            string setting = dataAdapter.TryGetValue<string>("setting", string.Empty);
            string name = dataAdapter.TryGetValue<string>("name", string.Empty);
            int settingType = dataAdapter.TryGetValue<int>("settingtype", 0);
            GBillSettingManager.Instance.SaveBillColumnSetting(AuthManager.Instance.CurrentUser.Id, billId
                , id, name, setting, settingType);
        }
    }
}
