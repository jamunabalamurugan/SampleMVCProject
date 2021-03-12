using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoredProcedureEg.Models;
namespace StoredProcedureEg.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            var products = db.Products.Where(p=>p.Discontinued==false).ToList();
            return View(products);
        }
        public ActionResult TenExpProducts()
        {
            //var result = db.Ten_Most_Expensive_Products().ToList();
            var result1 = (from p in db.Products
                          where p.UnitPrice > 70
                          select p).ToList();
                          //select new { p.ProductID,TenMostExpensiveProducts = p.ProductName , p.UnitPrice }).ToList();
                          //select new { p.ProductName, p.UnitPrice }).ToList();
            return View(result1);
        }

        public ActionResult Sales()
        {
            return View(db.SalesByCategory("Seafood", "1996"));
        }
        public ActionResult Accept()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Accept(string q)
        {
            var result = db.SalesByCategory(q, "1996");
            return PartialView("_SalesByCategory", result);
        }
        public ActionResult AcceptCategory()
        {
            //Fetch values for DropDownList display
            ViewBag.CategoryName = new SelectList(db.Categories, "CategoryName", "CategoryName");
           // ViewBag.CategoryName = (from c in db.Categories
            //                        select c.CategoryName).Distinct();
            return View();
        }
        [HttpPost]
        public ActionResult AcceptCategory(string CategoryName)
        {
            ViewBag.CategoryName = new SelectList(db.Categories, "CategoryName", "CategoryName");
          //  ViewBag.CategoryName = (from c in db.Categories
          //                          select c.CategoryName).Distinct();
            var result = db.SalesByCategory(CategoryName, "1996");
            return View(result);
          //  return RedirectToAction("SalesByCategory", new { category = @txtCategory });
        }
        public ActionResult SalesByCategory(string category)
        {
            return View(db.SalesByCategory(category,"1996"));
        }
    }
}