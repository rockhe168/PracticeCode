using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

namespace LinqToFeature
{
    public partial class Default : System.Web.UI.Page
    {

        NorthwindDataContext ctx = Dao.DataContextFactory.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                //<一>延迟加载

                //由于有了延迟加载，所以以下每用一次query都会执行一次sql
                //IQueryable query = from customer in ctx.Customers select customer;
                //foreach (Customers item in query)
                //{
                //    Response.Write(item.CustomerID);
                //}
                //foreach (Customers item in query)
                //{
                //    Response.Write(item.CustomerID);
                //}

                //解决延迟加载，则可以用方法语法，立即查询，并缓存起来,然后再操做他。
                //IEnumerable<Customers> customers = (from customer in ctx.Customers select customer).ToList();
                //foreach (Customers customer in customers)
                //{
                //    Response.Write(customer.CustomerID);
                //}
                //foreach (Customers customer in customers)
                //{
                //    Response.Write(customer.ContactName);
                //}

                //那么，延迟加载的优点在哪里呢？
                //延迟执行的优点在于我们可以像拼接SQL那样拼接查询句法，然后再执行：
                var query = from customer in ctx.Customers select customer;//string sql=select * from customers
                var newquery = (from customer in query select customer).OrderBy(c => c.CustomerID);// sql+=" order by customerID";


                //<二>DataLoadOptions

                //1、问题
                //var products = from produc in ctx.Products select produc;
                //foreach (Products product in products)
                //{
                //    if (product.UnitPrice > 10)
                //        ShowDetail(product.Order_Details);//此处会导致n条sql被执行
                //}

                //2、解决以上问题则要用到DataLoadOptions
                //DataLoadOptions options = new DataLoadOptions();
                //options.LoadWith<Products>(p => p.Order_Details);//同时加载产品对于的订单信息
                //ctx.LoadOptions = options;
                //var products = from product in ctx.Products select product;
                //foreach (Products item in products)
                //{
                //    if (item.UnitPrice > 10)
                //        ShowDetail(item.Order_Details);
                //}

                //3、限制订单详细表的加载条件那？
                //DataLoadOptions options = new DataLoadOptions();
                //options.LoadWith<Products>(p => p.Order_Details);//同时加载产品对于的订单信息
                //options.AssociateWith<Products>(p=>p.Order_Details.Where(od=>od.Quantity>80));//限制
                //ctx.LoadOptions = options;
                //var products = from product in ctx.Products select product;
                //foreach (Products item in products)
                //{
                //    if (item.UnitPrice > 10)
                //        ShowDetail(item.Order_Details);
                //}



                //<三>DataLoadOptions限制
                //1、Linq to sql对DataLoadOptions的使用是有限制的，它只支持1个1对多的关系。一个顾客可能有多个订单，一个订单可能有多个详细订单：
                //DataLoadOptions options = new DataLoadOptions();
                //options.LoadWith<Customers>(customer => customer.Orders);//第一个一对多
                //options.LoadWith<Orders>(order => order.Order_Details);//第二个一对多，则会导致N(n=orders.count())条sql语句被执行
                //ctx.LoadOptions = options;
                ////立即执行
                //IEnumerable<Customers> customers = ctx.Customers.ToList();


                //2、而对于多对1的关系，Linq to sql对于DataLoadOptions没有限制：
                //DataLoadOptions options = new DataLoadOptions();
                //options.LoadWith<Products>(product=>product.Categories);
                //options.LoadWith<Products>(product =>product.Order_Details);
                //options.LoadWith<Order_Details>(od=>od.Orders);
                //ctx.LoadOptions = options;
                //IEnumerable<Products> products = ctx.Products.ToList<Products>();


                //<四>主键缓存
                //1、Linq to sql对查询过的对象进行缓存，之后的如果只根据主键查询一条记录的话会直接从缓存中读取
                Customers customer1 = ctx.Customers.Single(c => c.CustomerID == "ANATR");
                customer1.ContactName = "Rock";
                Customers customer2 = ctx.Customers.Single(c => c.CustomerID == "ANATR");
                Response.Write(customer2.ContactName);
                //this.gvMain.DataSource = newquery;
                //this.gvMain.DataBind();
            }
        }

        private void ShowDetail(System.Data.Linq.EntitySet<Order_Details> entitySet)
        {
            foreach (Order_Details o in entitySet)
            {
                Response.Write(o.Quantity+"<br>");
            }
        }
    }
}