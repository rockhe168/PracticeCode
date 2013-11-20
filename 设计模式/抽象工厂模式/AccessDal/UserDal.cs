using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory;
using Domain;

namespace AccessDal
{
    public class UserDal : IUserDal
    {
        public void Insert(User user)
        {
            Console.WriteLine("这里是Access User Inser Method....");
        }

        public User GetUserById(int userId)
        {
            var user = new User() { UserId = 1, UserName = "Rock" };

            Console.WriteLine("这里是Access User GetUserById Method....");

            return user;
        }
    }
}
