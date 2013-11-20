using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 原型模式_简历复制_浅复制_
{
    class Program
    {
        static void Main(string[] args)
        {
            var rock = new Resume("何湘红");
            rock.SetPersonInfo("男",26);
            rock.SetWorkExperience("2013","携程");


            var rock2=(Resume)rock.Clone();
            rock2.SetPersonInfo("男",25);
            rock2.SetWorkExperience("2011","海航>上海集付通");


            rock.Display();
            rock2.Display();


            Console.ReadKey();
        }
    }
}
