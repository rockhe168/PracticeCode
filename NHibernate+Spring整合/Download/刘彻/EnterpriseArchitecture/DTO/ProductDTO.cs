using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace DTO
{
    /// <summary>
    /// 远程访问-产品数据传输对象
    /// 定义数据契约
    /// </summary>
    [DataContract]
    public class ProductDTO
    {
        private string _productName = string.Empty;
        private string _quantityPerUnit = string.Empty;
        [DataMember]
        public int Id { set; get; }
        [DataMember]
        public string ProductName
        {
            set { _productName = HttpUtility.HtmlEncode(value); }
            get { return _productName; }
        }
        [DataMember]
        public string QuantityPerUnit
        {
            set { _quantityPerUnit = HttpUtility.HtmlEncode(value); }
            get { return _quantityPerUnit; }
        }
        [DataMember]
        public decimal? UnitPrice { set; get; }
        [DataMember]
        public short? UnitsInStock { set; get; }
    }
}
