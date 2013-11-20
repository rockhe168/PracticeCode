using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 工厂方法模式_计算器_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入数字A：");
            string numberA = Console.ReadLine();
            Console.Write("请输入运算符号:");
            string operation = Console.ReadLine();
            Console.Write("请输入数字B：");
            string numberB = Console.ReadLine();

            IFactory factory = null;

            //把运算逻辑放到客户端调用层，方便抽象产品的扩展
            switch (operation)
            {
                case "+":
                    factory = new AddFactory();
                    break;
                case "-":
                    factory = new SubFactory();
                    break;
                case "*":
                    factory = new MultFactory();
                    break;
                case "/":
                    factory = new DevFactory();
                    break;
                default:
                    break;
            }

           Operation oper= factory.CreateOperation();
           oper.NumberA = double.Parse(numberA);
           oper.NumberB = double.Parse(numberB);
           Console.WriteLine("运算结果为--->" + oper.GetResult());

           Console.ReadKey();
        }
    }
}
