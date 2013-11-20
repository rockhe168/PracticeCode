using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAO;
using IService.IProducts;
using NUnit.Framework;
using Spring.Context;
using Spring.Context.Support;

namespace Test.NUnit.Service
{
     [TestFixture]
    class ProductService
    {
        private IApplicationContext _applicationContext;
        [SetUp]
        public void Init()
        {
            _applicationContext = ContextRegistry.GetContext();
        }
        [Test]//OK
        public void TestGetAllProducts()
        {
            var productService = _applicationContext.GetObject("ProductService") as IProductService;
            if (productService != null)
            {
                var productlist = productService.GetAllProducts();
            }
        }
    }
}
