using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{

    class A
    {
        public A()
        {
            PrintFields();
        }
        public virtual void PrintFields() { }
    }

    internal class B : A
    {
        private int x = 1;
        private int y;

        public B()
        {
            y = -1;
        }

        public override void PrintFields()
        {
            Console.WriteLine("x={0},y={1}", x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var b = new B();
            Console.ReadKey();
        }
    }
}
