using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Model.Products
{
    public class ProductList
    {
        private string _productName=string.Empty;
        private string _quantityPerUnit = string.Empty;

        public int Id { set; get; }
        public string ProductName
        {
            set { _productName = HttpUtility.HtmlEncode(value); }
            get { return _productName; }
        }
        public string QuantityPerUnit
        {
            set { _quantityPerUnit = HttpUtility.HtmlEncode(value); }
            get { return _quantityPerUnit; }
        }
        public decimal? UnitPrice { set; get; }
        public short? UnitsInStock { set; get; }
    }
}
