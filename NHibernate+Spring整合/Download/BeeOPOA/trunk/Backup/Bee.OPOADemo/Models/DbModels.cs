using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bee.OPOADemo.Models
{
    public class Employee
    {
        #region Properties

        public Int32 Id { get; set; }
        public String UserName { get; set; }
        public Int32 Sex { get; set; }
        public DateTime Birthday { get; set; }
        public String Nation { get; set; }
        public Int32 PartyId { get; set; }
        public Int32 EducationId { get; set; }
        public String Jiguan { get; set; }
        public Int32 MarryId { get; set; }
        public Int32 HealthId { get; set; }
        public String ShenFenId { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String Abode { get; set; }
        public String Remark { get; set; }
        public Int32 UserId { get; set; }
        public Int32 DepartmentId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public Boolean DelFlag { get; set; }

        #endregion

    }

    [Bee.Data.OrmTable(TableName = "Employee")]
    [Bee.Web.Model(PageSize = 15, DefaultOrderAscFlag=true)]
    public class User
    {
        #region Properties

        [Bee.Web.ModelProperty(OrderableFlag = true)]
        public Int32 Id { get; set; }

        [Bee.Web.ModelProperty(Description="姓名", OrderableFlag=true,
            Queryable = true, QueryType=Bee.Web.ModelQueryType.Contains)]
        public String UserName { get; set; }

        [Bee.Web.ModelProperty(Description = "部门", MappingName = "DepartmentInfo"
            , Queryable = true, QueryType = Bee.Web.ModelQueryType.Equal)]
        public Int32 DepartmentId { get; set; }

        [Bee.Web.ModelProperty(Description="性别", OrderableFlag=false,MappingName="SexInfo")]
        public int Sex { get; set; }

        [Bee.Web.ModelProperty(Description = "生日", Queryable = true, QueryType = Bee.Web.ModelQueryType.Between)]
        public DateTime Birthday { get; set; }

        [Bee.Web.ModelProperty(Description = "民族")]
        public String Nation { get; set; }

        [Bee.Web.ModelProperty(Description = "政治面貌",  MappingName="PartyInfo")]
        public Int32 PartyId { get; set; }

        [Bee.Web.ModelProperty(Description = "文化程度", MappingName = "EducationInfo")]
        public Int32 EducationId { get; set; }

        [Bee.Web.ModelProperty(Description = "籍贯")]
        public String Jiguan { get; set; }

        [Bee.Web.ModelProperty(Description = "婚姻状况",  MappingName="MarriageInfo")]
        public Int32 MarryId { get; set; }

        [Bee.Web.ModelProperty(Description = "健康状况", MappingName = "HealthInfo")]
        public Int32 HealthId { get; set; }

        [Bee.Web.ModelProperty(Description = "身份证号")]
        public String ShenFenId { get; set; }
        [Bee.Web.ModelProperty(Description = "联系电话", Visible=false)]
        public String Phone { get; set; }

        [Bee.Web.ModelProperty(Description = "家庭地址", Visible=false)]
        public String Address { get; set; }
        [Bee.Web.ModelProperty(Description = "现居住地址", Visible = false)]
        public String Abode { get; set; }

        [Bee.Web.ModelProperty(Description = "个人简介", Visible = false)]
        public String Remark { get; set; }

        [Bee.Web.ModelProperty(Visible = false)]
        public Int32 UserId { get; set; }

        

        [Bee.Web.ModelProperty(Visible = false)]
        public DateTime CreateTime { get; set; }

        [Bee.Web.ModelProperty(Visible = false)]
        public DateTime UpdateTime { get; set; }

        #endregion

    }
}
