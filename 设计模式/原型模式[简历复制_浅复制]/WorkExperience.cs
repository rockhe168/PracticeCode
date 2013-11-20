using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 原型模式_简历复制_浅复制_
{

    /// <summary>
    /// 工作经历
    /// </summary>
    class WorkExperience
    {
        //public WorkExperience(string workDate, string companyName)
        //{
        //    this.WorkDate = workDate;
        //    this.CompanyName = companyName;
        //}

        public string WorkDate { get; set; }

        public string CompanyName { get; set; }
    }
}
