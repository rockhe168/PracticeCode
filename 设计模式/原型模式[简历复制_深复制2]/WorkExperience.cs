using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 原型模式_简历复制_深复制2_
{
    class WorkExperience:ICloneable
    {
        

        public string WorkDate { get; set; }

        public string CompanyName { get; set; }

        public object Clone()
        {
            return  this.MemberwiseClone();
        }
    }
}
