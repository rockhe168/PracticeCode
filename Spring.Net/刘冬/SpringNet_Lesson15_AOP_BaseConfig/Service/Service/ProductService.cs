using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Service
{
    public class ProductService : IService
    {
        public IList FindAll()
        {
            return new ArrayList();
        }

        public void Save(object entity)
        {
            Console.WriteLine("保存：" + entity);
        }
    }
}
