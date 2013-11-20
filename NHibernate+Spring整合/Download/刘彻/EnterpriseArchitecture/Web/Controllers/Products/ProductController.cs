using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISegregate.ICommon;
using ISegregate.IProducts;
using Model.Products;

namespace Web.Controllers.Products
{
    /// <summary>
    /// 产品控制器
    ///  控制器的职责范围是专管与视图的控制交互，不包含数据验证和业务逻辑以及类型转化。
    /// 数据验证是Model的职责。类型转化是Segregate的职责，应用逻辑是Service职责，领域逻辑是Domain的职责
    /// </summary>
    public class ProductController : Controller
    {
        private IProductSeg ProductSeg { get; set; }
        private ILogSeg LogSeg { get; set; }
        //
        // GET: Product/Index

        public ActionResult Index()
        {
            List<ProductList> productList=new List<ProductList>();
            try
            {
                productList = ProductSeg.GetAllProducts();
                //... ...
            }
            catch (Exception e)
            {

                LogSeg.WriteLog("ProductController.Index()异常", e);
            }
             
            return View("~/Views/Products/Index.cshtml",productList);
        }
        /// <summary>
        /// 获取产品，通过WebService
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllProducts()
        {
            List<ProductList> productList = new List<ProductList>();
            try
            {
                productList = ProductSeg.GetAllProductsByWebService();
                //... ...
            }
            catch (Exception e)
            {

                LogSeg.WriteLog("ProductController.GetAllProducts()异常", e);
            }

            return View("~/Views/Products/Index.cshtml", productList);
        }
        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View("~/Views/Products/Create.cshtml");
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductList product)
        {
            string p;
            try
            {
                p=product.ProductName;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Product/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
