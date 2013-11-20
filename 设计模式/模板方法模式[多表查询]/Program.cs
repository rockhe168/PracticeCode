using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 模板方法模式_多表查询_
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccessObject dao;

            dao=new CategoriesDataAccess();
            dao.Run();

            dao=new ProductsDataAccess();
            dao.Run();


            Console.ReadKey();
        }
    }
}
