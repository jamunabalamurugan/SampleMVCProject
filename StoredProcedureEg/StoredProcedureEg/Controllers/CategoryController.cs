using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoredProcedureEg.Models;
namespace StoredProcedureEg.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category,string Save,string Cancel)
        {
            if(!string.IsNullOrEmpty(Save))
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if(!string.IsNullOrEmpty(Cancel))
            {
                ViewBag.Message = "Data was Cancelled";
            }
            return View();
        }
    }
}