using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using AbstractFactory;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User() {UserId=1,UserName="Rock" };

            //获取工厂实例
            var dalFactory = IFactory.Instance;

            dalFactory.CreateUserDal().Insert(user);

            var selectUser = dalFactory.CreateUserDal().GetUserById(1);

            Console.ReadKey();

        }
    }
}
