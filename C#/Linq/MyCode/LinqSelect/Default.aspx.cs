using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqSelect
{
    public partial class Default : System.Web.UI.Page
    {
        NorthwindDataContext ctx = Dao.DataContextFactory.GetInstance();

        //NorthwindDataContext ctx = new NorthwindDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var 构建匿名类型1 = from c in ctx.Customers
                              select new { 公司名称 = c.CompanyName, 地址 = c.Address };

                var 构建匿名类型2 = from emp in ctx.Employees
                              select new
                              {
                                  姓名 = emp.LastName + emp.FirstName,
                                  雇用年 = emp.HireDate.Value.Year
                              };


                var 构建匿名类型3 = from c in ctx.Customers
                              select new
                              {
                                  ID = c.CustomerID,
                                  联系人 = new { 职位 = c.ContactTitle, 联系人 = c.ContactName }
                              };

                var select带条件 = from o in ctx.Orders
                                select new
                                {
                                    订单ID = o.OrderID,
                                    是否超重 = o.Freight > 100 ? "是" : "否"
                                };

                var select多条件 = from customer in ctx.Customers
                                where customer.Country.Equals("UK") && customer.Orders.Count > 5
                                select new
                                {
                                    顾客姓名=customer.ContactName,
                                    国家 = customer.Country,
                                    城市 = customer.City,
                                    订单数量 = customer.Orders.Count
                                };

                var 排序 = from emp in ctx.Employees
                         orderby emp.HireDate.Value.Year descending, emp.FirstName ascending
                         select new
                         {
                             工作开始年 = emp.HireDate.Value.Year,
                             姓名 = emp.FirstName + emp.LastName
                         };

                var 分页 = (from customer in ctx.Customers select customer).Skip(1).Take(5);
                //this.gvPager = (from customer in ctx.Customers select customer).Count();
                this.gvPager.DataSource = 分页;
                this.gvPager.DataBind();

                var 一般分组 = from customer in ctx.Customers
                           group customer by customer.Country into g
                           where g.Count() > 5
                           orderby g.Count() descending
                           select g;

                this.gvMain.DataSource = 一般分组;
                this.gvMain.DataBind();
            }
        }

        protected void gvPager_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var 下一页=(from customer in ctx.Customers select customer).Skip(e.NewPageIndex+1).Take(5);
            this.gvPager.DataSource = 下一页;
            this.gvPager.DataBind();
        }
    }
}