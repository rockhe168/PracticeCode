using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory;

namespace SqlServerDal
{
    public class SqlServerFactory:IFactory
    {
        public override IUserDal CreateUserDal()
        {
            return new UserDal();
        }

        public override IDepartmentDal CreateDepartmentDal()
        {
            return new DepartmentDal();
        }
    }
}
