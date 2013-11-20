using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory;
using Domain;

namespace SqlServerDal
{
    public class UserDal:IUserDal
    {
        public void Insert(Domain.User user)
        {
            Console.WriteLine("这里是SqlServer User Inser Method....");
        }

        public User GetUserById(int userId)
        {
            var user = new User() { UserId=1, UserName="Rock"};

            Console.WriteLine("这里是SqlServer User GetUserById Method....");

            return user;
        }
    }
}
