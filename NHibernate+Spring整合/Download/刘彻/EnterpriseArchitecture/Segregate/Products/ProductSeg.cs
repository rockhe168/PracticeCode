using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISegregate.IProducts;
using IService.ICommon;
using IService.IProducts;
using Model.Products;

namespace Segregate.Products
{
    /// <summary>
    /// 产品隔离类
    ///  Segregate层将Domain中的数据类型转化为表现层MVC中Model的数据类型，反之依然。
    /// 本层作为表现层和应用逻辑层的门户而使用，表现层不能跨层调用应用逻辑层及
    /// 以下的层代码。在特殊情况下，本层亦可充当数据验证、净化，Service层下异常处理等职能。
    /// </summary>
    public class ProductSeg : IProductSeg
    {
        private IProductService ProductService { get; set; }
        private ILogService LogService { get; set; }
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        public List<ProductList> GetAllProducts()
        {
            List<ProductList> list = new List<ProductList>();
            var products = ProductService.GetAllProducts();
            try
            {
                foreach (var product in products)
                {
                    ProductList prod = new ProductList();
                    prod.Id = product.Id;
                    prod.ProductName = product.ProductName;
                    prod.QuantityPerUnit = product.QuantityPerUnit;
                    prod.UnitPrice = product.UnitPrice;
                    prod.UnitsInStock = product.UnitsInStock;
                    list.Add(prod);
                }
            }
            catch (Exception e)
            {
                LogService.WriteLog("ProductSeg.GetAllProducts()异常", e);
            }
            return list;
        }
        /// <summary>
        /// 获取产品，通过WebService
        /// </summary>
        /// <returns></returns>
        public List<ProductList> GetAllProductsByWebService()
        {
            List<ProductList> list = new List<ProductList>();
            var products = ProductService.GetAllProductsByWebService();
            try
            {
                foreach (var product in products)
                {
                    ProductList prod = new ProductList();
                    prod.Id = product.Id;
                    prod.ProductName = product.ProductName;
                    prod.QuantityPerUnit = product.QuantityPerUnit;
                    prod.UnitPrice = product.UnitPrice;
                    prod.UnitsInStock = product.UnitsInStock;
                    list.Add(prod);
                }
            }
            catch (Exception e)
            {
                LogService.WriteLog("ProductSeg.GetAllProductsByWebService()异常", e);
            }
            return list;

        }
    }
}
