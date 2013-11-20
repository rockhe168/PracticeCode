using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Service;
using ConfigAttribute.Attributes;

namespace ConfigAttribute.Service
{
    public class AttributeService : IService
    {
        [ConsoleDebug]
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
