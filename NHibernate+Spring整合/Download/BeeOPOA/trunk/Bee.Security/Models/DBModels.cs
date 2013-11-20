using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bee.Models
{
    public class DataDict
    {
        #region Properties

        public Int32 Id { get; set; }
        public Int32 UserId { get; set; }
        public String Title { get; set; }
        public String Name { get; set; }
        public Int32 ParentId { get; set; }
        public DateTime ModifyTime { get; set; }

        #endregion
    }

    public class DataDictMapping
    {
        public int Id { get; set; }
        public int DataDictId { get; set; }
        public string OptionId { get; set; }
        public string OptionValue { get; set; }
        public bool EnableFlag { get; set; }
    }

    public class PrintTemplate
    {
        #region Properties

        public Int32 Id { get; set; }
        public String Title { get; set; }
        public Int32 PTType { get; set; }
        public Int32 Type { get; set; }
        public String Content { get; set; }
        public DateTime ModifyTime { get; set; }

        #endregion
    }

    public class BillType
    {
        #region Properties

        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Name { get; set; }
        public String Format { get; set; }

        #endregion

    }

    public class BillTypeConfig
    {
        #region Properties

        public Int32 Id { get; set; }
        public String BillType { get; set; }
        public Int32 BillDate { get; set; }
        public Int32 LastId { get; set; }
        public DateTime ModifyTime { get; set; }

        #endregion

    }
}
