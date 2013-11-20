using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 简易计算器
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("请输入数字A：");
                string numberA = Console.ReadLine();
                Console.Write("请输入运算符号:");
                string operation = Console.ReadLine();
                Console.Write("请输入数字B：");
                string numberB = Console.ReadLine();

                Operation oper = OperationFactory.createOperation(operation);
                oper.NumberA = double.Parse(numberA);
                oper.NumberB = double.Parse(numberB);

                Console.WriteLine("运算结果为--->"+oper.GetResult());

                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("你输入有错误："+ex.Message);
                Console.ReadLine();
            }
        }
    }
}
