using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;

namespace LinqToConcurrentWithTransaction
{
    public partial class Default : System.Web.UI.Page
    {
        NorthwindDataContext ctx = Dao.DataContextFactory.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //检测并发
                
                ////<一>默认，总是检查  列特性UpdateCheck=UpdateCheck.Always
                ////修改Db，使测试环境更明朗sql=update Products set UnitPrice=25,UnitsInStock=38 where CategoryID=1
                //var products = from p in ctx.Product where p.CategoryID == 1 select p;

                //foreach (Product p in products)
                //{
                //    p.UnitsInStock =Convert.ToInt16(p.UnitsInStock - 1);//库存减1
                //}

                ////程序提交之前，执行sql=update Products set UnitPrice=UnitPrice+1,UnitsInStock=UnitsInStock-2 where CategoryID=1  --执行完后UnitPrice=26，UnitsInStock=36
                //ctx.SubmitChanges();//执行此处时，抛System.Data.Linq.ChangeConflictException {"找不到行或行已更改。"}  ,数据库数据由sql更改，程序未更改



                ////<二>从不检查  列特UpdateCheck=UpdateCheck.Never
                ////修改Db，使测试环境更明朗sql=update Products set UnitPrice=25,UnitsInStock=38 where CategoryID=1
                //var products = from p in ctx.Product where p.CategoryID == 1 select p;

                //foreach (Product p in products)
                //{
                //    p.UnitsInStock = Convert.ToInt16(p.UnitsInStock - 1);//库存减1
                //}

                ////程序提交之前，执行sql=update Products set UnitPrice=UnitPrice+1,UnitsInStock=UnitsInStock-2 where CategoryID=1  --执行完后UnitPrice=26，UnitsInStock=36
                //ctx.SubmitChanges();//执行结果为： UnitPrice=27，由sql语句的update生效，但UnitsInStock=37，此处程序的SubmitChanges覆盖了sql语句的update这个字段。



                ////<三>仅在已更改对象后检查。  列特UpdateCheck=UpdateCheck.WhenChanged
                ////修改Db，使测试环境更明朗sql=update Products set UnitPrice=25,UnitsInStock=38 where CategoryID=1
                //var products = from p in ctx.Product where p.CategoryID == 1 select p;

                //foreach (Product p in products)
                //{
                //    p.UnitsInStock = Convert.ToInt16(p.UnitsInStock - 1);//库存减1
                //}

                ////程序提交之前，执行sql=update Products set UnitPrice=UnitPrice+1,UnitsInStock=UnitsInStock-2 where CategoryID=1  --执行完后UnitPrice=26，UnitsInStock=36
                //ctx.SubmitChanges();//执行此处时，抛System.Data.Linq.ChangeConflictException {"找不到行或行已更改。"}  ,数据库数据由sql更改，程序未更改













                //有以上三种情况，当列特UpdateCheck=UpdateCheck.Never 是会导致数据并发
                //解决并发
                ////方法一：Resolve(RefreshMode.OverwriteCurrentValues);放弃当前更新，所有更新以原先更新为准
                ////修改Db，使测试环境更明朗sql=update Products set UnitPrice=25,UnitsInStock=38 where CategoryID=1
                //var products = from p in ctx.Product where p.CategoryID == 1 select p;

                //foreach (Product p in products)
                //{
                //    p.UnitsInStock = Convert.ToInt16(p.UnitsInStock - 1);//库存减1
                //}
                //try
                //{
                //    ctx.SubmitChanges(ConflictMode.ContinueOnConflict);//程序提交之前，执行sql=update Products set UnitPrice=UnitPrice+1,UnitsInStock=UnitsInStock-2 where CategoryID=1  --执行完后UnitPrice=26，UnitsInStock=36
                //}
                //catch (ChangeConflictException)
                //{
                //    foreach (ObjectChangeConflict cc in ctx.ChangeConflicts)
                //    {
                //        Product product = (Product)cc.Object;
                //        Response.Write(product.ProductID + "<br>");
                //        cc.Resolve(RefreshMode.OverwriteCurrentValues); // 放弃当前更新，所有更新以原先更新为准 执行结果：UnitPrice=26，UnitsInStock=36，放弃当前程序更新
                //    }
                //}

                ////方法二：Resolve(RefreshMode.KeepChanges); 原先更新有效，冲突字段以当前更新为准
                ////修改Db，使测试环境更明朗sql=update Products set UnitPrice=25,UnitsInStock=38 where CategoryID=1
                //var products = from p in ctx.Product where p.CategoryID == 1 select p;

                //foreach (Product p in products)
                //{
                //    p.UnitsInStock = Convert.ToInt16(p.UnitsInStock - 1);//库存减1
                //}
                //try
                //{
                //    ctx.SubmitChanges(ConflictMode.ContinueOnConflict);//程序提交之前，执行sql=update Products set UnitPrice=UnitPrice+1,UnitsInStock=UnitsInStock-2 where CategoryID=1  --执行完后UnitPrice=26，UnitsInStock=36
                //}
                //catch (ChangeConflictException)
                //{
                //    foreach (ObjectChangeConflict cc in ctx.ChangeConflicts)
                //    {
                //        Product product = (Product)cc.Object;
                //        Response.Write(product.ProductID + "<br>");
                //        cc.Resolve(RefreshMode.KeepChanges);// 原先更新有效，冲突字段以当前更新为准 执行结果：UnitPrice=26，UnitsInStock=36，放弃当前程序更新
                //    }
                //}

                //方法三：Resolve(RefreshMode.KeepCurrentValues);放弃原先更新，所有更新以当前更新为准
                //修改Db，使测试环境更明朗sql=update Products set UnitPrice=25,UnitsInStock=38 where CategoryID=1
                //var products = from p in ctx.Product where p.CategoryID == 1 select p;

                //foreach (Product p in products)
                //{
                //    p.UnitsInStock = Convert.ToInt16(p.UnitsInStock - 1);//库存减1
                //}
                //try
                //{
                //    ctx.SubmitChanges(ConflictMode.ContinueOnConflict);//程序提交之前，执行sql=update Products set UnitPrice=UnitPrice+1,UnitsInStock=UnitsInStock-2 where CategoryID=1  --执行完后UnitPrice=26，UnitsInStock=36
                //}
                //catch (ChangeConflictException)
                //{
                //    foreach (ObjectChangeConflict cc in ctx.ChangeConflicts)
                //    {
                //        Product product = (Product)cc.Object;
                //        Response.Write(product.ProductID + "<br>");
                //        cc.Resolve(RefreshMode.KeepCurrentValues);// 放弃原先更新，所有更新以当前更新为准 执行结果：UnitPrice=26，UnitsInStock=36，放弃当前程序更新
                //    }
                //}








                //事务

                //Customers customer=new Customers();
                //customer.CustomerID="Rock";
                //customer.CompanyName="RockHe";

                //Customers customer2=new Customers();
                //customer2.CustomerID="BOLID";
                //customer2.CompanyName="Good";

                //ctx.Customers.InsertOnSubmit(customer);
                //ctx.Customers.InsertOnSubmit(customer2);

                //try
                //{
                //    ctx.SubmitChanges();//更新DB  select * from Customers where CustomerID='Rock'查询为空, linq to sql 会把当前上下午做一次事务提交，所以当第二条数据条件失败时会导致整个上下文（DataContext）提交失败
                //}
                //catch (Exception ex)
                //{
                    
                //    //throw;
                //}


                //解决上面问题，可以把每次加入做成一个事务
                Customers customer3 = new Customers();
                customer3.CustomerID = "Rock";
                customer3.CompanyName = "RockHe";

                Customers customer4 = new Customers();
                customer4.CustomerID = "BOLID";
                customer4.CompanyName = "Good";

                CreateCustomer(customer3);
                CreateCustomer(customer4);

            }

        }


        void CreateCustomer(Customers customer)
        {
            ctx.Customers.InsertOnSubmit(customer);
            ctx.SubmitChanges();//立即提交
        }
    }
}
