using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory;

namespace AccessDal
{
    public class AccessFactory : IFactory
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
