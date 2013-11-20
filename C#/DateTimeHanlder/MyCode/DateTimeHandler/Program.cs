using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeHandler
{
    class Program
    {

        static void Main(string[] args)
        {
            DateTime currentDateTime = DateTime.Now;

            Console.WriteLine(currentDateTime.ToString("yyyy-MM-dd hh:mm:ss"));

            Console.WriteLine(currentDateTime.ToString("yyyy-MM-dd HH:mm:ss"));

            Console.ReadKey();

        }
    }
}
