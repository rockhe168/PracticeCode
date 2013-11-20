using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;

namespace AbstractFactory
{
    public abstract class IFactory
    {

        public static IFactory Instance
        {
            get
            {
                IFactory cachefactory = null;

                string factoryName = System.Configuration.ConfigurationManager.AppSettings["DB"];

                //通过反射获取具体的依赖
                if (factoryName != null)
                    cachefactory = (IFactory)Assembly.Load(factoryName+"Dal").CreateInstance(factoryName+"Dal."+factoryName+"Factory");

                return cachefactory;
            }

        }

        public abstract IUserDal CreateUserDal();

        public abstract IDepartmentDal CreateDepartmentDal();
    }
}
