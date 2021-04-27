using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index()
        {
            var values = db.CATEGORies.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CatAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CatAdd(CATEGORY c)
        {
            db.CATEGORies.Add(c);
            db.SaveChanges();
            return View();
        }
        public ActionResult CatDel(int id)
        {
            var Category = db.CATEGORies.Find(id);
            db.CATEGORies.Remove(Category);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult CatFind(int id)
        {
            var catf = db.CATEGORies.Find(id);
            return View("CatFind", catf);
        }
        public ActionResult CatUpd(CATEGORY c)
        {
            var catu = db.CATEGORies.Find(c.CATEGORY_ID);
            catu.CATEGORY_NAME = c.CATEGORY_NAME;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}