using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace AbstractFactory
{
    public interface IUserDal
    {
        void Insert(User user);
        User GetUserById(int userId);
    }
}
