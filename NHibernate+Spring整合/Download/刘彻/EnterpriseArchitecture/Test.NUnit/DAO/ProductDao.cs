using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Hibernate.common;
using Domain.Entity;
using IDAO;
using NUnit.Framework;
using Spring.Context;
using Spring.Context.Support;

namespace Test.NUnit.DAO
{
     [TestFixture]
    class ProductDao
    {
        private IApplicationContext _applicationContext;
        [SetUp]
        public void Init()
        {
            _applicationContext = ContextRegistry.GetContext();
        }
        [Test]//OK
        public void TestAddGetAllProduct()
        {
            //var productDao = _applicationContext.GetObject("ProductDao") as IProductDao;
            //if (productDao != null)
            //{
            //    var productlist = productDao.GetAllProduct();
            //}
        }
    }
}
