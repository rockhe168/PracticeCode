using System;
using System.Collections.Generic;
using DTO;
using IFacade.IProducts;
using IService.ICommon;
using IService.IProducts;

namespace Facade.Products
{
    /// <summary>
    /// 产品隔离类
    /// Facade定义为远程外观模式。Service已经是业务层，在远程调用中为了降低通信量，常常在Service之上在
    /// 加上一层外观模式，整合一个或多个Service，它是远程调用的入口，也是服务契约的实现，同事在这里也可以
    ///充当数据验证、净化，Service层下异常处理等职能。
    /// </summary>
    public class ProductFacade : IProductFacade
    {
        private IProductService ProductService { get; set; }
        private ILogService LogService { get; set; }
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> list = new List<ProductDTO>();
            var products = ProductService.GetAllProducts();
            try
            {
                foreach (var product in products)
                {
                    ProductDTO prod = new ProductDTO();
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
    }
}
