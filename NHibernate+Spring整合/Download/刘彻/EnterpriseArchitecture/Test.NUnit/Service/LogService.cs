using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IService.ICommon;
using IService.IProducts;
using NUnit.Framework;
using Spring.Context;
using Spring.Context.Support;

namespace Test.NUnit.Service
{
     [TestFixture]
    class LogService
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
            var logService = _applicationContext.GetObject("LogService") as ILogService;
            if (logService != null)
            {
                logService.WriteLog("riygldfkglkerio");
            }
        }
    }
}
