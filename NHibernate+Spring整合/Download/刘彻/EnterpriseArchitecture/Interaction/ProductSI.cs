using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using IInteraction;
using Interaction.WebHost;

namespace Interaction
{
    /// <summary>
    /// 产品系统交互层
    /// System Interaction定义了系统交互层，本系统一切和外部系统交互的实现都在这里完成，在经过Service层到达Service
    /// 以上的层，注意这里并没有核心的业务逻辑，这里只起到访问的作用，已经数据类型转化、有效性验证等作用。
    /// 交由Service来完成具体的业务给系统使用。
    /// </summary>
    public class ProductSI : IProductSI
    {
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            List<Product> list=new List<Product>();
            WebHost.ProductFacadeClient c = new ProductFacadeClient();
            List<ProductDTO> products = c.GetAllProducts();
            foreach (var productDto in products)
            {
                Product product=new Product();
                product.Id = productDto.Id;
                product.ProductName = productDto.ProductName;
                product.QuantityPerUnit = productDto.QuantityPerUnit;
                product.UnitPrice = productDto.UnitPrice;
                product.UnitsInStock = productDto.UnitsInStock;
                list.Add(product);
            }
            return list;
        }
    }
}
