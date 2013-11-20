using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Web;
using Bee.Data;
using Bee;
using Bee.Util;
using System.Data;
using System.IO;
using System.Text;
using Bee.BLL;
using Bee.Security;
using Bee.Models;

namespace Bee.Security.Controllers
{
    public partial class ConfigController : AuthControllerBase
    {
        static ConfigController()
        {
            DataDictManager.Instance.RegistDataMappingAll();
        }

        public PageResult PTIndex()
        {
            return View();
        }

        public void PTSave(PrintTemplate value)
        {
            using (DbSession dbSession = GetDbSession())
            {
                dbSession.Save(value);
            }
        }

        public List<string> PTList(string pttype)
        {
            using (DbSession dbSession = GetDbSession())
            {
                BeeDataAdapter dataAdapter = new BeeDataAdapter();
                dataAdapter.Add("pttype", pttype);
                List<PrintTemplate> list = dbSession.ExecuteCommand<PrintTemplate>(@"select id, title, type
from printtemplate
where pttype = @pttype and type < 100 order by type desc", dataAdapter);

                return (from item in list select string.Format("{0}${1}", item.Id, item.Title)).ToList();
            }
        }

        public PageResult PTEdit(int id, int pttype)
        {
            using (DbSession dbSession = GetDbSession())
            {
                ViewData["type"] = 1;
                PrintTemplate printTemplate = dbSession.Query<PrintTemplate>(SqlCriteria.New.Equal("id", id)).FirstOrDefault();

                if (printTemplate != null)
                {
                    ViewData.Merge(BeeDataAdapter.From(printTemplate), true);
                }

                PrintTemplate description = dbSession.Query<PrintTemplate>(
                        SqlCriteria.New
                        .Equal("type", 100)).FirstOrDefault();
                if (description != null)
                {
                    ViewData["content2"] = HttpUtility.HtmlDecode(description.Content);
                }

                return View();
            }
        }

        public PageResult DataDict()
        {
            using (DbSession dbSession = GetDbSession())
            {
                return View(dbSession.Query("datadict", null));
            }
        }

        public PageResult DataDictDetail(int id)
        {
            DataTable result = null;
            using (DbSession dbSession = GetDbSession())
            {
                DataTable dataTable = dbSession.Query("datadict", SqlCriteria.New.Equal("id", id));
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    ViewData.Merge(BeeDataAdapter.From(dataTable.Rows[0]), true);
                }

                result = dbSession.Query("datadictmapping", SqlCriteria.New.Equal("datadictid", id));
            }

            return View(result);
        }

        public void DataDictSave(BeeDataAdapter dataAdapter)
        {
            using (DbSession dbSession = GetDbSession(true))
            {
                DataDict dataDict = ConvertUtil.ConvertDataToObject<DataDict>(dataAdapter);
                dbSession.Save(dataDict);

                dbSession.Delete<DataDictMapping>(SqlCriteria.New.Equal("datadictid", dataDict.Id));
                int itemNum = dataAdapter.TryGetValue<int>("bee_itemNum", 0);
                for (int i = 0; i < itemNum; i++)
                {
                    DataDictMapping detail = new DataDictMapping();
                    detail.DataDictId = dataDict.Id;

                    detail.OptionId = dataAdapter.TryGetValue<string>("items[{0}].optionid".FormatWith(i), string.Empty);
                    detail.OptionValue = dataAdapter.TryGetValue<string>("items[{0}].optionvalue".FormatWith(i), string.Empty);
                    detail.EnableFlag = dataAdapter.TryGetValue<bool>("items[{0}].enableflag".FormatWith(i), false);

                    dbSession.Save(detail);
                }

                dbSession.CommitTransaction();

                DataMapping.Instance.Refresh(dataDict.Name);
            }
        }

        public string SelectDataDict(string name, string dictName)
        {
            HtmlBuilder htmlBuilder = HtmlBuilder.New.tag("select").attr("class", "combox").attr("name", name);
            DataTable dataTable = DataDictManager.Instance.GetDataDict(dictName);
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    htmlBuilder.include(HtmlBuilder.New.tag("option").attr("value", row["id"]).text(row["name"]).end);
                }
            }

            return htmlBuilder.end.ToString();
        }

        public PageResult BillMapping()
        {
            return View();
        }
    }
}
