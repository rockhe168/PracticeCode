using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqToProc
{
    public partial class Default : System.Web.UI.Page
    {
        NorthwindDataContext ctx = Dao.DataContextFactory.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //调用储存过程
                //create proc [dbo].[sp_singleresultset]
                //as 
                //set nocount on
                //select * from Customers
                var 单结果集储存过程 = from customer in ctx.sp_singleresultset()
                               select customer;


                //带参数的储存过程
                //create proc sp_withparameter
                //@customerid nchar(5),
                //@rowcount int output
                //as 
                //set nocount on
                //set @rowcount=(select COUNT(*) from Customers where CustomerID=@customerid)
                int? rowcount = -1;
                int result=ctx.sp_withparameter("", ref rowcount);

                Response.Write("储存过程返回的值为:"+rowcount);

                result = ctx.sp_withparameter("GODOS", ref rowcount);

                Response.Write("储存过程返回的值为:" + rowcount);


                //带返回值的存储过程
                //create proc sp_withreturnvalue
                //@customer nchar(5)
                //as
                //set nocount on
                //if exists(select 1 from Customers where CustomerID=@customer)
                //return 101
                //else 
                //return 100
                result = ctx.sp_withreturnvalue("");

                Response.Write("储存过程返回的值为:" + result);

                result = ctx.sp_withreturnvalue("GODOS");

                Response.Write("储存过程返回的值为:" + result);


                //储存过程返回多实体
                //create proc sp_multriresultset
                //as 
                //set nocount on
                //select * from Customers
                //select * from Employees


                //默认只返回第一个实体
                //var multri=from c in ctx.sp_multriresultset() select c;

                var 多结果集实体 = ctx.sp_multriresultset();

                //var customers = 多结果集实体.GetResult<Customers>();
               // var employees = 多结果集实体.GetResult<Employees>();

               // this.gvMain.DataSource = customers;
               // this.gvMain.DataBind();
            }
        }
    }
}