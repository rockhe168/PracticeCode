using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 原型模式_简历复制_浅复制_
{
    /// <summary>
    /// 简历
    /// </summary>
    class Resume:ICloneable
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        protected WorkExperience WorkExperience { get; set; }

        public Resume(string name)
        {
            this.Name = name;
            WorkExperience=new WorkExperience();
        }


        /// <summary>
        /// 设置个人信息
        /// </summary>
        /// <param name="sex"></param>
        /// <param name="age"></param>
        public void SetPersonInfo(string sex, int age)
        {
            this.Sex = sex;
            this.Age = age;
        }

        /// <summary>
        /// 设置工作经历
        /// </summary>
        /// <param name="date"></param>
        /// <param name="companyName"></param>
        public void SetWorkExperience(string date, string companyName)
        {
            this.WorkExperience.WorkDate = date;
            this.WorkExperience.CompanyName = companyName;
        }

        /// <summary>
        /// 显示
        /// </summary>
        public void Display()
        {
            Console.WriteLine("{0} {1} {2}",this.Name,this.Age,this.Sex);
            Console.WriteLine("工作经历：{0} {1}",this.WorkExperience.WorkDate,this.WorkExperience.CompanyName);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
