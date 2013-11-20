using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bee.Web;
using Bee.BLL;

namespace Bee.Models
{
    public class BillColumnSetting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 0:初始值， 1：默认值
        /// </summary>
        public int SettingType { get; set; }
        public int BillId { get; set; }
        public int UserId { get; set; }
        public string Setting { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }


        public List<BillColumnField> ColumnList
        {
            get
            {
                List<BillColumnField> result = new List<BillColumnField>();
                List<string> temp = this.Setting.Split(',').ToList();

                BillColumnMapping billColumnMapping = GBillSettingManager.Instance[BillId];
                foreach (string item in temp)
                {
                    BillColumnField value = (from billColumnField in billColumnMapping.ColumnMapping
                                             where billColumnField.Name == item
                                             select billColumnField).FirstOrDefault();
                    if (value != null)
                    {
                        result.Add(value);
                    }
                }

                return result;
            }
        }
    }
}
