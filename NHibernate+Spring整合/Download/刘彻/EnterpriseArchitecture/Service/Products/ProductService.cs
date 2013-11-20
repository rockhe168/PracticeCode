using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.common;
using IDAO;
using Domain.Entity;
using IInteraction;
using IService.IProducts;

namespace Service.Products
{
    /// <summary>
    /// 产品服务类
    /// Service(服务层)为系统业务整合区，这里完成简单或复杂的应用逻辑，服务层整合Domain领域对象的领域逻辑和DAO数据的存取
    /// 最终完成一定粒度的功能(如：一个用例--添加文章)。各个服务之间可以平行调用，但须以类似调用DAO方法一样使用接口通信
    /// 以便组合完成一个更大粒度的功能方法(服务)。
    /// </summary>
    public class ProductService : IProductService
    {
        private IProductDao ProductDao { get; set; }
        private IProductSI ProductSI { get; set; }
        private ILogHelper LogHelper { get; set; }
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            List<Product> productlist=new List<Product>();
            try
            {
                productlist=ProductDao.GetList();
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("ProductService.GetAllProducts()异常", e);
                return productlist;
            }
            return productlist;
        }
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProductsByWebService()
        {
            List<Product> productlist = new List<Product>();
            try
            {
                productlist = ProductSI.GetAllProducts();
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("ProductService.GetAllProductsByWebService()异常", e);
                return productlist;
            }
            return productlist;
        }
    }
}
