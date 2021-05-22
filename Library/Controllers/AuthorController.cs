using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index()
        {
            var values = db.AUTHORs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AuthorAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorAdd(AUTHOR a)
        {
            if(!ModelState.IsValid)
            {
                return View("AuthorAdd");
            }
            db.AUTHORs.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorDel(int id)
        {
            var author = db.AUTHORs.Find(id);
            db.AUTHORs.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult AuthorFind(int id)
        {
            var authorf = db.AUTHORs.Find(id);
            return View("AuthorFind", authorf);

        }
        public ActionResult AuthorUpd(AUTHOR a)
        {
            var athr = db.AUTHORs.Find(a.AUTHOR_ID);
            athr.AUTHOR_NAME = a.AUTHOR_NAME;
            athr.AUTHOR_SURNAME = a.AUTHOR_SURNAME;
            athr.DETAIL = a.DETAIL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}