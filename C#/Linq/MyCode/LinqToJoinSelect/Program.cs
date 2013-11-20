using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToJoinSelect
{

    /// <summary>
    /// 产品
    /// </summary>
    class Product
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal ProductPrice { get; set; }

    }

    class Order
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 订单价格
        /// </summary>
        public decimal TotalPrice { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var products=new List<Product>()
                                       {
                                           new Product(){ProductId = 1,ProductName = "Java编程思想",ProductPrice=99},
                                           new Product(){ProductId = 2,ProductName = ".net图解",ProductPrice = 55},
                                           new Product(){ProductId = 3,ProductName = ".net企业架构",ProductPrice = 78}
                                       };

            var orders = new List<Order>()
                             {
                                 new Order() { OrderId = 1, ProductId = 1, Number = 2, TotalPrice = 198 },
                                 new Order() { OrderId = 2, ProductId = 1, Number = 1, TotalPrice = 99 },
                                 new Order() { OrderId = 3, ProductId = 3, Number = 1, TotalPrice = 78 },
                                 new Order() { OrderId = 4, ProductId = 2, Number = 3, TotalPrice = 165 },
                                 new Order() { OrderId = 5, ProductId = 3, Number = 2, TotalPrice = 166 }
                             };



            //内部联接
            var showList = from order in orders
                           join product in products on order.ProductId equals product.ProductId
                           select new {order.OrderId,order.ProductId,product.ProductName,product.ProductPrice,order.Number,order.TotalPrice };

            foreach (var item in showList)
            {
                Console.WriteLine(item.OrderId+"-->"+item.ProductId+"-->"+item.ProductName+"-->"+item.Number+"-->"+item.ProductPrice+"-->"+item.TotalPrice);
            }

            //分组
            //var groupList= from item in showList group by 

            Console.ReadKey();
        }
    }


}
